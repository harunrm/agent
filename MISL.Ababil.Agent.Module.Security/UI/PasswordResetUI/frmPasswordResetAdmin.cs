using MetroFramework.Forms;
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

namespace MISL.Ababil.Agent.Module.Security.UI.PasswordResetUI
{
    public partial class frmPasswordResetAdmin : MetroForm
    {
        public frmPasswordResetAdmin(Packet packet)
        {
            _packet = packet;

            InitializeComponent();

            SetupDataLoad();
        }

        Packet _packet;
        AgentServices _agentServices = new AgentServices();

        private void SetupDataLoad()
        {
            List<AgentUserType> userTypeList = new List<AgentUserType>();
            {
                userTypeList.Add(AgentUserType.Branch);
                userTypeList.Add(AgentUserType.Agent);
                userTypeList.Add(AgentUserType.Outlet);
            }
            BindingSource bs = new BindingSource();
            bs.DataSource = userTypeList;
            cmbUserType.DataSource = bs;
            cmbUserType.SelectedIndex = -1;
        }

        private void frmPasswordResetAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner = null;
        }

        private void cmbUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUserType.SelectedItem != null)
            {
                switch ((AgentUserType)cmbUserType.SelectedItem)
                {
                    case AgentUserType.Outlet:
                        break;
                    case AgentUserType.Agent:
                        try
                        {

                            List<AgentInformation> objAgentInfoList = _agentServices.getAgentInfoBranchWise();
                            BindingSource bs = new BindingSource();
                            bs.DataSource = objAgentInfoList;
                            UtilityServices.fillComboBox(cmbAgent, bs, "businessName", "id");
                        }
                        catch (Exception ex)
                        {

                        }
                        break;
                    case AgentUserType.Branch:
                        break;
                    case AgentUserType.Admin:
                        break;
                    case AgentUserType.Remittance:
                        break;
                    case AgentUserType.FieldOfficer:
                        break;
                    default:
                        break;
                }
            }
            cmbAgent.SelectedIndex = -1;
            cmbOutlet.SelectedIndex = -1;
        }

        private void cmbAgent_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<SubAgentInformation> subAgentInformationList = _agentServices.GetSubagentsByAgentId(((AgentInformation)cmbAgent.SelectedValue).id);
            if (subAgentInformationList != null)
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = subAgentInformationList;
                UtilityServices.fillComboBox(cmbOutlet, bs, "name", "id");
            }
        }
    }
}