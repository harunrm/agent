using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using MISL.Ababil.Agent.Infrastructure.Mediators;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using MISL.Ababil.Agent.Infrastructure.Validation;
using MISL.Ababil.Agent.Services;
using MISL.Ababil.Agent.UI.forms.ProgressUI;
using System.Linq;

namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmAgentSearch : Form
    {

        const int SearchCriteriaNotSelected = -1;

        enum SearchCriteriaTypes
        {
            String,
            Date,
            TransactionStatus,
            ApprovalStatus
        }

        private readonly AgentDto _agentDto = new AgentDto();

        private readonly Hashtable _searchCriteriaTypeMap = new Hashtable();

        private static readonly string CriteriaCode = StringTable.SearchCriteriaTypeMap_Code;
        private static readonly string CriteriaName = StringTable.SearchCriteriaTypeMap_Name;
        private static readonly string CriteriaRegistrationDate = StringTable.SearchCriteriaTypeMap_Registration_Date;
        private static readonly string CriteriaApprovalDate = StringTable.SearchCriteriaTypeMap_Approval_Date;
        private static readonly string CriteriaTransactionStatus = StringTable.SearchCriteriaTypeMap_Transaction_Status;
        private static readonly string CriteriaApprovalStatus = StringTable.SearchCriteriaTypeMap_Approval_Status;

        List<AgentInformation> _agentInformations = new List<AgentInformation>();
        private int _currentRowIndex;

        public frmAgentSearch()
        {
            InitializeComponent();

            DefineSearchCriteriaTypeMap();

            PopuateAgentFieldList();

            PopulateApprovalStatus();

            PopulateTransactionStatus();

            DisableAllCriteriaDefinitionInputs();
            //ConfigureValidation();

            mtbFrom.Text = dtpFrom.Value.ToString("dd-MM-yyyy");
            mtbTo.Text = dtpTo.Value.ToString("dd-MM-yyyy");
        }

        //private void ConfigureValidation()
        //{

        //    ValidationManager.ConfigureValidation(this, txtSearchFieldContent, "Consumer ID", (long)ValidationType.Numeric, true);
        //    ValidationManager.ConfigureValidation(this, cmbAgentField, "District", (long)ValidationType.ListSelected, true);
        //    ValidationManager.ConfigureValidation(this, cmbApprovalStatus, "Thana", (long)ValidationType.ListSelected, true);
        //    ValidationManager.ConfigureValidation(this, cmbTransactionStatus, "Post Code", (long)ValidationType.ListSelected, true);


        //}

        private void PopulateTransactionStatus()
        {
            cmbTransactionStatus.Items.Clear();
            cmbTransactionStatus.Items.Add("Valid");
            cmbTransactionStatus.Items.Add("Invalid");
            cmbTransactionStatus.Items.Add("Blocked");
        }

        private void PopulateApprovalStatus()
        {
            cmbApprovalStatus.Items.Clear();
            cmbApprovalStatus.Items.Add("Waiting to be verified");
            cmbApprovalStatus.Items.Add("Verified");
            cmbApprovalStatus.Items.Add("Cancelled");
        }

        private void PopuateAgentFieldList()
        {
            string[] fields = new string[_searchCriteriaTypeMap.Count];

            _searchCriteriaTypeMap.Keys.CopyTo(fields, 0);

            cmbAgentField.Items.Clear();
            cmbAgentField.Items.AddRange(fields);
        }

        private void DefineSearchCriteriaTypeMap()
        {
            _searchCriteriaTypeMap.Add(CriteriaCode, SearchCriteriaTypes.String);
            _searchCriteriaTypeMap.Add(CriteriaName, SearchCriteriaTypes.String);
            _searchCriteriaTypeMap.Add(CriteriaRegistrationDate, SearchCriteriaTypes.Date);
            _searchCriteriaTypeMap.Add(CriteriaApprovalDate, SearchCriteriaTypes.Date);
            _searchCriteriaTypeMap.Add(CriteriaTransactionStatus, SearchCriteriaTypes.TransactionStatus);
            _searchCriteriaTypeMap.Add(CriteriaApprovalStatus, SearchCriteriaTypes.ApprovalStatus);
        }

        private void cmbAgentField_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableAppropriateSearchFieldInput();
        }

        private void EnableAppropriateSearchFieldInput()
        {
            int searchCriteriaType = GetSearchCriteriaType();
            switch (searchCriteriaType)
            {
                case SearchCriteriaNotSelected:
                    break;

                case (int)SearchCriteriaTypes.Date:
                    DisableAllCriteriaDefinitionInputs();
                    dtpFrom.Enabled = true;
                    dtpTo.Enabled = true;
                    break;

                case (int)SearchCriteriaTypes.String:
                    DisableAllCriteriaDefinitionInputs();
                    txtSearchFieldContent.Enabled = true;
                    break;

                case (int)SearchCriteriaTypes.TransactionStatus:
                    DisableAllCriteriaDefinitionInputs();
                    cmbTransactionStatus.Enabled = true;
                    break;

                case (int)SearchCriteriaTypes.ApprovalStatus:
                    DisableAllCriteriaDefinitionInputs();
                    cmbApprovalStatus.Enabled = true;
                    break;

                default:
                    break;
            }
        }

        private void DisableAllCriteriaDefinitionInputs()
        {
            cmbApprovalStatus.Enabled = false;
            cmbTransactionStatus.Enabled = false;
            txtSearchFieldContent.Enabled = false;
            dtpFrom.Enabled = false;
            dtpTo.Enabled = false;
            //btnAdd.Enabled = false;
            btnRemove.Enabled = false;
        }

        private int GetSearchCriteriaType()
        {
            string key = cmbAgentField.Text;
            if (_searchCriteriaTypeMap.ContainsKey(key))
                return (int)_searchCriteriaTypeMap[key];
            return SearchCriteriaNotSelected;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (true)
            {
                string currentSelectionCriteria = cmbAgentField.Text;

                if (currentSelectionCriteria.Equals(CriteriaCode))
                {
                    if (txtSearchFieldContent.Text.Trim().Length < 1)
                    {
                        MessageBox.Show(StringTable.Please_provide_text_content_for_Agent_Code,
                            StringTable.Search_Content_Missing);
                        return;
                    }

                    _agentDto.agentCode = txtSearchFieldContent.Text;
                    _agentDto.useCode = true;

                    lstSearchCriteria.Items.Add(CriteriaCode + " contains " + txtSearchFieldContent.Text);
                }

                if (currentSelectionCriteria.Equals(CriteriaName))
                {
                    if (txtSearchFieldContent.Text.Trim().Length < 1)
                    {
                        MessageBox.Show(StringTable.Please_provide_text_content_for_Agent_Name,
                            StringTable.Search_Content_Missing);
                        return;
                    }

                    _agentDto.businessName = txtSearchFieldContent.Text;
                    _agentDto.useName = true;

                    lstSearchCriteria.Items.Add(CriteriaName + " contains " + txtSearchFieldContent.Text);
                }

                if (currentSelectionCriteria.Equals(CriteriaApprovalStatus))
                {
                    if (cmbApprovalStatus.Text.Trim().Length < 1)
                    {
                        MessageBox.Show("Please provide approval status", StringTable.Search_Content_Missing);
                        return;
                    }

                    _agentDto.approvalStatus = (ApprovalStatus)cmbApprovalStatus.SelectedIndex;
                    _agentDto.useApprovalStatus = true;

                    lstSearchCriteria.Items.Add(CriteriaApprovalStatus + " is " + cmbApprovalStatus.Text);
                }

                if (currentSelectionCriteria.Equals(CriteriaTransactionStatus))
                {
                    if (cmbTransactionStatus.Text.Trim().Length < 1)
                    {
                        MessageBox.Show("Please provide transaction status", StringTable.Search_Content_Missing);
                        return;
                    }

                    _agentDto.transactionStatus = (AgentTransactionStatus)cmbApprovalStatus.SelectedIndex;
                    _agentDto.useTransactionStatus = true;

                    lstSearchCriteria.Items.Add(CriteriaTransactionStatus + " is " + cmbTransactionStatus.Text);
                }

                if (currentSelectionCriteria.Equals(CriteriaRegistrationDate))
                {
                    if (dtpTo.Value < dtpFrom.Value)
                    {
                        MessageBox.Show("Please ensure dates are consistent", StringTable.Search_Content_Missing);
                        return;
                    }

                    _agentDto.creationDateFrom = dtpFrom.Value.ToUnixTime();

                    _agentDto.creationDateTo = dtpTo.Value.ToUnixTime();

                    _agentDto.useCreationDate = true;

                    lstSearchCriteria.Items.Add(CriteriaRegistrationDate + " between " + dtpFrom.Value + " and " +
                                                dtpTo.Value);
                }

                if (currentSelectionCriteria.Equals(CriteriaApprovalDate))
                {
                    if (dtpTo.Value < dtpFrom.Value)
                    {
                        MessageBox.Show("Please ensure dates are consistent", StringTable.Search_Content_Missing);
                        return;
                    }

                    _agentDto.approvalDateFrom = dtpFrom.Value.ToUnixTime();

                    _agentDto.approvalDateTo = dtpTo.Value.ToUnixTime();

                    _agentDto.useApprovalDate = true;

                    lstSearchCriteria.Items.Add(CriteriaApprovalDate + " between " + dtpFrom.Value + " and " +
                                                dtpTo.Value);
                }

                cmbAgentField.Items.Remove(cmbAgentField.Text);

            }
        }

        //private Boolean CheckValidation()
        //{
        //    return ValidationManager.ValidateForm(this);
        //}

        private void txtSearchFieldContent_TextChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            mtbFrom.Text = dtpFrom.Value.ToString("dd-MM-yyyy");
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            mtbTo.Text = dtpTo.Value.ToString("dd-MM-yyyy");
        }

        private void cmbTransactionStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
        }

        private void cmbApprovalStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstSearchCriteria.SelectedIndex < 0) return;

            foreach (object criteria in _searchCriteriaTypeMap.Keys)
            {
                if (lstSearchCriteria.Text.StartsWith(criteria.ToString()))
                {
                    cmbAgentField.Items.Add(criteria);

                    if (criteria == CriteriaCode) _agentDto.useCode = false;
                    if (criteria == CriteriaName) _agentDto.useName = false;
                    if (criteria == CriteriaApprovalStatus) _agentDto.useApprovalDate = false;
                    if (criteria == CriteriaTransactionStatus) _agentDto.useCreationDate = false;
                }
            }

            lstSearchCriteria.Items.Remove(lstSearchCriteria.Text);
        }

        private void lstSearchCriteria_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemove.Enabled = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnSearch.Enabled = false;

            //chacking valid date
            try
            {
                string[] str = mtbFrom.Text.Split('-');
                DateTime d = new DateTime(int.Parse(str[2].Trim()), int.Parse(str[1].Trim()), int.Parse(str[0].Trim()));
                dtpFrom.Value = d;
            }
            catch
            {
                ProgressUIManager.CloseProgress();
                Message.showError("Please enter the date in correct format.");
                //mtbFrom.Focus();
                //mtbFrom.SelectAll();                

                btnSearch.Enabled = true;
                return;
            }

            try
            {
                string[] str = mtbTo.Text.Split('-');
                DateTime d = new DateTime(int.Parse(str[2].Trim()), int.Parse(str[1].Trim()), int.Parse(str[0].Trim()));
                dtpTo.Value = d;
            }
            catch
            {
                ProgressUIManager.CloseProgress();
                Message.showError("Please enter the date in correct format.");
                //mtbTo.Focus();
                //mtbTo.SelectAll();

                btnSearch.Enabled = true;
                return;
            }


            AgentServices services = new AgentServices();
            try
            {
                ProgressUIManager.ShowProgress(this);
                _agentInformations = services.SearchAgents(_agentDto);
                ProgressUIManager.CloseProgress();
            }
            catch (Exception ex)
            {
                ProgressUIManager.CloseProgress();
                btnSearch.Enabled = true;
                Message.showError(ex.Message);
            }
            //            MessageBox.Show(agentInformations.Count.ToString());
            List<AgentInformationMediator> agentRecords = AgentInformationMediator.GetAgentInformationMediatedList(_agentInformations);
            dgResults.DataSource = null;
            //dgResults.DataSource = agentRecords;

            dgResults.DataSource = agentRecords.Select(o => new AgentInformationMediatorGrid(o) { Id = o.Id, Agent_Code = o.AgentCode, Business_Name = o.BusinessName, Agent_Address = o.AgentAddress.addressLineOne, Creation_Date = o.CreationDate.ToString("dd-MM-yyyy").Replace("-", "/"), Approval_Status = o.ApprovalStatus, Approval_Date = o.ApprovalDate.ToString("dd-MM-yyyy").Replace("-", "/"), Transaction_Status = o.TransactionStatus }).ToList();

            btnSearch.Enabled = true;
        }

        private void btnViewAgent_Click(object sender, EventArgs e)
        {
            if (dgResults.RowCount > 0)
            {
                AgentInformation agentInformation = null;
                if (_currentRowIndex > -1)
                {
                    agentInformation = _agentInformations[_currentRowIndex];
                }
                if (agentInformation != null)
                {
                    AgentServices services = new AgentServices();
                    try
                    {
                        agentInformation = services.getAgentInfoById(agentInformation.id.ToString());
                    }
                    catch (Exception ex)
                    {
                        Message.showError(ex.Message);
                    }
                    frmAgentCreation agentCreation = new frmAgentCreation(agentInformation, ActionType.update);
                    agentCreation.IsCalledByOtherForm = true;
                    agentCreation.ShowDialog();
                }
            }
        }

        private void dgResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgResults_SelectionChanged(object sender, EventArgs e)
        {
            if (dgResults.CurrentRow != null) _currentRowIndex = dgResults.CurrentRow.Index;
        }

        private void frmAgentSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            //ValidationManager.ReleaseValidationData(this);
        }
        public static bool ReleaseValidationData(Form form)
        {
            return true;
        }

        private void mtbFrom_KeyUp(object sender, KeyEventArgs e)
        {
            //suppressed to avoid mtb to dtp conversion
            try
            {
                string[] str = mtbFrom.Text.Split('-');
                DateTime d = new DateTime(int.Parse(str[2].Trim()), int.Parse(str[1].Trim()), int.Parse(str[0].Trim()));
                dtpFrom.Value = d;
            }
            catch (Exception ex) { }
        }

        private void mtbTo_KeyUp(object sender, KeyEventArgs e)
        {
            //suppressed to avoid mtb to dtp conversion
            try
            {
                string[] str = mtbTo.Text.Split('-');
                DateTime d = new DateTime(int.Parse(str[2].Trim()), int.Parse(str[1].Trim()), int.Parse(str[0].Trim()));
                dtpTo.Value = d;
            }
            catch (Exception ex) { }
        }
    }

    public class AgentInformationMediatorGrid
    {
        public long Id { get; set; }
        public string Agent_Code { get; set; }
        public string Business_Name { get; set; }
        public string Agent_Address { get; set; }
        public string Creation_Date { get; set; }
        public string Transaction_Status { get; set; }
        public string Approval_Status { get; set; }
        public string Approval_Date { get; set; }

        private AgentInformationMediator _obj;

        public AgentInformationMediatorGrid(AgentInformationMediator obj)
        {
            _obj = obj;
        }

        public AgentInformationMediator GetModel()
        {
            return _obj;
        }
    }
}
