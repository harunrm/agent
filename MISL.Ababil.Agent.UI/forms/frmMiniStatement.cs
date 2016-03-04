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
using MISL.Ababil.Agent.Infrastructure.Validation;
using MISL.Ababil.Agent.Report.Reports;
using MISL.Ababil.Agent.Report.DataSets;
using MISL.Ababil.Agent.Infrastructure.Models.reports;
using CrystalDecisions.CrystalReports.Engine;
using MetroFramework.Forms;

namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmMiniStatement : MetroForm
    {
        public GUI _gui = new GUI();
        TransactionService _txnService = new TransactionService();
        ConsumerServices _consumerService = new ConsumerServices();
        ConsumerInformationDto _consumerInformationDto = new ConsumerInformationDto();
        List<TransactionDetail> _transactionDetails = new List<TransactionDetail>();
        string _captureFor;
        int _captureIndexNo;
        int _noOfCapturefinger = 0;
        string _capturefingerData;
        string _subagentFingerData;

        public frmMiniStatement()
        {
            InitializeComponent();
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.Text = "Capture";
            buttonColumn.UseColumnTextForButtonValue = true;
            fingerPrintGrid.Columns.Add(buttonColumn);
            lblRequiredFingerPrint.Text = string.Empty;
            lblConsumerTitle.Text = string.Empty;
            ConfigureValidation();
            PrintReport();
            ConfigUIEnhancement();
        }

        public void ConfigUIEnhancement()
        {
            _gui = new GUI(this);
            _gui.Config(ref txtConsumerAccount, ValidCheck.VALIDATIONTYPES.TEXTBOX_EMPTY, null);
        }

        private void PrintReport()
        {
            if (miniStatementGrid.Rows.Count == 0) btnPrint.Enabled = false;
            if (miniStatementGrid.Rows.Count > 0) btnPrint.Enabled = true;


        }

        private void ConfigureValidation()
        {
            ValidationManager.ConfigureValidation(this, txtConsumerAccount, "Account", (long)ValidationType.NonWhitespaceNonEmptyText, true);
        }

        private bool validationCheck()
        {
            return ValidationManager.ValidateForm(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (validationCheck())
            {
                if (txtConsumerAccount.Text != "")
                {
                    MinistatementRequest ministatementRequest = FillMinistatementRequestData();
                    try
                    {
                        _transactionDetails = _txnService.Ministatemnet(ministatementRequest, txtConsumerAccount.Text);

                        if (_transactionDetails != null)
                        {
                            miniStatementGrid.DataSource = _transactionDetails.Select(o => new accountStatementGrid(o) { txnSerial = o.txnSerial, txnDate = o.txnDate, txnNarration = o.txnNarration, trAmount = o.trAmount, txnNumber = o.txnNumber, txnPostBalance = o.txnPostBalance, instrumentNumber = o.instrumentNumber }).ToList();
                        }
                        PrintReport();
                    }
                    catch (Exception ex)
                    {
                        Message.showError(ex.Message);
                    }
                }
                else
                {
                    Message.showWarning("Account number can not be left blank");
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearAllInputData();
            PrintReport();
        }

        private void clearAllInputData()
        {
            txtConsumerAccount.Text = string.Empty;
            lblCustomerTitle.Text = string.Empty;
            lblConsumerTitle.Text = string.Empty;
            lblRequiredFingerPrint.Text = string.Empty;
            pic_consumer.Image = null;
            //miniStatementGrid.Rows.Clear();
            _noOfCapturefinger = 0;
            _miniStatement.Clear();
            _transactionDetails.Clear();
            fingerPrintGrid.DataSource = null;
            miniStatementGrid.DataSource = null;
        }

        private void txtConsumerAccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (Keys)e.KeyChar != Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            base.OnKeyPress(e);
        }

        private MinistatementRequest FillMinistatementRequestData()
        {
            MinistatementRequest request = new MinistatementRequest();
            request.customerAccount = txtConsumerAccount.Text;
            request.transactionDate = UtilityServices.GetLongDate(SessionInfo.currentDate);
            return request;
        }

        private void loadConsumerInformation()
        {
            if (txtConsumerAccount.Text != "")
            {
                try
                {
                    try
                    {
                        _consumerInformationDto = _consumerService.getConsumerInformationDtoByAcc(txtConsumerAccount.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    lblConsumerTitle.Text = _consumerInformationDto.consumerTitle;
                    //lblMobileNo.Text = consumerInformationDto.mobileNumber;
                    lblRequiredFingerPrint.Text = "At least " + _consumerInformationDto.numberOfOperator + " operator's finger print required.";
                    if (_consumerInformationDto.photo != null)
                    {
                        byte[] bytes = Convert.FromBase64String(_consumerInformationDto.photo);
                        Image image;
                        image = UtilityServices.byteArrayToImage(bytes);
                        pic_consumer.Image = image;
                    }

                    if (_consumerInformationDto.accountOperators != null)
                    {
                        fingerPrintGrid.DataSource = _consumerInformationDto.accountOperators.Select(o => new operatorfingerPrintGrid(o) { identity = o.identity, identityName = o.identityName }).ToList();

                    }
                }
                catch (Exception ex)
                {
                    lblConsumerTitle.Text = "";
                    pic_consumer.Image = null;
                    Message.showError(ex.Message);
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
                        Message.showInformation("Please capture agent fingerprint.");
                        _captureFor = "consumer";
                        bio.CaptureFingerData();
                    }
                    else
                    {
                        //if (noOfCapturefinger == consumerInformationDto.numberOfOperator)
                        //{

                        MinistatementRequest ministatementRequest = FillMinistatementRequestData();
                        /*
                            ministatementRequest.agentFingerData = subagentFingerData;
                            List<AccountOperator> objAccOperatorList = new List<AccountOperator>();
                            for (int i = 0; i < consumerInformationDto.accountOperators.Count; i++)
                            {
                                if (consumerInformationDto.accountOperators[i].fingerData != null)
                                    objAccOperatorList.Add(consumerInformationDto.accountOperators[i]);
                            }
                            ministatementRequest.accountOperators = objAccOperatorList;*/

                        try
                        {
                            _transactionDetails = _txnService.Ministatemnet(ministatementRequest, txtConsumerAccount.Text);


                            if (_transactionDetails != null)
                            {
                                miniStatementGrid.DataSource = _transactionDetails.Select(o => new accountStatementGrid(o) { txnSerial = o.txnSerial, txnDate = o.txnDate, txnNarration = o.txnNarration, trAmount = o.trAmount, txnNumber = o.txnNumber, txnPostBalance = o.txnPostBalance, instrumentNumber = o.instrumentNumber }).ToList();
                            }
                            //MessageBox.Show("Transaction successfully completed.");
                            lblConsumerTitle.Text = "";
                            //lblMobileNo.Text = "";
                            //pic_conusmer.Image = null;
                            //txtAmount.Text = "";
                            txtConsumerAccount.Text = "";
                            fingerPrintGrid.DataSource = null;
                        }
                        catch (Exception ex)
                        {
                            Message.showError(ex.Message);
                        }

                        /*
                        }
                        else
                        {
                            MessageBox.Show("At least number of " + consumerInformationDto.numberOfOperator + " finger print required. You captured only " + noOfCapturefinger);
                        }*/
                    }
                }

                else if (_captureFor == "consumer")
                {
                    _capturefingerData = bio.GetSafeLeftFingerData();
                    string previousFingerData = _consumerInformationDto.accountOperators[_captureIndexNo].fingerData;
                    _consumerInformationDto.accountOperators[_captureIndexNo].fingerData = _capturefingerData;
                    fingerPrintGrid.Rows[_captureIndexNo].Cells[0].Style.BackColor = Color.Green;
                    if (previousFingerData == null)
                    {
                        _noOfCapturefinger++;
                        if (_noOfCapturefinger == 1)
                        {
                            clearAllInputData();
                        }
                        lblRequiredFingerPrint.Text = "Caputured " + _noOfCapturefinger + " operator's finger prints out of " + _consumerInformationDto.numberOfOperator;
                    }

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

        public class accountStatementGrid
        {

            public long txnSerial { get; set; }
            public string txnDate { get; set; }
            public string txnNarration { get; set; }
            public string trAmount { get; set; }
            public decimal? txnNumber { get; set; }
            public decimal? txnPostBalance { get; set; }
            public string instrumentNumber { get; set; }

            private TransactionDetail _obj;

            public accountStatementGrid(TransactionDetail obj)
            {
                _obj = obj;
            }

            public TransactionDetail GetModel()
            {
                return _obj;
            }
        }

        private void fingerPrintGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                try
                {
                    AccountOperator accountOperator = _consumerInformationDto.accountOperators[e.RowIndex];
                    if (txtConsumerAccount.Text != "")
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

        private void txtConsumerAccount_MouseLeave(object sender, EventArgs e)
        {
            loadConsumerInformation();
        }

        private void frmMiniStatement_FormClosing(object sender, FormClosingEventArgs e)
        {
            ValidationManager.ReleaseValidationData(this);
            this.Owner = null;
        }

        List<MinistatementReport> _miniStatement = new List<MinistatementReport>();
        private void btnPrint_Click(object sender, EventArgs e)
        {
            crMiniStatement repObj = new crMiniStatement();
            frmReportViewer viewer = new frmReportViewer();
            ReportHeaders rptHeaders = new ReportHeaders();
            rptHeaders = UtilityServices.getReportHeaders("Account Mini Statement");

            TextObject txtBankName = repObj.ReportDefinition.ReportObjects["txtBankName"] as TextObject;
            TextObject txtBranchName = repObj.ReportDefinition.ReportObjects["txtBranchName"] as TextObject;
            TextObject txtBranchAddress = repObj.ReportDefinition.ReportObjects["txtBranchAddress"] as TextObject;
            TextObject txtReportHeading = repObj.ReportDefinition.ReportObjects["txtReportHeading"] as TextObject;
            TextObject txtPrintUser = repObj.ReportDefinition.ReportObjects["txtPrintUser"] as TextObject;
            TextObject txtPrintDate = repObj.ReportDefinition.ReportObjects["txtPrintDate"] as TextObject;

            TextObject txtCustomerTitle = repObj.ReportDefinition.ReportObjects["txtName"] as TextObject;
            TextObject txtAccountNumber = repObj.ReportDefinition.ReportObjects["txtAccountNumber"] as TextObject;
            if (_consumerInformationDto.consumerTitle!=null)
            {
                txtCustomerTitle.Text = _consumerInformationDto.consumerTitle;
            }
            if (txtConsumerAccount.Text != null)
            {
                txtAccountNumber.Text = txtConsumerAccount.Text;
            }

           

            if (rptHeaders != null)
            {
                if (rptHeaders.branchDto != null)
                {
                    txtBankName.Text = rptHeaders.branchDto.bankName;
                    txtBranchName.Text = rptHeaders.branchDto.branchName;
                    txtBranchAddress.Text = rptHeaders.branchDto.branchAddress;
                }
                txtReportHeading.Text = rptHeaders.reportHeading;
                txtPrintUser.Text = rptHeaders.printUser;
                txtPrintDate.Text = rptHeaders.printDate.ToString("dd-MM-yyyy").Replace("-","/");
            }
            _miniStatement.Clear();
            foreach (TransactionDetail tnxDetails in _transactionDetails)
            {
                MinistatementReport MiniStatement = new MinistatementReport();
                MiniStatement.TxnSerial = tnxDetails.txnSerial;
                MiniStatement.TxnDate = (DateTime.Parse(tnxDetails.txnDate)).ToString("dd-MM-yyyy").Replace("-","/");
                //MiniStatement.TxnNarration = tnxDetails.txnNarration;
                MiniStatement.TxnNarration = FirstLetterToUpper(tnxDetails.txnNarration);
                string drcr = tnxDetails.trAmount.Substring(tnxDetails.trAmount.Length - 3).Trim();
                string num = tnxDetails.trAmount.Substring(0, tnxDetails.trAmount.Length - 3);
                Decimal amount = decimal.Parse(num);
                MiniStatement.TrAmount = amount.ToString("N", new CultureInfo("BN-BD")) + " " + drcr;
                MiniStatement.TxnNumber = tnxDetails.txnNumber ?? 0;
                MiniStatement.TxnPostBalance = tnxDetails.txnPostBalance ?? 0;
                MiniStatement.InstrumentNumber = tnxDetails.instrumentNumber;
                _miniStatement.Add(MiniStatement);
            }
            repObj.SetDataSource(_miniStatement);
            viewer.crvReportViewer.ReportSource = repObj;
            viewer.ShowDialog(this.Parent);
        }

        public string FirstLetterToUpper(string str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1).ToLower();

            return str.ToUpper();
        }
    }

    public class MinistatementReport
    {
        public long TxnSerial { get; set; }
        public string TxnDate { get; set; }
        public string TxnNarration { get; set; }
        public string TrAmount { get; set; }
        public decimal TxnNumber { get; set; }
        public decimal TxnPostBalance { get; set; }
        public string InstrumentNumber { get; set; }
    }
}