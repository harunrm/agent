using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.cis;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.documentMgt;
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
using MISL.Ababil.Agent.LocalStorageService;
using MISL.Ababil.Agent.Communication;
using System.Globalization;
using MISL.Ababil.Agent.Module.Common.UI.MessageUI;
using MISL.Ababil.Agent.Module.Common.UI.DocumentUI;

namespace MISL.Ababil.Agent.Module.Common.UI.IndividualInformationUI
{
    public partial class frmIndividualInformation : Form
    {
        private Packet _receivePacket;
        private GUI _gui = new GUI();
        long? _docId = null;

        List<Country> _countries;
        List<Division> _divisions;
        List<District> _cdistricts;
        List<Thana> _cthanas;
        List<PostalCode> _cpostalCodes;
        List<District> _pdistricts;
        List<Thana> _pthanas;
        List<PostalCode> _ppostalCodes;
        List<Occupation> _occupations;

        IndividualInformation _individualInformation = new IndividualInformation();
        IndividualServices _individualServices = new IndividualServices();
        UtilityCom _utilityCom = new UtilityCom();
        private List<District> _districts;
        private List<Thana> _thanas;
        private List<Occupation> _postalCodes;
        private Dictionary<string, Address> _addresses;

        public frmIndividualInformation(Packet packet, IndividualInformation individualInformation)
        {
            InitializeComponent();
            _receivePacket = packet;
            _individualInformation = individualInformation;

            preparedUI();


            FillComponentWithObjectValue();


            //if (packet.DeveloperMode)
            //{
            //    GUI.DeveloperMode.EnableDeveloperMode(this);
            //}
        }
        //public frmIndividualInformation(Packet packet, IndividualInformation individualInformation, ref Dictionary<string, Address> addresses)
        //{
        //    InitializeComponent();
        //    _receivePacket = packet;
        //    _individualInformation = individualInformation;
        //    //_addresses = addresses;

        //    preparedUI();


        //    FillComponentWithObjectValue();

        //    //SetupAddresses();

        //    //if (packet.DeveloperMode)
        //    //{
        //    //    GUI.DeveloperMode.EnableDeveloperMode(this);
        //    //}
        //}

        //private void SetupAddresses()
        //{
        //    AddressCopyClear();

        //    if (_addresses.Count > 0)
        //    {
        //        for (int i = 0; i < _addresses.Count; i++)
        //        {
        //            AddressCopyAdd(_addresses.Keys.ElementAt(i), _addresses.Keys.ElementAt(i).Replace("_", " "));
        //        }
        //    }
        //}

        //private void AddressCopyClear()
        //{
        //    cmbContactAddressCopy.Items.Clear();
        //    cmbPermaAddressCopy.Items.Clear();
        //}

        //private void AddressCopyAdd(string key, string displayText)
        //{
        //    ComboboxItem comboboxItem = new ComboboxItem();
        //    comboboxItem.Value = key;
        //    comboboxItem.Text = displayText;

        //    cmbContactAddressCopy.Items.Add(comboboxItem);
        //    cmbPermaAddressCopy.Items.Add(comboboxItem);
        //}

        private void preparedUI()
        {
            SetupComponents();
            SetupDataLoad();
        }

