using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using MetroFramework.Forms;
using MISL.Ababil.Agent.Infrastructure;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using MISL.Ababil.Agent.Infrastructure.Models.dto;
using MISL.Ababil.Agent.Infrastructure.Models.models.transaction;
using MISL.Ababil.Agent.Infrastructure.Models.reports;
using MISL.Ababil.Agent.Report.DataSets;
using MISL.Ababil.Agent.Report.Properties;
using MISL.Ababil.Agent.Report.Reports;
using MISL.Ababil.Agent.Services;

namespace MISL.Ababil.Agent.Report
{
    public partial class frmTransactionReport : MetroForm
    {

        private GUI gui = new GUI();
        List<AgentInformation> objAgentInfoList = new List<AgentInformation>();
        AgentServices agentServices = new AgentServices();
        AgentInformation agentInformation = new AgentInformation();
        TransactionService transactionService = new TransactionService();
        ServiceResult result;

        public List<TransactionReport> _txnReportList = new List<TransactionReport>();

        public frmTransactionReport()
        {
            InitializeComponent();

            dtpDateFrom.Value = SessionInfo.currentDate;
            dtpDateTo.Value = SessionInfo.currentDate;
            LoadSetupData();
            controlActivity();
            ConfigUIEnhancement();
        }
        private void LoadSetupData()
        {
            try
            {
                List<AgentServicesTypeList> svcTypeList = Enum.GetValues(typeof(AgentServicesType)).Cast<AgentServicesType>()
                                                                                                .Select(a => new AgentServicesTypeList
                                                                                                {
                                                                                                    AgentServiceTypeName = a.ToString(),
                                                                                                }).ToList();
                AgentServicesTypeList allSvcType = new AgentServicesTypeList();
                BindingSource bsTxn = new BindingSource();
                allSvcType.AgentServiceTypeName = "All";
                svcTypeList.Insert(0, allSvcType);
                bsTxn.DataSource = svcTypeList;
                UtilityServices.fillComboBox(cmbTransactionType, bsTxn, "AgentServiceTypeName", "AgentServiceTypeName");

                objAgentInfoList = agentServices.getAgentInfoBranchWise();
                BindingSource bsAgent = new BindingSource();
                bsAgent.DataSource = objAgentInfoList;

                AgentInformation agSelect = new AgentInformation();
                agSelect.businessName = Resources.SetupData__Select_;
                objAgentInfoList.Insert(0, agSelect);
                AgentInformation agAll = new AgentInformation();
                agAll.businessName = Resources.SetupData__All_;
                objAgentInfoList.Insert(1, agAll);

                UtilityServices.fillComboBox(cmbAgentName, bsAgent, "businessName", "id");
                cmbAgentName.Text = "Select";
                cmbAgentName.SelectedIndex = 0;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
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
            }
        }
        public void ConfigUIEnhancement()
        {
            gui = new GUI(this);
            gui.Config(ref cmbAgentName, ValidCheck.VALIDATIONTYPES.COMBOBOX_EMPTY, null);
            gui.Config(ref cmbSubAgnetName);
            gui.Config(ref dtpDateFrom);
            gui.Config(ref dtpDateTo);
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
                { cmbSubAgnetName.SelectedIndex = 0; }
            }
        }
        private void cmbAgentName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cmbAgentName.Focused) return;

            try
            {
                if (cmbAgentName.SelectedIndex > 1)
                { agentInformation = agentServices.getAgentInfoById(cmbAgentName.SelectedValue.ToString()); }
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
            { MessageBox.Show(ex.Message); }
            setSubagent();
        }

        private void LoadTransactionRegisterData()
        {
            TransactionReport txnReportRow;
            _txnReportList = new List<TransactionReport>();

            TransactionReportSearchDto dailyTrnRecordSearchDto = FillTxnReportSearchDto();
            try
            {
                result = transactionService.getTransactionReport(dailyTrnRecordSearchDto);
                if (result.Success)
                {
                    List<TransactionReportResultDto> txnReportResult = result.ReturnedObject as List<TransactionReportResultDto>;
                    if (txnReportResult != null)
                    {
                        foreach (TransactionReportResultDto txnRecord in txnReportResult)
                        {
                            txnReportRow = new TransactionReport();
                            txnReportRow.agentId = txnRecord.agentId;
                            txnReportRow.agentName = txnRecord.agentName;
                            txnReportRow.subAgentId = txnRecord.subAgentId;
                            txnReportRow.subAgentName = txnRecord.subAgentName;
                            txnReportRow.txnId = txnRecord.txnId;
                            //txnReportRow.txnDate = UtilityServices.getDateFromLong(txnRecord.txnDate);
                            txnReportRow.txnDate = txnRecord.txnDate;
                            txnReportRow.voucherNo = txnRecord.voucherNo;
                            txnReportRow.transactionAmount = txnRecord.transactionAmount;
                            txnReportRow.comissionAmount = txnRecord.comissionAmount;
                            txnReportRow.agentService = txnRecord.agentService;
                            txnReportRow.debitAccount = txnRecord.debitAccount;
                            txnReportRow.creditAccount = txnRecord.creditAccount;

                            _txnReportList.Add(txnReportRow);
                        }
                    }
                }
            }
            catch (Exception exp)
            { MessageBox.Show("Report data loading error.\n" + exp.Message); }
        }
        private TransactionReportSearchDto FillTxnReportSearchDto()
        {
            TransactionReportSearchDto TxnReportSearchDto = new TransactionReportSearchDto();
            try
            {
                if (this.cmbAgentName.SelectedIndex > -1)
                {
                    if (cmbAgentName.SelectedIndex != 0 && cmbAgentName.SelectedIndex != 1)
                    {
                        TxnReportSearchDto.agentId = (long)cmbAgentName.SelectedValue;
                    }
                    else if (cmbAgentName.SelectedIndex == 1 || cmbAgentName.SelectedIndex == 0)
                    {
                        TxnReportSearchDto.agentId = 0;
                    }
                }
                if (this.cmbSubAgnetName.SelectedIndex > -1)
                {
                    if (cmbSubAgnetName.SelectedIndex != 0 && cmbSubAgnetName.SelectedIndex != 1)
                    {
                        TxnReportSearchDto.subAgentId = (long)cmbSubAgnetName.SelectedValue;
                    }
                    else if (cmbSubAgnetName.SelectedIndex == 1 || cmbSubAgnetName.SelectedIndex == 0)
                    {
                        TxnReportSearchDto.subAgentId = 0;
                    }
                }
                else TxnReportSearchDto.subAgentId = 0;

                if (cmbTransactionType.SelectedValue == "All") TxnReportSearchDto.agentService = null;
                else TxnReportSearchDto.agentService = (AgentServicesType)Enum.Parse(typeof(AgentServicesType), cmbTransactionType.SelectedValue.ToString());

                //TxnReportSearchDto.fromDate = Convert.ToDateTime(UtilityServices.GetLongDate(DateTime.ParseExact(dtpDateFrom.Date.Replace("/", "-"), "dd-MM-yyyy", CultureInfo.InvariantCulture)));
                //TxnReportSearchDto.toDate = Convert.ToDateTime(UtilityServices.GetLongDate(DateTime.ParseExact(dtpDateTo.Date.Replace("/", "-"), "dd-MM-yyyy", CultureInfo.InvariantCulture)));

                TxnReportSearchDto.fromDate = DateTime.ParseExact(dtpDateFrom.Date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                TxnReportSearchDto.toDate = DateTime.ParseExact(dtpDateTo.Date, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                return TxnReportSearchDto;
            }
            catch (Exception exp)
            { MessageBox.Show("Error filling search object.\n" + exp.Message); return null; }
        }
        private void btnShowReport_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validation
                DateTime fromDate, toDate;
                try
                {
                    //fromDate = UtilityServices.ParseDateTime(dtpFromDate.Date);                
                    fromDate = DateTime.ParseExact(dtpDateFrom.Date.Replace("/", "-"), "dd-MM-yyyy", CultureInfo.InvariantCulture);
                }
                catch
                {
                    MessageBox.Show("Please enter the Date in correct format.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                try
                {
                    //toDate = UtilityServices.ParseDateTime(dtpToDate.Date);
                    toDate = DateTime.ParseExact(dtpDateTo.Date.Replace("/", "-"), "dd-MM-yyyy", CultureInfo.InvariantCulture);
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

                if (cmbAgentName.SelectedIndex < 1)
                {
                    MessageBox.Show("Please select an agent.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                #endregion

                crTransactionReport report = new crTransactionReport();
                frmReportViewer viewer = new frmReportViewer();

                ReportHeaders rptHeaders = new ReportHeaders();
                rptHeaders = UtilityServices.getReportHeaders("Transaction Register");

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
                    txtPrintDate.Text = rptHeaders.printDate.ToString("dd/MM/yyyy").Replace("-", "/");
                }

                txtFromDate.Text = dtpDateFrom.Date;
                txtToDate.Text = dtpDateTo.Date;

                LoadTransactionRegisterData();

                if (!result.Success)
                {
                    MessageBox.Show("Report data loading error.\n" + result.Message);
                    return;
                }

                report.SetDataSource(_txnReportList);
                viewer.crvReportViewer.ReportSource = report;
                viewer.ShowDialog(this.Parent);
            }
            catch (Exception exp)
            { MessageBox.Show(exp.Message); }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }

    //public class TransactionTypeList
    //{
    //    public string txnTypeName { get; set; }
    //    //public TransactionType? txnType;
    //}
    public class AgentServicesTypeList
    {
        public string AgentServiceTypeName { get; set; }
    }

    public class TransactionReport
    {
        public long agentId = 0;
        public string agentName = "";
        public long subAgentId = 0;
        public string subAgentName = "";
        public string userName = "";

        public long txnId = 0;
        //public DateTime txnDate = new DateTime();
        public string txnDate = "";
        public string voucherNo = "";
        public decimal transactionAmount = 0;
        public decimal comissionAmount = 0;
        public string agentService = "";
        public string debitAccount = "";
        public string debitAccountTitle = "";
        public string creditAccount = "";
        public string creditAccountTitle = "";
        public string amountInWords = "";
    }

}
