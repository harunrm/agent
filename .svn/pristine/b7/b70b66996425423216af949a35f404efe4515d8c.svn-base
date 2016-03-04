using MetroFramework.Forms;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using MISL.Ababil.Agent.Infrastructure.Models.dto;
using MISL.Ababil.Agent.Module.ChequeRequisition.Models;
using MISL.Ababil.Agent.Module.ChequeRequisition.Service;
using MISL.Ababil.Agent.Module.Common.UI.CommentUI;
using MISL.Ababil.Agent.Module.Common.UI.MessageUI;
using MISL.Ababil.Agent.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using MISL.Ababil.Agent.Module.Common.UI;
using MISL.Ababil.Agent.Module.Common.Model;
using MISL.Ababil.Agent.UI.forms.ProgressUI;

namespace MISL.Ababil.Agent.Module.ChequeRequisition.UI
{
    public partial class frmChequeRequisition : MetroForm
    {
        private int chequeSerialDigits = 7;
        private CommentDto _commentDraft;
        private List<CommentDto> _comments;
        private Packet _receivePacket;
        private long _lastChequeSerial;

        public frmChequeRequisition(Packet packet, ChequeRequisitionSearchResultDto chequeRequisitionSearchResultDto)
        {
            _receivePacket = packet;
            InitializeComponent();

            _chequeRequisitionSearchResultDto = chequeRequisitionSearchResultDto;

            SetupDataLoad();
            FillComponentWithObjectValue();

            UpdateUIStateByUserTypeAndStatus();

            //if (SessionInfo.userBasicInformation.userType != AgentUserType.Outlet) btnReady.Visible = false;
            //if (_chequeRequisitionSearchResultDto.requisitionStatus == ChequeRequisitionStatus.Ready) btnReady.Visible = false;
            //else if (_chequeRequisitionSearchResultDto.requisitionStatus == ChequeRequisitionStatus.Correction)
            //{ btnApprove.Visible = btnReady.Visible = false; }
        }

        private ChequeRequisitionSearchResultDto _chequeRequisitionSearchResultDto { get; set; }
        private GUI _gui = new GUI();

        private void SetupDataLoad()
        {
            ChequeRequisitionService chequeRequisitionService = new ChequeRequisitionService();
            cmbUrgencyType.DataSource = chequeRequisitionService.GetUrgencyTypeList();
            cmbUrgencyType.SelectedIndex = -1;

            cmbDeliveryMedium.DataSource = chequeRequisitionService.GetDeliveryFromList();
            cmbDeliveryMedium.SelectedIndex = -1;
            //ChequeDeliveryMedium
        }

        private void UpdateUIStateByUserTypeAndStatus()
        {
            if (
                    SessionInfo.userBasicInformation.userType == AgentUserType.Admin
                ||
                    SessionInfo.userBasicInformation.userType == AgentUserType.Branch
                )
            {
                switch (_chequeRequisitionSearchResultDto.requisitionStatus)
                {
                    case ChequeRequisitionStatus.Submitted:
                        _gui.SetControlState(GUI.CONTROLSTATES.CS_VISIBLE, new Control[]
                        {
                            btnApprove,
                            btnReject,
                            btnCorrection
                        });
                        break;
                    case ChequeRequisitionStatus.Processing:
                        _gui.SetControlState(GUI.CONTROLSTATES.CS_VISIBLE, new Control[]
                        {
                           // btnReject,     => Shouldn't reject after it's accepted. Because charge+VAT already deducted.
                           // btnCorrection,
                            btnPrepare
                        });
                        break;
                    case ChequeRequisitionStatus.Prepared:
                        break;
                    case ChequeRequisitionStatus.Ready:
                        break;
                    case ChequeRequisitionStatus.Delivered:
                        break;
                    case ChequeRequisitionStatus.Correction:
                        break;
                    case ChequeRequisitionStatus.Cancel:
                        break;
                    default:
                        break;
                }
            }
        }

