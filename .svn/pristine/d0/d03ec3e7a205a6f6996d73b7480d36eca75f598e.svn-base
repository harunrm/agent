using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.user;
using MISL.Ababil.Agent.Infrastructure.Models.models.transaction;
using MISL.Ababil.Agent.Infrastructure.Models.reports;
using MISL.Ababil.Agent.Infrastructure.Validation;
using MISL.Ababil.Agent.Report.Properties;
using MISL.Ababil.Agent.Services;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using CrystalDecisions.CrystalReports.Engine;
using MISL.Ababil.Agent.Report.DataSets;
using MISL.Ababil.Agent.Report.Reports;
using MISL.Ababil.Agent.Infrastructure.Models.dto;
using MISL.Ababil.Agent.Infrastructure;
using MetroFramework.Forms;
using System.Globalization;

namespace MISL.Ababil.Agent.Report
{
    public partial class frmCashRegister : MetroForm
    {
        private GUI gui = new GUI();
        List<AgentInformation> objAgentInfoList = new List<AgentInformation>();
        //AgentServices objAgentServices = new AgentServices();
        AgentServices agentServices = new AgentServices();
        List<TransactionRecordExtension> trnList = new List<TransactionRecordExtension>();
        AgentInformation agentInformation = new AgentInformation();
        TransactionService transactionService = new TransactionService();

        public List<ClsCashRegister> _cashRegisterList = new List<ClsCashRegister>();
        CashRegister cashRegDS = new CashRegister();  // DataDet obj for report.

