using MetroFramework.Forms;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using MISL.Ababil.Agent.Module.ChequeRequisition.Models;
using MISL.Ababil.Agent.Module.ChequeRequisition.Service;
using MISL.Ababil.Agent.Module.Common.Model;
using MISL.Ababil.Agent.Module.Common.UI.MessageUI;
using MISL.Ababil.Agent.Services;
using MISL.Ababil.Agent.UI.forms.ProgressUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MISL.Ababil.Agent.Module.Common.Model;

namespace MISL.Ababil.Agent.Module.ChequeRequisition.UI
{
    public partial class frmChequeRequisitionSearch : MetroForm
    {
        public frmChequeRequisitionSearch()
        {
            InitializeComponent();
            SetupComponent();
        }

        private void SetupComponent()
        {
            if (
                SessionInfo.userBasicInformation.userType == AgentUserType.Branch
                ||
                SessionInfo.userBasicInformation.userType == AgentUserType.Admin
                )
            {
                btnAccept.Visible = true;
            }

            if (SessionInfo.userBasicInformation.userType == AgentUserType.Outlet)
            {
                //cmbOutlet.SelectedValue = SessionInfo.userBasicInformation.outlet.id;
                cmbOutlet.Enabled = false;
                btnReceive.Visible = true;
                panelOutlet.Visible = false;
            }
            else
            {
                LoadAllOutlet();
            }

            LoadAllStatus();
        }

        private void LoadAllOutlet()
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
            SubagentList subAgentAll = new SubagentList();
            subAgentAll.id = 0;
            subAgentAll.subAgentNameWithCode = "All";
            _subAgentList.Insert(0, subAgentAll);

            BindingSource bs = new BindingSource();
            bs.DataSource = _subAgentList; // subAgentInformationList;
            //UtilityServices.fillComboBox(cmbOutlet, bs, "name", "id");
            UtilityServices.fillComboBox(cmbOutlet, bs, "subAgentNameWithCode", "id");
            cmbOutlet.SelectedIndex = 0;
        }

        private void LoadAllStatus()
        {
            //cmbStatus.DataSource = GetChequeRequisitionStatusList();
            //cmbStatus.SelectedIndex = -1;

            List<ChequeRequisitionStatusList> statusList = Enum.GetValues(typeof(ChequeRequisitionStatus)).Cast<ChequeRequisitionStatus>()
                                                                                                            .Select(o => new ChequeRequisitionStatusList
                                                                                                            {
                                                                                                                ChequeRequisitionStatus = o.ToString(),
                                                                                                            }).ToList();
            ChequeRequisitionStatusList allStatus = new ChequeRequisitionStatusList();
            BindingSource bs = new BindingSource();
            allStatus.ChequeRequisitionStatus = "All";
            statusList.Insert(0, allStatus);
            bs.DataSource = statusList;
            UtilityServices.fillComboBox(cmbStatus, bs, "ChequeRequisitionStatus", "ChequeRequisitionStatus");
        }

        public Array GetChequeRequisitionStatusList()
        {
            return Enum.GetValues(typeof(ChequeRequisitionStatus));
        }

        ChequeRequisitionService _chequeRequisitionService = new ChequeRequisitionService();
        public List<ChequeRequisitionSearchResultDto> _ChequeRequestSearchResultList;
        private bool _filling;

        private void frmChequeRequisitionSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner = null;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            btnAccept.Enabled = btnReceive.Enabled = false;

            dgvResult.DataSource = null;
            dgvResult.Rows.Clear();
            dgvResult.Columns.Clear();
            ChequeRequestSearchDto chequeRequestSearchDto = new ChequeRequestSearchDto();

            if (SessionInfo.userBasicInformation.userType != AgentUserType.Outlet)
            {
                //if (cmbOutlet.SelectedValue != null) chequeRequestSearchDto.outlateId = (long)cmbOutlet.SelectedValue;
                chequeRequestSearchDto.outlateId = (long)cmbOutlet.SelectedValue;
            }
            else chequeRequestSearchDto.outlateId = SessionInfo.userBasicInformation.outlet.id;

            chequeRequestSearchDto.refNo = txtReferenceNumber.Text.Trim();
            chequeRequestSearchDto.accountNumber = txtAccountNo.Text.Trim();
            chequeRequestSearchDto.fromDate = UtilityServices.GetLongDate(dtpFrom.Value);
            chequeRequestSearchDto.toDate = UtilityServices.GetLongDate(dtpTo.Value);

