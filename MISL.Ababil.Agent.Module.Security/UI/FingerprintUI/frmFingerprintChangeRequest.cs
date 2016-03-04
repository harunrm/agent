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
using MISL.Ababil.Agent.Module.Security.Service;
using MISL.Ababil.Agent.Module.Security.Models;
using MISL.Ababil.Agent.Module.Common.UI.FingerprintUI;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.fingerprint;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.cis;
using MISL.Ababil.Agent.Module.Common.UI.IndividualInformationUI;

namespace MISL.Ababil.Agent.Module.Security.UI.FingerprintUI
{
    public partial class frmFingerprintChangeRequest : MetroForm
    {
        public frmFingerprintChangeRequest(Packet receivePacket, string accoutNo, string referenceNo, string reqId)
        {
            _receivePacket = receivePacket;
            _reqId = reqId;

            InitializeComponent();

            lblRequiredFingerPrint.Text = "";
            lblConsumerTitle.Text = "";
            lblMobileNo.Text = "";

            ConfigUIEnhancement();
            SetupDataLoad();

            if
                (
                    SessionInfo.userBasicInformation.userType == AgentUserType.Branch
                ||
                    SessionInfo.userBasicInformation.userType == AgentUserType.Admin
                )
            {
                _accoutNo = accoutNo;
                _referenceNumber = referenceNo;
                FillComponentWithObjectValue();
            }

            SetUIByUserRights();
        }


        string _accoutNo = "";
        string _referenceNumber = "";

        GUI _gui = new GUI();
        ConsumerServices _consumerService = new ConsumerServices();
        BioDataChangeReqDto _bioDataChangeReqDto = new BioDataChangeReqDto();
        FingerprintManagementService _fingerprintManagementService = new FingerprintManagementService();

        private string _captureFor;
        private int _captureIndexNo;
        private int _noOfCapturefinger = 0;
        private string _subagentFingerData;
        private Packet _receivePacket;
        private List<BiometricTemplate> _fingerList;
        private string _reqId;

        public List<CommentDto> _comments;
        public CommentDto _commentDraft;

        private void SetUIByUserRights()
        {
            if (
                    SessionInfo.userBasicInformation.userType == AgentUserType.Branch
                ||
                    SessionInfo.userBasicInformation.userType == AgentUserType.Admin
                )
            {
                btnApprove.Visible = true;
                btnApprove.Enabled = true;
                btnReject.Visible = true;
                btnReject.Enabled = true;

                txtConsumerAccount.ReadOnly = true;
                btnClear.Enabled = false;
                btnClear.Visible = false;
            }
            if (SessionInfo.userBasicInformation.userType == AgentUserType.Outlet)
            {
                btnApply.Visible = true;
                btnApply.Enabled = true;

                txtConsumerAccount.ReadOnly = false;
            }
        }

        private void FillComponentWithObjectValue()
        {
            LoadConsumerInfoByUserType(_accoutNo, _referenceNumber);
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
            if (SessionInfo.userBasicInformation.userType == AgentUserType.Outlet)
            {
                LoadConsumerInfoByUserType(txtConsumerAccount.Text, null);
            }
        }

        private void LoadConsumerInfoByUserType(string accountNumber, string referenceNumber)
        {
            if (
                    SessionInfo.userBasicInformation.userType == AgentUserType.Branch
                ||
                    SessionInfo.userBasicInformation.userType == AgentUserType.Admin
                )
            {
                loadConsumerInformation(true, accountNumber, referenceNumber);
            }
            if (
                    SessionInfo.userBasicInformation.userType == AgentUserType.Outlet
                )
            {
                loadConsumerInformation(false, accountNumber, null);
            }
        }

