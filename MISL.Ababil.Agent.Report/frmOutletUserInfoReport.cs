using MetroFramework.Forms;
using MISL.Ababil.Agent.Infrastructure;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using MISL.Ababil.Agent.Report.Properties;
using MISL.Ababil.Agent.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Report.Reports;
using MISL.Ababil.Agent.Infrastructure.Models.reports;
using CrystalDecisions.CrystalReports.Engine;
using MISL.Ababil.Agent.Module.Common.UI.MessageUI;

namespace MISL.Ababil.Agent.Report
{
    public partial class frmOutletUserInfoReport : MetroForm
    {
        private List<AgentInformation> objAgentInfoList = new List<AgentInformation>();
        private AgentServices agentServices = new AgentServices();
        private AgentInformation agentInformation = new AgentInformation();
        private List<OutletUserInfoReportSearchDto> result;

        List<OutletUserInfoReportResultDto> _outletUserInfoReportResultDto;
        List<OutletUserInfoResult> _outletInfoReportList = new List<OutletUserInfoResult>();
        public frmOutletUserInfoReport()
        {
            InitializeComponent();
            LoadSetupData();
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            if (CheckForValidation(true))
            {
                try
                {


                LoadOutletReportData();

                crOutletUserInfoReport report = new crOutletUserInfoReport();
                frmReportViewer frm = new frmReportViewer();
                ReportHeaders rptHeaders = new ReportHeaders();
                rptHeaders = UtilityServices.getReportHeaders("Outlet User Information Report");

                TextObject txtBankName = report.ReportDefinition.ReportObjects["txtBankName"] as TextObject;
                TextObject txtBranchName = report.ReportDefinition.ReportObjects["txtBranchName"] as TextObject;
                TextObject txtBranchAddress = report.ReportDefinition.ReportObjects["txtBranchAddress"] as TextObject;
                TextObject txtReportHeading = report.ReportDefinition.ReportObjects["txtReportHeading"] as TextObject;
                TextObject txtPrintUser = report.ReportDefinition.ReportObjects["txtPrintUser"] as TextObject;
                TextObject txtPrintDate = report.ReportDefinition.ReportObjects["txtPrintDate"] as TextObject;
                //TextObject txtFromDate = report.ReportDefinition.ReportObjects["txtFromDate"] as TextObject;
                //TextObject txtToDate = report.ReportDefinition.ReportObjects["txtToDate"] as TextObject;
                TextObject txtAgentName = report.ReportDefinition.ReportObjects["txtAgentName"] as TextObject;
                TextObject txtOutletName = report.ReportDefinition.ReportObjects["txtOutletName"] as TextObject;

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
                    //txtAgentName.Text =((AgentInformation)cmbAgentName.SelectedItem).businessName;
                    string txt = ((AgentInformation)cmbAgentName.SelectedItem).businessName;
                    txtAgentName.Text = DoInitCap.ConvertTo_ProperCase(txt);
                    txtOutletName.Text = ((SubAgentInformation)cmbOutletName.SelectedItem).name;

                }
                report.SetDataSource(_outletInfoReportList);


                frm.crvReportViewer.ReportSource = report;
                frm.ShowDialog();
                }
                catch (Exception ex)
                {

                    MsgBox.showError("report loding proble"+ex);
                }
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadSetupData()
        {
            objAgentInfoList = agentServices.getAgentInfoBranchWise();
            BindingSource bsAgent = new BindingSource();
            bsAgent.DataSource = objAgentInfoList;

            AgentInformation agSelect = new AgentInformation();
            agSelect.businessName = Resources.SetupData__Select_;
            objAgentInfoList.Insert(0, agSelect);
            //AgentInformation agAll = new AgentInformation();
            //agAll.businessName = Resources.SetupData__All_;
            //objAgentInfoList.Insert(1, agAll);

            UtilityServices.fillComboBox(cmbAgentName, bsAgent, "businessName", "id");
            cmbAgentName.Text = "Select";
            cmbAgentName.SelectedIndex = 0;

            cmbUserStatus.DataSource = Enum.GetValues(typeof(UserStatus));
            cmbUserStatus.SelectedIndex = -1;
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
                if (cmbAgentName.SelectedIndex > 0)
                {
                    agentInformation = agentServices.getAgentInfoById(cmbAgentName.SelectedValue.ToString());
                }
                if (cmbAgentName.SelectedIndex < 1)
                {
                    cmbOutletName.DataSource = null;
                    cmbOutletName.Items.Clear();
                    return;
                }
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

                try
                {
                    SubAgentInformation saiSelect = new SubAgentInformation();
                    saiSelect.name = "(Select)";

                    //SubAgentInformation saiAll = new SubAgentInformation();
                    //saiAll.name = "(All)";

                    agentInformation.subAgents.Insert(0, saiSelect);
                    // agentInformation.subAgents.Insert(1, saiAll);
                }
                catch (Exception exp)
                {
                }

                UtilityServices.fillComboBox(cmbOutletName, bs, "name", "id");
                if (cmbOutletName.Items.Count > 0)
                {
                    cmbOutletName.SelectedIndex = 0;
                }
            }
        }



