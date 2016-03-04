using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using MISL.Ababil.Agent.Communication;
using MISL.Ababil.Agent.Infrastructure;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.Remittance;
using MISL.Ababil.Agent.Infrastructure.Models.dto;
using MISL.Ababil.Agent.Report.Reports;
using MISL.Ababil.Agent.Infrastructure.Models.common;

using MISL.Ababil.Agent.Services;
using MISL.Ababil.Agent.Infrastructure.Models.reports;
using MISL.Ababil.Agent.Report.DataSets;
using System.Globalization;
using MetroFramework.Forms;
using MetroFramework.Controls;

namespace MISL.Ababil.Agent.Report
{
    public partial class frmRemittanceRecord : MetroForm
    {
        private GUI gui = new GUI();
        List<AgentInformation> objAgentInfoList = new List<AgentInformation>();
        //AgentServices objAgentServices = new AgentServices();
        AgentInformation agentInformation = new AgentInformation();
        AgentServices agentServices = new AgentServices();

        public List<RemittanceDtoForRpt> _remittanceInformations = new List<RemittanceDtoForRpt>();

        public RemittanceReportDataset remList = new RemittanceReportDataset();
        public frmRemittanceRecord()
        {
            InitializeComponent();
            GetSetupData();
            controlActivity();
            ConfigUIEnhancement();
        }
        public void ConfigUIEnhancement()
        {
            gui = new GUI(this);
            gui.Config(ref cmbAgentName, ValidCheck.VALIDATIONTYPES.COMBOBOX_EMPTY, null);
            gui.Config(ref cmbSubAgnetName);
            gui.Config(ref cmbCompanyName);
            gui.Config(ref cmbStatus);
            gui.Config(ref dtpFromDate);
            gui.Config(ref dtpToDatae);
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

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            if (cmbAgentName.SelectedIndex <= 0 || cmbCompanyName.SelectedIndex <= 0)
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

            crRemittanceRportSearchByDateRange report = new crRemittanceRportSearchByDateRange();

            frmReportViewer viewer = new frmReportViewer();

            ReportHeaders rptHeaders = new ReportHeaders();
            rptHeaders = UtilityServices.getReportHeaders("Remittance Detail Report");

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

            LoadRemittanceInformation();

            report.SetDataSource(remList);
            viewer.crvReportViewer.ReportSource = report;
            viewer.ShowDialog(Parent);
        }
        private void fillExchangeHouseList(ref MetroComboBox cbxExHouse)
        {
            RemittanceCom remCom = new RemittanceCom();
            List<ExchangeHouse> exHouses = new List<ExchangeHouse>();
            ExchangeHouse exchangeHouse = new ExchangeHouse();
            exchangeHouse.companyName = "(Select)";
            exHouses.Add(exchangeHouse);
            ExchangeHouse exchangeHouse2 = new ExchangeHouse();
            exchangeHouse2.companyName = "(All)";
            exHouses.Add(exchangeHouse2);
            exHouses.AddRange(remCom.getListofExchangeHouse());

            BindingSource bs = new BindingSource();
            bs.DataSource = exHouses;
            fillComboBox(cbxExHouse, bs, "companyName", "id");
            cbxExHouse.SelectedIndex = 0;
        }

        private void fillExchangeHouseList(ref ComboBox cbxExHouse)
        {
            RemittanceCom remCom = new RemittanceCom();
            List<ExchangeHouse> exHouses = new List<ExchangeHouse>();
            ExchangeHouse exchangeHouse = new ExchangeHouse();
            exchangeHouse.companyName = "(Select)";
            exHouses.Add(exchangeHouse);
            ExchangeHouse exchangeHouse2 = new ExchangeHouse();
            exchangeHouse2.companyName = "(All)";
            exHouses.Add(exchangeHouse2);
            exHouses.AddRange(remCom.getListofExchangeHouse());

            BindingSource bs = new BindingSource();
            bs.DataSource = exHouses;
            fillComboBox(cbxExHouse, bs, "companyName", "id");
            cbxExHouse.SelectedIndex = 0;
        }
        public static void fillComboBox(ComboBox cmb, BindingSource bs, string displayMember, string valueMember)
        {
            cmb.DataSource = bs;
            cmb.DisplayMember = displayMember;
            cmb.ValueMember = valueMember;
        }

        public static void fillComboBox(MetroComboBox cmb, BindingSource bs, string displayMember, string valueMember)
        {
            cmb.DataSource = bs;
            cmb.DisplayMember = displayMember;
            cmb.ValueMember = valueMember;
        }

