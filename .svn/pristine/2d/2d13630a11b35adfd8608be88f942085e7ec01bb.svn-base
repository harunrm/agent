using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.consumer;
using MISL.Ababil.Agent.Infrastructure.Models.models.transaction;
using MISL.Ababil.Agent.Infrastructure.Validation;
using MISL.Ababil.Agent.Module.Common.UI;
using MISL.Ababil.Agent.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MISL.Ababil.Agent.Module.Common.UI.MessageUI;
using MISL.Ababil.Agent.UI;
using MetroFramework.Forms;
using MISL.Ababil.Agent.Module.Common.Service;
using MISL.Ababil.Agent.UI.forms.ProgressUI;
using MISL.Ababil.Agent.Infrastructure.Models.dto;
using MISL.Ababil.Agent.Module.Common.UI.CommentUI;

namespace MISL.Ababil.Agent.Module.Security.UI
{
    public partial class frmFingerprintManager : MetroForm
    {
        public frmFingerprintManager(Packet receivePacket)
        {
            _receivePacket = receivePacket;
            InitializeComponent();
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.Text = "New Capture";
            buttonColumn.UseColumnTextForButtonValue = true;
            fingerPrintGrid.Columns.Add(buttonColumn);

            lblRequiredFingerPrint.Text = "";
            lblConsumerTitle.Text = "";
            lblMobileNo.Text = "";
            //lblBalanceValue.Text = "";

            ConfigUIEnhancement();
            SetupDataLoad();

            //if (chequeRequisitionSearchResultDto != null)
            //{
            //    _chequeRequisitionSearchResultDto = chequeRequisitionSearchResultDto;
            //    FillComponentWithObjectValue();
            //}
        }

        ConsumerServices _consumerService = new ConsumerServices();
        ConsumerInformationDto _consumerInformationDto = new ConsumerInformationDto();

        GUI _gui = new GUI();

        string _captureFor;
        int _captureIndexNo;
        int _noOfCapturefinger = 0;
        string _capturefingerData;
        string _subagentFingerData;
        bool? _isManualChargeApplicable = null;
        decimal _chargeAmount;

        public List<CommentDto> _comments;
        public CommentDto _commentDraft;
        private Packet _receivePacket;

        private void FillComponentWithObjectValue()
        {
            if (SessionInfo.userBasicInformation.userType == AgentUserType.Outlet)
            {
                AdgustUIForOutletOnReadyStatus();
            }
        }

        private void AdgustUIForOutletOnReadyStatus()
        {
            _gui.SetControlState(GUI.CONTROLSTATES.CS_HIDDEN, new Control[]
            {

            });
        }

        public ConsumerServices ConsumerService
        {
            get
            {
                return _consumerService;
            }

            set
            {
                _consumerService = value;
            }
        }



        public void ConfigUIEnhancement()
        {
            _gui = new GUI(this);

            _gui.Config(ref txtConsumerAccount, GUIValidation.VALIDATIONTYPES.TEXTBOX_EMPTY, null);
        }


        private void SetupDataLoad()
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtConsumerAccount_Leave(object sender, EventArgs e)
        {
            loadConsumerInformation();
        }

