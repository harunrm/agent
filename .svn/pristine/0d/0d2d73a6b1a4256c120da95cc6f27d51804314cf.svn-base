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
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using MISL.Ababil.Agent.Infrastructure.Models.dto;
using MISL.Ababil.Agent.Infrastructure.Models.models.transaction;
using MISL.Ababil.Agent.Infrastructure.Validation;
using MISL.Ababil.Agent.Report.Reports;
using MISL.Ababil.Agent.Services;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.reports;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.ssp;

using MISL.Ababil.Agent.Report.DataSets;
using MetroFramework.Forms;
using System.Threading.Tasks;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.termaccount;
using MISL.Ababil.Agent.LocalStorageService;
using System.Globalization;

namespace MISL.Ababil.Agent.Report
{
    public partial class frmAccountOpeningRport : MetroForm
    {
        private GUI gui = new GUI();
        List<AgentInformation> objAgentInfoList = new List<AgentInformation>();
        AgentServices objAgentServices = new AgentServices();
        AgentInformation agentInformation = new AgentInformation();
        AgentServices agentServices = new AgentServices();

        public List<AccountOpeningInformation> _accountInformations = new List<AccountOpeningInformation>();
        private List<AgentProduct> _agentProducts;
        private List<SspProductType> _agentSspProducts;
        AccountOpeningReport accRep = new AccountOpeningReport();

