using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MISL.Ababil.Agent.Communication;
using MISL.Ababil.Agent.Infrastructure;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.ssp;
using MISL.Ababil.Agent.Services;
using MISL.Ababil.Agent.UI.forms.ProgressUI;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Report;
using MetroFramework.Forms;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.termaccount;
using MISL.Ababil.Agent.Infrastructure.Models.dto;
using MISL.Ababil.Agent.LocalStorageService;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using System.Globalization;

namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmTermRequestSearch : MetroForm
    {
        private GUI _gui = new GUI();
        private List<TermAccountSearchResultDto> _termAccountSearchResultDtoList = new List<TermAccountSearchResultDto>();
        private TermAccountSearchDto _termAccountSearchDto = new TermAccountSearchDto();
        private List<AgentInformation> _objAgentInfoList = new List<AgentInformation>();
        private AgentServices _objAgentServices = new AgentServices();
        private AgentInformation _agentInformation = new AgentInformation();
        private AgentServices _agentServices = new AgentServices();
        private List<TermProductType> _itdProducts = new List<TermProductType>();
        private List<TermProductType> _mtdProducts = new List<TermProductType>();
        private int _columnLoaded = 0;

        public List<AgentInformation> _ObjAgentInfoList
        {
            get
            {
                return _objAgentInfoList;
            }

            set
            {
                _objAgentInfoList = value;
            }
        }

        public frmTermRequestSearch()
        {
            InitializeComponent();
            GetSetupData();
            ConfigUI();
        }

        private void GetSetupData()
        {
            setSubagent();
            setAccountStatus();
        }

        private void setAccountStatus()
        {
            List<object> termAccStatusList = (Enum.GetValues(typeof(TermAccountStatus)).Cast<object>()).ToList();
            termAccStatusList.Insert(0, "(Select)");
            termAccStatusList.Insert(1, "(All)");

            cmbAccountStatus.DataSource = termAccStatusList;
            cmbAccountStatus.SelectedIndex = -1;
        }

        public void ConfigUI()
        {
            _gui = new GUI(this);

            if (SessionInfo.userBasicInformation.userType == AgentUserType.Outlet)
            {
                if (cmbSubAgent.Items.Count > 0 && SessionInfo.userBasicInformation.outlet != null)
                {
                    cmbSubAgent.SelectedValue = SessionInfo.userBasicInformation.outlet.id;
                    cmbSubAgent.Enabled = false;
                }
            }
        }

        //private void setAgentList()
        //{
        //    ObjAgentInfoList = _objAgentServices.getAgentInfoBranchWise();
        //    BindingSource bs = new BindingSource();
        //    bs.DataSource = ObjAgentInfoList;

        //    AgentInformation agSelect = new AgentInformation();
        //    agSelect.businessName = "(Select)";
        //    ObjAgentInfoList.Insert(0, agSelect);

        //    UtilityServices.fillComboBox(cmbAgentName, bs, "businessName", "id");
        //    cmbAgentName.SelectedIndex = 0;
        //}

        private void setSubagent()
        {
            try
            {
                //_agentInformation = _objAgentServices.getAgentInfoById(SessionInfo.userBasicInformation.agent.id.ToString());                
                if (_agentInformation != null)
                {
                    BindingSource bs = new BindingSource();
                    List<SubAgentInformation> subagentInfoList = (new SubAgentService()).GetAllSubAgents();
                    {
                        try
                        {
                            SubAgentInformation saiSelect = new SubAgentInformation();
                            saiSelect.name = "(Select)";
                            subagentInfoList.Insert(0, saiSelect);

                            SubAgentInformation saiAll = new SubAgentInformation();
                            saiAll.name = "(All)";
                            subagentInfoList.Insert(1, saiAll);
                        }
                        catch //suppressed
                        {

                        }
                    }

                    bs.DataSource = subagentInfoList;
                    UtilityServices.fillComboBox(cmbSubAgent, bs, "name", "id");
                    if (cmbSubAgent.Items.Count > 0)
                    {
                        cmbSubAgent.SelectedIndex = 0;
                    }
                }
            }
            catch { }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            btnSearch.Enabled = false;

            _termAccountSearchResultDtoList = new List<TermAccountSearchResultDto>();
            FillSearchDto();
            ServiceResult serviceResult;
            try
            {
                ProgressUIManager.ShowProgress(this);
                serviceResult = TermService.SearchTermAccounts(_termAccountSearchDto);
                ProgressUIManager.CloseProgress();
                _gui.RefreshOwnerForm();

                if (serviceResult.Success)
                {
                    dgvSearchResult.DataSource = null;
                    dgvSearchResult.Columns.Clear();

                    _termAccountSearchResultDtoList = (List<TermAccountSearchResultDto>)serviceResult.ReturnedObject;

                    dgvSearchResult.DataSource = _termAccountSearchResultDtoList.Select(o => new TermAccountSearchResultDtoGrid(o)
                    {
                        refNo = o.refNo,
                        accountStatus = o.accountStatus,
                        accountType = o.accountType,
                        accTitle = o.accTitle,
                        linkAccountNo = o.LinkAccountNo,
                        outletName = o.outletName,
                        product = o.product.productDescription,
                        termAccountNo = o.termAccountNo
                    }).ToList();

                    if (dgvSearchResult.Rows.Count > 0)
                    {
                        loadButtons();

                        dgvSearchResult.Columns[1].HeaderText = "Acc. Type";

                        dgvSearchResult.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        dgvSearchResult.Columns[0].Width = 40;

                        dgvSearchResult.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        dgvSearchResult.Columns[1].Width = 60;

                        dgvSearchResult.Columns[2].HeaderText = "Product";
                        dgvSearchResult.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvSearchResult.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                        dgvSearchResult.Columns[3].HeaderText = "Acc. No";
                        dgvSearchResult.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                        dgvSearchResult.Columns[4].HeaderText = "Acc. Title";
                        dgvSearchResult.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                        dgvSearchResult.Columns[5].HeaderText = "Outlet";
                        dgvSearchResult.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                        dgvSearchResult.Columns[6].HeaderText = "Ref. No";
                        dgvSearchResult.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                        dgvSearchResult.Columns[7].HeaderText = "Status";
                        dgvSearchResult.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        dgvSearchResult.Columns[7].Width = 85;

                        dgvSearchResult.Columns[8].HeaderText = "Link Acc. No";
                        dgvSearchResult.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                        dgvSearchResult.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                        dgvSearchResult.Columns[9].Width = 40;
                    }
                }
                else
                {
                    Message.showError(serviceResult.Message);
                    _gui.RefreshOwnerForm();
                }
            }
            catch (Exception ex)
            {
                ProgressUIManager.CloseProgress();
                btnSearch.Enabled = true;
                Message.showError(ex.Message);
                _gui.RefreshOwnerForm();
            }

            lblReferenceNoDisplay.Text = dgvSearchResult.Rows.Count.ToString();
            btnSearch.Enabled = true;
        }

        private void FillSearchDto()
        {
            try
            {
                _termAccountSearchDto = new TermAccountSearchDto();
                _termAccountSearchDto.agentUserType = SessionInfo.userBasicInformation.userType;
                //if (SessionInfo.userBasicInformation.agent != null)
                //{
                //    _termAccountSearchDto.agentId = SessionInfo.userBasicInformation.agent.id;
                //}
                if (cmbSubAgent.SelectedIndex > 1)
                {
                    _termAccountSearchDto.outletId = (long?)cmbSubAgent.SelectedValue;
                }
                else
                {
                    _termAccountSearchDto.outletId = null;
                }

                if (!string.IsNullOrEmpty(cmbAccountType.Text))
                {
                    if (cmbAccountType.SelectedIndex > 1)
                    {
                        AccountType accountType = new AccountType();
                        Enum.TryParse<AccountType>(cmbAccountType.Text, out accountType);
                        _termAccountSearchDto.accountType = accountType;
                    }
                    else
                    {
                        _termAccountSearchDto.accountType = null;
                    }
                }
                else
                {
                    _termAccountSearchDto.accountType = null;
                }

                _termAccountSearchDto.productType = new TermProductType();
                if (cmbProductType.SelectedValue != null && cmbProductType.SelectedIndex > 0)
                {
                    _termAccountSearchDto.productType.id = (long)cmbProductType.SelectedValue;
                }
                else
                {
                    _termAccountSearchDto.productType.id = null;
                }

                _termAccountSearchDto.refNo = txtReferenceNumber.Text;
                _termAccountSearchDto.depositAccno = txtDepositAccountNumber.Text;


                if (cmbAccountStatus.SelectedIndex > 1)
                {
                    if (!string.IsNullOrEmpty(cmbAccountStatus.Text))
                    {
                        TermAccountStatus termAccountStatus = new TermAccountStatus();
                        Enum.TryParse<TermAccountStatus>(cmbAccountStatus.Text, out termAccountStatus);
                        _termAccountSearchDto.applicationStatus = termAccountStatus;
                    }
                    else
                    {
                        _termAccountSearchDto.applicationStatus = null;
                    }
                }
                else
                {
                    _termAccountSearchDto.applicationStatus = null;
                }

                //from date
                {
                    string format = "dd/MM/yyyy";
                    CultureInfo provider = CultureInfo.InvariantCulture;
                    _termAccountSearchDto.fromDate = UtilityServices.GetLongDate
                    (
                         DateTime.ParseExact(dtpFromDate.Date, format, provider)
                    );
                }

                //to date
                {
                    string format = "dd/MM/yyyy";
                    CultureInfo provider = CultureInfo.InvariantCulture;
                    _termAccountSearchDto.toDate = UtilityServices.GetLongDate
                    (
                         DateTime.ParseExact(dtpToDate.Date, format, provider)
                    );
                }

                switch (cmbAccountType.SelectedIndex)
                {
                    case 0:
                        _termAccountSearchDto.accountType = null;
                        break;
                    case 1:
                        _termAccountSearchDto.accountType = AccountType.SSP;
                        break;
                    case 2:
                        _termAccountSearchDto.accountType = AccountType.MTDR;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Message.showError(ex.Message);
            }
        }

        private void loadButtons()
        {
            if (dgvSearchResult.Rows.Count > 0)
            {
                //if (columnLoaded == 0)
                //{
                DataGridViewDisableButtonColumn buttonView = new DataGridViewDisableButtonColumn();
                buttonView.Text = "View";
                buttonView.Name = "View";
                buttonView.UseColumnTextForButtonValue = true;
                dgvSearchResult.Columns.Insert(0, buttonView);

                DataGridViewDisableButtonColumn buttonPrint = new DataGridViewDisableButtonColumn();
                buttonPrint.Text = "Print";
                buttonPrint.Name = "Print";
                buttonPrint.UseColumnTextForButtonValue = true;
                dgvSearchResult.Columns.Insert(dgvSearchResult.Columns.Count, buttonPrint);

                _columnLoaded = 1;
                //}
                for (int i = 0; i < _termAccountSearchResultDtoList.Count; i++)
                {
                    TermAccountSearchResultDto termAccountSearchResultDto = _termAccountSearchResultDtoList[i];
                    DataGridViewDisableButtonCell buttonCell = (DataGridViewDisableButtonCell)dgvSearchResult.Rows[i].Cells[dgvSearchResult.Columns.Count - 1];
                    if (termAccountSearchResultDto.accountStatus == TermAccountStatus.approved || termAccountSearchResultDto.accountStatus == TermAccountStatus.submitted)
                    {
                        buttonCell.Enabled = true;
                    }
                    else
                    {
                        buttonCell.Enabled = false;
                    }
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cmbAgent.SelectedIndex = -1;
            if (cmbSubAgent.Enabled)
            {
                cmbSubAgent.SelectedIndex = -1;
            }
            txtReferenceNumber.Text = "";
            cmbAccountType.SelectedIndex = -1;
            cmbProductType.DataSource = null;
            txtDepositAccountNumber.Text = "";
            cmbAccountType.SelectedIndex = -1;

            dtpFromDate.Value = SessionInfo.currentDate;
            dtpToDate.Value = SessionInfo.currentDate;

            _termAccountSearchDto = new TermAccountSearchDto();
        }

        private void dgvSearchResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSearchResult.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {

                if (dgvSearchResult.Rows.Count > 0)
                {
                    try
                    {
                        if (dgvSearchResult.RowCount > 0)
                        {
                            TermAccountSearchResultDto termAccountSearchResultDto = null;
                            //if (_currentRowIndex > -1)
                            {
                                termAccountSearchResultDto = _termAccountSearchResultDtoList[dgvSearchResult.SelectedCells[0].RowIndex];
                            }
                            if (dgvSearchResult.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "View")
                            {
                                if (termAccountSearchResultDto != null)
                                {
                                    TermAccountRequestDto termAccountRequestDto = TermService.GetTermAccountRequestDtoByAccID(_termAccountSearchResultDtoList[e.RowIndex].applicationId ?? 0);
                                    Packet packet = new Packet();
                                    //packet.DeveloperMode = true;
                                    packet.actionType = FormActionType.View;
                                    packet.intentType = IntentType.SelfDriven;

                                    frmTermAccountOpening frm = new frmTermAccountOpening(packet, termAccountRequestDto);
                                    frm.ShowDialog();
                                    Search();
                                }
                            }

                            if (e.ColumnIndex == dgvSearchResult.Columns.Count - 1) //print button
                            {
                                if (termAccountSearchResultDto != null)
                                {
                                    if (termAccountSearchResultDto.accountStatus == TermAccountStatus.submitted)
                                    {
                                        //print pre_ssp_account_slip
                                        frmShowReport objfrmShowReport = new frmShowReport();
                                        objfrmShowReport.SspPreAccountReport(termAccountSearchResultDto.refNo, termAccountSearchResultDto.accountType);
                                        _gui.RefreshOwnerForm();
                                    }
                                    if (termAccountSearchResultDto.accountStatus == TermAccountStatus.approved)
                                    {
                                        //print post_ssp_account_slip
                                        frmShowReport objfrmShowReport = new frmShowReport();
                                        objfrmShowReport.SSPApproveAccountReport(termAccountSearchResultDto.refNo, termAccountSearchResultDto.accountType);
                                        _gui.RefreshOwnerForm();
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }

        private void PopulateITDProducts()
        {
            //_itdProducts
            _itdProducts = LocalCache.GetITDProducts();
            if (_itdProducts.Count > 0)
            {
                if (_itdProducts[0].productDescription != "(All)")
                {
                    TermProductType apAll = new TermProductType();
                    apAll.productDescription = "(All)";
                    (_itdProducts).Insert(0, apAll);
                }
            }
            BindingSource bs = new BindingSource();
            bs.DataSource = _itdProducts;
            cmbProductType.DataSource = null;
            cmbProductType.DataSource = bs;
            cmbProductType.ValueMember = "id";
            cmbProductType.DisplayMember = "productDescription";
        }

        private void PopulateMTDRProducts()
        {
            //_mtdrProducts
            _mtdProducts = LocalCache.GetMTDProducts();
            if (_mtdProducts.Count > 0)
            {
                if (_mtdProducts[0].productDescription != "(All)")
                {
                    TermProductType apAll = new TermProductType();
                    apAll.productDescription = "(All)";
                    (_mtdProducts).Insert(0, apAll);
                }
            }
            BindingSource bs = new BindingSource();
            bs.DataSource = _mtdProducts;
            cmbProductType.DataSource = null;
            cmbProductType.DataSource = bs;
            cmbProductType.ValueMember = "id";
            cmbProductType.DisplayMember = "productDescription";
        }



        private void cmbAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbAccountType.SelectedIndex)
            {
                case 0: // SSP                    
                    cmbProductType.DataSource = null;
                    break;
                case 1: // SSP
                    PopulateITDProducts();
                    break;
                case 2: // MTDR
                    PopulateMTDRProducts();
                    break;
                default:
                    break;
            }
        }

        private void frmTermRequestSearch_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = SessionInfo.currentDate;
            dtpToDate.Value = SessionInfo.currentDate;
        }

        private void frmTermRequestSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Owner = null;
        }
    }

    public class TermAccountSearchResultDtoGrid
    {
        public AccountType? accountType { get; set; }
        public string product { get; set; }
        public string termAccountNo { get; set; }
        public string accTitle { get; set; }
        public string outletName { get; set; }
        public string refNo { get; set; }
        public TermAccountStatus? accountStatus { get; set; }
        public string linkAccountNo { get; set; }

        //public List<NomineeInformation> nominees { get; set; }

        private TermAccountSearchResultDto _obj;

        public TermAccountSearchResultDtoGrid(TermAccountSearchResultDto obj)
        {
            _obj = obj;
        }

        public TermAccountSearchResultDto GetModel()
        {
            return _obj;
        }
    }

    public class tmpGrid
    {
        public string id { get; set; }
        public string value { get; set; }

        private TmpCls _obj;

        public tmpGrid(TmpCls obj)
        {
            _obj = obj;
        }

        public TmpCls GetModel()
        {
            return _obj;
        }
    }

    public class TmpCls
    {
        public string id { get; set; }
        public string value { get; set; }
    }
}