        private void FillComponentWithObjectValue()
        {
            if (_chequeRequisitionSearchResultDto != null)
            {
                txtAccountNo.Text = _chequeRequisitionSearchResultDto.accNumber;
                txtTitle.Text = _chequeRequisitionSearchResultDto.accTitle;
                txtReferenceNumber.Text = _chequeRequisitionSearchResultDto.refNumber;
                txtNumberOfLeaf.Text = _chequeRequisitionSearchResultDto.noOfLeaf.ToString();

                cmbUrgencyType.SelectedItem = _chequeRequisitionSearchResultDto.urgencyType;
                cmbUrgencyType.Enabled = false;

                cmbDeliveryMedium.SelectedItem = _chequeRequisitionSearchResultDto.chequeDeliveryMedium;
                cmbDeliveryMedium.Enabled = false;

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
                //UtilityServices.fillComboBox(cmbDeliveryFrom, bs, "name", "id");
                bs.DataSource = _subAgentList;
                UtilityServices.fillComboBox(cmbDeliveryFrom, bs, "subAgentNameWithCode", "id");
                cmbDeliveryFrom.SelectedValue = _chequeRequisitionSearchResultDto.deliveryFrom;
                cmbDeliveryFrom.Enabled = false;

                _comments = (List<CommentDto>)TermService.GetCommentsID((_chequeRequisitionSearchResultDto.commentId).ToString()).ReturnedObject;
                CommentText();

                if (_chequeRequisitionSearchResultDto.startingNo != null) txtSerialFrom.Text = _chequeRequisitionSearchResultDto.startingNo.PadLeft(chequeSerialDigits, '0');
                if (_chequeRequisitionSearchResultDto.endingNo != null) txtSerialTo.Text = _chequeRequisitionSearchResultDto.endingNo.PadLeft(chequeSerialDigits, '0');

                #region rejected
                //if (
                //    (_chequeRequisitionSearchResultDto.requisitionStatus == ChequeRequisitionStatus.processing) 
                //    ||
                //    (_chequeRequisitionSearchResultDto.requisitionStatus == ChequeRequisitionStatus.ready)
                //    ||
                //    (_chequeRequisitionSearchResultDto.requisitionStatus == ChequeRequisitionStatus.prepared)
                //    ||
                //    (_chequeRequisitionSearchResultDto.requisitionStatus == ChequeRequisitionStatus.delivered)
                //   )
                //{
                //    VisibleChequeSerialNo(true);

                //    if (_chequeRequisitionSearchResultDto.requisitionStatus != ChequeRequisitionStatus.processing)
                //    {
                //        btnPrepare.Visible = false;
                //        txtSerialFrom.ReadOnly = txtSerialTo.ReadOnly = true;
                //    }
                //}
                
                //if (_chequeRequisitionSearchResultDto.requisitionStatus == ChequeRequisitionStatus.prepared)
                //{
                //    VisibleChequeSerialNo(true);
                //    txtSerialFrom.ReadOnly = txtSerialTo.ReadOnly = true;

                //    btnPrepare.Visible = false;
                //    btnReady.Visible = true;
                //}
                
                //if (_chequeRequisitionSearchResultDto.requisitionStatus == ChequeRequisitionStatus.submitted) VisibleChequeSerialNo(false);
                //if (_chequeRequisitionSearchResultDto.requisitionStatus == ChequeRequisitionStatus.correction) btnCorrection.Visible = false;
                #endregion

                #region Control form buttons visibility
                if (_chequeRequisitionSearchResultDto.requisitionStatus == ChequeRequisitionStatus.Submitted)
                {
                    lblSerialNumberFrom.Visible = txtSerialFrom.Visible = lblSerialNumberTo.Visible = txtSerialTo.Visible = false;

                    btnApprove.Visible = btnCorrection.Visible = btnReject.Visible = true;
                    btnPrepare.Visible = btnReady.Visible = false;

                    if (SessionInfo.userBasicInformation.userType != AgentUserType.Branch && SessionInfo.userBasicInformation.userType != AgentUserType.Admin)
                    { btnApprove.Visible = btnCorrection.Visible = btnReject.Visible = false; }
                }
                else if (_chequeRequisitionSearchResultDto.requisitionStatus == ChequeRequisitionStatus.Processing)
                {
                    _setChequeSerialNumber();
                    lblSerialNumberFrom.Visible = txtSerialFrom.Visible = lblSerialNumberTo.Visible = txtSerialTo.Visible = true;

                    btnPrepare.Visible = true;
                    btnReject.Visible = btnCorrection.Visible = btnApprove.Visible = btnReady.Visible = false;

                    if (SessionInfo.userBasicInformation.userType != AgentUserType.Branch && SessionInfo.userBasicInformation.userType != AgentUserType.Admin)
                    { btnCorrection.Visible = btnPrepare.Visible = false; }
                }
                else if (_chequeRequisitionSearchResultDto.requisitionStatus == ChequeRequisitionStatus.Prepared)
                {
                    lblSerialNumberFrom.Visible = txtSerialFrom.Visible = lblSerialNumberTo.Visible = txtSerialTo.Visible = true;
                    btnReject.Visible = btnReady.Visible = btnApprove.Visible = btnCorrection.Visible = btnPrepare.Visible = false;

                    if (SessionInfo.userBasicInformation.userType == AgentUserType.Outlet)
                    {
                        if (_chequeRequisitionSearchResultDto.deliveryFrom == SessionInfo.userBasicInformation.outlet.id) btnReady.Visible = true;
                        else btnReady.Visible = false; 
                    }
                }
                else if (_chequeRequisitionSearchResultDto.requisitionStatus == ChequeRequisitionStatus.Ready)
                {
                    lblSerialNumberFrom.Visible = txtSerialFrom.Visible = lblSerialNumberTo.Visible = txtSerialTo.Visible = true;
                    btnReject.Visible = btnApprove.Visible = btnCorrection.Visible = btnPrepare.Visible = btnReady.Visible = false;
                }
                else if (_chequeRequisitionSearchResultDto.requisitionStatus == ChequeRequisitionStatus.Delivered)
                {
                    lblSerialNumberFrom.Visible = txtSerialFrom.Visible = lblSerialNumberTo.Visible = txtSerialTo.Visible = true;
                    btnReject.Visible = btnApprove.Visible = btnCorrection.Visible = btnPrepare.Visible = btnReady.Visible = false;
                }
                else if (_chequeRequisitionSearchResultDto.requisitionStatus == ChequeRequisitionStatus.Correction)
                {
                    lblSerialNumberFrom.Visible = txtSerialFrom.Visible = lblSerialNumberTo.Visible = txtSerialTo.Visible = false;
                    btnReject.Visible = btnApprove.Visible = btnCorrection.Visible = btnPrepare.Visible = btnReady.Visible = false;
                }
                if (_chequeRequisitionSearchResultDto.requisitionStatus == ChequeRequisitionStatus.Cancel)
                {
                    lblSerialNumberFrom.Visible = txtSerialFrom.Visible = lblSerialNumberTo.Visible = txtSerialTo.Visible = false;
                    btnReject.Visible = btnApprove.Visible = btnCorrection.Visible = btnPrepare.Visible = btnReady.Visible = false;
                }

                txtSerialFrom.ReadOnly = txtSerialTo.ReadOnly = true;
                #endregion
            }
        }