        private void LoadOutletReportData()
        {
            UserService userService = new UserService();
            OutletUserInfoResult outletInfoReportRow;
            //OutletUserInfoReportResultDto outletInfoReportRowoutletUserInfoListRow;
            //OutletUserInfoReportResult  FillOutletUserInfoSearchDto;

            _outletUserInfoReportResultDto = userService.GetUserBasicInformation(cmbOutletName.SelectedValue.ToString());
            try
            {
                //result = agentServices.getOutletUserInfoResultList(outletSearchDto);
                if (_outletUserInfoReportResultDto != null)
                {
                    _outletInfoReportList.Clear();
                    foreach (OutletUserInfoReportResultDto outlet in _outletUserInfoReportResultDto)
                    {

                        outletInfoReportRow = new OutletUserInfoResult();
                        outletInfoReportRow.userId = outlet.userId;
                        outletInfoReportRow.userName = outlet.userName;
                        outletInfoReportRow.userStatus = DoInitCap.ConvertTo_ProperCase(outlet.userStatus);
                        outletInfoReportRow.contactNo = outlet.contactNo;
                        if (outlet.creationDate != null)
                        {
                            outletInfoReportRow.creationDate = UtilityServices.getBDFormattedDateFromLong(outlet.creationDate ?? 0);
                        }
                        //outletInfoReportRow.creationDate = DateTime.ParseExact(outlet.creationDate);
                        outletInfoReportRow.creditLimit = outlet.creditLimit ?? 0;
                        outletInfoReportRow.debitLimit = outlet.debitLimit ?? 0;

                        _outletInfoReportList.Add(outletInfoReportRow);

                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Report data loading error.\n" + exp.Message);
            }
        }



        private bool CheckForValidation(bool showMessages)
        {
            OutletUserInfoReportSearchDto outletUserInfoSearchDto = new OutletUserInfoReportSearchDto();

            if (this.cmbAgentName.SelectedIndex > 0)
            {
                outletUserInfoSearchDto._agent = new AgentInformation { id = (long)cmbAgentName.SelectedValue };
            }
            else
            {
                if (showMessages == true)
                {
                    MsgBox.showWarning("Please select an Agent!");
                }
                return false;
            }

            if (this.cmbOutletName.SelectedIndex > 0)
            {
                outletUserInfoSearchDto._agent = new AgentInformation { id = (long)cmbAgentName.SelectedValue };
            }
            else
            {
                if (showMessages == true)
                {
                    MsgBox.showWarning("Please select an Outlet!");
                }
                return false;
            }
            if (this.cmbOutletName.SelectedIndex > 0)
            {
                if (cmbUserStatus.SelectedItem != null)
                {
                    outletUserInfoSearchDto.userStatus = (UserStatus)cmbUserStatus.SelectedItem;
                }
            }
            return true;
        }

        private void frmOutletUserInfoReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner = null;
        }


    }


    public class OutletUserInfoResult
    {
        public string userId = "";

        public string userName = "";

        public string userStatus = "";
        // public DateTime? creationDate = new DateTime();
        public string creationDate = "";
        public string contactNo = "";
        public Decimal creditLimit = 0;
        public Decimal debitLimit = 0;
    }

}