        private void bio_OnCapture_AgreeAndSubmit(object sender, EventArgs e)
        {
            this.Enabled = false;
            AxBIOPLUGINACTXLib.AxBioPlugInActX x = (AxBIOPLUGINACTXLib.AxBioPlugInActX)sender;

            if (x.result == "0")
            {
                _subagentFingerData = bio.GetSafeLeftFingerData();
                if (!string.IsNullOrEmpty(_subagentFingerData))
                {
                    bool fingerprintAvailableForAllflag = true;
                    _bioDataChangeReqDto.outletUserTemplate = _subagentFingerData;
                    if (_bioDataChangeReqDto.bioDataChReqOwnerDtos.Count > 0)
                    {
                        string retVal = "";
                        for (int i = 0; i < _bioDataChangeReqDto.bioDataChReqOwnerDtos.Count; i++)
                        {
                            if (
                                    _bioDataChangeReqDto.bioDataChReqOwnerDtos[i].fingerDatas == null
                                ||
                                    _bioDataChangeReqDto.bioDataChReqOwnerDtos[i].fingerDatas.Count <= 0
                                )
                            {
                                fingerprintAvailableForAllflag = false;
                                break;
                            }
                            else
                            {
                                retVal = fingerPrintGrid.Rows[i].Cells[4].Value.ToString();
                                if (!string.IsNullOrEmpty(retVal))
                                {
                                    _bioDataChangeReqDto.bioDataChReqOwnerDtos[i].reason = retVal;
                                }

                            }
                        }
                        if (
                                (txtConsumerAccount.Text != "")
                            &&
                                (fingerprintAvailableForAllflag == true)
                            )
                        {
                            try
                            {
                                ProgressUIManager.ShowProgress(this);
                                string ServiceResponse = _fingerprintManagementService.UpdateBioDataChangeReqDtoList(_bioDataChangeReqDto);
                                ProgressUIManager.CloseProgress();
                                MsgBox.showInformation(ServiceResponse);
                                ClearUI();
                            }
                            catch (Exception ex)
                            {
                                ProgressUIManager.CloseProgress();
                                btnApply.Enabled = true;
                                MsgBox.showError(ex.Message);
                            }
                        }
                    }
                    if (fingerprintAvailableForAllflag == false)
                    {
                        MsgBox.showError("Required number of Fingerprint is not set!");
                    }
                }
            }
            this.Enabled = true;
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
            long individualId = -1;

            if (
                    SessionInfo.userBasicInformation.userType == AgentUserType.Branch
                ||
                    SessionInfo.userBasicInformation.userType == AgentUserType.Admin
                )
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == fingerPrintGrid.Columns.Count - 3)
                {
                    IndividualServices individualServices = new IndividualServices();
                    individualId = long.Parse
                    (
                        fingerPrintGrid.Rows[e.RowIndex].Cells[1].Value.ToString()
                    );
                    IndividualInformation individualInformation = individualServices.GetIndividualInfo(individualId);

                    Packet packet = new Packet();
                    packet.actionType = FormActionType.View;
                    frmIndividualInformation frm = new frmIndividualInformation(packet, individualInformation);
                    frm.ShowDialog();
                }

