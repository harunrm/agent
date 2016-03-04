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

namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmSSPRequestSearch : MetroForm
    {
        private GUI gui = new GUI();
        private List<TermAccountInformation> _sspAccountInformations = new List<TermAccountInformation>();
        private SspAccountInformationSearchDto _sspRequestDto = new SspAccountInformationSearchDto();
        int columnLoaded = 0;

        public frmSSPRequestSearch()
        {
            InitializeComponent();
            PopulateSspProducts();
            ConfigUI();
        }

        public void ConfigUI()
        {
            gui = new GUI(this);
            gui.Config(ref cmbSSPAccountStatus);
            gui.Config(ref cmbSSPAccountType);
            gui.Config(ref txtDepositAccountNumber);
            gui.Config(ref txtDepositAccountTitle);
            gui.Config(ref txtReferenceNumber);
        }

        private void PopulateSspProducts()
        {
            ServiceResult serviceResult = TermService.GetProductTypes();
            List<SspProductType> _sspProducts = serviceResult.ReturnedObject as List<SspProductType>;

            SspProductType tmpSspProductType = new SspProductType();
            tmpSspProductType.productDescription = "(Select)";
            tmpSspProductType.id = -1;
            _sspProducts.Insert(0, tmpSspProductType);

            BindingSource bs = new BindingSource();
            bs.DataSource = _sspProducts;

            cmbSSPAccountType.DataSource = bs;
            cmbSSPAccountType.DisplayMember = "productDescription";
            cmbSSPAccountType.ValueMember = "id";
            cmbSSPAccountType.SelectedIndex = 0;

            cmbSSPAccountStatus.Items.Add("(Select)");
            Array tmpAry = Enum.GetValues(typeof(sspaccountstatus));
            for (int i = 0; i < tmpAry.Length; i++)
            {
                cmbSSPAccountStatus.Items.Add(tmpAry.GetValue(i).ToString());
            }

            cmbSSPAccountStatus.SelectedIndex = 0;

            if (!serviceResult.Success)
            {
                MessageBox.Show(serviceResult.Message);
                gui.RefreshOwnerForm();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            btnSearch.Enabled = false;

            _sspAccountInformations = new List<TermAccountInformation>();
            _sspRequestDto = new SspAccountInformationSearchDto();
            ServiceResult serviceResult;
            try
            {
                //
                if (txtDepositAccountNumber.Text != "" && txtDepositAccountNumber.Text != null)
                {
                    _sspRequestDto.depositAccNum = txtDepositAccountNumber.Text;
                    _sspRequestDto.isdepositAccNum = true;
                }
                if (txtDepositAccountTitle.Text != "" && txtDepositAccountTitle.Text != null)
                {
                    _sspRequestDto.depositAcctitle = txtDepositAccountTitle.Text;
                    _sspRequestDto.isdepositAcctitle = true;
                }
                if (cmbSSPAccountType.SelectedIndex > 0)
                {
                    _sspRequestDto.sspProductType = (SspProductType)cmbSSPAccountType.SelectedItem;
                    _sspRequestDto.issspProductType = true;
                }
                if (cmbSSPAccountStatus.SelectedIndex > 0)
                {
                    _sspRequestDto.sspAccountStatus = (sspaccountstatus)(cmbSSPAccountStatus.SelectedIndex - 1);
                    _sspRequestDto.issspAccountStatus = true;
                }
                if (txtReferenceNumber.Text != "" && txtReferenceNumber.Text != null)
                {
                    _sspRequestDto.referanceNumber = txtReferenceNumber.Text;
                    _sspRequestDto.isreferanceNumber = true;
                }


                //
                ProgressUIManager.ShowProgress(this);
                serviceResult = TermService.SearchSspAccounts(_sspRequestDto);
                ProgressUIManager.CloseProgress();
                gui.RefreshOwnerForm();

                if (serviceResult.Success)
                {
                    //_sspAccountInformations = serviceResult.ReturnedObject as List<SspAccountInformation>;
                    _sspAccountInformations = (List<TermAccountInformation>)serviceResult.ReturnedObject;
                    dgvSearchResult.DataSource = null;
                    dgvSearchResult.Columns.Clear();

                    //DataGridViewButtonColumn buttonView = new DataGridViewButtonColumn();
                    //buttonView.Text = "View";
                    //buttonView.Name = "View";
                    //buttonView.UseColumnTextForButtonValue = true;
                    //dgvSearchResult.Columns.Add(buttonView);

                    dgvSearchResult.DataSource = _sspAccountInformations.Select(o => new SSPAccountInformationsGrid(o) { depositAccNum = o.depositAccNum, depositAcctitle = o.depositAcctitle, termAccNum = o.accountNumber, sspProductType = o.termProductType.ToString(), amount = o.amount, termAccountStatus = o.accountStatus, referanceNumber = o.referanceNumber }).ToList();
                    loadButtons();

                    //dgvSearchResult.Columns["id"].HeaderText = "ID";
                    dgvSearchResult.Columns["depositAccNum"].HeaderText = "Deposit Account No.";
                    dgvSearchResult.Columns["depositAccNum"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvSearchResult.Columns["depositAccNum"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    //dgvSearchResult.Columns["depositAccNum"].wi

                    dgvSearchResult.Columns["depositAcctitle"].HeaderText = "Deposit Account Title";
                    dgvSearchResult.Columns["depositAcctitle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    dgvSearchResult.Columns["sspAccNum"].HeaderText = "SSP Account No.";
                    dgvSearchResult.Columns["sspAccNum"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvSearchResult.Columns["sspAccNum"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    dgvSearchResult.Columns["sspProductType"].HeaderText = "SSP Product Type";
                    dgvSearchResult.Columns["sspProductType"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvSearchResult.Columns["amount"].HeaderText = "Amount";
                    dgvSearchResult.Columns["amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    //dgvSearchResult.Columns["subAgentUser"].HeaderText = "Subagent User";
                    //dgvSearchResult.Columns["remarks"].HeaderText = "Remarks";
                    dgvSearchResult.Columns["sspAccountStatus"].HeaderText = "SSP Account Status";

                    dgvSearchResult.Columns["referanceNumber"].HeaderText = "Reference No.";
                    dgvSearchResult.Columns["referanceNumber"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    //DataGridViewButtonColumn buttonPrint = new DataGridViewButtonColumn();
                    //buttonPrint.Text = "Print";
                    //buttonPrint.Name = "Print";
                    //buttonPrint.UseColumnTextForButtonValue = true;
                    //dgvSearchResult.Columns.Insert(dgvSearchResult.Columns.Count, buttonPrint);
                }
                else
                {
                    Message.showError(serviceResult.Message);
                    gui.RefreshOwnerForm();
                }
            }
            catch (Exception ex)
            {
                ProgressUIManager.CloseProgress();
                btnSearch.Enabled = true;
                Message.showError(ex.Message);
                gui.RefreshOwnerForm();
            }
            //_sspRequestDto.amount = 0;
            //_sspRequestDto.depositAccNum = "";
            //_sspRequestDto.depositAcctitle = "";
            //_sspRequestDto.referanceNumber = "";
            _sspRequestDto.isamount = false;
            _sspRequestDto.isdepositAccNum = false;
            _sspRequestDto.isdepositAcctitle = false;
            _sspRequestDto.isreferanceNumber = false;
            _sspRequestDto.issspAccNum = false;
            _sspRequestDto.issspProductType = false;
            //_sspRequestDto.sspAccNum = "";
            //_sspRequestDto.sspProductType = new SspProductType();
            //lstSearchCriteria.Items.Clear();

            //MessageBox.Show(agentInformations.Count.ToString());
            //List<AgentInformationMediator> agentRecords = AgentInformationMediator.GetAgentInformationMediatedList(_agentInformations);            

            lblReferenceNoDisplay.Text = dgvSearchResult.Rows.Count.ToString();
            btnSearch.Enabled = true;

            #region

            //btnSearch.Enabled = false;

            //List<SspAccountInformation> sspAccountInformations = new List<SspAccountInformation>();
            ////try
            ////{
            //ProgressUIManager.ShowProgress(this);
            //SSPRequestSearchCom sspRequestSearchCom = new SSPRequestSearchCom();
            //SspAccountInformationSearchDto sspAccountInformationSearchDto = new SspAccountInformationSearchDto();
            ////sspAccountInformationSearchDto.referanceNumber = "476";
            ////sspAccountInformationSearchDto.isreferanceNumber = true;

            //sspAccountInformations = sspRequestSearchCom.getListOfSSPAccountInformation(sspAccountInformationSearchDto);

            //ProgressUIManager.CloseProgress();

            ////if ()
            ////{

            //dataGridView1.DataSource = null;
            ////dataGridView1.AutoGenerateColumns = true;

            ////DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            ////buttonColumn.Text = "Open";
            ////buttonColumn.UseColumnTextForButtonValue = true;
            ////dataGridView1.Columns.Add(buttonColumn);            

            ////dataGridView1.DataSource =
            ////    sspAccountInformations.Select(o => new SSPAccountInformationsGrid(o)
            ////    {
            ////        id = o.id
            ////    }).ToList();
            //dataGridView1.DataSource = sspAccountInformations;

            ////}
            ////else
            ////{
            ////    //Message.showError(serviceResult.Message);
            ////}
            ////}
            ////catch (Exception ex)
            ////{
            ////    ProgressUIManager.CloseProgress();
            ////    btnSearch.Enabled = true;
            ////    Message.showError(ex.Message);
            ////}

            //btnSearch.Enabled = true;

            #endregion
        }
        private void loadButtons()
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

            columnLoaded = 1;
            //}
            for (int i = 0; i < _sspAccountInformations.Count; i++)
            {
                TermAccountInformation termAccInfo = _sspAccountInformations[i];
                DataGridViewDisableButtonCell buttonCell = (DataGridViewDisableButtonCell)dgvSearchResult.Rows[i].Cells[dgvSearchResult.Columns.Count - 1];
                if (termAccInfo.accountStatus == TermAccountStatus.approved || termAccInfo.accountStatus == TermAccountStatus.submitted)
                {
                    buttonCell.Enabled = true;
                }
                else
                {
                    buttonCell.Enabled = false;
                }
            }

        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            txtDepositAccountNumber.Text = "";
            txtDepositAccountTitle.Text = "";
            cmbSSPAccountType.SelectedIndex = 0;
            cmbSSPAccountStatus.SelectedIndex = 0;
            txtReferenceNumber.Text = "";
            _sspRequestDto = new SspAccountInformationSearchDto();
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
                            TermAccountInformation termAccountInformation = null;
                            //if (_currentRowIndex > -1)
                            {
                                termAccountInformation = _sspAccountInformations[dgvSearchResult.SelectedCells[0].RowIndex];
                            }
                            //if (dgvSearchResult.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "View")
                            if (e.ColumnIndex == 0)
                            {
                                if (termAccountInformation != null)
                                {
                                    frmTermAccountOpening frm = new frmTermAccountOpening(termAccountInformation);
                                    frm.ShowDialog();
                                    Search();
                                }
                            }
                            //if (dgvSearchResult.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Print")
                            if (e.ColumnIndex == dgvSearchResult.Columns.Count - 1)
                            {
                                if (termAccountInformation != null)
                                {
                                    if (termAccountInformation.accountStatus == TermAccountStatus.submitted)
                                    {
                                        //print pre_ssp_account_slip
                                        frmShowReport objfrmShowReport = new frmShowReport();
                                        objfrmShowReport.SspPreAccountReport(termAccountInformation.referanceNumber);
                                        gui.RefreshOwnerForm();
                                    }
                                    if (termAccountInformation.accountStatus == TermAccountStatus.approved)
                                    {
                                        //print post_ssp_account_slip
                                        frmShowReport objfrmShowReport = new frmShowReport();
                                        objfrmShowReport.SSPApproveAccountReport(termAccountInformation.referanceNumber);
                                        gui.RefreshOwnerForm();
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

        private void frmSSPRequestSearch_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void customTitlebar1_Click(object sender, EventArgs e)
        {

        }

        private void customTitlebar1_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
    public class SSPAccountInformationsGrid
    {
        //public long id { get; set; }
        public string depositAccNum { get; set; }
        public string depositAcctitle { get; set; }
        public string termAccNum { get; set; }
        public string sspProductType { get; set; }
        public decimal amount { get; set; }
        //public string subAgentUser { get; set; }
        //public string remarks { get; set; }
        public TermAccountStatus termAccountStatus { get; set; }
        public string referanceNumber { get; set; }
        //public List<NomineeInformation> nominees { get; set; }

        private TermAccountInformation _obj;

        public SSPAccountInformationsGrid(TermAccountInformation obj)
        {
            _obj = obj;
        }

        public TermAccountInformation GetModel()
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