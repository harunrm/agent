using MISL.Ababil.Agent.Infrastructure.Behavior;
using MISL.Ababil.Agent.Infrastructure.Mediators;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account.kyc;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account.tp;
using MISL.Ababil.Agent.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmKYCViewer : Form
    {
        private List<MediatorKycCustomerTurnover> _customerTurnoversKyc = new List<MediatorKycCustomerTurnover>();
        private List<MediatorKycAccountOpeningMode> _openingModesKyc = new List<MediatorKycAccountOpeningMode>();
        private List<MediatorKycCashMonthlyTxnAmount> _txnCashMonthlyTxnAmountsKyc = new List<MediatorKycCashMonthlyTxnAmount>();
        private List<MediatorKycCashMonthlyTxnNumber> _txnCashMonthlyTxnNumbersKyc = new List<MediatorKycCashMonthlyTxnNumber>();
        private List<MediatorKycMonthTxnAmount> _txnAmountsKyc = new List<MediatorKycMonthTxnAmount>();
        private List<MediatorKycMonthTxnNumber> _txnNumbersKyc = new List<MediatorKycMonthTxnNumber>();

        private readonly BindingSource _turnoverBindingSourceKyc = new BindingSource();
        private readonly BindingSource _openingModeBindingSourceKyc = new BindingSource();
        private readonly BindingSource _amountBindingSourceKyc = new BindingSource();
        private readonly BindingSource _numberBindingSourceKyc = new BindingSource();
        private readonly BindingSource _cashAmountBindingSourceKyc = new BindingSource();
        private readonly BindingSource _cashNumberBindingSourceKyc = new BindingSource();
        KycProfile _profile = new KycProfile();

        private readonly List<IKycProfileUpdateObserver> _observersKyc = new List<IKycProfileUpdateObserver>();



        //tp
        private List<CbsTransactionProfile> _transactionProfiles = new List<CbsTransactionProfile>();
        private BindingSource _profileSource = new BindingSource();

        CbsTxnProfileSet _profileSet = new CbsTxnProfileSet();
        private readonly List<ITransactionProfileUpdateObserver> _observers = new List<ITransactionProfileUpdateObserver>();

        //


        public frmKYCViewer()
        {
            InitializeComponent();

            InitializeProfileKyc();

            InitializeListsKyc();

            InitializeDataSourcesKyc();

            InitializeLookupsKyc();

            //SetProfileData(10);

            setControlEnablingKyc();





            //tp
            InitializeTransactionProfileValuesList();

            //SetProfileSetData(23);

            setControlEnabling();
            //ConfigureValidation();

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
            //

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

        private void setControlEnablingKyc()
        {
            //if (!UserWiseRights.subAgentRights.All(s => SessionInfo.rights.Contains(s)))
            if (!UtilityServices.isRightExist(Rights.DRAFT_CONSUMER_APPLICATION))
            {
                DisableControls(this);
                //EnableControls(btnClose);
            }
        }

        public void RegisterProfileUpdateObserverKyc(IKycProfileUpdateObserver observer)
        {
            _observersKyc.Add(observer);
        }

        public void SetProfileDataKyc(long profileId, string customerId, string customerName, string accountNumber)
        {
            SetProfileDataKyc(profileId);

            if (customerId.Length > 0)

                txtCustomerId.Text = customerId;

            else
            {
                txtCustomerId.Enabled = false;
            }

            if (accountNumber.Length > 0)

                txtAccountNumber.Text = accountNumber;

            else
            {
                txtAccountNumber.Enabled = false;
            }

            lblCustomerName.Text = customerName;
        }

        private void SetProfileDataKyc(long profileId)
        {
            if (profileId == 0) return;

            _profile = KycService.GetKycProfile(profileId);

            SetProfileValuesKyc();
        }

        private void SetProfileValuesKyc()
        {
            cmbAccountOpeningMode.SelectedValue = _profile.kycAccountOpeningMode.id;
            cmbMonthlyCashTxnAmount.SelectedValue = _profile.kycCashMonthlyTxnAmount.id;
            cmbMonthlyCashTxnNo.SelectedValue = _profile.kycCashMonthlyTxnNumber.id;
            cmbMonthlyTnxAmount.SelectedValue = _profile.kycMonthTxnAmount.id;
            cmbMonthlyTurnOver.SelectedValue = _profile.kycCustomerTurnover.id;
            cmbMonthlyTxnNumber.SelectedValue = _profile.kycMonthTxnNumber.id;
            txtSourceOfFund.Text = _profile.sourceOfFund;
        }

        private void InitializeProfileKyc()
        {
            _profile.kycAccountOpeningMode = new KycAccountOpeningMode();
            _profile.kycCustomerTurnover = new KycCustomerTurnover();
            _profile.kycMonthTxnAmount = new KycMonthTxnAmount();
            _profile.kycMonthTxnNumber = new KycMonthTxnNumber();
            _profile.kycCashMonthlyTxnAmount = new KycCashMonthlyTxnAmount();
            _profile.kycCashMonthlyTxnNumber = new KycCashMonthlyTxnNumber();
            _profile.id = 0;
            _profile.sourceOfFund = "N/A";
        }

        private void InitializeLookupsKyc()
        {
            UtilityServices.fillComboBox(cmbAccountOpeningMode, _openingModeBindingSourceKyc, "OpeningModeDescription", "Id");
            UtilityServices.fillComboBox(cmbMonthlyTurnOver, _turnoverBindingSourceKyc, "TurnOverDescription", "Id");
            UtilityServices.fillComboBox(cmbMonthlyTnxAmount, _amountBindingSourceKyc, "TransactionAmountDescription", "Id");
            UtilityServices.fillComboBox(cmbMonthlyTxnNumber, _numberBindingSourceKyc, "TransactionNumberDescription", "Id");
            UtilityServices.fillComboBox(cmbMonthlyCashTxnAmount, _cashAmountBindingSourceKyc, "TransactionAmountDescription", "Id");
            UtilityServices.fillComboBox(cmbMonthlyCashTxnNo, _cashNumberBindingSourceKyc, "TransactionNumberDescription", "Id");
        }

        private void InitializeDataSourcesKyc()
        {
            _openingModeBindingSourceKyc.DataSource = _openingModesKyc;
            _turnoverBindingSourceKyc.DataSource = _customerTurnoversKyc;
            _amountBindingSourceKyc.DataSource = _txnAmountsKyc;
            _numberBindingSourceKyc.DataSource = _txnNumbersKyc;
            _cashAmountBindingSourceKyc.DataSource = _txnCashMonthlyTxnAmountsKyc;
            _cashNumberBindingSourceKyc.DataSource = _txnCashMonthlyTxnNumbersKyc;
        }

        private void InitializeListsKyc()
        {
            _openingModesKyc = KycService.GetAccountOpeningModes();
            _customerTurnoversKyc = KycService.getCustomerTurnovers();
            _txnAmountsKyc = KycService.getTransactionAmount();
            _txnNumbersKyc = KycService.getTransactionNumbers();
            _txnCashMonthlyTxnAmountsKyc = KycService.getCashTransactionAmount();
            _txnCashMonthlyTxnNumbersKyc = KycService.getCashTransactionNumbers();
        }



        private KycProfile FillKycProfileDataKyc()
        {
            _profile.sourceOfFund = txtSourceOfFund.Text;
            _profile.kycAccountOpeningMode.id = Convert.ToInt32(cmbAccountOpeningMode.SelectedValue);
            _profile.kycCustomerTurnover.id = Convert.ToInt32(cmbMonthlyTurnOver.SelectedValue);
            _profile.kycMonthTxnAmount.id = Convert.ToInt32(cmbMonthlyTnxAmount.SelectedValue);
            _profile.kycMonthTxnNumber.id = Convert.ToInt32(cmbMonthlyTxnNumber.SelectedValue);
            _profile.kycCashMonthlyTxnAmount.id = Convert.ToInt32(cmbMonthlyCashTxnAmount.SelectedValue);
            _profile.kycCashMonthlyTxnNumber.id = Convert.ToInt32(cmbMonthlyCashTxnNo.SelectedValue);

            return _profile;
        }

        public long IdKyc { get; set; }

        private void txtCustomerId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (Keys)e.KeyChar != Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            OnKeyPress(e);
        }
        private void ClearAllInputDataKyc()
        {
            txtCustomerId.Text = string.Empty;
            txtSourceOfFund.Text = string.Empty;
            txtAccountNumber.Text = string.Empty;
            cmbMonthlyTurnOver.Text = string.Empty;
            cmbMonthlyTxnNumber.Text = string.Empty;
            cmbAccountOpeningMode.Text = string.Empty;
            cmbMonthlyCashTxnNo.Text = string.Empty;
            cmbMonthlyCashTxnAmount.Text = string.Empty;
            cmbMonthlyTnxAmount.Text = string.Empty;
            txtCommets.Text = string.Empty;
        }

        private void ClearProfileDataKyc()
        {
            _profile.id = 0;
            _profile.kycAccountOpeningMode.id = 0;
            _profile.kycCashMonthlyTxnAmount.id = 0;
            _profile.kycCashMonthlyTxnNumber.id = 0;
            _profile.kycCustomerTurnover.id = 0;
            _profile.kycMonthTxnAmount.id = 0;
            _profile.kycMonthTxnNumber.id = 0;

            ClearCombosKyc();
        }

        private void ClearCombosKyc()
        {
            cmbAccountOpeningMode.SelectedIndex = 0;
            cmbMonthlyCashTxnAmount.SelectedIndex = 0;
            cmbMonthlyCashTxnNo.SelectedIndex = 0;
            cmbMonthlyTnxAmount.SelectedIndex = 0;
            cmbMonthlyTurnOver.SelectedIndex = 0;
            cmbMonthlyTxnNumber.SelectedIndex = 0;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void RegisterProfileUpdateObserver(ITransactionProfileUpdateObserver observer)
        {
            _observers.Add(observer);
        }


        public void SetProfileSetData(long profileSetId, string customerName)
        {
            this.lblCustomerName.Text = customerName;
            if (profileSetId == 0) return;



            _profileSet = ProfileService.GetProfileSet(profileSetId);

            SetProfileValues();
        }
        //private void DisableControls(Control con)
        //{
        //    foreach (Control c in con.Controls)
        //    {
        //        DisableControls(c);
        //    }
        //    con.Enabled = false;
        //}

        //private void EnableControls(Control con)
        //{
        //    if (con != null)
        //    {
        //        con.Enabled = true;
        //        EnableControls(con.Parent);
        //    }
        //}

        private void setControlEnabling()
        {
            //if (!UserWiseRights.subAgentRights.All(s => SessionInfo.rights.Contains(s)))
            if (!UtilityServices.isRightExist(Rights.DRAFT_CONSUMER_APPLICATION))
            {
                DisableControls(this);
                //EnableControls(btnClose);
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






        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dgCustomerTnxProfile_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSourceOfFund_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCustomerId_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void lblSourceOfFund_Click(object sender, EventArgs e)
        {

        }

        private void lblCustomerID_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cmbMonthlyTnxAmount_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbMonthlyTurnOver_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbMonthlyCashTxnAmount_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbMonthlyCashTxnNo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbMonthlyTxnNumber_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbAccountOpeningMode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtCommets_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAccountNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblComments_Click(object sender, EventArgs e)
        {

        }

        private void lblAccountNumber_Click(object sender, EventArgs e)
        {

        }

        private void lblMonthlyTurnover_Click(object sender, EventArgs e)
        {

        }

        private void lblAccountOpeningMode_Click(object sender, EventArgs e)
        {

        }

        private void lblMonthlyTxnNumber_Click(object sender, EventArgs e)
        {

        }

        private void lblMonthlYTxnAount_Click(object sender, EventArgs e)
        {

        }

        private void lblAccountName_Click(object sender, EventArgs e)
        {

        }

        private void lblCustomerName_Click(object sender, EventArgs e)
        {

        }

        private void gpbSearchOption_Enter(object sender, EventArgs e)
        {

        }

        private void frmKYCViewer_Load(object sender, EventArgs e)
        {

        }
    }
}