using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MISL.Ababil.Agent.Infrastructure;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.ssp;
using MISL.Ababil.Agent.Services;
using MISL.Ababil.Agent.UI.forms.ProgressUI;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.termaccount;

namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmSSPRequestList : Form
    {

        #region "Enum"

        public enum SspProductTypes
        {
            Millionaire = 0, Billionaire = 1
        }

        #endregion

        #region "Constants"

        public class Constants
        {
            public const string SearchCriteriaTypeMap_AccountNumber = "AccountNumber";
            public const string SearchCriteriaTypeMap_AccountTitle = "AccountTitle";
            public const string SearchCriteriaTypeMap_SspAccountNumber = "SspAccountNumber";
            public const string SearchCriteriaTypeMap_Amount = "Amount";
            public const string SearchCriteriaTypeMap_ReferenceNumber = "ReferenceNumber";
            public const string SearchCriteriaTypeMap_SspProductTypes = "SspProductTypes";
        }

        public class ErrorMessage
        {
            public const string Search_Content_Missing = "Search Content Missing";

            public const string Please_provide_text_content_for_AccountNumber = "Please provide text content for account number.";
            public const string Please_provide_text_content_for_AccountTitle = "Please provide text content for account title.";
            public const string Please_provide_text_content_for_SspAccountNumber = "Please provide text content for ssp account number.";
            public const string Please_provide_text_content_for_Amount = "Please provide text content for amount.";
            public const string Please_provide_text_content_for_ReferenceNumber = "Please provide text content for reference number.";
            public const string Please_select_SspProductType = "Please select ssp product type.";
        }

        #endregion

        const int SearchCriteriaNotSelected = -1;

        enum SearchCriteriaTypes
        {
            String,
            Date,
            SspProductTypes
        }

        //private readonly SspRequestDto _sspRequestDto = new SspRequestDto();
        private readonly SspAccountInformationSearchDto _sspRequestDto = new SspAccountInformationSearchDto();

        private readonly Hashtable _searchCriteriaTypeMap = new Hashtable();
        private int _currentRowIndex;

        List<TermAccountInformation> _sspAccountInformations = new List<TermAccountInformation>();

        private static readonly string CriteriaAccountNumber = Constants.SearchCriteriaTypeMap_AccountNumber;
        private static readonly string CriteriaAccountTitle = Constants.SearchCriteriaTypeMap_AccountTitle;
        private static readonly string CriteriaSspAccountNumber = Constants.SearchCriteriaTypeMap_SspAccountNumber;
        private static readonly string CriteriaAmount = Constants.SearchCriteriaTypeMap_Amount;
        private static readonly string CriteriaReferenceNumber = Constants.SearchCriteriaTypeMap_ReferenceNumber;
        private static readonly string CriteriaSspProductTypes = Constants.SearchCriteriaTypeMap_SspProductTypes;

        public frmSSPRequestList()
        {
            InitializeComponent();

            DefineSearchCriteriaTypeMap();
            PopuateAgentFieldList();
            PopulateSspProductTypes();
            DisableAllCriteriaDefinitionInputs();
            //ConfigureValidation();
        }

        private void DefineSearchCriteriaTypeMap()
        {
            _searchCriteriaTypeMap.Add(CriteriaAccountNumber, SearchCriteriaTypes.String);
            _searchCriteriaTypeMap.Add(CriteriaAccountTitle, SearchCriteriaTypes.String);
            _searchCriteriaTypeMap.Add(CriteriaSspAccountNumber, SearchCriteriaTypes.String);
            _searchCriteriaTypeMap.Add(CriteriaAmount, SearchCriteriaTypes.String);
            _searchCriteriaTypeMap.Add(CriteriaReferenceNumber, SearchCriteriaTypes.String);
            //_searchCriteriaTypeMap.Add(CriteriaSspProductTypes, SearchCriteriaTypes.SspProductTypes);
        }

        private void PopuateAgentFieldList()
        {
            string[] fields = new string[_searchCriteriaTypeMap.Count];

            _searchCriteriaTypeMap.Keys.CopyTo(fields, 0);

            cmbAgentField.Items.Clear();
            cmbAgentField.Items.AddRange(fields);
        }

        private void DisableAllCriteriaDefinitionInputs()
        {
            cmbSspProductTypes.Enabled = false;
            txtSearchFieldContent.Enabled = false;
            btnRemove.Enabled = false;
        }

        private void PopulateSspProductTypes()
        {
            cmbSspProductTypes.Items.Clear();
            cmbSspProductTypes.Items.Add("Millionaire");
            cmbSspProductTypes.Items.Add("Billionaire");
        }

        private int GetSearchCriteriaType()
        {
            string key = cmbAgentField.Text;
            if (_searchCriteriaTypeMap.ContainsKey(key))
                return (int)_searchCriteriaTypeMap[key];
            return SearchCriteriaNotSelected;
        }

        private void EnableAppropriateSearchFieldInput()
        {
            int searchCriteriaType = GetSearchCriteriaType();
            switch (searchCriteriaType)
            {
                case SearchCriteriaNotSelected:
                    break;

                case (int)SearchCriteriaTypes.String:
                    DisableAllCriteriaDefinitionInputs();
                    txtSearchFieldContent.Enabled = true;
                    break;

                case (int)SearchCriteriaTypes.SspProductTypes:
                    DisableAllCriteriaDefinitionInputs();
                    cmbSspProductTypes.Enabled = true;
                    break;

                default:
                    break;
            }
        }

        private void cmbAgentField_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableAppropriateSearchFieldInput();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (true)
            {
                string currentSelectionCriteria = cmbAgentField.Text;

                if (currentSelectionCriteria.Equals(CriteriaAccountNumber))
                {
                    if (txtSearchFieldContent.Text.Trim().Length < 1)
                    {
                        MessageBox.Show(ErrorMessage.Please_provide_text_content_for_AccountNumber,
                            ErrorMessage.Search_Content_Missing);
                        return;
                    }

                    _sspRequestDto.depositAccNum = txtSearchFieldContent.Text;
                    _sspRequestDto.isdepositAccNum = true;

                    lstSearchCriteria.Items.Add(CriteriaAccountNumber + " contains " + txtSearchFieldContent.Text);
                }

                if (currentSelectionCriteria.Equals(CriteriaAccountTitle))
                {
                    if (txtSearchFieldContent.Text.Trim().Length < 1)
                    {
                        MessageBox.Show(ErrorMessage.Please_provide_text_content_for_AccountTitle,
                           ErrorMessage.Search_Content_Missing);
                        return;
                    }

                    _sspRequestDto.depositAcctitle = txtSearchFieldContent.Text;
                    _sspRequestDto.isdepositAcctitle = true;

                    lstSearchCriteria.Items.Add(CriteriaAccountTitle + " contains " + txtSearchFieldContent.Text);
                }

                if (currentSelectionCriteria.Equals(CriteriaSspAccountNumber))
                {
                    if (txtSearchFieldContent.Text.Trim().Length < 1)
                    {
                        MessageBox.Show(ErrorMessage.Please_provide_text_content_for_SspAccountNumber,
                            ErrorMessage.Search_Content_Missing);
                        return;
                    }

                    _sspRequestDto.sspAccNum = txtSearchFieldContent.Text;
                    _sspRequestDto.issspAccNum = true;

                    lstSearchCriteria.Items.Add(CriteriaSspAccountNumber + " contains " + txtSearchFieldContent.Text);
                }

                if (currentSelectionCriteria.Equals(CriteriaAmount))
                {
                    if (txtSearchFieldContent.Text.Trim().Length < 1)
                    {
                        MessageBox.Show(ErrorMessage.Please_provide_text_content_for_Amount,
                           ErrorMessage.Search_Content_Missing);
                        return;
                    }

                    decimal amount;
                    if (decimal.TryParse(txtSearchFieldContent.Text, out amount))
                    {
                        _sspRequestDto.amount = amount;
                        _sspRequestDto.isamount = true;
                    }

                    lstSearchCriteria.Items.Add(CriteriaAmount + " contains " + txtSearchFieldContent.Text);
                }

                if (currentSelectionCriteria.Equals(CriteriaReferenceNumber))
                {
                    if (txtSearchFieldContent.Text.Trim().Length < 1)
                    {
                        MessageBox.Show(ErrorMessage.Please_provide_text_content_for_ReferenceNumber,
                           ErrorMessage.Search_Content_Missing);
                        return;
                    }

                    _sspRequestDto.referanceNumber = txtSearchFieldContent.Text;
                    _sspRequestDto.isreferanceNumber = true;

                    lstSearchCriteria.Items.Add(CriteriaReferenceNumber + " contains " + txtSearchFieldContent.Text);
                }

                if (currentSelectionCriteria.Equals(CriteriaSspProductTypes))
                {
                    if (cmbSspProductTypes.Text.Trim().Length < 1)
                    {
                        MessageBox.Show("Please provide ssp product types", ErrorMessage.Search_Content_Missing);
                        return;
                    }

                    lstSearchCriteria.Items.Add(CriteriaSspProductTypes + " is " + cmbSspProductTypes.Text);
                    long selectedValue;
                    var value = cmbSspProductTypes.SelectedValue;
                    if (value == null)
                    {
                        MessageBox.Show("Please provide ssp product types", ErrorMessage.Search_Content_Missing);
                        return;
                    }
                    if (long.TryParse(value.ToString(), out selectedValue))
                    {
                        _sspRequestDto.sspProductType.id = selectedValue;
                        _sspRequestDto.issspProductType = true;
                    }

                }

                cmbAgentField.Items.Remove(cmbAgentField.Text);
                DisableAllCriteriaDefinitionInputs();
                ClearFields();
            }
        }

        private void ClearFields()
        {
            txtSearchFieldContent.Text = string.Empty;
        }

        private void txtSearchFieldContent_TextChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
        }

        private void cmbSspProductTypes_SelectedIndexChanged(object sender, EventArgs e)
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

                    if (criteria == CriteriaAccountNumber) _sspRequestDto.isdepositAccNum = false;
                    if (criteria == CriteriaAccountTitle) _sspRequestDto.isdepositAcctitle = false;
                    if (criteria == CriteriaSspAccountNumber) _sspRequestDto.issspAccNum = false;
                    if (criteria == CriteriaAmount) _sspRequestDto.isamount = false;
                    if (criteria == CriteriaReferenceNumber) _sspRequestDto.isreferanceNumber = false;
                    if (criteria == CriteriaSspProductTypes) _sspRequestDto.issspProductType = false;
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

            _sspAccountInformations = new List<TermAccountInformation>();
            ServiceResult serviceResult;
            try
            {
                ProgressUIManager.ShowProgress(this);
                serviceResult = TermService.SearchSspAccounts(_sspRequestDto);
                ProgressUIManager.CloseProgress();

                if (serviceResult.Success)
                {
                    //dgResults.Rows.Clear();
                    //dgResults.DataSource = _sspAccountInformations;


                    //_sspAccountInformations = serviceResult.ReturnedObject as List<SspAccountInformation>;
                    _sspAccountInformations = (List<TermAccountInformation>)serviceResult.ReturnedObject;
                    dgResults.DataSource = null;


                    //dgResults.DataSource = _sspAccountInformations.Select(o => new SSPAccountInformationsGrid(o) { id = o.id, referanceNumber = o.referanceNumber, subAgentUser = o.subAgentUser }).ToList();
                    dgResults.DataSource = _sspAccountInformations.ToList();
                    dgResults.DataSource = _sspAccountInformations;

                }
                else
                {
                    Message.showError(serviceResult.Message);
                }
            }
            catch (Exception ex)
            {
                ProgressUIManager.CloseProgress();
                btnSearch.Enabled = true;
                Message.showError(ex.Message);
            }
            //_sspRequestDto.amount = 0;
            //_sspRequestDto.depositAccNum = "";
            //_sspRequestDto.depositAcctitle = "";
            _sspRequestDto.isamount = false;
            _sspRequestDto.isdepositAccNum = false;
            _sspRequestDto.isdepositAcctitle = false;
            _sspRequestDto.isreferanceNumber = false;
            _sspRequestDto.issspAccNum = false;
            _sspRequestDto.issspProductType = false;
            //_sspRequestDto.referanceNumber = "";
            //_sspRequestDto.sspAccNum = "";
            //_sspRequestDto.sspProductType = new SspProductType();
            //lstSearchCriteria.Items.Clear();

            //            MessageBox.Show(agentInformations.Count.ToString());
            //List<AgentInformationMediator> agentRecords = AgentInformationMediator.GetAgentInformationMediatedList(_agentInformations);            

            btnSearch.Enabled = true;
        }

        private void btnViewAgent_Click(object sender, EventArgs e)
        {
            if (dgResults.RowCount > 0)
            {
                TermAccountInformation sspAccountInformation = null;
                //if (_currentRowIndex > -1)
                {
                    sspAccountInformation = _sspAccountInformations[_currentRowIndex];
                }
                if (sspAccountInformation != null)
                {
                    //----------------------------------------------------------------------------------------//
                    //frmTermAccountOpening frm = new frmTermAccountOpening(sspAccountInformation.id);                    
                    //frm.ShowDialog();
                    //----------------------------------------------------------------------------------------//
                }
            }

            //if (dgResults.RowCount > 0)
            //{
            //    SspAccountInformation sspAccountInformation = null;
            //    if (_currentRowIndex > -1)
            //    {
            //        sspAccountInformation = _sspAccountInformations[_currentRowIndex];
            //    }
            //    if (sspAccountInformation != null)
            //    {

            //        frmSSPAccountOpening frm = new frmSSPAccountOpening(sspAccountInformation);
            //        frm.Show(this.Parent);
            //        //frmAgentCreation agentCreation = new frmAgentCreation(agentInformation, ActionType.update);
            //        //agentCreation.IsCalledByOtherForm = true;
            //        //agentCreation.ShowDialog();
            //    }
            //}
        }

        private void dgResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgResults.CurrentRow != null) _currentRowIndex = dgResults.CurrentRow.Index;

        }

        private void dgResults_SelectionChanged(object sender, EventArgs e)
        {
            if (dgResults.CurrentRow != null) _currentRowIndex = dgResults.CurrentRow.Index;

        }

        public class SSPAccountInformationsGrid
        {
            private const long SerialVersionUid = 1L;
            public long id;
            //public string depositAccNum;
            //public string depositAcctitle;
            //public string sspAccNum;
            //public SspProductType sspProductType;
            //public decimal amount;
            public string subAgentUser;
            //public string remarks;
            //public SspAccountStatus sspAccountStatus;
            public string referanceNumber;
            //public List<NomineeInformation> nominees;


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
    }
}

