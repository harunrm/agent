using CrystalDecisions.CrystalReports.Engine;
using MetroFramework.Forms;
using MISL.Ababil.Agent.Infrastructure;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
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
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MISL.Ababil.Agent.Report
{
    public partial class frmBillPaymentReport : MetroForm
    {
        private GUI gui = new GUI();
        List<AgentInformation> objAgentInfoList = new List<AgentInformation>();
        //AgentServices objAgentServices = new AgentServices();
        AgentInformation agentInformation = new AgentInformation();
        AgentServices agentServices = new AgentServices();
        BillPaymentDS billDs = null;
        public frmBillPaymentReport()
        {
            InitializeComponent();
            SetupDataLoad();
            controlActivity();
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
                    if (SessionInfo.rights.Contains("REMITTANCE_FIRST_APPROVE") || SessionInfo.rights.Contains("REMITTANCE_SECOND_APPROVE"))
                    {
                        cmbAgentName.Enabled = true;
                        cmbSubAgnetName.Enabled = true;
                        return;
                    }
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
        private void SetupDataLoad()
        {

            try
            {
                objAgentInfoList = agentServices.getAgentInfoBranchWise();
                BindingSource bs = new BindingSource();
                bs.DataSource = objAgentInfoList;


                AgentInformation agSelect = new AgentInformation();
                agSelect.businessName = "(Select)";
                objAgentInfoList.Insert(0, agSelect);
                AgentInformation agAll = new AgentInformation();
                agAll.businessName = "(All)";
                objAgentInfoList.Insert(1, agAll);




                UtilityServices.fillComboBox(cmbAgentName, bs, "businessName", "id");
                cmbAgentName.Text = "Select";
                cmbAgentName.SelectedIndex = 0;
                // service provider info load

                BillPaymentServices billPaymentServices = new BillPaymentServices();





                List<BillServiceProvider> serviceProviderList = billPaymentServices.GetListBillServiceProviders();
                BillServiceProvider bill = new BillServiceProvider();
                bill.shortcode = "(Select)";
                serviceProviderList.Insert(0, bill);
                BillServiceProvider billAll = new BillServiceProvider();
                billAll.shortcode = "(All)";
                serviceProviderList.Insert(1, billAll);

                BindingSource bsBillServiceProvider = new BindingSource();
                bsBillServiceProvider.DataSource = serviceProviderList;
                UtilityServices.fillComboBox(cmbServiceProvider, bsBillServiceProvider, "shortcode", "id");
                cmbServiceProvider.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }
        private void btnViewReport_Click(object sender, EventArgs e)
        {

            if (cmbAgentName.SelectedIndex <= 0 || cmbServiceProvider.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select an option.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //chacking valid date
            DateTime fromDate, toDate;
            try
            {
                //fromDate = UtilityServices.ParseDateTime(dtpFromDate.Date);                
                fromDate = DateTime.ParseExact(dtpFromDate.Date.Replace("/", "-"), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            }
            catch
            {
                MessageBox.Show("Please enter the Date in correct format.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                //toDate = UtilityServices.ParseDateTime(dtpToDate.Date);
                toDate = DateTime.ParseExact(dtpToDatae.Date.Replace("/", "-"), "dd-MM-yyyy", CultureInfo.InvariantCulture);
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

            cRBillPaymentReport report = new cRBillPaymentReport();

            frmReportViewer viewer = new frmReportViewer();

            ReportHeaders rptHeaders = new ReportHeaders();
            rptHeaders = UtilityServices.getReportHeaders("Bill Payment Detail Report");

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
                txtPrintDate.Text = rptHeaders.printDate.ToString("dd-MM-yyyy").Replace("-","/");
            }

            txtFromDate.Text = dtpFromDate.Date;
            txtToDate.Text = dtpToDatae.Date;

            LoadBillPaymentInformation();

            report.SetDataSource(billDs);
            viewer.crvReportViewer.ReportSource = report;
            viewer.ShowDialog(Parent);

        }
        private void LoadBillPaymentInformation()
        {
            billDs = new BillPaymentDS();
            ServiceResult result = BillPaymentServices.GetBillPayemntList(FillBillPaymentSearchDto());
            if (!result.Success)
            {
                MessageBox.Show(result.Message);
                return;
            }

            List<BillPaymentSearchResultDto> billPayment = result.ReturnedObject as List<BillPaymentSearchResultDto>;

            for (int i = 0; i < billPayment.Count; i++)
            {

                BillPaymentDS.BillPaymentDTRow billPaymentRep = billDs.BillPaymentDT.NewBillPaymentDTRow();
                billPaymentRep.agentName = billPayment[i].agentName;
                billPaymentRep.outletName = billPayment[i].outletName;
                billPaymentRep.paymentType = billPayment[i].paymentType.ToString();//check tomorrow
                // billPaymentRep.paymentType = billPayment[i].paymentType;
                billPaymentRep.accountNo = billPayment[i].accountNo;
                billPaymentRep.billAmount = billPayment[i].billAmount;
                billPaymentRep.billNo = billPayment[i].billNo;
                billPaymentRep.customerName = billPayment[i].customerName;
                billPaymentRep.charge = billPayment[i].charge;
                billPaymentRep.mobileNo = billPayment[i].mobileNo;
                billPaymentRep.serviceProvider = billPayment[i].serviceProvider;
                string tmp = billPayment[i].txnDate;
                if (tmp.Length > 12)
                {
                    billPaymentRep.txnDate = tmp.Substring(0, tmp.Length - 12);
                }
                billDs.BillPaymentDT.AddBillPaymentDTRow(billPaymentRep);

            }
            billDs.AcceptChanges();



        }
        private BillPaymentSearchDto FillBillPaymentSearchDto()
        {
            BillPaymentSearchDto billPaymentSearchDto = new BillPaymentSearchDto();

            if (cmbAgentName.SelectedIndex > 1)
            {
                billPaymentSearchDto.agentId = (long)cmbAgentName.SelectedValue;
            }
            if (cmbSubAgnetName.SelectedIndex > 1)
            {
                billPaymentSearchDto.subagentId = (long)cmbSubAgnetName.SelectedValue;
            }

            if (SessionInfo.rights.Contains("REMITTANCE_FIRST_APPROVE") ||
    SessionInfo.rights.Contains("REMITTANCE_SECOND_APPROVE"))
            {
                billPaymentSearchDto.agentId = null;
                billPaymentSearchDto.subagentId = null;
            }


            if (cmbServiceProvider.SelectedIndex == 1)
            {
                billPaymentSearchDto.serviceProviderId = null;
            }
            else if (cmbServiceProvider.SelectedIndex > 1)
            {
                billPaymentSearchDto.serviceProviderId = (long)cmbServiceProvider.SelectedValue;
            }


            billPaymentSearchDto.billNo = txtBillNumber.Text;





            //billPaymentSearchDto.fromDate = dtpFromDate.Value;
            //billPaymentSearchDto.toDate = dtpToDatae.Value;

            billPaymentSearchDto.fromDate = DateTime.ParseExact(dtpFromDate.Date.Replace("/", "-"), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            billPaymentSearchDto.toDate = DateTime.ParseExact(dtpToDatae.Date.Replace("/", "-"), "dd-MM-yyyy", CultureInfo.InvariantCulture);



            return billPaymentSearchDto;
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
                        saiSelect.name = "(Select)";

                        SubAgentInformation saiAll = new SubAgentInformation();
                        saiAll.name = "(All)";

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBillPaymentReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner = null;
        }
    }
}
