using CrystalDecisions.CrystalReports.Engine;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.user;
using MISL.Ababil.Agent.Infrastructure.Models.models.transaction;
using MISL.Ababil.Agent.Infrastructure.Models.reports;
using MISL.Ababil.Agent.Report.DataSets;
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
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.Remittance;
using MISL.Ababil.Agent.Infrastructure.Validation;
using MISL.Ababil.Agent.Report.Properties;

namespace MISL.Ababil.Agent.Report
{


    public partial class frmTransactionRecordForBranch : Form
    {
        List<AgentInformation> objAgentInfoList = new List<AgentInformation>();
        //AgentServices objAgentServices = new AgentServices();
        AgentInformation agentInformation = new AgentInformation();
        AgentServices agentServices = new AgentServices();

        List<SubAgentUser> subAgentUserList = new List<SubAgentUser>();
        TransactionService transactionService = new TransactionService();
        List<TransactionRecordExtension> trnList = new List<TransactionRecordExtension>();
        SubAgentServices subServices = new SubAgentServices();
        public frmTransactionRecordForBranch()
        {
            InitializeComponent();
            LoadSetupData();
            mtbDateFrom.Text = dtpDateFrom.Value.ToString("dd-MM-yyyy");
            mtbDateTo.Text = dtpDateTo.Value.ToString("dd-MM-yyyy");
        }

        private void frmTransactionRecord_Load(object sender, EventArgs e)
        {
            //lblUserName.Text = SessionInfo.username;
            dtpDateFrom.Value = SessionInfo.currentDate;
            dtpDateTo.Value = SessionInfo.currentDate;
        }

