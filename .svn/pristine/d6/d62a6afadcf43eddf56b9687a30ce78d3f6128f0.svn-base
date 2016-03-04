using MetroFramework.Forms;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using MISL.Ababil.Agent.LocalStorageService;
using MISL.Ababil.Agent.Module.Common.Model;
using MISL.Ababil.Agent.Module.Common.UI.MessageUI;
using MISL.Ababil.Agent.Module.Security.Models;
using MISL.Ababil.Agent.Module.Security.Service;
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

namespace MISL.Ababil.Agent.Module.Security.UI.FingerprintUI
{
    public partial class frmFingerprintAdmin : MetroForm
    {
        public frmFingerprintAdmin()
        {
            InitializeComponent();
            SetupComponent();
        }

        private void SetupComponent()
        {
            //List of agents
            {
                AgentServices agentServices = new AgentServices();
                List<AgentInformation> agentInfoList = agentServices.getAgentInfoBranchWise();
                BindingSource bs = new BindingSource();
                bs.DataSource = agentInfoList;

                AgentInformation agSelect = new AgentInformation();
                agSelect.businessName = "(Select)";
                agentInfoList.Insert(0, agSelect);
                AgentInformation agAll = new AgentInformation();
                agAll.businessName = "(All)";
                agentInfoList.Insert(1, agAll);

                UtilityServices.fillComboBox(cmbAgentName, bs, "businessName", "id");
                cmbAgentName.Text = "Select";
                cmbAgentName.SelectedIndex = 0;
            }

            //List of outlets
            {
                AgentServices agentServices = new AgentServices();
                SubAgentServices subAgentServices = new SubAgentServices();
                BindingSource bs = new BindingSource();
                List<SubAgentInformation> subAgentInformationList = subAgentServices.GetAllSubAgents();
                //List<SubAgentInformation> subAgentInformationList = agentServices.GetSubagentsByAgentId(((AgentInformation)cmbAgentName.SelectedValue).id);


                List<SubagentList> subAgentList = subAgentInformationList.Select(o => new SubagentList()
                {
                    id = o.id,
                    name = o.name,
                    subAgentCode = o.subAgentCode,
                    subAgentNameWithCode = o.name + "  [" + o.subAgentCode + "]"
                }).ToList();

                SubagentList sagSelect = new SubagentList();
                sagSelect.subAgentNameWithCode = "(Select)";
                subAgentList.Insert(0, sagSelect);
                SubagentList sagAll = new SubagentList();
                sagAll.subAgentNameWithCode = "(All)";
                subAgentList.Insert(1, sagAll);

                bs.DataSource = subAgentList;
                UtilityServices.fillComboBox(cmbOutlet, bs, "subAgentNameWithCode", "id");
            }
        }

        //ChequeRequisitionService _chequeRequisitionService = new ChequeRequisitionService();
        //public List<ChequeRequisitionSearchResultDto> _ChequeRequestSearchResultList;
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
            try
            {

                dgvResult.DataSource = null;
                dgvResult.Rows.Clear();
                dgvResult.Columns.Clear();
                FingerprintManagementService _fingerprintManagementService = new FingerprintManagementService();
                BioDataChangeReqSearchDto bioDataChangeReqSearchDto = new BioDataChangeReqSearchDto();

                //TODO: Fill when service is ready for parameters
                {
                    bioDataChangeReqSearchDto.agentId = (long)cmbAgentName.SelectedValue;
                    bioDataChangeReqSearchDto.outlateId = (long)cmbOutlet.SelectedValue;
                    bioDataChangeReqSearchDto.accountNumber = txtAccountNo.Text;
                    bioDataChangeReqSearchDto.referanceNumber = txtReferenceNumber.Text;
                    bioDataChangeReqSearchDto.mobileNumber = txtMobileNo.Text;
                }

                ProgressUIManager.ShowProgress(this);
                List<BioDataChangeReqSearchResultDto> bioDataChangeReqSearchResultDtoList = _fingerprintManagementService.GetBioDataChangeReqSearchDtoList(bioDataChangeReqSearchDto);
                ProgressUIManager.CloseProgress();

                dgvResult.DataSource = bioDataChangeReqSearchResultDtoList.Select(o => new BioDataChangeReqSearchResultDtoGrid(o)
                {
                    requestId = o.requestId,
                    refrenceNumber = o.refrenceNumber,
                    agentName = o.agentName,
                    subAgentName = o.subAgentName,
                    accountNumber = o.accountNumber,
                    accountTitle = o.accountTitle,
                    mobileNumber = o.mobileNumber
                }).ToList();

                //Open Button
                {
                    DataGridViewButtonColumn dgvButtonColumn = new DataGridViewButtonColumn();
                    dgvButtonColumn.HeaderText = "";
                    dgvButtonColumn.Text = "Open";
                    dgvButtonColumn.UseColumnTextForButtonValue = true;
                    dgvResult.Columns.Add(dgvButtonColumn);
                }

                //lblItemsFound.Text = "Item(s) Found: " + dgvRemittance.Rows.Count.ToString();

            }
            catch (Exception ex)
            {
                MsgBox.showError(ex.Message);
                ProgressUIManager.CloseProgress();
            }

