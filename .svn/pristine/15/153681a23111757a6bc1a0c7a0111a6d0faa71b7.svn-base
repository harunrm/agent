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
    public partial class frmAccountMonitoringRport : MetroForm
    {
        public GUI gui = new GUI();
        List<AgentInformation> objAgentInfoList = new List<AgentInformation>();
        AgentServices objAgentServices = new AgentServices();
        AgentInformation agentInformation = new AgentInformation();
        AgentServices agentServices = new AgentServices();

        AgentIncomeStatementDS agentDS = new AgentIncomeStatementDS();

        public List<AccountMonitoringInfo> _accountMonitoringList = new List<AccountMonitoringInfo>();
        private List<AgentProduct> _agentProducts;


        public frmAccountMonitoringRport()
        {
            InitializeComponent();
            GetSetupData();
            try
            {
                //cmbAgentName.SelectedIndex = 0;
                cmbAgentName.SelectedIndex = -1;
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
                crAccountMonitoringReport report = new crAccountMonitoringReport();
                frmReportViewer viewer = new frmReportViewer();

                ReportHeaders rptHeaders = new ReportHeaders();
                rptHeaders = UtilityServices.getReportHeaders("Account Monitoring Report");

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

                LoadAccountMonitoring();

                //report.SetDataSource(_accountMonitoringList);
                report.SetDataSource(agentDS);

                viewer.crvReportViewer.ReportSource = report;
                viewer.ShowDialog(this.Parent);
            }
            else
            {
                MessageBox.Show("Please select an option!", "Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void LoadAccountMonitoring()
        {
            AccountMonitoringInfo accountMonitoringInfo;
            _accountMonitoringList.Clear();
            AccountSearchDto accountSearchDto = FillAccountSearchDto();
            ServiceResult result;
            agentDS = new AgentIncomeStatementDS();

            try
            {
                result = AgentServices.GetAccountMonitorInformaiton(accountSearchDto);

                if (!result.Success)
                {
                    MessageBox.Show(result.Message);
                    return;
                }

                List<AccountMonitoringDto> accountMonitoring = result.ReturnedObject as List<AccountMonitoringDto>;

                if (accountMonitoring != null)
                {
                    foreach (AccountMonitoringDto account in accountMonitoring)
                    {
                        AgentIncomeStatementDS.AccountMonitoringRow newRow = agentDS.AccountMonitoring.NewAccountMonitoringRow();

                        newRow.AgentId = account.agentId;
                        newRow.AgentName = account.agentName;
                        newRow.SubAgentId = account.subAgentId;
                        newRow.SubAgentName = account.subAgentName;
                        newRow.AgentAccBalance = account.agentAccBalance ?? 0;

                        newRow.NoOfMSDAccount = account.noOfMSDAccount ?? 0;
                        newRow.MSDAccBalance = account.msdAccBalance ?? 0;

                        newRow.NoOfCDAccount = account.noOfCDAccount ?? 0;
                        newRow.CDAccBalance = account.cdAccBalance ?? 0;

                        newRow.NoOfITDAccount = account.noOfITDAccount ?? 0;
                        newRow.ITDAccBalance = account.itdAccBalance ?? 0;

                        newRow.NoOfMTDAccount = account.noOfMTDAccount ?? 0;
                        newRow.MTDAccBalance = account.mtdAccBalance ?? 0;

                        newRow.NoOfInvestmentAccount = account.noOfInvestmentAccount ?? 0;
                        newRow.InvestedAmount = account.investedAmount ?? 0;

                        agentDS.AccountMonitoring.AddAccountMonitoringRow(newRow);
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

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            //mtbFromDate.Text = dtpFromDate.Value.ToString("dd-MM-yyyy");
            //dtpFromDate.Text = dtpFromDate.Date;
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            //mtbToDate.Text = dtpToDate.Value.ToString("dd-MM-yyyy");
            //dtpFromDate.Text = dtpToDate.Date;
        }

        //private void mtbFromDate_KeyUp(object sender, KeyEventArgs e)
        //{
        //    //suppressed to avoid mtb to dtp conversion
        //    try
        //    {
        //        string[] str = mtbFromDate.Text.Split('-');
        //        DateTime d = new DateTime(int.Parse(str[2].Trim()), int.Parse(str[1].Trim()), int.Parse(str[0].Trim()));
        //        dtpFromDate.Value = d;
        //    }
        //    catch (Exception ex) { }
        //}

        //private void mtbToDate_KeyUp(object sender, KeyEventArgs e)
        //{
        //    //suppressed to avoid mtb to dtp conversion
        //    try
        //    {
        //        string[] str = mtbToDate.Text.Split('-');
        //        DateTime d = new DateTime(int.Parse(str[2].Trim()), int.Parse(str[1].Trim()), int.Parse(str[0].Trim()));
        //        dtpToDate.Value = d;
        //    }
        //    catch (Exception ex) { }
        //}

        private void frmTrMonitoringRport_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = SessionInfo.currentDate;
            dtpToDate.Value = SessionInfo.currentDate;
        }
    }
    public class AccountMonitoringInfo
    {
        public long AgentId = 0;
        public string AgentName = "";
        public long SubAgentId = 0;
        public string SubAgentName = "";
        public decimal? AgentAccBalance = 0;

        public long NoOfMSDAccount = 0;
        public decimal MSDAccBalance = 0;

        public long NoOfCDAccount = 0;
        public decimal CDAccBalance = 0;

        public long NoOfITDAccount = 0;
        public decimal ITDAccBalance = 0;

        public long NoOfMTDAccount = 0;
        public decimal MTDAccBalance = 0;

        public long NoOfInvestmentAccount = 0;
        public decimal InvestedAmount = 0;
    }


}
