using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.consumer;
using MISL.Ababil.Agent.Infrastructure.Models.models.transaction;
using MISL.Ababil.Agent.Infrastructure.Validation;
using MISL.Ababil.Agent.Module.Common.UI;

using MISL.Ababil.Agent.Report.Reports;
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
using MISL.Ababil.Agent.Module.ChequeRequisition.Service;
using MISL.Ababil.Agent.Module.ChequeRequisition.Models;
using MISL.Ababil.Agent.Infrastructure.Models.dto;
using MISL.Ababil.Agent.Module.Common.UI.CommentUI;
using MISL.Ababil.Agent.Module.Common.Model;

namespace MISL.Ababil.Agent.Module.ChequeRequisition.UI
{
    public partial class frmChequeRequisitionRequest : MetroForm
    {
        public frmChequeRequisitionRequest(Packet receivePacket, ChequeRequisitionSearchResultDto chequeRequisitionSearchResultDto)
        {
            _receivePacket = receivePacket;
            InitializeComponent();
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.Text = "Capture";
            buttonColumn.UseColumnTextForButtonValue = true;
            fingerPrintGrid.Columns.Add(buttonColumn);
            bio.Visible = false;
            lblRequiredFingerPrint.Text = "";
            lblConsumerTitle.Text = "";
            lblMobileNo.Text = "";
            //lblBalanceValue.Text = "";

            ConfigUIEnhancement();
            SetupDataLoad();

            if (chequeRequisitionSearchResultDto != null)
            {
                _chequeRequisitionSearchResultDto = chequeRequisitionSearchResultDto;
                FillComponentWithObjectValue();
            }
        }

        ChequeRequisitionService _chequeRequisitionService = new ChequeRequisitionService();
        ConsumerServices _consumerService = new ConsumerServices();
        ConsumerInformationDto _consumerInformationDto = new ConsumerInformationDto();
        List<ChequeLeafConfig> _chequeLeafConfigList;
        ChequeRequestDto _chequeRequestDto = null;
        ChequeRequisitionSearchResultDto _chequeRequisitionSearchResultDto = new ChequeRequisitionSearchResultDto();

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
            if (_chequeRequisitionSearchResultDto.accNumber != null)
            {
                txtConsumerAccount.Text = _chequeRequisitionSearchResultDto.accNumber;
                loadConsumerInformation();

                cmbUrgencyType.SelectedItem = _chequeRequisitionSearchResultDto.urgencyType;

                cmbDeliveryForm.SelectedItem = _chequeRequisitionSearchResultDto.chequeDeliveryMedium;

                SubAgentServices subAgentServices = new SubAgentServices();
                BindingSource bs = new BindingSource();
                List<SubAgentInformation> subAgentInformationList = subAgentServices.GetAllSubAgents();

                List<SubagentList> _subAgentList = subAgentInformationList.Select(o => new SubagentList()
                {
                    id = o.id,
                    name = o.name,
                    subAgentCode = o.subAgentCode,
                    subAgentNameWithCode = o.name + "  [" + o.subAgentCode + "]"
                }).ToList();

                //bs.DataSource = subAgentInformationList;
                //UtilityServices.fillComboBox(cmbBranchOrOutlet, bs, "name", "id");
                bs.DataSource = _subAgentList;
                UtilityServices.fillComboBox(cmbBranchOrOutlet, bs, "subAgentNameWithCode", "id");
                cmbBranchOrOutlet.SelectedValue = _chequeRequisitionSearchResultDto.deliveryFrom;

                cmbNumberofLeaf.SelectedValue = cmbNumberofLeaf.Items.Cast<ChequeLeafConfig>().Where(x => x.numberOfLeaf == _chequeRequisitionSearchResultDto.noOfLeaf).First().id;
                txtChequeFrom.Text = _chequeRequisitionSearchResultDto.startingNo;
                txtChequeTo.Text = _chequeRequisitionSearchResultDto.endingNo;

                _comments = (List<CommentDto>)TermService.GetCommentsID((_chequeRequisitionSearchResultDto.commentId).ToString()).ReturnedObject;
                CommentText();
            }

            if (SessionInfo.userBasicInformation.userType == AgentUserType.Outlet)
            {
                AdgustUIForOutletOnReadyStatus();
            }
            if (
                  _receivePacket.actionType == FormActionType.Edit
              ||
                  _receivePacket.actionType == FormActionType.New
              )
            {
                AdgustUIForOutletOnNewOrCorrectionStatus();
            }
        }

