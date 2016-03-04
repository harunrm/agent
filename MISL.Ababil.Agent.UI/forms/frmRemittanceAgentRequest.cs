using MISL.Ababil.Agent.Communication;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.Remittance;
using MISL.Ababil.Agent.Infrastructure.Models.models.transaction;
using MISL.Ababil.Agent.Infrastructure.Validation;
using MISL.Ababil.Agent.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MISL.Ababil.Agent.UI.forms.ProgressUI;
using MetroFramework.Forms;
using MetroFramework.Controls;
using MISL.Ababil.Agent.LocalStorageService;

namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmRemittanceAgentRequest : MetroForm
    {
        public GUI _gui = new GUI();
        private AmountInWords _amountInWords = new AmountInWords();
        public Remittance _remittance = new Remittance();

        public bool _IsFromAdmin = false;
        private bool _IsDocFirstRun = true;
        private string _subAgentFingerData = null;
        private RemittanceStatus _existingStatus;

        public frmRemittanceAgentRequest()
        {
            InitializeComponent();
            ConfigUIEnhancement();
            this.FormBorderStyle = FormBorderStyle.None;
        }

        public void ConfigUIEnhancement()
        {
            _gui = new GUI(this);
            _gui.Config(ref cmbCompanyName);
            _gui.Config(ref txtSecurityCodePINCode, ValidCheck.VALIDATIONTYPES.TEXTBOX_EMPTY, null);
            _gui.Config(ref txtName, ValidCheck.VALIDATIONTYPES.TEXTBOX_EMPTY, null);
            _gui.Config(ref cmbSenderCountry, ValidCheck.VALIDATIONTYPES.COMBOBOX_EMPTY, null);
            _gui.Config(ref txtPurpose, ValidCheck.VALIDATIONTYPES.TEXTBOX_EMPTY, null);

            _gui.Config(ref txtExpectedAmount, ValidCheck.VALIDATIONTYPES.TEXTBOX_NUMBER, null);
            _gui.Config(ref txtCorrectedAmount);

            _gui.Config(ref txtNameBen, ValidCheck.VALIDATIONTYPES.TEXTBOX_EMPTY, null);
            _gui.Config(ref txtFathersName);
            _gui.Config(ref txtMothersName);
            _gui.Config(ref txtMobileNo, ValidCheck.VALIDATIONTYPES.TEXTBOX_NUMBER_MOBILE, null);
            _gui.Config(ref txtAddressLineOne, ValidCheck.VALIDATIONTYPES.TEXTBOX_EMPTY, null);
            _gui.Config(ref txtAddressLineTwo);
            _gui.Config(ref cmbDivision, ValidCheck.VALIDATIONTYPES.COMBOBOX_EMPTY, null);
            _gui.Config(ref cmbDistrict, ValidCheck.VALIDATIONTYPES.COMBOBOX_EMPTY, null);
            _gui.Config(ref cmbThana, ValidCheck.VALIDATIONTYPES.COMBOBOX_EMPTY, null);
            _gui.Config(ref cmbPostalCode, ValidCheck.VALIDATIONTYPES.COMBOBOX_EMPTY, null);
            _gui.Config(ref cmbCountry);

            //gui.Config(ref cmbCompanyName, ValidCheck.VALIDATIONTYPES.COMBOBOX_EMPTY, null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool IsDocAvailable()
        {
            if (_remittance.documentId > 0)
            {
                return true;
            }
            return false;
        }

        private void btnSubmitRequest_Click(object sender, EventArgs e)
        {
            if (_gui.IsAllControlValidated() == true)
            {
                if (IsDocAvailable() == false)
                {
                    Message.showWarning("Document Not found.");
                    _gui.RefreshOwnerForm();
                    return;
                }
                //if (validationCheck() == true)
                //{
                string result = Message.showConfirmation("Do you want to submit?");
                _gui.RefreshOwnerForm();
                if (result == "yes")
                {
                    _existingStatus = _remittance.remittanceStatus;

                    if ((txtSecurityCodePINCode.Text == "") || (txtExpectedAmount.Text == "") || (txtMobileNo.Text == "") || (txtName.Text == "") || (txtAddressLineOne.Text == "") || (cmbDistrict.SelectedItem == null) || (cmbThana.SelectedItem == null) || (cmbPostalCode.SelectedItem == null) || (cmbSenderCountry.SelectedItem == null))
                    {
                        btnSubmitRequest.Enabled = true;
                        //Message.showWarning("Please entery all mandatory fields!");
                        return;
                    }
                    else
                    {
                        _remittance = fillRemittance();
                        _remittance.remittanceStatus = RemittanceStatus.Submitted;
                        RemittanceServices remittanceServices = new RemittanceServices();
                        try
                        {
                            ProgressUIManager.ShowProgress(this);
                            string responseString = remittanceServices.saveRemittance(_remittance);
                            ProgressUIManager.CloseProgress();
                            _gui.RefreshOwnerForm();
                            String msg = null;

                            switch (_remittance.remittanceStatus)
                            {
                                case RemittanceStatus.Submitted:
                                    if (responseString != null)
                                    {
                                        msg = "Remittance submitted successfully with reference no: " + responseString;
                                        clearAll();
                                    }
                                    else
                                    {
                                        msg = "Remittance submitted successfully with reference no: " + _remittance.referanceNumber;
                                        clearAll();
                                    }
                                    break;
                                case RemittanceStatus.ApprovedFirst:
                                    msg = "Remittance verified successfully. ";
                                    break;
                                case RemittanceStatus.Corrected:
                                    msg = "Remittance sent back for correction";
                                    break;
                                case RemittanceStatus.Rejected:
                                    msg = "Remittance Request rejecetd";
                                    break;
                                case RemittanceStatus.Approved:
                                    msg = "Remittance Request Approved successfully.";
                                    break;
                                case RemittanceStatus.Disbursed:
                                    msg = "Remittance disbursed successfully.";
                                    break;
                            }

                            Message.showInformation(msg);
                            _gui.RefreshOwnerForm();
                            if (_existingStatus != RemittanceStatus.Submitted)
                            {
                                this.Close();
                            }
                        }
                        catch (Exception ex)
                        {
                            ProgressUIManager.CloseProgress();
                            btnSubmitRequest.Enabled = true;
                            Message.showError(ex.Message);
                        }

                    }
                }
                //}
                //else
                //{
                //    //Message.showError("Validation Failed!\n\nPlease check all input fields and try again.");
                //}

                btnSubmitRequest.Enabled = true;
                _gui.RefreshOwnerForm();
            }
            else
            {
                Message.showError("Valiation Failed!\n\nPlease check all fields and try again.");
                this.Update();
                this.Refresh();
                _gui.IsAllControlValidated();
            }
            _gui.RefreshOwnerForm();
            _gui.IsAllControlValidated();
        }

        private Remittance fillRemittance()
        {
            ExchangeHouse exHouse = new ExchangeHouse();
            exHouse.id = (long)cmbCompanyName.SelectedValue;
            _remittance.exchangeHouse = exHouse;
            _remittance.pinCode = txtSecurityCodePINCode.Text;
            _remittance.expectedAmount = decimal.Parse(txtExpectedAmount.Text);
            _remittance.senderName = txtName.Text;

            if (cmbSenderCountry.SelectedValue != null)
            {
                Country senderCountry = new Country();
                senderCountry.id = (long)cmbSenderCountry.SelectedValue;
                _remittance.senderCountry = senderCountry;
            }
            //cmbCountry.SelectedValue = remittance.benificaryAddress.country.id;

            _remittance.senderPurpose = txtPurpose.Text;
            _remittance.benificaryName = txtNameBen.Text;
            _remittance.benificaryMobileNumber = txtMobileNo.Text;
            _remittance.benificaryFatherName = txtFathersName.Text;
            _remittance.benificaryMotherName = txtMothersName.Text;

            Address address = new Address();
            address.addressLineOne = txtAddressLineOne.Text;
            address.addressLineTwo = txtAddressLineTwo.Text;

            if (cmbDivision.SelectedValue != null)
            {
                Division division = new Division();
                division.id = (int)cmbDivision.SelectedValue;
                address.division = division;
            }

            if (cmbDistrict.SelectedValue != null)
            {
                District district = new District();
                district.id = (int)cmbDistrict.SelectedValue;
                address.district = district;
            }

            if (cmbThana.SelectedValue != null)
            {
                Thana thana = new Thana();
                thana.id = (int)cmbThana.SelectedValue;
                address.thana = thana;
            }

            if (cmbPostalCode.SelectedValue != null)
            {
                PostalCode postalCode = new PostalCode();
                postalCode.id = (long)cmbPostalCode.SelectedValue;
                address.postalCode = postalCode;
            }

            if (cmbCountry.SelectedValue != null)
            {
                Country country = new Country();
                country.id = (long)cmbCountry.SelectedValue;
                address.country = country;
            }

            _remittance.benificaryAddress = address;
            //remittance.entryUserDateTime = DateTime.un
            _remittance.entryUser = SessionInfo.username;
            _remittance.entryUserDateTime = UtilityServices.GetLongDate(SessionInfo.currentDate).ToString();

            return _remittance;
        }

        private void loadRemittance()
        {
            cmbCompanyName.SelectedValue = _remittance.exchangeHouse.id;
            //txtRemittanceNoReferanceNo.Text = remittance.referanceNumber;
            txtSecurityCodePINCode.Text = _remittance.pinCode;
            txtExpectedAmount.Text = _remittance.expectedAmount.ToString();

            double decValue;
            if (double.TryParse(txtExpectedAmount.Text, out decValue))
            {
                txtExpectedAmount.Text = decValue.ToString("##,##,###.00", System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
            }

            lblExpectedAmountInWords.Text = _amountInWords.ToWords(txtExpectedAmount.Text.Replace(",", ""));
            txtCorrectedAmount.Text = _remittance.remittanceAmount.ToString();
            if (double.TryParse(txtCorrectedAmount.Text, out decValue))
            {
                txtCorrectedAmount.Text = decValue.ToString("##,##,###.00", System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
            }
            lblCorrectedAmountInWords.Text = _amountInWords.ToWords(txtCorrectedAmount.Text.Replace(",", ""));
            txtName.Text = _remittance.senderName;
            if (_remittance.senderCountry != null)
                cmbSenderCountry.SelectedValue = _remittance.senderCountry.id;
            txtPurpose.Text = _remittance.senderPurpose;
            txtNameBen.Text = _remittance.benificaryName;
            txtMobileNo.Text = _remittance.benificaryMobileNumber;
            txtFathersName.Text = _remittance.benificaryFatherName;
            txtMothersName.Text = _remittance.benificaryMotherName;
            txtAddressLineOne.Text = _remittance.benificaryAddress.addressLineOne;
            txtAddressLineTwo.Text = _remittance.benificaryAddress.addressLineTwo;

            //address cmb-box-es
            {
                long tmpId = 0;
                if (_remittance.benificaryAddress.division != null)
                {
                    List<Division> divisionsContact = LocalCache.GetDivisions();
                    BindingSource bsDivisionsContact = new BindingSource();
                    bsDivisionsContact.DataSource = divisionsContact;
                    UtilityServices.fillComboBox(cmbDivision, bsDivisionsContact, "name", "id");
                    cmbDivision.SelectedValue = _remittance.benificaryAddress.division.id;
                }
                if (_remittance.benificaryAddress.district != null)
                {
                    List<District> districtTmp = LocalCache.GetDistrictsByDivisionID(_remittance.benificaryAddress.division.id);
                    BindingSource bsDistrictContact = new BindingSource();
                    bsDistrictContact.DataSource = districtTmp;
                    UtilityServices.fillComboBox(cmbDistrict, bsDistrictContact, "title", "id");
                    cmbDistrict.SelectedValue = _remittance.benificaryAddress.district.id;
                }
                if (_remittance.benificaryAddress.thana != null)
                {
                    tmpId = _remittance.benificaryAddress.district.id;
                    List<Thana> thanaTmp = LocalCache.GetThanasByDistrictID(tmpId);
                    BindingSource bsThana = new BindingSource();
                    bsThana.DataSource = thanaTmp;
                    UtilityServices.fillComboBox(cmbThana, bsThana, "title", "id");
                    cmbThana.SelectedValue = _remittance.benificaryAddress.thana.id;
                }
                if (_remittance.benificaryAddress.postalCode != null)
                {
                    List<PostalCode> postalCodeTmp = LocalCache.GetPostalCodesByDistrictID(tmpId);
                    BindingSource bsPostalCodeTmp = new BindingSource();
                    bsPostalCodeTmp.DataSource = postalCodeTmp;
                    UtilityServices.fillComboBox(cmbPostalCode, bsPostalCodeTmp, "postalCode", "id");
                    cmbPostalCode.SelectedValue = _remittance.benificaryAddress.postalCode.id;
                }
                if (_remittance.benificaryAddress.country != null)
                {
                    List<Country> countryTmp = LocalCache.GetCountries();
                    BindingSource bsCountryTmp = new BindingSource();
                    bsCountryTmp.DataSource = countryTmp;
                    UtilityServices.fillComboBox(cmbCountry, bsCountryTmp, "name", "id");
                    cmbCountry.SelectedValue = _remittance.benificaryAddress.country.id;
                }
                if (_remittance.senderCountry != null)
                {
                    List<Country> countryTmp = LocalCache.GetCountries();
                    BindingSource bsCountryTmp = new BindingSource();
                    bsCountryTmp.DataSource = countryTmp;
                    UtilityServices.fillComboBox(cmbSenderCountry, bsCountryTmp, "name", "id");
                    cmbSenderCountry.SelectedValue = _remittance.senderCountry.id;
                }
            }

            btnDisburse.Enabled = false;
            btnDisburse.Visible = false;
            btnDownload.Enabled = false;
            btnDownload.Visible = false;
            btnSubmitRequest.Enabled = false;
            btnSubmitRequest.Visible = false;
            btnClear.Enabled = false;
            btnClear.Visible = false;

            if (SessionInfo.rights.Contains("REMITANCE_ENTRY"))
            {
                btnSubmitRequest.Enabled = true;
                btnSubmitRequest.Visible = true;
                btnClear.Enabled = true;
                btnClear.Visible = true;
                if (_remittance.remittanceStatus == RemittanceStatus.Approved)
                {
                    btnDisburse.Enabled = true;
                    btnDisburse.Visible = true;
                    btnDownload.Enabled = true;
                    btnDownload.Visible = true;
                    btnSubmitRequest.Enabled = false;
                    btnSubmitRequest.Visible = false;
                    btnClear.Enabled = false;
                    btnClear.Visible = false;
                }
                if (_remittance.remittanceStatus == RemittanceStatus.Corrected)
                {
                    btnSubmitRequest.Enabled = true;
                    btnSubmitRequest.Visible = true;
                    btnClear.Enabled = true;
                    btnClear.Visible = true;
                }
                else
                {
                    btnSubmitRequest.Enabled = false;
                    btnSubmitRequest.Visible = false;
                    btnClear.Enabled = false;
                    btnClear.Visible = false;
                }
            }
        }

        private void frmRemittanceAgentRequest_Load(object sender, EventArgs e)
        {
            //exchange house
            {
                List<ExchangeHouse> exchangeHouses = LocalCache.GetExchangeHouses();
                BindingSource bsExchangeHouse = new BindingSource();
                bsExchangeHouse.DataSource = exchangeHouses;
                UtilityServices.fillComboBox(cmbCompanyName, bsExchangeHouse, "companyName", "id");
            }

            if
                (
                    SessionInfo.userBasicInformation.userType == AgentUserType.Outlet
                    &&
                    string.IsNullOrEmpty(_remittance.referanceNumber)
                )
            {
                long tmpId = 0;
                //division
                {
                    List<Division> benDivisions = LocalCache.GetDivisions();
                    BindingSource bsBenDivisions = new BindingSource();
                    bsBenDivisions.DataSource = benDivisions;
                    UtilityServices.fillComboBox(cmbDivision, bsBenDivisions, "name", "id");
                    cmbDivision.SelectedValue = SessionInfo.userBasicInformation.division.id;
                }
                //district
                {
                    List<District> benDistrictTmp = LocalCache.GetDistrictsByDivisionID(((Division)cmbDivision.SelectedItem).id);
                    BindingSource bsBenDistrict = new BindingSource();
                    bsBenDistrict.DataSource = benDistrictTmp;
                    UtilityServices.fillComboBox(cmbDistrict, bsBenDistrict, "title", "id");
                    cmbDistrict.SelectedValue = SessionInfo.userBasicInformation.district.id;
                }

                //thana
                {
                    tmpId = ((District)cmbDistrict.SelectedItem).id;
                    List<Thana> ThanaTmp = LocalCache.GetThanasByDistrictID(tmpId);
                    BindingSource bsThana = new BindingSource();
                    bsThana.DataSource = ThanaTmp;
                    UtilityServices.fillComboBox(cmbThana, bsThana, "title", "id");
                    cmbThana.SelectedValue = SessionInfo.userBasicInformation.thana.id;
                }

                //postal Code
                {
                    List<PostalCode> PostalCodeTmp = LocalCache.GetPostalCodesByDistrictID(tmpId);
                    BindingSource bsPostalCodeTmp = new BindingSource();
                    bsPostalCodeTmp.DataSource = PostalCodeTmp;
                    UtilityServices.fillComboBox(cmbPostalCode, bsPostalCodeTmp, "postalCode", "id");
                    cmbPostalCode.SelectedValue = SessionInfo.userBasicInformation.postalCode.id;
                }

                //beneficiary-country
                {
                    List<Country> benCountryTmp = LocalCache.GetCountries();
                    BindingSource bsBenCountryTmp = new BindingSource();
                    bsBenCountryTmp.DataSource = benCountryTmp;
                    UtilityServices.fillComboBox(cmbCountry, bsBenCountryTmp, "name", "id");
                }
                //sender-country
                {
                    List<Country> senderCountryTmp = LocalCache.GetCountries();
                    BindingSource bsSenderCountryTmp = new BindingSource();
                    bsSenderCountryTmp.DataSource = senderCountryTmp;
                    UtilityServices.fillComboBox(cmbSenderCountry, bsSenderCountryTmp, "name", "id");
                }
            }

            cmbCountry.SelectedValue = (long)19; //Bangladesh
            cmbSenderCountry.SelectedItem = null;

            if (_IsFromAdmin)
            {
                loadRemittance();
            }

            if (_remittance.remittanceStatus == RemittanceStatus.Corrected)
            {
                lnkRemarks.Visible = !String.IsNullOrEmpty(_remittance.comments);
            }

            if (_remittance.remittanceStatus == RemittanceStatus.Approved)
            {
                btnDisburse.Visible = true;
                btnDownload.Visible = true;
            }
            cmbCompanyName.Focus();
        }

        private void fillExchangeHouseList(ref ComboBox cbxExHouse)
        {
            RemittanceCom remCom = new RemittanceCom();
            List<MISL.Ababil.Agent.Infrastructure.Models.domain.models.Remittance.ExchangeHouse> exHouses = remCom.getListofExchangeHouse();

            BindingSource bs = new BindingSource();
            bs.DataSource = exHouses;
            fillComboBox(cbxExHouse, bs, "companyName", "id");
        }

        private void fillExchangeHouseList(ref MetroComboBox cbxExHouse)
        {
            RemittanceCom remCom = new RemittanceCom();
            List<MISL.Ababil.Agent.Infrastructure.Models.domain.models.Remittance.ExchangeHouse> exHouses = remCom.getListofExchangeHouse();

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

        private void cmbDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (!cb.Focused)
            {
                return;
            }

            List<District> benDistrictTmp = LocalCache.GetDistrictsByDivisionID(((Division)cmbDivision.SelectedItem).id);
            BindingSource bsBenDistrict = new BindingSource();
            bsBenDistrict.DataSource = benDistrictTmp;
            UtilityServices.fillComboBox(cmbDistrict, bsBenDistrict, "title", "id");

            cmbThana.DataSource = null;
            cmbPostalCode.DataSource = null;
        }

        private void cmbDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (!cb.Focused)
            {
                return;
            }
            long tmpId = ((District)cmbDistrict.SelectedItem).id;
            List<Thana> ThanaTmp = LocalCache.GetThanasByDistrictID(tmpId);
            BindingSource bsThana = new BindingSource();
            bsThana.DataSource = ThanaTmp;
            UtilityServices.fillComboBox(cmbThana, bsThana, "title", "id");

            List<PostalCode> PostalCodeTmp = LocalCache.GetPostalCodesByDistrictID(tmpId);
            BindingSource bsPostalCodeTmp = new BindingSource();
            bsPostalCodeTmp.DataSource = PostalCodeTmp;
            UtilityServices.fillComboBox(cmbPostalCode, bsPostalCodeTmp, "postalCode", "id");

            cmbThana.SelectedIndex = -1;
            cmbPostalCode.SelectedIndex = -1;
        }

        public void changeControlsReadOnly(bool readOnly)
        {
            cmbCompanyName.Enabled = !readOnly;
            cmbCountry.Enabled = !readOnly;
            cmbDistrict.Enabled = !readOnly;
            cmbDivision.Enabled = !readOnly;
            cmbPostalCode.Enabled = !readOnly;
            cmbSenderCountry.Enabled = !readOnly;
            cmbThana.Enabled = !readOnly;

            txtAddressLineOne.ReadOnly = readOnly;
            txtAddressLineTwo.ReadOnly = readOnly;
            //txtDocumentIdentificationNo.ReadOnly = readOnly;
            txtExpectedAmount.ReadOnly = readOnly;
            txtFathersName.ReadOnly = readOnly;
            //txtIssuePlace.ReadOnly = readOnly;
            txtMobileNo.ReadOnly = readOnly;
            txtMothersName.ReadOnly = readOnly;
            txtName.ReadOnly = readOnly;
            txtNameBen.ReadOnly = readOnly;
            txtPurpose.ReadOnly = readOnly;
            txtSecurityCodePINCode.ReadOnly = readOnly;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_IsFromAdmin == false)
            {
                if (_IsDocFirstRun == true)
                {
                    frmDocument frm = new frmDocument();
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        if (frm.retrnMsg != "")
                        {
                            _remittance.documentId = long.Parse(frm.retrnMsg);
                            _IsDocFirstRun = false;
                        }
                    }
                    _gui.RefreshOwnerForm();
                }
                else
                {
                    frmDocument frm = new frmDocument((Int32)_remittance.documentId, ActionType.update);
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        _remittance.documentId = long.Parse(frm.retrnMsg);
                    }
                    _gui.RefreshOwnerForm();
                }
            }
            else
            {
                if (_remittance.remittanceStatus != RemittanceStatus.Corrected)
                {
                    frmDocument frm = new frmDocument((Int32)_remittance.documentId, ActionType.view);
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        //remittance.documentId = long.Parse(frm.retrnMsg);
                    }
                    _gui.RefreshOwnerForm();
                }
                else
                {
                    frmDocument frm = new frmDocument((Int32)_remittance.documentId, ActionType.update);
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        //remittance.documentId = long.Parse(frm.retrnMsg);
                    }
                    _gui.RefreshOwnerForm();
                }
            }
        }

        //set by GUI Class
        private void txtExpectedAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsNumber(e.KeyChar) && (Keys)e.KeyChar != Keys.Back && e.KeyChar != '.')
            //{
            //    e.Handled = true;
            //}
            //base.OnKeyPress(e);
        }

        private void txtExpectedAmount_Leave(object sender, EventArgs e)
        {
            double decValue;
            if (double.TryParse(txtExpectedAmount.Text, out decValue))
            {
                txtExpectedAmount.Text = decValue.ToString("##,##,##,###.00", System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
            }
        }

        private void btnDisburse_Click(object sender, EventArgs e)
        {
            this.UseWaitCursor = true;

            string result = Message.showConfirmation("Do you want to disburse?");
            if (result == "yes")
            {
                bio.CaptureFingerData();
            }

            this.Enabled = true;
            this.UseWaitCursor = false;
            _gui.RefreshOwnerForm();
        }

        private void frmRemittanceAgentRequest_FormClosing(object sender, FormClosingEventArgs e)
        {
            ValidationManager.ReleaseValidationData(this);
            this.Owner = null;
        }

        private void bio_OnCapture(object sender, EventArgs e)
        {
            AxBIOPLUGINACTXLib.AxBioPlugInActX x = (AxBIOPLUGINACTXLib.AxBioPlugInActX)sender;

            if (x.result == "0")
            {
                _subAgentFingerData = bio.GetSafeLeftFingerData();
                if (_subAgentFingerData != null)
                {
                    _remittance.remittanceStatus = RemittanceStatus.Disbursed;
                    RemittanceDisburseRequest remittanceDisburseRequest = new RemittanceDisburseRequest();
                    remittanceDisburseRequest.agentFingerData = _subAgentFingerData;
                    remittanceDisburseRequest.remittance = _remittance;
                    try
                    {
                        RemittanceServices remittanceServices = new RemittanceServices();
                        ProgressUIManager.ShowProgress(this);
                        string responseString = remittanceServices.disburseRemittance(remittanceDisburseRequest);
                        ProgressUIManager.CloseProgress();
                        if (responseString != "")
                        {
                            Message.showInformation("Remittance disbursed successfully. with voucher no: " + responseString);
                            MISL.Ababil.Agent.Report.frmShowReport objFrmReport = new MISL.Ababil.Agent.Report.frmShowReport();
                            objFrmReport.ShowRemittanceReport(responseString);

                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        ProgressUIManager.CloseProgress();
                        btnDisburse.Enabled = true;
                        Message.showError(ex.Message);
                    }
                }
                else
                {
                    Message.showWarning("Subagent finger print needed.");
                }
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            frmDocument frm = new frmDocument((Int32)_remittance.bankdocumentId, ActionType.view);
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

            }
            _gui.RefreshOwnerForm();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            string result = Message.showConfirmation("Do you want to clear?");
            if (result == "yes")
            {
                clearAll();
                cmbCompanyName.Focus();
            }
            _gui.RefreshOwnerForm();
        }

        private void clearAll()
        {
            _IsFromAdmin = false;
            _IsDocFirstRun = true;
            _remittance = new Remittance();
            _subAgentFingerData = null;
            txtSecurityCodePINCode.Text = "";
            txtExpectedAmount.Text = "";
            txtNameBen.Text = "";
            txtFathersName.Text = "";
            txtMothersName.Text = "";
            txtMobileNo.Text = "";
            txtAddressLineOne.Text = "";
            txtAddressLineTwo.Text = "";

            txtName.Text = "";
            txtPurpose.Text = "";
            cmbDivision.SelectedItem = null;
            cmbDistrict.SelectedItem = null;
            cmbThana.SelectedItem = null;
            cmbPostalCode.SelectedItem = null;
            cmbCountry.SelectedValue = (long)19;
            cmbSenderCountry.SelectedItem = null;

            lblExpectedAmountInWords.Text = "";
            lblCorrectedAmountInWords.Text = "";

            _gui.RefreshOwnerForm();
        }

        private void txtMobileNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (Keys)e.KeyChar != Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtCorrectedAmount_TextChanged(object sender, EventArgs e)
        {
            AmountInWords amountInWords = new AmountInWords();
            lblCorrectedAmountInWords.Text = amountInWords.ToWords(txtCorrectedAmount.Text);
        }

        private void txtExpectedAmount_TextChanged(object sender, EventArgs e)
        {
            double decValue;
            string str = "";
            if (double.TryParse(txtExpectedAmount.Text, out decValue))
            {
                str = decValue.ToString("##,##,###.00", System.Globalization.CultureInfo.CurrentCulture.NumberFormat);
            }
            lblExpectedAmountInWords.Text = _amountInWords.ToWords(str.Replace(",", ""));
        }

        private void Invisible_OnEnabledChanged(object sender, EventArgs e)
        {
            ((Control)sender).Visible = ((Control)sender).Enabled;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Message.showInformation(_remittance.comments);
            _gui.RefreshOwnerForm();
        }

        private void frmRemittanceAgentRequest_Deactivate(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
        }
    }
}