        private void frmChequeRequisition_Load(object sender, EventArgs e)
        {

        }

        private void frmChequeRequisition_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner = null;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            string result = MsgBox.showConfirmation("Are you sure to accept this request ?");
            if (result == "yes")
            {
                try
                {
                    ProgressUIManager.ShowProgress(this);
                    ChequeRequisitionService chequeRequisitionService = new ChequeRequisitionService();
                    ChequeRequestStatusChangeDto chequeRequestStatusChangeDto = new ChequeRequestStatusChangeDto();
                    if (_commentDraft != null)
                    {
                        _commentDraft.stage = ChequeRequisitionStatus.Processing.ToString();
                        _commentDraft.id = _chequeRequisitionSearchResultDto.commentId;
                    }

                    chequeRequestStatusChangeDto.chequeRequestInfoId = _chequeRequisitionSearchResultDto.chequeRequisitionInfoId;
                    chequeRequestStatusChangeDto.commentDto = _commentDraft;
                    string responseString = chequeRequisitionService.ChangeChequeRequisitionStatus(chequeRequestStatusChangeDto, "processing");
                    if (responseString == "") responseString = "Cheque requisition is processing.";
                    ProgressUIManager.CloseProgress();
                    MsgBox.showInformation(responseString);
                    this.Close();
                }
                catch (Exception exp)
                { ProgressUIManager.CloseProgress(); MsgBox.showError(exp.Message); }
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (_commentDraft == null)
            {
                MsgBox.showWarning("Comment required to reject a request.");
                return;
            }

            string result = MsgBox.showConfirmation("Are you sure to reject this request ?");
            if (result == "yes")
            {
                try
                {
                    ProgressUIManager.ShowProgress(this);
                    ChequeRequisitionService chequeRequisitionService = new ChequeRequisitionService();
                    ChequeRequestStatusChangeDto chequeRequestStatusChangeDto = new ChequeRequestStatusChangeDto();
                    if (_commentDraft != null)
                    {
                        _commentDraft.stage = ChequeRequisitionStatus.Cancel.ToString();
                        _commentDraft.id = _chequeRequisitionSearchResultDto.commentId;
                    }

                    chequeRequestStatusChangeDto.chequeRequestInfoId = _chequeRequisitionSearchResultDto.chequeRequisitionInfoId;
                    chequeRequestStatusChangeDto.commentDto = _commentDraft;
                    string responseString = chequeRequisitionService.ChangeChequeRequisitionStatus(chequeRequestStatusChangeDto, "cancel");
                    MsgBox.showInformation(responseString);
                    ProgressUIManager.CloseProgress();
                    this.Close();
                }
                catch (Exception exp)
                { ProgressUIManager.CloseProgress(); MsgBox.showError(exp.Message); }
            }
        }

