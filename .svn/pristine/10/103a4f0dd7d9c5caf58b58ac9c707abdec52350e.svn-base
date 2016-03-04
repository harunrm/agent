using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using MISL.Ababil.Agent.Infrastructure;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using MISL.Ababil.Agent.Services;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account;
using MISL.Ababil.Agent.Infrastructure.Models.dto;
using MISL.Ababil.Agent.Infrastructure.Validation;
using MISL.Ababil.Agent.Report.Reports;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using System.Globalization;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.ssp;
using MISL.Ababil.Agent.Infrastructure.Models.reports;
using MetroFramework.Forms;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.termaccount;
using MISL.Ababil.Agent.LocalStorageService;

namespace MISL.Ababil.Agent.Report
{

    public partial class frmAccountWiseBalance : MetroForm
    {
        private GUI gui = new GUI();
        List<AccountBalanceInformation> _balanceInformations = new List<AccountBalanceInformation>();
        List<AgentInformation> objAgentInfoList = new List<AgentInformation>();
        AgentServices objAgentServices = new AgentServices();
        AgentInformation agentInformation = new AgentInformation();
        AgentServices agentServices = new AgentServices();
        private AccountDto accountDto;
        private List<AgentProduct> _agentProducts;
        private List<SspProductType> _agentSspProducts;

        public enum ProductTypes
        {
            Deposit,
            Investment,
            ITD_MTD
        }

