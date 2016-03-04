using MetroFramework.Forms;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using MISL.Ababil.Agent.Infrastructure.Models.dto;
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
    public partial class frmOutletCashInfoAll : MetroForm
    {
        private Packet _packet;
        private GUI _gui = new GUI();
        private List<AgentInformation> _objAgentInfoList = new List<AgentInformation>();
        private AgentServices _objAgentServices = new AgentServices();
        private AgentInformation _agentInformation = new AgentInformation();
        private AgentServices _agentServices = new AgentServices();

        public frmOutletCashInfoAll(Packet packet)
        {
            _packet = packet;
            InitializeComponent();
            GetSetupData();
            controlActivity();
            ConfigUIEnhancement();
        }

        public void ConfigUIEnhancement()
        {
            _gui = new GUI(this);
            _gui.Config(ref cmbAgentName, ValidCheck.VALIDATIONTYPES.COMBOBOX_EMPTY, null);
            _gui.Config(ref cmbSubAgnetName, ValidCheck.VALIDATIONTYPES.COMBOBOX_EMPTY, null);
            _gui.Config(ref dtpFromDate);
        }

        private void controlActivity()
        {
            try
            {
                if (SessionInfo.rights.Contains(Rights.REPORT_VIEW_CENTRALLY.ToString())) //branch user
                {
                    cmbAgentName.Enabled = true;
                    cmbSubAgnetName.Enabled = true;
                }
                else if (SessionInfo.rights.Contains(Rights.REPORT_VIEW_AGENTWISE.ToString())) //agent user
                {
                    cmbAgentName.SelectedValue = UtilityServices.getCurrentAgent().id;
                    cmbAgentName.Enabled = false;
                    cmbSubAgnetName.Enabled = true;
                    _agentInformation = _agentServices.getAgentInfoById(UtilityServices.getCurrentAgent().id.ToString());
                    setSubagent();
                }
                else
                {
                    SubAgentInformation currentSubagentInfo = UtilityServices.getCurrentSubAgent();
                    cmbAgentName.SelectedValue = currentSubagentInfo.agent.id;
                    _agentInformation = _agentServices.getAgentInfoById(currentSubagentInfo.agent.id.ToString());
                    setSubagent();
                    cmbAgentName.Enabled = false;
                    cmbSubAgnetName.SelectedValue = currentSubagentInfo.id;
                    cmbSubAgnetName.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void setSubagent()
        {
            if (_agentInformation != null)
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = _agentInformation.subAgents;

                {
                    try
                    {
                        SubAgentInformation saiSelect = new SubAgentInformation();
                        saiSelect.name = "(Select)";
                        _agentInformation.subAgents.Insert(0, saiSelect);
                    }
                    catch //suppressed
                    {

                    }
                }
                UtilityServices.fillComboBox(cmbSubAgnetName, bs, "name", "id");
                if (cmbSubAgnetName.Items.Count > 0)
                {
                    cmbSubAgnetName.SelectedIndex = 0;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmOutletCashInfoAll_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = SessionInfo.currentDate;
        }

        private void GetSetupData()
        {
            try
            {
                setAgentList();
            }
            catch { }
        }

        private void setAgentList()
        {
            _objAgentInfoList = _objAgentServices.getAgentInfoBranchWise();
            BindingSource bs = new BindingSource();
            bs.DataSource = _objAgentInfoList;

            AgentInformation agSelect = new AgentInformation();
            agSelect.businessName = "(Select)";
            _objAgentInfoList.Insert(0, agSelect);

            UtilityServices.fillComboBox(cmbAgentName, bs, "businessName", "id");
            cmbAgentName.SelectedIndex = 0;
        }

        private void cmbAgentName_SelectedIndexChanged(object sender, EventArgs e)
        {

            ComboBox cb = (ComboBox)sender;
            if (!cb.Focused)
            {
                return;
            }

            try
            {
                if (cmbAgentName.SelectedIndex > 0)
                {
                    _agentInformation = _agentServices.getAgentInfoById(cmbAgentName.SelectedValue.ToString());
                }
                if (cmbAgentName.SelectedIndex < 1)
                {
                    cmbSubAgnetName.DataSource = null;
                    cmbSubAgnetName.Items.Clear();
                    return;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            setSubagent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (cmbAgentName.SelectedIndex < 1)
            {
                Message.showError("Please select an Agent!");
                return;
            }
            if (cmbSubAgnetName.SelectedIndex < 1)
            {
                Message.showError("Please select an Outlet!");
                return;
            }
            if (dtpFromDate.Value > SessionInfo.currentDate)
            {
                Message.showError("Future date not allowed!");
                return;
            }

            Packet packet = new Packet();
            packet.actionType = FormActionType.View;
            packet.intentType = IntentType.Request;

            OutletCashSumReqDto outletCashSumReqDto = new OutletCashSumReqDto();
            outletCashSumReqDto.outletId = (long)cmbSubAgnetName.SelectedValue;
            outletCashSumReqDto.informationDate = dtpFromDate.Value;

            frmOutletCashInfo frm = new frmOutletCashInfo(packet, outletCashSumReqDto);
            frm.ShowDialog();
        }
    }
}