        private void SetupDataLoad()
        {
            _countries = LocalCache.GetCountries();

            BindingSource bsCountry = new BindingSource();
            bsCountry.DataSource = _countries;

            _divisions = LocalCache.GetDivisions();

            BindingSource bsDivisionContact = new BindingSource();
            bsDivisionContact.DataSource = _divisions;

            BindingSource bsDivisionPermanent = new BindingSource();
            bsDivisionPermanent.DataSource = _divisions;

            //_districts = new List<District>();
            _districts = LocalCache.GetDistricts();
            //for (int i = 0; i < _divisions.Count; i++)
            //{
            //    _districts.AddRange(LocalCache.GetDistrictsByDivisionID(_divisions[i].id));
            //}

            BindingSource bsDistrict = new BindingSource();
            bsDistrict.DataSource = _districts;

            _occupations = LocalCache.GetOccupations();

            BindingSource bsOccupation = new BindingSource();
            bsOccupation.DataSource = _occupations;

            cmbGender.DataSource = Enum.GetValues(typeof(Gender));
            cmbMaritalStatus.DataSource = Enum.GetValues(typeof(MaritalStatus));

            UtilityServices.fillComboBox(cmbBirthPlace, bsDistrict, "title", "id");
            cmbBirthPlace.SelectedIndex = -1;

            //UtilityServices.fillComboBox(cmbBirthCountry, bsCountry, "name", "id");
            UtilityServices.fillComboBox(cmbOccupation, bsOccupation, "name", "id");
            UtilityServices.fillComboBox(cmbContactDivision, bsDivisionContact, "name", "id");
            UtilityServices.fillComboBox(cmbPermanentDivision, bsDivisionPermanent, "name", "id");
            cmbContactDivision.SelectedIndex = -1;
            cmbPermanentDivision.SelectedIndex = -1;

            UtilityServices.fillCountries(ref cmbBirthCountry);
            UtilityServices.fillOccupation(ref cmbOccupation);

            UtilityServices.fillComboBox(cmbContactCountryCode, bsCountry, "name", "id");
            UtilityServices.fillComboBox(cmbPermanentCountryCode, bsCountry, "name", "id");

            cmbBirthCountry.SelectedValue = CommonRules.countryId;
            cmbContactCountryCode.SelectedValue = CommonRules.countryId;
            cmbPermanentCountryCode.SelectedValue = CommonRules.countryId;

            if
                (
                    (
                        _receivePacket.actionType == FormActionType.New
                        ||
                        _receivePacket.actionType == FormActionType.Edit
                    )
                    &&
                    SessionInfo.userBasicInformation.userType == AgentUserType.Outlet
                )
            {

                //contact
                if (_individualInformation == null || _individualInformation.presentAddress == null)
                {
                    if (SessionInfo.userBasicInformation != null)
                    {
                        List<Division> divisionsContact = LocalCache.GetDivisions();
                        BindingSource bsDivisionsContact = new BindingSource();
                        bsDivisionsContact.DataSource = divisionsContact;
                        UtilityServices.fillComboBox(cmbContactDivision, bsDivisionsContact, "name", "id");

                        if (SessionInfo.userBasicInformation.division != null)
                        {
                            cmbContactDivision.SelectedValue = SessionInfo.userBasicInformation.division.id;

                            List<District> DistrictTmpContact = LocalCache.GetDistrictsByDivisionID(SessionInfo.userBasicInformation.division.id);
                            BindingSource bsDistrictContact = new BindingSource();
                            bsDistrictContact.DataSource = DistrictTmpContact;
                            UtilityServices.fillComboBox(cmbContactDistrict, bsDistrictContact, "title", "id");
                            cmbContactDistrict.SelectedValue = SessionInfo.userBasicInformation.district.id;
                        }

                        if (SessionInfo.userBasicInformation.district != null)
                        {
                            long tmpIdContact = SessionInfo.userBasicInformation.district.id;
                            List<Thana> ThanaTmpContact = LocalCache.GetThanasByDistrictID(tmpIdContact);
                            BindingSource bsThanaContact = new BindingSource();
                            bsThanaContact.DataSource = ThanaTmpContact;
                            UtilityServices.fillComboBox(cmbContactThana, bsThanaContact, "title", "id");
                            cmbContactThana.SelectedValue = SessionInfo.userBasicInformation.thana.id;

                            List<PostalCode> PostalCodeTmpContact = LocalCache.GetPostalCodesByDistrictID(tmpIdContact);
                            BindingSource bsPostalCodeTmpContact = new BindingSource();
                            bsPostalCodeTmpContact.DataSource = PostalCodeTmpContact;
                            UtilityServices.fillComboBox(cmbContactPostCode, bsPostalCodeTmpContact, "postalCode", "id");
                            cmbContactPostCode.SelectedValue = SessionInfo.userBasicInformation.postalCode.id;
                        }
                    }
                }
                //cmbContactCountryCode.SelectedValue = SessionInfo.userBasicInformation.country.id;                


                //per
                if (_individualInformation == null || _individualInformation.permanentAddress == null)
                {
                    if (SessionInfo.userBasicInformation != null)
                    {
                        List<Division> divisionsPermanent = LocalCache.GetDivisions();
                        BindingSource bsDivisionsPermanent = new BindingSource();
                        bsDivisionsPermanent.DataSource = divisionsPermanent;
                        UtilityServices.fillComboBox(cmbPermanentDivision, bsDivisionsPermanent, "name", "id");
                        if (SessionInfo.userBasicInformation.division != null)
                        {
                            cmbPermanentDivision.SelectedValue = SessionInfo.userBasicInformation.division.id;

                            List<District> DistrictTmpPermanent = LocalCache.GetDistrictsByDivisionID(SessionInfo.userBasicInformation.division.id);
                            BindingSource bsDistrictPermanent = new BindingSource();
                            bsDistrictPermanent.DataSource = DistrictTmpPermanent;
                            UtilityServices.fillComboBox(cmbPermanentDistrict, bsDistrictPermanent, "title", "id");
                            cmbPermanentDistrict.SelectedValue = SessionInfo.userBasicInformation.district.id;
                        }

                        if (SessionInfo.userBasicInformation.district != null)
                        {
                            long tmpIdPermanent = SessionInfo.userBasicInformation.district.id;
                            List<Thana> ThanaTmpPermanent = LocalCache.GetThanasByDistrictID(tmpIdPermanent);
                            BindingSource bsThanaPermanent = new BindingSource();
                            bsThanaPermanent.DataSource = ThanaTmpPermanent;
                            UtilityServices.fillComboBox(cmbPermanentThana, bsThanaPermanent, "title", "id");
                            cmbPermanentThana.SelectedValue = SessionInfo.userBasicInformation.thana.id;

                            List<PostalCode> PostalCodeTmpPermanent = LocalCache.GetPostalCodesByDistrictID(tmpIdPermanent);
                            BindingSource bsPostalCodeTmpPermanent = new BindingSource();
                            bsPostalCodeTmpPermanent.DataSource = PostalCodeTmpPermanent;
                            UtilityServices.fillComboBox(cmbPermanentPostalCode, bsPostalCodeTmpPermanent, "postalCode", "id");
                            cmbPermanentPostalCode.SelectedValue = SessionInfo.userBasicInformation.postalCode.id;
                        }
                    }
                }

                //cmbPermanentCountryCode.SelectedValue = SessionInfo.userBasicInformation.country.id;                
            }

            if (_receivePacket.actionType == FormActionType.View)
            {
                _gui.SetControlState(GUI.CONTROLSTATES.CS_READONLY, new Control[]
                {
                    txtContactAddress1,
                    txtContactAddress2,
                    txtEmail,
                    txtFatherLastName,
                    txtFathersFirstName,
                    txtFax,
                    txtFirstName,
                    txtLastName,
                    txtMobileNo,
                    txtMotherLastName,
                    txtMothersFirstName,
                    txtPermanentAddress1,
                    txtPermanentAddress2,
                    txtSpouseName,
                    txtTelephoneNo,
                });
                _gui.SetControlState(GUI.CONTROLSTATES.CS_DISABLE, new Control[]
                {
                    cmbBirthCountry,
                    cmbBirthPlace,
                    cmbContactAddressCopy,
                    cmbContactCountryCode,
                    cmbContactDistrict,
                    cmbContactDivision,
                    cmbContactPostCode,
                    cmbContactThana,
                    cmbGender,
                    cmbMaritalStatus,
                    cmbOccupation,
                    cmbPermaAddressCopy,
                    cmbPermanentCountryCode,
                    cmbPermanentDistrict,
                    cmbPermanentDivision,
                    cmbPermanentPostalCode,
                    cmbPermanentThana
                });
                _gui.SetControlState(GUI.CONTROLSTATES.CS_HIDDEN, new Control[]
                {
                    btnClear,
                    btnSave
                });
                _gui.SetControlState(GUI.CONTROLSTATES.CS_DISABLE, new Control[]
                {
                    chkUseAsPermanent,
                    dtpDOB
                });
            }
        }

