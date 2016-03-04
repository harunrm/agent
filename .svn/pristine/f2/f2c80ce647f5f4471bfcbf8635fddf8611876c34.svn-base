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
using MISL.Ababil.Agent.Infrastructure.Validation;

namespace MISL.Ababil.Agent.Report
{


    public partial class frmTransactionRecord : Form
    {
        List<SubAgentUser> subAgentUserList = new List<SubAgentUser>();
        TransactionService transactionService = new TransactionService();
        List<TransactionRecord> trnList = new List<TransactionRecord>();
        SubAgentServices subServices = new SubAgentServices();
        public frmTransactionRecord()
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
                subAgentUserList = subServices.getSubAgentUserList();

                SubAgentUser agSelect = new SubAgentUser();
                agSelect.username = "(Select)";
                subAgentUserList.Insert(0, agSelect);

                SubAgentUser agAll = new SubAgentUser();
                agAll.username = "(All)";
                subAgentUserList.Insert(1, agAll);

                BindingSource bs = new BindingSource();
                bs.DataSource = subAgentUserList;

                cmbUser.DataSource = bs;
                cmbUser.ValueMember = "username";
                cmbUser.DisplayMember = "username";
                cmbUser.Text = "All";

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


            if (cmbUser.SelectedIndex != 0)
            {
                if (cmbUser.SelectedIndex != 1)
                {
                    try
                    {
                        DailyTrnRecordSearchDto TrnDateDto = new DailyTrnRecordSearchDto();
                        TrnDateDto.fromDate = Convert.ToDateTime(dtpDateFrom.Text).ToUnixTime();
                        TrnDateDto.toDate = Convert.ToDateTime(dtpDateTo.Text).ToUnixTime();
                        if (cmbUser.Text != "All") TrnDateDto.subAgentUserName = cmbUser.Text;

                        trnList = GetTransactionReocrdByDateRange(TrnDateDto);
                        ShowTransectionRecord(trnList);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    try
                    {
                        DailyTrnRecordSearchDto TrnDateDto = new DailyTrnRecordSearchDto();
                        TrnDateDto.fromDate = Convert.ToDateTime(dtpDateFrom.Text).ToUnixTime();
                        TrnDateDto.toDate = Convert.ToDateTime(dtpDateTo.Text).ToUnixTime();
                        if (cmbUser.Text != "All") TrnDateDto.subAgentUserName = null;

                        trnList = GetTransactionReocrdByDateRange(TrnDateDto);
                        ShowTransectionRecord(trnList);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an option.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbUser.Focus();
            }
        }

        private List<TransactionRecord> GetTransactionReocrdByDateRange(DailyTrnRecordSearchDto TrnDateDto)
        {
            return transactionService.getTransactionReocrdByDateRange(TrnDateDto);
        }

        public void ShowTransectionRecord(List<TransactionRecord> trnsectionList)
        {
            try
            {
                // Set Crystal Report data.
                crTransectionRecordByDateRange objRpt = new crTransectionRecordByDateRange();
                TransactionRecordDS trnDS = new TransactionRecordDS();
                TextObject objtxtUserId = objRpt.ReportDefinition.ReportObjects["txtUserId"] as TextObject;
                if (objtxtUserId != null && ValidationManager.ValidateNonEmptyTextWithoutSpace(cmbUser.Text))
                {
                    objtxtUserId.Text = SessionInfo.username;
                }

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
                            else if (trnsectionList[i].agentServices == AgentServicesType.CashWithdraw)
                            {
                                row.amountWithdraw = trnsectionList[i].amount;
                                row.AccountNo = trnsectionList[i].debitAccount;
                            }

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

    }
}
