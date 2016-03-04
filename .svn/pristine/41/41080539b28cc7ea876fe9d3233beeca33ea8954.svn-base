using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using MISL.Ababil.Agent.Infrastructure.Behavior;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account.tp;
using MISL.Ababil.Agent.Services;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using System.Linq;
using MISL.Ababil.Agent.Infrastructure.Validation;
using MISL.Ababil.Agent.UI.forms.ProgressUI;

namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmCustomerTransactionProfile : Form
    {

        private List<CbsTransactionProfile> _transactionProfiles = new List<CbsTransactionProfile>();
        private BindingSource _profileSource = new BindingSource();

        CbsTxnProfileSet _profileSet = new CbsTxnProfileSet();
        private readonly List<ITransactionProfileUpdateObserver> _observers = new List<ITransactionProfileUpdateObserver>();


        public frmCustomerTransactionProfile()
        {
            InitializeComponent();

            InitializeTransactionProfileValuesList();

            //SetProfileSetData(23);

            setControlEnabling();
            ConfigureValidation();

            try
            {
                List<CbsTransactionProfile> remainingLimits = new List<CbsTransactionProfile>();
                remainingLimits.AddRange(this._transactionProfiles);
                int rowIndex = 0;
                foreach (CbsTransactionProfile profile in remainingLimits)
                {
                    dgCustomerTnxProfile.Rows.Add();
                    //dgCustomerTnxProfile["SLNo", rowIndex].Value = rowIndex + 1;
                    dgCustomerTnxProfile["gvColTransactionType", rowIndex].Value = profile.id;
                    dgCustomerTnxProfile["gvColDbNo", rowIndex].Value = 0;
                    dgCustomerTnxProfile["gvDbAmount", rowIndex].Value = 0;
                    dgCustomerTnxProfile["gvTotalDrAmount", rowIndex].Value = 0;
                    dgCustomerTnxProfile["gvCrNo", rowIndex].Value = 0;
                    dgCustomerTnxProfile["gvCrAccount", rowIndex].Value = 0;
                    dgCustomerTnxProfile["gvCrTotalAmount", rowIndex].Value = 0;
                    dgCustomerTnxProfile["gvStopTransaction", rowIndex].Value = true;
                    rowIndex++;
                }
            }
            catch (Exception exception)
            {
                //ignored
            }
        }

        private void ConfigureValidation()
        {
            ValidationManager.ConfigureValidation(this, dgCustomerTnxProfile, "Transaction Details", (long)ValidationType.GridHasRows, true);
        }

        public void RegisterProfileUpdateObserver(ITransactionProfileUpdateObserver observer)
        {
            _observers.Add(observer);
        }

        public void SetProfileSetData(long profileSetId, string customerName)
        {
            if (!string.IsNullOrEmpty(customerName))
            {
                lblCustomerName.Text = customerName;
            }
            else
            {
                lblCustomerName.Text = "(New Customer)";
            }
            if (profileSetId == 0) return;

            _profileSet = ProfileService.GetProfileSet(profileSetId);
            SetProfileValues();
        }

        private void DisableControls(Control con)
        {
            foreach (Control c in con.Controls)
            {
                DisableControls(c);
            }
            con.Enabled = false;
        }

        private void EnableControls(Control con)
        {
            if (con != null)
            {
                con.Enabled = true;
                EnableControls(con.Parent);
            }
        }

        private void setControlEnabling()
        {
            //if (!UserWiseRights.subAgentRights.All(s => SessionInfo.rights.Contains(s)))
            if (!UtilityServices.isRightExist(Rights.DRAFT_CONSUMER_APPLICATION))
            {
                DisableControls(this);
                EnableControls(btnClose);
            }
        }
        private void SetProfileValues()
        {
            int rowIndex = 0;
            dgCustomerTnxProfile.Rows.Clear();
            //try
            //{

            List<CbsTransactionProfile> remainingLimits = new List<CbsTransactionProfile>();
            remainingLimits.AddRange(this._transactionProfiles);

            foreach (CbsTransactionLimit limit in _profileSet.transactionLimits)
            {
                foreach (CbsTransactionProfile profile in remainingLimits)
                {
                    if (profile.id == limit.txnProfile.id)
                    {
                        remainingLimits.Remove(profile);
                        break;
                    }
                }

                //remainingLimits.Remove(limit);
                dgCustomerTnxProfile.Rows.Add();
                //dgCustomerTnxProfile["SLNo", rowIndex].Value = rowIndex + 1;
                dgCustomerTnxProfile["gvColTransactionType", rowIndex].Value = limit.txnProfile.id;
                dgCustomerTnxProfile["gvColDbNo", rowIndex].Value = limit.dailyDebitTxnNo;
                dgCustomerTnxProfile["gvDbAmount", rowIndex].Value = limit.singleTxnDebitLimit;
                dgCustomerTnxProfile["gvTotalDrAmount", rowIndex].Value = limit.totalDebitAmount;
                dgCustomerTnxProfile["gvCrNo", rowIndex].Value = limit.dailyCreditTxnNo;
                dgCustomerTnxProfile["gvCrAccount", rowIndex].Value = limit.singleTxnCreditLimit;
                dgCustomerTnxProfile["gvCrTotalAmount", rowIndex].Value = limit.totalCreditAmount;
                dgCustomerTnxProfile["gvStopTransaction", rowIndex].Value = limit.valid;

                rowIndex++;
            }


            foreach (CbsTransactionProfile profile in remainingLimits)
            {
                dgCustomerTnxProfile.Rows.Add();
                rowIndex = dgCustomerTnxProfile.RowCount - 2;
                //dgCustomerTnxProfile["SLNo", rowIndex].Value = rowIndex + 1;
                dgCustomerTnxProfile["gvColTransactionType", rowIndex].Value = profile.id;
                dgCustomerTnxProfile["gvColDbNo", rowIndex].Value = 0;
                dgCustomerTnxProfile["gvDbAmount", rowIndex].Value = 0;
                dgCustomerTnxProfile["gvTotalDrAmount", rowIndex].Value = 0;
                dgCustomerTnxProfile["gvCrNo", rowIndex].Value = 0;
                dgCustomerTnxProfile["gvCrAccount", rowIndex].Value = 0;
                dgCustomerTnxProfile["gvCrTotalAmount", rowIndex].Value = 0;
                dgCustomerTnxProfile["gvStopTransaction", rowIndex].Value = true;

            }

            //}
            //catch (Exception exception)
            //{
            //ignore
            //}



        }
        private void GetProfileValues()
        {
            List<CbsTransactionLimit> newLimits = GetLimits();

            _profileSet.transactionLimits = newLimits;
        }

        private List<CbsTransactionLimit> GetLimits()
        {
            List<CbsTransactionLimit> newLimits = new List<CbsTransactionLimit>();

            foreach (DataGridViewRow row in dgCustomerTnxProfile.Rows)
            {
                CbsTransactionLimit limit = new CbsTransactionLimit();
                limit.txnProfile = new CbsTransactionProfile();
                object transactionType = row.Cells["gvColTransactionType"].Value;
                if (transactionType == null) continue;
                limit.txnProfile.id = (long)transactionType;

                limit.dailyDebitTxnNo = GetSafeNullableIntValueFromField(row, "gvColDbNo");
                limit.singleTxnDebitLimit = GetSafeDecimalValueFromField(row, "gvDbAmount");
                limit.totalDebitAmount = GetSafeDecimalValueFromField(row, "gvTotalDrAmount");
                limit.dailyCreditTxnNo = GetSafeNullableIntValueFromField(row, "gvCrNo");
                limit.singleTxnCreditLimit = GetSafeDecimalValueFromField(row, "gvCrAccount");
                limit.totalCreditAmount = GetSafeDecimalValueFromField(row, "gvCrTotalAmount");
                limit.valid = true; // row.Cells["gvStopTransaction"].Value.ToString().Equals("True") ? true : false;

                newLimits.Add(limit);
            }
            return newLimits;
        }

        private static decimal GetSafeDecimalValueFromField(DataGridViewRow row, string columnName)
        {
            decimal result;
            decimal dailyDebitTxnNo = 0;
            var cellValue = row.Cells[columnName].Value;
            if (cellValue == null) return dailyDebitTxnNo;
            bool success = decimal.TryParse(cellValue.ToString(), out result);
            if (success)
            {
                dailyDebitTxnNo = result;
            }
            return dailyDebitTxnNo;
        }

        private static int? GetSafeNullableIntValueFromField(DataGridViewRow row, string columnName)
        {
            int result;
            int? dailyDebitTxnNo = 0;
            var cellValue = row.Cells[columnName].Value;
            if (cellValue == null) return dailyDebitTxnNo;
            bool success = int.TryParse(cellValue.ToString(), out result);
            if (success)
            {
                dailyDebitTxnNo = result;
            }
            return dailyDebitTxnNo;
        }


        private void InitializeTransactionProfileValuesList()
        {
            _transactionProfiles = ProfileService.GetProfiles();

            _profileSource.DataSource = _transactionProfiles;

            gvColTransactionType.DataSource = _profileSource;
            gvColTransactionType.DisplayMember = "description";
            gvColTransactionType.ValueMember = "id";
        }

        private void txtAccountNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (Keys)e.KeyChar != Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            OnKeyPress(e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dgCustomerTnxProfile.Rows.Clear(); ;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;

            if (ValidationCheck())
            {
                string retrnMsg;

                GetProfileValues();

                List<long> limitCount = new List<long>();
                string duplicateLimit = "";

                foreach (CbsTransactionLimit limit in _profileSet.transactionLimits)
                {
                    if (limitCount.Contains(limit.txnProfile.id))
                    {
                        foreach (CbsTransactionProfile profile in _transactionProfiles)
                        {
                            if (profile.id == limit.txnProfile.id)
                            {
                                limit.txnProfile.description = profile.description;
                                break;
                            }
                        }

                        duplicateLimit = duplicateLimit + "\n" + limit.txnProfile.description;

                    }
                    else
                    {
                        limitCount.Add(limit.txnProfile.id);
                    }
                }

                if (duplicateLimit.Length > 0)
                {
                    MessageBox.Show("Duplicate Limit exists for the following limits: " + "\n" + duplicateLimit);
                    btnSave.Enabled = true;
                    return;
                }

                try
                {
                    ProgressUIManager.ShowProgress(this);

                    retrnMsg = ProfileService.SaveProfileData(_profileSet);
                    _profileSet.id = Convert.ToInt32(retrnMsg);

                    foreach (ITransactionProfileUpdateObserver observer in _observers)
                    {
                        if (observer != null) observer.ProfileSetUpdated(_profileSet);
                    }

                    ProgressUIManager.CloseProgress();

                    MessageBox.Show(StringTable.Transaction_Profile_was_saved_successfully);

                    
                    this.Close();
                }
                catch (Exception ex)
                {
                    ProgressUIManager.CloseProgress();
                    btnSave.Enabled = true;
                    Message.showError(ex.Message);
                }

            }

            btnSave.Enabled = true;
        }

        private void dgCustomerTnxProfile_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
        }

        private void dgCustomerTnxProfile_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgCustomerTnxProfile_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

            if (e.ColumnIndex < 1) return;
            string formattedValue = e.FormattedValue.ToString();
            if (!ValidationManager.ValidatePositive(formattedValue))
            {
                e.Cancel = true;
                MessageBox.Show(StringTable.Numeric_value_is_expected, StringTable.InputErrors);
            }
        }

        public long GetTPNo()
        {
            return _profileSet.id;
        }

        private bool ValidationCheck()
        {
            return ValidationManager.ValidateForm(this);
        }

        private void frmCustomerTransactionProfile_FormClosing(object sender, FormClosingEventArgs e)
        {
            ValidationManager.ReleaseValidationData(this);
        }
    }
}
