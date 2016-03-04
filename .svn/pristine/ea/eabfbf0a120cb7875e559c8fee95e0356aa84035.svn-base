using CrystalDecisions.CrystalReports.Engine;
using MetroFramework.Forms;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using MISL.Ababil.Agent.Infrastructure.Models.dto;
using MISL.Ababil.Agent.Infrastructure.Models.reports;
using MISL.Ababil.Agent.Report.DataSets;
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
    public partial class frmAgentDayEndSummary : MetroForm
    {
        private GUI gui = new GUI();
        List<AgentInformation> objAgentInfoList = new List<AgentInformation>();
        AgentInformation agentInformation = new AgentInformation();
        AgentServices objAgentServices = new AgentServices();
        List<AgentDayEndSummeryDto> _agentDayEndSummeryDtoList = new List<AgentDayEndSummeryDto>();
        public AgentDayEndSummaryDS dayEndSummaryList = new AgentDayEndSummaryDS();

        public frmAgentDayEndSummary()
        {
            InitializeComponent();
            GetSetupData();
            try
            {
                cmbAgentName.SelectedIndex = 0;
            }
            catch
            {
            }
            controlActivity();
            ConfigUIEnhancement();
        }

        public void ConfigUIEnhancement()
        {
            gui = new GUI(this);
            gui.Config(ref cmbAgentName, ValidCheck.VALIDATIONTYPES.COMBOBOX_EMPTY, null);
            gui.Config(ref cmbSubAgnetName);
            gui.Config(ref dtpFromDate);

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
                    agentInformation = objAgentServices.getAgentInfoById(UtilityServices.getCurrentAgent().id.ToString());
                    setSubagent();
                }
                else
                {
                    SubAgentInformation currentSubagentInfo = UtilityServices.getCurrentSubAgent();
                    cmbAgentName.SelectedValue = currentSubagentInfo.agent.id;
                    agentInformation = objAgentServices.getAgentInfoById(currentSubagentInfo.agent.id.ToString());
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

        private void GetSetupData()
        {
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
            cmbAgentName.SelectedIndex = 0;
        }

        private void setSubagent()
        {
            if (agentInformation != null)
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = agentInformation.subAgents;

                {
                    try
                    {
                        SubAgentInformation saiSelect = new SubAgentInformation();
                        saiSelect.name = "(Select)";

                        SubAgentInformation saiAll = new SubAgentInformation();
                        saiAll.name = "(All)";

                        agentInformation.subAgents.Insert(0, saiSelect);
                        agentInformation.subAgents.Insert(1, saiAll);
                    }
                    catch
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
                    agentInformation = objAgentServices.getAgentInfoById(cmbAgentName.SelectedValue.ToString());
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
                //MessageBox.Show(ex.Message);
            }
            setSubagent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            showReport();
        }

        private void showReport()
        {
            if ((cmbAgentName.SelectedIndex > 0 && cmbSubAgnetName.SelectedIndex > 0) || cmbAgentName.SelectedIndex == 1)
            {
                crAgentDayEndSummary report = new crAgentDayEndSummary();
                frmReportViewer viewer = new frmReportViewer();

                ReportHeaders rptHeaders = new ReportHeaders();
                rptHeaders = UtilityServices.getReportHeaders("Agent Day End Summary");

                TextObject txtBankName = report.ReportDefinition.ReportObjects["txtBankName"] as TextObject;
                TextObject txtBranchName = report.ReportDefinition.ReportObjects["txtBranchName"] as TextObject;
                TextObject txtBranchAddress = report.ReportDefinition.ReportObjects["txtBranchAddress"] as TextObject;
                TextObject txtReportHeading = report.ReportDefinition.ReportObjects["txtReportHeading"] as TextObject;
                TextObject txtPrintUser = report.ReportDefinition.ReportObjects["txtPrintUser"] as TextObject;
                TextObject txtPrintDate = report.ReportDefinition.ReportObjects["txtPrintDate"] as TextObject;
                TextObject txtFromDate = report.ReportDefinition.ReportObjects["txtFromDate"] as TextObject;
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

                txtFromDate.Text = dtpFromDate.Date;
                loadAgentDayEndSummary();
                report.SetDataSource(dayEndSummaryList);
                viewer.crvReportViewer.ReportSource = report;
                viewer.ShowDialog(this.Parent);
            }
            else
            {
                MessageBox.Show("Please select an option!", "Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void showReportNull()
        {
            if ((cmbAgentName.SelectedIndex > 0 && cmbSubAgnetName.SelectedIndex > 0) || cmbAgentName.SelectedIndex == 1)
            {
                crAgentDayEndSummary report = new crAgentDayEndSummary();
                frmReportViewer viewer = new frmReportViewer();

                ReportHeaders rptHeaders = new ReportHeaders();
                rptHeaders = UtilityServices.getReportHeaders("Agent Day End Summary");

                TextObject txtBankName = report.ReportDefinition.ReportObjects["txtBankName"] as TextObject;
                TextObject txtBranchName = report.ReportDefinition.ReportObjects["txtBranchName"] as TextObject;
                TextObject txtBranchAddress = report.ReportDefinition.ReportObjects["txtBranchAddress"] as TextObject;
                TextObject txtReportHeading = report.ReportDefinition.ReportObjects["txtReportHeading"] as TextObject;
                TextObject txtPrintUser = report.ReportDefinition.ReportObjects["txtPrintUser"] as TextObject;
                TextObject txtPrintDate = report.ReportDefinition.ReportObjects["txtPrintDate"] as TextObject;
                TextObject txtFromDate = report.ReportDefinition.ReportObjects["txtFromDate"] as TextObject;
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
                    txtPrintDate.Text = rptHeaders.printDate.ToString("dd/MM/yyyy");
                }

                txtFromDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                loadAgentDayEndSummaryNull();
                report.SetDataSource(dayEndSummaryList);
                viewer.crvReportViewer.ReportSource = report;
                viewer.ShowDialog(this.Parent);
            }
            else
            {
                MessageBox.Show("Please select an option!", "Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void loadAgentDayEndSummaryNull()
        {
            dayEndSummaryList = new AgentDayEndSummaryDS();
            AccountSearchDto accountSearchDto = FillAccountSearchDtoNull();
            try
            {
                _agentDayEndSummeryDtoList = objAgentServices.getAgentDayEndSummaryDtoList(accountSearchDto);
                List<AgentDayEndSummaryDS> summaryList = new List<AgentDayEndSummaryDS>();

                for (int i = 0; i < _agentDayEndSummeryDtoList.Count; i++)
                {
                    AgentDayEndSummaryDS.AgentDayEndSummeryRow summaryRow = dayEndSummaryList.AgentDayEndSummery.NewAgentDayEndSummeryRow();
                    summaryRow.agentId = _agentDayEndSummeryDtoList[i].agentId;
                    summaryRow.agentName = _agentDayEndSummeryDtoList[i].agentName;
                    summaryRow.subAgentId = _agentDayEndSummeryDtoList[i].subAgentId;
                    summaryRow.subAgentName = _agentDayEndSummeryDtoList[i].subAgentName;
                    summaryRow.serviceName = _agentDayEndSummeryDtoList[i].serviceName;
                    summaryRow.id = _agentDayEndSummeryDtoList[i].id; //setServiceOrder(_agentDayEndSummeryDtoList[i].serviceName);
                    if (_agentDayEndSummeryDtoList[i].cashReceive != null)
                    {
                        summaryRow.cashReceive = (decimal)_agentDayEndSummeryDtoList[i].cashReceive;
                        summaryRow.cashReceiveStr = ((decimal)_agentDayEndSummeryDtoList[i].cashReceive).ToString("N");
                        if (summaryRow.id == 1)
                            summaryRow.cashReceiveStr = "";
                    }
                    else
                    {
                        summaryRow.cashReceive = 0;
                        summaryRow.cashReceiveStr = "";
                    }
                    if (_agentDayEndSummeryDtoList[i].cashPayment != null)
                    {
                        summaryRow.cashPayment = (decimal)_agentDayEndSummeryDtoList[i].cashPayment;
                        summaryRow.cashPaymentStr = ((decimal)_agentDayEndSummeryDtoList[i].cashPayment).ToString("N");
                    }
                    else
                    {
                        summaryRow.cashPayment = 0;
                        summaryRow.cashPaymentStr = "";
                    }
                    //if (_agentDayEndSummeryDtoList[i].closingBalance != null)
                    //{
                    //    summaryRow.closingBalance = (decimal)_agentDayEndSummeryDtoList[i].closingBalance;
                    //    summaryRow.cosingBalanceStr = ((decimal)_agentDayEndSummeryDtoList[i].closingBalance).ToString("N");
                    //}
                    //else
                    //{
                    //    summaryRow.closingBalance = 0;
                    //    summaryRow.cosingBalanceStr = "";
                    //}

                    dayEndSummaryList.AgentDayEndSummery.AddAgentDayEndSummeryRow(summaryRow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadAgentDayEndSummary()
        {
            dayEndSummaryList = new AgentDayEndSummaryDS();
            AccountSearchDto accountSearchDto = FillAccountSearchDto();
            try
            {
                _agentDayEndSummeryDtoList = objAgentServices.getAgentDayEndSummaryDtoList(accountSearchDto);
                List<AgentDayEndSummaryDS> summaryList = new List<AgentDayEndSummaryDS>();
                #region MyRegion
                //Adding initial balance
                //AgentDayEndSummaryDS.AgentDayEndSummeryRow previousBalanceRow = dayEndSummaryList.AgentDayEndSummery.NewAgentDayEndSummeryRow();
                //previousBalanceRow.agentId = _agentDayEndSummeryDtoList[0].agentId;
                //previousBalanceRow.agentName = _agentDayEndSummeryDtoList[0].agentName;
                //previousBalanceRow.subAgentId = _agentDayEndSummeryDtoList[0].subAgentId;
                //previousBalanceRow.subAgentName = _agentDayEndSummeryDtoList[0].subAgentName;
                //previousBalanceRow.serviceName = "Previous Cash Balance(previous date)";
                //previousBalanceRow.cashReceive = 0;
                //previousBalanceRow.cashReceiveStr = "";
                //previousBalanceRow.cashPayment = 0;
                //previousBalanceRow.cashPaymentStr = "";
                ////previousBalanceRow.closingBalance = (decimal)_agentDayEndSummeryDtoList[0].closingBalance;
                ////previousBalanceRow.cosingBalanceStr = ((decimal)_agentDayEndSummeryDtoList[0].closingBalance).ToString("N");
                //previousBalanceRow.id = 0;
                //dayEndSummaryList.AgentDayEndSummery.AddAgentDayEndSummeryRow(previousBalanceRow);

                //Adding other services     
                #endregion

                for (int i = 0; i < _agentDayEndSummeryDtoList.Count; i++)
                {
                    AgentDayEndSummaryDS.AgentDayEndSummeryRow summaryRow = dayEndSummaryList.AgentDayEndSummery.NewAgentDayEndSummeryRow();
                    summaryRow.agentId = _agentDayEndSummeryDtoList[i].agentId;
                    summaryRow.agentName = _agentDayEndSummeryDtoList[i].agentName;
                    summaryRow.subAgentId = _agentDayEndSummeryDtoList[i].subAgentId;
                    summaryRow.subAgentName = _agentDayEndSummeryDtoList[i].subAgentName;
                    summaryRow.serviceName = _agentDayEndSummeryDtoList[i].serviceName;
                    summaryRow.id = _agentDayEndSummeryDtoList[i].id; //setServiceOrder(_agentDayEndSummeryDtoList[i].serviceName);
                    if (_agentDayEndSummeryDtoList[i].cashReceive != null)
                    {
                        summaryRow.cashReceive = (decimal)_agentDayEndSummeryDtoList[i].cashReceive;
                        summaryRow.cashReceiveStr = ((decimal)_agentDayEndSummeryDtoList[i].cashReceive).ToString("N");
                        if (summaryRow.id == 1)
                            summaryRow.cashReceiveStr = "";
                    }
                    else
                    {
                        summaryRow.cashReceive = 0;
                        summaryRow.cashReceiveStr = "";
                    }
                    if (_agentDayEndSummeryDtoList[i].cashPayment != null)
                    {
                        summaryRow.cashPayment = (decimal)_agentDayEndSummeryDtoList[i].cashPayment;
                        summaryRow.cashPaymentStr = ((decimal)_agentDayEndSummeryDtoList[i].cashPayment).ToString("N");
                    }
                    else
                    {
                        summaryRow.cashPayment = 0;
                        summaryRow.cashPaymentStr = "";
                    }
                    //if (_agentDayEndSummeryDtoList[i].closingBalance != null)
                    //{
                    //    summaryRow.closingBalance = (decimal)_agentDayEndSummeryDtoList[i].closingBalance;
                    //    summaryRow.cosingBalanceStr = ((decimal)_agentDayEndSummeryDtoList[i].closingBalance).ToString("N");
                    //}
                    //else
                    //{
                    //    summaryRow.closingBalance = 0;
                    //    summaryRow.cosingBalanceStr = "";
                    //}

                    dayEndSummaryList.AgentDayEndSummery.AddAgentDayEndSummeryRow(summaryRow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private int setServiceOrder(string serviceName)
        {
            switch (serviceName)
            {
                case "Previous Cash Balance(previous date)":
                    {
                        return 1;
                    }
                case "CashDeposit":
                    {
                        return 2;
                    }
                case "CashWithdraw":
                    {
                        return 3;
                    }
                case "Remittance":
                    {
                        return 4;
                    }
                case "Utility Bill Collection":
                    {
                        return 5;
                    }
                case "Commission Receive in Cash":
                    {
                        return 6;
                    }
                case "Cash Receive From Agent":
                    {
                        return 7;
                    }
                case "Cash Payment to Agent":
                    {
                        return 8;
                    }
                default:
                    return 0;
            }
        }

        private AccountSearchDto FillAccountSearchDtoNull()
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
                    accountSearchDto.agent = null; // all Agent
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
                    accountSearchDto.subAgent = null; // all SubAgent
                }
            }

            accountSearchDto.product = null; //AgentProduct is not to be selected for this report
            //accountSearchDto.toDate = UtilityServices.GetLongDate(dtpFromDate.Value);

            //accountSearchDto.toDate = UtilityServices.GetLongDate(this.dtpFromDate.Value);
            return accountSearchDto;
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
                    accountSearchDto.agent = null; // all Agent
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
                    accountSearchDto.subAgent = null; // all SubAgent
                }
            }

            accountSearchDto.product = null; //AgentProduct is not to be selected for this report

            //accountSearchDto.toDate = UtilityServices.GetLongDate(UtilityServices.ParseDateTime(this.dtpFromDate.Date));
            accountSearchDto.toDate = UtilityServices.GetLongDate
            (
                DateTime.ParseExact(dtpFromDate.Date.Replace("/", "-"), "dd-MM-yyyy", CultureInfo.InvariantCulture)
            );
            
            return accountSearchDto;
        }

        private void frmAgentDayEndSummary_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = SessionInfo.currentDate;
        }
    }
}