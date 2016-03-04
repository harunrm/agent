using CrystalDecisions.CrystalReports.Engine;
using MetroFramework.Forms;
using MISL.Ababil.Agent.Infrastructure;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using MISL.Ababil.Agent.Infrastructure.Models.reports;
using MISL.Ababil.Agent.Report.Reports;
using MISL.Ababil.Agent.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MISL.Ababil.Agent.Report
{
    public partial class frmItdBalancOutstanding : MetroForm
    {
        List<AgentInformation> objAgentInfoList = new List<AgentInformation>();
        AgentServices agentServices = new AgentServices();
        AgentInformation agentInformation = new AgentInformation();
        TransactionService transactionService = new TransactionService();
        ServiceResult result;
       // List<ChequeRequisitionReportResultDto> chqRequisitionReportResult;

       // public List<ChequeRequisitionReport> _chqRequisitionReportList = new List<ChequeRequisitionReport>();
        public frmItdBalancOutstanding()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            //Date validation
            DateTime fromDate, toDate;
            try
            {
             
                fromDate = DateTime.ParseExact(dtpFromDate.Date.Replace("/", "-"), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            }
            catch
            {
                MessageBox.Show("Please enter the Date in correct format.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {

                toDate = DateTime.ParseExact(dtpToDate.Date.Replace("/", "-"), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            }
            catch
            {
                MessageBox.Show("Please enter the Date in correct format.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (fromDate > toDate)
            {
                MessageBox.Show("From date can not be greater than to date.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if ((cmbAgentName.SelectedIndex > 0 && cmbSubAgnetName.SelectedIndex > 0) || cmbAgentName.SelectedIndex == 1)
            {
                crAgentIncomeStatement report = new crAgentIncomeStatement();
                frmReportViewer viewer = new frmReportViewer();

                ReportHeaders rptHeaders = new ReportHeaders();
                rptHeaders = UtilityServices.getReportHeaders("Agent Income Statement");

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
                    txtPrintDate.Text = rptHeaders.printDate.ToString("dd-MM-yyyy").Replace("-", "/");
                }
                #region harun======(22-09-15)===
                //txtFromDate.Text = mtbFromDate.Text.ToString();
                //txtToDate.Text = mtbToDate.Text.ToString();
                #endregion
                txtFromDate.Text = dtpFromDate.Date;
                txtToDate.Text = dtpToDate.Date;

                //loadAgentIncomeStatement();

                //report.SetDataSource(_agentIncomeStatList);

                viewer.crvReportViewer.ReportSource = report;
                viewer.ShowDialog(this.Parent);
            }
            else
            {
                MessageBox.Show("Please select an option!", "Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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
                AgentInformation agAll = new AgentInformation();
                agAll.businessName = "All";
                objAgentInfoList.Insert(1, agAll);

                UtilityServices.fillComboBox(cmbAgentName, bsAgent, "businessName", "id");
                //cmbAgentName.Text = "Select";
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

        //private List<ChequeRequisitionReportResultDto> LoadItdBalanceOutstandingData()
        //{
        //    ChequeRequisitionService service = new ChequeRequisitionService();
        //    ChequeRequisitionReport chqRequisitionRow;
        //    _chqRequisitionReportList = new List<ChequeRequisitionReport>();

        //    ChequeRequisitionReportSearchDto requisitionReportSearchDto = FillTxnReportSearchDto();
        //    try
        //    {
        //        chqRequisitionReportResult = service.getChequeRequisitionReport(requisitionReportSearchDto);
        //        //return chqRequisitionReportResult;
        //        // if (result.Success)
        //        //if (result != null)
        //        //   {
        //        //List<ChequeRequisitionReportResultDto> txnReportResult = result.ReturnedObject as List<ChequeRequisitionReportResultDto>;

        //        if (chqRequisitionReportResult != null)
        //        {
        //            foreach (ChequeRequisitionReportResultDto chqRecord in chqRequisitionReportResult)
        //            {
        //                chqRequisitionRow = new ChequeRequisitionReport();
        //                chqRequisitionRow.agentId = chqRecord.agentId;
        //                chqRequisitionRow.agentName = chqRecord.agentName;
        //                chqRequisitionRow.subAgentId = chqRecord.subAgentId;
        //                chqRequisitionRow.subAgentName = chqRecord.subAgentName;
        //                chqRequisitionRow.accountNumber = chqRecord.accountNumber;
        //                chqRequisitionRow.accountTitle = chqRecord.accountTitle;
        //                chqRequisitionRow.noOfLeaf = chqRecord.noOfLeaf;
        //                chqRequisitionRow.chequeDeliveryMedium = chqRecord.chequeDeliveryMedium.ToString();
        //                chqRequisitionRow.deliveryFrom = chqRecord.deliveryFrom;
        //                chqRequisitionRow.requestDate = UtilityServices.getBDFormattedDateFromLong(chqRecord.requestDate);
        //                chqRequisitionRow.chequeRequisitionStatus = chqRecord.chequeRequisitionStatus.ToString();
        //                chqRequisitionRow.subAgentCode = chqRecord.subAgentCode;


        //                _chqRequisitionReportList.Add(chqRequisitionRow);
        //            }
        //        }
        //        // return _chqRequisitionReportList;
        //        //}
        //        return chqRequisitionReportResult;
        //    }
        //    catch (Exception exp)
        //    {
        //        MessageBox.Show("Report data loading error.\n" + exp.Message);
        //        return null;
        //    }
        //}
        //private ChequeRequisitionReportSearchDto FillTxnReportSearchDto()
        //{
        //    ChequeRequisitionReportSearchDto chqReportSearchDto = new ChequeRequisitionReportSearchDto();
        //    try
        //    {
        //        if (this.cmbAgentName.SelectedIndex > -1)
        //        {
        //            if (cmbAgentName.SelectedIndex != 0 && cmbAgentName.SelectedIndex != 1)
        //            {
        //                chqReportSearchDto.agentId = (long)cmbAgentName.SelectedValue;
        //            }
        //            else if (cmbAgentName.SelectedIndex == 1 || cmbAgentName.SelectedIndex == 0)
        //            {
        //                chqReportSearchDto.agentId = 0;
        //            }
        //        }
        //        if (this.cmbSubAgnetName.SelectedIndex > -1)
        //        {
        //            if (cmbSubAgnetName.SelectedIndex != 0 && cmbSubAgnetName.SelectedIndex != 1)
        //            {
        //                chqReportSearchDto.subAgentId = (long)cmbSubAgnetName.SelectedValue;
        //            }
        //            else if (cmbSubAgnetName.SelectedIndex == 1 || cmbSubAgnetName.SelectedIndex == 0)
        //            {
        //                chqReportSearchDto.subAgentId = 0;
        //            }
        //        }
        //        else chqReportSearchDto.subAgentId = 0;

        //        if (cmbUrgencyType.SelectedValue == "All") chqReportSearchDto.urgencyType = null;
        //        else chqReportSearchDto.urgencyType = (UrgencyType)Enum.Parse(typeof(UrgencyType), cmbUrgencyType.SelectedValue.ToString());

        //        //TxnReportSearchDto.fromDate = Convert.ToDateTime(UtilityServices.GetLongDate(DateTime.ParseExact(dtpDateFrom.Date.Replace("/", "-"), "dd-MM-yyyy", CultureInfo.InvariantCulture)));
        //        //TxnReportSearchDto.toDate = Convert.ToDateTime(UtilityServices.GetLongDate(DateTime.ParseExact(dtpDateTo.Date.Replace("/", "-"), "dd-MM-yyyy", CultureInfo.InvariantCulture)));

        //        chqReportSearchDto.fromDate = DateTime.ParseExact(dtpDateFrom.Date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        //        chqReportSearchDto.toDate = DateTime.ParseExact(dtpDateTo.Date, "dd/MM/yyyy", CultureInfo.InvariantCulture);

        //        return chqReportSearchDto;
        //    }
        //    catch (Exception exp)
        //    { MessageBox.Show("Error filling search object.\n" + exp.Message); return null; }
        //}
    }

}