            this.Enabled = true;
            this.UseWaitCursor = false;
        }

        private void dgvResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvResult.Rows[e.RowIndex].Cells[dgvResult.Columns.Count - 1].Value.ToString() == "Open")
                {
                    Packet packet = new Packet();
                    packet.actionType = FormActionType.View;
                    string accNum = dgvResult.Rows[e.RowIndex].Cells[4].Value.ToString();
                    string refNum = dgvResult.Rows[e.RowIndex].Cells[1].Value.ToString();
                    string reqId = dgvResult.Rows[e.RowIndex].Cells[0].Value.ToString();
                    frmFingerprintChangeRequest frm = new frmFingerprintChangeRequest(packet, accNum, refNum, reqId);
                    frm.ShowDialog(this);
                    Search();
                }
            }
            catch { }
        }

        private void cbxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (
                    SessionInfo.userBasicInformation.userType == AgentUserType.Branch
                ||
                    SessionInfo.userBasicInformation.userType == AgentUserType.Admin
                )
            {

            }

            if (SessionInfo.userBasicInformation.userType == AgentUserType.Outlet)
            {

            }
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                txtAccountNo.Text = "";
                txtMobileNo.Text = "";
                txtReferenceNumber.Text = "";
                cmbAgentName.SelectedIndex = 0;
                cmbOutlet.SelectedIndex = 0;

                dgvResult.DataSource = null;
                dgvResult.Rows.Clear();
            }
            catch
            {
                //suppressed
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {

        }

        private void btnReceive_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private class BioDataChangeReqSearchResultDtoGrid
        {
            public long requestId { get; set; }
            public string refrenceNumber { get; set; }
            public string agentName { get; set; }
            public string subAgentName { get; set; }
            public string accountNumber { get; set; }
            public string accountTitle { get; set; }
            public string mobileNumber { get; set; }

            private BioDataChangeReqSearchResultDto _obj;

            public BioDataChangeReqSearchResultDtoGrid(BioDataChangeReqSearchResultDto obj)
            {
                _obj = obj;
            }

            public BioDataChangeReqSearchResultDto GetModel()
            {
                return _obj;
            }
        }

        private void cmbAgentName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //List of outlets
            {
                if (cmbAgentName.SelectedIndex > 1)
                {
                    AgentServices agentServices = new AgentServices();
                    SubAgentServices subAgentServices = new SubAgentServices();
                    BindingSource bs = new BindingSource();
                    //List<SubAgentInformation> subAgentInformationList = subAgentServices.GetAllSubAgents();
                    List<SubAgentInformation> subAgentInformationList = agentServices.GetSubagentsByAgentId((long)cmbAgentName.SelectedValue);


                    List<SubagentList> subAgentList = subAgentInformationList.Select(o => new SubagentList()
                    {
                        id = o.id,
                        name = o.name,
                        subAgentCode = o.subAgentCode,
                        subAgentNameWithCode = o.name + "  [" + o.subAgentCode + "]"
                    }).ToList();

                    SubagentList sagSelect = new SubagentList();
                    sagSelect.subAgentNameWithCode = "(Select)";
                    subAgentList.Insert(0, sagSelect);
                    SubagentList sagAll = new SubagentList();
                    sagAll.subAgentNameWithCode = "(All)";
                    subAgentList.Insert(1, sagAll);

                    bs.DataSource = subAgentList;
                    UtilityServices.fillComboBox(cmbOutlet, bs, "subAgentNameWithCode", "id");
                }
                else
                {
                    AgentServices agentServices = new AgentServices();
                    SubAgentServices subAgentServices = new SubAgentServices();
                    BindingSource bs = new BindingSource();
                    List<SubAgentInformation> subAgentInformationList = subAgentServices.GetAllSubAgents();
                    //List<SubAgentInformation> subAgentInformationList = agentServices.GetSubagentsByAgentId((long)cmbAgentName.SelectedValue);


                    List<SubagentList> subAgentList = subAgentInformationList.Select(o => new SubagentList()
                    {
                        id = o.id,
                        name = o.name,
                        subAgentCode = o.subAgentCode,
                        subAgentNameWithCode = o.name + "  [" + o.subAgentCode + "]"
                    }).ToList();

                    SubagentList sagSelect = new SubagentList();
                    sagSelect.subAgentNameWithCode = "(Select)";
                    subAgentList.Insert(0, sagSelect);
                    SubagentList sagAll = new SubagentList();
                    sagAll.subAgentNameWithCode = "(All)";
                    subAgentList.Insert(1, sagAll);

                    bs.DataSource = subAgentList;
                    UtilityServices.fillComboBox(cmbOutlet, bs, "subAgentNameWithCode", "id");
                }
            }
        }
    }
}