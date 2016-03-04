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
using MISL.Ababil.Agent.Module.Common.UI.MessageUI;

namespace MISL.Ababil.Agent.Report
{
    public partial class frmAgentCashInformationReport : MetroForm
    {
        List<AgentInformation> objAgentInfoList = new List<AgentInformation>();
        AgentServices agentServices = new AgentServices();
        AgentInformation agentInformation = new AgentInformation();
        ServiceResult result;
        public frmAgentCashInformationReport()
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
                AgentInformation agAll = new AgentInformation();
                agAll.businessName = "All";
                objAgentInfoList.Insert(1, agAll);

                UtilityServices.fillComboBox(cmbAgentName, bsAgent, "businessName", "id");
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
                MessageBox.Show(ex.Message);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SerachValidetionCheck()
        {
            DateTime tmpDate = new DateTime();
            try
            {
                tmpDate = DateTime.ParseExact(dtpDate.Date.ToString().Replace("/", "-"), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            }
            catch
            {
                MsgBox.showWarning("Please enter the Date in correct format.");
                return;
            }

            if (tmpDate > SessionInfo.currentDate)
            {
                MsgBox.showWarning("Future date not allow!!.");
                return;
            }


            if (cmbAgentName.SelectedIndex < 1)
            {
                MsgBox.showWarning("Please select an agent.");
                return;
            }
        }
        private void btnViewReport_Click(object sender, EventArgs e)
        {
            try
            {
                SerachValidetionCheck();
                //frmAgentBalance frm = new frmAgentBalance();

                #region Commented
                // crAgentCashInformationReport report = new crAgentCashInformationReport();
               // frmReportViewer viewer = new frmReportViewer();

               // ReportHeaders rptHeaders = new ReportHeaders();
               // rptHeaders = UtilityServices.getReportHeaders("Cheque Requisition Report");

               // TextObject txtBankName = report.ReportDefinition.ReportObjects["txtBankName"] as TextObject;
               // TextObject txtBranchName = report.ReportDefinition.ReportObjects["txtBranchName"] as TextObject;
               // TextObject txtBranchAddress = report.ReportDefinition.ReportObjects["txtBranchAddress"] as TextObject;
               // TextObject txtReportHeading = report.ReportDefinition.ReportObjects["txtReportHeading"] as TextObject;
               // TextObject txtPrintUser = report.ReportDefinition.ReportObjects["txtPrintUser"] as TextObject;
               // TextObject txtPrintDate = report.ReportDefinition.ReportObjects["txtPrintDate"] as TextObject;
               // //TextObject txtFromDate = report.ReportDefinition.ReportObjects["txtDate"] as TextObject;
               // //TextObject txtToDate = report.ReportDefinition.ReportObjects["txtToDate"] as TextObject;

               // if (rptHeaders != null)
               // {
               //     if (rptHeaders.branchDto != null)
               //     {
               //         txtBankName.Text = rptHeaders.branchDto.bankName;
               //         txtBranchName.Text = rptHeaders.branchDto.branchName;
               //         txtBranchAddress.Text = rptHeaders.branchDto.branchAddress;
               //     }
               //     txtReportHeading.Text = rptHeaders.reportHeading;
               //     txtPrintUser.Text = rptHeaders.printUser;
               //     txtPrintDate.Text = rptHeaders.printDate.ToString("dd/MM/yyyy").Replace("-", "/");
               // }

               // // txtFromDate.Text = dtpDateFrom.Date;
               // // txtToDate.Text = dtpDateTo.Date;

               // // LoadChequeRequisitionRegisterData();

               // if (!result.Success)
               // {
               //     MessageBox.Show("Report data loading error.\n" + result.Message);
               //     return;
               // }

               //// report.SetDataSource(_chqRequisitionReportList);
               // viewer.crvReportViewer.ReportSource = report;
                // viewer.ShowDialog();
                #endregion
            }
            catch (Exception exp)
            { MessageBox.Show(exp.Message); }
        }
    }
}
