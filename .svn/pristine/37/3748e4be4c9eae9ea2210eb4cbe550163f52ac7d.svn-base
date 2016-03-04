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
using MISL.Ababil.Agent.Infrastructure.Models.reports;
using MISL.Ababil.Agent.Infrastructure.Validation;
using MISL.Ababil.Agent.UI.forms.ProgressUI;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;

namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmCashWithdraw : Form
    {
        TransactionService _txnService = new TransactionService();
        ConsumerServices _consumerService = new ConsumerServices();
        ConsumerInformationDto _consumerInformationDto = new ConsumerInformationDto();
        string _captureFor;
        int _captureIndexNo;
        int _noOfCapturefinger = 0;
        string _capturefingerData;
        string _subagentFingerData;
        bool? _isManualChargeApplicable = null;
        decimal _chargeAmount;

        GUI _gui = new GUI();

        public frmCashWithdraw()
        {
            InitializeComponent();
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.Text = "Capture";
            buttonColumn.UseColumnTextForButtonValue = true;
            fingerPrintGrid.Columns.Add(buttonColumn);
            bio.Visible = false;
            lblRequiredFingerPrint.Text = "";
            lblConsumerTitle.Text = "";
            lblMobileNo.Text = "";
            lblBalanceValue.Text = "";
            ConfigUIEnhancement();
        }

        public void ConfigUIEnhancement()
        {
            _gui = new GUI(this);

            _gui.Config(ref txtConsumerAccount, ValidCheck.VALIDATIONTYPES.TEXTBOX_EMPTY, null);
            _gui.Config(ref txtAmount, ValidCheck.VALIDATIONTYPES.TEXTBOX_NUMBER, null);
            _gui.Config(ref txtrCharge, ValidCheck.VALIDATIONTYPES.TEXTBOX_NUMBER, null);
            _gui.Config(ref txtrTotal);
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

        private CashOutRequest FillCashOutRequestData()
        {
            CashOutRequest request = new CashOutRequest();
            request.customerAccount = txtConsumerAccount.Text;
            request.amount = decimal.Parse(txtAmount.Text, CultureInfo.InvariantCulture);
            request.chargeAmount = decimal.Parse(txtrCharge.Text, CultureInfo.InvariantCulture);
            request.transactionDate = UtilityServices.GetLongDate(SessionInfo.currentDate);
            return request;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtConsumerAccount_Leave(object sender, EventArgs e)
        {
            loadConsumerInformation();
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
                        MessageBox.Show("Please capture agent fingerprint.");
                        _captureFor = "consumer";
                        bio.CaptureFingerData();
                    }
                    else
                    {
                        if (_noOfCapturefinger == _consumerInformationDto.numberOfOperator)
                        {
                            if (txtConsumerAccount.Text != "" && txtAmount.Text != "")
                            {
                                CashOutRequest cashOutRequest = FillCashOutRequestData();
                                cashOutRequest.agentFingerData = _subagentFingerData;
                                List<AccountOperator> objAccOperatorList = new List<AccountOperator>();
                                for (int i = 0; i < _consumerInformationDto.accountOperators.Count; i++)
                                {
                                    if (_consumerInformationDto.accountOperators[i].fingerData != null)
                                        objAccOperatorList.Add(_consumerInformationDto.accountOperators[i]);
                                }
                                cashOutRequest.accountOperators = objAccOperatorList;

                                try
                                {
                                    if (TransactionUIService.isTxnSafe("CashWithdraw", cashOutRequest.customerAccount, "", cashOutRequest.amount))
                                    {
                                        ProgressUIManager.ShowProgress(this);
                                        string ServiceResponse = _txnService.CashOut(cashOutRequest);
                                        ProgressUIManager.CloseProgress();
                                        TransactionUIService.cacheCurrentTxn("CashWithdraw", cashOutRequest.customerAccount, "", cashOutRequest.amount);
                                        decimal amountTmp = _consumerInformationDto.balance ?? 0;
                                        decimal totalTmp = decimal.Parse(txtrTotal.Text.Replace(",", ""));
                                        decimal finalValue = amountTmp - totalTmp;
                                        Message.showInformation("Transaction successfully completed.\n\nCurrent Balance is: " + finalValue.ToString("N", new CultureInfo("BN-BD")));

                                        clearUI();
                                        frmShowReport objfrmShowReport = new frmShowReport();
                                        objfrmShowReport.WithDrawlReport(ServiceResponse);
                                    }
                                    else
                                    {
                                        clearUI();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    ProgressUIManager.CloseProgress();
                                    btnWithdraw.Enabled = true;
                                    Message.showError(ex.Message);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("At least number of " + _consumerInformationDto.numberOfOperator + " finger print required. You captured only " + _noOfCapturefinger);
                        }
                    }
                }

                else if (_captureFor == "consumer")
                {
                    _capturefingerData = bio.GetSafeLeftFingerData();
                    string previousFingerData = _consumerInformationDto.accountOperators[_captureIndexNo].fingerData;
                    _consumerInformationDto.accountOperators[_captureIndexNo].fingerData = _capturefingerData;
                    fingerPrintGrid.Rows[_captureIndexNo].Cells[1].Style.BackColor = Color.Green;
                    fingerPrintGrid.Rows[_captureIndexNo].Cells[2].Style.BackColor = Color.Green;
                    if (previousFingerData == null)
                    {
                        _noOfCapturefinger++;
                        if (_noOfCapturefinger == 1)
                        {
                            disableAllComponent();
                        }
                        lblRequiredFingerPrint.Text = "Caputured " + _noOfCapturefinger + " operator's finger prints out of " + _consumerInformationDto.numberOfOperator;
                    }
                }
            }
        }

        private void disableAllComponent()
        {
            txtConsumerAccount.Enabled = false;
            txtAmount.Enabled = false;
        }

        private void txtConsumerAccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            //MessageBox.Show("outside " + e.KeyChar.ToString());
            if (!char.IsNumber(e.KeyChar) && (Keys)e.KeyChar != Keys.Back && e.KeyChar != '.')
            {
                //MessageBox.Show("Inside "+e.KeyChar.ToString());
                e.Handled = true;
            }

            base.OnKeyPress(e);
        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtAmount.Text))
            {
                //try
                //{
                int queueId = ValidationManager.QueueValidateControl(txtConsumerAccount, "Consumer Account",
                        (long)ValidationType.NonWhitespaceNonEmptyText, 0, true);

                if (txtConsumerAccount.Text != "" && txtAmount.Text != "")
                {
                    if (ValidationManager.ValidateQueue(queueId))
                    {
                        ChargeCalculationRequest chargeRequest = new ChargeCalculationRequest();
                        chargeRequest.srcAccount = txtConsumerAccount.Text;
                        chargeRequest.dstAccount = "";
                        if (!string.IsNullOrEmpty(txtAmount.Text))
                        {
                            chargeRequest.transactionAmount = decimal.Parse(txtAmount.Text);
                        }
                        chargeRequest.agentServices = "CashWithdraw";
                        chargeRequest.entryUser = SessionInfo.username;
                        try
                        {
                            _chargeAmount = _txnService.getChargeAmount(chargeRequest);
                            txtrCharge.Text = _chargeAmount.ToString("N", new CultureInfo("BN-BD"));
                            txtrTotal.Text = (decimal.Parse(txtAmount.Text) + decimal.Parse(txtrCharge.Text)).ToString("N", new CultureInfo("BN-BD"));
                            // Message.showInformation("Charge Amount : " + chargeAmount);  
                        }
                        catch (Exception ex)
                        {
                            Message.showError(ex.Message);
                            txtrCharge.Text = "";
                            txtrTotal.Text = "";
                        }
                    }
                    else
                    {
                        Message.showWarning("Account number and Amount required to calculate charge");
                    }
                }
                double decValue;
                if (double.TryParse(txtAmount.Text, out decValue))
                {
                    txtAmount.Text = decValue.ToString("N", new CultureInfo("BN-BD"));
                }
                //}
                //catch (Exception ex)
                //{
                //    Message.showError(ex.Message);                
                //} 
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
                    AccountOperator accountOperator = _consumerInformationDto.accountOperators[e.RowIndex];
                    if (txtConsumerAccount.Text != "" && txtAmount.Text != "")
                    {
                        _gui.SetControlState
                        (
                            GUI.CONTROLSTATES.CS_READONLY,
                            new Control[]
                            {
                                txtConsumerAccount,
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
                        Message.showInformation("Account number or amount may be blank.");
                    }
                }
                catch
                {
                    Message.showWarning("No operator found for capture.");
                }
            }
        }

        private void loadConsumerInformation()
        {
            if (ValidationManager.ValidateNonEmptyTextWithoutSpace(txtConsumerAccount.Text))
            {
                try
                {
                    _consumerInformationDto = _consumerService.getConsumerInformationDtoByAcc(txtConsumerAccount.Text);
                    lblConsumerTitle.Text = _consumerInformationDto.consumerTitle;
                    lblMobileNo.Text = _consumerInformationDto.mobileNumber;
                    lblBalanceValue.Text = (_consumerInformationDto.balance ?? 0).ToString("N", new CultureInfo("BN-BD"));
                    txtrCharge.Text = "";
                    txtrTotal.Text = "";
                    lblRequiredFingerPrint.Text = "At least " + _consumerInformationDto.numberOfOperator + " operator's finger print required.";
                    if (_consumerInformationDto.photo != null)
                    {
                        byte[] bytes = Convert.FromBase64String(_consumerInformationDto.photo);
                        Image image;
                        image = UtilityServices.byteArrayToImage(bytes);
                        pic_conusmer.Image = image;
                    }

                    if (_consumerInformationDto.accountOperators != null)
                    {
                        fingerPrintGrid.DataSource = _consumerInformationDto.accountOperators.Select(o => new operatorfingerPrintGrid(o) { identity = o.identity, identityName = o.identityName }).ToList();
                    }
                }
                catch (Exception ex)
                {
                    Message.showError(ex.Message);

                    lblConsumerTitle.Text = "";
                    lblMobileNo.Text = "";
                    lblBalanceValue.Text = "";
                    pic_conusmer.Image = null;
                    fingerPrintGrid.DataSource = null;
                    lblRequiredFingerPrint.Text = null;
                }
            }
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

        private void showCashWithdrowRport()
        {
            crWithdraw objRpt = new crWithdraw();
            frmReportViewer frm = new frmReportViewer();
            frm.crvReportViewer.ReportSource = objRpt;
            frm.ShowDialog();
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            btnWithdraw.Enabled = false;

            if (validationCheck() && _gui.IsAllControlValidated() && calculateManualCharge())
            {
                string result = Message.showConfirmation("Are you sure to withdraw?");
                if (result == "yes")
                {
                    if (txtConsumerAccount.Text != "" && txtAmount.Text != "")
                    {
                        _gui.SetControlState
                        (
                            GUI.CONTROLSTATES.CS_READONLY,
                            new Control[]
                            {
                                txtConsumerAccount,
                                txtAmount,
                                txtrCharge,
                            }
                        );

                        _captureFor = "subagent";
                        bio.CaptureFingerData();
                    }
                    else
                    {
                        Message.showWarning("Account no or amount may be blank.");
                    }
                }
            }
            _gui.SetControlState
            (
                GUI.CONTROLSTATES.CS_READWRITE,
                new Control[]
                {
                    txtConsumerAccount,
                    txtAmount,
                }
            );
            if (_isManualChargeApplicable == true)
            {
                txtrCharge.ReadOnly = false;
            }
            btnWithdraw.Enabled = true;
        }

        private void clearUI()
        {
            txtConsumerAccount.Enabled = true;
            txtAmount.Enabled = true;
            txtConsumerAccount.Text = "";
            txtAmount.Text = "";
            pic_conusmer.Image = null;
            fingerPrintGrid.DataSource = null;
            lblConsumerTitle.Text = "";
            lblMobileNo.Text = "";
            lblRequiredFingerPrint.Text = "";
            _noOfCapturefinger = 0;
            txtrCharge.Text = "";
            txtrTotal.Text = "";
            lblInWords.Text = "";
            lblBalanceValue.Text = "";

            _gui.SetControlState
            (
                GUI.CONTROLSTATES.CS_READWRITE,
                new Control[]
                {
                            txtConsumerAccount,
                            txtAmount,
                }
            );
            if (_isManualChargeApplicable == true)
            {
                txtrCharge.ReadOnly = false;
            }
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            clearUI();
        }

        private bool validationCheck()
        {
            if (txtConsumerAccount.Text == "")
            {
                Message.showWarning("Account number can not be left blank");
                txtConsumerAccount.Focus();
                return false;
            }

            if (txtAmount.Text == "")
            {
                Message.showWarning("Amount can not be left blank");
                txtAmount.Focus();
                return false;
            }

            if (_noOfCapturefinger != _consumerInformationDto.numberOfOperator)
            {
                Message.showWarning("At least number of " + _consumerInformationDto.numberOfOperator + " finger print required. You captured only " + _noOfCapturefinger);
                return false;
            }

            if (_consumerInformationDto.accountOperators == null)
            {
                Message.showWarning("Your account (" + txtConsumerAccount.Text + ") may be not eligible for withdraw from agent banking");
                return false;
            }

            return true;
        }

        private void txtrTotal_TextChanged(object sender, EventArgs e)
        {
            AmountInWords amountInWords = new AmountInWords();
            lblInWords.Text = amountInWords.ToWords(txtrTotal.Text);
        }

        private void frmCashWithdraw_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner = null;
        }

        private void txtrCharge_TextChanged(object sender, EventArgs e)
        {

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

        private void txtrCharge_Leave(object sender, EventArgs e)
        {
            calculateManualCharge();
        }

        private void frmCashWithdraw_Load(object sender, EventArgs e)
        {
            getChargeApplicability();
        }
    }
}