        public void SetupComponents()
        {
            _gui = new GUI(this);
            //gui.Config(ref txtOutletName);

            txtMobileNo.MaxLength = 11;

            if (_receivePacket.intentType == IntentType.Request)
            {
                btnSave.Text = "Done";
            }
            else
            {
                btnSave.Text = "Save";
            }

            if (_receivePacket.actionType == FormActionType.View)
            {
                _gui.SetControlState(GUI.CONTROLSTATES.CS_DISABLE, new Control[] { txtFirstName, txtLastName, txtFathersFirstName, txtFatherLastName, txtMothersFirstName, txtMotherLastName, cmbGender, cmbMaritalStatus, txtSpouseName, mtbDOB, cmbBirthPlace, cmbOccupation, txtTelephoneNo, txtMobileNo, txtFax, txtEmail, cmbContactAddressCopy, txtContactAddress1, txtContactAddress2, cmbContactDivision, cmbContactDistrict, cmbContactThana, cmbContactPostCode, cmbPermaAddressCopy, txtPermanentAddress1, txtPermanentAddress2, cmbPermanentDivision, cmbPermanentDistrict, cmbPermanentThana, cmbPermanentPostalCode });
            }
        }

        private void FillComponentWithObjectValue()
        {
            if (_individualInformation == null)
            {
                _individualInformation = new IndividualInformation();

                _individualInformation.presentAddress = new Address();
                _individualInformation.presentAddress.division = new Division();
                _individualInformation.presentAddress.district = new District();
                _individualInformation.presentAddress.thana = new Thana();
                _individualInformation.presentAddress.postalCode = new PostalCode();

                _individualInformation.permanentAddress = new Address();
                _individualInformation.permanentAddress.division = new Division();
                _individualInformation.permanentAddress.district = new District();
                _individualInformation.permanentAddress.thana = new Thana();
                _individualInformation.permanentAddress.postalCode = new PostalCode();
            }
            else
            {
                try
                {


                    txtFirstName.Text = _individualInformation.firstName;
                    txtLastName.Text = _individualInformation.lastName;
                    txtFathersFirstName.Text = _individualInformation.fatherFirstName;
                    txtFatherLastName.Text = _individualInformation.fatherLastName;
                    txtMothersFirstName.Text = _individualInformation.motherFirstName;
                    txtMotherLastName.Text = _individualInformation.motherLastName;
                    txtSpouseName.Text = _individualInformation.spouseName;
                    txtMobileNo.Text = _individualInformation.mobileNo;
                    txtFax.Text = _individualInformation.fax;
                    txtEmail.Text = _individualInformation.email;
                    cmbGender.SelectedItem = _individualInformation.gender;
                    if (_individualInformation.birthPalce != null)
                    {
                        cmbBirthPlace.SelectedValue = _individualInformation.birthPalce.id;
                    }
                    else
                    {
                        cmbBirthPlace.SelectedValue = -1;
                    }
                    if (_individualInformation.occupation != null)
                    {
                        cmbOccupation.SelectedValue = _individualInformation.occupation.id;
                    }
                    else
                    {
                        cmbOccupation.SelectedIndex = -1;
                    }

                    _docId = _individualInformation.documentInfoId;

                    if (_individualInformation.dateOfBirthSt != null)
                    {
                        try
                        {
                            dtpDOB.Value = DateTime.ParseExact(_individualInformation.dateOfBirthSt.Substring(0, 10), "dd-MM-yyyy", CultureInfo.InvariantCulture);
                        }
                        catch { }
                    }
                    cmbMaritalStatus.SelectedItem = _individualInformation.maritalStatus;

                    if (_individualInformation.presentAddress != null)
                    {
                        txtContactAddress1.Text = _individualInformation.presentAddress.addressLineOne;
                        txtContactAddress2.Text = _individualInformation.presentAddress.addressLineTwo;
                    }

                    if (_individualInformation.permanentAddress != null)
                    {
                        txtPermanentAddress1.Text = _individualInformation.permanentAddress.addressLineOne;
                        txtPermanentAddress2.Text = _individualInformation.permanentAddress.addressLineTwo;
                    }



                    //=====================================================//




                    if (_individualInformation.presentAddress != null)
                    {
                        if (_individualInformation.presentAddress.division.id > 0)
                        {
                            List<Division> divisionsContact = LocalCache.GetDivisions();
                            BindingSource bsDivisionsContact = new BindingSource();
                            bsDivisionsContact.DataSource = divisionsContact;
                            UtilityServices.fillComboBox(cmbContactDivision, bsDivisionsContact, "name", "id");
                            cmbContactDivision.SelectedIndex = -1;
                            cmbContactDivision.SelectedValue = _individualInformation.presentAddress.division.id;
                        }

                        else
                        {
                            return;
                        }


                        List<District> DistrictTmpContact = LocalCache.GetDistrictsByDivisionID(_individualInformation.presentAddress.division.id);
                        BindingSource bsDistrictContact = new BindingSource();
                        bsDistrictContact.DataSource = DistrictTmpContact;
                        UtilityServices.fillComboBox(cmbContactDistrict, bsDistrictContact, "title", "id");
                        if (_individualInformation.presentAddress.district.id > 0)
                        {
                            long tmpIdContact = _individualInformation.presentAddress.district.id;
                            List<Thana> ThanaTmpContact = LocalCache.GetThanasByDistrictID(tmpIdContact);
                            BindingSource bsThanaContact = new BindingSource();
                            bsThanaContact.DataSource = ThanaTmpContact;
                            UtilityServices.fillComboBox(cmbContactThana, bsThanaContact, "title", "id");

                            List<PostalCode> PostalCodeTmpContact = LocalCache.GetPostalCodesByDistrictID(tmpIdContact);
                            BindingSource bsPostalCodeTmpContact = new BindingSource();
                            bsPostalCodeTmpContact.DataSource = PostalCodeTmpContact;
                            UtilityServices.fillComboBox(cmbContactPostCode, bsPostalCodeTmpContact, "postalCode", "id");
                        }

                        if (_individualInformation.presentAddress != null)
                        {
                            txtContactAddress1.Text = _individualInformation.presentAddress.addressLineOne;
                            txtContactAddress2.Text = _individualInformation.presentAddress.addressLineTwo;
                        }

                        if (_individualInformation.presentAddress.district != null)
                        {
                            cmbContactDistrict.SelectedValue = _individualInformation.presentAddress.district.id;
                        }
                        if (_individualInformation.presentAddress.thana != null)
                        {
                            cmbContactThana.SelectedValue = _individualInformation.presentAddress.thana.id;
                        }
                        if (_individualInformation.presentAddress.postalCode != null)
                        {
                            cmbContactPostCode.SelectedValue = _individualInformation.presentAddress.postalCode.id;
                        }
                        if (_individualInformation.presentAddress.country != null)
                        {
                            cmbContactCountryCode.SelectedItem = _individualInformation.presentAddress.country;
                        }

                        //_individualInformation.presentAddress.country = _countries[cmbContactCountryCode.SelectedIndex];
                    }
                    else
                    {
                        return;
                    }


                    if (_individualInformation.permanentAddress == null)
                    {
                        _individualInformation.permanentAddress = new Address();
                        cmbPermanentDivision.SelectedIndex = -1;
                    }
                    else
                    {
                        List<Division> divisionsPermanent = LocalCache.GetDivisions();
                        BindingSource bsDivisionsPermanent = new BindingSource();
                        bsDivisionsPermanent.DataSource = divisionsPermanent;
                        UtilityServices.fillComboBox(cmbPermanentDivision, bsDivisionsPermanent, "name", "id");
                        cmbPermanentDivision.SelectedIndex = -1;
                        if (_individualInformation.permanentAddress.division != null)
                        {
                            cmbPermanentDivision.SelectedValue = _individualInformation.permanentAddress.division.id;
                        }
                        else
                        {
                            return;
                        }

                        List<District> DistrictTmpPermanent = LocalCache.GetDistrictsByDivisionID(_individualInformation.permanentAddress.division.id);
                        BindingSource bsDistrictPermanent = new BindingSource();
                        bsDistrictPermanent.DataSource = DistrictTmpPermanent;
                        UtilityServices.fillComboBox(cmbPermanentDistrict, bsDistrictPermanent, "title", "id");

                        long tmpIdPermanent = _individualInformation.permanentAddress.district.id;
                        List<Thana> ThanaTmpPermanent = LocalCache.GetThanasByDistrictID(tmpIdPermanent);
                        BindingSource bsThanaPermanent = new BindingSource();
                        bsThanaPermanent.DataSource = ThanaTmpPermanent;
                        UtilityServices.fillComboBox(cmbPermanentThana, bsThanaPermanent, "title", "id");

                        List<PostalCode> PostalCodeTmpPermanent = LocalCache.GetPostalCodesByDistrictID(tmpIdPermanent);
                        BindingSource bsPostalCodeTmpPermanent = new BindingSource();
                        bsPostalCodeTmpPermanent.DataSource = PostalCodeTmpPermanent;
                        UtilityServices.fillComboBox(cmbPermanentPostalCode, bsPostalCodeTmpPermanent, "postalCode", "id");

                        txtPermanentAddress1.Text = _individualInformation.permanentAddress.addressLineOne;
                        txtPermanentAddress2.Text = _individualInformation.permanentAddress.addressLineTwo;
                        if (_individualInformation.permanentAddress.district != null)
                        {
                            cmbPermanentDistrict.SelectedValue = _individualInformation.permanentAddress.district.id;
                        }
                        if (_individualInformation.permanentAddress.thana != null)
                        {
                            cmbPermanentThana.SelectedValue = _individualInformation.permanentAddress.thana.id;
                        }
                        if (_individualInformation.permanentAddress.postalCode != null)
                        {
                            cmbPermanentPostalCode.SelectedValue = _individualInformation.permanentAddress.postalCode.id;
                        }
                        if (_individualInformation.permanentAddress.country != null)
                        {
                            cmbPermanentCountryCode.SelectedItem = _individualInformation.permanentAddress.country;
                        }
                        //_individualInformation.presentAddress.country = _countries[cmbContactCountryCode.SelectedIndex];
                    }
                }
                catch (Exception ex)
                {
                    MsgBox.showError(ex.Message);
                }
            }
        }

