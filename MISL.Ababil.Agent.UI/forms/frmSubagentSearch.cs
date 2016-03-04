using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using MISL.Ababil.Agent.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmSubagentSearch : Form
    {
        List<AgentInformation> objAgentInfoList = new List<AgentInformation>();
        List<SubAgentInformation> subAgentInformationList;
        AgentServices objAgentServices = new AgentServices();
        public frmSubagentSearch()
        {
            InitializeComponent();
            InitializeSetupData();
        }
        private void InitializeSetupData()
        {
            txtMobileNo.MaxLength = CommonRules.mobileNoLength;
            try
            {
                objAgentInfoList = objAgentServices.getAgentInfoBranchWise();
                BindingSource bs = new BindingSource();
                bs.DataSource = objAgentInfoList;
                UtilityServices.fillComboBox(cmbAgentName, bs, "businessName", "id");
                cmbAgentName.Text = "Select";
            }
            catch (Exception ex)
            {
                Message.showError(ex.Message);
            }
        }



        private void btnSearch_Click(object sender, EventArgs e)
        {
            showSubagents();
        }
        private void showSubagents()
        {
            AgentInformation agentInfo = null;
            int agentId = Convert.ToInt32(cmbAgentName.SelectedValue);
            try
            {
                agentInfo = objAgentServices.getAgentInfoById(agentId.ToString());
                if (agentInfo.subAgents != null)
                {
                    if (agentInfo.subAgents.Count > 0)
                    {
                        if (dgvSubAgent.Columns.Count == 0)
                        {
                            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                            buttonColumn.Text = "View";
                            buttonColumn.UseColumnTextForButtonValue = true;
                            dgvSubAgent.Columns.Add(buttonColumn);
                        }
                        subAgentInformationList = agentInfo.subAgents;
                        dgvSubAgent.DataSource = subAgentInformationList.Select(o => new SubAgentInformationGrid(o) { id = o.id, name = o.name, subAgentCode = o.subAgentCode, businessAddress = o.businessAddress, mobleNumber = o.mobleNumber, phoneNumber = o.phoneNumber }).ToList();
                    }
                }
                lblItemCount.Text = agentInfo.subAgents.Count.ToString();
            }
            catch (Exception ex)
            {
                Message.showError(ex.Message);
            }
        }

        private void dgvSubAgent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSubAgent.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "View")
            {
                if (dgvSubAgent.RowCount > 0)
                {
                    SubAgentInformation subAgentInformation = subAgentInformationList[e.RowIndex]; ;

                    if (subAgentInformation != null)
                    {
                        SubAgentServices services = new SubAgentServices();
                        try
                        {
                            subAgentInformation = services.getSubAgentInfoById(subAgentInformation.id.ToString());
                        }
                        catch (Exception ex)
                        {
                            Message.showError(ex.Message);
                        }
                        frmSubAgent objfrmSubAgent = new frmSubAgent(subAgentInformation, Convert.ToInt32(cmbAgentName.SelectedValue), ActionType.update);
                        objfrmSubAgent.ShowDialog();
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            showSubagents();
        }
    }
}
