using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using MISL.Ababil.Agent.Infrastructure;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using MISL.Ababil.Agent.Infrastructure.Models.dto;
using MISL.Ababil.Agent.Infrastructure.Models.models.transaction;
using MISL.Ababil.Agent.Infrastructure.Validation;
using MISL.Ababil.Agent.Report.Reports;
using MISL.Ababil.Agent.Services;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Report.DataSets;
using MISL.Ababil.Agent.Infrastructure.Models.reports;
using MetroFramework.Forms;
using System.Globalization;

namespace MISL.Ababil.Agent.Report
{
    public partial class frmAgentCommissionRport : MetroForm
    {
        private GUI gui = new GUI();
        List<AgentInformation> objAgentInfoList = new List<AgentInformation>();
        AgentServices objAgentServices = new AgentServices();
        AgentInformation agentInformation = new AgentInformation();
        AgentServices agentServices = new AgentServices();

        public List<AgentCommissionInformation> _agentCommissionInformations = new List<AgentCommissionInformation>();
        private List<AgentProduct> _agentProducts;

        AgentIncomeStatementDS agentDS = new AgentIncomeStatementDS();


        public frmAgentCommissionRport()
        {
            InitializeComponent();
            GetSetupData();
            try
            {
                cmbAgentName.SelectedIndex = 0;
            }
            catch (Exception exp)
            { }
            controlActivity();
            ConfigUIEnhancement();
        }
        public void ConfigUIEnhancement()
        {
            gui = new GUI(this);
            gui.Config(ref cmbAgentName, ValidCheck.VALIDATIONTYPES.COMBOBOX_EMPTY, null);
            gui.Config(ref cmbSubAgnetName);
            gui.Config(ref dtpFromDate);
            gui.Config(ref dtpToDate);
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
                    agentInformation = agentServices.getAgentInfoById(UtilityServices.getCurrentAgent().id.ToString());
                    setSubagent();
                }
                else
                {
                    SubAgentInformation currentSubagentInfo = UtilityServices.getCurrentSubAgent();
                    cmbAgentName.SelectedValue = currentSubagentInfo.agent.id;
                    agentInformation = agentServices.getAgentInfoById(currentSubagentInfo.agent.id.ToString());
                    setSubagent();
                    cmbAgentName.Enabled = false;
                    cmbSubAgnetName.SelectedValue = currentSubagentInfo.id;
                    cmbSubAgnetName.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //cmbAgentName.Enabled = true;
                //cmbSubAgnetName.Enabled = true;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            //chacking valid date
            DateTime fromDate, toDate;
            try
            {
                //fromDate = UtilityServices.ParseDateTime(dtpFromDate.Date);
                fromDate = DateTime.ParseExact(dtpFromDate.Date.Replace("/", "-"), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            }
            catch
            {
                MessageBox.Show("Please enter the Date in correct format.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                //toDate = UtilityServices.ParseDateTime(dtpToDate.Date);
                toDate = DateTime.ParseExact(dtpToDate.Date.Replace("/", "-"), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            }
            catch
            {
                MessageBox.Show("Please enter the Date in correct format.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (SessionInfo.currentDate < toDate)
            {
                MessageBox.Show("Future date is not allowed!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (fromDate > toDate)
            {
                MessageBox.Show("From date can not be greater than to date.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (cmbAgentName.SelectedIndex > 0)
            {
                crAgentCommissionInformation report = new crAgentCommissionInformation();
                frmReportViewer viewer = new frmReportViewer();

                ReportHeaders rptHeaders = new ReportHeaders();
                rptHeaders = UtilityServices.getReportHeaders("Agent Commission Report");

                TextObject txtBankName = report.ReportDefinition.ReportObjects["txtBankName"] as TextObject;
                TextObject txtBranchName = report.ReportDefinition.ReportObjects["txtBranchName"] as TextObject;
                TextObject txtBranchAddress = report.ReportDefinition.ReportObjects["txtBranchAddress"] as TextObject;
                TextObject txtReportHeading = report.ReportDefinition.ReportObjects["txtReportHeading"] as TextObject;
                TextObject txtPrintUser = report.ReportDefinition.ReportObjects["txtPrintUser"] as TextObject;
                TextObject txtPrintDate = report.ReportDefinition.ReportObjects["txtPrintDate"] as TextObject;
                TextObject txtFromDate = report.ReportDefinition.ReportObjects["txtFromDate"] as TextObject;
                TextObject txtToDate = report.ReportDefinition.ReportObjects["txtToDate"] as TextObject;
                if (rptHeaders != null)
                {
                    if (rptHeaders.branchDto != null)
                    {
                        txtBankName.Text = rptHeaders.branchDto.bankName;
                        txtBranchName.Text = rptHeaders.branchDto.branchName;
                        txtBranchAddress.Text = rptHeaders.branchDto.branchAddress;
                    }
                    txtReportHeading.Text = rptHeaders.reportHeading;
                    txtPrintUser.Text = rptHeaders.printUser;
                    txtPrintDate.Text = rptHeaders.printDate.ToString("dd-MM-yyyy").Replace("-","/");
                }
                //txtFromDate.Text = Convert.ToDateTime(dtpFromDate.Text).ToString("dd/MM/yyyy");
                //txtToDate.Text = Convert.ToDateTime(dtpToDate.Text).ToString("dd/MM/yyyy");
                txtFromDate.Text = dtpFromDate.Date;
                txtToDate.Text = dtpToDate.Date;

                LoadAgentCommissionInformation();

                //report.SetDataSource(_agentCommissionInformations);
                report.SetDataSource(agentDS);

                viewer.crvReportViewer.ReportSource = report;
                viewer.ShowDialog(this.Parent);
            }
            else
            {
                MessageBox.Show("Please select an option!", "Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void LoadAgentCommissionInformation()
        {
            AgentCommissionInformation agentCommissionInformation;
            _agentCommissionInformations.Clear();
            AccountSearchDto accountSearchDto = FillAccountSearchDto();
            ServiceResult result;
            agentDS = new AgentIncomeStatementDS();

            try
            {
                result = AgentServices.GetAgentCommissionInformaiton(accountSearchDto);

                if (!result.Success)
                {
                    MessageBox.Show(result.Message);
                    return;
                }

                List<AgentCommissionInfoDto> agentCommissionInfo = result.ReturnedObject as List<AgentCommissionInfoDto>;

                if (agentCommissionInfo != null)
                {
                    foreach (AgentCommissionInfoDto agentCommission in agentCommissionInfo)
                    {
                        AgentIncomeStatementDS.AgentCommissionInformationRow newRow =
                            agentDS.AgentCommissionInformation.NewAgentCommissionInformationRow();
                        newRow.AgentId = agentCommission.agentId;
                        newRow.AgentName = agentCommission.agentName;
                        newRow.SubAgentId = agentCommission.subAgentId;
                        newRow.SubAgentName = agentCommission.subAgentName;
                        newRow.TransactionCommission = agentCommission.transactionComm ?? 0;
                        newRow.RemittanceCommission = agentCommission.remittanceComm ?? 0;
                        newRow.UtilityBillCommission = agentCommission.utilityBillComm ?? 0;
                        newRow.LoanDisbursmentCommission = agentCommission.loanDisbursmentComm ?? 0;
                        newRow.RepaymentCollectionCommission = agentCommission.repaymentCollectionComm ?? 0;
                        agentDS.AgentCommissionInformation.AddAgentCommissionInformationRow(newRow);

                        #region MyRegion


                        //agentCommissionInformation = new AgentCommissionInformation();
                        //agentCommissionInformation.AgentId = agentCommission.agentId;
                        //agentCommissionInformation.AgentName = agentCommission.agentName;
                        //agentCommissionInformation.SubAgentId = agentCommission.subAgentId;
                        //agentCommissionInformation.SubAgentName = agentCommission.subAgentName;
                        //agentCommissionInformation.TransactionCommission = agentCommission.transactionComm ?? 0;
                        //agentCommissionInformation.RemittanceCommission = agentCommission.remittanceComm ?? 0;
                        //agentCommissionInformation.UtilityBillCommission = agentCommission.utilityBillComm ?? 0;
                        //agentCommissionInformation.LoanDisbursmentCommission = agentCommission.loanDisbursmentComm ?? 0;
                        //agentCommissionInformation.RepaymentCollectionCommission = agentCommission.repaymentCollectionComm ?? 0;

                        //_agentCommissionInformations.Add(agentCommissionInformation);
                        #endregion
                    }

                }
                agentDS.AcceptChanges();
            }
            catch (Exception)
            {
                //ignored
            }
        }

        private AccountSearchDto FillAccountSearchDto()
        {
            AccountSearchDto accountSearchDto = new AccountSearchDto();

            if (this.cmbAgentName.SelectedIndex > -1)
            {
                if (cmbAgentName.SelectedIndex != 0 || cmbAgentName.SelectedIndex != 1)
                {
                    accountSearchDto.agent = new AgentInformation { id = (long)cmbAgentName.SelectedValue };
                }
                if (cmbAgentName.SelectedIndex == 1 || cmbAgentName.SelectedIndex == 0)
                {
                    accountSearchDto.agent = null; // new AgentInformation();
                }
                if (cmbAgentName.SelectedIndex == 0)
                {
                    //MessageBox.Show("Please select an option!", "Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //return null;
                }
            }
            if (this.cmbSubAgnetName.SelectedIndex > -1)
            {
                if (cmbSubAgnetName.SelectedIndex != 0 || cmbSubAgnetName.SelectedIndex != 1)
                {
                    accountSearchDto.subAgent = new SubAgentInformation { id = (long)cmbSubAgnetName.SelectedValue };
                }
                if (cmbSubAgnetName.SelectedIndex == 1 || cmbSubAgnetName.SelectedIndex == 0)
                {
                    accountSearchDto.subAgent = null; // new SubAgentInformation();
                }
                if (cmbSubAgnetName.SelectedIndex == 0)
                {
                    //MessageBox.Show("Please select an option!", "Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //return null;
                }
            }

            //accountSearchDto.fromDate = UtilityServices.GetLongDate(UtilityServices.ParseDateTime(dtpFromDate.Date));
            //accountSearchDto.toDate = UtilityServices.GetLongDate(UtilityServices.ParseDateTime(dtpToDate.Date));
            
            accountSearchDto.fromDate = UtilityServices.GetLongDate
            (
                DateTime.ParseExact(dtpFromDate.Date.Replace("/", "-"), "dd-MM-yyyy", CultureInfo.InvariantCulture)
            );

            
            accountSearchDto.toDate = UtilityServices.GetLongDate
            (
                DateTime.ParseExact(dtpToDate.Date.Replace("/", "-"), "dd-MM-yyyy", CultureInfo.InvariantCulture)
            );

            return accountSearchDto;
        }

        private void GetSetupData()
        {
            //string configvalue1 = ConfigurationManager.AppSettings["countryId"];
            try
            {
                setAgentList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void setAgentList()
        {
            objAgentInfoList = objAgentServices.getAgentInfoBranchWise();
            BindingSource bs = new BindingSource();
            bs.DataSource = objAgentInfoList;

            AgentInformation agSelect = new AgentInformation();
            agSelect.businessName = "(Select)";
            objAgentInfoList.Insert(0, agSelect);
            AgentInformation agAll = new AgentInformation();
            agAll.businessName = "(All)";
            objAgentInfoList.Insert(1, agAll);

            UtilityServices.fillComboBox(cmbAgentName, bs, "businessName", "id");
            //            cmbAgentName.Text = "Select";
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
                if (cmbAgentName.SelectedIndex > 1)
                {
                    agentInformation = agentServices.getAgentInfoById(cmbAgentName.SelectedValue.ToString());
                }
                if (cmbAgentName.SelectedIndex == 1)
                {
                    //agentInformation = agentServices.getAgentInfoById(null);
                }
                if (cmbAgentName.SelectedIndex < 2)
                {
                    cmbSubAgnetName.DataSource = null;
                    cmbSubAgnetName.Items.Clear();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            setSubagent();
        }
        private void setSubagent()
        {
            if (agentInformation != null)
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = agentInformation.subAgents;

                try
                {
                    SubAgentInformation saiSelect = new SubAgentInformation();
                    saiSelect.name = "(Select)";

                    SubAgentInformation saiAll = new SubAgentInformation();
                    saiAll.name = "(All)";

                    agentInformation.subAgents.Insert(0, saiSelect);
                    agentInformation.subAgents.Insert(1, saiAll);
                }
                catch (Exception exp)
                { }

                UtilityServices.fillComboBox(cmbSubAgnetName, bs, "name", "id");
                if (cmbSubAgnetName.Items.Count > 0)
                {
                    cmbSubAgnetName.SelectedIndex = 0;
                }
            }
        }

        private void frmAgentCommissionRport_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = SessionInfo.currentDate;
            dtpToDate.Value = SessionInfo.currentDate;
        }

        private void frmAgentCommissionRport_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner = null;
        }
    }

    public class AgentCommissionInformation
    {
        public long AgentId = 0;
        public string AgentName = "";
        public long SubAgentId = 0;
        public string SubAgentName = "";
        public decimal TransactionCommission = 0;
        public decimal RemittanceCommission = 0;
        public decimal UtilityBillCommission = 0;
        public decimal LoanDisbursmentCommission = 0;
        public decimal RepaymentCollectionCommission = 0;
    }


}