        public frmCashRegister()
        {
            InitializeComponent();
            LoadSetupData();
            controlActivity();
            ConfigUIEnhancement();
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
        public void ConfigUIEnhancement()
        {
            gui = new GUI(this);
            gui.Config(ref cmbAgentName, ValidCheck.VALIDATIONTYPES.COMBOBOX_EMPTY, null);
            gui.Config(ref cmbSubAgnetName);
            gui.Config(ref dtpDateFrom);
            gui.Config(ref dtpDateTo);
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
                cmbAgentName.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
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
                MessageBox.Show("Please select an option.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            crCashRegister report = new crCashRegister();
            frmReportViewer viewer = new frmReportViewer();

            ReportHeaders rptHeaders = new ReportHeaders();
            rptHeaders = UtilityServices.getReportHeaders("Agent Cash Register");

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
                txtPrintDate.Text = rptHeaders.printDate.ToString("dd/MM/yyyy").Replace("-","/");
            }
            #region harun ==============date=====
            //txtFromDate.Text = Convert.ToDateTime(dtpDateFrom.Text).ToString("dd/MM/yyyy");
            //txtToDate.Text = Convert.ToDateTime(dtpDateTo.Text).ToString("dd/MM/yyyy");
            #endregion
            txtFromDate.Text = dtpDateFrom.Date;
            txtToDate.Text = dtpDateTo.Date;

            LoadCashRegisterData();

            //report.SetDataSource(_cashRegisterList);
            report.SetDataSource(cashRegDS);

            viewer.crvReportViewer.ReportSource = report;
            viewer.ShowDialog(this.Parent);

            #region Commented

            //btnShowReport.Enabled = false;

            #region Commented :: WALI :: 21-Jul-2015
            //List<long> agentsList = new List<long>();
            //List<string> subAgentsList = new List<string>();
            //trnList.Clear();

            //if (cmbAgentName.SelectedIndex > 1)
            //{
            //    foreach (AgentInformation agentInformation in objAgentInfoList)
            //    {
            //        if (agentInformation.businessName.Equals(cmbAgentName.Text))
            //        {
            //            agentsList.Add(agentInformation.id);
            //            break;
            //        }
            //    }
            //}
            //else
            //{
            //    foreach (AgentInformation agentInformation in objAgentInfoList)
            //    {
            //        if (agentInformation.businessName.Equals(Resources.SetupData__Select_) || agentInformation.businessName.Equals(Resources.SetupData__All_)) continue;
            //        agentsList.Add(agentInformation.id);
            //    }
            //}
            //SubAgentServices subAgentServices = new SubAgentServices();

            //foreach (long agentId in agentsList)
            //{
            //    agentInformation = agentServices.getAgentInfoById(agentId.ToString());
            //    if (cmbSubAgnetName.SelectedIndex < 2)
            //    {
            //        List<SubAgentInformation> subAgentInformations = agentInformation.subAgents;
            //        if (subAgentInformations != null)
            //        {
            //            foreach (SubAgentInformation subAgentInformation in subAgentInformations)
            //            {
            //                SubAgentInformation thisSubAgent = subAgentServices.getSubAgentInfoById(subAgentInformation.id.ToString());
            //                if (thisSubAgent.users == null) continue;

            //                if (cmbSubAgnetName.SelectedIndex > 1)
            //                {
            //                    if ((long)cmbSubAgnetName.SelectedValue != thisSubAgent.id) continue;
            //                }
            //                subAgentsList.Clear();
            //                foreach (SubAgentUser subAgentUser in thisSubAgent.users)
            //                { subAgentsList.Add(subAgentUser.username); }

            //                PopulateRecords(subAgentsList, thisSubAgent);
            //            }
            //        }
            //    }
            //    else
            //    {
            //        SubAgentInformation thisSubAgent = subAgentServices.getSubAgentInfoById(cmbSubAgnetName.SelectedValue.ToString());
            //        if (thisSubAgent.users != null)
            //        {
            //            subAgentsList.Clear();
            //            foreach (SubAgentUser subAgentUser in thisSubAgent.users)
            //            { subAgentsList.Add(subAgentUser.username); }

            //            PopulateRecords(subAgentsList, thisSubAgent);
            //        }
            //    }
            //}

            //ShowTransectionRecord(trnList);
            #endregion

            //TextObject txtReportFromDate = report.ReportDefinition.ReportObjects["txtFromDate"] as TextObject;
            //if (txtReportFromDate != null)
            //{
            //    txtReportFromDate.Text = dtpDateFrom.Text;
            //}

            //TextObject txtReportToDate = report.ReportDefinition.ReportObjects["txtToDate"] as TextObject;
            //if (txtReportToDate != null)
            //{
            //    txtReportToDate.Text = dtpDateTo.Text;
            //}

            //report.SetParameterValue("SelectionType", cmbProduct.Text);

            //ShowTransectionRecord(trnList);
            //btnShowReport.Enabled = true;

            //if (cmbAgentName.SelectedIndex > 0 && cmbSubAgnetName.SelectedIndex > 0)
            // {
            //     crCashRegister report = new crCashRegister();
            //     frmReportViewer viewer = new frmReportViewer();

            //     ReportHeaders rptHeaders = new ReportHeaders();
            //     rptHeaders = UtilityServices.getReportHeaders("Agent Income Statement");

            //     TextObject txtBankName = report.ReportDefinition.ReportObjects["txtBankName"] as TextObject;
            //     TextObject txtBranchName = report.ReportDefinition.ReportObjects["txtBranchName"] as TextObject;
            //     TextObject txtBranchAddress = report.ReportDefinition.ReportObjects["txtBranchAddress"] as TextObject;
            //     TextObject txtReportHeading = report.ReportDefinition.ReportObjects["txtReportHeading"] as TextObject;
            //     TextObject txtPrintUser = report.ReportDefinition.ReportObjects["txtPrintUser"] as TextObject;
            //    // TextObject txtPrintDate = report.ReportDefinition.ReportObjects["txtPrintDate"] as TextObject;
            //     if (rptHeaders!=null)
            //     {
            //         if(rptHeaders.branchDto!=null)
            //         {
            //             txtBankName.Text = rptHeaders.branchDto.bankName;
            //             txtBranchName.Text = rptHeaders.branchDto.branchName;
            //             txtBranchAddress.Text = rptHeaders.branchDto.branchAddress;
            //         }
            //         txtReportHeading.Text = rptHeaders.reportHeading;
            //         txtPrintUser.Text = rptHeaders.printUser;
            //       //  txtPrintDate.Text = rptHeaders.printDate.ToString("dd/MM/yyyy");
            //     }

            //     viewer.crvReportViewer.ReportSource = report;
            //     viewer.ShowDialog(this.Parent);
            // }
            // else
            // {
            //     MessageBox.Show("Please select an option!", "Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            // }
            #endregion
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
                    trnList.AddRange(GetTransactionReocrdByDateRange(TrnDateDto, agentInformation.businessName, thisSubAgent.name));
                }

                //trnList = GetTransactionReocrdByDateRange(TrnDateDto);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
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
                    catch //suppressed
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
                //MessageBox.Show(ex.Message);
            }
            setSubagent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region =============harun=====(22-09-15)


