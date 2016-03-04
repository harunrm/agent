using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MetroFramework.Forms;
using MISL.Ababil.Agent.Infrastructure;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.dto;
using MISL.Ababil.Agent.Services;
using MISL.Ababil.Agent.Report.Reports;
using MISL.Ababil.Agent.Infrastructure.Models.reports;
using CrystalDecisions.CrystalReports.Engine;
using MISL.Ababil.Agent.Report.DataSets;
using System.Globalization;

namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmAgentBalance : MetroForm
    {
        private Packet _packet;
        private long _agentId;
        ServiceResult result;
        AgentServices agentService = new AgentServices();
        AgentBalanceDto _agentBalance;
        Chart pieChart = new Chart();
        List<AgentBalanceDto> _agentBalanceList;
        AgentCashInformationDS _agentBalnaceDS;
        DateTime _informationDate;
        public frmAgentBalance()
        {
            InitializeComponent();
            //FillComponents(SessionInfo.userBasicInformation.agent.id, DateTime.Today);
            bool isSuccess = FillComponents(0, DateTime.Today);
            if (!isSuccess) this.Close();
        }
        public frmAgentBalance(Packet packet, long agentId, DateTime date)
        {
            InitializeComponent();
            _informationDate = date;
            _agentId = agentId;
            bool isSuccess = FillComponents(_agentId, date);
            if (!isSuccess) this.Close();
        }

        private bool FillComponents(long agentId, DateTime date)
        {
            try
            {
                lblDate.Text = date.ToString("dd/MM/yyyy");
                AgentBalanceReqDto reqDto = new AgentBalanceReqDto();
                reqDto.agentId = agentId;
                reqDto.informationDate = date;
                result = agentService.getAgentBalanceDetails(reqDto);
                if (result.Success)
                {
                    _agentBalance = result.ReturnedObject as AgentBalanceDto;
                    int rowIndex = 0;
                    decimal outletTotal = 0;
                    foreach (OutletBalanceDto outlet in _agentBalance.outletBalanceList)
                    {
                        dgvOutletCashInfo.Rows.Add();
                        dgvOutletCashInfo["gvColSubAgentCode", rowIndex].Value = outlet.subAgentCode;
                        dgvOutletCashInfo["gvColSubAgentName", rowIndex].Value = outlet.name;
                        dgvOutletCashInfo["gvColMobleNumber", rowIndex].Value = outlet.mobleNumber;
                        dgvOutletCashInfo["gvColCurrentBalance", rowIndex].Value = outlet.currentBalance.ToString("N", new CultureInfo("BN-BD"));
                        dgvOutletCashInfo["gvColSubAgentID", rowIndex].Value = outlet.id;
                        outletTotal += outlet.currentBalance;
                        rowIndex++;
                    }

                    dgvOutletCashInfo.Columns[0].DefaultCellStyle.Alignment = dgvOutletCashInfo.Columns[1].DefaultCellStyle.Alignment =
                        dgvOutletCashInfo.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvOutletCashInfo.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    dgvOutletCashInfo.Refresh();
                    lblAgentCode.Text = _agentBalance.agentCode;
                    lblAgentName.Text = _agentBalance.businessName;
                    lblOutletTotal.Text = outletTotal.ToString("N", new CultureInfo("BN-BD")) + " BDT";
                    lblAgentAccBalance.Text = _agentBalance.accountBalance.ToString("N", new CultureInfo("BN-BD")) + " BDT";
                    lblGrandTotal.Text = (outletTotal + _agentBalance.accountBalance).ToString("N", new CultureInfo("BN-BD")) + " BDT";

                    lblOutletTotal.TextAlign = lblAgentAccBalance.TextAlign = lblGrandTotal.TextAlign = ContentAlignment.MiddleRight;

                    LoadPieChart(_agentBalance.accountBalance, outletTotal);
                    return true;
                }
                else
                { Message.showError("Data loading error!\n" + result.Message); return false; }
            }
            catch(Exception exp)
            {throw;}
        }
        void LoadPieChart(decimal agentBalance, decimal outletTotalBalance)
        {
            chartBalance.Series[0].Points.Clear();
            DataPoint dataPointAgentBalance = new DataPoint();
            DataPoint dataPointOutletBalance = new DataPoint();

            dataPointAgentBalance.SetValueY(Convert.ToDouble(agentBalance));
            dataPointOutletBalance.SetValueY(Convert.ToDouble(outletTotalBalance));

            chartBalance.Series[0].Points.Add(dataPointAgentBalance);
            lblPieAgentBalance.Text += "\n" + agentBalance.ToString();
            //chartBalance.Series[0].Points[0].Label = agentBalance.ToString();
            chartBalance.Series[0].Points.Add(dataPointOutletBalance);
            //chartBalance.Series[0].Points[1].Label = outletTotalBalance.ToString();
            lblPieOutletTotal.Text += "\n" + outletTotalBalance.ToString();
            chartBalance.Update();

            lblPieColorAgent.BackColor = Color.FromArgb(65, 140, 241);
            lblPieColorOutlet.BackColor = Color.FromArgb(251, 180, 64);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void btnPrint_Click(object sender, EventArgs e)
        {
             _agentBalnaceDS = new AgentCashInformationDS();
             try
             {
                 if (_agentBalance != null)
                 {
                     crAgentCashInformationReport report = new crAgentCashInformationReport();
                     frmReportViewer viewer = new frmReportViewer();

                     ReportHeaders rptHeaders = new ReportHeaders();
                     rptHeaders = UtilityServices.getReportHeaders("Agent Cash Information");

                     TextObject txtBankName = report.ReportDefinition.ReportObjects["txtBankName"] as TextObject;
                     TextObject txtBranchName = report.ReportDefinition.ReportObjects["txtBranchName"] as TextObject;
                     TextObject txtBranchAddress = report.ReportDefinition.ReportObjects["txtBranchAddress"] as TextObject;
                     TextObject txtReportHeading = report.ReportDefinition.ReportObjects["txtReportHeading"] as TextObject;
                     TextObject txtPrintUser = report.ReportDefinition.ReportObjects["txtPrintUser"] as TextObject;
                     TextObject txtPrintDate = report.ReportDefinition.ReportObjects["txtPrintDate"] as TextObject;

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

                     LoadAccountMonitoring();

                     report.SetDataSource(_agentBalnaceDS);
                     viewer.crvReportViewer.ReportSource = report;
                     viewer.ShowDialog(this.Parent);
                 }
             }
             catch (Exception exp)
             {
                 MessageBox.Show("Report data loading error.\n" + exp.Message);
                 
             }


        }

        private void LoadAccountMonitoring()
        {
            if (_agentBalance.outletBalanceList != null)
            {
                foreach (OutletBalanceDto account in _agentBalance.outletBalanceList)
                {
                    AgentCashInformationDS.AgentCashInfoDTRow newRow = _agentBalnaceDS.AgentCashInfoDT.NewAgentCashInfoDTRow();
                    newRow.subAgentCode = account.subAgentCode;
                    newRow.name = account.name;
                    newRow.businessAddress = account.businessAddress;
                    newRow.currentBalance = account.currentBalance;
                    newRow.mobleNumber = account.mobleNumber;

                    newRow.agentCode = _agentBalance.agentCode;
                    newRow.accountNo = _agentBalance.accountNo;
                    newRow.accountBalance = _agentBalance.accountBalance;
                    newRow.contactNo = _agentBalance.contactNo;
                    newRow.businessName = _agentBalance.businessName;

                    _agentBalnaceDS.AgentCashInfoDT.AddAgentCashInfoDTRow(newRow);
                }
            }

            _agentBalnaceDS.AcceptChanges();
        }

        private void dgvOutletCashInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3)  // Cash Balance
                {
                    OutletCashSumReqDto reqDto = new OutletCashSumReqDto();
                    reqDto.informationDate = _informationDate;
                    reqDto.outletId = _agentBalance.outletBalanceList[e.RowIndex].id;

                    Packet packet = new Packet();
                    packet.actionType = FormActionType.View;
                    packet.intentType = IntentType.Request;

                    frmOutletCashInfo outletCash = new frmOutletCashInfo(packet, reqDto);
                    outletCash.ShowDialog();
                }
            }
            catch (Exception exp)
            { Message.showError(exp.Message); }
        }

    }

}