        private void FillObjectWithComponentValue()
        {
            try
            {
                IndividualInformation individualInformationTmp = new IndividualInformation();
                if (_individualInformation != null)
                {
                    individualInformationTmp = _individualInformation;
                }

                _individualInformation = new IndividualInformation();

                _individualInformation.firstName = txtFirstName.Text;
                _individualInformation.lastName = txtLastName.Text;
                _individualInformation.fatherFirstName = txtFathersFirstName.Text;
                _individualInformation.fatherLastName = txtFatherLastName.Text;
                _individualInformation.motherFirstName = txtMothersFirstName.Text;
                _individualInformation.motherLastName = txtMotherLastName.Text;
                _individualInformation.spouseName = txtSpouseName.Text;
                _individualInformation.mobileNo = txtMobileNo.Text;
                _individualInformation.fax = txtFax.Text;
                _individualInformation.email = txtEmail.Text;
                _individualInformation.dateOfBirthSt = mtbDOB.Text;
                _individualInformation.birthCountry = (Country)cmbBirthCountry.SelectedItem;
                _individualInformation.documentInfoId = _docId;
                _individualInformation.gender = (Gender)cmbGender.SelectedItem;
                _individualInformation.birthPalce = ((District)cmbBirthPlace.SelectedItem);
                _individualInformation.occupation = ((Occupation)cmbOccupation.SelectedItem);
                _individualInformation.maritalStatus = (MaritalStatus)cmbMaritalStatus.SelectedItem;

                //pre
                {
                    if (_individualInformation.presentAddress == null)
                    {
                        _individualInformation.presentAddress = new Address();
                    }

                    if (individualInformationTmp.presentAddress != null)
                    {
                        _individualInformation.presentAddress.id = individualInformationTmp.presentAddress.id;
                    }

                    _individualInformation.presentAddress.addressLineOne = txtContactAddress1.Text;
                    _individualInformation.presentAddress.addressLineTwo = txtContactAddress2.Text;

                    _individualInformation.presentAddress.division = (Division)cmbContactDivision.SelectedItem;
                    _individualInformation.presentAddress.district = (District)cmbContactDistrict.SelectedItem;
                    _individualInformation.presentAddress.thana = (Thana)cmbContactThana.SelectedItem;
                    _individualInformation.presentAddress.postalCode = (PostalCode)cmbContactPostCode.SelectedItem;
                    _individualInformation.presentAddress.country = (Country)cmbContactCountryCode.SelectedItem;
                }

                //per
                {
                    if (_individualInformation.permanentAddress == null)
                    {
                        _individualInformation.permanentAddress = new Address();
                    }

                    if (individualInformationTmp.permanentAddress != null)
                    {
                        _individualInformation.permanentAddress.id = individualInformationTmp.permanentAddress.id;
                    }

                    _individualInformation.permanentAddress.addressLineOne = txtPermanentAddress1.Text;
                    _individualInformation.permanentAddress.addressLineTwo = txtPermanentAddress2.Text;

                    _individualInformation.permanentAddress.division = (Division)cmbPermanentDivision.SelectedItem;
                    _individualInformation.permanentAddress.district = (District)cmbPermanentDistrict.SelectedItem;
                    _individualInformation.permanentAddress.thana = (Thana)cmbPermanentThana.SelectedItem;
                    _individualInformation.permanentAddress.postalCode = (PostalCode)cmbPermanentPostalCode.SelectedItem;
                    _individualInformation.permanentAddress.country = (Country)cmbPermanentCountryCode.SelectedItem;
                }
            }
            catch (Exception ex)
            {
                MsgBox.showError(ex.Message);
            }
        }