        //private void mtbFromDate_KeyUp(object sender, KeyEventArgs e)
        //{
        //    //suppressed to avoid mtb to dtp conversion
        //    try
        //    {
        //        string[] str = mtbDateFrom.Text.Split('-');
        //        DateTime d = new DateTime(int.Parse(str[2].Trim()), int.Parse(str[1].Trim()), int.Parse(str[0].Trim()));
        //        dtpDateFrom.Value = d;
        //    }
        //    catch (Exception ex) { }
        //}

        //private void mtbToDate_KeyUp(object sender, KeyEventArgs e)
        //{
        //    //suppressed to avoid mtb to dtp conversion
        //    try
        //    {
        //        string[] str = mtbDateTo.Text.Split('-');
        //        DateTime d = new DateTime(int.Parse(str[2].Trim()), int.Parse(str[1].Trim()), int.Parse(str[0].Trim()));
        //        dtpDateTo.Value = d;
        //    }
        //    catch (Exception ex) { }
        //}

        #endregion

        private List<TransactionRecordExtension> GetTransactionReocrdByDateRange(DailyTrnRecordSearchDto TrnDateDto, string agentName, string subAgentName)
        {
            List<TransactionRecord> transactionReocrdByDateRange = transactionService.getTransactionReocrdByDateRange(TrnDateDto);

            List<TransactionRecordExtension> transactions = new List<TransactionRecordExtension>();

            foreach (TransactionRecord transactionRecord in transactionReocrdByDateRange)
            {
                if (!ValidationManager.ValidateNonEmptyText(transactionRecord.creditAccount)
                    && !ValidationManager.ValidateNonEmptyText(transactionRecord.debitAccount))
                    continue;

                if (transactionRecord.agentServices != AgentServicesType.CashDeposit
                    && transactionRecord.agentServices != AgentServicesType.CashWithdraw)
                    continue;

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

        private void ShowTransectionRecord(List<TransactionRecordExtension> trnsectionList)
        {
            try
            {
                // Set Crystal Report data.
                crCashRegister objRpt = new crCashRegister();
                CashRegister trnDS = new CashRegister();


                ReportHeaders rptHeaders = new ReportHeaders();
                rptHeaders = UtilityServices.getReportHeaders("Agent Income Statement");

                TextObject txtBankName = objRpt.ReportDefinition.ReportObjects["txtBankName"] as TextObject;
                TextObject txtBranchName = objRpt.ReportDefinition.ReportObjects["txtBranchName"] as TextObject;
                TextObject txtBranchAddress = objRpt.ReportDefinition.ReportObjects["txtBranchAddress"] as TextObject;
                // TextObject txtReportHeading = objRpt.ReportDefinition.ReportObjects["txtReportHeading"] as TextObject;
                TextObject txtPrintUser = objRpt.ReportDefinition.ReportObjects["txtPrintUser"] as TextObject;
                // TextObject txtPrintDate = report.ReportDefinition.ReportObjects["txtPrintDate"] as TextObject;
                if (rptHeaders != null)
                {
                    if (rptHeaders.branchDto != null)
                    {
                        txtBankName.Text = rptHeaders.branchDto.bankName;
                        txtBranchName.Text = rptHeaders.branchDto.branchName;
                        txtBranchAddress.Text = rptHeaders.branchDto.branchAddress;
                    }
                    //txtReportHeading.Text = rptHeaders.reportHeading;
                    txtPrintUser.Text = rptHeaders.printUser;

                }




                if (trnsectionList != null)
                {

                    if (trnsectionList.Count > 0)
                    {

                        for (int i = 0; i < trnsectionList.Count; i++)
                        {
                            CashRegister.CashRegisterRow row = trnDS._CashRegister.NewCashRegisterRow();

                            row.transactionDate = trnsectionList[i].transactionDate;
                            if (trnsectionList[i].agentServices == AgentServicesType.CashDeposit)
                            {
                                row.cashDeposit = trnsectionList[i].amount;
                                row.accountNo = trnsectionList[i].creditAccount;
                            }
                            else if (trnsectionList[i].agentServices == AgentServicesType.CashWithdraw)
                            {
                                row.cashWithdraw = trnsectionList[i].amount;
                                row.accountNo = trnsectionList[i].debitAccount;
                            }

                            row.agent = trnsectionList[i].AgentName;
                            row.outlet = trnsectionList[i].SubAgentName;

                            trnDS._CashRegister.AddCashRegisterRow(row);

                        }
                        trnDS.AcceptChanges();


                    }
                }

                frmReportViewer frm = new frmReportViewer();
                objRpt.SetDataSource(trnDS);
                frm.crvReportViewer.ReportSource = objRpt;

                frm.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }

        private void frmCashRegister_Load(object sender, EventArgs e)
        {
            dtpDateFrom.Value = SessionInfo.currentDate;
            dtpDateTo.Value = SessionInfo.currentDate;
        }



        #region WALI :: 21-Jul-2015
        private void LoadCashRegisterData()
        {
            ClsCashRegister cashRegister;
            _cashRegisterList.Clear();
            DailyTrnRecordSearchDto dailyTrnRecordSearchDto = FillDailyTrnRecordSearchDto();
            ServiceResult result1;

            try
            {
                result1 = AccountInformationService.GetCashRegisterReport(dailyTrnRecordSearchDto);

                if (!result1.Success)
                {
                    MessageBox.Show(result1.Message);
                    return;
                }

                List<CashRegisterDto> cashReg = result1.ReturnedObject as List<CashRegisterDto>;

                cashRegDS = new CashRegister();

                if (cashReg != null)
                {
                    foreach (CashRegisterDto cashRegRow in cashReg)
                    {
                        CashRegister.CashRegisterRow dataRow = cashRegDS._CashRegister.NewCashRegisterRow();
                        dataRow.agentId = cashRegRow.agentId;
                        dataRow.agentName = cashRegRow.agentName;
                        dataRow.subAgentId = cashRegRow.subAgentId;
                        dataRow.subAgentName = cashRegRow.subAgentName;
                        dataRow.trId = cashRegRow.trId;
                        dataRow.amount = cashRegRow.amount;
                        dataRow.service = cashRegRow.service;
                        dataRow.accountNumber = cashRegRow.accountNumber;
                        dataRow.accounttitle = cashRegRow.accounttitle;
                        dataRow.trDate = UtilityServices.getDateFromLong(cashRegRow.trDate);

                        cashRegDS._CashRegister.AddCashRegisterRow(dataRow);

                        //cashRegister = new ClsCashRegister();
                        //cashRegister.agentId = cashRegRow.agentId;
                        //cashRegister.agentName = cashRegRow.agentName;
                        //cashRegister.subAgentId = cashRegRow.subAgentId;
                        //cashRegister.subAgentName = cashRegRow.subAgentName;
                        //cashRegister.trId = cashRegRow.trId;
                        //cashRegister.service = cashRegRow.service;
                        //cashRegister.accountNumber = cashRegRow.accountNumber;
                        //cashRegister.accounttitle = cashRegRow.accounttitle;
                        //cashRegister.amount = cashRegRow.amount;
                        //cashRegister.trDate = UtilityServices.getDateFromLong(cashRegRow.trDate);
                        //_cashRegisterList.Add(cashRegister);
                    }
                }
                cashRegDS.AcceptChanges();
            }
            catch (Exception exp)
            { }
        }
        private DailyTrnRecordSearchDto FillDailyTrnRecordSearchDto()
        {
            DailyTrnRecordSearchDto TrnDateDto = new DailyTrnRecordSearchDto();

            try
            {
                if (this.cmbAgentName.SelectedIndex > -1)
                {
                    if (cmbAgentName.SelectedIndex != 0 || cmbAgentName.SelectedIndex != 1)
                    {
                        TrnDateDto.agent = new AgentInformation { id = (long)cmbAgentName.SelectedValue };
                    }
                    if (cmbAgentName.SelectedIndex == 1 || cmbAgentName.SelectedIndex == 0)
                    {
                        TrnDateDto.agent = null; // new AgentInformation();
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
                        TrnDateDto.subAgent = new SubAgentInformation { id = (long)cmbSubAgnetName.SelectedValue };
                    }
                    if (cmbSubAgnetName.SelectedIndex == 1 || cmbSubAgnetName.SelectedIndex == 0)
                    {
                        TrnDateDto.subAgent = null; // new SubAgentInformation();
                    }
                    if (cmbSubAgnetName.SelectedIndex == 0)
                    {
                        //MessageBox.Show("Please select an option!", "Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //return null;
                    }
                }

                //TrnDateDto.fromDate = UtilityServices.GetLongDate(UtilityServices.ParseDateTime(dtpDateFrom.Date));
                //TrnDateDto.toDate = UtilityServices.GetLongDate(UtilityServices.ParseDateTime(dtpDateTo.Date));
                TrnDateDto.fromDate = UtilityServices.GetLongDate
                (
                     DateTime.ParseExact(dtpDateFrom.Date.Replace("/", "-"), "dd-MM-yyyy", CultureInfo.InvariantCulture)
                );
                TrnDateDto.toDate = UtilityServices.GetLongDate
                (
                     DateTime.ParseExact(dtpDateTo.Date.Replace("/", "-"), "dd-MM-yyyy", CultureInfo.InvariantCulture)
                );


                List<string> subAgentsList = new List<string>();
                SubAgentServices subAgentServices = new SubAgentServices();
                List<SubAgentInformation> subAgentInformations = agentInformation.subAgents;
                if (subAgentInformations != null)
                {
                    foreach (SubAgentInformation subAgentInformation in subAgentInformations)
                    {
                        SubAgentInformation thisSubAgent = subAgentServices.getSubAgentInfoById(subAgentInformation.id.ToString());
                        if (thisSubAgent.users == null) continue;

                        if (cmbSubAgnetName.SelectedIndex > 1)
                        {
                            if ((long)cmbSubAgnetName.SelectedValue != thisSubAgent.id) continue;
                        }
                        subAgentsList.Clear();
                        foreach (SubAgentUser subAgentUser in thisSubAgent.users)
                        { subAgentsList.Add(subAgentUser.username); }
                    }
                }
                foreach (string subAgentUser in subAgentsList)
                {
                    TrnDateDto.subAgentUserName = subAgentUser;
                }
            }
            catch (Exception exp)
            { }

            return TrnDateDto;
        }
        public class ClsCashRegister
        {
            public long agentId = 0;
            public string agentName = "";
            public long subAgentId = 0;
            public string subAgentName = "";

            public long trId = 0;
            public decimal amount = 0;
            public string service = "";
            public string accountNumber = "";
            public string accounttitle = "";
            public DateTime trDate = new DateTime();
        }
        #endregion

        private void frmCashRegister_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner = null;
        }
    }

    class TransactionRecordExtension : TransactionRecord
    {
        public string AgentName;
        public string SubAgentName;
    }
}