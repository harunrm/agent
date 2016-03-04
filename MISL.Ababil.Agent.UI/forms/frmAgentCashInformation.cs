using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;
using MISL.Ababil.Agent.Infrastructure;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using MISL.Ababil.Agent.Services;

namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmAgentCashInformation : MetroForm
    {
        List<AgentInformation> objAgentInfoList = new List<AgentInformation>();
        AgentServices agentServices = new AgentServices();
        AgentInformation agentInformation = new AgentInformation();
        ServiceResult result;
        public frmAgentCashInformation()
        {
            InitializeComponent();
            LoadSetupData();
            controlActivity();
        }

        private void LoadSetupData()
        {
            try
            {
                objAgentInfoList = agentServices.getAgentInfoBranchWise();
                BindingSource bsAgent = new BindingSource();
                bsAgent.DataSource = objAgentInfoList;

                AgentInformation agSelect = new AgentInformation();
                agSelect.businessName = "Select";
                objAgentInfoList.Insert(0, agSelect);
                //AgentInformation agAll = new AgentInformation();
                //agAll.businessName = "All";
                //objAgentInfoList.Insert(1, agAll);

                UtilityServices.fillComboBox(cmbAgentName, bsAgent, "businessName", "id");
                cmbAgentName.SelectedIndex = 0;
            }
            catch (Exception ex)
            { Message.showError(ex.Message); }
        }
        private void controlActivity()
        {
            try
            {
                if (SessionInfo.rights.Contains(Rights.REPORT_VIEW_CENTRALLY.ToString())) //branch user
                {
                    cmbAgentName.Enabled = true;
                }
                else if (SessionInfo.rights.Contains(Rights.REPORT_VIEW_AGENTWISE.ToString())) //agent user
                {
                    cmbAgentName.SelectedValue = UtilityServices.getCurrentAgent().id;
                    cmbAgentName.Enabled = false;
                    agentInformation = agentServices.getAgentInfoById(UtilityServices.getCurrentAgent().id.ToString());
                }
                else
                {
                    SubAgentInformation currentSubagentInfo = UtilityServices.getCurrentSubAgent();
                    cmbAgentName.SelectedValue = currentSubagentInfo.agent.id;
                    agentInformation = agentServices.getAgentInfoById(currentSubagentInfo.agent.id.ToString());
                    cmbAgentName.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Message.showError(ex.Message);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private RequestValidity SerachValidationCheck()
        {
            RequestValidity reqValidity = new RequestValidity();

            if (cmbAgentName.SelectedIndex < 1)
            {
                reqValidity.isValidRequest = false;
                reqValidity.message = "Please select an agent.";
            }

            DateTime tmpDate = new DateTime();
            try
            {
                tmpDate = DateTime.ParseExact(dtpDate.Date.ToString().Replace("/", "-"), "dd-MM-yyyy", CultureInfo.InvariantCulture);

                if (tmpDate > SessionInfo.currentDate)
                {
                    reqValidity.isValidRequest = false;
                    reqValidity.message += "\nFuture date not allowed!!.";
                }
            }
            catch
            {
                reqValidity.isValidRequest = false;
                reqValidity.message = "\nPlease enter the Date in correct format.";
            }

            return reqValidity;
        }
        private void btnViewReport_Click(object sender, EventArgs e)
        {
            try
            {
                RequestValidity reqValidity = SerachValidationCheck();

                if (reqValidity.isValidRequest)
                {
                    Packet packet = new Packet();
                    long agentId = objAgentInfoList[cmbAgentName.SelectedIndex].id;
                    DateTime informationDate = dtpDate.Value;

                    frmAgentBalance frm = new frmAgentBalance(packet, agentId, informationDate);
                    frm.ShowDialog();
                }
                else Message.showWarning(reqValidity.message);
            }
            catch (Exception exp)
            { Message.showError(exp.Message); }
        }
    }

    internal class RequestValidity
    {
        public bool isValidRequest { get; set; }
        public string message { get; set; }

        public RequestValidity()
        {
            isValidRequest = true;
            message = "";
        }
    }
}
