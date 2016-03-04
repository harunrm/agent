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
    public partial class frmTrMonitoringRport : MetroForm
    {
        private GUI gui = new GUI();
        List<AgentInformation> objAgentInfoList = new List<AgentInformation>();
        AgentServices objAgentServices = new AgentServices();
        AgentInformation agentInformation = new AgentInformation();
        AgentServices agentServices = new AgentServices();

        AgentIncomeStatementDS agentDS = new AgentIncomeStatementDS();

        public List<AgentTrMonitoringInfo> _agentTrMonitorings = new List<AgentTrMonitoringInfo>();
        private List<AgentProduct> _agentProducts;


        public frmTrMonitoringRport()
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

            //mtbFromDate.Text = dtpFromDate.Value.ToString("dd-MM-yyyy");
            //mtbToDate.Text = dtpToDate.Value.ToString("dd-MM-yyyy");
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
                crAgentTrMonitoring report = new crAgentTrMonitoring();
                frmReportViewer viewer = new frmReportViewer();

                ReportHeaders rptHeaders = new ReportHeaders();
                rptHeaders = UtilityServices.getReportHeaders("Transaction Monitoring Report");

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
                #region harun
                //txtFromDate.Text = Convert.ToDateTime(dtpFromDate.Text).ToString("dd/MM/yyyy");
                //txtToDate.Text = Convert.ToDateTime(dtpToDate.Text).ToString("dd/MM/yyyy");
                #endregion
                txtFromDate.Text = dtpFromDate.Date;
                txtToDate.Text = dtpToDate.Date;

                LoadAgentTrMonitoring();

                //report.SetDataSource(_agentTrMonitorings);
                report.SetDataSource(agentDS);

                viewer.crvReportViewer.ReportSource = report;
                viewer.ShowDialog(this.Parent);
            }
            else
            {
                MessageBox.Show("Please select an option!", "Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void LoadAgentTrMonitoring()
        {
            AgentTrMonitoringInfo agentTrMonitoringInfo;
            _agentTrMonitorings.Clear();
            AccountSearchDto accountSearchDto = FillAccountSearchDto();
            ServiceResult result;
            agentDS = new AgentIncomeStatementDS();

            try
            {
                result = AgentServices.GetAgentTrMonitorInformaiton(accountSearchDto);

                if (!result.Success)
                {
                    MessageBox.Show(result.Message);
                    return;
                }

                List<AgentTransactionMonitoringDto> agentTrMonitoring = result.ReturnedObject as List<AgentTransactionMonitoringDto>;

                if (agentTrMonitoring != null)
                {
                    foreach (AgentTransactionMonitoringDto agentCommission in agentTrMonitoring)
                    {
                        AgentIncomeStatementDS.AgentTrMonitoringRow newRow = agentDS.AgentTrMonitoring.NewAgentTrMonitoringRow();

                        newRow.AgentId = agentCommission.agentId;
                        newRow.AgentName = agentCommission.agentName;
                        newRow.SubAgentId = agentCommission.subAgentId;
                        newRow.SubAgentName = agentCommission.subAgentName;
                        newRow.NoOfAccount = agentCommission.noOfAccount ?? 0;

                        newRow.NoOfDeposit = agentCommission.noOfDeposit ?? 0;
                        newRow.DepositAmount = agentCommission.depositAmount ?? 0;

                        newRow.NoOfWithdraw = agentCommission.noOfWithdraw ?? 0;
                        newRow.WithdrawAmount = agentCommission.withdrawAmount ?? 0;

                        newRow.NoOfFundTransfer = agentCommission.noOfFundTransfer ?? 0;
                        newRow.TransferAmount = agentCommission.transferAmount ?? 0;

                        newRow.NoOfRemittance = agentCommission.noOfRemittance ?? 0;
                        newRow.RemittanceAmount = agentCommission.remittanceAmount ?? 0;

                        newRow.NoOfUtilityBill = agentCommission.noOfUtilityBill ?? 0;
                        newRow.BillCollectionAmount = agentCommission.billCollectionAmount ?? 0;

                        newRow.NoOfLoanDisbursed = agentCommission.noOfLoanDisbursed ?? 0;
                        newRow.DisbursedAmount = agentCommission.disbursedAmount ?? 0;

                        newRow.NoOfInstallmentRecovered = agentCommission.noOfInstallmentRecovered ?? 0;
                        newRow.RecoveredAmount = agentCommission.recoveredAmount ?? 0;

                        agentDS.AgentTrMonitoring.AddAgentTrMonitoringRow(newRow);

                        #region Used the datased instead :: WALI 
                        //agentTrMonitoringInfo = new AgentTrMonitoringInfo();
                        //agentTrMonitoringInfo.AgentId = agentCommission.agentId;
                        //agentTrMonitoringInfo.AgentName = agentCommission.agentName;
                        //agentTrMonitoringInfo.SubAgentId = agentCommission.subAgentId;
                        //agentTrMonitoringInfo.SubAgentName = agentCommission.subAgentName;
                        //agentTrMonitoringInfo.NoOfAccount = agentCommission.noOfAccount ?? 0;

                        //agentTrMonitoringInfo.NoOfDeposit = agentCommission.noOfDeposit ?? 0;
                        //agentTrMonitoringInfo.DepositAmount = agentCommission.depositAmount ?? 0;

                        //agentTrMonitoringInfo.NoOfWithdraw = agentCommission.noOfWithdraw ?? 0;
                        //agentTrMonitoringInfo.WithdrawAmount = agentCommission.withdrawAmount ?? 0;

                        //agentTrMonitoringInfo.NoOfFundTransfer = agentCommission.noOfFundTransfer ?? 0;
                        //agentTrMonitoringInfo.TransferAmount = agentCommission.transferAmount ?? 0;

                        //agentTrMonitoringInfo.NoOfRemittance = agentCommission.noOfRemittance ?? 0;
                        //agentTrMonitoringInfo.RemittanceAmount = agentCommission.remittanceAmount ?? 0;

                        //agentTrMonitoringInfo.NoOfUtilityBill = agentCommission.noOfUtilityBill ?? 0;
                        //agentTrMonitoringInfo.BillCollectionAmount = agentCommission.billCollectionAmount ?? 0;

                        //agentTrMonitoringInfo.NoOfLoanDisbursed = agentCommission.noOfLoanDisbursed ?? 0;
                        //agentTrMonitoringInfo.DisbursedAmount = agentCommission.disbursedAmount ?? 0;

                        //agentTrMonitoringInfo.NoOfInstallmentRecovered = agentCommission.noOfInstallmentRecovered ?? 0;
                        //agentTrMonitoringInfo.RecoveredAmount = agentCommission.recoveredAmount ?? 0;

                        //_agentTrMonitorings.Add(agentTrMonitoringInfo);
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

            accountSearchDto.fromDate = UtilityServices.GetLongDate(UtilityServices.ParseDateTime(dtpFromDate.Date));
            accountSearchDto.toDate = UtilityServices.GetLongDate(UtilityServices.ParseDateTime(dtpToDate.Date));
            
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
        #region========== harun(22-09-015)==========
        //private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        //{
        //    mtbFromDate.Text = dtpFromDate.Value.ToString("dd-MM-yyyy");
        //}

        //private void dtpToDate_ValueChanged(object sender, EventArgs e)
        //{
        //    mtbToDate.Text = dtpToDate.Value.ToString("dd-MM-yyyy");
        //}

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
        #endregion


        private void frmTrMonitoringRport_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = SessionInfo.currentDate;
            dtpToDate.Value = SessionInfo.currentDate;
        }
    }
    public class AgentTrMonitoringInfo
    {
        public long AgentId = 0;
        public string AgentName = "";
        public long SubAgentId = 0;
        public string SubAgentName = "";
        public long NoOfAccount;

        public long NoOfDeposit = 0;
        public decimal DepositAmount = 0;

        public long NoOfWithdraw = 0;
        public decimal WithdrawAmount = 0;

        public long NoOfFundTransfer = 0;
        public decimal TransferAmount = 0;

        public long NoOfRemittance = 0;
        public decimal RemittanceAmount = 0;

        public long NoOfUtilityBill = 0;
        public decimal BillCollectionAmount = 0;

        public long NoOfLoanDisbursed = 0;
        public decimal DisbursedAmount = 0;

        public long NoOfInstallmentRecovered = 0;
        public decimal RecoveredAmount = 0;
    }


}