        private void bio_OnCapture_AgreeAndSubmit(object sender, EventArgs e)
        {
            ////AxBIOPLUGINACTXLib.AxBioPlugInActX x = (AxBIOPLUGINACTXLib.AxBioPlugInActX)sender;

            ////if (x.result == "0")
            ////{
            ////    if (_captureFor == "subagent")
            ////    {
            ////        _subagentFingerData = bio.GetSafeLeftFingerData();
            ////        if (_subagentFingerData == null)
            ////        {
            ////            MessageBox.Show("Please capture agent fingerprint.");
            ////            _captureFor = "consumer";
            ////            bio.CaptureFingerData();
            ////        }
            ////        else
            ////        {
            ////            if (_noOfCapturefinger == _consumerInformationDto.numberOfOperator)
            ////            {
            ////                if (txtConsumerAccount.Text != "")
            ////                {
            ////                    _chequeRequestDto = new ChequeRequestDto();
            ////                    _chequeRequestDto = FillChequeRequestData();
            ////                    _chequeRequestDto.agentFingerData = _subagentFingerData;
            ////                    List<AccountOperator> objAccOperatorList = new List<AccountOperator>();
            ////                    for (int i = 0; i < _consumerInformationDto.accountOperators.Count; i++)
            ////                    {
            ////                        if (_consumerInformationDto.accountOperators[i].fingerData != null)
            ////                            objAccOperatorList.Add(_consumerInformationDto.accountOperators[i]);
            ////                    }
            ////                    _chequeRequestDto.accountOperators = objAccOperatorList;

            ////                    try
            ////                    {
            ////                        //if()
            ////                        {
            ////                            ProgressUIManager.ShowProgress(this);
            ////                            string ServiceResponse = _chequeRequisitionService.SaveChequeRequest(_chequeRequestDto);
            ////                            ProgressUIManager.CloseProgress();
            ////                            MsgBox.showInformation(ServiceResponse);
            ////                            //decimal amountTmp = _consumerInformationDto.balance ?? 0;

            ////                            ClearUI();
            ////                            //frmShowReport objfrmShowReport = new frmShowReport();
            ////                            //objfrmShowReport.WithDrawlReport(ServiceResponse);
            ////                        }
            ////                        //else
            ////                        //{
            ////                        //    clearUI();
            ////                        //}
            ////                    }
            ////                    catch (Exception ex)
            ////                    {
            ////                        ProgressUIManager.CloseProgress();
            ////                        btnAgreeAndSubmit.Enabled = true;
            ////                        MsgBox.showError(ex.Message);
            ////                    }
            ////                }
            ////            }
            ////            else
            ////            {
            ////                MessageBox.Show("At least number of " + _consumerInformationDto.numberOfOperator + " finger print required. You captured only " + _noOfCapturefinger);
            ////            }
            ////        }
            ////    }
            ////    else if (_captureFor == "consumer")
            ////    {
            ////        _capturefingerData = bio.GetSafeLeftFingerData();
            ////        string previousFingerData = _consumerInformationDto.accountOperators[_captureIndexNo].fingerData;
            ////        _consumerInformationDto.accountOperators[_captureIndexNo].fingerData = _capturefingerData;
            ////        fingerPrintGrid.Rows[_captureIndexNo].Cells[1].Style.BackColor = Color.Green;
            ////        fingerPrintGrid.Rows[_captureIndexNo].Cells[2].Style.BackColor = Color.Green;
            ////        if (previousFingerData == null)
            ////        {
            ////            _noOfCapturefinger++;
            ////            if (_noOfCapturefinger == 1)
            ////            {
            ////                disableAllComponent();
            ////            }
            ////            lblRequiredFingerPrint.Text = "Caputured " + _noOfCapturefinger + " operator's finger prints out of " + _consumerInformationDto.numberOfOperator;
            ////        }
            ////    }
            ////}
        }

        private void bio_OnCapture_Delivery(object sender, EventArgs e)
        {
            ////AxBIOPLUGINACTXLib.AxBioPlugInActX x = (AxBIOPLUGINACTXLib.AxBioPlugInActX)sender;

            ////if (x.result == "0")
            ////{
            ////    if (_captureFor == "subagent")
            ////    {
            ////        _subagentFingerData = bio.GetSafeLeftFingerData();
            ////        if (_subagentFingerData == null)
            ////        {
            ////            MessageBox.Show("Please capture agent fingerprint.");
            ////            _captureFor = "consumer";
            ////            bio2.CaptureFingerData();
            ////        }
            ////        else
            ////        {
            ////            if (_noOfCapturefinger == _consumerInformationDto.numberOfOperator)
            ////            {
            ////                if (txtConsumerAccount.Text != "")
            ////                {
            ////                    _chequeRequestDto = new ChequeRequestDto();
            ////                    _chequeRequestDto = FillChequeRequestData();
            ////                    _chequeRequestDto.chequeRequestInfoId = _chequeRequisitionSearchResultDto.chequeRequisitionInfoId;
            ////                    _chequeRequestDto.agentFingerData = _subagentFingerData;
            ////                    List<AccountOperator> objAccOperatorList = new List<AccountOperator>();
            ////                    for (int i = 0; i < _consumerInformationDto.accountOperators.Count; i++)
            ////                    {
            ////                        if (_consumerInformationDto.accountOperators[i].fingerData != null)
            ////                            objAccOperatorList.Add(_consumerInformationDto.accountOperators[i]);
            ////                    }
            ////                    _chequeRequestDto.accountOperators = objAccOperatorList;

            ////                    try
            ////                    {
            ////                        ProgressUIManager.ShowProgress(this);
            ////                        string ServiceResponse = _chequeRequisitionService.SaveChequeRequestDelivery(_chequeRequestDto);
            ////                        ProgressUIManager.CloseProgress();
            ////                        MsgBox.showInformation(ServiceResponse);
            ////                        ClearUI();
            ////                    }
            ////                    catch (Exception ex)
            ////                    {
            ////                        ProgressUIManager.CloseProgress();
            ////                        btnAgreeAndSubmit.Enabled = true;
            ////                        MsgBox.showError(ex.Message);
            ////                    }
            ////                }
            ////            }
            ////            else
            ////            {
            ////                MessageBox.Show("At least number of " + _consumerInformationDto.numberOfOperator + " finger print required. You captured only " + _noOfCapturefinger);
            ////            }
            ////        }
            ////    }
            ////    else if (_captureFor == "consumer")
            ////    {
            ////        _capturefingerData = bio.GetSafeLeftFingerData();
            ////        string previousFingerData = _consumerInformationDto.accountOperators[_captureIndexNo].fingerData;
            ////        _consumerInformationDto.accountOperators[_captureIndexNo].fingerData = _capturefingerData;
            ////        fingerPrintGrid.Rows[_captureIndexNo].Cells[1].Style.BackColor = Color.Green;
            ////        fingerPrintGrid.Rows[_captureIndexNo].Cells[2].Style.BackColor = Color.Green;
            ////        if (previousFingerData == null)
            ////        {
            ////            _noOfCapturefinger++;
            ////            if (_noOfCapturefinger == 1)
            ////            {
            ////                disableAllComponent();
            ////            }
            ////            lblRequiredFingerPrint.Text = "Caputured " + _noOfCapturefinger + " operator's finger prints out of " + _consumerInformationDto.numberOfOperator;
            ////        }
            ////    }
            ////}
        }

