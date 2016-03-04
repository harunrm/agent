using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MISL.Ababil.Agent.Services;
//using System.Runtime.Serialization.Json;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.cis;
//using System.Web.Script.Serialization;
using System.Net;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.documentMgt;

using MISL.Ababil.Agent.Infrastructure.Validation;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models;
using MISL.Ababil.Agent.UI.forms.ProgressUI;
using MISL.Ababil.Agent.Communication;


namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmCustomerCopy : Form
    {
        CustomerInformation objCutomerInfo = new CustomerInformation();
        List<OwnerInformation> objOwnerInfoList = new List<OwnerInformation>();
        List<SectorCodeInfo> publicSectorCodes = new List<SectorCodeInfo>();
        List<SectorCodeInfo> privateSectorCodes = new List<SectorCodeInfo>();

        long idForUpdate = 0;

        ActionType actionTypeForDocument = new ActionType();
        bool IsFoundDocument = false;
        long? docId = 0;

        public frmCustomerCopy()
        {
            InitializeComponent();
            addDeleteButtons();
            FillSectorType();
            ConfigureValidation();
        }

        private void ConfigureValidation()
        {
            ValidationManager.ConfigureValidation(this, cmbCustomerType, "Customer Type", (long)ValidationType.ListSelected, true);
            ValidationManager.ConfigureValidation(this, cmbInstitutionType, "Institution Type", (long)ValidationType.ListSelected, true);
            ValidationManager.ConfigureValidation(this, txtCustomerTitle, "Customer Title", (long)ValidationType.NonWhitespaceNonEmptyText, true);
            ValidationManager.ConfigureValidation(this, txtTelephone, "Telephone", (long)ValidationType.BangladeshiLandPhoneNumber);
            ValidationManager.ConfigureValidation(this, txtEmail, "Email", (long)ValidationType.EmailAddress);
            ValidationManager.ConfigureValidation(this, txtMolile, "Mobile", (long)ValidationType.BangladeshiCellphoneNumber, true);
            ValidationManager.ConfigureValidation(this, txtFax, "Fax", (long)ValidationType.BangladeshiLandPhoneNumber);
            ValidationManager.ConfigureValidation(this, cmbLocation, "Location", (long)ValidationType.ListSelected, true);

            ValidationManager.ConfigureValidation(this, txtBusinessAddress1, "Business Address Line One", (long)ValidationType.NonWhitespaceNonEmptyText, true);
            ValidationManager.ConfigureValidation(this, txtBusinessAddress2, "Business Address Line Two", (long)ValidationType.NonWhitespaceNonEmptyText, false);


            ValidationManager.ConfigureValidation(this, cmbDivitionBus, "Business Address Division", (long)ValidationType.ListSelected, true);
            ValidationManager.ConfigureValidation(this, cmbDistrictBus, "Business Address District", (long)ValidationType.ListSelected, true);
            ValidationManager.ConfigureValidation(this, cmbThanaBus, "Business Address Thana", (long)ValidationType.ListSelected, true);
            ValidationManager.ConfigureValidation(this, cmbPostCodeBus, "Business Address Postal Code", (long)ValidationType.ListSelected, true);
            ValidationManager.ConfigureValidation(this, cmbCountryBus, "Business Address Country", (long)ValidationType.ListSelected, true);

            ValidationManager.ConfigureValidation(this, cmbDivitionPer, "Permanent Address Division", (long)ValidationType.ListSelected, true);
            ValidationManager.ConfigureValidation(this, cmbDistrictPer, "Permanent Address District", (long)ValidationType.ListSelected, true);
            ValidationManager.ConfigureValidation(this, cmbThanaPer, "Permanent Address Thana", (long)ValidationType.ListSelected, true);
            ValidationManager.ConfigureValidation(this, cmbPostCodePer, "Permanent Address Postal Code", (long)ValidationType.ListSelected, true);
            ValidationManager.ConfigureValidation(this, cmbCountryPer, "Permanent Address Country", (long)ValidationType.ListSelected, true);

            ValidationManager.ConfigureValidation(this, cmbDivitionPre, "Present Business Address Division", (long)ValidationType.ListSelected, true);
            ValidationManager.ConfigureValidation(this, cmbDistrictPre, "Present Business Address District", (long)ValidationType.ListSelected, true);
            ValidationManager.ConfigureValidation(this, cmbThanaPre, "Present Business Address Thana", (long)ValidationType.ListSelected, true);
            ValidationManager.ConfigureValidation(this, cmbPostCodePre, "Present Business Address Postal Code", (long)ValidationType.ListSelected, true);
            ValidationManager.ConfigureValidation(this, cmbCountryPre, "Present Business Address Country", (long)ValidationType.ListSelected, true);
            ValidationManager.ConfigureValidation(this, cmbSectorType, "Sector Type", (long)ValidationType.ListSelected, true);
            ValidationManager.ConfigureValidation(this, cmbSectorCode, "Sector Type", (long)ValidationType.ListSelected, true);


        }

        private bool validationCheck()
        {
            return ValidationManager.ValidateForm(this);
        }


        public frmCustomerCopy(CustomerInformation customerInformation, ActionType actionType)
        {
            InitializeComponent();
            actionTypeForDocument = actionType;
            IsFoundDocument = true;
            FillSectorType();
            if (actionType == ActionType.update)
            {
                addEditButtons();
                //addDeleteButtons();
                objCutomerInfo = customerInformation;
                setCustomerInfoToUpdate(customerInformation);
                btnSave.Text = btnSave.DialogResult.ToString();
                cmbOwnerType.Enabled = false;
                cmbCustomerType.Enabled = false;
                ConfigureValidation();
            }
            else if (actionType == ActionType.getModel)
            {
                addEditButtons();
                //addDeleteButtons();
                objCutomerInfo = customerInformation;
                setCustomerInfoToUpdate(customerInformation);
                //txtCustomerTitle.Text = customerInformation.title;
                //txtMolile.Text = customerInformation.mobileNumber;
                btnSave.Text = btnSave.DialogResult.ToString();
                ConfigureValidation();

            }
            else if (actionType == ActionType.view)
            {
                addEditButtons();
                objCutomerInfo = customerInformation;
                setCustomerInfoToUpdate(customerInformation);
                btnSave.Text = btnSave.DialogResult.ToString();
                changeEnabled(false);
            }

            //ConfigureValidation();
        }

        //public frmCustomer(CustomerInformation _objCutomerInfo)
        //{

        //}
        private void frmCustomer_Load(object sender, EventArgs e)
        {

            //fillSetupData();
            UtilityServices.appendCustomerAddress(ref objCutomerInfo);
            loadCommonAddresses();
        }

        private void FillSectorType()
        {
            ComboboxItem itemSelect = new ComboboxItem();
            itemSelect.Text = "(Select)";
            itemSelect.Value = "0";
            ComboboxItem itemPublic = new ComboboxItem();
            itemPublic.Text = "Public";
            itemPublic.Value = "1";
            ComboboxItem itemPrivate = new ComboboxItem();
            itemPrivate.Text = "Private";
            itemPrivate.Value = "2";
            cmbSectorType.Items.Add(itemSelect);
            cmbSectorType.Items.Add(itemPublic);
            cmbSectorType.Items.Add(itemPrivate);

            cmbSectorType.SelectedIndex = 0;
        }

        private void loadCommonAddresses()
        {
            if (UtilityServices.commonAddresses != null)
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = UtilityServices.commonAddresses;
                BindingSource bs1 = new BindingSource();
                bs1.DataSource = UtilityServices.commonAddresses;
                BindingSource bs2 = new BindingSource();
                bs2.DataSource = UtilityServices.commonAddresses;
                UtilityServices.fillComboBox(cmbBusinessAddressCopy, bs, "commonAddressName", "commonAddressIndex");
                UtilityServices.fillComboBox(cmbPermanentAddressCopy, bs1, "commonAddressName", "commonAddressIndex");
                UtilityServices.fillComboBox(cmbPresentAddressCopy, bs2, "commonAddressName", "commonAddressIndex");
                cmbBusinessAddressCopy.Text = "Select";
                cmbPermanentAddressCopy.Text = "Select";
                cmbPresentAddressCopy.Text = "Select";
            }
        }
        void addDeleteButtons()
        {
            DataGridViewButtonColumn btnOwnerDelete = new DataGridViewButtonColumn();
            gvOwnerInfo.Columns.Add(btnOwnerDelete);
            btnOwnerDelete.HeaderText = "";
            btnOwnerDelete.Text = "Delete";
            btnOwnerDelete.Name = "btnDelete";
            btnOwnerDelete.UseColumnTextForButtonValue = true;
        }
        void addEditButtons()
        {
            DataGridViewButtonColumn btnOwnerEdit = new DataGridViewButtonColumn();
            gvOwnerInfo.Columns.Add(btnOwnerEdit);
            btnOwnerEdit.HeaderText = "";
            //if (UserWiseRights.subAgentRights.All(s => SessionInfo.rights.Contains(s)))
            if (UtilityServices.isRightExist(Rights.DRAFT_CONSUMER_APPLICATION))
                btnOwnerEdit.Text = "Edit";
            else
                btnOwnerEdit.Text = "View";
            btnOwnerEdit.Name = "btnEdit";
            btnOwnerEdit.UseColumnTextForButtonValue = true;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void fillSetupData()
        {
            try
            {

                UtilityServices.fillCustomerTypes(ref cmbCustomerType);
                cmbCustomerType.Text = "Select";

                //UtilityServices.fillOwnerTypesByCisType(ref cmbOwnerType);
                UtilityServices.fillDivisions(ref cmbDivitionBus);
                cmbDivitionBus.Text = "Select";
                UtilityServices.fillDivisions(ref cmbDivitionPer);
                cmbDivitionPer.Text = "Select";
                UtilityServices.fillDivisions(ref cmbDivitionPre);
                cmbDivitionPre.Text = "Select";
                UtilityServices.fillCountries(ref cmbCountryBus);
                cmbCountryBus.Text = "Select";
                UtilityServices.fillCountries(ref cmbCountryPer);
                cmbCountryPer.Text = "Select";
                UtilityServices.fillCountries(ref cmbCountryPre);
                cmbCountryPre.Text = "Select";

                UtilityServices.fillInstitutionTypes(ref cmbInstitutionType);
                cmbInstitutionType.Text = "Select";
                cmbLocation.DataSource = Enum.GetValues(typeof(CisLocation));
                //cmbLocation.Text = "Select";
                countrySet();
                txtMolile.MaxLength = CommonRules.mobileNoLength;

                txtIndividualId.Enabled = false;
                btnNewIndividual.Enabled = false;
                btnAddSelectedIndividualAsOwner.Enabled = false;
                btnSearch.Enabled = false;

                if (UtilityServices.commonAddresses != null)
                {
                    BindingSource bs = new BindingSource();
                    bs.DataSource = UtilityServices.commonAddresses;
                    UtilityServices.fillComboBox(cmbBusinessAddressCopy, bs, "commonAddressName", "commonAddressIndex");
                    UtilityServices.fillComboBox(cmbPermanentAddressCopy, bs, "commonAddressName", "commonAddressIndex");
                    UtilityServices.fillComboBox(cmbPresentAddressCopy, bs, "commonAddressName", "commonAddressIndex");
                    cmbBusinessAddressCopy.Text = "Select";
                    cmbPermanentAddressCopy.Text = "Select";
                    cmbPresentAddressCopy.Text = "Select";
                }

              //  cmbSectorType.SelectedValue = 1;
                UtilityCom objUtil = new UtilityCom();
                List<SectorCodeInfo> SectorCodeList = objUtil.getcmbSectorCodeList();
               
                foreach (SectorCodeInfo singleInfo in SectorCodeList)
                {


                    if (singleInfo.sectorType == 1)
                    {

                        publicSectorCodes.Add(singleInfo);
                        publicSectorCodes = publicSectorCodes.OrderBy(x => x.name).ToList();
                    }
                    else
                    {
                        privateSectorCodes.Add(singleInfo);
                        privateSectorCodes = privateSectorCodes.OrderBy(x => x.name).ToList();
                    }
                }




            }
            catch (Exception ex)
            { }

        }

        private void countrySet()
        {
            cmbCountryBus.SelectedValue = CommonRules.countryId;
            cmbCountryPer.SelectedValue = CommonRules.countryId;
            cmbCountryPre.SelectedValue = CommonRules.countryId;
        }

        private void cmbDivitionBus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (!cb.Focused)
            {
                return;
            }
            int divisionId = Convert.ToInt32(cmbDivitionBus.SelectedValue);
            UtilityServices.fillDistrictsByDivision(ref cmbDistrictBus, divisionId);
            cmbDistrictBus.Text = "Select";
            cmbThanaBus.DataSource = null;
            cmbPostCodeBus.DataSource = null;

        }
        private void cmbDistrictBus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (!cb.Focused)
            {
                return;
            }
            UtilityServices.fillThanaByDistrict(ref cmbThanaBus, Convert.ToInt32(cmbDistrictBus.SelectedValue));
            cmbThanaBus.Text = "Select";
            UtilityServices.fillPostalCodeByDistrict(ref cmbPostCodeBus, Convert.ToInt32(cmbDistrictBus.SelectedValue));
            cmbPostCodeBus.Text = "Select";
        }
        private void cmbDivitionPer_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (!cb.Focused)
            {
                return;
            }
            int divisionId = Convert.ToInt32(cmbDivitionPer.SelectedValue);
            UtilityServices.fillDistrictsByDivision(ref cmbDistrictPer, divisionId);
            cmbDistrictPer.Text = "Select";
            cmbThanaPer.DataSource = null;
            cmbPostCodePer.DataSource = null;
        }
        private void cmbDistrictPer_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (!cb.Focused)
            {
                return;
            }
            UtilityServices.fillThanaByDistrict(ref cmbThanaPer, Convert.ToInt32(cmbDistrictPer.SelectedValue));
            cmbDistrictPer.Text = "Select";
            UtilityServices.fillPostalCodeByDistrict(ref cmbPostCodePer, Convert.ToInt32(cmbDistrictPer.SelectedValue));
            cmbDistrictPer.Text = "Select";
        }
        private void cmbDivitionPre_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (!cb.Focused)
            {
                return;
            }
            int divisionId = Convert.ToInt32(cmbDivitionPre.SelectedValue);
            UtilityServices.fillDistrictsByDivision(ref cmbDistrictPre, divisionId);
            cmbDistrictPre.Text = "Select";
            cmbThanaPre.DataSource = null;
            cmbPostCodePre.DataSource = null;
        }
        private void cmbDistrictPre_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (!cb.Focused)
            {
                return;
            }
            UtilityServices.fillThanaByDistrict(ref cmbThanaPre, Convert.ToInt32(cmbDistrictPre.SelectedValue));
            cmbDistrictPre.Text = "Select";
            UtilityServices.fillPostalCodeByDistrict(ref cmbPostCodePre, Convert.ToInt32(cmbDistrictPre.SelectedValue));
            cmbDistrictPre.Text = "Select";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;

            //if (validationCheck())
            //{
            if (!validationCheck())
            {
                btnSave.Enabled = true;
                return;
            }

            if (((Button)sender).Text != ((Button)sender).DialogResult.ToString())
            {
                string result = Message.showConfirmation("Are you sure to save?");

                if (result == "yes")
                {
                    CustomerServices objCustomerServices = new CustomerServices();
                    CustomerInformation objCis = new CustomerInformation();
                    objCis = fillCustomerInformation();
                    try
                    {
                        //if (customerValidation(objCis))           //not necessary when validationCheck() is used.
                        //{
                        ProgressUIManager.ShowProgress(this);
                        string retrnMsg = objCustomerServices.saveCustomer(objCis);
                        ProgressUIManager.CloseProgress();

                        Message.showConfirmation(retrnMsg);
                        clearData();
                        //}
                    }
                    catch (Exception ex)
                    {
                        ProgressUIManager.CloseProgress();
                        btnSave.Enabled = true;
                        Message.showError(ex.Message);
                    }
                }

            }
            //}

            btnSave.Enabled = true;
        }

        public bool customerValidation(CustomerInformation objCustomer)
        {
            if (objCustomer.cisType == null)
            {
                MessageBox.Show("Customer type not found.");
                return false;
            }
            if (objCustomer.cisType.id == CommonRules.cisType_institute && (objCustomer.cisInstituteType == null || objCustomer.cisInstituteType.id == 0))
            {
                MessageBox.Show("Institute type not found.");
                return false;
            }
            if (objCustomer.title == "")
            {
                MessageBox.Show("Customer title not found.");
                return false;
            }
            if (objCustomer.sectorType ==0)
            {
                MessageBox.Show("Sectore Type not found.");
                return false; 
            }
            if (objCustomer.sectorType == 0)
            {
                MessageBox.Show("Sectore Code not found.");
                return false;
            }
            if (objCustomer.mobileNumber == "")
            {
                MessageBox.Show("Mobile number not found.");
                return false;
            }
            //if (objCustomer.location == null)
            //{
            //    MessageBox.Show("Location not found.");
            //    return false;
            //}
            if (objCustomer.cisType.id == CommonRules.cisType_institute && objCustomer.businessAddress == null)
            {
                MessageBox.Show("Business address not found.");
                return false;
            }
            else if (objCustomer.cisType.id == CommonRules.cisType_institute && objCustomer.businessAddress.addressLineOne == "" && objCustomer.businessAddress.addressLineTwo == "")
            {
                MessageBox.Show("Business address not found.");
                return false;
            }
            if (objCustomer.permanentAddress == null)
            {
                MessageBox.Show("Permanent address not found.");
                return false;
            }
            else if (objCustomer.permanentAddress.addressLineOne == "" && objCustomer.permanentAddress.addressLineTwo == "")
            {
                MessageBox.Show("Permanent address not found.");
                return false;
            }
            if (objCustomer.presentAddress == null)
            {
                MessageBox.Show("Present address not found.");
                return false;
            }
            else if (objCustomer.presentAddress.addressLineOne == "" && objCustomer.presentAddress.addressLineTwo == "")
            {
                MessageBox.Show("Present address not found.");
                return false;
            }
            return true;
        }
        public CustomerInformation getCustomerForDilogResult()
        {
            objCutomerInfo = fillCustomerInformation();

            return objCutomerInfo;
        }
        private CustomerInformation fillCustomerInformation()
        {
            CustomerInformation objCis = new CustomerInformation();
            objCis.borrowerCode = txtBorrowerCode.Text;
            objCis.sectorType = long.Parse(((ComboboxItem)cmbSectorType.SelectedItem).Value.ToString());
            if (cmbSectorCode.SelectedValue != null)
                objCis.sectorCode = cmbSectorCode.SelectedValue.ToString();
            else
                objCis.sectorCode = null;
            if (docId != 0) objCis.documentInfoId = docId;
            if (idForUpdate != 0) objCis.id = idForUpdate;
            objCis.title = txtCustomerTitle.Text;
            objCis.phoneNumber = txtTelephone.Text;
            objCis.email = txtEmail.Text;
            objCis.mobileNumber = txtMolile.Text;
            objCis.fax = txtFax.Text;
            objCis.location = (CisLocation)cmbLocation.SelectedValue;
            if (objCutomerInfo == null) objCutomerInfo = new CustomerInformation();
            if (objCutomerInfo.businessAddress != null)
                objCis.businessAddress = UtilityServices.genClientAddress(txtBusinessAddress1.Text.Trim(), txtBusinessAddress2.Text.Trim(), cmbPostCodeBus, cmbThanaBus, cmbDistrictBus, cmbDivitionBus, cmbCountryBus, objCutomerInfo.businessAddress.commonAddressIndex, objCutomerInfo.businessAddress.commonAddressName);
            else
                objCis.businessAddress = UtilityServices.genClientAddress(txtBusinessAddress1.Text.Trim(), txtBusinessAddress2.Text.Trim(), cmbPostCodeBus, cmbThanaBus, cmbDistrictBus, cmbDivitionBus, cmbCountryBus, null, null);
            if (objCutomerInfo.permanentAddress != null)
                objCis.permanentAddress = UtilityServices.genClientAddress(txtPermanentBusinessAddress1.Text.Trim(), txtPermanentBusinessAddress2.Text.Trim(), cmbPostCodePer, cmbThanaPer, cmbDistrictPer, cmbDivitionPer, cmbCountryPer, objCutomerInfo.permanentAddress.commonAddressIndex, objCutomerInfo.permanentAddress.commonAddressName);
            else
                objCis.permanentAddress = UtilityServices.genClientAddress(txtPermanentBusinessAddress1.Text.Trim(), txtPermanentBusinessAddress2.Text.Trim(), cmbPostCodePer, cmbThanaPer, cmbDistrictPer, cmbDivitionPer, cmbCountryPer, null, null);
            if (objCutomerInfo.presentAddress != null)
                objCis.presentAddress = UtilityServices.genClientAddress(txtPresentBusinessAddress1.Text.Trim(), txtPresentBusinessAddress2.Text.Trim(), cmbPostCodePre, cmbThanaPre, cmbDistrictPre, cmbDivitionPre, cmbCountryPre, objCutomerInfo.presentAddress.commonAddressIndex, objCutomerInfo.presentAddress.commonAddressName);
            else
                objCis.presentAddress = UtilityServices.genClientAddress(txtPresentBusinessAddress1.Text.Trim(), txtPresentBusinessAddress2.Text.Trim(), cmbPostCodePre, cmbThanaPre, cmbDistrictPre, cmbDivitionPre, cmbCountryPre, null, null);
            objCis.branchId = 0;
            objCis.cisType = UtilityServices.genCisType(Convert.ToInt32(cmbCustomerType.SelectedValue), null, null);
            objCis.cisInstituteType = (cmbInstitutionType.SelectedIndex == -1) ? null : UtilityServices.genCisInstituteType(Convert.ToInt32(cmbInstitutionType.SelectedValue), null);
            objCis.owners = objOwnerInfoList;
            objCis.businessAddress.country.id = Convert.ToInt32(cmbCountryBus.SelectedValue);
            objCis.permanentAddress.country.id = Convert.ToInt32(cmbCountryPer.SelectedValue);
            objCis.presentAddress.country.id = Convert.ToInt32(cmbCountryPre.SelectedValue);
            return objCis;

        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            string result = Message.showConfirmation("Are you sure to clear all data?");

            if (result == "yes")
            {
                clearData();
            }
        }
        private void btnAddSelectedIndividualAsOwner_Click(object sender, EventArgs e)
        {
            if (txtIndividualId.Text == "")
            {
                MessageBox.Show("Input Individual ID.");
                return;
            }

            IndividualServices objIndividualServices = new IndividualServices();

            IndividualInformation objIndividualInfo = new IndividualInformation();
            OwnerInformation objOwnerInfo = new OwnerInformation();

            if (objOwnerInfoList == null) { objOwnerInfoList = new List<OwnerInformation>(); }
            if (objIndividualInfo != null)
            {
                try
                {
                    objIndividualInfo = objIndividualServices.GetIndividualInfo(Convert.ToInt32(txtIndividualId.Text));
                    if (objIndividualInfo != null)
                    {
                        objOwnerInfo.individualInformation = objIndividualInfo;
                        int ownerTypeId = (cmbOwnerType.SelectedValue != "") ? Convert.ToInt32(cmbOwnerType.SelectedValue) : 0;
                        objOwnerInfo.ownerType = UtilityServices.genCisOwnerType(ownerTypeId, cmbOwnerType.Text, "");
                        objOwnerInfoList.Add(objOwnerInfo);
                      //  gvOwnerInfo.DataSource = objOwnerInfoList.Select(o => new OwnersGrid(o) { Name = o.individualInformation.firstName + o.individualInformation.lastName, Fathers_Name = o.individualInformation.fatherFirstName, OwnerType = o.ownerType.description }).ToList();
                    }
                    else
                        Message.showInformation("Individual not found");
                }
                //List<IndividualInformation> individiualList = new List<IndividualInformation>();
                //individiualList.Add(objIndividualInfo);
                //gvOwnerInfo.AutoGenerateColumns = false;
                //gvOwnerInfo.DataSource = null;
                //gvOwnerInfo.DataSource = individiualList;
                catch (Exception ex)
                {
                    Message.showError(ex.Message);
                }
            }

        }
        private void businessAddressTopermanentAddress()
        {
            try
            {
                UtilityServices.copyAddress(txtBusinessAddress1, txtBusinessAddress2, cmbPostCodeBus, cmbThanaBus, cmbDistrictBus, cmbDivitionBus, cmbCountryBus, ref txtPermanentBusinessAddress1, ref txtPermanentBusinessAddress2, ref cmbPostCodePer, ref cmbThanaPer, ref cmbDistrictPer, ref cmbDivitionPer, ref cmbCountryPer);
            }
            catch (Exception ex)
            {
                Message.showError(ex.Message);
            }
        }
        private void businessAddressToPresentAddress()
        {
            try
            {
                UtilityServices.copyAddress(txtBusinessAddress1, txtBusinessAddress2, cmbPostCodeBus, cmbThanaBus, cmbDistrictBus, cmbDivitionBus, cmbCountryBus, ref txtPresentBusinessAddress1, ref txtPresentBusinessAddress2, ref cmbPostCodePre, ref cmbThanaPre, ref cmbDistrictPre, ref cmbDivitionPre, ref cmbCountryPre);
            }
            catch (Exception ex)
            {
                Message.showError(ex.Message);
            }
        }
        private void permanentAddressToPresentAddress()
        {
            try
            {
                UtilityServices.copyAddress(txtPermanentBusinessAddress1, txtPermanentBusinessAddress2, cmbPostCodePer, cmbThanaPer, cmbDistrictPer, cmbDivitionPer, cmbCountryPer, ref txtPresentBusinessAddress1, ref txtPresentBusinessAddress1, ref cmbPostCodePre, ref cmbThanaPre, ref cmbDistrictPre, ref cmbDivitionPre, ref cmbCountryPre);
            }
            catch (Exception ex)
            {
                Message.showError(ex.Message);
            }
        }
        private void clearData()
        {
            txtBusinessAddress1.Text = "";
            txtBusinessAddress2.Text = "";
            txtCustomerTitle.Text = "";
            txtEmail.Text = "";
            txtFax.Text = "";
            txtIndividualId.Text = "";
            txtMolile.Text = "";
            txtPermanentBusinessAddress1.Text = "";
            txtPermanentBusinessAddress2.Text = "";
            txtPresentBusinessAddress1.Text = "";
            txtPresentBusinessAddress2.Text = "";
            txtTelephone.Text = "";

            cmbDistrictBus.DataSource = null;
            cmbThanaBus.DataSource = null;
            cmbPostCodeBus.DataSource = null;

            cmbDistrictPer.DataSource = null;
            cmbThanaPer.DataSource = null;
            cmbPostCodePer.DataSource = null;

            cmbDistrictPre.DataSource = null;
            cmbThanaPre.DataSource = null;
            cmbPostCodePre.DataSource = null;
        }
        private void chkUseBusinessAddress_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (!cb.Focused)
            {
                return;
            }
            if (chkUseBusinessAddress.Checked)
            {
                businessAddressTopermanentAddress();
            }
            else
            {
                //txtPermanentBusinessAddress1.Text = "";
                //txtPermanentBusinessAddress2.Text = "";
                //cmbDistrictPer.DataSource = null;
                //cmbThanaPer.DataSource = null;
                //cmbPostCodePer.DataSource = null;
                //cmbDivitionPer.SelectedIndex = 0;
            }
        }
        private void btnNewIndividual_Click(object sender, EventArgs e)
        {
            /*
            IndividualInformation objIndiInfo = new IndividualInformation();
            frmIndividualInformation objFrmIndividualInfo = new frmIndividualInformation(objIndiInfo, ActionType.getModel);
            DialogResult dr = objFrmIndividualInfo.ShowDialog();
            if (dr == DialogResult.OK)
            {
                OwnerInformation objOwnerInfo = new OwnerInformation();
                int ownerTypeId = (cmbOwnerType.SelectedValue != "") ? Convert.ToInt32(cmbOwnerType.SelectedValue) : 0;
                objOwnerInfo.ownerType = UtilityServices.genCisOwnerType(ownerTypeId, cmbOwnerType.Text, "");
                objOwnerInfo.individualInformation = objFrmIndividualInfo.getIndividualForDilogResult();
                if (objOwnerInfoList == null) { objOwnerInfoList = new List<OwnerInformation>(); }
                objOwnerInfoList.Add(objOwnerInfo);
                gvOwnerInfo.DataSource = objOwnerInfoList.Select(o => new OwnersGrid(o)
                {
                    Name = o.individualInformation.firstName + o.individualInformation.lastName,
                    Fathers_Name = o.individualInformation.fatherFirstName,
                    OwnerType = o.ownerType.ownerCode
                }).ToList();
            }
            */
        }
        private void gvOwnerInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gvOwnerInfo.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 1) //delete
                {
                    int rowIndex = e.RowIndex;
                    objOwnerInfoList.RemoveAt(rowIndex);
                    gvOwnerInfo.DataSource = null;
                    /*
                    gvOwnerInfo.DataSource = objOwnerInfoList.Select(o => new OwnersGrid(o)
                    {
                        Name = o.individualInformation.firstName + o.individualInformation.lastName,
                        Fathers_Name = o.individualInformation.fatherFirstName,
                        OwnerType = o.ownerType.ownerCode
                    }).ToList();*/
                }
                if (e.ColumnIndex == 0) //edit or view
                {
                    IndividualInformation objIndiInfo = objOwnerInfoList[e.RowIndex].individualInformation;
                    if (objIndiInfo == null) objIndiInfo = new IndividualInformation();
                    //=These codes are only to get common addresses of customer=//
                    objCutomerInfo = fillCustomerInformation();
                    UtilityServices.appendCustomerAddress(ref objCutomerInfo);
                    //===//

                    //recheckIndividual:
                    frmIndividualInformation objFrmIndividualInfo = null;
                    //if (UtilityServices.isRightExist(Rights.DRAFT_CONSUMER_APPLICATION))
                     //   objFrmIndividualInfo = new frmIndividualInformation(objIndiInfo, ActionType.update);
                    ///else
                      //  objFrmIndividualInfo = new frmIndividualInformation(objIndiInfo, ActionType.view);
                    DialogResult dr = objFrmIndividualInfo.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        //OwnerInformation objOwnerInfo = new OwnerInformation();
                        //int ownerTypeId = (cmbOwnerType.SelectedValue != "") ? Convert.ToInt32(cmbOwnerType.SelectedValue) : 0;
                        //objOwnerInfo.ownerType = objOwnerInfoList[e.RowIndex].ownerType;
                       // objIndiInfo = objFrmIndividualInfo.getIndividualForDilogResult();
                        //if (!objFrmIndividualInfo.checkIndividual(objIndiInfo))
                        //    goto recheckIndividual;
                        objOwnerInfoList[e.RowIndex].individualInformation = objIndiInfo;
                        if (objOwnerInfoList == null) { objOwnerInfoList = new List<OwnerInformation>(); }
                       /* gvOwnerInfo.DataSource = objOwnerInfoList.Select(o => new OwnersGrid(o)
                        {
                            Name = o.individualInformation.firstName + o.individualInformation.lastName,
                            Fathers_Name = o.individualInformation.fatherFirstName,
                            OwnerType = o.ownerType.description
                        }).ToList();
                        */
                        loadCommonAddresses();
                    }
                }
            }
        }
        private void validationCheckPrevious()
        {
            if (gvOwnerInfo.RowCount == 0)
            {
                MessageBox.Show("Add Individual as Owner");
            }
        }
        private void setCustomerInfoToUpdate(CustomerInformation customerInformation)
        {
            if (customerInformation != null)
            {
                if (customerInformation.documentInfoId != 0) docId = customerInformation.documentInfoId;
                fillSetupData();
                if (customerInformation.cisType != null)
                {

                    if (customerInformation.cisType.id != 0)
                    {
                        cmbCustomerType.SelectedValue = customerInformation.cisType.id;
                        UtilityServices.fillOwnerTypesByCisType(ref cmbOwnerType, (int)customerInformation.cisType.id);
                        cmbOwnerType.Text = "Select";
                        if (customerInformation.owners.Count != 0)
                        {
                            //if (customerInformation.owners[0].ownerType != null)
                            //    cmbInstitutionType.SelectedValue = customerInformation.owners[0].ownerType.id;
                        }
                        if (customerInformation.cisType.id != 3)
                        {
                            cmbInstitutionType.SelectedIndex = -1;
                            cmbInstitutionType.Enabled = false;
                        }
                    }
                }
                if (customerInformation.sectorType != 0 || customerInformation.sectorType != null)
                {
                    try
                    {
                        cmbSectorType.SelectedIndex = (int)customerInformation.sectorType;
                    }
                    catch { }
                }
                if (customerInformation.sectorCode != null)
                {
                    UtilityServices.GetSectorCodeList(ref cmbSectorCode, ref publicSectorCodes, ref privateSectorCodes);

                    cmbSectorCode.SelectedValue = customerInformation.sectorCode;

                }
                if (customerInformation.cisInstituteType != null)
                {
                    if (customerInformation.cisInstituteType.id != 0)
                        cmbInstitutionType.SelectedValue = customerInformation.cisInstituteType.id;
                    else
                        cmbInstitutionType.Text = "Select";
                }
                else
                {
                    cmbInstitutionType.SelectedIndex = -1;
                    cmbInstitutionType.Text = "Select";

                }
                if (customerInformation.borrowerCode != null) txtBorrowerCode.Text = customerInformation.borrowerCode;
                if (customerInformation.id != 0) idForUpdate = customerInformation.id;
                if (customerInformation.title != null) txtCustomerTitle.Text = customerInformation.title;
                if (customerInformation.email != null) txtEmail.Text = customerInformation.email;
                if (customerInformation.fax != null) txtFax.Text = customerInformation.fax;
                if (customerInformation.mobileNumber != null) txtMolile.Text = customerInformation.mobileNumber;
                if (customerInformation.phoneNumber != null) txtTelephone.Text = customerInformation.phoneNumber;

                if (customerInformation.businessAddress != null)
                {
                    txtBusinessAddress1.Text = customerInformation.businessAddress.addressLineOne;
                    txtBusinessAddress2.Text = customerInformation.businessAddress.addressLineTwo;
                    if (customerInformation.businessAddress.division != null)
                    {
                        if (customerInformation.businessAddress.division.id != 0)
                        {
                            UtilityServices.fillDivisions(ref cmbDivitionBus);
                            cmbDivitionBus.SelectedValue = customerInformation.businessAddress.division.id;
                            if (customerInformation.businessAddress.district != null)
                            {
                                if (customerInformation.businessAddress.district.id != 0)
                                {
                                    UtilityServices.fillDistrictsByDivision(ref cmbDistrictBus, customerInformation.businessAddress.division.id);
                                    cmbDistrictBus.SelectedValue = customerInformation.businessAddress.district.id;
                                    if (customerInformation.businessAddress.thana != null)
                                    {
                                        if (customerInformation.businessAddress.thana.id != 0)
                                        {
                                            UtilityServices.fillThanaByDistrict(ref cmbThanaBus, customerInformation.businessAddress.district.id);
                                            cmbThanaBus.SelectedValue = customerInformation.businessAddress.thana.id;
                                        }
                                    }

                                    if (customerInformation.businessAddress.postalCode != null)
                                    {
                                        if (customerInformation.businessAddress.postalCode.id != 0)
                                        {
                                            UtilityServices.fillPostalCodeByDistrict(ref cmbPostCodeBus, customerInformation.businessAddress.district.id);
                                            cmbPostCodeBus.SelectedValue = customerInformation.businessAddress.postalCode.id;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (customerInformation.businessAddress.country != null)
                    {
                        if (customerInformation.businessAddress.country.id != 0)
                        {
                            UtilityServices.fillCountries(ref cmbCountryBus);
                            cmbCountryBus.SelectedValue = customerInformation.businessAddress.country.id;
                        }
                    }
                }
                if (customerInformation.permanentAddress != null)
                {
                    txtPermanentBusinessAddress1.Text = customerInformation.permanentAddress.addressLineOne;
                    txtPermanentBusinessAddress2.Text = customerInformation.permanentAddress.addressLineTwo;
                    if (customerInformation.permanentAddress.division != null)
                    {
                        if (customerInformation.permanentAddress.division.id != 0)
                        {
                            UtilityServices.fillDivisions(ref cmbDivitionPer);
                            cmbDivitionPer.SelectedValue = customerInformation.permanentAddress.division.id;
                            if (customerInformation.permanentAddress.district != null)
                            {
                                if (customerInformation.permanentAddress.district.id != 0)
                                {
                                    UtilityServices.fillDistrictsByDivision(ref cmbDistrictPer, customerInformation.permanentAddress.division.id);
                                    cmbDistrictPer.SelectedValue = customerInformation.permanentAddress.district.id;
                                    if (customerInformation.permanentAddress.thana != null)
                                    {
                                        if (customerInformation.permanentAddress.thana.id != 0)
                                        {
                                            UtilityServices.fillThanaByDistrict(ref cmbThanaPer, customerInformation.permanentAddress.district.id);
                                            cmbThanaPer.SelectedValue = customerInformation.permanentAddress.thana.id;
                                        }
                                    }
                                    if (customerInformation.permanentAddress.postalCode != null)
                                    {
                                        if (customerInformation.permanentAddress.postalCode.id != 0)
                                        {
                                            UtilityServices.fillPostalCodeByDistrict(ref cmbPostCodePer, customerInformation.permanentAddress.district.id);
                                            cmbPostCodePer.SelectedValue = customerInformation.permanentAddress.postalCode.id;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (customerInformation.permanentAddress.country != null)
                    {
                        if (customerInformation.permanentAddress.country.id != 0)
                        {
                            UtilityServices.fillCountries(ref cmbCountryPer);
                            cmbCountryPer.SelectedValue = customerInformation.permanentAddress.country.id;
                        }
                    }
                }
                if (customerInformation.presentAddress != null)
                {
                    txtPresentBusinessAddress1.Text = customerInformation.presentAddress.addressLineOne;
                    txtPresentBusinessAddress2.Text = customerInformation.presentAddress.addressLineTwo;
                    if (customerInformation.presentAddress.division != null)
                    {
                        if (customerInformation.presentAddress.division.id != 0)
                        {
                            UtilityServices.fillDivisions(ref cmbDivitionPre);
                            cmbDivitionPre.SelectedValue = customerInformation.presentAddress.division.id;
                            if (customerInformation.presentAddress.district != null)
                            {
                                if (customerInformation.presentAddress.district.id != 0)
                                {
                                    UtilityServices.fillDistrictsByDivision(ref cmbDistrictPre, customerInformation.presentAddress.division.id);
                                    cmbDistrictPre.SelectedValue = customerInformation.presentAddress.district.id;

                                    cmbThanaPre.Text = "Select";
                                    if (customerInformation.presentAddress.thana != null)
                                    {
                                        if (customerInformation.presentAddress.thana.id != 0)
                                        {
                                            UtilityServices.fillThanaByDistrict(ref cmbThanaPre, customerInformation.presentAddress.district.id);
                                            cmbThanaPre.SelectedValue = customerInformation.presentAddress.thana.id;
                                        }
                                    }
                                    if (customerInformation.presentAddress.postalCode != null)
                                    {
                                        if (customerInformation.presentAddress.postalCode.id != 0)
                                        {
                                            UtilityServices.fillPostalCodeByDistrict(ref cmbPostCodePre, customerInformation.presentAddress.district.id);
                                            cmbPostCodePre.SelectedValue = customerInformation.presentAddress.postalCode.id;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (customerInformation.presentAddress.country != null)
                    {
                        if (customerInformation.presentAddress.country.id != 0)
                        {
                            UtilityServices.fillCountries(ref cmbCountryPre);
                            cmbCountryPre.SelectedValue = customerInformation.presentAddress.country.id;
                        }
                    }
                }
                //if (customerInformation.cisType != null)
                //{
                //    cmbCustomerType.Text = customerInformation.cisType.description;
                //}
                //if (customerInformation.cisInstituteType != null)
                //{
                //    if (customerInformation.cisInstituteType.id != 0)
                //        cmbInstitutionType.SelectedValue = customerInformation.cisInstituteType.id;
                //}
                //if (customerInformation.location != null) 
                cmbLocation.Text = customerInformation.location.ToString();

                if (customerInformation.owners != null)
                {
                    objOwnerInfoList = customerInformation.owners;
                   // gvOwnerInfo.DataSource = objOwnerInfoList.Select(o => new OwnersGrid(o) { Name = o.individualInformation.firstName + o.individualInformation.lastName, Fathers_Name = o.individualInformation.fatherFirstName, OwnerType = o.ownerType.description }).ToList();
                }

            }
        }

        private void txtMolile_KeyUp(object sender, KeyEventArgs e)
        {


        }

        private void txtIndividualId_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsNumber(e.KeyChar) && (Keys)e.KeyChar != Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            base.OnKeyPress(e);
        }

        private void txtMolile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (Keys)e.KeyChar != Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            base.OnKeyPress(e);
        }

        private void txtTelephone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (Keys)e.KeyChar != Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            base.OnKeyPress(e);
        }

        private void changeEnabled(bool boolValue)
        {
            cmbSectorCode.Enabled = boolValue;
            cmbSectorType.Enabled = boolValue;
            txtBorrowerCode.Enabled = boolValue;

            txtBusinessAddress1.Enabled = boolValue;
            txtBusinessAddress2.Enabled = boolValue;
            txtCustomerTitle.Enabled = boolValue;
            txtEmail.Enabled = boolValue;
            txtFax.Enabled = boolValue;
            txtIndividualId.Enabled = boolValue;
            txtMolile.Enabled = boolValue;
            txtPermanentBusinessAddress1.Enabled = boolValue;
            txtPermanentBusinessAddress2.Enabled = boolValue;
            txtPresentBusinessAddress1.Enabled = boolValue;
            txtPresentBusinessAddress2.Enabled = boolValue;
            txtTelephone.Enabled = boolValue;
            chkPermanentToPresent.Enabled = boolValue;
            chkBusinessToPresent.Enabled = boolValue;

            //cmbCountryBus.Enabled = boolValue;
            //cmbCountryPer.Enabled = boolValue;
            //cmbCountryPre.Enabled = boolValue;
            cmbCustomerType.Enabled = boolValue;
            cmbDistrictBus.Enabled = boolValue;
            cmbDistrictPer.Enabled = boolValue;
            cmbDistrictPre.Enabled = boolValue;
            cmbDivitionBus.Enabled = boolValue;
            cmbDivitionPer.Enabled = boolValue;
            cmbDivitionPre.Enabled = boolValue;
            cmbLocation.Enabled = boolValue;
            cmbOwnerType.Enabled = boolValue;
            cmbPostCodeBus.Enabled = boolValue;
            cmbPostCodePer.Enabled = boolValue;
            cmbPostCodePre.Enabled = boolValue;
            cmbThanaBus.Enabled = boolValue;
            cmbThanaPer.Enabled = boolValue;
            cmbThanaPre.Enabled = boolValue;
            cmbInstitutionType.Enabled = boolValue;

            btnSave.Enabled = boolValue;
            btnClear.Enabled = boolValue;

            chkUseBusinessAddress.Enabled = boolValue;

            cmbBusinessAddressCopy.Enabled = boolValue;
            cmbPermanentAddressCopy.Enabled = boolValue;
            cmbPresentAddressCopy.Enabled = boolValue;
        }

        private void btnDocument_Click(object sender, EventArgs e)
        {
            frmDocument doc = new frmDocument(Convert.ToInt32(docId), actionTypeForDocument);
            //frmDocument doc = new frmDocument(7, ActionType.update);           
            DialogResult dr = doc.ShowDialog();

            if (dr == DialogResult.OK)
            {
                try
                {
                    docId = Convert.ToInt32(doc.getDocIdAfterSave());

                }
                catch (Exception ex)
                {
                    // MessageBox.Show(doc.getDocIdAfterSave());
                }

            }
        }

        private void cmbCustomerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (!cb.Focused)
            {
                return;
            }
            UtilityServices.fillOwnerTypesByCisType(ref cmbOwnerType, Convert.ToInt32(cmbCustomerType.SelectedValue));
            cmbOwnerType.SelectedText = "Select";
        }

        private void btnSave_MouseDown(object sender, MouseEventArgs e)
        {
            objCutomerInfo = fillCustomerInformation();
            UtilityServices.appendCustomerAddress(ref objCutomerInfo);
            //if (!customerValidation(objCutomerInfo) && (btnSave.DialogResult == DialogResult.OK))
            if (!customerValidation(objCutomerInfo) && (btnSave.DialogResult == DialogResult.OK))
            {
                btnSave.DialogResult = DialogResult.None;
            }
            else
            {
                btnSave.DialogResult = DialogResult.OK;
            }
            ////MessageBox.Show("From down");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void frmCustomer_FormClosing(object sender, FormClosingEventArgs e)
        {
            ValidationManager.ReleaseValidationData(this);
        }

        private void cmbBusinessAddressCopy_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (!cb.Focused)
            {
                return;
            }
            Address addr = UtilityServices.commonAddresses.Single(o => o.commonAddressIndex == (int)(cmbBusinessAddressCopy.SelectedValue));
            UtilityServices.setAddress(addr, ref txtBusinessAddress1, ref txtBusinessAddress2, ref cmbPostCodeBus, ref cmbThanaBus, ref cmbDistrictBus, ref cmbDivitionBus, ref cmbCountryBus);
        }

        private void cmbPermanentAddressCopy_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (!cb.Focused)
            {
                return;
            }
            chkUseBusinessAddress.Checked = false;
            Address addr = UtilityServices.commonAddresses.Single(o => o.commonAddressIndex == (int)(cmbPermanentAddressCopy.SelectedValue));
            UtilityServices.setAddress(addr, ref txtPermanentBusinessAddress1, ref txtPermanentBusinessAddress2, ref cmbPostCodePer, ref cmbThanaPer, ref cmbDistrictPer, ref cmbDivitionPer, ref cmbCountryPer);
        }

        private void cmbPresentAddressCopy_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (!cb.Focused)
            {
                return;
            }
            chkBusinessToPresent.Checked = false;
            chkPermanentToPresent.Checked = false;
            Address addr = UtilityServices.commonAddresses.Single(o => o.commonAddressIndex == (int)(cmbPresentAddressCopy.SelectedValue));
            UtilityServices.setAddress(addr, ref txtPresentBusinessAddress1, ref txtPresentBusinessAddress2, ref cmbPostCodePre, ref cmbThanaPre, ref cmbDistrictPre, ref cmbDivitionPre, ref cmbCountryPre);
        }

        private void chkBusinessToPresent_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (!cb.Focused)
            {
                return;
            }
            if (chkBusinessToPresent.Checked)
            {
                chkPermanentToPresent.Checked = false;
                businessAddressToPresentAddress();
            }
            else
            {
                //txtPresentBusinessAddress1.Text = "";
                //txtPresentBusinessAddress2.Text = "";
                //cmbDistrictPre.DataSource = null;
                //cmbThanaPre.DataSource = null;
                //cmbPostCodePre.DataSource = null;
                //cmbDivitionPre.SelectedIndex = 0;
            }
        }

        private void chkPermanentToPresent_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (!cb.Focused)
            {
                return;
            }
            if (chkPermanentToPresent.Checked)
            {
                chkBusinessToPresent.Checked = false;
                permanentAddressToPresentAddress();
            }
            else
            {
                //txtPresentBusinessAddress1.Text = "";
                //txtPresentBusinessAddress2.Text = "";
                //cmbDistrictPre.DataSource = null;
                //cmbThanaPre.DataSource = null;
                //cmbPostCodePre.DataSource = null;
                //cmbDivitionPre.SelectedIndex = 0;
            }
        }

        private void cmbSectorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSectorType.SelectedIndex != 0)
            {
                BindingSource sc = new BindingSource();
                if (cmbSectorType.SelectedIndex == 1)
                    //  cmbSectorCode.DataSource = publicSectorCodes;
                    sc.DataSource = publicSectorCodes.OrderBy(x => x.name).ToList();

                if (cmbSectorType.SelectedIndex == 2)
                    // cmbSectorCode.DataSource = privateSectorCodes;
                    sc.DataSource = privateSectorCodes.OrderBy(x => x.name).ToList();

                UtilityServices.fillComboBox(cmbSectorCode, sc, "NameWithCode", "code");
            }

        }
    }
    public class OwnersGridCopy
    {
        public string Name { get; set; }
        public string Fathers_Name { get; set; }
        public string OwnerType { get; set; }

        private OwnerInformation _obj;

        public OwnersGridCopy(OwnerInformation obj)
        {
            _obj = obj;
        }

        public OwnerInformation GetModel()
        {
            return _obj;
        }
    }
}
