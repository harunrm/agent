using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.consumer;
using MISL.Ababil.Agent.Infrastructure.Models.models.transaction;
using MISL.Ababil.Agent.Services;
using MISL.Ababil.Agent.Report;
using MISL.Ababil.Agent.Report.Reports;
using MISL.Ababil.Agent.Infrastructure.Validation;
using MISL.Ababil.Agent.UI.forms.ProgressUI;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;

namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmFundTransfer : Form
    {
        GUI _gui = new GUI();

        TransactionService _txnService = new TransactionService();
        ConsumerServices _consumerService = new ConsumerServices();
        ConsumerInformationDto _srcConsumerInformationDto = new ConsumerInformationDto();
        ConsumerInformationDto _destConsumerInformationDto = new ConsumerInformationDto();

        string _captureFor;
        int _captureIndexNo;
        int _noOfCapturefinger = 0;
        string _capturefingerData;
        string _subagentFingerData;
        bool? _isManualChargeApplicable = null;
        decimal _chargeAmount;

        public int CaptureIndexNo
        {
            get
            {
                return _captureIndexNo;
            }

            set
            {
                _captureIndexNo = value;
            }
        }

        public frmFundTransfer()
        {
            InitializeComponent();
            bio.Visible = false;
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.Text = "Capture";
            buttonColumn.UseColumnTextForButtonValue = true;
            fingerPrintGrid.Columns.Add(buttonColumn);
            bio.Visible = false;
            lblRequiredFingerPrint.Text = string.Empty;
            lblFromConsumerTitle.Text = string.Empty;
            lblFromMobileNo.Text = string.Empty;
            lblToConsumerTitle.Text = string.Empty;
            lblToMobileNo.Text = string.Empty;
            lblRequiredFingerPrint.Text = string.Empty;
            lblBalanceValue.Text = string.Empty;

            ConfigUIEnhancement();
        }

        public void ConfigUIEnhancement()
        {
            _gui = new GUI(this);

            _gui.Config(ref txtFromAccount, ValidCheck.VALIDATIONTYPES.TEXTBOX_EMPTY, null);
            _gui.Config(ref txtToAccount, ValidCheck.VALIDATIONTYPES.TEXTBOX_EMPTY, null);
            _gui.Config(ref txtAmount, ValidCheck.VALIDATIONTYPES.TEXTBOX_EMPTY, null);
            //_gui.Config(ref txtrCharge, ValidCheck.VALIDATIONTYPES.TEXTBOX_EMPTY, null);
            //_gui.Config(ref txtrTotal, ValidCheck.VALIDATIONTYPES.TEXTBOX_EMPTY, null);
        }

        private void getChargeApplicability()
        {
            ChargeApplicabilityService chargeApplicabilityService = new ChargeApplicabilityService();
            //
            _isManualChargeApplicable = chargeApplicabilityService.IsManualChargeApplicable(AgentServicesType.CashDeposit);
            //
            //
            //_isManualChargeApplicable = true; //keep for testing
            //
            switch (_isManualChargeApplicable)
            {
                //case null:
                //    Message.showError("Charge applicability checking failed!");
                //    this.Owner = null;
                //    this.Close();
                //    break;
                case false:
                    txtrCharge.ReadOnly = true;
                    txtrCharge.BackColor = txtrTotal.BackColor;
                    break;
                case true:
                    txtrCharge.ReadOnly = false;
                    txtrCharge.BackColor = Color.White;
                    break;
                default:
                    break;
            }
        }

        private void btnDotransfer_Click(object sender, EventArgs e)
        {
            btnDotransfer.Enabled = false;

            if (validationCheckPrevious() && _gui.IsAllControlValidated() && calculateManualCharge())
            {
                string result = Message.showConfirmation("Are you sure to transfer?");
                if (result == "yes")
                {
                    _gui.SetControlState
                    (
                        GUI.CONTROLSTATES.CS_READONLY,
                        new Control[]
                        {
                            txtFromAccount,
                            txtToAccount,
                            txtAmount,
                            txtrCharge,
                        }
                    );

                    _captureFor = "subagent";
                    bio.CaptureFingerData();
                }
            }

            _gui.SetControlState
            (
              GUI.CONTROLSTATES.CS_READWRITE,
              new Control[]
              {
                    txtFromAccount,
                    txtToAccount,
                    txtAmount,
              }
            );
            if (_isManualChargeApplicable == true)
            {
                txtrCharge.ReadOnly = false;
            }

            btnDotransfer.Enabled = true;
        }

        private FundTransferRequest FillFundTransferRequest()
        {
            FundTransferRequest fundTransferRequest = new FundTransferRequest();
            fundTransferRequest.fromAccount = txtFromAccount.Text;
            fundTransferRequest.toAccount = txtToAccount.Text;
            fundTransferRequest.amount = decimal.Parse(txtAmount.Text, CultureInfo.InvariantCulture);
            fundTransferRequest.chargeAmount = decimal.Parse(txtrCharge.Text, CultureInfo.InvariantCulture);
            fundTransferRequest.transactionDate = UtilityServices.GetLongDate(SessionInfo.currentDate);
            return fundTransferRequest;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAllInputData();
        }
        private void ClearAllInputData()
        {
            txtFromAccount.Text = string.Empty;
            txtAmount.Text = string.Empty;
            txtToAccount.Text = string.Empty;
            picFromConusmer.Image = null;
            picToConusmer.Image = null;
            lblFromConsumerTitle.Text = string.Empty;
            lblFromMobileNo.Text = string.Empty;
            lblToConsumerTitle.Text = string.Empty;
            lblToMobileNo.Text = string.Empty;
            lblRequiredFingerPrint.Text = string.Empty;
            fingerPrintGrid.DataSource = null;
            txtFromAccount.Enabled = true;
            txtAmount.Enabled = true;
            txtToAccount.Enabled = true;
            _noOfCapturefinger = 0;
            txtrCharge.Text = "";
            txtrTotal.Text = "";
            lblBalanceValue.Text = "";
        }

        private void disableAllComponent()
        {
            txtFromAccount.Enabled = false;
            txtAmount.Enabled = false;
            txtToAccount.Enabled = false;
        }

        private void txtFromAccount_Leave(object sender, EventArgs e)
        {
            if (loadSourceConsumerInformation())
            {
                txtToAccount.Focus();
            }
            txtrCharge.Text = "";
            txtrTotal.Text = "";
        }

        private void txtFromAccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (Keys)e.KeyChar != Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            base.OnKeyPress(e);
        }

        private void txtToAccount_Leave(object sender, EventArgs e)
        {
            if (loadDestConsumerInformation())
            {
                txtAmount.Focus();
            }
        }

        private void txtToAccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Utility.EnterPressed(e)) txtAmount.Focus();
            if (!char.IsNumber(e.KeyChar) && (Keys)e.KeyChar != Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            base.OnKeyPress(e);
        }

        private bool loadSourceConsumerInformation()
        {
            if (ValidationManager.ValidateNonEmptyTextWithoutSpace(txtFromAccount.Text))
            {
                try
                {
                    _srcConsumerInformationDto = _consumerService.getConsumerInformationDtoByAcc(txtFromAccount.Text);
                    lblFromConsumerTitle.Text = _srcConsumerInformationDto.consumerTitle;
                    lblFromMobileNo.Text = _srcConsumerInformationDto.mobileNumber;
                    lblBalanceValue.Text = (_srcConsumerInformationDto.balance ?? 0).ToString("N", new CultureInfo("BN-BD"));
                    lblRequiredFingerPrint.Text = "At least " + _srcConsumerInformationDto.numberOfOperator + " operator's finger print required.";
                    if (_srcConsumerInformationDto.photo != null)
                    {
                        byte[] bytes = Convert.FromBase64String(_srcConsumerInformationDto.photo);
                        Image image;
                        image = UtilityServices.byteArrayToImage(bytes);
                        picFromConusmer.Image = image;
                    }

                    if (_srcConsumerInformationDto.accountOperators != null)
                    {
                        fingerPrintGrid.DataSource = _srcConsumerInformationDto.accountOperators.Select(o => new operatorfingerPrintGrid(o) { identity = o.identity, identityName = o.identityName }).ToList();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    Message.showError(ex.Message);
                    lblFromConsumerTitle.Text = "";
                    lblFromMobileNo.Text = "";
                    picFromConusmer.Image = null;
                    return false;
                }
            }
            return false;
        }

        private bool loadDestConsumerInformation()
        {
            if (ValidationManager.ValidateNonEmptyTextWithoutSpace(txtToAccount.Text))
            {
                try
                {
                    _destConsumerInformationDto = _consumerService.getConsumerInformationDtoByAcc(txtToAccount.Text);
                    lblToConsumerTitle.Text = _destConsumerInformationDto.consumerTitle;
                    lblToMobileNo.Text = _destConsumerInformationDto.mobileNumber;
                    if (_destConsumerInformationDto.photo != null)
                    {
                        byte[] bytes = Convert.FromBase64String(_destConsumerInformationDto.photo);
                        Image image;
                        image = UtilityServices.byteArrayToImage(bytes);
                        picToConusmer.Image = image;
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    Message.showError(ex.Message);
                    lblToConsumerTitle.Text = "";
                    lblToMobileNo.Text = "";
                    picToConusmer.Image = null;
                    return false;
                }
            }
            return false;
        }

        public class operatorfingerPrintGrid
        {
            public string identity { get; set; }
            public string identityName { get; set; }

            private AccountOperator _obj;

            public operatorfingerPrintGrid(AccountOperator obj)
            {
                _obj = obj;
            }

            public AccountOperator GetModel()
            {
                return _obj;
            }
        }

        private void bio_OnCapture(object sender, EventArgs e)
        {
            AxBIOPLUGINACTXLib.AxBioPlugInActX x = (AxBIOPLUGINACTXLib.AxBioPlugInActX)sender;

            if (x.result == "0")
            {
                if (_captureFor == "subagent")
                {
                    _subagentFingerData = bio.GetSafeLeftFingerData();
                    if (_subagentFingerData == null)
                    {
                        Message.showInformation("Please capture agent fingerprint.");
                        _captureFor = "consumer";
                        bio.CaptureFingerData();
                    }
                    else
                    {
                        if (_noOfCapturefinger == _srcConsumerInformationDto.numberOfOperator)
                        {
                            FundTransferRequest fundTransferRequest = FillFundTransferRequest();
                            fundTransferRequest.agentFingerData = _subagentFingerData;
                            List<AccountOperator> objAccOperatorList = new List<AccountOperator>();
                            for (int i = 0; i < _srcConsumerInformationDto.accountOperators.Count; i++)
                            {
                                if (_srcConsumerInformationDto.accountOperators[i].fingerData != null)
                                    objAccOperatorList.Add(_srcConsumerInformationDto.accountOperators[i]);
                            }
                            fundTransferRequest.accountOperators = objAccOperatorList;

                            try
                            {
                                if (TransactionUIService.isTxnSafe("FundTransfer", fundTransferRequest.fromAccount, fundTransferRequest.toAccount, fundTransferRequest.amount))
                                {
                                    ProgressUIManager.ShowProgress(this);
                                    string ServiceResponse = _txnService.FundTransfer(fundTransferRequest);
                                    ProgressUIManager.CloseProgress();
                                    TransactionUIService.cacheCurrentTxn("FundTransfer", fundTransferRequest.fromAccount, fundTransferRequest.toAccount, fundTransferRequest.amount);
                                    Message.showInformation("Transaction successfully completed.\n\nCurrent balance of the source account is: " + ((_srcConsumerInformationDto.balance ?? 0) - decimal.Parse(txtrTotal.Text)).ToString("N", new CultureInfo("BN-BD")));

                                    ClearAllInputData();

                                    frmShowReport objfrmShowReport = new frmShowReport();
                                    objfrmShowReport.MoneyTransferReport(ServiceResponse);
                                }
                                else
                                    ClearAllInputData();
                            }
                            catch (Exception ex)
                            {
                                ProgressUIManager.CloseProgress();
                                btnDotransfer.Enabled = true;
                                Message.showError(ex.Message);
                            }
                        }
                        else
                        {
                            Message.showWarning("At least number of " + _srcConsumerInformationDto.numberOfOperator + " finger print required. You captured only " + _noOfCapturefinger);
                        }
                    }
                }
                else if (_captureFor == "consumer")
                {
                    _capturefingerData = bio.GetSafeLeftFingerData();
                    string previousFingerData = _srcConsumerInformationDto.accountOperators[_captureIndexNo].fingerData;
                    _srcConsumerInformationDto.accountOperators[_captureIndexNo].fingerData = _capturefingerData;
                    fingerPrintGrid.Rows[_captureIndexNo].Cells[1].Style.BackColor = Color.Green;
                    fingerPrintGrid.Rows[_captureIndexNo].Cells[2].Style.BackColor = Color.Green;
                    if (previousFingerData == null)
                    {
                        _noOfCapturefinger++;
                        if (_noOfCapturefinger == 1)
                        {
                            disableAllComponent();
                        }

                        lblRequiredFingerPrint.Text = "Caputured " + _noOfCapturefinger + " operator's finger prints out of " + _srcConsumerInformationDto.numberOfOperator;
                    }
                }
            }
        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFromAccount.Text))
            {
                Message.showError("Source Account Number not found!");
            }
            else if (string.IsNullOrEmpty(txtToAccount.Text))
            {
                Message.showError("Destination Account Number not found!");
            }
            else if (string.IsNullOrEmpty(txtAmount.Text))
            {
                Message.showError("Amount not valid!");
            }
            else
            {
                ChargeCalculationRequest chargeRequest = new ChargeCalculationRequest();
                chargeRequest.srcAccount = txtFromAccount.Text;
                chargeRequest.dstAccount = txtToAccount.Text;
                chargeRequest.transactionAmount = decimal.Parse(txtAmount.Text);
                chargeRequest.agentServices = "FundTransfer";
                chargeRequest.entryUser = SessionInfo.username;
                try
                {
                    AmountInWords amountInWords = new AmountInWords();
                    _chargeAmount = _txnService.getChargeAmount(chargeRequest);
                    txtrCharge.Text = _chargeAmount.ToString();
                    txtrTotal.Text = (decimal.Parse(txtAmount.Text) + decimal.Parse(txtrCharge.Text)).ToString();

                    double decValue2;
                    string str = "";
                    if (double.TryParse(txtrTotal.Text, out decValue2))
                    {
                        str = decValue2.ToString("##,##,###.00", System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
                    }
                    lblInWords.Text = amountInWords.ToWords(str.Replace(",", ""));
                }
                catch (Exception ex)
                {
                    Message.showError(ex.Message);
                    txtrCharge.Text = "";
                    txtrTotal.Text = "";
                }
            }
            //else
            //{
            //    Message.showWarning("Account number or amount may be invalid");
            //}            

            double decValue;
            if (double.TryParse(txtAmount.Text, out decValue))
            {
                txtAmount.Text = decValue.ToString("##,##,###.00", System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (Keys)e.KeyChar != Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            base.OnKeyPress(e);
        }

        private void fingerPrintGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {

                try
                {
                    AccountOperator accountOperator = _srcConsumerInformationDto.accountOperators[e.RowIndex];
                    if (txtFromAccount.Text != "" && txtAmount.Text != "" && txtToAccount.Text != "")
                    {

                        if (txtFromAccount.Text != txtToAccount.Text)
                        {
                            _gui.SetControlState
                            (
                                GUI.CONTROLSTATES.CS_READONLY,
                                new Control[]
                                {
                                    txtFromAccount,
                                    txtToAccount,
                                    txtAmount,
                                    txtrCharge,
                                }
                            );
                            var senderGrid = (DataGridView)sender;
                            _captureIndexNo = e.RowIndex;
                            bio.CaptureFingerData();
                            _captureFor = "consumer";
                        }
                        else
                        {
                            Message.showInformation("Source account and Destination account can not be same");
                        }
                    }
                    else
                    {
                        Message.showInformation("Account number or amount may be blank.");
                    }
                }
                catch
                {
                    Message.showWarning("No operator found for capture.");
                }
            }
        }

        private void showCashWithdrowRport()
        {
            crWithdraw objRpt = new crWithdraw();
            frmReportViewer frm = new frmReportViewer();
            frm.crvReportViewer.ReportSource = objRpt;
            frm.ShowDialog();
        }

        private Boolean validationCheckPrevious()
        {
            if (txtFromAccount.Text == "")
            {
                Message.showWarning("Source Account number can not be left blank");
                txtFromAccount.Focus();
                return false;
            }

            if (txtAmount.Text == "")
            {
                Message.showWarning("Amount can not be left blank");
                txtAmount.Focus();
                return false;
            }

            if (txtToAccount.Text == "")
            {
                Message.showWarning("Destination Account number can not be left blank");
                txtToAccount.Focus();
                return false;
            }

            if (txtFromAccount.Text == txtToAccount.Text)
            {
                Message.showWarning("Source Account & Destination Account can not be same");
                txtToAccount.Focus();
                return false;
            }


            if (_noOfCapturefinger != _srcConsumerInformationDto.numberOfOperator)
            {
                Message.showWarning("At least number of " + _srcConsumerInformationDto.numberOfOperator + " finger print required. You captured only " + _noOfCapturefinger);
                return false;
            }

            if (_srcConsumerInformationDto.accountOperators == null)
            {

                Message.showWarning("Your account (" + txtFromAccount.Text + ") may be not eligible for fund transfer from agent banking");
                return false;
            }

            return true;
        }

        private void frmFundTransfer_FormClosing(object sender, FormClosingEventArgs e)
        {
            ValidationManager.ReleaseValidationData(this);
            this.Owner = null;
        }

        private void txtrTotal_TextChanged(object sender, EventArgs e)
        {
            AmountInWords amountInWords = new AmountInWords();
            double decValue2;
            string str = "";
            if (double.TryParse(txtrTotal.Text, out decValue2))
            {
                str = decValue2.ToString("##,##,###.00", System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
            }
            lblInWords.Text = amountInWords.ToWords(str.Replace(",", ""));
        }

        private void frmFundTransfer_Load(object sender, EventArgs e)
        {
            getChargeApplicability();
        }

        private void txtrCharge_Leave(object sender, EventArgs e)
        {
            calculateManualCharge();
        }

        private bool calculateManualCharge()
        {
            if (_isManualChargeApplicable == true)
            {
                try
                {
                    decimal chargeAmountTmp = decimal.Parse(txtrCharge.Text);
                    if (0 <= chargeAmountTmp && chargeAmountTmp <= _chargeAmount)
                    {
                        txtrCharge.Text = chargeAmountTmp.ToString("N", new CultureInfo("BN-BD"));//.ToString("#.00");
                        txtrTotal.Text = ((decimal.Parse(txtAmount.Text) + decimal.Parse(txtrCharge.Text))).ToString(
                            "N", new CultureInfo("BN-BD")); //.ToString("#.00");
                        AmountInWords amountInWords = new AmountInWords();
                        lblInWords.Text = amountInWords.ToWords(txtrTotal.Text);
                    }
                    else
                    {
                        Message.showError("Manual charge cannot be greater than calculated charge (" + _chargeAmount + ")");
                        return false;
                    }
                    return true;
                }
                catch
                {
                    //suppressed
                    return false;
                }
            }
            return false;
        }
    }
}