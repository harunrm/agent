using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using MISL.Ababil.Agent.Services;
using MISL.Ababil.Agent.Infrastructure;
using MISL.Ababil.Agent.Module.ChequeRequisition.Models;
using MISL.Ababil.Agent.Module.ChequeRequisition.Models.Report;
using MISL.Ababil.Agent.Module.ChequeRequisition.Service;
using System.Globalization;
using MISL.Ababil.Agent.Report.Reports;
using MISL.Ababil.Agent.Infrastructure.Models.reports;
using CrystalDecisions.CrystalReports.Engine;
using MISL.Ababil.Agent.Module.ChequeRequisition.DataSets;
using MISL.Ababil.Agent.Module.Common.UI.MessageUI;

namespace MISL.Ababil.Agent.Module.ChequeRequisition.Report
{
    public partial class frmChequeRequisitionInformation : MetroForm
    {
        List<AgentInformation> objAgentInfoList = new List<AgentInformation>();
        AgentServices agentServices = new AgentServices();
        AgentInformation agentInformation = new AgentInformation();
        TransactionService transactionService = new TransactionService();
        ServiceResult result;
        List<ChequeRequisitionReportResultDto> chqRequisitionReportResult;

        public List<ChequeRequisitionReport> _chqRequisitionReportList = new List<ChequeRequisitionReport>();

        public frmChequeRequisitionInformation()
        {
            InitializeComponent();

            dtpDateFrom.Value = SessionInfo.currentDate;
            dtpDateTo.Value = SessionInfo.currentDate;
            LoadSetupData();
            controlActivity();
            ConfigUIEnhancement();
        }