        private bool validationCheck()
        {
            //if (_individualInformation.maritalStatus == MaritalStatus.Married && _individualInformation.spouseName == "")
            //{
            //    MsgBox.showWarning("Spouse name not found.");
            //    return false;
            //}
            try
            {
                string[] str = mtbDOB.Text.Split('-');
                DateTime d = new DateTime(int.Parse(str[2].Trim()), int.Parse(str[1].Trim()), int.Parse(str[0].Trim()));
                dtpDOB.Value = d;
            }
            catch
            {
                MsgBox.showError("Please enter the date in correct format.");
                //mtbDOB.Focus();
                //mtbDOB.SelectAll();
                return false;
            }
            //return ValidationManager.ValidateForm(this);
            if (_individualInformation.firstName == "")
            {
                MsgBox.showWarning("Individual first name not found.");
                return false;
            }
            if (_individualInformation.lastName == "")
            {
                MsgBox.showWarning("Individual last name not found.");
                return false;
            }
            if (_individualInformation.fatherFirstName == "")
            {
                MsgBox.showWarning("Father first name not found.");
                return false;
            }
            if (_individualInformation.fatherLastName == "")
            {
                MsgBox.showWarning("Father last name not found.");
                return false;
            }
            if (_individualInformation.motherFirstName == "")
            {
                MsgBox.showWarning("Mother first name not found.");
                return false;
            }
            if (_individualInformation.motherLastName == "")
            {
                MsgBox.showWarning("Mother last name not found.");
                return false;
            }
            if (_individualInformation.gender.ToString() == "")
            {
                MsgBox.showWarning("Gender not found.");
                return false;
            }
            if (_individualInformation.maritalStatus.ToString() == "")
            {
                MsgBox.showWarning("Marital status not found.");
                return false;
            }
            if (_individualInformation.maritalStatus == MaritalStatus.Married && _individualInformation.spouseName == "")
            {
                MsgBox.showWarning("Spouse name not found.");
                return false;
            }
            /*
            if (objIndividualInfo.dateOfBirth > DateTime.Now.ToUnixTime())
            {
                MessageBox.Show("Gender not found.");
                return false;
            }
            */
            if (_individualInformation.birthPalce == null)
            {
                MsgBox.showWarning("Birth place not found.");
                return false;
            }
            else if (_individualInformation.birthPalce.id == 0)
            {
                MsgBox.showWarning("Birth place not found.");
                return false;
            }
            if (_individualInformation.birthCountry == null)
            {
                MsgBox.showWarning("Birth country not found.");
                return false;
            }
            else if (_individualInformation.birthCountry.id == 0)
            {
                MsgBox.showWarning("Birth country not found.");
                return false;
            }
            if (_individualInformation.occupation == null)
            {
                MsgBox.showWarning("Occupation not found.");
                return false;
            }
            else if (_individualInformation.occupation.id == 0)
            {
                MsgBox.showWarning("Occupation not found.");
                return false;
            }

            if (_individualInformation.mobileNo == "")
            {
                MsgBox.showWarning("Mobile number not found.");
                return false;
            }

            if (_individualInformation.presentAddress == null)
            {
                MsgBox.showWarning("Present address not found.");
                return false;
            }
            else
            {
                if (txtContactAddress1.Text.Trim() == "" && txtContactAddress2.Text.Trim() == "")
                {
                    MsgBox.showWarning("Present address not found.");
                    return false;
                }
            }
            if (_individualInformation.permanentAddress == null)
            {
                MsgBox.showWarning("PermanentAddress address not found.");
                return false;
            }
            else
            {
                if (txtPermanentAddress1.Text.Trim() == "" && txtPermanentAddress2.Text.Trim() == "")
                {
                    MsgBox.showWarning("PermanentAddress address not found.");
                    return false;
                }
            }

            return true;
        }