            //if (cmbStatus.SelectedValue != null) chequeRequestSearchDto.requisitionStatus = (ChequeRequisitionStatus)cmbStatus.SelectedValue.ToString();
            //else chequeRequestSearchDto.requisitionStatus = null;
            if (cmbStatus.SelectedValue == "All") chequeRequestSearchDto.requisitionStatus = null;
            else chequeRequestSearchDto.requisitionStatus = (ChequeRequisitionStatus)Enum.Parse(typeof(ChequeRequisitionStatus), cmbStatus.SelectedValue.ToString());

            try
            {
                  ProgressUIManager.ShowProgress(this);
                _ChequeRequestSearchResultList = _chequeRequisitionService.GetChequeRequisitionList(chequeRequestSearchDto);
                 ProgressUIManager.CloseProgress();

                if (_ChequeRequestSearchResultList != null)
                {
                    dgvResult.DataSource = null;
                    //dgvRemittance.DataSource = remittances.Select(o => new RemittanceGrid(o) { id = o.id, district = o.benificaryAddress.district.title, exchangeHouse = o.exchangeHouse.companyName, outlet = getOutletName(o.voucherNumber), benificaryName = o.benificaryName, benificarynid = o.benificarynid, senderName = o.senderName, pinCode = o.pinCode, referenceNumber = o.referanceNumber, remittanceStatus = o.remittanceStatus, entryUser = o.entryUser, entryUserDateTime = o.entryUserDateTime, firstApprover = o.firstApprover, firstApprovalDateTime = o.firstApprovalDateTime, secondApprover = o.secondApprover, secondApprovalDateTime = o.secondApprovalDateTime, comments = o.comments }).ToList();
                    //dgvRemittance.DataSource = remittances.Select(o => new RemittanceGrid(o) { id = o.id, district = o.benificaryAddress.district.title, exchangeHouse = o.exchangeHouse.companyName,  benificaryName = o.benificaryName, benificarynid = o.benificarynid, senderName = o.senderName, pinCode = o.pinCode, referenceNumber = o.referanceNumber, remittanceStatus = o.remittanceStatus, entryUser = o.entryUser, entryUserDateTime = o.entryUserDateTime, firstApprover = o.firstApprover, firstApprovalDateTime = o.firstApprovalDateTime, secondApprover = o.secondApprover, secondApprovalDateTime = o.secondApprovalDateTime, comments = o.comments }).ToList();
                    dgvResult.DataSource = _ChequeRequestSearchResultList.Select(o => new ChequeRequestSearchResultGrid(o)
                    {
                        requestOutletName = o.requestOutletName,
                        deliveryOutletName = o.deliveryOutletName,
                        refNumber = o.refNumber,
                        submiteDate = UtilityServices.getBDFormattedDateFromLong(o.submiteDate),
                        accTitle = o.accTitle,
                        accNumber = o.accNumber,
                        noOfLeaf = o.noOfLeaf,
                        urgencyType = o.urgencyType,
                        Status = (o.requisitionStatus).ToString()
                    }).ToList();

                    for (int i = 0; i < dgvResult.Columns.Count; i++)
                    {
                        dgvResult.Columns[i].ReadOnly = true;
                    }

                    //View Button
                    {
                        DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                        buttonColumn.Text = "View";
                        buttonColumn.UseColumnTextForButtonValue = true;
                        buttonColumn.ReadOnly = false;
                        dgvResult.Columns.Add(buttonColumn);
                    }
                    //CheckBox
                    {
                        dgvResult.Columns[0].HeaderText = "";
                        dgvResult.Columns[0].Width = 40;
                        _filling = true;
                        cbxSelectAll.Checked = false;
                        _filling = false;
                        dgvResult.Columns[0].ReadOnly = true;
                    }

                    if (cmbStatus.SelectedValue != null)
                    {
                        if (cmbStatus.SelectedValue.ToString() != ChequeRequisitionStatus.Submitted.ToString()) btnAccept.Enabled = false;
                        else if (cmbStatus.SelectedValue.ToString() != ChequeRequisitionStatus.Prepared.ToString()) btnReceive.Enabled = false;
                    }

                    #region Format Grid Headers
                    dgvResult.Columns[1].HeaderText = "Request From";
                    dgvResult.Columns[2].HeaderText = "Delivery From";
                    dgvResult.Columns[3].HeaderText = "Acc. No.";
                    dgvResult.Columns[4].HeaderText = "Acc. Title";
                    dgvResult.Columns[5].HeaderText = "No. of Leaf";
                    dgvResult.Columns[6].HeaderText = "Urgency Type";
                    dgvResult.Columns[7].HeaderText = "Submit Date";
                    dgvResult.Columns[8].HeaderText = "Ref. No.";
                    dgvResult.Columns[9].HeaderText = "Status";
                    #endregion
                }
                else
                {
                    ProgressUIManager.CloseProgress();
                    btnSearch.Enabled = true;
                    MsgBox.showInformation("No applications available");
                }
            }
            catch (Exception ex)
            {
                ProgressUIManager.CloseProgress();
                btnSearch.Enabled = true;
                MsgBox.showError(ex.Message);
            }