        private void LoadSetupData()
        {
            try
            {
                GetSetupData();
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
                objAgentInfoList = agentServices.getAgentInfoBranchWise();
                BindingSource bs = new BindingSource();
                bs.DataSource = objAgentInfoList;


                AgentInformation agSelect = new AgentInformation();
                agSelect.businessName = Resources.SetupData__Select_;
                objAgentInfoList.Insert(0, agSelect);
                AgentInformation agAll = new AgentInformation();
                agAll.businessName = Resources.SetupData__All_;
                objAgentInfoList.Insert(1, agAll);



                UtilityServices.fillComboBox(cmbAgentName, bs, "businessName", "id");
                cmbAgentName.Text = "Select";
                //cmbAgentName.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            //chacking valid date
            try
            {
                string[] str = mtbDateFrom.Text.Split('-');
                DateTime d = new DateTime(int.Parse(str[2].Trim()), int.Parse(str[1].Trim()), int.Parse(str[0].Trim()));
                dtpDateFrom.Value = d;
            }
            catch
            {
                MessageBox.Show("Please enter the Date in correct format.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                string[] str = mtbDateTo.Text.Split('-');
                DateTime d = new DateTime(int.Parse(str[2].Trim()), int.Parse(str[1].Trim()), int.Parse(str[0].Trim()));
                dtpDateTo.Value = d;
            }
            catch
            {
                MessageBox.Show("Please enter the Date in correct format.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            if (cmbAgentName.SelectedIndex < 1)
            {
                MessageBox.Show("Please select an option.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            btnShowReport.Enabled = false;

            List<long> agentsList = new List<long>();
            List<string> subAgentsList = new List<string>();
            trnList.Clear();

            if (cmbAgentName.SelectedIndex > 1)
            {
                foreach (AgentInformation agentInformation in objAgentInfoList)
                {
                    if (agentInformation.businessName.Equals(cmbAgentName.Text))
                    {
                        agentsList.Add(agentInformation.id);
                        break;
                    }
                }
            }
            else
            {
                foreach (AgentInformation agentInformation in objAgentInfoList)
                {
                    if (agentInformation.businessName.Equals(Resources.SetupData__Select_) || agentInformation.businessName.Equals(Resources.SetupData__All_))
                        continue;
                    agentsList.Add(agentInformation.id);
                }
            }

            SubAgentServices subAgentServices = new SubAgentServices();

            foreach (long agentId in agentsList)
            {
                agentInformation = agentServices.getAgentInfoById(agentId.ToString());
                if (cmbSubAgnetName.SelectedIndex < 2)
                {
                    List<SubAgentInformation> subAgentInformations = agentInformation.subAgents;
                    if (subAgentInformations != null)
                    {
                        foreach (SubAgentInformation subAgentInformation in subAgentInformations)
                        {
                            SubAgentInformation thisSubAgent =
                                subAgentServices.getSubAgentInfoById(subAgentInformation.id.ToString());
                            if (thisSubAgent.users == null) continue;

                            if (cmbSubAgnetName.SelectedIndex > 1)
                            {
                                if ((long)cmbSubAgnetName.SelectedValue != thisSubAgent.id) continue;
                            }
                            subAgentsList.Clear();
                            foreach (SubAgentUser subAgentUser in thisSubAgent.users)
                            {
                                subAgentsList.Add(subAgentUser.username);
                            }

                            PopulateRecords(subAgentsList, thisSubAgent);

                        }
                    }
                }
                else
                {
                    SubAgentInformation thisSubAgent =
                        subAgentServices.getSubAgentInfoById(cmbSubAgnetName.SelectedValue.ToString());
                    if (thisSubAgent.users != null)
                    {

                        subAgentsList.Clear();
                        foreach (SubAgentUser subAgentUser in thisSubAgent.users)
                        {
                            subAgentsList.Add(subAgentUser.username);
                        }

                        PopulateRecords(subAgentsList, thisSubAgent);
                    }

                }

            }


            ShowTransectionRecord(trnList);

            btnShowReport.Enabled = true;

        }

        private void PopulateRecords(List<string> subAgentsList, SubAgentInformation thisSubAgent)
        {
            try
            {
                DailyTrnRecordSearchDto TrnDateDto = new DailyTrnRecordSearchDto();
                TrnDateDto.fromDate = Convert.ToDateTime(dtpDateFrom.Text).ToUnixTime();
                TrnDateDto.toDate = Convert.ToDateTime(dtpDateTo.Text).ToUnixTime();
                //if (cmbUser.Text != "All") TrnDateDto.subAgentUserName = cmbUser.Text;

                foreach (string subAgentUser in subAgentsList)
                {
                    TrnDateDto.subAgentUserName = subAgentUser;
                    trnList.AddRange(GetTransactionReocrdByDateRange(TrnDateDto,
                        agentInformation.businessName, thisSubAgent.name));
                }

                //trnList = GetTransactionReocrdByDateRange(TrnDateDto);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        class TransactionRecordExtension : TransactionRecord
        {
            public string AgentName;
            public string SubAgentName;
        }

        private List<TransactionRecordExtension> GetTransactionReocrdByDateRange(DailyTrnRecordSearchDto TrnDateDto, string agentName, string subAgentName)
        {
            List<TransactionRecord> transactionReocrdByDateRange = transactionService.getTransactionReocrdByDateRange(TrnDateDto);

            List<TransactionRecordExtension> transactions = new List<TransactionRecordExtension>();

            foreach (TransactionRecord transactionRecord in transactionReocrdByDateRange)
            {
                if (!ValidationManager.ValidateNonEmptyText(transactionRecord.creditAccount)
                    && !ValidationManager.ValidateNonEmptyText(transactionRecord.debitAccount)) continue;

                if (transactionRecord.agentServices != AgentServicesType.CashDeposit
                    && transactionRecord.agentServices != AgentServicesType.CashWithdraw) continue;

                TransactionRecordExtension extension = new TransactionRecordExtension();
                extension.amount = transactionRecord.amount;
                extension.creditAccount = transactionRecord.creditAccount;
                extension.debitAccount = transactionRecord.debitAccount;
                extension.transactionDate = transactionRecord.transactionDate;
                extension.AgentName = agentName;
                extension.SubAgentName = subAgentName;
                extension.agentServices = transactionRecord.agentServices;
                transactions.Add(extension);
            }
            return transactions;

            //return transactionReocrdByDateRange;
        }


        private void setSubagent()
        {
            if (agentInformation != null)
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = agentInformation.subAgents;

                if (agentInformation.subAgents != null)
                {
                    try
                    {
                        SubAgentInformation saiSelect = new SubAgentInformation();
                        saiSelect.name = "Select";

                        SubAgentInformation saiAll = new SubAgentInformation();
                        saiAll.name = "All";

                        agentInformation.subAgents.Insert(0, saiSelect);
                        agentInformation.subAgents.Insert(1, saiAll);
                    }
                    catch //suppressed
                    {

                    }


                    UtilityServices.fillComboBox(cmbSubAgnetName, bs, "name", "id");
                    if (cmbSubAgnetName.Items.Count > 0)
                    {
                        cmbSubAgnetName.SelectedIndex = 0;
                    }
                }

            }
        }


        private void ShowTransectionRecord(List<TransactionRecordExtension> trnsectionList)
        {
            try
            {
                // Set Crystal Report data.
                crTransectionRecordByDateRangeForBranch objRpt = new crTransectionRecordByDateRangeForBranch();
                TransactionRecordDSForBranch trnDS = new TransactionRecordDSForBranch();

                TextObject txtReprortAgnetName = objRpt.ReportDefinition.ReportObjects["txtAgentName"] as TextObject;
                if (txtReprortAgnetName != null && ValidationManager.ValidateNonEmptyTextWithoutSpace(cmbAgentName.Text))
                {
                    txtReprortAgnetName.Text = cmbAgentName.Text;
                }
                TextObject txtReprortSubAgnetName = objRpt.ReportDefinition.ReportObjects["txtSubAgentName"] as TextObject;
                if (txtReprortSubAgnetName != null && ValidationManager.ValidateNonEmptyTextWithoutSpace(cmbAgentName.Text))
                {
                    string subagent = cmbSubAgnetName.Text;
                    if (subagent == "" || subagent == string.Empty)
                    {
                        txtReprortSubAgnetName.Text = "All";
                    }
                    else
                    {
                        txtReprortSubAgnetName.Text = subagent;
                    }

                }
                TextObject objtxtUserId = objRpt.ReportDefinition.ReportObjects["txtUserId"] as TextObject;
                objtxtUserId.Text = SessionInfo.username;

                if (trnsectionList != null)
                {

                    if (trnsectionList.Count > 0)
                    {

                        for (int i = 0; i < trnsectionList.Count; i++)
                        {
                            TransactionRecordDSForBranch.TransactionRecordRow row = trnDS.TransactionRecord.NewTransactionRecordRow();

                            row.transactionDate = trnsectionList[i].transactionDate;
                            if (trnsectionList[i].agentServices == AgentServicesType.CashDeposit)
                            {
                                row.amountDeposit = trnsectionList[i].amount;
                                row.AccountNo = trnsectionList[i].creditAccount;
                            }
                            else if (trnsectionList[i].agentServices == AgentServicesType.CashWithdraw)
                            {
                                row.amountWithdraw = trnsectionList[i].amount;
                                row.AccountNo = trnsectionList[i].debitAccount;
                            }

                            row.Agent = trnsectionList[i].AgentName;
                            row.SubAgent = trnsectionList[i].SubAgentName;

                            trnDS.TransactionRecord.AddTransactionRecordRow(row);

                        }
                        trnDS.AcceptChanges();


                    }
                }

                //objRpt.RecordSelectionFormula = "{DailyTrnRecordSearchDto.fromDate} >= {?" + Convert.ToDateTime(dtpDateFrom.Text) + "} and {DailyTrnRecordSearchDto.toDate} <= {?" + Convert.ToDateTime(dtpDateFrom.Text) + "}";
                //objRpt.RecordSelectionFormula = "{TransactionRecord.transactionDate} >= Date (" + Convert.ToDateTime(dtpDateFrom.Text).Year.ToString() + "," + Convert.ToDateTime(dtpDateFrom.Text).Month.ToString() + " ," + Convert.ToDateTime(dtpDateFrom.Text).Day.ToString() + " ) and {TransactionRecord.transactionDate} <= Date (" + Convert.ToDateTime(dtpDateTo.Text).Year.ToString() + "," + Convert.ToDateTime(dtpDateTo.Text).Month.ToString() + " ," + Convert.ToDateTime(dtpDateTo.Text).Day.ToString() + ")";

                frmReportViewer frm = new frmReportViewer();
                objRpt.SetDataSource(trnDS);
                frm.crvReportViewer.ReportSource = objRpt;

                frm.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }

        private void mtbDateFrom_KeyUp(object sender, KeyEventArgs e)
        {
            //suppressed to avoid mtb to dtp conversion
            try
            {
                string[] str = mtbDateFrom.Text.Split('-');
                DateTime d = new DateTime(int.Parse(str[2].Trim()), int.Parse(str[1].Trim()), int.Parse(str[0].Trim()));
                dtpDateFrom.Value = d;
            }
            catch (Exception ex) { }
        }

        private void mtbDateTo_KeyUp(object sender, KeyEventArgs e)
        {
            //suppressed to avoid mtb to dtp conversion
            try
            {
                string[] str = mtbDateTo.Text.Split('-');
                DateTime d = new DateTime(int.Parse(str[2].Trim()), int.Parse(str[1].Trim()), int.Parse(str[0].Trim()));
                dtpDateTo.Value = d;
            }
            catch (Exception ex) { }
        }

        private void dtpDateFrom_ValueChanged(object sender, EventArgs e)
        {
            mtbDateFrom.Text = dtpDateFrom.Value.ToString("dd-MM-yyyy");
        }

        private void dtpDateTo_ValueChanged(object sender, EventArgs e)
        {
            mtbDateTo.Text = dtpDateTo.Value.ToString("dd-MM-yyyy");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                //MessageBox.Show(ex.Message);
            }
            setSubagent();
        }

    }
}