        public IndividualInformation getFilledObject()
        {
            return _individualInformation;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FillObjectWithComponentValue();

            if (validationCheck())
            {
                //if (_receivePacket.intentType == IntentType.Request)
                {
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                MsgBox.showError("Validation failed!");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _gui.EmptyControls(new Control[] { txtFirstName, txtLastName, txtFathersFirstName, txtFatherLastName, txtMothersFirstName, txtMotherLastName, cmbGender, cmbMaritalStatus, txtSpouseName, mtbDOB, cmbBirthPlace, cmbOccupation, txtTelephoneNo, txtMobileNo, txtFax, txtEmail, cmbContactAddressCopy, txtContactAddress1, txtContactAddress2, cmbContactDivision, cmbContactDistrict, cmbContactThana, cmbContactPostCode, cmbPermaAddressCopy, txtPermanentAddress1, txtPermanentAddress2, cmbPermanentDivision, cmbPermanentDistrict, cmbPermanentThana, cmbPermanentPostalCode });
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //----------------------------------------------------------------------------------------------//
        //----------------------------------------------------------------------------------------------//


        private void cmbContactDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (!cb.Focused)
            {
                return;
            }

            List<District> DistrictTmpContact = LocalCache.GetDistrictsByDivisionID(((Division)cmbContactDivision.SelectedItem).id);
            //List<District> DistrictTmpContact = LocalCache.GetDistrictsByDivisionID(_individualInformation.presentAddress.division.id);
            BindingSource bsDistrictContact = new BindingSource();
            bsDistrictContact.DataSource = DistrictTmpContact;
            UtilityServices.fillComboBox(cmbContactDistrict, bsDistrictContact, "title", "id");

            cmbContactDistrict.SelectedIndex = -1;
            cmbContactThana.SelectedIndex = -1;
            cmbContactPostCode.SelectedIndex = -1;
        }

        private void cmbContactDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (!cb.Focused)
            {
                return;
            }

            long tmpIdContact = ((District)cmbContactDistrict.SelectedItem).id;
            //long tmpIdContact = _individualInformation.presentAddress.district.id;
            List<Thana> ThanaTmpContact = LocalCache.GetThanasByDistrictID(tmpIdContact);
            BindingSource bsThanaContact = new BindingSource();
            bsThanaContact.DataSource = ThanaTmpContact;
            UtilityServices.fillComboBox(cmbContactThana, bsThanaContact, "title", "id");

            List<PostalCode> PostalCodeTmpContact = LocalCache.GetPostalCodesByDistrictID(tmpIdContact);
            BindingSource bsPostalCodeTmpContact = new BindingSource();
            bsPostalCodeTmpContact.DataSource = PostalCodeTmpContact;
            UtilityServices.fillComboBox(cmbContactPostCode, bsPostalCodeTmpContact, "postalCode", "id");

            cmbContactThana.SelectedIndex = -1;
            cmbContactPostCode.SelectedIndex = -1;
        }

        //Permanent
        private void cmbPermanentDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (!cb.Focused)
            {
                return;
            }

            List<District> DistrictTmpPermanent = LocalCache.GetDistrictsByDivisionID(((Division)cmbPermanentDivision.SelectedItem).id);
            BindingSource bsDistrictPermanent = new BindingSource();
            bsDistrictPermanent.DataSource = DistrictTmpPermanent;
            UtilityServices.fillComboBox(cmbPermanentDistrict, bsDistrictPermanent, "title", "id");

            cmbPermanentDistrict.SelectedIndex = -1;
        }
        private void cmbPermanentDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (!cb.Focused)
            {
                return;
            }