        private void btnCorrection_Click(object sender, EventArgs e)
        {
            string result = MsgBox.showConfirmation("Are you sure to send for correction ?");
            if (result == "yes")
            {
                try
                {
                    ProgressUIManager.ShowProgress(this);
                    ChequeRequisitionService chequeRequisitionService = new ChequeRequisitionService();
                    ChequeRequestStatusChangeDto chequeRequestStatusChangeDto = new ChequeRequestStatusChangeDto();
                    if (_commentDraft != null)
                    {
                        _commentDraft.stage = ChequeRequisitionStatus.Correction.ToString();
                        _commentDraft.id = _chequeRequisitionSearchResultDto.commentId;
                    }

                    chequeRequestStatusChangeDto.chequeRequestInfoId = _chequeRequisitionSearchResultDto.chequeRequisitionInfoId;
                    chequeRequestStatusChangeDto.commentDto = _commentDraft;
                    string responseString = chequeRequisitionService.ChangeChequeRequisitionStatus(chequeRequestStatusChangeDto, "correction");
                    if (responseString == "") responseString = "Correction request is submitted.";
                    ProgressUIManager.CloseProgress();
                    MsgBox.showInformation(responseString);
                    this.Close();
                }
                catch (Exception exp)
                { ProgressUIManager.CloseProgress(); MsgBox.showError(exp.Message); }
            }
        }

        private void btnComment_Click(object sender, EventArgs e)
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

            if (_chequeRequisitionSearchResultDto != null)
            {
                //if (_chequeRequisitionSearchResultDto != null)
                {
                    //if (_receivePacket.actionType != FormActionType.New)
                    {
                        //if (_termAccountRequestDto.termAccountInformation != null)
                        {
                            if (_comments == null)
                            {
                                _comments = (List<CommentDto>)TermService.GetCommentsID((_chequeRequisitionSearchResultDto.commentId).ToString()).ReturnedObject;
                            }
                        }
                        frmCommentUI frm = new frmCommentUI(packetTmp, _commentDraft, _comments, stageTmp);
                        frm.Top = this.Top + btnComment.Top - frm.Height + 40;
                        frm.Left = btnComment.Left + this.Left + 10;
                        frm.ShowDialog();
                        _commentDraft = frm._commentDraft;
                        CommentText();
                        return;
                    }
                }
            }

            if (_receivePacket.actionType == FormActionType.New)
            {
                frmCommentUI frm = new frmCommentUI(packetTmp, _commentDraft, _comments, stageTmp);
                frm.Top = this.Top + btnComment.Top - frm.Height + 40;
                frm.Left = btnComment.Left + this.Left + 10;
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
                btnComment.BackColor = Color.LightGreen;
            }
            btnComment.Text = "Comment (" + count.ToString() + ")";
        }

