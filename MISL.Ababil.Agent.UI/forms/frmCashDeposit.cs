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
using MISL.Ababil.Agent.Infrastructure.Validation;
using MISL.Ababil.Agent.Services;
using MISL.Ababil.Agent.Report.Reports;
using MISL.Ababil.Agent.Report;
using MISL.Ababil.Agent.UI.forms.ProgressUI;
using MetroFramework.Forms;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;

namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmCashDeposit : MetroForm
    {
        public GUI _gui = new GUI();
        TransactionService _service = new TransactionService();
        ConsumerServices _consumerService = new ConsumerServices();
        ConsumerInformationDto _consumerInformationDto = new ConsumerInformationDto();
        string _subagentFingerPrint;
        string _serviceResponse;
        bool? _isManualChargeApplicable = null;
        decimal _chargeAmount;

        public frmCashDeposit()
        {
            InitializeComponent();
            bio.Visible = false;
            lblConsumerTitle.Text = "";
            lblMobileNo.Text = "";
            lblBalanceValue.Text = "";

            this.FormBorderStyle = FormBorderStyle.None;
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

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            btnDeposit.Enabled = false;

            if (_gui.IsAllControlValidated() && calculateManualCharge())
            {
                string result = Message.showConfirmation("Are you sure to deposit?");

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
                        bio.CaptureFingerData();
                        //bio.CaptureVerifySingleShortFingerData();                        
                    }
                    else
                    {
                        Message.showWarning("Account no or amount may be blank.");
                        txtConsumerAccount.Focus();
                        _gui.IsAllControlValidated();
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
            btnDeposit.Enabled = true;
        }

        private CashInRequest FillCashInRequestData()
        {
            CashInRequest request = new CashInRequest();
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

        private void txtConsumerAccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (Keys)e.KeyChar != Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            base.OnKeyPress(e);
        }

        private void txtConsumerAccount_Leave(object sender, EventArgs e)
        {
            if (txtConsumerAccount.Text != "")
            {
                try
                {

                    _consumerInformationDto = _consumerService.getConsumerInformationDtoByAcc(txtConsumerAccount.Text.Trim());
                    lblConsumerTitle.Text = _consumerInformationDto.consumerTitle;
                    lblMobileNo.Text = _consumerInformationDto.mobileNumber;
                    lblBalanceValue.Text = (_consumerInformationDto.balance ?? 0).ToString("N", new CultureInfo("BN-BD"));
                    txtAmount.Text = "";
                    txtrCharge.Text = "";
                    txtrTotal.Text = "";

                    if (_consumerInformationDto.photo != null)
                    {
                        byte[] bytes = Convert.FromBase64String(_consumerInformationDto.photo);
                        Image image;
                        image = UtilityServices.byteArrayToImage(bytes);
                        pic_conusmer.Image = image;
                    }
                }
                catch (Exception ex)
                {
                    clearUi();
                    Message.showWarning(ex.Message);
                }
            }
        }

        private void clearUi()
        {
            lblConsumerTitle.Text = "";
            lblMobileNo.Text = "";
            pic_conusmer.Image = null;
            txtAmount.Text = "";
            txtConsumerAccount.Text = "";
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

        private void bio_OnCapture(object sender, EventArgs e)
        {
            AxBIOPLUGINACTXLib.AxBioPlugInActX x = (AxBIOPLUGINACTXLib.AxBioPlugInActX)sender;

            if (x.result == "0")
            {
                _subagentFingerPrint = bio.GetSafeLeftFingerData();
                if (_subagentFingerPrint != null)
                {
                    if (txtConsumerAccount.Text != "" && txtAmount.Text != "")
                    {
                        CashInRequest request = FillCashInRequestData();
                        request.agentFingerData = _subagentFingerPrint;
                        try
                        {
                            if (TransactionUIService.isTxnSafe("CashDeposit", request.customerAccount, "", request.amount))
                            {
                                ProgressUIManager.ShowProgress(this);
                                _serviceResponse = _service.CashIn(request);
                                ProgressUIManager.CloseProgress();
                                TransactionUIService.cacheCurrentTxn("CashDeposit", request.customerAccount, "", request.amount);

                                decimal finalValue = (_consumerInformationDto.balance ?? 0) + request.amount;
                                Message.showInformation("Cash Deposited successfully.\n\nCurrent Balance is: " + finalValue.ToString("N", new CultureInfo("BN-BD")));

                                clearUi();

                                try
                                {
                                    frmShowReport objfrmShowReport = new frmShowReport();
                                    objfrmShowReport.DepositeReport(_serviceResponse);
                                }
                                catch (Exception ex)
                                {
                                    Message.showError("Report generate problem: " + ex.Message);
                                }
                            }
                            else
                            {
                                clearUi();
                            }
                        }
                        catch (Exception ex)
                        {
                            ProgressUIManager.CloseProgress();
                            btnDeposit.Enabled = true;
                            Message.showError(ex.Message);
                        }
                    }
                    else
                    {
                        Message.showWarning("Account no or amount may be blank.");
                    }
                }
                else
                {
                    Message.showWarning("Subagent finger print needed.");
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

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            double decValue;
            if (double.TryParse(txtAmount.Text, out decValue))
            {
                txtAmount.Text = decValue.ToString("N", new CultureInfo("BN-BD"));
            }

            if (txtConsumerAccount.Text != "" && txtAmount.Text != "")
            {
                if (decimal.Parse(txtConsumerAccount.Text) > 0)
                {
                    ChargeCalculationRequest chargeRequest = new ChargeCalculationRequest();
                    chargeRequest.srcAccount = txtConsumerAccount.Text;
                    chargeRequest.dstAccount = "";
                    chargeRequest.transactionAmount = decimal.Parse(txtAmount.Text);
                    chargeRequest.agentServices = "CashDeposit";
                    chargeRequest.entryUser = SessionInfo.username;
                    try
                    {
                        _chargeAmount = _service.getChargeAmount(chargeRequest);
                        txtrCharge.Text = _chargeAmount.ToString("N", new CultureInfo("BN-BD"));//.ToString("#.00");
                        txtrTotal.Text = ((decimal.Parse(txtAmount.Text) + decimal.Parse(txtrCharge.Text))).ToString(
                            "N", new CultureInfo("BN-BD")); //.ToString("#.00");
                        AmountInWords amountInWords = new AmountInWords();
                        lblInWords.Text = amountInWords.ToWords(txtrTotal.Text);

                        //lblInWords.Text = String.Format("{0:##,##,##,###.##}", (decimal.Parse(txtAmount.Text) + decimal.Parse(txtrCharge.Text)));
                        //lblInWords.Text = (decimal.Parse(txtAmount.Text) + decimal.Parse(txtrCharge.Text)).ToString("N", new CultureInfo("BN-BD"));

                    }
                    catch (Exception ex)
                    {
                        Message.showError(ex.Message);
                    }
                }
                else
                {
                    Message.showWarning("Amount must be greater than zero");
                }
            }
            else
            {
                txtrCharge.Text = "";
                txtrTotal.Text = "";
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

        private void btshowAccHolderInfo_Click(object sender, EventArgs e)
        {
            _consumerInformationDto = _consumerService.getConsumerInformationDtoByAcc(txtConsumerAccount.Text);
            lblConsumerTitle.Text = _consumerInformationDto.consumerTitle;
            lblMobileNo.Text = _consumerInformationDto.mobileNumber;

            if (_consumerInformationDto.photo != null)
            {
                byte[] bytes = Convert.FromBase64String(_consumerInformationDto.photo);
                Image image;
                image = UtilityServices.byteArrayToImage(bytes);
                pic_conusmer.Image = image;
            }
        }

        private void btChargeCalculation_Click(object sender, EventArgs e)
        {
            if (txtConsumerAccount.Text != "" && txtAmount.Text != "")
            {
                ChargeCalculationRequest chargeRequest = new ChargeCalculationRequest();
                chargeRequest.srcAccount = txtConsumerAccount.Text;
                chargeRequest.dstAccount = "";
                chargeRequest.transactionAmount = decimal.Parse(txtAmount.Text);
                chargeRequest.agentServices = "CashDeposit";
                chargeRequest.entryUser = SessionInfo.username;
                try
                {
                    _chargeAmount = _service.getChargeAmount(chargeRequest);
                    Message.showInformation("Charge Amount : " + _chargeAmount);
                }
                catch (Exception ex)
                {
                    Message.showError(ex.Message);
                }
            }
            else
            {
                Message.showWarning("Account number and amount require to calculate charge.");
            }
        }

        private void frmCashDeposit_FormClosing(object sender, FormClosingEventArgs e)
        {
            //ValidationManager.ReleaseValidationData(this);
            this.Owner = null;
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            clearUi();
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

        private void btnDeposit_Leave(object sender, EventArgs e)
        {

        }

        private void frmCashDeposit_Load(object sender, EventArgs e)
        {
            getChargeApplicability();
        }

        private void txtrCharge_Leave(object sender, EventArgs e)
        {
            calculateManualCharge();
        }
    }
}