        private void AdgustUIForOutletOnNewOrCorrectionStatus()
        {
            _gui.SetControlState(GUI.CONTROLSTATES.CS_HIDDEN, new Control[]
            {
                        btnDelivery

            });

            _gui.SetControlState(GUI.CONTROLSTATES.CS_ENABLE, new Control[]
            {
                        fingerPrintGrid
            });

            _gui.SetControlState(GUI.CONTROLSTATES.CS_VISIBLE, new Control[]
            {
                        btnClear,
                        btnAgreeAndSubmit,
                        lblNote,
                        lblNoteMsg
            });

            _gui.SetControlState(GUI.CONTROLSTATES.CS_ENABLE, new Control[]
            {
                        cmbNumberofLeaf,
                        cmbBranchOrOutlet,
                        //cmbDeliveryForm,
                        txtConsumerAccount,
                        cmbUrgencyType
            });

            _gui.SetControlState(GUI.CONTROLSTATES.CS_HIDDEN, new Control[]
            {
                lblChequeNo,
                txtChequeFrom,
                lblTo,
                txtChequeTo,

            });

            _gui.SetControlState(GUI.CONTROLSTATES.CS_DISABLE, new Control[]
            {
                lblChequeNo,
                txtChequeFrom,
                lblTo,
                txtChequeTo,

            });
        }

        private void AdgustUIForOutletOnReadyStatus()
        {
            if (_chequeRequisitionSearchResultDto.requisitionStatus == ChequeRequisitionStatus.Ready)
            {
                _gui.SetControlState(GUI.CONTROLSTATES.CS_VISIBLE, new Control[]
                {
                        btnDelivery

                });
            }
            else
            {
                _gui.SetControlState(GUI.CONTROLSTATES.CS_DISABLE, new Control[]
                {
                        fingerPrintGrid
                });
            }

            _gui.SetControlState(GUI.CONTROLSTATES.CS_HIDDEN, new Control[]
            {
                        btnClear,
                        btnAgreeAndSubmit,
                        lblNote,
                        lblNoteMsg
            });

            _gui.SetControlState(GUI.CONTROLSTATES.CS_DISABLE, new Control[]
            {
                        cmbNumberofLeaf,
                        cmbBranchOrOutlet,
                        cmbDeliveryForm,
                        txtConsumerAccount,
                        cmbUrgencyType
            });

            _gui.SetControlState(GUI.CONTROLSTATES.CS_VISIBLE, new Control[]
            {
                lblChequeNo,
                txtChequeFrom,
                lblTo,
                txtChequeTo,

            });

            _gui.SetControlState(GUI.CONTROLSTATES.CS_ENABLE, new Control[]
            {
                lblChequeNo,
                txtChequeFrom,
                lblTo,
                txtChequeTo,

            });

            gbxAuthentication.Top = 341;
            gbxChequeInfo.Height = 117;
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
            ChequeRequisitionService chequeRequisitionService = new ChequeRequisitionService();

            {
                cmbUrgencyType.DataSource = chequeRequisitionService.GetUrgencyTypeList();
                cmbUrgencyType.SelectedIndex = -1;
                cmbDeliveryForm.DataSource = chequeRequisitionService.GetDeliveryFromList();
                cmbDeliveryForm.SelectedIndex = 0;
                cmbDeliveryForm.Enabled = false;
            }

            if (
                    (SessionInfo.userBasicInformation.userType == AgentUserType.Outlet)
                &&
                    (_receivePacket.actionType == FormActionType.New)
                )
            {
                SubAgentServices subAgentServices = new SubAgentServices();
                List<SubAgentInformation> subAgentInformationList = subAgentServices.GetAllSubAgents();

                List<SubagentList> _subAgentList = subAgentInformationList.Select(o => new SubagentList()
                {
                    id = o.id,
                    name = o.name,
                    subAgentCode = o.subAgentCode,
                    subAgentNameWithCode = o.name + "  [" + o.subAgentCode + "]"
                }).ToList();

                BindingSource bs = new BindingSource();
                //bs.DataSource = subAgentInformationList;
                //UtilityServices.fillComboBox(cmbBranchOrOutlet, bs, "name", "id");
                bs.DataSource = _subAgentList;
                UtilityServices.fillComboBox(cmbBranchOrOutlet, bs, "subAgentNameWithCode", "id");
                cmbBranchOrOutlet.SelectedValue = SessionInfo.userBasicInformation.outlet.id;
            }

            //Number of Leaf
            {
                _chequeLeafConfigList = chequeRequisitionService.GetChequeLeafConfigList();
                BindingSource bs = new BindingSource();
                bs.DataSource = _chequeLeafConfigList;
                UtilityServices.fillComboBox(cmbNumberofLeaf, bs, "numberOfLeaf", "id");
                cmbNumberofLeaf.SelectedIndex = -1;
            }
        }