            //long tmpIdPermanent = _individualInformation.permanentAddress.district.id;
            long tmpIdPermanent = ((District)cmbPermanentDistrict.SelectedItem).id;
            List<Thana> ThanaTmpPermanent = LocalCache.GetThanasByDistrictID(tmpIdPermanent);
            BindingSource bsThanaPermanent = new BindingSource();
            bsThanaPermanent.DataSource = ThanaTmpPermanent;
            UtilityServices.fillComboBox(cmbPermanentThana, bsThanaPermanent, "title", "id");

            List<PostalCode> PostalCodeTmpPermanent = LocalCache.GetPostalCodesByDistrictID(tmpIdPermanent);
            BindingSource bsPostalCodeTmpPermanent = new BindingSource();
            bsPostalCodeTmpPermanent.DataSource = PostalCodeTmpPermanent;
            UtilityServices.fillComboBox(cmbPermanentPostalCode, bsPostalCodeTmpPermanent, "postalCode", "id");

            cmbPermanentThana.SelectedIndex = -1;
            cmbPermanentPostalCode.SelectedIndex = -1;
        }

        private void chkUseAsPermanent_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseAsPermanent.Checked)
            {
                UtilityServices.copyAddress(txtContactAddress1, txtContactAddress2, cmbContactPostCode, cmbContactThana, cmbContactDistrict, cmbContactDivision, cmbContactCountryCode, ref txtPermanentAddress1, ref txtPermanentAddress2, ref cmbPermanentPostalCode, ref cmbPermanentThana, ref cmbPermanentDistrict, ref cmbPermanentDivision, ref cmbPermanentCountryCode);
            }
        }

        private void txtTelephoneNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (Keys)e.KeyChar != Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            base.OnKeyPress(e);
        }

        private void txtMobileNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (Keys)e.KeyChar != Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            base.OnKeyPress(e);
        }

        private void btnDocument_Click(object sender, EventArgs e)
        {
            ActionType actionType = new ActionType();

            switch (_receivePacket.actionType)
            {
                case FormActionType.New:
                    actionType = ActionType.update;
                    break;
                case FormActionType.Edit:
                    actionType = ActionType.update;
                    break;
                case FormActionType.View:
                    actionType = ActionType.view;
                    break;
                case FormActionType.Verify:
                    actionType = ActionType.view;
                    break;
                default:
                    break;
            }

            frmDocument doc = new frmDocument(Convert.ToInt32(_docId ?? 0), actionType);
            //frmDocument doc = new frmDocument(Convert.ToInt32(_docId ?? 0), ActionType.update);
            if (doc.ShowDialog() == DialogResult.OK)
            {
                string retVal = doc.getDocIdAfterSave();
                _docId = long.Parse(retVal != "" ? retVal : "0");
            }

            if (_individualInformation != null) //&& _individualInformation.documentInfoId != null
            {
                _individualInformation.documentInfoId = _docId;
            }
        }

        private void cmbPermaAddressCopy_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (!cb.Focused)
            {
                return;
            }
            chkUseAsPermanent.Checked = false;
            //Address addr = UtilityServices.commonAddresses.Single(o => o.commonAddressIndex == (int)(cmbPermaAddressCopy.SelectedValue));
            Address addr = _addresses[((ComboboxItem)cb.SelectedItem).Value];
            UtilityServices.setAddress(addr, ref txtPermanentAddress1, ref txtPermanentAddress2, ref cmbPermanentPostalCode, ref cmbPermanentThana, ref cmbPermanentDistrict, ref cmbPermanentDivision, ref cmbPermanentCountryCode);
        }

        private void cmbContactAddressCopy_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (!cb.Focused)
            {
                return;
            }
            //Address addr = UtilityServices.commonAddresses.Single(o => o.commonAddressIndex == (int)(cmbContactAddressCopy.SelectedValue));
            Address addr = _addresses[((ComboboxItem)cb.SelectedItem).Value];
            UtilityServices.setAddress(addr, ref txtContactAddress1, ref txtContactAddress2, ref cmbContactPostCode, ref cmbContactThana, ref cmbContactDistrict, ref cmbContactDivision, ref cmbContactCountryCode);
        }

        private void mtbDOB_KeyUp(object sender, KeyEventArgs e)
        {
            //suppressed to avoid mtb to dtp conversion
            try
            {
                string[] str = mtbDOB.Text.Split('-');
                DateTime d = new DateTime(int.Parse(str[2].Trim()), int.Parse(str[1].Trim()), int.Parse(str[0].Trim()));
                dtpDOB.Value = d;
            }
            catch (Exception ex) { }
        }

        private void dtpDOB_ValueChanged(object sender, EventArgs e)
        {
            mtbDOB.Text = dtpDOB.Value.ToString("dd-MM-yyyy");
        }

        private void cmbContactThana_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}