        private void disableAllComponent()
        {
            txtConsumerAccount.Enabled = false;
        }

        private void txtConsumerAccount_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (txtConsumerAccount.Text != "")
                    {
                        _gui.SetControlState
                        (
                            GUI.CONTROLSTATES.CS_READONLY,
                            new Control[]
                            {
                                txtConsumerAccount,
                            }
                        );

                        var senderGrid = (DataGridView)sender;
                        _captureIndexNo = e.RowIndex;
                        ///////////bio.CaptureFingerData();
                        _captureFor = "consumer";
                    }
                    else
                    {
                        MsgBox.showInformation("Account number or amount may be blank.");
                    }
                }
                catch
                {
                    MsgBox.showWarning("No operator found for capture.");
                }
            }
        }

        private void loadConsumerInformation()
        {
            if (ValidationManager.ValidateNonEmptyTextWithoutSpace(txtConsumerAccount.Text))
            {
                try
                {
                    _consumerInformationDto = new ConsumerInformationDto();
                    _consumerInformationDto = ConsumerService.getConsumerInformationDtoByAcc(txtConsumerAccount.Text);
                    lblConsumerTitle.Text = _consumerInformationDto.consumerTitle;
                    lblMobileNo.Text = _consumerInformationDto.mobileNumber;
                    //lblBalanceValue.Text = (_consumerInformationDto.balance ?? 0).ToString("N", new CultureInfo("BN-BD"));
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
                        fingerPrintGrid.Columns[1].Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MsgBox.showError(ex.Message);

                    lblConsumerTitle.Text = "";
                    lblMobileNo.Text = "";
                    //lblBalanceValue.Text = "";
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

        private void ClearUI()
        {
            _commentDraft = null;
            _comments = null;
            _consumerInformationDto = null;

            txtConsumerAccount.Enabled = true;
            txtConsumerAccount.Text = "";
            pic_conusmer.Image = null;
            fingerPrintGrid.DataSource = null;
            lblConsumerTitle.Text = "";
            lblMobileNo.Text = "";
            lblRequiredFingerPrint.Text = "";
            _noOfCapturefinger = 0;
            //lblBalanceValue.Text = "";

            //lblBalanceValue.Text = "0.00";            

            _gui.SetControlState
            (
                GUI.CONTROLSTATES.CS_READWRITE,
                new Control[]
                {
                    txtConsumerAccount,
                }
            );
            if (_isManualChargeApplicable == true)
            {
                //txtrCharge.ReadOnly = false;
            }
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            ClearUI();
        }

        private bool validationCheck()
        {
            if (_consumerInformationDto == null)
            {
                MsgBox.showWarning("Customer information not found!");
                return false;
            }

            if (txtConsumerAccount.Text == "")
            {
                MsgBox.showWarning("Account number can not be left blank");
                txtConsumerAccount.Focus();
                return false;
            }

            //if (txtAmount.Text == "")
            //{
            //    MsgBox.showWarning("Amount can not be left blank");
            //    txtAmount.Focus();
            //    return false;
            //}

            if (_noOfCapturefinger != _consumerInformationDto.numberOfOperator)
            {
                MsgBox.showWarning("At least number of " + _consumerInformationDto.numberOfOperator + " finger print required. You captured only " + _noOfCapturefinger);
                return false;
            }

            if (_consumerInformationDto.accountOperators == null)
            {
                MsgBox.showWarning("Your account (" + txtConsumerAccount.Text + ") may be not eligible for withdraw from agent banking");
                return false;
            }

            return true;
        }

        private void frmChequeRequisition_Load(object sender, EventArgs e)
        {

        }

        private void frmChequeRequisition_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner = null;
        }
    }
}