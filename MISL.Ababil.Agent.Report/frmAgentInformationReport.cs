using CrystalDecisions.CrystalReports.Engine;
using MetroFramework.Forms;
using MISL.Ababil.Agent.Infrastructure;
using MISL.Ababil.Agent.Infrastructure.Models.reports;
using MISL.Ababil.Agent.Module.Common.UI.MessageUI;
using MISL.Ababil.Agent.Report.Reports;
using MISL.Ababil.Agent.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MISL.Ababil.Agent.Report
{
    public partial class frmAgentInformationReport : MetroForm
    {
        ServiceResult result;
        List<AgentInformationReport> _agentInfoReportList = new List<AgentInformationReport>();
        AgentServices agentService = new AgentServices();
        public frmAgentInformationReport()
        {
            InitializeComponent();
        }
        public void loadAgentInformation()
        {
            try
            {
                _GetReportData();

                crAgentInformationReport report = new crAgentInformationReport();
                frmReportViewer frm = new frmReportViewer();
                ReportHeaders rptHeaders = new ReportHeaders();
                rptHeaders = UtilityServices.getReportHeaders("Agent Information Report");

                TextObject txtBankName = report.ReportDefinition.ReportObjects["txtBankName"] as TextObject;
                TextObject txtBranchName = report.ReportDefinition.ReportObjects["txtBranchName"] as TextObject;
                TextObject txtBranchAddress = report.ReportDefinition.ReportObjects["txtBranchAddress"] as TextObject;
                TextObject txtReportHeading = report.ReportDefinition.ReportObjects["txtReportHeading"] as TextObject;
                TextObject txtPrintUser = report.ReportDefinition.ReportObjects["txtPrintUser"] as TextObject;
                TextObject txtPrintDate = report.ReportDefinition.ReportObjects["txtPrintDate"] as TextObject;
                //TextObject txtFromDate = report.ReportDefinition.ReportObjects["txtFromDate"] as TextObject;
                //TextObject txtToDate = report.ReportDefinition.ReportObjects["txtToDate"] as TextObject;

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
                report.SetDataSource(_agentInfoReportList);

                #region harun======(22-09-15)===
                // txtFromDate.Text = mtbFromDate.Text.ToString();
                //txtToDate.Text = mtbToDate.Text.ToString();

                // txtFromDate.Text = dtpFromDate.Date;
                //txtToDate.Text = dtpToDate.Date;
                #endregion

                frm.crvReportViewer.ReportSource = report;
                frm.ShowDialog();
            }
            catch (Exception exp)
            { MsgBox.showError(exp.Message); }
        }
        private void _GetReportData()
        {
            AgentInformationReport agentInfoReportRow;
            _agentInfoReportList = new List<AgentInformationReport>();
            try
            {
                result = agentService.getAgentInformationReportList();
                if (result.Success)
                {
                    List<AgentReportDto> agentReportResult = result.ReturnedObject as List<AgentReportDto>;
                    if (agentReportResult != null)
                    {
                        foreach (AgentReportDto agentRecord in agentReportResult)
                        {
                            agentInfoReportRow = new AgentInformationReport();
                            agentInfoReportRow.id = agentRecord.id;
                            agentInfoReportRow.agentCode = agentRecord.agentCode;
                            agentInfoReportRow.businessName = agentRecord.businessName;
                            agentInfoReportRow.accountNo = agentRecord.accountNo;
                            agentInfoReportRow.contactNo = agentRecord.contactNo;
                            agentInfoReportRow.address = agentRecord.address;
                            //agentInfoReportRow.creationDate = agentRecord.creationDate;
                            //agentInfoReportRow.creationDate = UtilityServices.getDateFromLong(agentRecord.creationDate);
                            agentInfoReportRow.creationDate = UtilityServices.getBDFormattedDateFromLong(agentRecord.creationDate);
                            agentInfoReportRow.noOfOutlet = agentRecord.noOfOutlet;

                            _agentInfoReportList.Add(agentInfoReportRow);
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                throw;
                //MessageBox.Show("Report data loading error.\n" + exp.Message);
            }
        }
    }
    public class AgentInformationReport
    {
        public long id = 0;
        public string agentCode = "";
        public string businessName = "";
        public string accountNo = "";
        public string contactNo = "";
        public string address = "";
        public string creationDate = "";
        public int noOfOutlet = 0;
    }
}