        public frmAccountOpeningRport()
        {
            InitializeComponent();
            GetSetupData();
            try
            {
                cmbAgentName.SelectedIndex = 0;
                cmbProduct.SelectedIndex = 0;
            }
            catch
            {
            }
            controlActivity();
            ConfigUIEnhancement();

            //mtbFromDate.Text = dtpFromDate.Value.ToString("dd-MM-yyyy");
            //mtbToDate.Text = dtpToDate.Value.ToString("dd-MM-yyyy");
        }
        public void ConfigUIEnhancement()
        {
            gui = new GUI(this);
            gui.Config(ref cmbAgentName, ValidCheck.VALIDATIONTYPES.COMBOBOX_EMPTY, null);
            gui.Config(ref cmbSubAgnetName);
            gui.Config(ref cmbProduct, ValidCheck.VALIDATIONTYPES.COMBOBOX_EMPTY, null);
            gui.Config(ref dtpFromDate);
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
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            accRep.AccountOpenings.Clear();

            DateTime fromDate, toDate;

            //fromDate = UtilityServices.ParseDateTime(dtpFromDate.Date);
            fromDate = DateTime.ParseExact(dtpFromDate.Date.Replace("/", "-"), "dd-MM-yyyy", CultureInfo.InvariantCulture);

            //toDate = UtilityServices.ParseDateTime(dtpToDate.Date);
            toDate = DateTime.ParseExact(dtpToDate.Date.Replace("/", "-"), "dd-MM-yyyy", CultureInfo.InvariantCulture);

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

            if (cmbAgentName.SelectedIndex > 0 && cmbProduct.SelectedIndex > 0) //((ComboboxItem) cmbProduct.SelectedItem).Text.ToLower() != "(all)" && ((ComboboxItem)cmbProduct.SelectedItem).Text.ToLower() != "(select)")
            {

                crAccountOpeningReportByDateRange_Eng report = new crAccountOpeningReportByDateRange_Eng();
                frmReportViewer viewer = new frmReportViewer();

                ReportHeaders rptHeaders = new ReportHeaders();
                rptHeaders = UtilityServices.getReportHeaders("Account Opening Register");

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
                txtToDate.Text = dtpToDate.Date;

                //LoadAccountOpeningInformation();

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
                //else
                //{
                //    LoadAccountOpeningInformation();
                //}

                report.SetDataSource(accRep);

                viewer.crvReportViewer.ReportSource = report;
                viewer.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select an option!", "Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void LoadAccountBalanceInformation(ProductType productType)
        {
            try
            {
                AccountOpeningInformation accountOpeningInformation = new AccountOpeningInformation();
                _accountInformations.Clear();
                AccountSearchDto accountSearchDto = new AccountSearchDto(); //FillAccountSearchDto();
                SspAccountSearchDto sspAccountSearchDto = new SspAccountSearchDto(); //FillSspSearchDto(); 
                SspAccountSearchDto mtdAccountSearchDto = new SspAccountSearchDto(); //FillSspSearchDto(); 


                if (productType == ProductType.Deposit)
                {
                    accountSearchDto = FillAccountSearchDto();
                }
                if (productType == ProductType.SSP)
                {
                    sspAccountSearchDto = FillSspSearchDto();
                }
                if (productType == ProductType.MTDR)
                {
                    mtdAccountSearchDto = FillMTDSearchDto();
                }

                ServiceResult result1 = new ServiceResult();

                if (accountSearchDto.product == null)
                {
                    try
                    {
                        if (productType == ProductType.Deposit)
                        {
                            result1 = AccountOpeningReportService.GetAccountOpeningList(accountSearchDto);
                        }
                        if (productType == ProductType.SSP)
                        {
                            result1 = AccountOpeningReportService.GetAccountOpeningList(sspAccountSearchDto, productType);
                        }
                        if (productType == ProductType.MTDR)
                        {
                            result1 = AccountOpeningReportService.GetAccountOpeningList(mtdAccountSearchDto, productType);
                        }
                        if (!result1.Success)
                        {
                            MessageBox.Show(result1.Message);
                            return;
                        }

                        List<AccountBlanceDto> accountOpenings = null;

                        accountOpenings = result1.ReturnedObject as List<AccountBlanceDto>;



                        if (accountOpenings != null)
                        {
                            foreach (AccountBlanceDto balanceDto in accountOpenings)
                            {
                                AccountOpeningReport.AccountOpeningsRow row = accRep.AccountOpenings.NewAccountOpeningsRow();
                                row.AccountNumber = balanceDto.accountNumber;
                                row.AccountName = balanceDto.accTitle;
                                row.OpeningDate = UtilityServices.getDateFromLong(balanceDto.openDate);
                                row.ProductName = balanceDto.productTitle;

                                row.MobileNumber = balanceDto.mobileNumber;
                                row.AgentName = balanceDto.agentName;
                                row.AgentId = balanceDto.agentId;
                                row.SubAgentName = balanceDto.subAgentName;
                                row.SubAgentId = balanceDto.subAgentId;
                                row.Balance = balanceDto.balance ?? 0;
                                accRep.AccountOpenings.AddAccountOpeningsRow(row);

                            }
                            accRep.AcceptChanges();
                        }

                    }
                    catch (Exception)
                    {
                        //ignored
                    }
                }
                else
                {
                    if (productType == ProductType.Deposit)
                    {
                        result1 = AccountOpeningReportService.GetAccountOpeningList(accountSearchDto);
                    }
                    if (productType == ProductType.SSP)
                    {
                        result1 = AccountOpeningReportService.GetAccountOpeningList(sspAccountSearchDto, productType);
                    }
                    if (productType == ProductType.MTDR)
                    {
                        result1 = AccountOpeningReportService.GetAccountOpeningList(mtdAccountSearchDto, productType);
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
                            AccountOpeningReport.AccountOpeningsRow row = accRep.AccountOpenings.NewAccountOpeningsRow();
                            row.AccountNumber = balanceDto.accountNumber;
                            row.AccountName = balanceDto.accTitle;
                            row.OpeningDate = UtilityServices.getDateFromLong(balanceDto.openDate);
                            row.ProductName = balanceDto.productTitle;

                            row.MobileNumber = balanceDto.mobileNumber;
                            row.AgentName = balanceDto.agentName;
                            row.AgentId = balanceDto.agentId;
                            row.SubAgentName = balanceDto.subAgentName;
                            row.SubAgentId = balanceDto.subAgentId;
                            // if (balanceDto.balance == null) row.Balance = 0;
                            // else
                            //row.Balance = (decimal)balanceDto.balance;
                            row.Balance = balanceDto.balance ?? 0;
                            accRep.AccountOpenings.AddAccountOpeningsRow(row);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAccountOpeningInformation()
        {
            AccountOpeningInformation accountOpeningInformation = new AccountOpeningInformation();
            _accountInformations.Clear();
            AccountSearchDto accountSearchDto = FillAccountSearchDto();
            ServiceResult result1;

            if (accountSearchDto.product == null)
            {
                try
                {
                    #region OLD
                    // accountSearchDto.product = new AgentProduct {id = _agentProducts[2].id};
                    // result1 = AccountOpeningReportService.GetAccountOpeningList(accountSearchDto);
                    // accountSearchDto.product = new AgentProduct { id = _agentProducts[3].id };
                    // ServiceResult result2 = AccountOpeningReportService.GetAccountOpeningList(accountSearchDto);
                    // if (!result1.Success || !result2.Success)
                    // {
                    //     MessageBox.Show(result1.Message + "\n" + result2.Message);
                    //     return;
                    // }

                    // List<AccountBlanceDto> accountOpenings = result1.ReturnedObject as List<AccountBlanceDto>;

                    // if (accountOpenings != null)
                    //     foreach (AccountBlanceDto balanceDto in accountOpenings)
                    //     {
                    //         accountOpeningInformation = new AccountOpeningInformation();
                    //         accountOpeningInformation.AccountNumber = balanceDto.accountNumber;
                    //         accountOpeningInformation.AccountName = balanceDto.accTitle;
                    //         accountOpeningInformation.OpeningDate = UtilityServices.getDateFromLong(balanceDto.openDate);
                    //         //accountOpeningInformation.ProductName = _agentProducts[2].productTitle;   // WALI

                    //         accountOpeningInformation.ProductName = balanceDto.productTitle;
                    //         accountOpeningInformation.MobileNumber = balanceDto.mobileNumber;
                    //         accountOpeningInformation.AgentName = balanceDto.agentName;
                    //         accountOpeningInformation.AgentId = balanceDto.agentId;
                    //         accountOpeningInformation.SubAgentName = balanceDto.subAgentName;
                    //         accountOpeningInformation.SubAgentId = balanceDto.subAgentId;

                    //         _accountInformations.Add(accountOpeningInformation);
                    //     }

                    //accountOpenings = result2.ReturnedObject as List<AccountBlanceDto>;

                    // if (accountOpenings != null)
                    //     foreach (AccountBlanceDto balanceDto in accountOpenings)
                    //     {
                    //         accountOpeningInformation = new AccountOpeningInformation();
                    //         accountOpeningInformation.AccountNumber = balanceDto.accountNumber;
                    //         accountOpeningInformation.AccountName = balanceDto.accTitle;
                    //         accountOpeningInformation.OpeningDate = UtilityServices.getDateFromLong(balanceDto.openDate);
                    //         accountOpeningInformation.ProductName = _agentProducts[3].productTitle;
                    //         _accountInformations.Add(accountOpeningInformation);
                    //     }
                    #endregion

                    //accountSearchDto.product = new AgentProduct { id = _agentProducts[2].id };                    
                    result1 = AccountOpeningReportService.GetAccountOpeningList(accountSearchDto);
                    if (!result1.Success)
                    {
                        MessageBox.Show(result1.Message);
                        return;
                    }

                    List<AccountBlanceDto> accountOpenings = result1.ReturnedObject as List<AccountBlanceDto>;

                    if (accountOpenings != null)
                        foreach (AccountBlanceDto balanceDto in accountOpenings)
                        {
                            accountOpeningInformation = new AccountOpeningInformation();
                            accountOpeningInformation.AccountNumber = balanceDto.accountNumber;
                            accountOpeningInformation.AccountName = balanceDto.accTitle;
                            accountOpeningInformation.OpeningDate = UtilityServices.getDateFromLong(balanceDto.openDate);
                            //accountOpeningInformation.ProductName = _agentProducts[2].productTitle;   // WALI

                            accountOpeningInformation.ProductName = balanceDto.productTitle;
                            accountOpeningInformation.MobileNumber = balanceDto.mobileNumber;
                            accountOpeningInformation.AgentName = balanceDto.agentName;
                            accountOpeningInformation.AgentId = balanceDto.agentId;
                            accountOpeningInformation.SubAgentName = balanceDto.subAgentName;
                            accountOpeningInformation.SubAgentId = balanceDto.subAgentId;
                            accountOpeningInformation.balance = Convert.ToDecimal(balanceDto.balance);
                            _accountInformations.Add(accountOpeningInformation);
                        }
                }
                catch (Exception)
                {
                    //ignored
                }
            }
            else
            {
                result1 = AccountOpeningReportService.GetAccountOpeningList(accountSearchDto);

                if (!result1.Success)
                {
                    MessageBox.Show(result1.Message);
                    return;
                }

                List<AccountBlanceDto> accountOpenings = result1.ReturnedObject as List<AccountBlanceDto>;

                if (accountOpenings != null)
                    foreach (AccountBlanceDto balanceDto in accountOpenings)
                    {
                        accountOpeningInformation = new AccountOpeningInformation();
                        accountOpeningInformation.AccountNumber = balanceDto.accountNumber;
                        accountOpeningInformation.AccountName = balanceDto.accTitle;
                        accountOpeningInformation.OpeningDate = UtilityServices.getDateFromLong(balanceDto.openDate);
                        accountOpeningInformation.ProductName = cmbProduct.Text;
                        _accountInformations.Add(accountOpeningInformation);
                    }
            }
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
                    accountSearchDto.agent = null; // new AgentInformation();
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
                if (cmbSubAgnetName.SelectedIndex == 1)
                {
                    accountSearchDto.subAgent = null; // new SubAgentInformation();
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
                }
                if (cmbProduct.SelectedIndex == 1)
                {
                    accountSearchDto.product = null; // new AgentProduct();
                }
                if (cmbProduct.SelectedIndex == 0)
                {
                    //MessageBox.Show("Please select an option!", "Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //return null;
                }
            }


            //accountSearchDto.fromDate = UtilityServices.GetLongDate(UtilityServices.ParseDateTime(dtpFromDate.Date));
            accountSearchDto.fromDate = UtilityServices.GetLongDate
            (
                DateTime.ParseExact(dtpFromDate.Date.Replace("/", "-"), "dd-MM-yyyy", CultureInfo.InvariantCulture)
            );

            //accountSearchDto.toDate = UtilityServices.GetLongDate(UtilityServices.ParseDateTime(dtpToDate.Date));
            accountSearchDto.toDate = UtilityServices.GetLongDate
            (
                DateTime.ParseExact(dtpToDate.Date.Replace("/", "-"), "dd-MM-yyyy", CultureInfo.InvariantCulture)
            );


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
                    accountSearchDto.agent = null; // new AgentInformation();
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
                if (cmbSubAgnetName.SelectedIndex == 1)
                {
                    accountSearchDto.subAgent = null; // new SubAgentInformation();
                }
                if (cmbSubAgnetName.SelectedIndex == 0)
                {
                    //MessageBox.Show("Please select an option!", "Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //return null;
                }
            }
            if (this.cmbProduct.SelectedIndex > -1)
            {
                if (cmbProduct.SelectedValue != null && (cmbProduct.SelectedIndex != 0 || cmbProduct.SelectedIndex != 1))
                {
                    //accountSearchDto.product = new AgentProduct { id = (long)(cmbProduct.SelectedValue) };
                    accountSearchDto.product = new SspProductType { id = (long)(cmbProduct.SelectedValue) };
                }
                if (cmbProduct.SelectedIndex == 1)
                {
                    accountSearchDto.product = null; // new AgentProduct();
                }
                if (cmbProduct.SelectedIndex == 0)
                {
                    //MessageBox.Show("Please select an option!", "Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //return null;
                }
            }



            //accountSearchDto.fromDate = UtilityServices.GetLongDate(UtilityServices.ParseDateTime(dtpFromDate.Date));
            //accountSearchDto.toDate = UtilityServices.GetLongDate(UtilityServices.ParseDateTime(dtpToDate.Date));

            accountSearchDto.fromDate = UtilityServices.GetLongDate
            (
                DateTime.ParseExact(dtpFromDate.Date.Replace("/", "-"), "dd-MM-yyyy", CultureInfo.InvariantCulture)
            );

            accountSearchDto.toDate = UtilityServices.GetLongDate
            (
                DateTime.ParseExact(dtpToDate.Date.Replace("/", "-"), "dd-MM-yyyy", CultureInfo.InvariantCulture)
            );

            return accountSearchDto;
        }

        private SspAccountSearchDto FillMTDSearchDto()
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
                    accountSearchDto.agent = null; // new AgentInformation();
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
                if (cmbSubAgnetName.SelectedIndex == 1)
                {
                    accountSearchDto.subAgent = null; // new SubAgentInformation();
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
                    //accountSearchDto.product = new AgentProduct { id = (long)(cmbProduct.SelectedValue) };
                    accountSearchDto.product = new SspProductType { id = (long)(cmbProduct.SelectedValue) };
                }
                if (cmbProduct.SelectedIndex == 1)
                {
                    accountSearchDto.product = null; // new AgentProduct();
                }
                if (cmbProduct.SelectedIndex == 0)
                {
                    //MessageBox.Show("Please select an option!", "Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //return null;
                }
            }



            //accountSearchDto.fromDate = UtilityServices.GetLongDate(UtilityServices.ParseDateTime(dtpFromDate.Date));
            //accountSearchDto.toDate = UtilityServices.GetLongDate(UtilityServices.ParseDateTime(dtpToDate.Date));

            accountSearchDto.fromDate = UtilityServices.GetLongDate
            (
                DateTime.ParseExact(dtpFromDate.Date.Replace("/", "-"), "dd-MM-yyyy", CultureInfo.InvariantCulture)
            );

            accountSearchDto.toDate = UtilityServices.GetLongDate
            (
                DateTime.ParseExact(dtpToDate.Date.Replace("/", "-"), "dd-MM-yyyy", CultureInfo.InvariantCulture)
            );

            return accountSearchDto;
        }



        private void GetSetupData()
        {
            //string configvalue1 = ConfigurationManager.AppSettings["countryId"];
            try
            {
                setAgentList();

                setProductList();

                //_itdProducts = LocalCache.GetITDProducts();
                //_mtdProducts = LocalCache.GetMTDProducts();

                ////_itdProducts
                //{
                //    TermProductType apSelect = new TermProductType();
                //    apSelect.productDescription = "(Select)";
                //    (_itdProducts).Insert(0, apSelect);

                //    TermProductType apAll = new TermProductType();
                //    apAll.productDescription = "(All)";
                //    (_itdProducts).Insert(1, apAll);
                //}

                ////_mtdProducts
                //{
                //    TermProductType apSelect = new TermProductType();
                //    apSelect.productDescription = "(Select)";
                //    (_mtdProducts).Insert(0, apSelect);

                //    TermProductType apAll = new TermProductType();
                //    apAll.productDescription = "(All)";
                //    (_mtdProducts).Insert(1, apAll);
                //}
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
            //            cmbAgentName.Text = "Select";
            cmbAgentName.SelectedIndex = 0;
        }
        private void setProductList()
        {
            BindingSource bs1 = new BindingSource();
            ServiceResult serviceResult = AccountOpeningReportService.GetAllAgentProducts();
            if (serviceResult.Success)
            {
                _agentProducts = serviceResult.ReturnedObject as List<AgentProduct>;
                bs1.DataSource = _agentProducts;

                AgentProduct apSelect = new AgentProduct();
                apSelect.productTitle = "(Select)";
                ((List<AgentProduct>)serviceResult.ReturnedObject).Insert(0, apSelect);

                AgentProduct apAll = new AgentProduct();
                apAll.productTitle = "(All)";
                ((List<AgentProduct>)serviceResult.ReturnedObject).Insert(1, apAll);

                UtilityServices.fillComboBox(cmbProduct, bs1, "productTitle", "id");
                //cmbProduct.DataSource = AccountOpeningReportService.GetAllAgentProducts();
                //Enum.GetValues(typeof(ProductType));
                cmbProduct.SelectedIndex = 0;
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

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            //mtbFromDate.Text = dtpFromDate.Value.ToString("dd-MM-yyyy");
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            //mtbToDate.Text = dtpToDate.Value.ToString("dd-MM-yyyy");
        }

        private void frmAccountOpeningRport_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = SessionInfo.currentDate;
            dtpToDate.Value = SessionInfo.currentDate;
        }

        private void mtbFromDate_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

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

        private void frmAccountOpeningRport_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner = null;
        }
    }

    public class AccountOpeningInformation
    {
        public string AccountNumber = "";
        public string AccountName = "";
        public DateTime OpeningDate = DateTime.Now;
        public string ProductName = "";
        public string MobileNumber = "";
        public string AgentName = "";
        public string SubAgentName = "";
        public long AgentId = 0;
        public long SubAgentId = 0;
        public decimal balance = 0;
    }
}