        private ChequeRequestDto FillChequeRequestData()
        {
            ChequeRequestDto request = new ChequeRequestDto();

            if (_chequeRequisitionSearchResultDto != null) request.chequeRequestInfoId = _chequeRequisitionSearchResultDto.chequeRequisitionInfoId;  // For correction Requests

            request.accountNo = txtConsumerAccount.Text;
            request.accountOperators = _consumerInformationDto.accountOperators;
            request.chequeDeliveryMedium = (ChequeDeliveryMedium)cmbDeliveryForm.SelectedValue;
            request.deliveryFrom = (long)cmbBranchOrOutlet.SelectedValue;
            request.urgencyType = (UrgencyType)cmbUrgencyType.SelectedValue;

            if (_commentDraft != null)
            {
                _commentDraft.stage = ChequeRequisitionStatus.Submitted.ToString();
            }
            request.comment = _commentDraft;

            //if (request.comment == null)
            //{
            //    request.comment = new CommentDto();
            //}

            ChequeLeafConfig retVal = ((ChequeLeafConfig)cmbNumberofLeaf.SelectedItem);
            if (retVal.numberOfLeaf > 0)
            {
                request.noOfLeaf = retVal.numberOfLeaf;
                request.chargeAmount = retVal.charge;
            }
            else
            {
                MessageBox.Show("Invalid Number of leaf.");
            }
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

        private void bio_OnCapture_AgreeAndSubmit(object sender, EventArgs e)
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
                            if (txtConsumerAccount.Text != "")
                            {
                                _chequeRequestDto = new ChequeRequestDto();
                                _chequeRequestDto = FillChequeRequestData();
                                _chequeRequestDto.agentFingerData = _subagentFingerData;
                                List<AccountOperator> objAccOperatorList = new List<AccountOperator>();
                                for (int i = 0; i < _consumerInformationDto.accountOperators.Count; i++)
                                {
                                    if (_consumerInformationDto.accountOperators[i].fingerData != null)
                                        objAccOperatorList.Add(_consumerInformationDto.accountOperators[i]);
                                }
                                _chequeRequestDto.accountOperators = objAccOperatorList;

                                try
                                {
                                    //if()
                                    {
                                        ProgressUIManager.ShowProgress(this);
                                        string ServiceResponse = _chequeRequisitionService.SaveChequeRequest(_chequeRequestDto);
                                        ProgressUIManager.CloseProgress();
                                        if (ServiceResponse == null) MsgBox.showError("Request is not saved !");
                                        else
                                        {
                                            MsgBox.showInformation(ServiceResponse);
                                            //decimal amountTmp = _consumerInformationDto.balance ?? 0;

                                            ClearUI();
                                        }
                                        //frmShowReport objfrmShowReport = new frmShowReport();
                                        //objfrmShowReport.WithDrawlReport(ServiceResponse);
                                    }
                                    //else
                                    //{
                                    //    clearUI();
                                    //}
                                }
                                catch (Exception ex)
                                {
                                    ProgressUIManager.CloseProgress();
                                    btnAgreeAndSubmit.Enabled = true;
                                    MsgBox.showError(ex.Message);
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

        private void bio_OnCapture_Delivery(object sender, EventArgs e)
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
                        bio2.CaptureFingerData();
                    }
                    else
                    {
                        if (_noOfCapturefinger == _consumerInformationDto.numberOfOperator)
                        {
                            if (txtConsumerAccount.Text != "")
                            {
                                _chequeRequestDto = new ChequeRequestDto();
                                _chequeRequestDto = FillChequeRequestData();
                                _chequeRequestDto.chequeRequestInfoId = _chequeRequisitionSearchResultDto.chequeRequisitionInfoId;
                                _chequeRequestDto.agentFingerData = _subagentFingerData;
                                List<AccountOperator> objAccOperatorList = new List<AccountOperator>();
                                for (int i = 0; i < _consumerInformationDto.accountOperators.Count; i++)
                                {
                                    if (_consumerInformationDto.accountOperators[i].fingerData != null)
                                        objAccOperatorList.Add(_consumerInformationDto.accountOperators[i]);
                                }
                                _chequeRequestDto.accountOperators = objAccOperatorList;

                                try
                                {
                                    ProgressUIManager.ShowProgress(this);
                                    string ServiceResponse = _chequeRequisitionService.SaveChequeRequestDelivery(_chequeRequestDto);
                                    ProgressUIManager.CloseProgress();
                                    MsgBox.showInformation(ServiceResponse);
                                    //ClearUI();
                                    this.Close();
                                }
                                catch (Exception ex)
                                {
                                    ProgressUIManager.CloseProgress();
                                    btnAgreeAndSubmit.Enabled = true;
                                    MsgBox.showError(ex.Message);
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
                        bio.CaptureFingerData();
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

        private void showCashWithdrowRport()
        {
            //crWithdraw objRpt = new crWithdraw();
            //frmReportViewer frm = new frmReportViewer();
            //frm.crvReportViewer.ReportSource = objRpt;
            //frm.ShowDialog();
        }

        private void btnAgreeAndSubmit_Click(object sender, EventArgs e)
        {
            AgreeAndSubmit();
        }

        private void AgreeAndSubmit()
        {
            btnAgreeAndSubmit.Enabled = false;

            if (validationCheck() && _gui.IsAllControlValidated())
            {
                string result = MsgBox.showConfirmation("Are you sure to send the request?");
                if (result == "yes")
                {
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

                        _captureFor = "subagent";
                        bio.CaptureFingerData();
                    }
                    else
                    {
                        MsgBox.showWarning("Account no or amount may be blank.");
                    }
                }
            }
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
            btnAgreeAndSubmit.Enabled = true;
        }

        private void Deliver()
        {
            btnAgreeAndSubmit.Enabled = false;

            if (validationCheck() && _gui.IsAllControlValidated())
            {
                string result = MsgBox.showConfirmation("Are you sure to deliver?");
                if (result == "yes")
                {
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

                        _captureFor = "subagent";
                        bio2.CaptureFingerData();
                    }
                    else
                    {
                        MsgBox.showWarning("Account no or amount may be blank.");
                    }
                }
            }
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
            btnAgreeAndSubmit.Enabled = true;
        }

        private void ClearUI()
        {
            _chequeRequestDto = null;
            _commentDraft = null;
            _comments = null;
            _consumerInformationDto = null;

            txtConsumerAccount.Enabled = true;
            txtConsumerAccount.Text = "";
            pic_conusmer.Image = null;
            fingerPrintGrid.DataSource = null;
            fingerPrintGrid.Refresh();
            lblConsumerTitle.Text = "";
            lblMobileNo.Text = "";
            lblRequiredFingerPrint.Text = "";
            _noOfCapturefinger = 0;
            //lblBalanceValue.Text = "";

            btnComments.Text = "Comments (0)";
            txtChequeFrom.Text = txtChequeTo.Text = "";
            lblChargeValue.Text = "0.00";

            cmbBranchOrOutlet.SelectedIndex = -1;

            //CHECK LATER
            //
            cmbDeliveryForm.SelectedIndex = 0;
            //

            cmbNumberofLeaf.SelectedIndex = -1;
            cmbUrgencyType.SelectedIndex = -1;

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

            #region Validation Check for Cheque Info
            bool isChequeInfoCorrect = true;
            string errMessage = "";

            if (cmbUrgencyType.SelectedValue == null) { errMessage += "Please select Urgency Type.\n"; isChequeInfoCorrect = false; }
            if (cmbNumberofLeaf.SelectedValue == null) { errMessage += "Please select No. of Leaf.\n"; isChequeInfoCorrect = false; }
            if (cmbDeliveryForm.SelectedValue == null) { errMessage += "Please select a delivery medium.\n"; isChequeInfoCorrect = false; }
            else if (cmbBranchOrOutlet.SelectedValue == null)
            {
                if (lblBranchOrOutlet.Text.Trim().ToLower() == "branch :") { errMessage += "Please select a Branch.\n"; isChequeInfoCorrect = false; }
                else if (lblBranchOrOutlet.Text.Trim().ToLower() == "outlet :") { errMessage += "Please select an Outlet.\n"; isChequeInfoCorrect = false; }
            }

            if (!isChequeInfoCorrect)
            {
                MsgBox.showWarning("Input required !\n" + errMessage);
                return false;
            }
            #endregion

            return true;
        }

        private void frmChequeRequisition_Load(object sender, EventArgs e)
        {
            //if(_receivePacket.actionType== FormActionType.New)
            //{

            //}
        }

        private void frmChequeRequisition_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner = null;
        }

        private void cmbDeliveryForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDeliveryForm.SelectedValue != null)
            {
                switch ((ChequeDeliveryMedium)cmbDeliveryForm.SelectedValue)
                {
                    case ChequeDeliveryMedium.Outlet:
                        lblBranchOrOutlet.Text = "Outlet :";
                        LoadAllOutlet();
                        break;
                    case ChequeDeliveryMedium.Branch:
                        lblBranchOrOutlet.Text = "Branch :";
                        LoadAllBranch();
                        break;
                    default:
                        break;
                }
            }
        }

        private void LoadAllOutlet()
        {
            SubAgentServices subAgentServices = new SubAgentServices();
            List<SubAgentInformation> subAgentInformationList = subAgentServices.GetAllSubAgents();
            BindingSource bs = new BindingSource();
            bs.DataSource = subAgentInformationList;
            UtilityServices.fillComboBox(cmbBranchOrOutlet, bs, "name", "id");
            cmbBranchOrOutlet.SelectedIndex = -1;
        }
        private void LoadAllBranch()
        {
            UtilityServices.fillBranches(ref cmbBranchOrOutlet);
            cmbBranchOrOutlet.SelectedIndex = -1;
        }

        private void cmbNumberofLeaf_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (cmbNumberofLeaf.SelectedValue != null)
                {
                    List<ChequeLeafConfig> selectedChequeLeafConfigList = _chequeLeafConfigList.Where(x => x.id == (long)(cmbNumberofLeaf.SelectedValue ?? 0)).ToList<ChequeLeafConfig>();

                    lblChargeValue.Text = selectedChequeLeafConfigList[0].charge.ToString();
                }

            }
            catch
            {


            }
            //lblChargeValue.Text = ((ChequeLeafConfig)cmbNumberofLeaf.SelectedValue).charge.ToString();
        }

        private void btnComments_Click(object sender, EventArgs e)
        {
            Packet packetTmp = new Packet();
            packetTmp.actionType = FormActionType.Edit;
            packetTmp.intentType = IntentType.Request;

            string stageTmp = "";
            if (SessionInfo.userBasicInformation.userType == AgentUserType.Outlet)
            {
                stageTmp = "Submission";
            }
            else
            {
                stageTmp = "Approval";
            }

            if (_chequeRequestDto != null)
            {
                if (_chequeRequestDto != null)
                {
                    //if (_receivePacket.actionType != FormActionType.New)
                    {
                        //if (_termAccountRequestDto.termAccountInformation != null)
                        {
                            if (_chequeRequestDto.comment != null
                                ||
                                _chequeRequestDto.comment.comment_id != 0)
                            {
                                _comments = (List<CommentDto>)TermService.GetCommentsID((_chequeRequestDto.comment.comment_id).ToString()).ReturnedObject;
                            }

                        }
                        frmCommentUI frm = new frmCommentUI(packetTmp, _commentDraft, _comments, stageTmp);
                        frm.Top = this.Top + btnComments.Top - frm.Height + 40;
                        frm.Left = btnComments.Left + this.Left + 10;
                        frm.ShowDialog();
                        _commentDraft = frm._commentDraft;
                        CommentText();
                        return;
                    }
                }
            }

            if (_receivePacket.actionType == FormActionType.New)
            {
                _comments = new List<CommentDto>();
                frmCommentUI frm = new frmCommentUI(packetTmp, _commentDraft, _comments, stageTmp);
                frm.Top = this.Top + btnComments.Top - frm.Height + 40;
                frm.Left = btnComments.Left + this.Left + 10;
                frm.ShowDialog();
                _commentDraft = frm._commentDraft;
                CommentText();
            }
        }

        private void CommentText()
        {
            int count = _comments.Count;
            if (_commentDraft != null)
            {
                count++;
                btnComments.BackColor = Color.LightGreen;
            }
            btnComments.Text = "Comment (" + count.ToString() + ")";
        }

        private void btnDelivery_Click(object sender, EventArgs e)
        {
            Deliver();
        }
    }
    
}