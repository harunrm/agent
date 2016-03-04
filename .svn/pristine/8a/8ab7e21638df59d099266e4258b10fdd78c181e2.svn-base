using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MISL.Ababil.Agent.Infrastructure.Behavior;
using MISL.Ababil.Agent.Infrastructure.Mediators;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account.kyc;
using MISL.Ababil.Agent.Services;
using System.Linq;
using MISL.Ababil.Agent.Infrastructure.Validation;
using MISL.Ababil.Agent.UI.forms.ProgressUI;

namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmKYC : Form
    {
        private GUI _gui = new GUI();

        private Packet _receivePacket;
        public bool _viewMode = false;

        KycProfile _profile = new KycProfile();
        long? _kycId;
        string _customerId = "";
        string _customerTitle = "";

        private List<MediatorKycCustomerTurnover> _customerTurnovers = new List<MediatorKycCustomerTurnover>();
        private List<MediatorKycAccountOpeningMode> _openingModes = new List<MediatorKycAccountOpeningMode>();
        private List<MediatorKycCashMonthlyTxnAmount> _txnCashMonthlyTxnAmounts = new List<MediatorKycCashMonthlyTxnAmount>();
        private List<MediatorKycCashMonthlyTxnNumber> _txnCashMonthlyTxnNumbers = new List<MediatorKycCashMonthlyTxnNumber>();
        private List<MediatorKycMonthTxnAmount> _txnAmounts = new List<MediatorKycMonthTxnAmount>();
        private List<MediatorKycMonthTxnNumber> _txnNumbers = new List<MediatorKycMonthTxnNumber>();

        private readonly BindingSource _turnoverBindingSource = new BindingSource();
        private readonly BindingSource _openingModeBindingSource = new BindingSource();
        private readonly BindingSource _amountBindingSource = new BindingSource();
        private readonly BindingSource _numberBindingSource = new BindingSource();
        private readonly BindingSource _cashAmountBindingSource = new BindingSource();
        private readonly BindingSource _cashNumberBindingSource = new BindingSource();

        private readonly List<IKycProfileUpdateObserver> _observers = new List<IKycProfileUpdateObserver>();

        public frmKYC(Packet packet, long? kycId)
        {
            InitializeComponent();

            InitializeProfile();

            _receivePacket = packet;
            _kycId = kycId;
            preparedUI();
            if (packet.DeveloperMode)
            {
                GUI.DeveloperMode.EnableDeveloperMode(this);
            }

            if (_viewMode == true)
            {
                gbxAccInfo.Enabled = false;
                gbxCustomerInfo.Enabled = false;
            }
        }

        public frmKYC(Packet packet, long? kycId, string customerId, string customerTitle)
        {
            InitializeComponent();

            InitializeProfile();

            _receivePacket = packet;
            _kycId = kycId;
            _customerId = customerId;
            _customerTitle = customerTitle;

            preparedUI();

            if (packet.DeveloperMode)
            {
                GUI.DeveloperMode.EnableDeveloperMode(this);
            }

            if (_viewMode == true)
            {
                gbxAccInfo.Enabled = false;
                gbxCustomerInfo.Enabled = false;
            }
        }

        private void preparedUI()
        {
            SetupDataLoad();
            SetupComponents();

        }

        private void SetupDataLoad()
        {
            InitializeLists();

            InitializeDataSources();

            InitializeLookups();

            SetProfileData();

            setControlEnabling();

            ConfigureValidation();
        }

        public void SetupComponents()
        {
            _gui = new GUI(this);
            //gui.Config(ref txtOutletName);  

            if (_receivePacket.actionType == FormActionType.View)
            {
                _gui.SetControlState(GUI.CONTROLSTATES.CS_DISABLE, new Control[]
                {
                    gbxAccInfo,
                    gbxCustomerInfo
                });
                _gui.SetControlState(GUI.CONTROLSTATES.CS_HIDDEN, new Control[]
                {
                    btnSave,
                    btnClear
                });
            }
        }

        private void FillComponentWithObjectValue()
        {

        }

        private void FillObjectWithComponentValue()
        {

        }

        public void SetProfileData(long? _kycProfileNo)
        {
            if (_kycId == 0 || _kycId == null)
            {
                //return;
            }
            else
            {
                _profile = KycService.GetKycProfile(_kycId ?? 0);
                cmbAccountOpeningMode.SelectedValue = _profile.kycAccountOpeningMode.id;
                cmbMonthlyCashTxnAmount.SelectedValue = _profile.kycCashMonthlyTxnAmount.id;
                cmbMonthlyCashTxnNo.SelectedValue = _profile.kycCashMonthlyTxnNumber.id;
                cmbMonthlyTnxAmount.SelectedValue = _profile.kycMonthTxnAmount.id;
                cmbMonthlyTurnOver.SelectedValue = _profile.kycCustomerTurnover.id;
                cmbMonthlyTxnNumber.SelectedValue = _profile.kycMonthTxnNumber.id;
                txtSourceOfFund.Text = _profile.sourceOfFund;
            }
            txtCustomerId.Text = _customerId != "0" ? _customerId : "(not available)";
            lblCustomerName.Text = _customerTitle;
        }

        public void SetProfileData()
        {
            if (_kycId == 0 || _kycId == null)
            {
                //return;
            }
            else
            {
                _profile = KycService.GetKycProfile(_kycId ?? 0);
                cmbAccountOpeningMode.SelectedValue = _profile.kycAccountOpeningMode.id;
                cmbMonthlyCashTxnAmount.SelectedValue = _profile.kycCashMonthlyTxnAmount.id;
                cmbMonthlyCashTxnNo.SelectedValue = _profile.kycCashMonthlyTxnNumber.id;
                cmbMonthlyTnxAmount.SelectedValue = _profile.kycMonthTxnAmount.id;
                cmbMonthlyTurnOver.SelectedValue = _profile.kycCustomerTurnover.id;
                cmbMonthlyTxnNumber.SelectedValue = _profile.kycMonthTxnNumber.id;
                txtSourceOfFund.Text = _profile.sourceOfFund;
            }
            txtCustomerId.Text = _customerId != "0" ? _customerId : "(not available)";
            lblCustomerName.Text = _customerTitle;
        }


        private bool validationCheck()
        {
            return ValidationManager.ValidateForm(this);
        }

        public long? getFilledObject()
        {
            return _kycId;
        }

        private void ConfigureValidation()
        {
            ValidationManager.ConfigureValidation(this, txtCustomerId, "Customer ID", (long)ValidationType.NonWhitespaceNonEmptyText, true);
            ValidationManager.ConfigureValidation(this, txtSourceOfFund, "Source Of Fund", (long)ValidationType.NonWhitespaceNonEmptyText, true);
            ValidationManager.ConfigureValidation(this, cmbAccountOpeningMode, "Account Opening Mode", (long)ValidationType.ListSelected, true);
            ValidationManager.ConfigureValidation(this, cmbMonthlyTxnNumber, "Monthly TXN Number", (long)ValidationType.ListSelected, true);
            ValidationManager.ConfigureValidation(this, cmbMonthlyCashTxnAmount, "Monthly Cash Txn Amount", (long)ValidationType.ListSelected, true);

            ValidationManager.ConfigureValidation(this, cmbMonthlyTurnOver, "Monthly Turnover", (long)ValidationType.ListSelected, true);
            ValidationManager.ConfigureValidation(this, cmbMonthlyTnxAmount, "Monthly TNX Amount", (long)ValidationType.ListSelected, true);
            ValidationManager.ConfigureValidation(this, cmbMonthlyCashTxnNo, "Monthly Cash Txn No", (long)ValidationType.ListSelected, true);
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

        public void RegisterProfileUpdateObserver(IKycProfileUpdateObserver observer)
        {
            _observers.Add(observer);
        }

        public void SetProfileData(long profileId, string customerId, string customerName, string accountNumber)
        {
            SetProfileData(profileId);

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

        private void SetProfileData(long profileId)
        {
            if (profileId == 0) return;

            _profile = KycService.GetKycProfile(profileId);

            SetProfileValues();
        }

        private void SetProfileValues()
        {
            cmbAccountOpeningMode.SelectedValue = _profile.kycAccountOpeningMode.id;
            cmbMonthlyCashTxnAmount.SelectedValue = _profile.kycCashMonthlyTxnAmount.id;
            cmbMonthlyCashTxnNo.SelectedValue = _profile.kycCashMonthlyTxnNumber.id;
            cmbMonthlyTnxAmount.SelectedValue = _profile.kycMonthTxnAmount.id;
            cmbMonthlyTurnOver.SelectedValue = _profile.kycCustomerTurnover.id;
            cmbMonthlyTxnNumber.SelectedValue = _profile.kycMonthTxnNumber.id;
            txtSourceOfFund.Text = _profile.sourceOfFund;
        }

        private void InitializeProfile()
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

        private void InitializeLookups()
        {
            UtilityServices.fillComboBox(cmbAccountOpeningMode, _openingModeBindingSource, "OpeningModeDescription", "Id");
            UtilityServices.fillComboBox(cmbMonthlyTurnOver, _turnoverBindingSource, "TurnOverDescription", "Id");
            UtilityServices.fillComboBox(cmbMonthlyTnxAmount, _amountBindingSource, "TransactionAmountDescription", "Id");
            UtilityServices.fillComboBox(cmbMonthlyTxnNumber, _numberBindingSource, "TransactionNumberDescription", "Id");
            UtilityServices.fillComboBox(cmbMonthlyCashTxnAmount, _cashAmountBindingSource, "TransactionAmountDescription", "Id");
            UtilityServices.fillComboBox(cmbMonthlyCashTxnNo, _cashNumberBindingSource, "TransactionNumberDescription", "Id");
        }

        private void InitializeDataSources()
        {
            _openingModeBindingSource.DataSource = _openingModes;
            _turnoverBindingSource.DataSource = _customerTurnovers;
            _amountBindingSource.DataSource = _txnAmounts;
            _numberBindingSource.DataSource = _txnNumbers;
            _cashAmountBindingSource.DataSource = _txnCashMonthlyTxnAmounts;
            _cashNumberBindingSource.DataSource = _txnCashMonthlyTxnNumbers;
        }

        private void InitializeLists()
        {
            _openingModes = KycService.GetAccountOpeningModes();
            _customerTurnovers = KycService.getCustomerTurnovers();
            _txnAmounts = KycService.getTransactionAmount();
            _txnNumbers = KycService.getTransactionNumbers();
            _txnCashMonthlyTxnAmounts = KycService.getCashTransactionAmount();
            _txnCashMonthlyTxnNumbers = KycService.getCashTransactionNumbers();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }



        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAllInputData();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;

            if (validationCheck())
            {
                string result = Message.showConfirmation("Do you want to save?");
                if (result == "yes")
                {
                    KycProfile kycProfile = FillKycProfileData();

                    string retrnMsg;
                    try
                    {
                        ProgressUIManager.ShowProgress(this);
                        retrnMsg = KycService.SaveProfileData(kycProfile);
                        _kycId = Convert.ToInt32(retrnMsg);

                        // foreach (IKycProfileUpdateObserver observer in _observers)
                        // {
                        //    if (observer != null) observer.ProfileUpdated(_profile);
                        // }
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
            }
            btnSave.Enabled = true;
        }

        private KycProfile FillKycProfileData()
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

        public long Id { get; set; }

        private void txtCustomerId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (Keys)e.KeyChar != Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            OnKeyPress(e);
        }
        private void ClearAllInputData()
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

        private void txtAccountNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (Keys)e.KeyChar != Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            OnKeyPress(e);
        }

        private void txtCustomerId_Leave(object sender, EventArgs e)
        {
            //Utility.HandleAccountNumberTextLeave(UtilityServices.GetAccountTitle(txtCustomerId.Text), txtCustomerId, lblCustomerName);

            //ShowCustomerKycData(txtCustomerId.Text);
        }

        private void ShowCustomerKycData(string text)
        {

        }

        private void frmKYC_FormClosed(object sender, FormClosedEventArgs e)
        {
            _observers.Clear();
            ClearProfileData();
        }

        private void ClearProfileData()
        {
            _profile.id = 0;
            _profile.kycAccountOpeningMode.id = 0;
            _profile.kycCashMonthlyTxnAmount.id = 0;
            _profile.kycCashMonthlyTxnNumber.id = 0;
            _profile.kycCustomerTurnover.id = 0;
            _profile.kycMonthTxnAmount.id = 0;
            _profile.kycMonthTxnNumber.id = 0;

            ClearCombos();
        }

        private void ClearCombos()
        {
            cmbAccountOpeningMode.SelectedIndex = 0;
            cmbMonthlyCashTxnAmount.SelectedIndex = 0;
            cmbMonthlyCashTxnNo.SelectedIndex = 0;
            cmbMonthlyTnxAmount.SelectedIndex = 0;
            cmbMonthlyTurnOver.SelectedIndex = 0;
            cmbMonthlyTxnNumber.SelectedIndex = 0;
        }

        private void frmKYC_FormClosing(object sender, FormClosingEventArgs e)
        {
            ValidationManager.ReleaseValidationData(this);
        }

        private void frmKYC_Load(object sender, EventArgs e)
        {
            if (_viewMode == true)
            {
                gbxAccInfo.Enabled = false;
                gbxCustomerInfo.Enabled = false;
            }
        }
    }
}
