using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.user;
using MISL.Ababil.Agent.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MISL.Ababil.Agent.Infrastructure.Validation;

namespace MISL.Ababil.Agent.UI.forms
{
     
    public partial class frmAgent : Form
    {
        int columnLoaded = 0;
        List<SubAgentInformation> subAgentList = new List<SubAgentInformation>();
        List<AgentInformation> agentInfoList = new List<AgentInformation>();
        AgentInformation agentInformation = new AgentInformation();
        AgentServices agentServices = new AgentServices();
        public frmAgent()
        {
            InitializeComponent();
            ConfigureValidation();
        }

        private void ConfigureValidation()
        {
            ValidationManager.ConfigureValidation(this, cmbAgentName, "Agent Name", (long) ValidationType.ListSelected,true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmSubAgent objSubAgent = new frmSubAgent();
            objSubAgent.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CheckValidation();
            frmUserCreate objfrmUserCreate = new frmUserCreate();
            objfrmUserCreate.Show();
        }

        private Boolean CheckValidation()
        {
            return ValidationManager.ValidateForm(this);
        }

        private void frmAgent_Load(object sender, EventArgs e)
        {
            //setAgentInformation();
            fillSetupData();
        }
        
        private void fillSetupData()
        {
            try
            {
                agentInfoList = agentServices.getAgentInfoBranchWise();
                BindingSource bs = new BindingSource();
                bs.DataSource = agentInfoList;
                UtilityServices.fillComboBox(cmbAgentName, bs, "businessName", "id");
            }
            catch(Exception ex)
            {
                Message.showError(ex.Message);
            }
        }
        private void setAgentInformation()
        {
            //try
            //{
            //    AgentInformation agentInfo = new AgentInformation();
            //    AgentServices agentservices = new AgentServices();

            //    agentInfo = agentservices.getAgentInfo();

            //    //Set General Info
            //    lblAgent_BusinessLocation.Text = agentInfo.agentAddress.addressLineOne;
            //    lblAgent_BusinessName.Text = agentInfo.businessName;
            //    lblCustomerId.Text = agentInfo.customerId.ToString();

            //    //set Account List
            //    gvAccountInfo.DataSource = agentInfo.accounts.Select(o => new AccountInfoGrid(o) { accountNumber = o.accountNumber, accountTitle = o.accountTitle }).ToList();

            //    //set User info
            //    gvUsers.DataSource = agentInfo.agentUsers.Select(o => new userListGrid(o) { username = o.username }).ToList();

            //    //set  Sub Agent list
            //    gvSubAgent.DataSource = agentInfo.subAgents.Select(o => new subAgentListGrid(o) { name = o.name, mobleNumber = o.mobleNumber }).ToList();

            //    if (columnLoaded == 0)
            //    {
            //        DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            //        buttonColumn.Text = "Edit";
            //        buttonColumn.Name = "Edit";
            //        buttonColumn.UseColumnTextForButtonValue = true;
            //        gvSubAgent.Columns.Add(buttonColumn);
            //        //columnLoaded = 1;
           
            //    }
            //    else
            //    {
            //        //gvSubAgent.Columns[0].DisplayIndex = 4;
            //    }


            //}catch(Exception ex)
            //{

            //}
           
        }
        private void gvSubAgent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                //SubAgentInformation subAgentInfo = new SubAgentInformation();
                //subAgentInfo = subAgentList[e.RowIndex];

                //frmSubAgent subAgentFrom = new frmSubAgent(subAgentInfo, ActionType.update);
                //subAgentFrom.Show();
                

            }

        }

        private void cmbAgentName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (!cb.Focused)
            {
                return;
            }

            AgentServices agentServices = new AgentServices();
            try
            {
                agentInformation = agentServices.getAgentInfoById(cmbAgentName.SelectedValue.ToString());
            }
            catch(Exception ex)
            {
                Message.showError(ex.Message);
            }
            if (agentInformation != null)
            {
                lblAgent_BusinessName.Text = agentInformation.businessName;
                if(agentInformation.agentAddress != null) lblAgent_BusinessLocation.Text = agentInformation.agentAddress.addressLineOne;
                lblCustomerId.Text = agentInformation.customerId.ToString();
                //lblMobile.Text = agentInformation.

               if(agentInformation.accounts != null) gvAccountInfo.DataSource = agentInformation.accounts.Select(o => new AccountInfoGrid(o) { accountNumber = o.accountNumber, accountTitle = o.accountTitle }).ToList();
               if (agentInformation.agentUsers != null) gvAccountInfo.DataSource = agentInformation.agentUsers.Select(o => new userListGrid(o) { username = o.username }).ToList();
               if (agentInformation.subAgents != null) gvAccountInfo.DataSource = agentInformation.subAgents.Select(o => new subAgentListGrid(o) { name = o.name, mobleNumber = o.mobleNumber }).ToList();
            }

           

        }

        private void frmAgent_FormClosing(object sender, FormClosingEventArgs e)
        {
            ValidationManager.ReleaseValidationData(this);
        }

    }
    public class AccountInfoGrid
    {
        public string accountNumber { get; set; }
        public string accountTitle { get; set; }
        //public long Balance { get; set; }
        //public long No_of_Agent { get; set; }

        private AccountInformation _obj;

        public AccountInfoGrid(AccountInformation obj)
        {
            _obj = obj;
        }

        public AccountInformation GetModel()
        {
            return _obj;
        }
    }

    public class userListGrid
    {
        public string username { get; set; }
        //public string status { get; set; }
        //pulic Delete button
        //public Edit button

        private AgentUser _obj;

        public userListGrid(AgentUser obj)
        {
            _obj = obj;
        }

        public AgentUser GetModel()
        {
            return _obj;
        }
    }

    public class subAgentListGrid
    {
        public string name { get; set; }
        public string mobleNumber { get; set; }
        //public AccountInformation agentAccount { get; set; }
        //Edit
        //Delete

        private SubAgentInformation _obj;

        public subAgentListGrid(SubAgentInformation obj)
        {
            _obj = obj;
        }

        public SubAgentInformation GetModel()
        {
            return _obj;
        }
    }

}