        private void btnPrepare_Click(object sender, EventArgs e)
        {
            try
            {
                string result = MsgBox.showConfirmation("Are you sure to prepare this request ?");
                if (result == "yes")
                {
                    ProgressUIManager.ShowProgress(this);
                    string validateMsg = ValidateSerialNumber();
                    if (validateMsg == "")
                    {
                        ChequeRequisitionService chequeRequisitionService = new ChequeRequisitionService();
                        ChequeRequestStatusChangeDto chequeRequestStatusChangeDto = new ChequeRequestStatusChangeDto();
                        if (_commentDraft != null)
                        {
                            _commentDraft.stage = ChequeRequisitionStatus.Prepared.ToString();
                            _commentDraft.id = _chequeRequisitionSearchResultDto.commentId;
                        }

                        chequeRequestStatusChangeDto.chequeRequestInfoId = _chequeRequisitionSearchResultDto.chequeRequisitionInfoId;
                        chequeRequestStatusChangeDto.commentDto = _commentDraft;
                        chequeRequestStatusChangeDto.startingNo = txtSerialFrom.Text.Trim();
                        chequeRequestStatusChangeDto.endingNo = txtSerialTo.Text.Trim();
                        string responseString = chequeRequisitionService.ChangeChequeRequisitionStatus(chequeRequestStatusChangeDto, "prepared");
                        ProgressUIManager.CloseProgress();

                        MsgBox.showInformation(responseString);
                        this.Close();
                    }
                    else
                    {
                        ProgressUIManager.CloseProgress();
                        MsgBox.showError(validateMsg);
                        return;
                    }
                }
            }
            catch (Exception exp)
            { MsgBox.showError(exp.Message); }
        }
        private void NumericText_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox senderText = (TextBox)sender;
            if (!char.IsNumber(e.KeyChar) && (Keys)e.KeyChar != Keys.Back)          // Accept only numbers, delete & BackSpace
            {
                e.Handled = true;
            }
            if ((Keys)e.KeyChar != Keys.Back && senderText.Text.Length >= chequeSerialDigits)        // Because maximum 7 digit is accepted.
            {
                e.Handled = true;
            }
        }
        private void ChequeSerialNo_OnLeave(object sender, EventArgs e)
        {
            TextBox senderText = (TextBox)sender;
            senderText.Text = senderText.Text.PadLeft(chequeSerialDigits, '0');
        }
        private string ValidateSerialNumber()
        {
            if (txtSerialFrom.Text.Trim() == "" || txtSerialTo.Text.Trim() == "")
            { return chequeSerialDigits.ToString() + " digit serial number required."; }
            else
            {
                long startingNo = long.Parse(txtSerialFrom.Text.Trim());
                long endingNo = long.Parse(txtSerialTo.Text.Trim());

                if ((txtSerialFrom.Text.Trim().Length != chequeSerialDigits) || (txtSerialTo.Text.Trim().Length != chequeSerialDigits))
                { return "Serial number should be exactly " + chequeSerialDigits.ToString() + " digits."; }

                else if (startingNo > endingNo) return "Starting serial should not be less than ending serial";
                else return "";
            }
        }
        private void VisibleChequeSerialNo(bool isVisible)
        {
            //if (_chequeRequisitionSearchResultDto.requisitionStatus == ChequeRequisitionStatus.processing) _setChequeSerialNumber();

            //lblSerialNumberFrom.Visible = lblSerialNumberTo.Visible = isVisible;
            //txtSerialFrom.Visible = txtSerialTo.Visible = isVisible;

            //btnPrepare.Visible = isVisible;
            //btnApprove.Visible = btnCorrection.Visible = btnReject.Visible = btnReady.Visible = !isVisible;
        }
        private void _setChequeSerialNumber()
        {
            try
            {
                #region Get last cheque serial number
                ChequeRequisitionService chequeRequisitionService = new ChequeRequisitionService();
                _lastChequeSerial = chequeRequisitionService.GetLastChequeSerial(txtAccountNo.Text.Trim());

                txtSerialFrom.Text = (_lastChequeSerial + 1).ToString().PadLeft(chequeSerialDigits, '0');
                txtSerialTo.Text = (_lastChequeSerial + _chequeRequisitionSearchResultDto.noOfLeaf).ToString().PadLeft(chequeSerialDigits, '0');
                #endregion
            }
            catch (Exception exp)
            { throw; }
        }

        private void btnReady_Click(object sender, EventArgs e)
        {
            try
            {
                string result = MsgBox.showConfirmation("Are you sure to receive this cheque ?");
                if (result == "yes")
                {
                    ProgressUIManager.ShowProgress(this);
                    List<ChequeRequestStatusChangeDto> chequeRequestList = new List<ChequeRequestStatusChangeDto>();
                    ChequeRequisitionService chequeRequisitionService = new ChequeRequisitionService();
                    ChequeRequestStatusChangeDto chequeRequestStatusChangeDto = new ChequeRequestStatusChangeDto();
                    if (_commentDraft != null)
                    {
                        _commentDraft.stage = ChequeRequisitionStatus.Ready.ToString();
                        _commentDraft.id = _chequeRequisitionSearchResultDto.commentId;
                    }

                    chequeRequestStatusChangeDto.chequeRequestInfoId = _chequeRequisitionSearchResultDto.chequeRequisitionInfoId;
                    chequeRequestStatusChangeDto.commentDto = _commentDraft;
                    chequeRequestStatusChangeDto.startingNo = txtSerialFrom.Text.Trim();
                    chequeRequestStatusChangeDto.endingNo = txtSerialTo.Text.Trim();

                    chequeRequestList.Add(chequeRequestStatusChangeDto);
                    string responseString = chequeRequisitionService.SingleReceive(chequeRequestList);
                    ProgressUIManager.CloseProgress();

                    MsgBox.showInformation(responseString);
                    this.Close();
                }
            }
            catch (Exception exp)
            {
                ProgressUIManager.CloseProgress(); 
                MsgBox.showError(exp.Message);
            }
        }

    }
}
