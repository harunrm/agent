using MetroFramework.Forms;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.consumer;
using MISL.Ababil.Agent.Infrastructure.Models.models.transaction;
using MISL.Ababil.Agent.Report;
using MISL.Ababil.Agent.Services;
using MISL.Ababil.Agent.UI.forms.ProgressUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmBillPayment : MetroForm
    {
        private GUI _gui;
        private Packet _packet;
        private BillPaymentRequestDto _BillPaymentRequestDto;
        private AmountInWords _amountInWords = new AmountInWords();
        private ConsumerServices _consumerService = new ConsumerServices();
        private ConsumerInformationDto _srcConsumerInformationDto = new ConsumerInformationDto();
        private int _captureIndexNo;
        private string _captureFor;
        private string _subagentFingerData;
        private int _noOfCapturefinger;
        private string _capturefingerData;

        public frmBillPayment(Packet packet, BillPaymentRequestDto billPaymentRequestDto)
        {
            _packet = packet;
            _BillPaymentRequestDto = billPaymentRequestDto;

            InitializeComponent();
            InitialSetup();
        }

        private void InitialSetup()
        {
            SetupDataLoad();
            SetupComponents();
            FillComponentWithObjectValue();
        }

        private void SetupDataLoad()
        {
            //Bill Service Proviers
            {
                BillPaymentServices billPaymentServices = new BillPaymentServices();
                List<BillServiceProvider> exchangeHouses = billPaymentServices.GetListBillServiceProviders();
                BindingSource bsBillServiceProvider = new BindingSource();
                bsBillServiceProvider.DataSource = exchangeHouses;
                UtilityServices.fillComboBox(cmbServiceName, bsBillServiceProvider, "shortcode", "id");
                cmbServiceName.SelectedIndex = -1;
            }

            //DataGrid Capture Button
            {
                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.Text = "Capture";
                buttonColumn.UseColumnTextForButtonValue = true;
                fingerPrintGrid.Columns.Add(buttonColumn);
            }
        }

        private void SetupComponents()
        {
            _gui = new GUI(this);

            _gui.Config(ref cmbServiceName, Services.ValidCheck.VALIDATIONTYPES.COMBOBOX_EMPTY, null);
            //_gui.Config(ref txtReferenceNo, Services.ValidCheck.VALIDATIONTYPES.TEXTBOX_EMPTY, null);
            _gui.Config(ref txtCustomerName, Services.ValidCheck.VALIDATIONTYPES.TEXTBOX_EMPTY, null);
            _gui.Config(ref txtMobile, Services.ValidCheck.VALIDATIONTYPES.TEXTBOX_NUMBER_MOBILE, null);
            _gui.Config(ref txtBillNo, Services.ValidCheck.VALIDATIONTYPES.TEXTBOX_EMPTY, null);
            _gui.Config(ref txtAmount, Services.ValidCheck.VALIDATIONTYPES.TEXTBOX_NUMBER, null);

            _gui.Config(new Control[]
            {
                rBtnCash,
                rBtnAccount
            });

            _gui.Config(new Control[]
            {
                fingerPrintGrid
            });

        }

        private void FillComponentWithObjectValue()
        {

        }

        private void FillObjectWithComponentValue()
        {
            _BillPaymentRequestDto = new BillPaymentRequestDto();
            _BillPaymentRequestDto.serviceProviderId = (long)cmbServiceName.SelectedValue;
            //_BillPaymentRequestDto.referenceNo = txtReferenceNo.Text;
            _BillPaymentRequestDto.customerName = txtCustomerName.Text;
            _BillPaymentRequestDto.mobileNo = txtMobile.Text;
            _BillPaymentRequestDto.billNo = txtBillNo.Text;
            _BillPaymentRequestDto.billAmount = decimal.Parse(txtAmount.Text);
            _BillPaymentRequestDto.chargeAmount = decimal.Parse(txtCharge.Text);

            if (rBtnAccount.Checked)
            {
                _BillPaymentRequestDto.paymentType = PaymentType.Account;
                _BillPaymentRequestDto.accountNo = txtConsumerAccount.Text;
            }
            else
            {
                _BillPaymentRequestDto.paymentType = PaymentType.Cash;
            }
        }

        private bool LoadSourceConsumerInformation()
        {
            if (!string.IsNullOrEmpty(txtConsumerAccount.Text))
            {
                try
                {
                    _srcConsumerInformationDto = _consumerService.getConsumerInformationDtoByAcc(txtConsumerAccount.Text);
                    lblConsumerTitle.Text = _srcConsumerInformationDto.consumerTitle;
                    lblMobileNoValue.Text = _srcConsumerInformationDto.mobileNumber;
                    lblBalanceValue.Text = (_srcConsumerInformationDto.balance ?? 0).ToString("N", new CultureInfo("BN-BD"));

                    //lblRequiredFingerPrint.Text = "At least " + _srcConsumerInformationDto.numberOfOperator + " operator's finger print required.";
                    if (_srcConsumerInformationDto.photo != null)
                    {
                        byte[] bytes = Convert.FromBase64String(_srcConsumerInformationDto.photo);
                        Image image;
                        image = UtilityServices.byteArrayToImage(bytes);
                        pbxConusmer.Image = image;
                    }

                    if (_srcConsumerInformationDto.accountOperators != null)
                    {
                        fingerPrintGrid.DataSource = _srcConsumerInformationDto.accountOperators.Select(o => new operatorfingerPrintGrid(o) { identity = o.identity, identityName = o.identityName }).ToList();
                    }
                    fingerPrintGrid.Columns[0].Width = 90;
                    fingerPrintGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    fingerPrintGrid.Columns[1].Visible = false;
                    fingerPrintGrid.Columns[2].HeaderText = "Operator Name";
                    return true;
                }
                catch (Exception ex)
                {
                    Message.showError(ex.Message);
                    lblConsumerTitle.Text = "";
                    lblMobileNoValue.Text = "";
                    pbxConusmer.Image = null;
                    return false;
                }
            }
            return false;
        }

        private void rBtnAccount_CheckedChanged(object sender, EventArgs e)
        {
            gbxAccount.Enabled = rBtnAccount.Checked;
            if (rBtnAccount.Checked)
            {
                _gui.Config(ref txtConsumerAccount, Services.ValidCheck.VALIDATIONTYPES.TEXTBOX_EMPTY, null);
            }
            else
            {
                _gui.ControlsForValidation.Remove(txtConsumerAccount);
            }
        }

        private void frmBillPayment_Load(object sender, EventArgs e)
        {
            SendKeys.SendWait("{ENTER}");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbServiceName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;

            //if (validationCheck() && _gui.IsAllControlValidated())
            if (_gui.IsAllControlValidated())
            {
                string result = Message.showConfirmation("Are you sure to pay the bill?");
                if (result == "yes")
                {
                    if (rBtnAccount.Checked)
                    {
                        if (txtConsumerAccount.Text != "" && txtAmount.Text != "")
                        {
                            if (fingerPrintGrid.Rows.Count > 0)
                            {
                                _captureFor = "subagent";
                                bio.CaptureFingerData();
                            }
                            else
                            {
                                Message.showError("Fingerprint not found!");
                                _gui.IsAllControlValidated();
                                return;
                            }
                        }
                        else
                        {
                            Message.showWarning("Account Number or Amount connot be left blank!");
                            _gui.IsAllControlValidated();
                        }
                    }
                    else if (txtAmount.Text != "")
                    {
                        _captureFor = "subagent";
                        bio.CaptureFingerData();
                    }
                    else
                    {
                        Message.showWarning("Amount connot be left blank!");
                        _gui.IsAllControlValidated();
                    }
                }
            }
            btnSave.Enabled = true;
        }

        private bool validationCheck()
        {
            //throw new NotImplementedException();
            return true;
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            if (
                    (cmbServiceName.SelectedValue != null)
                    ||
                    (!string.IsNullOrEmpty(txtAmount.Text))
                )
            {
                decimal billAmount;
                decimal billCharge;
                decimal billTotal;

                string str = "";
                if (decimal.TryParse(txtAmount.Text, out billAmount))
                {
                    str = billAmount.ToString("N", new CultureInfo("BN-BD"));
                    txtAmount.Text = str;
                }

                BillPaymentServices billPaymentServices = new BillPaymentServices();


                billCharge = billPaymentServices.GetChargeByBillAmount((long)cmbServiceName.SelectedValue, billAmount) ?? 0;
                txtCharge.Text = billCharge.ToString("N", new CultureInfo("BN-BD"));
                billTotal = billAmount + billCharge;
                txtTotal.Text = billTotal.ToString("N", new CultureInfo("BN-BD"));
                str = billTotal.ToString();

                lblInWordString.Text = _amountInWords.ToWords(str.Replace(",", "")).Replace("  ", " ");
                rBtnCash.Focus();
            }
            else
            {

            }
        }

        private void txtConsumerAccount_Leave(object sender, EventArgs e)
        {
            LoadSourceConsumerInformation();
        }

        private void fingerPrintGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0 && _srcConsumerInformationDto.accountOperators.Count > 0)
            {
                try
                {
                    AccountOperator accountOperator = _srcConsumerInformationDto.accountOperators[e.RowIndex];
                    if (txtConsumerAccount.Text != "" && txtAmount.Text != "")
                    {
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
                        if (_noOfCapturefinger == _srcConsumerInformationDto.numberOfOperator)
                        {
                            //if (txtConsumerAccount.Text != "" && txtAmount.Text != "")                            
                            {
                                FillObjectWithComponentValue();
                                _BillPaymentRequestDto.txnUserFingerData = _subagentFingerData;

                                List<AccountOperator> objAccOperatorList = new List<AccountOperator>();
                                if (rBtnAccount.Checked)
                                {
                                    for (int i = 0; i < _srcConsumerInformationDto.accountOperators.Count; i++)
                                    {
                                        if (_srcConsumerInformationDto.accountOperators[i].fingerData != null)
                                            objAccOperatorList.Add(_srcConsumerInformationDto.accountOperators[i]);
                                    }
                                }
                                _BillPaymentRequestDto.accountOperators = objAccOperatorList;

                                try
                                {
                                    if (TransactionUIService.isTxnSafe("BillPayment", _BillPaymentRequestDto.accountNo, "", _BillPaymentRequestDto.billAmount))
                                    {
                                        ProgressUIManager.ShowProgress(this);

                                        BillPaymentServices billPaymentServices = new BillPaymentServices();
                                        string ServiceResponse = billPaymentServices.SaveBillPaymentRequest(_BillPaymentRequestDto);

                                        ProgressUIManager.CloseProgress();

                                        TransactionUIService.cacheCurrentTxn("BillPayment", _BillPaymentRequestDto.accountNo, "", _BillPaymentRequestDto.billAmount);

                                        if (!rBtnCash.Checked)
                                        {
                                            Message.showInformation
                                                (
                                                    "Bill payment successfully with Voucher No: " + ServiceResponse +
                                                    "\n\nCurrent Balance is: " + ((_srcConsumerInformationDto.balance ?? 0) - decimal.Parse(txtTotal.Text)).ToString("N", new CultureInfo("BN-BD"))
                                                );
                                        }
                                        else
                                        {
                                            Message.showInformation
                                            (
                                                "Bill payment successfully with Voucher No: " + ServiceResponse
                                            );
                                        }

                                        Clear();

                                        //frmShowReport objfrmShowReport = new frmShowReport();
                                        //objfrmShowReport.WithDrawlReport(ServiceResponse);

                                        cmbServiceName.Focus();
                                    }
                                    else
                                    {
                                        Clear();
                                        cmbServiceName.Focus();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    ProgressUIManager.CloseProgress();
                                    btnSave.Enabled = true;
                                    Message.showError(ex.Message);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("At least number of " + _srcConsumerInformationDto.numberOfOperator + " finger print required. You captured only " + _noOfCapturefinger);
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
                            SetComponentEnableStatus(false);
                        }
                        //lblRequiredFingerPrint.Text = "Caputured " + _noOfCapturefinger + " operator's finger prints out of " + _consumerInformationDto.numberOfOperator;
                    }
                }
            }
            cmbServiceName.Focus();
        }

        private void SetComponentEnableStatus(bool enabled)
        {
            GUI.CONTROLSTATES status;
            if (enabled)
            {
                status = GUI.CONTROLSTATES.CS_ENABLE;
            }
            else
            {
                status = GUI.CONTROLSTATES.CS_DISABLE;
            }

            _gui.SetControlState(status, new Control[]
            {
                cmbServiceName,
                //txtReferenceNo,
                txtCustomerName,
                txtMobile,

                txtBillNo,
                txtAmount,
                txtCharge,
                txtTotal,
                lblInWordString,

                rBtnCash,

                txtConsumerAccount,
                lblConsumerTitle,
                lblMobileNoValue,

                fingerPrintGrid
            });
        }

        private void Clear()
        {
            _BillPaymentRequestDto = new BillPaymentRequestDto();
            _capturefingerData = "";
            _captureFor = "";
            _captureIndexNo = -1;
            _consumerService = new ConsumerServices();
            _noOfCapturefinger = 0;
            _srcConsumerInformationDto = new ConsumerInformationDto();
            _subagentFingerData = "";

            cmbServiceName.SelectedIndex = -1;
            //txtReferenceNo.Text = "";
            txtCustomerName.Text = "";
            txtMobile.Text = "";

            txtBillNo.Text = "";
            txtAmount.Text = "0";
            txtCharge.Text = "0";
            txtTotal.Text = "0";
            lblInWordString.Text = "";

            rBtnCash.Checked = true;

            txtConsumerAccount.Text = "";
            lblConsumerTitle.Text = "";
            lblMobileNoValue.Text = "";
            lblBalanceValue.Text = "";

            fingerPrintGrid.DataSource = null;
            fingerPrintGrid.Rows.Clear();

            SetComponentEnableStatus(true);

            cmbServiceName.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (Message.showConfirmation("Are yous sure to clear?") == "yes")
            {
                Clear();
            }
        }

        private void cmbServiceName_Enter(object sender, EventArgs e)
        {

        }

        private void frmBillPayment_Shown(object sender, EventArgs e)
        {

        }

        private void button1_Enter(object sender, EventArgs e)
        {

        }

        private void frmBillPayment_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner = null;
        }

        private void rBtnCash_CheckedChanged(object sender, EventArgs e)
        {
            txtConsumerAccount.Text = "";
            lblConsumerTitle.Text = "";
            lblMobileNoValue.Text = "";
            lblBalanceValue.Text = "";
            fingerPrintGrid.DataSource = null;
            fingerPrintGrid.Rows.Clear();
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
}