        public frmAccountWiseBalance()
        {
            InitializeComponent();
            GetSetupData();

            //suppressed
            try
            {
                cmbAgentName.SelectedIndex = 0;
                cmbProduct.SelectedIndex = 0;
                //mtbToDate.Text = dtpToDate.Value.ToString("dd-MM-yyyy");

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

            gui.Config(ref cmbProduct, ValidCheck.VALIDATIONTYPES.COMBOBOX_EMPTY, null);
            gui.Config(ref dtpToDate);
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
                else                                                                            //subagent user
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

        //public class ComboboxItem
        //{
        //    public string Text { get; set; }
        //    public object Value { get; set; }

        //    public override string ToString()
        //    {
        //        return Text;
        //    }
        //}

        private void btnViewReport_Click(object sender, EventArgs e)
        {

            if (cmbAgentName.SelectedIndex > 0 && cmbProduct.SelectedIndex > 0)
            {

                crAccountWiseBalanceOnDate_Eng objReport = new crAccountWiseBalanceOnDate_Eng();
                frmReportViewer frm = new frmReportViewer();

                try
                {
                    // DateTime toDateEntry = DateTime.ParseExact(mtbToDate.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    //DateTime toDateEntry = UtilityServices.ParseDateTime(dtpToDate.Date);
                    DateTime toDateEntry = DateTime.ParseExact(dtpToDate.Date.Replace("/", "-"), "dd-MM-yyyy", CultureInfo.InvariantCulture);

                    if (toDateEntry > SessionInfo.currentDate)
                    {
                        MessageBox.Show("Future date is not allowed!", "Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Invalid date format!", "Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                ReportHeaders rptHeaders = new ReportHeaders();
                rptHeaders = UtilityServices.getReportHeaders("Account Balance As on Date");

                TextObject txtBankName = objReport.ReportDefinition.ReportObjects["txtBankName"] as TextObject;
                TextObject txtBranchName = objReport.ReportDefinition.ReportObjects["txtBranchName"] as TextObject;
                TextObject txtBranchAddress = objReport.ReportDefinition.ReportObjects["txtBranchAddress"] as TextObject;
                TextObject txtPrintUser = objReport.ReportDefinition.ReportObjects["txtPrintUser"] as TextObject;
                TextObject txtPrintDate = objReport.ReportDefinition.ReportObjects["txtPrintDate"] as TextObject;
                if (rptHeaders != null)
                {
                    if (rptHeaders.branchDto != null)
                    {
                        txtBankName.Text = rptHeaders.branchDto.bankName;
                        txtBranchName.Text = rptHeaders.branchDto.branchName;
                        txtBranchAddress.Text = rptHeaders.branchDto.branchAddress;
                    }
                    txtPrintUser.Text = rptHeaders.printUser;
                    txtPrintDate.Text = rptHeaders.printDate.ToString("dd-MM-yyyy").Replace("-","/");
                }

                if (rBtnDeposit.Checked == true)
                {
                    LoadAccountBalanceInformation(ProductType.Deposit);

                }
                if (rBtnITDMTD.Checked == true)
                {
                    LoadAccountBalanceInformation(ProductType.SSP);
                }
                if (rBtnMTD.Checked == true)
                {
                    LoadAccountBalanceInformation(ProductType.MTDR);
                }

                objReport.SetDataSource(_balanceInformations);

                //objReport.SetParameterValue("DateAsOn", DateTime.ParseExact(dtpToDate.Text.Trim(), "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture));
                //objReport.SetParameterValue("DateAsOn", UtilityServices.ParseDateTime(dtpToDate.Date));
                objReport.SetParameterValue("DateAsOn", dtpToDate.Value);
                frm.crvReportViewer.ReportSource = objReport;

                frm.ShowDialog(this.Parent);
            }
            else
            {
                MessageBox.Show("Please select an option!", "Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void LoadAccountBalanceInformation(ProductType productType)
        {
            AccountBalanceInformation accountBalanceInformation;
            AccountSearchDto accountSearchDto = new AccountSearchDto();
            SspAccountSearchDto sspAccountSearchDto = new SspAccountSearchDto();

            if (productType == ProductType.Deposit)
            {
                accountSearchDto = FillSearchDto();
            }
            if (productType == ProductType.SSP)
            {
                sspAccountSearchDto = FillSspSearchDto();
            }

            if (productType == ProductType.MTDR)
            {
                sspAccountSearchDto = FillSspSearchDto();
            }

            ServiceResult result1 = new ServiceResult();
            _balanceInformations.Clear();

            try
            {
                // accountSearchDto.product = new AgentProduct { id = _agentProducts[2].id };
                if (productType == ProductType.Deposit)
                {
                    result1 = AccountBalanceReportService.GetAccountBalanceList(accountSearchDto);
                }
                if (productType == ProductType.SSP)
                {
                    result1 = AccountBalanceReportService.GetAccountBalanceList(sspAccountSearchDto, productType);
                }
                if (productType == ProductType.MTDR)
                {
                    result1 = AccountBalanceReportService.GetAccountBalanceList(sspAccountSearchDto, productType);
                }

                if (!result1.Success)
                {
                    MessageBox.Show(result1.Message);
                    return;
                }

                List<AccountBlanceDto> accountOpenings = result1.ReturnedObject as List<AccountBlanceDto>;

                if (accountOpenings != null)
                {
                    foreach (AccountBlanceDto balanceDto in accountOpenings)
                    {
                        accountBalanceInformation = new AccountBalanceInformation();
                        accountBalanceInformation.AccountNumber = balanceDto.accountNumber;
                        accountBalanceInformation.AccountName = balanceDto.accTitle;
                        if (balanceDto.balance != null) accountBalanceInformation.Balance = (decimal)balanceDto.balance;
                        //accountBalanceInformation.ProductName = _agentProducts[2].productTitle;
                        accountBalanceInformation.ProductName = balanceDto.productTitle;

                        accountBalanceInformation.AgentID = balanceDto.agentId;
                        accountBalanceInformation.AgentName = balanceDto.agentName;
                        accountBalanceInformation.SubAgentID = balanceDto.subAgentId;
                        accountBalanceInformation.SubAgentName = balanceDto.subAgentName;

                        _balanceInformations.Add(accountBalanceInformation);
                    }
                }
            }
            catch (Exception)
            {
                //ignored
            }
        }

        private AccountSearchDto FillSearchDto()
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
                    accountSearchDto.agent = null; //new AgentInformation();
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
                    accountSearchDto.subAgent = new SubAgentInformation { id = (long)cmbSubAgnetName.SelectedValue };
                }
                if (cmbSubAgnetName.SelectedIndex == 1 || cmbSubAgnetName.SelectedIndex == 0)
                {
                    accountSearchDto.subAgent = null; //new SubAgentInformation();
                }
                if (cmbSubAgnetName.SelectedIndex == 0)
                {
                    //MessageBox.Show("Please select an option!", "Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //return null;
                }
            }
            if (this.cmbProduct.SelectedIndex > -1)
            {
                if (cmbProduct.SelectedIndex != 0 || cmbProduct.SelectedIndex != 1)
                {

                    accountSearchDto.product = new AgentProduct { id = (long)(cmbProduct.SelectedValue) };
                    if (rBtnDeposit.Checked == true)
                    {
                        accountSearchDto.product.productType = ProductType.Deposit;
                    }
                    else
                    {
                        accountSearchDto.product.productType = ProductType.SSP;
                    }
                    //accountSearchDto.product = new SspProductType { id = (long)(cmbProduct.SelectedValue) };


                }
                if (cmbProduct.SelectedIndex == 1 || cmbProduct.SelectedIndex == 0)
                {
                    accountSearchDto.product = null;
                }
                if (cmbProduct.SelectedIndex == 0)
                {
                    //MessageBox.Show("Please select an option!", "Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //return null;
                }
            }

            //accountSearchDto.toDate = UtilityServices.GetLongDate(UtilityServices.ParseDateTime(dtpToDate.Date));
            accountSearchDto.toDate = UtilityServices.GetLongDate(DateTime.ParseExact(dtpToDate.Date.Replace("/", "-"), "dd-MM-yyyy", CultureInfo.InvariantCulture));

            return accountSearchDto;
        }

        private SspAccountSearchDto FillSspSearchDto()
        {
            SspAccountSearchDto accountSearchDto = new SspAccountSearchDto();

            if (this.cmbAgentName.SelectedIndex > -1)
            {
                if (cmbAgentName.SelectedIndex != 0 || cmbAgentName.SelectedIndex != 1)
                {
                    accountSearchDto.agent = new AgentInformation { id = (long)cmbAgentName.SelectedValue };
                }
                if (cmbAgentName.SelectedIndex == 1 || cmbAgentName.SelectedIndex == 0)
                {
                    accountSearchDto.agent = null; //new AgentInformation();
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
                    accountSearchDto.subAgent = new SubAgentInformation { id = (long)cmbSubAgnetName.SelectedValue };
                }
                if (cmbSubAgnetName.SelectedIndex == 1 || cmbSubAgnetName.SelectedIndex == 0)
                {
                    accountSearchDto.subAgent = null; //new SubAgentInformation();
                }
                if (cmbSubAgnetName.SelectedIndex == 0)
                {
                    //MessageBox.Show("Please select an option!", "Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //return null;
                }
            }
            if (this.cmbProduct.SelectedIndex > -1)
            {
                if (cmbProduct.SelectedIndex != 0 && cmbProduct.SelectedIndex != 1)
                {
                    accountSearchDto.product = new SspProductType { id = (long)(cmbProduct.SelectedValue) };
                }
                if (cmbProduct.SelectedIndex == 1 || cmbProduct.SelectedIndex == 0)
                {
                    accountSearchDto.product = null;
                }
                if (cmbProduct.SelectedIndex == 0)
                {
                    //MessageBox.Show("Please select an option!", "Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //return null;
                }
            }

            //accountSearchDto.toDate = UtilityServices.GetLongDate(UtilityServices.ParseDateTime(dtpToDate.Date));
            accountSearchDto.toDate = UtilityServices.GetLongDate(DateTime.ParseExact(dtpToDate.Date.Replace("/", "-"), "dd-MM-yyyy", CultureInfo.InvariantCulture));

            return accountSearchDto;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static void fillComboBox(ComboBox cmb, BindingSource bs, string displayMember, string valueMember)
        {
            cmb.DataSource = bs;
            cmb.DisplayMember = displayMember;
            cmb.ValueMember = valueMember;




        }

        private void GetSetupData()
        {
            //string configvalue1 = ConfigurationManager.AppSettings["countryId"];
            try
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


                cmbAgentName.SelectedIndex = -1;

                ///////////////////////////////////////////////////////////////////////////////////////////////
                // All Products, kept for later usage.
                ///////////////////////////////////////////////////////////////////////////////////////////////
                //BindingSource bs1 = new BindingSource();
                //ServiceResult serviceResult = AccountOpeningReportService.GetAllAgentProducts();
                //if (serviceResult.Success)
                //{
                //    AgentProduct apSelect = new AgentProduct();
                //    apSelect.productTitle = "(Select)";
                //    _agentProducts = (List<AgentProduct>)serviceResult.ReturnedObject;
                //    (_agentProducts).Insert(0, apSelect);

                //    AgentProduct apAll = new AgentProduct();
                //    apAll.productTitle = "(All)";
                //    (_agentProducts).Insert(1, apAll);


                //    bs1.DataSource = serviceResult.ReturnedObject as List<AgentProduct>;

                //    UtilityServices.fillComboBox(cmbProduct, bs1, "productTitle", "id");

                //    cmbProduct.SelectedIndex = -1;
                //}
                ///////////////////////////////////////////////////////////////////////////////////////////////
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

        private void frmAccountWiseBalance_Load(object sender, EventArgs e)
        {
            dtpToDate.Value = SessionInfo.currentDate;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        //private void mtbToDate_KeyUp(object sender, KeyEventArgs e)
        //{
        //    //suppressed to avoid mtb to dtp conversion
        //    try
        //    {
        //        string[] str = mtbToDate.Text.Split('-');
        //        DateTime d = new DateTime(int.Parse(str[2].Trim()), int.Parse(str[1].Trim()), int.Parse(str[0].Trim()));
        //        dtpToDate.Value = d;
        //    }
        //    catch (Exception ex) { }
        //}

        private void rBtnDeposit_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtnDeposit.Checked == true)
            {
                cmbProduct.Enabled = true;
                BindingSource bs1 = new BindingSource();
                ServiceResult serviceResult = AccountOpeningReportService.GetDepositProducts();
                if (serviceResult.Success)
                {
                    _agentProducts = serviceResult.ReturnedObject as List<AgentProduct>;

                    AgentProduct apSelect = new AgentProduct();
                    apSelect.productTitle = "(Select)";
                    _agentProducts = (List<AgentProduct>)serviceResult.ReturnedObject;
                    (_agentProducts).Insert(0, apSelect);

                    AgentProduct apAll = new AgentProduct();
                    apAll.productTitle = "(All)";
                    (_agentProducts).Insert(1, apAll);

                    bs1.DataSource = _agentProducts;

                    UtilityServices.fillComboBox(cmbProduct, bs1, "productTitle", "id");

                    cmbProduct.SelectedIndex = 0;
                }
            }
        }

        private void rBtnITDMTD_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtnITDMTD.Checked == true)
            {
                cmbProduct.Enabled = true;
                BindingSource bs1 = new BindingSource();
                bs1.DataSource = null;
                //_itdProducts
                List<TermProductType> _itdProducts = _itdProducts = LocalCache.GetITDProducts();
                {
                    if (_itdProducts.Count > 0)
                    {
                        if (_itdProducts[0].productDescription != "(Select)")
                        {
                            TermProductType apSelect = new TermProductType();
                            apSelect.productDescription = "(Select)";
                            (_itdProducts).Insert(0, apSelect);
                        }
                        if (_itdProducts[1].productDescription != "(All)")
                        {
                            TermProductType apAll = new TermProductType();
                            apAll.productDescription = "(All)";
                            (_itdProducts).Insert(1, apAll);
                        }
                    }
                }
                if (
                        _itdProducts[3].productDescription == "(Select)"
                    ||
                        _itdProducts[3].productDescription == "(All)"

                    )
                {
                    _itdProducts.RemoveAt(3);
                }
                if (
                        _itdProducts[2].productDescription == "(Select)"
                    ||
                        _itdProducts[2].productDescription == "(All)"

                    )
                {
                    _itdProducts.RemoveAt(2);
                }
                bs1.DataSource = _itdProducts;

                UtilityServices.fillComboBox(cmbProduct, bs1, "productDescription", "id");
                cmbProduct.SelectedIndex = 0;
            }
            //if (rBtnITDMTD.Checked == true)
            //{
            //    cmbProduct.Enabled = true;
            //    BindingSource bs1 = new BindingSource();
            //    ServiceResult serviceResult = AccountOpeningReportService.GetSchemeProducts();
            //    if (serviceResult.Success)
            //    {
            //        _agentSspProducts = serviceResult.ReturnedObject as List<SspProductType>;

            //        SspProductType apSelect = new SspProductType();
            //        apSelect.productDescription = "(Select)";
            //        _agentSspProducts = (List<SspProductType>)serviceResult.ReturnedObject;
            //        (_agentSspProducts).Insert(0, apSelect);

            //        SspProductType apAll = new SspProductType();
            //        apAll.productDescription = "(All)";
            //        (_agentSspProducts).Insert(1, apAll);

            //        bs1.DataSource = _agentSspProducts;

            //        UtilityServices.fillComboBox(cmbProduct, bs1, "productDescription", "id");

            //        cmbProduct.SelectedIndex = 0;
            //    }
            //}
        }

        private void rBtnMTD_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtnMTD.Checked == true)
            {
                cmbProduct.Enabled = true;
                BindingSource bs1 = new BindingSource();
                bs1.DataSource = null;
                //_mtdProducts
                List<TermProductType> _mtdProducts = LocalCache.GetMTDProducts();
                {
                    if (_mtdProducts.Count > 0)
                    {
                        if (_mtdProducts[0].productDescription != "(Select)")
                        {
                            TermProductType apSelect = new TermProductType();
                            apSelect.productDescription = "(Select)";
                            (_mtdProducts).Insert(0, apSelect);
                        }
                        if (_mtdProducts[1].productDescription != "(All)")
                        {
                            TermProductType apAll = new TermProductType();
                            apAll.productDescription = "(All)";
                            (_mtdProducts).Insert(1, apAll);
                        }
                        if (_mtdProducts.Count > 3)
                        {
                            if (
                                  _mtdProducts[3].productDescription == "(Select)"
                              ||
                                  _mtdProducts[3].productDescription == "(All)"

                              )
                            {
                                _mtdProducts.RemoveAt(3);
                            }
                        }
                        if (_mtdProducts.Count > 2)
                        {
                            if (
                                _mtdProducts[2].productDescription == "(Select)"
                            ||
                                _mtdProducts[2].productDescription == "(All)"

                            )
                            {
                                _mtdProducts.RemoveAt(2);
                            }
                        }
                    }
                }
                bs1.DataSource = _mtdProducts;
                cmbProduct.DataSource = null;
                UtilityServices.fillComboBox(cmbProduct, bs1, "productDescription", "id");
                cmbProduct.SelectedIndex = 0;
            }
        }

        private void frmAccountWiseBalance_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner = null;
        }
    }

    public class AccountBalanceInformation
    {
        public string AccountNumber = "";
        public string AccountName = "";
        public decimal Balance = 0;
        public string ProductName = "";

        public long AgentID = 0;
        public string AgentName = "";
        public long SubAgentID = 0;
        public string SubAgentName = "";
    }
}