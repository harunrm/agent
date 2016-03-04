using MetroFramework.Forms;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using MISL.Ababil.Agent.Services;
using MISL.Ababil.Agent.UI.forms.OutletUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.user;

namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmOutletList : MetroForm
    {
        public frmOutletList()
        {
            try
            {
                InitializeComponent();
                lblAgentCodeValue.Text = SessionInfo.userBasicInformation.agent.agentCode;
                lblAgentNameValue.Text = SessionInfo.userBasicInformation.agent.businessName;
                AgentServices agentServices = new AgentServices();
                lblBalanceValue.Text = agentServices.GetAgentAccountInfoByAgentId(SessionInfo.userBasicInformation.agent.id.ToString()).balance.ToString() + "BDT";
            }
            catch (Exception ex)
            {
                Message.showError(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            panelOutletList.Controls.Clear();

            AgentServices agentServices = new AgentServices();
            List<SubAgentInformation> subAgentInformationList = agentServices.GetSubagentsByAgentId(SessionInfo.userBasicInformation.agent.id);

            for (int i = 0; i < subAgentInformationList.Count; i++)
            {
                //OutletListItem outletListItem = new OutletListItem(null, subAgentInformationList[i]);
                OutletListItem outletListItem = new OutletListItem(null, LimitUserType.Outlet, (object)subAgentInformationList[i]);

                outletListItem.Dock = DockStyle.Top;
                panelOutletList.Controls.Add(outletListItem);
            }
        }

        private void panelOutletList_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}