            //lblItemsFound.Text = "Item(s) Found: " + dgvRemittance.Rows.Count.ToString();
            this.Enabled = true;
            this.UseWaitCursor = false;
        }

        private void dgvResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgvResult.Rows[e.RowIndex].Cells[dgvResult.Columns.Count - 1].Value.ToString() == "View")
            try
            {
                //if (dgvResult.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "View")
                if (e.ColumnIndex == 0)
                {
                    dgvResult.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !(bool)dgvResult.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    if (
                           SessionInfo.userBasicInformation.userType == AgentUserType.Branch
                        ||
                           SessionInfo.userBasicInformation.userType == AgentUserType.Admin
                       )
                    {
                        SetSelectedCellForBranch();
                    }

                    if (SessionInfo.userBasicInformation.userType == AgentUserType.Outlet)
                    {
                        SetSelectedCellForOutlet();
                    }
                }
                if (dgvResult.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "View")
                {
                    Packet packet = new Packet();

                    if (
                            SessionInfo.userBasicInformation.userType == AgentUserType.Branch
                        ||
                            SessionInfo.userBasicInformation.userType == AgentUserType.Admin
                        )
                    {
                        packet.actionType = FormActionType.View;
                        frmChequeRequisition frm = new frmChequeRequisition(packet, _ChequeRequestSearchResultList[e.RowIndex]);
                        frm.ShowDialog(this);
                    }
                    if (
                            SessionInfo.userBasicInformation.userType == AgentUserType.Outlet
                        )
                    {
                        if (_ChequeRequestSearchResultList[e.RowIndex].requisitionStatus == ChequeRequisitionStatus.Correction)
                        {
                            packet.actionType = FormActionType.Edit;
                        }
                        else
                        {
                            packet.actionType = FormActionType.View;
                        }

                        if (_ChequeRequestSearchResultList[e.RowIndex].requisitionStatus != ChequeRequisitionStatus.Prepared)
                        {
                            frmChequeRequisitionRequest frm = new frmChequeRequisitionRequest(packet, _ChequeRequestSearchResultList[e.RowIndex]);
                            frm.ShowDialog(this);
                        }
                        else
                        {
                            frmChequeRequisition frm = new frmChequeRequisition(packet, _ChequeRequestSearchResultList[e.RowIndex]);
                            frm.ShowDialog(this);
                        }
                    }

                    Search();
                }
            }
            catch { }
        }

        private void cbxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (!_filling)
            {
                for (int i = 0; i < dgvResult.Rows.Count; i++)
                {
                    dgvResult.Rows[i].Cells[0].Value = cbxSelectAll.Checked;
                }
            }

            if (
                    SessionInfo.userBasicInformation.userType == AgentUserType.Branch
                ||
                    SessionInfo.userBasicInformation.userType == AgentUserType.Admin
                )
            {
                SetSelectedCellForBranch();
            }

            if (SessionInfo.userBasicInformation.userType == AgentUserType.Outlet)
            {
                SetSelectedCellForOutlet();
            }
        }

        private void SetSelectedCellForBranch()
        {
            btnAccept.Enabled = false;

            bool flagAllSubmitted = true;
            int totalChecked = 0;
            for (int i = 0; i < dgvResult.Rows.Count; i++)
            {
                if (
                        _ChequeRequestSearchResultList[i].requisitionStatus != ChequeRequisitionStatus.Submitted
                    &&
                        ((bool)dgvResult.Rows[i].Cells[0].Value == true)
                    )
                {
                    flagAllSubmitted = false;
                }

                if (
                        _ChequeRequestSearchResultList[i].requisitionStatus == ChequeRequisitionStatus.Submitted
                    &&
                        ((bool)dgvResult.Rows[i].Cells[0].Value == true)
                    )
                {
                    totalChecked++;
                }

            }
            if ((flagAllSubmitted == true) && (totalChecked > 0))
            {
                btnAccept.Enabled = true;
            }
            else
            {
                btnAccept.Enabled = false;
            }
        }

        private void SetSelectedCellForOutlet()
        {
            btnReceive.Enabled = false;

            bool flagAllSubmitted = true;
            int totalChecked = 0;
            for (int i = 0; i < dgvResult.Rows.Count; i++)
            {
                if (
                        _ChequeRequestSearchResultList[i].requisitionStatus != ChequeRequisitionStatus.Prepared
                    &&
                        (_ChequeRequestSearchResultList[i].deliveryFrom != SessionInfo.userBasicInformation.outlet.id)
                    &&
                        ((bool)dgvResult.Rows[i].Cells[0].Value == true)
                    )
                {
                    flagAllSubmitted = false;
                }

                if (
                        _ChequeRequestSearchResultList[i].requisitionStatus == ChequeRequisitionStatus.Prepared
                    &&
                        (_ChequeRequestSearchResultList[i].deliveryFrom == SessionInfo.userBasicInformation.outlet.id)
                    &&
                        ((bool)dgvResult.Rows[i].Cells[0].Value == true)
                    )
                {
                    totalChecked++;
                }

            }
            if ((flagAllSubmitted == true) && (totalChecked > 0))
            {
                btnReceive.Enabled = true;
            }
            else
            {
                btnReceive.Enabled = false;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearUI();
        }
        private void ClearUI()
        {
            List<ChequeRequestSearchResultGrid> _emptyList = new List<ChequeRequestSearchResultGrid>();
            dgvResult.DataSource = null;
            dgvResult.Refresh();

            txtAccountNo.Text = txtReferenceNumber.Text = "";
            dtpFrom.Value = dtpTo.Value = SessionInfo.currentDate;
            cmbOutlet.SelectedIndex = -1;
            cmbStatus.SelectedIndex = 0;
            cbxSelectAll.Checked = false;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                ProgressUIManager.ShowProgress(this);
                List<ChequeRequisitionSearchResultDto> chequeRequisitionSearchResultDtoList = GetSelectedChequeRequisitionSearchResultDto();
                List<ChequeRequestStatusChangeDto> ChequeRequestStatusChangeDtoList = _chequeRequisitionService.ConvertChequeRequisitionSearchResultDtoListToChequeRequestStatusChangeDtoList(chequeRequisitionSearchResultDtoList);
                string result = _chequeRequisitionService.BulkAccept(ChequeRequestStatusChangeDtoList);
                if (result != "")
                {
                    ProgressUIManager.CloseProgress();
                    MsgBox.showInformation(result);
                    Search();
                }
                else
                { ProgressUIManager.CloseProgress(); MsgBox.showWarning("Server Error !"); }
            }
            catch (Exception exp)
            { ProgressUIManager.CloseProgress(); MsgBox.showError(exp.Message); }
        }

        private List<ChequeRequisitionSearchResultDto> GetSelectedChequeRequisitionSearchResultDto()
        {
            List<ChequeRequisitionSearchResultDto> ChequeRequisitionSearchResultDtoList = new List<ChequeRequisitionSearchResultDto>();
            if (_ChequeRequestSearchResultList.Count == dgvResult.Rows.Count)
            {
                for (int i = 0; i < dgvResult.Rows.Count; i++)
                {
                    if ((bool)dgvResult.Rows[i].Cells[0].Value == true)
                    {
                        ChequeRequisitionSearchResultDto chequeRequisitionSearchResultDtoTmp = _ChequeRequestSearchResultList[i];
                        ChequeRequisitionSearchResultDtoList.Add(chequeRequisitionSearchResultDtoTmp);
                    }
                }
            }
            return ChequeRequisitionSearchResultDtoList;
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            try
            {
                ProgressUIManager.ShowProgress(this);
                List<ChequeRequisitionSearchResultDto> chequeRequisitionSearchResultDtoList = GetSelectedChequeRequisitionSearchResultDto();
                List<ChequeRequestStatusChangeDto> ChequeRequestStatusChangeDtoList = _chequeRequisitionService.ConvertChequeRequisitionSearchResultDtoListToChequeRequestStatusChangeDtoList(chequeRequisitionSearchResultDtoList);
                string result = _chequeRequisitionService.BulkReceive(ChequeRequestStatusChangeDtoList);
                if (result != "")
                {
                    ProgressUIManager.CloseProgress();
                    MsgBox.showInformation(result);
                    Search();
                }
                else
                { ProgressUIManager.CloseProgress(); MsgBox.showWarning("Server Error !"); }
            }
            catch (Exception exp)
            { ProgressUIManager.CloseProgress(); MsgBox.showError(exp.Message); }
        }
    }

    internal class ChequeRequestSearchResultGrid
    {
        public bool selected { get; set; }
        public string requestOutletName { get; set; }
        public string deliveryOutletName { get; set; }
        public string accNumber { get; set; }
        public string accTitle { get; set; }
        public int noOfLeaf { get; set; }
        public UrgencyType urgencyType { get; set; }
        public string submiteDate { get; set; }
        public string refNumber { get; set; }
        public string Status { get; set; }

        private ChequeRequisitionSearchResultDto o;

        public ChequeRequestSearchResultGrid(ChequeRequisitionSearchResultDto o)
        {
            this.o = o;
        }
    }

    internal class ChequeRequisitionStatusList
    {
        public string ChequeRequisitionStatus { get; set; }
    }
}