                if (e.RowIndex >= 0 && e.ColumnIndex == fingerPrintGrid.Columns.Count - 1)
                {
                    try
                    {
                        BioChangeDto bioChangeDto = new BioChangeDto();
                        bioChangeDto.identity = fingerPrintGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
                        individualId = long.Parse
                        (
                            fingerPrintGrid.Rows[e.RowIndex].Cells[1].Value.ToString()
                        );
                        bioChangeDto.individualId = individualId;

                        ProgressUIManager.ShowProgress(this);
                        _fingerprintManagementService.ResendToken(bioChangeDto);
                        ProgressUIManager.CloseProgress();

                        MsgBox.showInformation("Token is resent successfully.");
                    }
                    catch (Exception ex)
                    {
                        MsgBox.showError(ex.Message);
                    }
                }
            }

            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                frmFingerprintCapture objFrmFinger = new frmFingerprintCapture(lblConsumerTitle.Text);
                DialogResult dr = objFrmFinger.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    _fingerList = objFrmFinger.bioMetricTemplates;
                    _bioDataChangeReqDto.bioDataChReqOwnerDtos[_captureIndexNo].fingerDatas = _fingerList;
                    colorFingerDataRows();
                }
            }
        }

        private void colorFingerDataRows()
        {
            for (int i = 0; i < fingerPrintGrid.Rows.Count; i++)
            {
                if (_bioDataChangeReqDto.bioDataChReqOwnerDtos[_captureIndexNo].fingerDatas.Count > 0)
                {
                    fingerPrintGrid.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                }
            }
        }

        private void loadConsumerInformation(bool showAdminOnlyColumns, string accountNumber, string referenceNumber)
        {
            if (ValidationManager.ValidateNonEmptyTextWithoutSpace(accountNumber))
            {
                try
                {
                    FingerprintManagementService fingerprintManagementService = new FingerprintManagementService();
                    _bioDataChangeReqDto = fingerprintManagementService.GetBioDataChangeReqDtoList(accountNumber, referenceNumber);
                    if (showAdminOnlyColumns == true)
                    {
                        txtConsumerAccount.Text = accountNumber;
                    }
                    lblConsumerTitle.Text = _bioDataChangeReqDto.accountTitle;
                    lblMobileNo.Text = _bioDataChangeReqDto.mobileNumber;

                    if (_bioDataChangeReqDto.image != null)
                    {
                        Image image;
                        image = UtilityServices.byteArrayToImage(_bioDataChangeReqDto.image);
                        pic_conusmer.Image = image;
                    }

                    //Clearing the Grid
                    {
                        fingerPrintGrid.DataSource = null;
                        fingerPrintGrid.Columns.Clear();
                    }

                    //New Capture - Button
                    {
                        if (showAdminOnlyColumns == false)
                        {
                            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                            buttonColumn.Text = "New Capture";
                            buttonColumn.UseColumnTextForButtonValue = true;
                            fingerPrintGrid.Columns.Add(buttonColumn);
                        }
                    }

                    if (_bioDataChangeReqDto.bioDataChReqOwnerDtos != null)
                    {
                        fingerPrintGrid.DataSource = _bioDataChangeReqDto.bioDataChReqOwnerDtos.Select(o => new BioDataChReqOwnerDtoGrid(o) { Identity = o.identity, Individual_ID = o.individualId.ToString(), Identity_Name = o.individualName, Reason = o.reason }).ToList();
                    }

                    for (int i = 0; i < fingerPrintGrid.Columns.Count; i++)
                    {
                        fingerPrintGrid.Columns[i].ReadOnly = true;
                    }

                    //Individual Info - Button
                    {
                        if (showAdminOnlyColumns == true)
                        {
                            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                            buttonColumn.Text = "Info...";
                            buttonColumn.UseColumnTextForButtonValue = true;
                            fingerPrintGrid.Columns.Add(buttonColumn);
                        }
                    }

                    //Token - Cell TextBox
                    {
                        if (showAdminOnlyColumns == true)
                        {
                            DataGridViewTextBoxColumn textBoxColumn = new DataGridViewTextBoxColumn();
                            textBoxColumn.HeaderText = "Token";
                            textBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                            fingerPrintGrid.Columns.Add(textBoxColumn);
                        }
                    }

                    //Token Resend Button - Button
                    {
                        if (showAdminOnlyColumns == true)
                        {
                            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                            buttonColumn.Text = "Resend";
                            buttonColumn.UseColumnTextForButtonValue = true;
                            fingerPrintGrid.Columns.Add(buttonColumn);
                        }
                    }

                    if (showAdminOnlyColumns == true)
                    {
                        fingerPrintGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        fingerPrintGrid.Columns[0].Visible = false;
                        lblRequiredFingerPrint.Visible = false;
                    }
                    else
                    {
                        fingerPrintGrid.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        fingerPrintGrid.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        fingerPrintGrid.Columns[1].Visible = false;
                        fingerPrintGrid.Columns[4].ReadOnly = false;
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

        public class BioDataChReqOwnerDtoGrid
        {
            public string Identity { get; set; }

            public string Individual_ID { get; set; }
            public string Identity_Name { get; set; }

            public string Reason { get; set; }

            private BioDataChReqOwnerDto _obj;

            public BioDataChReqOwnerDtoGrid(BioDataChReqOwnerDto obj)
            {
                _obj = obj;
            }

            public BioDataChReqOwnerDto GetModel()
            {
                return _obj;
            }
        }

        private void ClearUI()
        {
            _commentDraft = null;
            _comments = null;

            txtConsumerAccount.Enabled = true;
            txtConsumerAccount.Text = "";
            pic_conusmer.Image = null;
            fingerPrintGrid.DataSource = null;
            lblConsumerTitle.Text = "";
            lblMobileNo.Text = "";
            lblRequiredFingerPrint.Text = "";
            _noOfCapturefinger = 0;

            _gui.SetControlState
            (
                GUI.CONTROLSTATES.CS_READWRITE,
                new Control[]
                {
                    txtConsumerAccount,
                }
            );
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            if (MsgBox.showConfirmation("Are you sure to clear?") == "yes")
            {
                ClearUI();
            }
        }

        private void frmChequeRequisition_Load(object sender, EventArgs e)
        {

        }

        private void frmChequeRequisition_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner = null;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (CheckForValidationFromOutlet(false))
            {
                bio.CaptureFingerData();
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckForValidationFromBranch(false))
                {
                    FillDto();
                    ProgressUIManager.ShowProgress(this);
                    string retVal = _fingerprintManagementService.SubmitTokens(_bioDataChangeReqDto);
                    ProgressUIManager.CloseProgress();
                    MsgBox.showInformation("Fingerprint updated successfully.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ProgressUIManager.CloseProgress();
                MsgBox.showError(ex.Message);
            }

        }

        private bool CheckForValidationFromBranch(bool suppressed)
        {
            bool flag = true;
            for (int i = 0; i < fingerPrintGrid.Rows.Count; i++)
            {
                object value = fingerPrintGrid.Rows[i].Cells[fingerPrintGrid.Columns.Count - 1].Value;
                if (
                        (value == null)
                    ||
                        (string.IsNullOrEmpty(value.ToString()))
                    )
                {
                    flag = false;
                }
            }
            if (flag == false)
            {
                if (!suppressed)
                {
                    MsgBox.showError("Token not found!");
                }
                return false;
            }
            return true;
        }

        private bool CheckForValidationFromOutlet(bool suppressed)
        {
            if (string.IsNullOrEmpty(txtConsumerAccount.Text))
            {
                if (!suppressed)
                {
                    MsgBox.showError("Account number not found!");
                }
                return false;
            }

            bool flag = true;
            for (int i = 0; i < fingerPrintGrid.Rows.Count; i++)
            {
                if (fingerPrintGrid.Rows[i].Cells[4].Value == null || string.IsNullOrEmpty(fingerPrintGrid.Rows[i].Cells[4].Value.ToString()))
                {
                    flag = false;
                }
            }
            if (flag == false)
            {
                if (!suppressed)
                {
                    MsgBox.showError("Reason not found!");
                }
                return false;
            }
            return true;
        }

        private void FillDto()
        {
            for (int i = 0; i < fingerPrintGrid.Rows.Count; i++)
            {
                _bioDataChangeReqDto.bioDataChReqOwnerDtos[i].token = fingerPrintGrid.Rows[i].Cells[fingerPrintGrid.Columns.Count - 2].Value.ToString();
            }
            _bioDataChangeReqDto.referanceNumber = _referenceNumber;
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                if (MsgBox.showConfirmation("Do you want to reject this request?") == "yes")
                {
                    ProgressUIManager.ShowProgress(this);
                    string retVal = _fingerprintManagementService.Reject(_reqId);
                    ProgressUIManager.CloseProgress();
                    MsgBox.showInformation("Fingerprint update request is rejected.");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MsgBox.showError(ex.Message);
                ProgressUIManager.CloseProgress();
            }
        }
    }
}