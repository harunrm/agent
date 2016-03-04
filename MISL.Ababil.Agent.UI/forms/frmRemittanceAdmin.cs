using MISL.Ababil.Agent.Communication;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.Remittance;
using MISL.Ababil.Agent.Infrastructure.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MISL.Ababil.Agent.Infrastructure.Models.reports;
using MISL.Ababil.Agent.Services;
using MISL.Ababil.Agent.UI.forms.ProgressUI;

namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmRemittanceAdmin : Form
    {
        int columnLoaded = 0;
        private List<Remittance> remittances;

        public frmRemittanceAdmin()
        {
            InitializeComponent();
            //ConfigureValidation();

            cmbNameofExchangeHouse.SelectedItem = null;
            cmbRemittanceStatus.SelectedItem = null;
        }

        //private void ConfigureValidation()
        //{
        //    ValidationManager.ConfigureValidation(this, cmbNameofExchangeHouse, "Exchange House", (long)ValidationType.ListSelected, true);
        //    ValidationManager.ConfigureValidation(this, txtRecipientName, "Name", (long)ValidationType.NonWhitespaceNonEmptyText, false);
        //    ValidationManager.ConfigureValidation(this, txtRecipientNationalID, "National ID", (long)ValidationType.NonWhitespaceNonEmptyText, false);
        //    ValidationManager.ConfigureValidation(this, txtSenderName, "Name", (long)ValidationType.NonWhitespaceNonEmptyText, false);
        //    ValidationManager.ConfigureValidation(this, txtPINCode, "PIN Code", (long)ValidationType.NonWhitespaceNonEmptyText, false);
        //    ValidationManager.ConfigureValidation(this, txtReferanceNumber, "Referance Number", (long)ValidationType.Positive + (long)ValidationType.NonZero, false);
        //    ValidationManager.ConfigureValidation(this, cmbRemittanceStatus, "Remittance Status", (long)ValidationType.ListSelected, true);
        //}

        //private bool validationCheck()
        //{
        //    return ValidationManager.ValidateForm(this);
        //}

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //if (validationCheck() == true)
            //{
            btnSearch.Enabled = false;
            search();
            btnSearch.Enabled = true;
            //}
        }

        //private string getOutletName(string voucherNumber)
        //{
        //    ConsumerServices consumerService = new ConsumerServices();
        //    RemittanceReportDto remittanceReportDto = consumerService.GetRemittanceReportDto(voucherNumber);
        //    if (remittanceReportDto.outletName != "")
        //    {
        //        return remittanceReportDto.outletName;
        //    }
        //    return "";
        //    //return "_";
        //}

        private void search()
        {
            dgvRemittance.DataSource = null;
            dgvRemittance.Rows.Clear();
            dgvRemittance.Columns.Clear();
            Remittance remittance = fillRemittance();
            RemittanceCom objRemittanceCom = new RemittanceCom();

            try
            {
                ProgressUIManager.ShowProgress(this);
                remittances = objRemittanceCom.getListOfRemittance(remittance);
                ProgressUIManager.CloseProgress();

                if (remittances != null)
                {
                    //if (columnLoaded == 0)
                    {
                        DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                        buttonColumn.Text = "Open";
                        buttonColumn.UseColumnTextForButtonValue = true;
                        dgvRemittance.Columns.Add(buttonColumn);
                        //columnLoaded = 1;

                        if (SessionInfo.rights.Contains("REMITANCE_FIRST_APPROVE"))
                        {
                            DataGridViewButtonColumn buttonColumn2 = new DataGridViewButtonColumn();
                            buttonColumn2.Text = "Process";
                            buttonColumn2.UseColumnTextForButtonValue = true;
                            dgvRemittance.Columns.Add(buttonColumn2);
                            //columnLoaded = 2;
                        }
                        else if (SessionInfo.rights.Contains("REMITANCE_SECOND_APPROVE"))
                        {
                            DataGridViewButtonColumn buttonColumn2 = new DataGridViewButtonColumn();
                            buttonColumn2.Text = "Process";
                            buttonColumn2.UseColumnTextForButtonValue = true;
                            dgvRemittance.Columns.Add(buttonColumn2);
                            //columnLoaded = 2;
                        }
                    }

                    dgvRemittance.DataSource = null;
                    //dgvRemittance.DataSource = remittances.Select(o => new RemittanceGrid(o) { id = o.id, district = o.benificaryAddress.district.title, exchangeHouse = o.exchangeHouse.companyName, outlet = getOutletName(o.voucherNumber), benificaryName = o.benificaryName, benificarynid = o.benificarynid, senderName = o.senderName, pinCode = o.pinCode, referenceNumber = o.referanceNumber, remittanceStatus = o.remittanceStatus, entryUser = o.entryUser, entryUserDateTime = o.entryUserDateTime, firstApprover = o.firstApprover, firstApprovalDateTime = o.firstApprovalDateTime, secondApprover = o.secondApprover, secondApprovalDateTime = o.secondApprovalDateTime, comments = o.comments }).ToList();
                    //dgvRemittance.DataSource = remittances.Select(o => new RemittanceGrid(o) { id = o.id, district = o.benificaryAddress.district.title, exchangeHouse = o.exchangeHouse.companyName,  benificaryName = o.benificaryName, benificarynid = o.benificarynid, senderName = o.senderName, pinCode = o.pinCode, referenceNumber = o.referanceNumber, remittanceStatus = o.remittanceStatus, entryUser = o.entryUser, entryUserDateTime = o.entryUserDateTime, firstApprover = o.firstApprover, firstApprovalDateTime = o.firstApprovalDateTime, secondApprover = o.secondApprover, secondApprovalDateTime = o.secondApprovalDateTime, comments = o.comments }).ToList();
                    dgvRemittance.DataSource = remittances.Select(o => new RemittanceGrid(o) { id = o.id, district = o.benificaryAddress.district.title, exchangeHouse = o.exchangeHouse.companyName, outlet = o.outletName, benificaryName = o.benificaryName, benificarynid = o.benificarynid, senderName = o.senderName, pinCode = o.pinCode, referenceNumber = o.referanceNumber, remittanceStatus = o.remittanceStatus, entryUser = o.entryUser, entryUserDateTime = o.entryUserDateTime, firstApprover = o.firstApprover, firstApprovalDateTime = o.firstApprovalDateTime, secondApprover = o.secondApprover, secondApprovalDateTime = o.secondApprovalDateTime, comments = o.comments }).ToList();
                }
                else
                {
                    ProgressUIManager.CloseProgress();
                    btnSearch.Enabled = true;
                    Message.showInformation("No applications available");
                }
            }
            catch (Exception ex)
            {
                ProgressUIManager.CloseProgress();
                btnSearch.Enabled = true;
                Message.showError(ex.Message);
            }

            lblItemsFound.Text = "Item(s) Found: " + dgvRemittance.Rows.Count.ToString();
            this.Enabled = true;
            this.UseWaitCursor = false;
        }

        public class RemittanceGrid
        {
            public long id { get; set; }
            public string district { get; set; }
            public string outlet { get; set; }
            public string exchangeHouse { get; set; }
            public String referenceNumber { get; set; }
            public RemittanceStatus remittanceStatus { get; set; }
            //public ExchangeHouse exchangeHouse { get; set; }
            public String pinCode { get; set; }
            //public Decimal expectedAmount { get; set; }
            public String senderName { get; set; }
            //public Country senderCountry { get; set; }
            //public String senderPurpose { get; set; }                                            
            //public string remittanceStatus { get; set; }
            public String benificaryName { get; set; }
            //public String benificaryFatherName { get; set; }
            //public String benificaryMotherName { get; set; }
            //public Address benificaryAddress { get; set; }
            //public String benificaryMobileNumber { get; set; }
            //public String status { get; set; }
            public String comments { get; set; }
            public String benificarynid { get; set; }
            public string entryUser { get; set; }
            public string entryUserDateTime { get; set; }
            public string firstApprover { get; set; }
            public string firstApprovalDateTime { get; set; }
            public string secondApprover { get; set; }
            public string secondApprovalDateTime { get; set; }

            private Remittance _obj;

            public RemittanceGrid(Remittance obj)
            {
                _obj = obj;
            }

            public Remittance GetModel()
            {
                return _obj;
            }
        }

        private Remittance fillRemittance()
        {
            Remittance remittance = new Remittance();
            ExchangeHouse exHouse = new ExchangeHouse();
            exHouse.id = (long)cmbNameofExchangeHouse.SelectedValue;
            remittance.exchangeHouse = exHouse;
            remittance.benificaryName = txtRecipientName.Text;
            remittance.pinCode = txtPINCode.Text;
            remittance.referanceNumber = txtReferanceNumber.Text;

            if (SessionInfo.rights.Contains("REMITANCE_ENTRY"))
            {
                remittance.entryUser = SessionInfo.username;
            }

            RemittanceStatus remStatus = new RemittanceStatus();
            Enum.TryParse<RemittanceStatus>(cmbRemittanceStatus.Text, out remStatus);
            remittance.remittanceStatus = remStatus;

            return remittance;
        }

        private void fillExchangeHouseList(ref ComboBox cbxExHouse)
        {
            RemittanceCom remCom = new RemittanceCom();
            List<ExchangeHouse> exHouses = remCom.getListofExchangeHouse();
            BindingSource bs = new BindingSource();
            bs.DataSource = exHouses;
            fillComboBox(cbxExHouse, bs, "companyName", "id");
        }

        public static void fillComboBox(ComboBox cmb, BindingSource bs, string displayMember, string valueMember)
        {
            cmb.DataSource = bs;
            cmb.DisplayMember = displayMember;
            cmb.ValueMember = valueMember;
        }

        public static void fillDataGridView(DataGridView dgv, BindingSource bs, string dataMember)
        {
            dgv.DataSource = bs;
            dgv.DataMember = dataMember;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            resetSearch();
        }

        private void resetSearch()
        {
            txtRecipientName.Text = null;
            txtRecipientNationalID.Text = null;
            txtSenderName.Text = null;
            txtPINCode.Text = null;
            txtReferanceNumber.Text = null;
            cmbRemittanceStatus.SelectedIndex = 0;
            cmbNameofExchangeHouse.SelectedIndex = 0;
            cmbNameofExchangeHouse.Focus();
        }

        private void frmRemittanceAdmin_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            fillExchangeHouseList(ref cmbNameofExchangeHouse);

            if (SessionInfo.rights.Contains("REMITANCE_ENTRY"))
            {
                cmbRemittanceStatus.Items.Clear();
                cmbRemittanceStatus.Items.Add("Submitted");
                cmbRemittanceStatus.Items.Add("ApprovedFirst");
                cmbRemittanceStatus.Items.Add("Approved");
                cmbRemittanceStatus.Items.Add("Corrected"); ///editable
                cmbRemittanceStatus.Items.Add("Rejected");
                cmbRemittanceStatus.Items.Add("Disbursed");
                cmbRemittanceStatus.SelectedIndex = 0;
            }
            if (SessionInfo.rights.Contains("REMITANCE_FIRST_APPROVE"))
            {
                if (!cmbRemittanceStatus.Items.Contains("Submitted"))
                {
                    cmbRemittanceStatus.Items.Add("Submitted");
                    cmbRemittanceStatus.SelectedIndex = 0;
                }
            }
            if (SessionInfo.rights.Contains("REMITANCE_SECOND_APPROVE"))
            {
                if (!cmbRemittanceStatus.Items.Contains("ApprovedFirst"))
                {
                    cmbRemittanceStatus.Items.Add("ApprovedFirst");
                    cmbRemittanceStatus.SelectedIndex = 0;
                }
            }
        }

        private void dgvRemittance_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (dgvRemittance.Rows.Count > 0)
                {
                    try
                    {
                        if (dgvRemittance.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Process")
                        {
                            if (remittances[e.RowIndex].remittanceStatus == RemittanceStatus.Submitted)
                            {
                                frmRemittanceApprove objfrmRemittanceApprove = new frmRemittanceApprove();
                                objfrmRemittanceApprove._remittance = remittances[e.RowIndex];
                                //objfrmRemittanceApprove.MdiParent = this.MdiParent;
                                objfrmRemittanceApprove.ShowDialog();
                                search();
                                return;
                            }
                            if (remittances[e.RowIndex].remittanceStatus == RemittanceStatus.ApprovedFirst)
                            {
                                frmRemittanceApprove objfrmRemittanceEntry = new frmRemittanceApprove();
                                objfrmRemittanceEntry._remittance = remittances[e.RowIndex];
                                //objfrmRemittanceEntry.MdiParent = this.MdiParent;
                                objfrmRemittanceEntry.ShowDialog();
                                search();
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
                if (dgvRemittance.Rows.Count > 0)
                {
                    try
                    {
                        if (dgvRemittance.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Open")
                        {
                            frmRemittanceAgentRequest objfrmRemittanceAgentRequest = new frmRemittanceAgentRequest();
                            objfrmRemittanceAgentRequest._remittance = remittances[e.RowIndex];
                            /*
                            if (objfrmRemittanceAgentRequest.remittance.comments == "" || objfrmRemittanceAgentRequest.remittance.comments == null || objfrmRemittanceAgentRequest.remittance == null)
                            {
                                objfrmRemittanceAgentRequest.lnkRemarks.Visible = false;
                            }
                            else
                            {
                                objfrmRemittanceAgentRequest.lnkRemarks.Visible = true;
                            }
                            */
                            // objfrmRemittanceAgentRequest.MdiParent = this.MdiParent; ;
                            if (remittances[e.RowIndex].remittanceStatus != RemittanceStatus.Corrected)
                            {
                                objfrmRemittanceAgentRequest._IsFromAdmin = true;
                                objfrmRemittanceAgentRequest.changeControlsReadOnly(true);
                            }
                            else
                            {
                                objfrmRemittanceAgentRequest._IsFromAdmin = true;
                                objfrmRemittanceAgentRequest.changeControlsReadOnly(false);
                            }
                            objfrmRemittanceAgentRequest.ShowDialog();
                            search();
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }

        private void frmRemittanceAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            //ValidationManager.ReleaseValidationData(this);
            this.Owner = null;
        }

        private void autoRefreshTimer_Tick(object sender, EventArgs e)
        {
            //search();
        }
    }
}