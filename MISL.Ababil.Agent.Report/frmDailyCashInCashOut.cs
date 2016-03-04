using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using MISL.Ababil.Agent.Infrastructure.Models.models.transaction;
using MISL.Ababil.Agent.Infrastructure.Models.reports;
using MISL.Ababil.Agent.Report.DataSets;
using MISL.Ababil.Agent.Report.Reports;
using MISL.Ababil.Agent.Services;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MetroFramework.Forms;


namespace MISL.Ababil.Agent.Report
{
    public partial class frmDailyCashInCashOut : MetroForm
    {
        List<AgentInformation> objAgentInfoList = new List<AgentInformation>();
        AgentInformation agentInformation = new AgentInformation();
        List<SubAgentInformation> objSubtInfoList = new List<SubAgentInformation>();
        SubAgentServices objSubServices = new SubAgentServices();
        List<TransactionRecord> trnList = new List<TransactionRecord>();
        TransactionService transactionService = new TransactionService();
        AgentServices agentServices = new AgentServices();
        public frmDailyCashInCashOut()
        {
            InitializeComponent();
            GetSetupData();
            fillReportType();
            controlActivity();

            mtbDate.Text = dtpDate.Value.ToString("dd-MM-yyyy");
        }
        private void controlActivity()
        {
            try
            {
                if (SessionInfo.rights.Contains(Rights.REPORT_VIEW_CENTRALLY.ToString())) //branch user
                {
                    cmbAgentName.Enabled = true;
                    cmbSubAgentName.Enabled = true;
                }
                else if (SessionInfo.rights.Contains(Rights.REPORT_VIEW_AGENTWISE.ToString())) //agent user
                {
                    cmbAgentName.SelectedValue = UtilityServices.getCurrentAgent().id;
                    cmbAgentName.Enabled = false;
                }
                else
                {
                    SubAgentInformation currentSubagentInfo = UtilityServices.getCurrentSubAgent();
                    cmbAgentName.SelectedValue = currentSubagentInfo.agent.id;
                    agentInformation = agentServices.getAgentInfoById(currentSubagentInfo.agent.id.ToString());
                    setSubagent();
                    cmbAgentName.Enabled = false;
                    cmbSubAgentName.SelectedValue = currentSubagentInfo.id;
                    cmbSubAgentName.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //cmbAgentName.Enabled = true;
                //cmbSubAgentName.Enabled = true;
            }
        }
        private void btnShowReport_Click(object sender, EventArgs e)
        {
            //checking for valid date
            try
            {
                string[] str = mtbDate.Text.Split('-');
                DateTime d = new DateTime(int.Parse(str[2].Trim()), int.Parse(str[1].Trim()), int.Parse(str[0].Trim()));
                dtpDate.Value = d;
            }
            catch
            {
                MessageBox.Show("Please enter the Date in correct format.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (isValidRequest())
            {
                String selectedText = cmbTransactionType.Text;


                if (selectedText == "Deposite")
                {
                    try
                    {
                        DepositReportDto TrnDateDto = new DepositReportDto();
                        //TrnDateDto.accountNumber=
                        ////if (cmbAgentName.Text != null)
                        //    TrnDateDto.subAgentUserName = cmbSubAgentName.Text;

                        //trnList = transactionService.getDailyDipositTransactionReocrd(TrnDateDto);
                        //ShowTransectionRecord(trnList);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                //else if (selectedText == "Withdraw")
                //{

                //}
                //else if (selectedText == "Money Transfer")
                //{

                //}
                //else if (selectedText == "Remittance")
                //{

                //}


            }
        }
        private bool isValidRequest()
        {

            String selectedText = cmbTransactionType.Text;

            if (selectedText == "Select")
            {
                System.Windows.Forms.MessageBox.Show("Please, select report type.");
                return false;
            }

            return true;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void ShowTransectionRecord(List<TransactionRecord> trnsectionList)
        {
            try
            {
                // Set Crystal Report data.
                crDaillyCashInCashOut objRpt = new crDaillyCashInCashOut();
                TransactionRecordDS trnDS = new TransactionRecordDS();
                frmReportViewer frm = new frmReportViewer();

                if (trnsectionList != null)
                {

                    if (trnsectionList.Count > 0)
                    {

                        for (int i = 0; i < trnsectionList.Count; i++)
                        {
                            TransactionRecordDS.TransactionRecordRow row = trnDS.TransactionRecord.NewTransactionRecordRow();

                            row.transactionDate = trnsectionList[i].transactionDate;
                            if (trnsectionList[i].agentServices == AgentServicesType.CashDeposit)
                            {
                                row.amountDeposit = trnsectionList[i].amount;
                                row.AccountNo = trnsectionList[i].creditAccount;
                            }
                            //else if (trnsectionList[i].agentServices == AgentServicesType.CashWithdraw)
                            //{
                            //    row.amountWithdraw = trnsectionList[i].amount;
                            //    row.AccountNo = trnsectionList[i].debitAccount;
                            //}

                            trnDS.TransactionRecord.AddTransactionRecordRow(row);

                        }
                        trnDS.AcceptChanges();




                    }
                }

                // objRpt.SetDataSource(trnDS);
                frm.crvReportViewer.ReportSource = objRpt;

                frm.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }
        public void fillReportType()
        {
            cmbTransactionType.DisplayMember = "Text";
            cmbTransactionType.ValueMember = "Value";

            cmbTransactionType.Items.Add(new { Text = "Select", Value = "0" });
            cmbTransactionType.Items.Add(new { Text = "Deposite", Value = "1" });
            cmbTransactionType.Items.Add(new { Text = "Withdraw", Value = "2" });
            cmbTransactionType.Items.Add(new { Text = "Money Transfer", Value = "3" });
            cmbTransactionType.Items.Add(new { Text = "Remittance", Value = "4" });


            cmbTransactionType.SelectedText = "Select";
        }
        private void GetSetupData()
        {
            //string configvalue1 = ConfigurationManager.AppSettings["countryId"];
            try
            {
                objAgentInfoList = agentServices.getAgentInfoBranchWise();
                BindingSource bs = new BindingSource();
                bs.DataSource = objAgentInfoList;
                UtilityServices.fillComboBox(cmbAgentName, bs, "businessName", "id");
                cmbAgentName.Text = "Select";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                agentInformation = agentServices.getAgentInfoById(cmbAgentName.SelectedValue.ToString());
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
                if (agentInformation.subAgents != null)
                    UtilityServices.fillComboBox(cmbSubAgentName, bs, "name", "id");
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            mtbDate.Text = dtpDate.Value.ToString("dd-MM-yyyy");
        }

        private void mtbDate_KeyUp(object sender, KeyEventArgs e)
        {
            //suppressed to avoid mtb to dtp conversion
            try
            {
                string[] str = mtbDate.Text.Split('-');
                DateTime d = new DateTime(int.Parse(str[2].Trim()), int.Parse(str[1].Trim()), int.Parse(str[0].Trim()));
                dtpDate.Value = d;
            }
            catch (Exception ex) { }
        }

        private void frmDailyCashInCashOut_Load(object sender, EventArgs e)
        {
            dtpDate.Value = SessionInfo.currentDate;
        }
    }
}