        private void LoadSetupData()
        {
            try
            {
                List<ChequeRequisitionStatusList> statusList = Enum.GetValues(typeof(ChequeRequisitionStatus)).Cast<ChequeRequisitionStatus>()
                                                                                .Select(o => new ChequeRequisitionStatusList
                                                                                {
                                                                                    ChequeRequisitionStatus = o.ToString(),
                                                                                }).ToList();
                ChequeRequisitionStatusList allStatus = new ChequeRequisitionStatusList();
                BindingSource bs = new BindingSource();
                allStatus.ChequeRequisitionStatus = "All";
                statusList.Insert(0, allStatus);
                bs.DataSource = statusList;
                UtilityServices.fillComboBox(cmbStatus, bs, "ChequeRequisitionStatus", "ChequeRequisitionStatus");
                List<UrgencyTypeList> urgencyTypeList = Enum.GetValues(typeof(UrgencyType)).Cast<UrgencyType>()
                                                                                            .Select(u => new UrgencyTypeList
                                                                                            {
                                                                                                UrgencyType = u.ToString(),
                                                                                            }).ToList();
                UrgencyTypeList allUrgencyType = new UrgencyTypeList();
                BindingSource bsUrgncy = new BindingSource();
                allUrgencyType.UrgencyType = "All";
                urgencyTypeList.Insert(0, allUrgencyType);
                bsUrgncy.DataSource = urgencyTypeList;
                UtilityServices.fillComboBox(cmbUrgencyType, bsUrgncy, "UrgencyType", "UrgencyType");

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
                //cmbAgentName.Text = "Select";
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
            }
        }
        public void ConfigUIEnhancement()
        {
            //gui = new GUI(this);
            //gui.Config(ref cmbAgentName, ValidCheck.VALIDATIONTYPES.COMBOBOX_EMPTY, null);
            //gui.Config(ref cmbSubAgnetName);
            //gui.Config(ref dtpDateFrom);
            //gui.Config(ref dtpDateTo);
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

                    SubAgentInformation saiAll = new SubAgentInformation();
                    saiAll.name = "(All)";

                    agentInformation.subAgents.Insert(0, saiSelect);
                    agentInformation.subAgents.Insert(1, saiAll);
                }
                catch (Exception exp)
                { }
                UtilityServices.fillComboBox(cmbSubAgnetName, bs, "name", "id");
                if (cmbSubAgnetName.Items.Count > 0)
                { cmbSubAgnetName.SelectedIndex = 0; }
            }
        }

        private List<ChequeRequisitionReportResultDto> LoadChequeRequisitionRegisterData()
        {
            ChequeRequisitionService service = new ChequeRequisitionService();
            ChequeRequisitionReport chqRequisitionRow;
            _chqRequisitionReportList = new List<ChequeRequisitionReport>();

            ChequeRequisitionReportSearchDto requisitionReportSearchDto = FillTxnReportSearchDto();
            try
            {
                chqRequisitionReportResult = service.getChequeRequisitionReport(requisitionReportSearchDto);
                //return chqRequisitionReportResult;
                // if (result.Success)
                //if (result != null)
                //   {
                //List<ChequeRequisitionReportResultDto> txnReportResult = result.ReturnedObject as List<ChequeRequisitionReportResultDto>;

                if (chqRequisitionReportResult != null)
                {
                    foreach (ChequeRequisitionReportResultDto chqRecord in chqRequisitionReportResult)
                    {
                        chqRequisitionRow = new ChequeRequisitionReport();
                        chqRequisitionRow.agentId = chqRecord.agentId;
                        chqRequisitionRow.agentName = chqRecord.agentName;
                        chqRequisitionRow.subAgentId = chqRecord.subAgentId;
                        chqRequisitionRow.subAgentName = chqRecord.subAgentName;
                        chqRequisitionRow.accountNumber = chqRecord.accountNumber;
                        chqRequisitionRow.accountTitle = DoInitCap.ConvertTo_ProperCase(chqRecord.accountTitle);
                        chqRequisitionRow.noOfLeaf = chqRecord.noOfLeaf;
                        chqRequisitionRow.chequeDeliveryMedium = chqRecord.chequeDeliveryMedium.ToString();
                        chqRequisitionRow.deliveryFrom = chqRecord.deliveryFrom;
                        chqRequisitionRow.requestDate = UtilityServices.getBDFormattedDateFromLong(chqRecord.requestDate);
                        chqRequisitionRow.chequeRequisitionStatus = chqRecord.chequeRequisitionStatus.ToString();
                        chqRequisitionRow.subAgentCode = chqRecord.subAgentCode;


                        _chqRequisitionReportList.Add(chqRequisitionRow);
                    }
                }
                // return _chqRequisitionReportList;
                //}
                return chqRequisitionReportResult;
            }
            catch (Exception exp)
            {
                MessageBox.Show("Report data loading error.\n" + exp.Message);
                return null;
            }
        }
        private ChequeRequisitionReportSearchDto FillTxnReportSearchDto()
        {
            ChequeRequisitionReportSearchDto chqReportSearchDto = new ChequeRequisitionReportSearchDto();
            try
            {
                if (this.cmbAgentName.SelectedIndex > -1)
                {
                    if (cmbAgentName.SelectedIndex != 0 && cmbAgentName.SelectedIndex != 1)
                    {
                        chqReportSearchDto.agentId = (long)cmbAgentName.SelectedValue;
                    }
                    else if (cmbAgentName.SelectedIndex == 1 || cmbAgentName.SelectedIndex == 0)
                    {
                        chqReportSearchDto.agentId = 0;
                    }
                }
                if (this.cmbSubAgnetName.SelectedIndex > -1)
                {
                    if (cmbSubAgnetName.SelectedIndex != 0 && cmbSubAgnetName.SelectedIndex != 1)
                    {
                        chqReportSearchDto.subAgentId = (long)cmbSubAgnetName.SelectedValue;
                    }
                    else if (cmbSubAgnetName.SelectedIndex == 1 || cmbSubAgnetName.SelectedIndex == 0)
                    {
                        chqReportSearchDto.subAgentId = 0;
                    }
                }
                else chqReportSearchDto.subAgentId = 0;

                if (cmbUrgencyType.SelectedValue == "All") chqReportSearchDto.urgencyType = null;
                else chqReportSearchDto.urgencyType = (UrgencyType)Enum.Parse(typeof(UrgencyType), cmbUrgencyType.SelectedValue.ToString());
                if (cmbStatus.SelectedValue == "All") chqReportSearchDto.chequeRequisitionStatus = null;
                else chqReportSearchDto.chequeRequisitionStatus = (ChequeRequisitionStatus)Enum.Parse(typeof(ChequeRequisitionStatus), cmbStatus.SelectedValue.ToString());

                //TxnReportSearchDto.fromDate = Convert.ToDateTime(UtilityServices.GetLongDate(DateTime.ParseExact(dtpDateFrom.Date.Replace("/", "-"), "dd-MM-yyyy", CultureInfo.InvariantCulture)));
                //TxnReportSearchDto.toDate = Convert.ToDateTime(UtilityServices.GetLongDate(DateTime.ParseExact(dtpDateTo.Date.Replace("/", "-"), "dd-MM-yyyy", CultureInfo.InvariantCulture)));

                chqReportSearchDto.fromDate = DateTime.ParseExact(dtpDateFrom.Date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                chqReportSearchDto.toDate = DateTime.ParseExact(dtpDateTo.Date, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                return chqReportSearchDto;
            }
            catch (Exception exp)
            { MessageBox.Show("Error filling search object.\n" + exp.Message); return null; }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShowReport_Click_1(object sender, EventArgs e)
        {
            try
            {
                #region Validation
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
                    MessageBox.Show("Please select an agent.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                #endregion

                crChequeRequisitionRegister report = new crChequeRequisitionRegister();
                frmReportViewer viewer = new frmReportViewer();

                ReportHeaders rptHeaders = new ReportHeaders();
                rptHeaders = UtilityServices.getReportHeaders("Cheque Requisition Report");

                TextObject txtBankName = report.ReportDefinition.ReportObjects["txtBankName"] as TextObject;
                TextObject txtBranchName = report.ReportDefinition.ReportObjects["txtBranchName"] as TextObject;
                TextObject txtBranchAddress = report.ReportDefinition.ReportObjects["txtBranchAddress"] as TextObject;
                TextObject txtReportHeading = report.ReportDefinition.ReportObjects["txtReportHeading"] as TextObject;
                TextObject txtPrintUser = report.ReportDefinition.ReportObjects["txtPrintUser"] as TextObject;
                TextObject txtPrintDate = report.ReportDefinition.ReportObjects["txtPrintDate"] as TextObject;
                TextObject txtFromDate = report.ReportDefinition.ReportObjects["txtFromDate"] as TextObject;
                TextObject txtToDate = report.ReportDefinition.ReportObjects["txtToDate"] as TextObject;
                TextObject txtDeliveryFrom = report.ReportDefinition.ReportObjects["txtDeliveryFrom"] as TextObject;
                if (cmbStatus.SelectedValue == ChequeRequisitionStatus.Delivered.ToString())
                {
                    txtDeliveryFrom.Text = "Request From";
                }
                else txtDeliveryFrom.Text = "Delivery From";
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
                    txtPrintDate.Text = rptHeaders.printDate.ToString("dd/MM/yyyy").Replace("-", "/");
                }

                txtFromDate.Text = dtpDateFrom.Date;
                txtToDate.Text = dtpDateTo.Date;

                LoadChequeRequisitionRegisterData();

                report.SetDataSource(_chqRequisitionReportList);
                viewer.crvReportViewer.ReportSource = report;
                viewer.ShowDialog(this.Parent);
            }
            catch (Exception exp)
            {
               // MessageBox.Show(exp.Message);
                MsgBox.showError(exp.Message);
            }

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbAgentName_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (!cmbAgentName.Focused) return;

            try
            {
                if (cmbAgentName.SelectedIndex > 1)
                { agentInformation = agentServices.getAgentInfoById(cmbAgentName.SelectedValue.ToString()); }
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
            { MessageBox.Show(ex.Message); }
            setSubagent();

        }


        private void frmChequeRequisitionInformation_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner = null;
        }
    }

    public class UrgencyTypeList
    {
        public string UrgencyType { get; set; }
    }

    public class ChequeRequisitionReport
    {
        public long agentId = 0;
        public string agentName = "";
        public long subAgentId = 0;
        public string subAgentName = "";
        public string accountNumber = "";
        public string accountTitle = "";
        public long noOfLeaf = 0;
        public string chequeDeliveryMedium = "";
        public string deliveryFrom = "";
        public string requestDate = "";
        public string chequeRequisitionStatus = "";
        public string subAgentCode = "";
    }

}