        private void LoadRemittanceInformation()
        {
            remList = new RemittanceReportDataset();
            #region comment


            //RemittanceReportInformation remittanceInformation;
            //ServiceResult result = RemittanceServices.GetRemittanceList(FillRemittanceSearchDto());

            //if (!result.Success)
            //{
            //    MessageBox.Show(result.Message);
            //    return;
            //}

            //List<Remittance> remittances = result.ReturnedObject as List<Remittance>;

            //_remittanceInformations.Clear();

            //if (remittances != null)
            //    foreach (Remittance remittance in remittances)
            //    {


            //        remittanceInformation = new RemittanceReportInformation();
            //        remittanceInformation.senderName = remittance.senderName;
            //        remittanceInformation.benificaryName = remittance.benificaryName;
            //        remittanceInformation.benificaryMobileNumber = remittance.benificaryMobileNumber;
            //        remittanceInformation.exchangeHouse = remittance.exchangeHouse;
            //        remittanceInformation.referanceNumber = remittance.referanceNumber;
            //        remittanceInformation.remittanceAmount = remittance.remittanceAmount;
            //        remittanceInformation.remittanceStatus = remittance.remittanceStatus;
            //        remittanceInformation.senderCountry = remittance.senderCountry;
            //        _remittanceInformations.Add(remittanceInformation);
            //    }

            #endregion
            ServiceResult result = RemittanceServices.GetRemittanceList(FillRemittanceSearchDto());
            remList = new RemittanceReportDataset();

            if (!result.Success)
            {
                MessageBox.Show(result.Message);
                return;
            }

            List<RemittanceDto> remittances = result.ReturnedObject as List<RemittanceDto>;
            List<RemittanceDtoForRpt> remittancesForRpt = new List<RemittanceDtoForRpt>();
            for (int i = 0; i < remittances.Count; i++)
            {
                RemittanceReportDataset.RemittanceReportTableRow RemittanceDtoForRpt =
                remList.RemittanceReportTable.NewRemittanceReportTableRow();
                RemittanceDtoForRpt.agentId = remittances[i].agentId;
                RemittanceDtoForRpt.agentName = remittances[i].agentName;
                RemittanceDtoForRpt.subAgentId = remittances[i].subAgentId;
                RemittanceDtoForRpt.subAgentName = remittances[i].subAgentName;
                RemittanceDtoForRpt.requestDateDT = UtilityServices.getDateFromLong(remittances[i].requestDate);
                RemittanceDtoForRpt.exchangeHouse = remittances[i].exchangeHouse;
                RemittanceDtoForRpt.benificiaryName = remittances[i].benificiaryName;
                RemittanceDtoForRpt.pINCode = remittances[i].pINCode;
                RemittanceDtoForRpt.mobileNo = remittances[i].mobileNo;
                RemittanceDtoForRpt.remitterName = remittances[i].remitterName;
                RemittanceDtoForRpt.remitterCountry = remittances[i].remitterCountry;

                if (remittances[i].disbursedDate != null)
                {
                    RemittanceDtoForRpt.disbursedDateStr = UtilityServices.getDateFromLong(remittances[i].disbursedDate).ToString("dd/MM/yyyy");
                }
                else
                    RemittanceDtoForRpt.disbursedDateStr = "";

                RemittanceDtoForRpt.amount = remittances[i].amount;
                RemittanceDtoForRpt.status = remittances[i].status.ToString();

                remList.RemittanceReportTable.AddRemittanceReportTableRow(RemittanceDtoForRpt);
                #region commint


                //RemittanceDtoForRpt objRemittanceDtoForRpt = new RemittanceDtoForRpt();
                //objRemittanceDtoForRpt.agentId = remittances[i].agentId;
                //objRemittanceDtoForRpt.agentName = remittances[i].agentName;
                //objRemittanceDtoForRpt.subAgentId = remittances[i].subAgentId;
                //objRemittanceDtoForRpt.subAgentName = remittances[i].subAgentName;
                //objRemittanceDtoForRpt.requestDateDT = UtilityServices.getDateFromLong(remittances[i].requestDate);
                //objRemittanceDtoForRpt.exchangeHouse = remittances[i].exchangeHouse;
                //objRemittanceDtoForRpt.benificiaryName = remittances[i].benificiaryName;
                //objRemittanceDtoForRpt.pINCode = remittances[i].pINCode;
                //objRemittanceDtoForRpt.mobileNo = remittances[i].mobileNo;
                //objRemittanceDtoForRpt.remitterName = remittances[i].remitterName;
                //objRemittanceDtoForRpt.remitterCountry = remittances[i].remitterCountry;
                //if (remittances[i].disbursedDate != null)
                //{
                //    objRemittanceDtoForRpt.disbursedDateStr = UtilityServices.getDateFromLong(remittances[i].disbursedDate).ToShortDateString();
                //}
                //else
                //    objRemittanceDtoForRpt.disbursedDateStr = "";

                //objRemittanceDtoForRpt.amount = remittances[i].amount;
                //objRemittanceDtoForRpt.status = remittances[i].status.ToString();

                //remittancesForRpt.Add(objRemittanceDtoForRpt);
                #endregion
            }
            remList.AcceptChanges();

            //_remittanceInformations = remittancesForRpt;

        }

