using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;
using MISL.Ababil.Agent.Infrastructure.Validation;

using MISL.Ababil.Agent.Infrastructure.Behavior;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account.tp;
using MISL.Ababil.Agent.Services;
using MISL.Ababil.Agent.UI.forms.ProgressUI;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account.kyc;
using MISL.Ababil.Agent.Infrastructure.Mediators;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account;

namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmTPAndKYC : MetroForm
    {
        private Packet _receivePacket;
        public bool _viewMode = false;
        private TpMode _tpMode;
        private TpType _tpType;
        private ProductType _productType;
        private DepositAccountCategory _accCategory;
        private bool _isKYCTxnInputVisibile;

        //private bool isTxnProfileSet = false;
        //private bool isKYCSet = false;

        private List<CbsTransactionProfile> _transactionProfiles = new List<CbsTransactionProfile>();
        private BindingSource _kycProfileSource = new BindingSource();

        CbsTxnProfileSet _txnProfileSet = new CbsTxnProfileSet();
        private readonly List<ITransactionProfileUpdateObserver> _observers = new List<ITransactionProfileUpdateObserver>();

        KycProfile _kycProfile = new KycProfile();
        long? _kycId;
        string _customerId = "";
        string _customerTitle = "";

        private List<MediatorKycCustomerTurnover> _KYCcustomerTurnovers = new List<MediatorKycCustomerTurnover>();
        private List<MediatorKycAccountOpeningMode> _KYCopeningModes = new List<MediatorKycAccountOpeningMode>();
        private List<MediatorKycCashMonthlyTxnAmount> _KYCtxnCashMonthlyTxnAmounts = new List<MediatorKycCashMonthlyTxnAmount>();
        private List<MediatorKycCashMonthlyTxnNumber> _KYCtxnCashMonthlyTxnNumbers = new List<MediatorKycCashMonthlyTxnNumber>();
        private List<MediatorKycMonthTxnAmount> _KYCtxnAmounts = new List<MediatorKycMonthTxnAmount>();
        private List<MediatorKycMonthTxnNumber> _KYCtxnNumbers = new List<MediatorKycMonthTxnNumber>();

        private readonly BindingSource _turnoverBindingSource = new BindingSource();
        private readonly BindingSource _openingModeBindingSource = new BindingSource();
        private readonly BindingSource _amountBindingSource = new BindingSource();
        private readonly BindingSource _numberBindingSource = new BindingSource();
        private readonly BindingSource _cashAmountBindingSource = new BindingSource();
        private readonly BindingSource _cashNumberBindingSource = new BindingSource();

        public frmTPAndKYC()
        {
            try
            {
                InitializeComponent();
                SetNewTransactionProfile();
                Packet pack = new Packet();
                _loadKYC(pack, 0);
            }
            catch (Exception exception)
            { MessageBox.Show(exception.Message); }
        }
        public frmTPAndKYC(bool isKYCTxnInputVisibile)
        {
            try
            {
                InitializeComponent();
                SetNewTransactionProfile();
                Packet pack = new Packet();
                _loadKYC(pack, 0);
                _visibleControlsKYC(isKYCTxnInputVisibile); // These controls are invisible for Ter Accounts
            }
            catch (Exception exception)
            { MessageBox.Show(exception.Message); }
        }
        public frmTPAndKYC(ProductType productType, DepositAccountCategory accCategory, bool isKYCTxnInputVisibile)
        {
            try
            {
                InitializeComponent();
                _productType = productType;
                _accCategory = accCategory;

                if(productType == ProductType.Deposit) SetNewTransactionProfile();
                else this.tpAndKYC.TabPages.RemoveAt(0);

                Packet pack = new Packet();
                _loadKYC(pack, 0);
                _visibleControlsKYC(isKYCTxnInputVisibile); // These controls are invisible for Ter Accounts
            }
            catch (Exception exception)
            { MessageBox.Show(exception.Message); }
        }

        #region Transaction Profile        
        private void SetNewTransactionProfile()
        {
            try
            {
                dgvCreditTP.Rows.Clear();
                dgvDebitTP.Rows.Clear();
                _transactionProfiles = ProfileService.GetProfiles();
                _enableControlsTP(true);
                //ConfigureValidation();

                List<CbsTransactionProfile> remainingLimits = new List<CbsTransactionProfile>();
                remainingLimits.AddRange(this._transactionProfiles);
                int rowIndex_Credit = 0, rowIndex_Debit = 0;
                foreach (CbsTransactionProfile profile in remainingLimits)
                {
                    if (profile.tpType == TpType.CREDIT)
                    {
                        dgvCreditTP.Rows.Add();
                        //dgCustomerTnxProfile["SLNo", rowIndex_Credit].Value = rowIndex + 1;
                        dgvCreditTP["gvColTransactionType", rowIndex_Credit].Value = profile.description;
                        dgvCreditTP["gvColNoOfCredit", rowIndex_Credit].Value = 0;
                        dgvCreditTP["gvColCreditAmount", rowIndex_Credit].Value = 0;
                        dgvCreditTP["gvColTotalCreditAmount", rowIndex_Credit].Value = 0;
                        dgvCreditTP["gvColTransactionTypeID", rowIndex_Credit].Value = profile.id;
                        dgvCreditTP["gvColTpMode", rowIndex_Credit].Value = profile.tpMode;
                        dgvCreditTP["gvColTpType", rowIndex_Credit].Value = profile.tpType;
                        rowIndex_Credit++;
                    }
                    else if (profile.tpType == TpType.DEBIT)
                    {
                        dgvDebitTP.Rows.Add();
                        //dgCustomerTnxProfile["SLNo", rowIndex_Debit].Value = rowIndex + 1;
                        dgvDebitTP["gvColTransactionTypeDebit", rowIndex_Debit].Value = profile.description;
                        dgvDebitTP["gvColNoOfDebit", rowIndex_Debit].Value = 0;
                        dgvDebitTP["gvColDebitAmount", rowIndex_Debit].Value = 0;
                        dgvDebitTP["gvColTotalDebitAmount", rowIndex_Debit].Value = 0;
                        dgvDebitTP["gvColTransactionTypeIDDebit", rowIndex_Debit].Value = profile.id;
                        dgvDebitTP["gvColTpModeDebit", rowIndex_Debit].Value = profile.tpMode;
                        dgvDebitTP["gvColTpTypeDebit", rowIndex_Debit].Value = profile.tpType;
                        rowIndex_Debit++;
                    }
                }
            }
            catch (Exception exp)
            { MessageBox.Show(exp.Message); }
        }
        public void _enableControlsTP(bool isEnabled)
        {
            dgvCreditTP.Enabled = dgvDebitTP.Enabled = isEnabled;
        }
        public long GetTxnProfileNo()
        {
            return _txnProfileSet.id;
        }
        private void ConfigureValidation()
        {
            ValidationManager.ConfigureValidation(this, dgvCreditTP, "Transaction Details", (long)ValidationType.GridHasRows, true);
        }

        public void SetTxnProfileSetData(long profileSetId, string customerName)
        {
            if (!string.IsNullOrEmpty(customerName))
            {
                _customerTitle = customerName;
                txtCustomerName.Text = customerName;
            }
            else
            {
                txtCustomerName.Text = "(New Customer)";
            }
            if (profileSetId == 0) return;

            _txnProfileSet = ProfileService.GetProfileSet(profileSetId);
            SetSavedTxnProfileValues();
        }
        private void SetSavedTxnProfileValues()
        {
            try
            {
                int rowIndexCredit = 0;
                int rowIndexDebit = 0;
                dgvCreditTP.Rows.Clear();
                dgvDebitTP.Rows.Clear();
                List<CbsTransactionProfile> remainingLimits_Credit = new List<CbsTransactionProfile>();
                List<CbsTransactionProfile> remainingLimits_Debit = new List<CbsTransactionProfile>();
                remainingLimits_Credit.AddRange(this._transactionProfiles);
                remainingLimits_Debit.AddRange(this._transactionProfiles);

                foreach (CbsTransactionLimit limit in _txnProfileSet.transactionLimits)
                {
                    foreach (CbsTransactionProfile profile in remainingLimits_Credit)
                    {
                        if (profile.id == limit.txnProfile.id)
                        {
                            remainingLimits_Credit.Remove(profile);
                            break;
                        }
                    }

                    if (limit.txnProfile.tpType == TpType.CREDIT)
                    {
                        dgvCreditTP.Rows.Add();
                        //dgCustomerTnxProfile["SLNo", rowIndexCredit].Value = rowIndex + 1;
                        dgvCreditTP["gvColTransactionType", rowIndexCredit].Value = limit.txnProfile.description;
                        dgvCreditTP["gvColNoOfCredit", rowIndexCredit].Value = limit.monthlyTxnCreditNo;
                        dgvCreditTP["gvColCreditAmount", rowIndexCredit].Value = limit.singleTxnCreditLimit;
                        //dgvCreditTP["gvColTotalCreditAmount", rowIndexCredit].Value = limit.totalCreditAmount;
                        dgvCreditTP["gvColTotalCreditAmount", rowIndexCredit].Value = limit.monthlyTxnCreditLimit;
                        dgvCreditTP["gvColTransactionTypeID", rowIndexCredit].Value = limit.txnProfile.id;
                        dgvCreditTP["gvColTpMode", rowIndexCredit].Value = limit.txnProfile.tpMode;
                        dgvCreditTP["gvColTpType", rowIndexCredit].Value = limit.txnProfile.tpType;
                        rowIndexCredit++;
                    }
                    else if (limit.txnProfile.tpType == TpType.DEBIT)
                    {
                        dgvDebitTP.Rows.Add();
                        //dgvDebitTP["SLNo", rowIndexDebit].Value = rowIndex + 1;
                        dgvDebitTP["gvColTransactionTypeDebit", rowIndexDebit].Value = limit.txnProfile.description;
                        dgvDebitTP["gvColNoOfDebit", rowIndexDebit].Value = limit.monthlyTxnDebitNo;
                        dgvDebitTP["gvColDebitAmount", rowIndexDebit].Value = limit.singleTxnDebitLimit;
                        //dgvDebitTP["gvColTotalDebitAmount", rowIndexDebit].Value = limit.totalDebitAmount;
                        dgvDebitTP["gvColTotalDebitAmount", rowIndexDebit].Value = limit.monthlyTxnDebitLimit;
                        dgvDebitTP["gvColTransactionTypeIDDebit", rowIndexDebit].Value = limit.txnProfile.id;
                        dgvDebitTP["gvColTpModeDebit", rowIndexDebit].Value = limit.txnProfile.tpMode;
                        dgvDebitTP["gvColTpTypeDebit", rowIndexDebit].Value = limit.txnProfile.tpType;
                        rowIndexDebit++;
                    }
                }

                foreach (CbsTransactionProfile profile in remainingLimits_Credit)
                {
                    if (profile.tpType == TpType.CREDIT)
                    {
                        dgvCreditTP.Rows.Add();
                        rowIndexCredit = dgvCreditTP.RowCount - 2;
                        //dgCustomerTnxProfile["SLNo", rowIndexCredit].Value = rowIndex + 1;
                        dgvCreditTP["gvColTransactionType", rowIndexCredit].Value = profile.description;
                        dgvCreditTP["gvColNoOfCredit", rowIndexCredit].Value = 0;
                        dgvCreditTP["gvColCreditAmount", rowIndexCredit].Value = 0;
                        dgvCreditTP["gvColTotalCreditAmount", rowIndexCredit].Value = 0;
                        //dgvCreditTP["gvStopTransaction", rowIndexCredit].Value = true;
                        rowIndexCredit++;
                    }
                    else if (profile.tpType == TpType.DEBIT)
                    {
                        dgvDebitTP.Rows.Add();
                        rowIndexDebit = dgvCreditTP.RowCount - 2;
                        //dgvDebitTP["SLNo", rowIndex].Value = rowIndex + 1;
                        dgvDebitTP["gvColTransactionTypeDebit", rowIndexDebit].Value = profile.description;
                        dgvDebitTP["gvColNoOfDebit", rowIndexDebit].Value = 0;
                        dgvDebitTP["gvColDebitAmount", rowIndexDebit].Value = 0;
                        dgvDebitTP["gvColTotalDebitAmount", rowIndexDebit].Value = 0;
                        //dgvDebitTP["gvStopTransaction", rowIndexDebit].Value = true;
                        rowIndexDebit++;
                    }
                }
            }
            catch (Exception exp) 
            { Message.showError(exp.Message); }
        }
        private TPValidationCheck IsValidTP(CbsTransactionLimit passedLimit)
        {
            try
            {
                TPValidationCheck validCheck = new TPValidationCheck();
                validCheck.validTP = true;

                if (passedLimit.monthlyTxnCreditNo == 0 && passedLimit.monthlyTxnDebitNo == 0)
                {
                    validCheck.validTP = true; validCheck.validationMessage = "";    
                    return validCheck; 
                }
                else if (passedLimit.monthlyTxnCreditNo != 0)
                {
                    //if (passedLimit.singleTxnCreditLimit > passedLimit.totalCreditAmount)
                    if (passedLimit.singleTxnCreditLimit > passedLimit.monthlyTxnCreditLimit)
                    {
                        validCheck.validTP = false;
                        validCheck.validationMessage = "Credit amount exceeded Total credit limit. [" + passedLimit.txnProfile.description + "]";
                    }

                    decimal? totalCreditLimit = passedLimit.monthlyTxnCreditNo * passedLimit.singleTxnCreditLimit;
                    //if (passedLimit.totalCreditAmount > totalCreditLimit)
                    if (passedLimit.monthlyTxnCreditLimit > totalCreditLimit)
                    {
                        validCheck.validTP = false;
                        validCheck.validationMessage = "Total credit limit is " + totalCreditLimit.ToString() + " . [" + passedLimit.txnProfile.description + "]";
                    }
                }
                else if (passedLimit.monthlyTxnDebitNo != 0)
                {
                    //if (passedLimit.singleTxnDebitLimit > passedLimit.totalDebitAmount)
                    if (passedLimit.singleTxnDebitLimit > passedLimit.monthlyTxnDebitLimit)
                    {
                        validCheck.validTP = false;
                        validCheck.validationMessage = "Debit amount exceeded Total debit limit. [" + passedLimit.txnProfile.description + "]";
                    }

                    decimal? totalDebitLimit = passedLimit.monthlyTxnDebitNo * passedLimit.singleTxnDebitLimit;
                    //if (passedLimit.totalDebitAmount > totalDebitLimit)
                    if (passedLimit.monthlyTxnDebitLimit > totalDebitLimit)
                    {
                        validCheck.validTP = false;
                        validCheck.validationMessage = "Total debit amount limit is " + totalDebitLimit.ToString() + " . [" + passedLimit.txnProfile.description + "]";
                    }
                }

                return validCheck;
            }
            catch (Exception exp)
            { 
                Message.showError(exp.Message);
                return null;
            }
        }
        private List<CbsTransactionLimit> GetTxnLimits()
        {
            List<CbsTransactionLimit> newLimits = new List<CbsTransactionLimit>();
            TPValidationCheck validateTP = new TPValidationCheck();

            foreach (DataGridViewRow rowCredit in dgvCreditTP.Rows)
            {
                CbsTransactionLimit limit = new CbsTransactionLimit();
                limit.txnProfile = new CbsTransactionProfile();
                object trTypeCreditID = rowCredit.Cells["gvColTransactionTypeID"].Value;
                if (trTypeCreditID == null) continue;
                limit.txnProfile.id = (long)trTypeCreditID;
                limit.txnProfile.description = rowCredit.Cells["gvColTransactionType"].Value.ToString();

                limit.monthlyTxnCreditNo = GetSafeNullableIntValueFromField(rowCredit, "gvColNoOfCredit");
                if (limit.monthlyTxnCreditNo == 0)
                {
                    limit.singleTxnCreditLimit = 0;
                    //limit.totalCreditAmount = 0;
                    limit.monthlyTxnCreditLimit = 0;
                }
                else
                {
                    limit.singleTxnCreditLimit = GetSafeDecimalValueFromField(rowCredit, "gvColCreditAmount");
                    //limit.totalCreditAmount = GetSafeDecimalValueFromField(rowCredit, "gvColTotalCreditAmount");
                    limit.monthlyTxnCreditLimit = GetSafeDecimalValueFromField(rowCredit, "gvColTotalCreditAmount");
                }
                limit.monthlyTxnDebitNo = 0;
                limit.singleTxnDebitLimit = 0;
                //limit.totalDebitAmount = 0;
                limit.monthlyTxnDebitLimit = 0;
                limit.txnProfile.tpMode = (TpMode)rowCredit.Cells["gvColTpMode"].Value;
                limit.txnProfile.tpType = (TpType)rowCredit.Cells["gvColTpType"].Value;
                limit.valid = true;

                if (this.tpAndKYC.SelectedTab != tabTransacProfile) validateTP = IsValidTP(limit);
                else { validateTP.validTP = true; }

                if (validateTP.validTP) newLimits.Add(limit);
                else
                {
                    this.tpAndKYC.SelectTab(tabTransacProfile);
                    Message.showWarning(validateTP.validationMessage);
                    return null;
                }
            }

            foreach (DataGridViewRow rowDebit in dgvDebitTP.Rows)
            {
                CbsTransactionLimit limit = new CbsTransactionLimit();
                limit.txnProfile = new CbsTransactionProfile();
                object trTypeDebitID = rowDebit.Cells["gvColTransactionTypeIDDebit"].Value;
                if (trTypeDebitID == null) continue;
                limit.txnProfile.id = (long)trTypeDebitID;
                limit.txnProfile.description = rowDebit.Cells["gvColTransactionTypeDebit"].Value.ToString();

                limit.monthlyTxnCreditNo = 0;
                limit.singleTxnCreditLimit = 0;
                //limit.totalCreditAmount = 0;
                limit.monthlyTxnCreditLimit = 0;
                limit.monthlyTxnDebitNo = GetSafeNullableIntValueFromField(rowDebit, "gvColNoOfDebit");
                if (limit.monthlyTxnDebitNo == 0)
                {
                    limit.singleTxnDebitLimit = 0;
                    //limit.totalDebitAmount = 0;
                    limit.monthlyTxnDebitLimit = 0;
                }
                else
                {
                    limit.singleTxnDebitLimit = GetSafeDecimalValueFromField(rowDebit, "gvColDebitAmount");
                    //limit.totalDebitAmount = GetSafeDecimalValueFromField(rowDebit, "gvColTotalDebitAmount");
                    limit.monthlyTxnDebitLimit = GetSafeDecimalValueFromField(rowDebit, "gvColTotalDebitAmount");
                }
                limit.txnProfile.tpMode = (TpMode)rowDebit.Cells["gvColTpModeDebit"].Value;
                limit.txnProfile.tpType = (TpType)rowDebit.Cells["gvColTpTypeDebit"].Value;
                limit.valid = true;

                if (this.tpAndKYC.SelectedTab != tabTransacProfile) validateTP = IsValidTP(limit);
                else { validateTP.validTP = true; }

                if (validateTP.validTP) newLimits.Add(limit);
                else
                {
                    this.tpAndKYC.SelectTab(tabTransacProfile);
                    Message.showWarning(validateTP.validationMessage);
                    return null;
                }
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
        private bool GetTxnProfileValues()
        {
            List<CbsTransactionLimit> newLimits = GetTxnLimits();

            if (newLimits != null)
            {
                _txnProfileSet.transactionLimits = newLimits;
                return true;
            }
            else return false;
        }

        public void RegisterProfileUpdateObserver(ITransactionProfileUpdateObserver observer)
        {
            _observers.Add(observer);
        }
        private void dgvTnxProfile_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

            if (e.ColumnIndex < 1) return;
            string formattedValue = e.FormattedValue.ToString();
            if (!ValidationManager.ValidatePositive(formattedValue))
            {
                e.Cancel = true;
                MessageBox.Show(StringTable.Numeric_value_is_expected, StringTable.InputErrors);
            }
        }

        #endregion

        #region KYC
        public void _loadKYC(Packet packet, long? kycId)
        {
            InitializeKYCProfile();

            _receivePacket = packet;
            _kycId = kycId;
            SetupKYCDataLoad();
            SetupKYCComponents();

            //if (packet.DeveloperMode)
            //{
            //    GUI.DeveloperMode.EnableDeveloperMode(this);
            //}

            //if (_viewMode == true)
            //{
            //    gbxAccInfo.Enabled = false;
            //    gbxCustomerInfo.Enabled = false;
            //}
        }
        public void _loadKYC(Packet packet, long? kycId, string customerId, string customerTitle)
        {
            InitializeKYCProfile();

            _receivePacket = packet;
            _kycId = kycId;
            _customerId = customerId;
            _customerTitle = customerTitle;

            SetupKYCDataLoad();
            SetupKYCComponents();

            //if (packet.DeveloperMode) GUI.DeveloperMode.EnableDeveloperMode(this);
            //if (_viewMode == true)
            //{
            //    gbxAccInfo.Enabled = false;
            //    gbxCustomerInfo.Enabled = false;
            //}

            this._enableControlsKYC(!_viewMode);
            //this.isTxnProfileSet = true;
        }
        public void _enableControlsKYC(bool isEnabled)
        {
            cmbMonthlyCashTxnAmount.Enabled = cmbMonthlyCashTxnNo.Enabled = cmbMonthlyTnxAmount.Enabled = cmbMonthlyTxnNumber.Enabled = isEnabled;
            txtSourceOfFund.Enabled = isEnabled;

            cmbAccountOpeningMode.Enabled = cmbMonthlyTurnOver.Enabled = !(_viewMode);

            if (!_viewMode) txtSourceOfFund.Enabled = true;
        }
        public void _visibleControlsKYC(bool isvisible)
        {
            lblMonthlyTxnNumber.Visible = lblMonthlyTxnAmount.Visible =
                lblCashTxnNo.Visible = lblCashTxnAmount.Visible = isvisible;

            cmbMonthlyTxnNumber.Visible = cmbMonthlyTnxAmount.Visible =
                cmbMonthlyCashTxnNo.Visible = cmbMonthlyCashTxnAmount.Visible = isvisible;

            _isKYCTxnInputVisibile = isvisible;
        }
        public long? getKycID()
        {
            return _kycId;
        }

        private void InitializeKYCProfile()
        {
            _kycProfile.kycAccountOpeningMode = new KycAccountOpeningMode();
            _kycProfile.kycCustomerTurnover = new KycCustomerTurnover();
            _kycProfile.kycMonthTxnAmount = new KycMonthTxnAmount();
            _kycProfile.kycMonthTxnNumber = new KycMonthTxnNumber();
            _kycProfile.kycCashMonthlyTxnAmount = new KycCashMonthlyTxnAmount();
            _kycProfile.kycCashMonthlyTxnNumber = new KycCashMonthlyTxnNumber();
            _kycProfile.id = 0;
            _kycProfile.sourceOfFund = "N/A";
        }
        private void SetupKYCDataLoad()
        {
            InitializeKYCLists();
            InitializeKYCDataSources();
            InitializeKYCLookups();
            SetKYCProfileData();

            //ConfigureValidation();
        }
        public void SetupKYCComponents()
        {
            //_gui = new GUI(this);
            //gui.Config(ref txtOutletName);  

            if (_receivePacket.actionType == FormActionType.View)
            {
                _viewMode = true;
                _enableControlsKYC(!_viewMode);
                //_gui.SetControlState(GUI.CONTROLSTATES.CS_DISABLE, new Control[]
                //{
                //    gbxAccInfo,
                //    gbxCustomerInfo
                //});
                //_gui.SetControlState(GUI.CONTROLSTATES.CS_HIDDEN, new Control[]
                //{
                //    btnSave,
                //    btnClear
                //});
            }
        }

        private void InitializeKYCLookups()
        {
            UtilityServices.fillComboBox(cmbAccountOpeningMode, _openingModeBindingSource, "OpeningModeDescription", "Id");
            UtilityServices.fillComboBox(cmbMonthlyTurnOver, _turnoverBindingSource, "TurnOverDescription", "Id");
            UtilityServices.fillComboBox(cmbMonthlyTnxAmount, _amountBindingSource, "TransactionAmountDescription", "Id");
            UtilityServices.fillComboBox(cmbMonthlyTxnNumber, _numberBindingSource, "TransactionNumberDescription", "Id");
            UtilityServices.fillComboBox(cmbMonthlyCashTxnAmount, _cashAmountBindingSource, "TransactionAmountDescription", "Id");
            UtilityServices.fillComboBox(cmbMonthlyCashTxnNo, _cashNumberBindingSource, "TransactionNumberDescription", "Id");
        }
        private void InitializeKYCDataSources()
        {
            _openingModeBindingSource.DataSource = _KYCopeningModes;
            _turnoverBindingSource.DataSource = _KYCcustomerTurnovers;
            _amountBindingSource.DataSource = _KYCtxnAmounts;
            _numberBindingSource.DataSource = _KYCtxnNumbers;
            _cashAmountBindingSource.DataSource = _KYCtxnCashMonthlyTxnAmounts;
            _cashNumberBindingSource.DataSource = _KYCtxnCashMonthlyTxnNumbers;
        }
        private void InitializeKYCLists()
        {
            List<MediatorKycMonthTxnAmount> _KYCtxnAmounts_All = new List<MediatorKycMonthTxnAmount>();
            List<MediatorKycMonthTxnNumber> _KYCtxnNumbers_All = new List<MediatorKycMonthTxnNumber>();
            List<MediatorKycCashMonthlyTxnAmount> _KYCtxnCashMonthlyTxnAmounts_All = new List<MediatorKycCashMonthlyTxnAmount>();
            List<MediatorKycCashMonthlyTxnNumber> _KYCtxnCashMonthlyTxnNumbers_All = new List<MediatorKycCashMonthlyTxnNumber>();

            _KYCopeningModes = KycService.GetAccountOpeningModes();
            _KYCcustomerTurnovers = KycService.getCustomerTurnovers();

            _KYCtxnAmounts_All = KycService.getTransactionAmount();
            if (_accCategory == DepositAccountCategory.MSD) _KYCtxnAmounts = _KYCtxnAmounts_All.Where(x => x.txnType.Trim() == "SA").ToList();
            else _KYCtxnAmounts = _KYCtxnAmounts_All.Where(x => x.txnType.Trim() == "CA").ToList();

            _KYCtxnNumbers_All = KycService.getTransactionNumbers();
            if (_accCategory == DepositAccountCategory.MSD) _KYCtxnNumbers = _KYCtxnNumbers_All.Where(x => x.txnType.Trim() == "SA").ToList();
            else _KYCtxnNumbers = _KYCtxnNumbers_All.Where(x => x.txnType.Trim() == "CA").ToList();

            _KYCtxnCashMonthlyTxnAmounts_All = KycService.getCashTransactionAmount();
            if (_accCategory == DepositAccountCategory.MSD) _KYCtxnCashMonthlyTxnAmounts = _KYCtxnCashMonthlyTxnAmounts_All.Where(x => x.txnType.Trim() == "SA").ToList();
            else _KYCtxnCashMonthlyTxnAmounts = _KYCtxnCashMonthlyTxnAmounts_All.Where(x => x.txnType.Trim() == "CA").ToList();

            _KYCtxnCashMonthlyTxnNumbers_All = KycService.getCashTransactionNumbers();
            if (_accCategory == DepositAccountCategory.MSD) _KYCtxnCashMonthlyTxnNumbers = _KYCtxnCashMonthlyTxnNumbers_All.Where(x => x.txnType.Trim() == "SA").ToList();
            else _KYCtxnCashMonthlyTxnNumbers = _KYCtxnCashMonthlyTxnNumbers_All.Where(x => x.txnType.Trim() == "CA").ToList();
        }

        public void SetKYCProfileData(long? _kycProfileNo)
        {
            if (_kycProfileNo == 0 || _kycProfileNo == null)
            {
                _kycId = 0;
            }
            else
            {
                _kycId = _kycProfileNo;
                _kycProfile = KycService.GetKycProfile(_kycId ?? 0);
                txtSourceOfFund.Text = _kycProfile.sourceOfFund;
                cmbAccountOpeningMode.SelectedValue = _kycProfile.kycAccountOpeningMode.id;
                cmbMonthlyTurnOver.SelectedValue = _kycProfile.kycCustomerTurnover.id;

                if (_isKYCTxnInputVisibile)
                {
                    cmbMonthlyCashTxnAmount.SelectedValue = _kycProfile.kycCashMonthlyTxnAmount.id;
                    cmbMonthlyCashTxnNo.SelectedValue = _kycProfile.kycCashMonthlyTxnNumber.id;
                    cmbMonthlyTnxAmount.SelectedValue = _kycProfile.kycMonthTxnAmount.id;
                    cmbMonthlyTxnNumber.SelectedValue = _kycProfile.kycMonthTxnNumber.id;
                }
            }

            txtCustomerID.Text = _customerId != "0" ? _customerId : "(not available)";
            txtCustomerName.Text = _customerTitle;
        }
        public void SetKYCProfileData()
        {
            if (_kycId == 0 || _kycId == null)
            {
                //return;
            }
            else
            {
                _kycProfile = KycService.GetKycProfile(_kycId ?? 0);
                txtSourceOfFund.Text = _kycProfile.sourceOfFund;
                cmbAccountOpeningMode.SelectedValue = _kycProfile.kycAccountOpeningMode.id;
                cmbMonthlyTurnOver.SelectedValue = _kycProfile.kycCustomerTurnover.id;

                if (_isKYCTxnInputVisibile)
                {
                    cmbMonthlyCashTxnAmount.SelectedValue = _kycProfile.kycCashMonthlyTxnAmount.id;
                    cmbMonthlyCashTxnNo.SelectedValue = _kycProfile.kycCashMonthlyTxnNumber.id;
                    cmbMonthlyTnxAmount.SelectedValue = _kycProfile.kycMonthTxnAmount.id;
                    cmbMonthlyTxnNumber.SelectedValue = _kycProfile.kycMonthTxnNumber.id;
                }
            }

            txtCustomerID.Text = _customerId != "0" ? _customerId : "(not available)";
            txtCustomerName.Text = _customerTitle;
        }
        #endregion

        private bool ValidationCheck()
        {
            return ValidationManager.ValidateForm(this);
        }
        private void SetKYCbyTxnProfile()
        {
            this._enableControlsKYC(true);
            int? monthlyTxnNumber = 0;
            decimal monthlyTxnAmount = 0;
            int? monthlyCashTxnNumber = 0;
            decimal monthlyCashTxnAmount = 0;
            List<CbsTransactionLimit> _cashTransactions = _txnProfileSet.transactionLimits.Where(x => x.txnProfile.tpMode == TpMode.CASH).ToList();

            MediatorKycMonthTxnNumber _KYCtxnNumbers_Select = new MediatorKycMonthTxnNumber();
            MediatorKycMonthTxnAmount _KYCtxnAmounts_Select = new MediatorKycMonthTxnAmount();
            MediatorKycCashMonthlyTxnNumber _KYCtxnCashMonthlyTxnNumbers_Select = new MediatorKycCashMonthlyTxnNumber();
            MediatorKycCashMonthlyTxnAmount _KYCtxnCashMonthlyTxnAmounts_Select = new MediatorKycCashMonthlyTxnAmount();

            monthlyTxnNumber = _txnProfileSet.transactionLimits.Sum(x => x.monthlyTxnCreditNo + x.monthlyTxnDebitNo);
            //monthlyTxnAmount = _txnProfileSet.transactionLimits.Sum(x => x.totalCreditAmount + x.totalDebitAmount);
            monthlyTxnAmount = _txnProfileSet.transactionLimits.Sum(x => x.monthlyTxnCreditLimit + x.monthlyTxnDebitLimit);
            monthlyCashTxnNumber = _cashTransactions.Sum(x => x.monthlyTxnCreditNo + x.monthlyTxnDebitNo);
            //monthlyCashTxnAmount = _cashTransactions.Sum(x => x.totalCreditAmount + x.totalDebitAmount);
            monthlyCashTxnAmount = _cashTransactions.Sum(x => x.monthlyTxnCreditLimit + x.monthlyTxnDebitLimit);

            _KYCtxnNumbers_Select = _KYCtxnNumbers.Where(x => (x.minNumber <= monthlyTxnNumber) && (x.maxNumber >= monthlyTxnNumber)).SingleOrDefault();
            _KYCtxnAmounts_Select = _KYCtxnAmounts.Where(x => (x.minAmount <= monthlyTxnAmount) && (x.maxAmount >= monthlyTxnAmount)).SingleOrDefault();
            _KYCtxnCashMonthlyTxnNumbers_Select = _KYCtxnCashMonthlyTxnNumbers.Where(x => (x.minNumber <= monthlyCashTxnNumber) && (x.maxNumber >= monthlyCashTxnNumber)).SingleOrDefault();
            _KYCtxnCashMonthlyTxnAmounts_Select = _KYCtxnCashMonthlyTxnAmounts.Where(x => (x.minAmount <= monthlyCashTxnAmount) && (x.maxAmount >= monthlyCashTxnAmount)).SingleOrDefault();

            cmbMonthlyTxnNumber.SelectedValue = _KYCtxnNumbers_Select.id;
            cmbMonthlyTnxAmount.SelectedValue = _KYCtxnAmounts_Select.id;
            cmbMonthlyCashTxnNo.SelectedValue = _KYCtxnCashMonthlyTxnNumbers_Select.id;
            cmbMonthlyCashTxnAmount.SelectedValue = _KYCtxnCashMonthlyTxnAmounts_Select.id;

            if(_productType == ProductType.Deposit)this._enableControlsKYC(false);
        }
        private void tpAndKYC_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (_viewMode == false)
                {
                    #region Set TxnProfile on tab change
                    bool isValidTP = GetTxnProfileValues();
                    if (isValidTP)
                    {
                        SetKYCbyTxnProfile();

                        List<long> limitCount = new List<long>();
                        string duplicateLimit = "";

                        foreach (CbsTransactionLimit limit in _txnProfileSet.transactionLimits)
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
                            { limitCount.Add(limit.txnProfile.id); }
                        }

                        if (duplicateLimit.Length > 0)
                        {
                            MessageBox.Show("Duplicate Limit exists for the following limits: " + "\n" + duplicateLimit);
                            btnSave.Enabled = true;
                            return;
                        }
                    }
                    else return;
                    //isTxnProfileSet = true;
                    //Message.showInformation("Transaction Profile is set successfully.");
                    #endregion
                }
            }
            catch (Exception ex)
            { Message.showError(ex.Message); }
        }
        private void SetSelectedKYC()
        {
            try
            {
                if (txtSourceOfFund.Text.Trim() == "")
                {
                    Message.showWarning("Source of fund required !");
                    return;
                }

                _kycProfile.sourceOfFund = txtSourceOfFund.Text.Trim();
                _kycProfile.kycAccountOpeningMode.id = Convert.ToInt32(cmbAccountOpeningMode.SelectedValue);
                _kycProfile.kycCustomerTurnover.id = Convert.ToInt32(cmbMonthlyTurnOver.SelectedValue);

                if (_isKYCTxnInputVisibile)
                {
                    _kycProfile.kycMonthTxnAmount.id = Convert.ToInt32(cmbMonthlyTnxAmount.SelectedValue);
                    _kycProfile.kycMonthTxnNumber.id = Convert.ToInt32(cmbMonthlyTxnNumber.SelectedValue);
                    _kycProfile.kycCashMonthlyTxnAmount.id = Convert.ToInt32(cmbMonthlyCashTxnAmount.SelectedValue);
                    _kycProfile.kycCashMonthlyTxnNumber.id = Convert.ToInt32(cmbMonthlyCashTxnNo.SelectedValue);
                }
                else
                {
                    _kycProfile.kycMonthTxnAmount = null;
                    _kycProfile.kycMonthTxnNumber = null;
                    _kycProfile.kycCashMonthlyTxnAmount = null;
                    _kycProfile.kycCashMonthlyTxnNumber = null;
                }
                //isKYCSet = true;
                //Message.showInformation("KYC is set successfully.");
            }
            catch (Exception exp)
            { Message.showError(exp.Message); }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            SetNewTransactionProfile();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //string errMessage = "";
                //if (!isTxnProfileSet) errMessage += "Transaction Profile is not set.\n";
                //if (!isKYCSet) errMessage += "KYC is not set.";
                //if (!isTxnProfileSet || !isKYCSet)
                //{ Message.showError(errMessage); return; }

                string returnMsg;
                string successMessage;
                ProgressUIManager.ShowProgress(this);
                
                #region Transaction Profile
                tpAndKYC_SelectedIndexChanged(null, null);
                returnMsg = ProfileService.SaveProfileData(_txnProfileSet);
                _txnProfileSet.id = Convert.ToInt32(returnMsg);

                foreach (ITransactionProfileUpdateObserver observer in _observers)
                {
                    if (observer != null) observer.ProfileSetUpdated(_txnProfileSet);
                }
                #endregion

                #region KYC
                SetSelectedKYC();
                returnMsg = KycService.SaveProfileData(_kycProfile);
                _kycId = Convert.ToInt32(returnMsg);

                foreach (IKycProfileUpdateObserver observer in _observers)
                {
                    if (observer != null) observer.ProfileUpdated(_kycProfile);
                }
                #endregion

                ProgressUIManager.CloseProgress();
                this.DialogResult = DialogResult.OK;
                if (this.tpAndKYC.TabCount == 2) successMessage = "Transaction Profile and KYC was saved successfully.";
                else successMessage = "KYC was saved successfully.";
                Message.showInformation(successMessage);
                this.Close();
            }
            catch (Exception exp)
            {
                ProgressUIManager.CloseProgress(); Message.showError(exp.Message);
            }
        }

    }

    class TPValidationCheck
    {
        public bool validTP;
        public string validationMessage;
    }
}