        private RemittanceSearchDto FillRemittanceSearchDto()
        {
            RemittanceSearchDto remittanceSearchDto = new RemittanceSearchDto();

            if (cmbAgentName.SelectedIndex > 1)
            {
                remittanceSearchDto.agentInformation = new AgentInformation { id = (long)cmbAgentName.SelectedValue };
            }
            if (cmbSubAgnetName.SelectedIndex > 1)
            {
                remittanceSearchDto.subAgentInformation = new SubAgentInformation { id = (long)cmbSubAgnetName.SelectedValue };
            }

            if (SessionInfo.rights.Contains("REMITTANCE_FIRST_APPROVE") ||
    SessionInfo.rights.Contains("REMITTANCE_SECOND_APPROVE"))
            {
                remittanceSearchDto.agentInformation = null;
                remittanceSearchDto.subAgentInformation = null;
            }


            if (cmbCompanyName.SelectedIndex > 1)
            {
                remittanceSearchDto.exchangeHouse = new ExchangeHouse { id = (long)cmbCompanyName.SelectedValue };
            }

            if (cmbStatus.SelectedIndex > -1)
            {
                remittanceSearchDto.remittanceStatus = (int)cmbStatus.SelectedValue;
            }
            else
            {
                remittanceSearchDto.remittanceStatus = null;
            }



            //remittanceSearchDto.fromDate = UtilityServices.GetLongDate(UtilityServices.ParseDateTime(dtpFromDate.Date));
            //remittanceSearchDto.toDate = UtilityServices.GetLongDate(UtilityServices.ParseDateTime(dtpToDatae.Date));


            //accountSearchDto.fromDate = UtilityServices.GetLongDate(UtilityServices.ParseDateTime(dtpFromDate.Date));
            remittanceSearchDto.fromDate = UtilityServices.GetLongDate
            (
                DateTime.ParseExact(dtpFromDate.Date.Replace("/", "-"), "dd-MM-yyyy", CultureInfo.InvariantCulture)
            );

            //accountSearchDto.toDate = UtilityServices.GetLongDate(UtilityServices.ParseDateTime(dtpToDate.Date));
            remittanceSearchDto.toDate = UtilityServices.GetLongDate
            (
                DateTime.ParseExact(dtpToDatae.Date.Replace("/", "-"), "dd-MM-yyyy", CultureInfo.InvariantCulture)
            );

            return remittanceSearchDto;
        }


        private void GetSetupData()
        {
            fillExchangeHouseList(ref cmbCompanyName);
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
                Array dataSource = Enum.GetValues(typeof(RemittanceStatus));
                //var appended;

                cmbStatus.Items.Insert(0, "[Select");
                cmbStatus.Items.Insert(1, "[All]");
                cmbStatus.DataSource = dataSource;
                cmbStatus.SelectedIndex = -1;
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
        #region ========harun(22-09-15)=========

        //private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        //{
        //    mtbFromDate.Text = dtpFromDate.Value.ToString("dd-MM-yyyy");
        //}

        //private void dtpToDatae_ValueChanged(object sender, EventArgs e)
        //{
        //    mtbToDate.Text = dtpToDatae.Value.ToString("dd-MM-yyyy");
        //}

        //private void mtbFromDate_KeyUp(object sender, KeyEventArgs e)
        //{
        //    //suppressed to avoid mtb to dtp conversion
        //    try
        //    {
        //        string[] str = mtbFromDate.Text.Split('-');
        //        DateTime d = new DateTime(int.Parse(str[2].Trim()), int.Parse(str[1].Trim()), int.Parse(str[0].Trim()));
        //        dtpFromDate.Value = d;
        //    }
        //    catch (Exception ex) { }
        //}

        //private void mtbToDatae_KeyUp(object sender, KeyEventArgs e)
        //{
        //    //suppressed to avoid mtb to dtp conversion
        //    try
        //    {
        //        string[] str = mtbToDate.Text.Split('-');
        //        DateTime d = new DateTime(int.Parse(str[2].Trim()), int.Parse(str[1].Trim()), int.Parse(str[0].Trim()));
        //        dtpToDatae.Value = d;
        //    }
        //    catch (Exception ex) { }
        //}
        #endregion
        private void frmRemittanceRecord_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = SessionInfo.currentDate;
            dtpToDatae.Value = SessionInfo.currentDate;
        }

        private void cmbSubAgnetName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbCompanyName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblProduct_Click(object sender, EventArgs e)
        {

        }

        private void lblSubAgent_Click(object sender, EventArgs e)
        {

        }

        private void lblAgent_Click(object sender, EventArgs e)
        {

        }

        private void dtpToDatae_Load(object sender, EventArgs e)
        {

        }

        private void dtpFromDate_Load(object sender, EventArgs e)
        {

        }

        private void frmRemittanceRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner = null;
        }
    }

    public class RemittanceReportInformation : Remittance
    {
        public string SenderCountryName
        {
            get
            {
                if (senderCountry != null) return senderCountry.name;
                return "";
            }
        }

        public string ExchangeHouseName
        {
            get
            {
                if (exchangeHouse != null) return exchangeHouse.companyName;
                return "";
            }
        }

        public string StatusName
        {
            get { return remittanceStatus.ToString(); }
        }


    }
}
