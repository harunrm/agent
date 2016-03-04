using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MISL.Ababil.Agent.Services;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.cis;
using System.Net;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.documentMgt;
using MISL.Ababil.Agent.Infrastructure.Validation;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models;
using MISL.Ababil.Agent.UI.forms.ProgressUI;
using MISL.Ababil.Agent.Communication;
using MISL.Ababil.Agent.LocalStorageService;
using MetroFramework.Forms;

namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmCustomer : MetroForm
    {
        private Packet _receivePacket;
        private GUI _gui = new GUI();

        List<Country> _countries;
        List<Division> _divisions;
        List<District> _cdistricts;
        List<Thana> _cthanas;
        List<PostalCode> _cpostalCodes;
        List<District> _bDistricts;
        List<Thana> _bThanas;
        List<PostalCode> _bPostalCodes;
        List<District> _pdistricts;
        List<Thana> _pthanas;
        List<PostalCode> _ppostalCodes;
        List<Occupation> _occupations;
        CustomerInformation _customerInformation = new CustomerInformation();
        IndividualInformation _individualInformation = new IndividualInformation();
        IndividualServices _individualServices = new IndividualServices();
        UtilityCom _utilityCom = new UtilityCom();

        CustomerInformation objCutomerInfo = new CustomerInformation();
        //List<OwnerInformation> objOwnerInfoList = new List<OwnerInformation>();
        List<SectorCodeInfo> publicSectorCodes = new List<SectorCodeInfo>();
        List<SectorCodeInfo> privateSectorCodes = new List<SectorCodeInfo>();

        private ActionType actionTypeForDocument;
        private long? _docId;
        long idForUpdate = 0;
        string _mobileNumber = "";
        private Dictionary<string, Address> _addresses;

        public frmCustomer(Packet packet, CustomerInformation customerInformaiton)
        {
            InitializeComponent();
            _receivePacket = packet;
            _customerInformation = customerInformaiton;
            preparedUI();

            FillComponentWithObjectValue();

            //if (packet.DeveloperMode)
            //{
            //    GUI.DeveloperMode.EnableDeveloperMode(this);
            //}
        }

        public frmCustomer(Packet packet, CustomerInformation customerInformaiton, ref Dictionary<string, Address> addresses)
        {
            InitializeComponent();
            _receivePacket = packet;
            _customerInformation = customerInformaiton;
            _addresses = addresses;

            preparedUI();

            FillComponentWithObjectValue();

            SetupAddresses();

            //if (packet.DeveloperMode)
            //{
            //    GUI.DeveloperMode.EnableDeveloperMode(this);
            //}
        }

        private void preparedUI()
        {
            SetupDataLoad();
            SetupComponents();

        }

        private void SetupAddresses()
        {
            AddressCopyClear();

            if (_addresses.Count > 0)
            {
                for (int i = 0; i < _addresses.Count; i++)
                {
                    AddressCopyAdd(_addresses.Keys.ElementAt(i), _addresses.Keys.ElementAt(i).Replace("_", " "));
                }
            }
        }

        private void AddressCopyClear()
        {
            cmbBusinessAddressCopy.Items.Clear();
            cmbPermanentAddressCopy.Items.Clear();
            cmbPresentAddressCopy.Items.Clear();
        }

        private void AddressCopyAdd(string key, string displayText)
        {
            ComboboxItem comboboxItem = new ComboboxItem();
            comboboxItem.Value = key;
            comboboxItem.Text = displayText;

            cmbBusinessAddressCopy.Items.Add(comboboxItem);
            cmbPermanentAddressCopy.Items.Add(comboboxItem);
            cmbPresentAddressCopy.Items.Add(comboboxItem);
        }

        private void SetupDataLoad()
        {
            _countries = LocalCache.GetCountries();
            _divisions = LocalCache.GetDivisions();
            _occupations = LocalCache.GetOccupations();

            BindingSource bsCountry = new BindingSource();
            bsCountry.DataSource = _countries;

            BindingSource bsDivisionBus = new BindingSource();
            bsDivisionBus.DataSource = _divisions;

            BindingSource bsDivisionPer = new BindingSource();
            bsDivisionPer.DataSource = _divisions;

            BindingSource bsDivisionPre = new BindingSource();
            bsDivisionPre.DataSource = _divisions;

            BindingSource bsOccupation = new BindingSource();
            bsOccupation.DataSource = _occupations;

            UtilityServices.fillComboBox(cmbCountryBus, bsCountry, "name", "id");
            UtilityServices.fillComboBox(cmbCountryPer, bsCountry, "name", "id");
            UtilityServices.fillComboBox(cmbCountryPre, bsCountry, "name", "id");

            cmbCountryBus.SelectedValue = CommonRules.countryId;
            cmbCountryPer.SelectedValue = CommonRules.countryId;
            cmbCountryPre.SelectedValue = CommonRules.countryId;

            try
            {
                UtilityServices.fillCustomerTypes(ref cmbCustomerType);
                cmbCustomerType.SelectedIndex = -1;

                cmbInstitutionType.Visible = false;
                lblInisType.Enabled = false;

                UtilityServices.fillComboBox(cmbDivitionBus, bsDivisionBus, "name", "id");
                cmbDivitionBus.SelectedIndex = -1;

                UtilityServices.fillComboBox(cmbDivitionPer, bsDivisionPer, "name", "id");
                cmbDivitionPer.SelectedIndex = -1;

                UtilityServices.fillComboBox(cmbDivitionPre, bsDivisionPre, "name", "id");
                cmbDivitionPre.SelectedIndex = -1;

                UtilityServices.fillInstitutionTypes(ref cmbInstitutionType);
                cmbInstitutionType.SelectedIndex = -1;

                cmbLocation.DataSource = Enum.GetValues(typeof(CisLocation));
                txtMolile.MaxLength = CommonRules.mobileNoLength;
                txtIndividualId.Enabled = false;
                btnNewIndividual.Enabled = false;
                btnAddSelectedIndividualAsOwner.Enabled = false;
                btnSearch.Enabled = false;

                //if (UtilityServices.commonAddresses != null)
                //{
                //    BindingSource bs = new BindingSource();
                //    bs.DataSource = UtilityServices.commonAddresses;
                //    UtilityServices.fillComboBox(cmbBusinessAddressCopy, bs, "commonAddressName", "commonAddressIndex");
                //    UtilityServices.fillComboBox(cmbPermanentAddressCopy, bs, "commonAddressName", "commonAddressIndex");
                //    UtilityServices.fillComboBox(cmbPresentAddressCopy, bs, "commonAddressName", "commonAddressIndex");
                //    cmbBusinessAddressCopy.Text = "Select";
                //    cmbPermanentAddressCopy.Text = "Select";
                //    cmbPresentAddressCopy.Text = "Select";
                //}

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
            FillSectorType();

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
                if (_customerInformation == null || _customerInformation.businessAddress == null)
                {
                    List<Division> divisionsBus = LocalCache.GetDivisions();
                    BindingSource bsDivisionsBus = new BindingSource();
                    bsDivisionsBus.DataSource = divisionsBus;
                    UtilityServices.fillComboBox(cmbDivitionBus, bsDivisionsBus, "name", "id");
                    cmbDivitionBus.SelectedValue = SessionInfo.userBasicInformation.division.id;

                    List<District> DistrictTmpBus = LocalCache.GetDistrictsByDivisionID(SessionInfo.userBasicInformation.division.id);
                    BindingSource bsDistrictBus = new BindingSource();
                    bsDistrictBus.DataSource = DistrictTmpBus;
                    UtilityServices.fillComboBox(cmbDistrictBus, bsDistrictBus, "title", "id");

                    long tmpIdBus = SessionInfo.userBasicInformation.district.id;
                    List<Thana> ThanaTmpBus = LocalCache.GetThanasByDistrictID(tmpIdBus);
                    BindingSource bsThanaBus = new BindingSource();
                    bsThanaBus.DataSource = ThanaTmpBus;
                    UtilityServices.fillComboBox(cmbThanaBus, bsThanaBus, "title", "id");

                    List<PostalCode> PostalCodeTmpBus = LocalCache.GetPostalCodesByDistrictID(tmpIdBus);
                    BindingSource bsPostalCodeTmpBus = new BindingSource();
                    bsPostalCodeTmpBus.DataSource = PostalCodeTmpBus;
                    UtilityServices.fillComboBox(cmbPostCodeBus, bsPostalCodeTmpBus, "postalCode", "id");


                    cmbDistrictBus.SelectedValue = SessionInfo.userBasicInformation.district.id;
                    cmbThanaBus.SelectedValue = SessionInfo.userBasicInformation.thana.id;
                    cmbPostCodeBus.SelectedValue = SessionInfo.userBasicInformation.postalCode.id;
                    //cmbContactCountryCode.SelectedValue = SessionInfo.userBasicInformation.country.id;
                }

                if (_customerInformation == null || _customerInformation.permanentAddress == null)
                {
                    List<Division> divisionsPer = LocalCache.GetDivisions();
                    BindingSource bsDivisionsPer = new BindingSource();
                    bsDivisionsPer.DataSource = divisionsPer;
                    UtilityServices.fillComboBox(cmbDivitionPer, bsDivisionsPer, "name", "id");
                    cmbDivitionPer.SelectedValue = SessionInfo.userBasicInformation.division.id;

                    List<District> DistrictTmpPer = LocalCache.GetDistrictsByDivisionID(SessionInfo.userBasicInformation.division.id);
                    BindingSource bsDistrictPer = new BindingSource();
                    bsDistrictPer.DataSource = DistrictTmpPer;
                    UtilityServices.fillComboBox(cmbDistrictPer, bsDistrictPer, "title", "id");

                    long tmpIdPer = SessionInfo.userBasicInformation.district.id;
                    List<Thana> ThanaTmpPer = LocalCache.GetThanasByDistrictID(tmpIdPer);
                    BindingSource bsThanaPer = new BindingSource();
                    bsThanaPer.DataSource = ThanaTmpPer;
                    UtilityServices.fillComboBox(cmbThanaPer, bsThanaPer, "title", "id");

                    List<PostalCode> PostalCodeTmpPer = LocalCache.GetPostalCodesByDistrictID(tmpIdPer);
                    BindingSource bsPostalCodeTmpPer = new BindingSource();
                    bsPostalCodeTmpPer.DataSource = PostalCodeTmpPer;
                    UtilityServices.fillComboBox(cmbPostCodePer, bsPostalCodeTmpPer, "postalCode", "id");


                    cmbDistrictPer.SelectedValue = SessionInfo.userBasicInformation.district.id;
                    cmbThanaPer.SelectedValue = SessionInfo.userBasicInformation.thana.id;
                    cmbPostCodePer.SelectedValue = SessionInfo.userBasicInformation.postalCode.id;
                    //cmbContactCountryCode.SelectedValue = SessionInfo.userBasicInformation.country.id;
                }

                if (_customerInformation == null || _customerInformation.presentAddress == null)
                {
                    List<Division> divisionsPre = LocalCache.GetDivisions();
                    BindingSource bsDivisionsPre = new BindingSource();
                    bsDivisionsPre.DataSource = divisionsPre;
                    UtilityServices.fillComboBox(cmbDivitionPre, bsDivisionsPre, "name", "id");
                    cmbDivitionPre.SelectedValue = SessionInfo.userBasicInformation.division.id;

                    List<District> DistrictTmpPre = LocalCache.GetDistrictsByDivisionID(SessionInfo.userBasicInformation.division.id);
                    BindingSource bsDistrictPre = new BindingSource();
                    bsDistrictPre.DataSource = DistrictTmpPre;
                    UtilityServices.fillComboBox(cmbDistrictPre, bsDistrictPre, "title", "id");

                    long tmpIdPre = SessionInfo.userBasicInformation.district.id;
                    List<Thana> ThanaTmpPre = LocalCache.GetThanasByDistrictID(tmpIdPre);
                    BindingSource bsThanaPre = new BindingSource();
                    bsThanaPre.DataSource = ThanaTmpPre;
                    UtilityServices.fillComboBox(cmbThanaPre, bsThanaPre, "title", "id");

                    List<PostalCode> PostalCodeTmpPre = LocalCache.GetPostalCodesByDistrictID(tmpIdPre);
                    BindingSource bsPostalCodeTmpPre = new BindingSource();
                    bsPostalCodeTmpPre.DataSource = PostalCodeTmpPre;
                    UtilityServices.fillComboBox(cmbPostCodePre, bsPostalCodeTmpPre, "postalCode", "id");


                    cmbDistrictPre.SelectedValue = SessionInfo.userBasicInformation.district.id;
                    cmbThanaPre.SelectedValue = SessionInfo.userBasicInformation.thana.id;
                    cmbPostCodePre.SelectedValue = SessionInfo.userBasicInformation.postalCode.id;
                }

                //cmbCountryBus.SelectedValue = SessionInfo.userBasicInformation.country.id;
            }

            if (_receivePacket.actionType == FormActionType.View)
            {
                _gui.SetControlState(GUI.CONTROLSTATES.CS_READONLY, new Control[]
                {
                    txtBorrowerCode,
                    txtBusinessAddress1,
                    txtBusinessAddress2,
                    txtCustomerTitle,
                    txtEmail,
                    txtFax,
                    txtIndividualId,
                    txtMolile,
                    txtPermanentBusinessAddress1,
                    txtPermanentBusinessAddress2,
                    txtPresentBusinessAddress1,
                    txtPresentBusinessAddress2,
                    txtTelephone,
                });
                _gui.SetControlState(GUI.CONTROLSTATES.CS_DISABLE, new Control[]
                {
                    cmbBusinessAddressCopy,
                    cmbCountryBus,
                    cmbCountryPer,
                    cmbCountryPre,
                    cmbCustomerType,
                    cmbDistrictBus,
                    cmbDistrictPer,
                    cmbDistrictPre,
                    cmbDivitionBus,
                    cmbDivitionPer,
                    cmbDivitionPre,
                    cmbInstitutionType,
                    cmbLocation,
                    cmbOwnerType,
                    cmbPermanentAddressCopy,
                    cmbPostCodeBus,
                    cmbPostCodePer,
                    cmbPostCodePre,
                    cmbPresentAddressCopy,
                    cmbSectorCode,
                    cmbSectorType,
                    cmbThanaBus,
                    cmbThanaPer,
                    cmbThanaPre,

                    chkBusinessToPresent,
                    chkPermanentToPresent,
                    chkUseBusinessAddress
                });
                _gui.SetControlState(GUI.CONTROLSTATES.CS_HIDDEN, new Control[]
               {
                   btnClear,
                   btnSave
               });
            }
        }

        public void SetupComponents()
        {
            _gui = new GUI(this);
            //gui.Config(ref txtOutletName);

            if (_receivePacket.intentType == IntentType.Request)
            {
                btnSave.Text = "Done";
            }
            else
                btnSave.Text = "Save";


            if (_receivePacket.actionType == FormActionType.View)
            {
                //  _gui.SetControlState(GUI.CONTROLSTATES.CS_DISABLE, new Control[] { txtFirstName, txtLastName, txtFathersFirstName, txtFatherLastName, txtMothersFirstName, txtMotherLastName, cmbGender, cmbMaritalStatus, txtSpouseName, mtbDOB, cmbBirthPlace, cmbOccupation, txtTelephoneNo, txtMobileNo, txtFax, txtEmail, cmbContactAddressCopy, txtContactAddress1, txtContactAddress2, cmbContactDivision, cmbContactDistrict, cmbContactThana, cmbContactPostCode, cmbPermaAddressCopy, txtPermanentAddress1, txtPermanentAddress2, cmbPermanentDivision, cmbPermanentDistrict, cmbPermanentThana, cmbPermanentPostalCode });
            }
        }

        private void FillComponentWithObjectValue()
        {

            if (_customerInformation != null)
            {
                cmbCustomerType.SelectedValue = _customerInformation.cisType.id;
                if (_customerInformation.cisInstituteType != null)
                {
                    cmbInstitutionType.SelectedValue = _customerInformation.cisInstituteType.id;
                }

                _customerInformation.cisType = UtilityServices.genCisType(Convert.ToInt32(cmbCustomerType.SelectedValue), null, null);
                if ((long)cmbCustomerType.SelectedValue != 1)
                {
                    cmbInstitutionType.Visible = true;
                    lblInisType.Enabled = true;
                }
                _customerInformation.cisInstituteType = (cmbInstitutionType.SelectedIndex == -1) ? null : UtilityServices.genCisInstituteType(Convert.ToInt32(cmbInstitutionType.SelectedValue), null);

                txtCustomerTitle.Text = _customerInformation.title;
                txtEmail.Text = _customerInformation.email;
                txtMolile.Text = _customerInformation.mobileNumber;
                txtFax.Text = _customerInformation.fax;
               cmbLocation.SelectedItem = _customerInformation.location;
                if (_customerInformation.sectorType != 0 || _customerInformation.sectorType != null)
                {
                    try
                    {
                        cmbSectorType.SelectedIndex = (int)_customerInformation.sectorType;
                    }
                    catch { }
                }

                if (_customerInformation.sectorCode != null)
                {
                  //  UtilityServices.GetSectorCodeList(ref cmbSectorCode, ref publicSectorCodes, ref privateSectorCodes);
                    cmbSectorCode.SelectedValue = _customerInformation.sectorCode;
                }

                txtBorrowerCode.Text = _customerInformation.borrowerCode;
                _docId = _customerInformation.documentInfoId;

                List<Division> DivisionTmp = LocalCache.GetDivisions();
                BindingSource bsDivisionTmpBus = new BindingSource();
                bsDivisionTmpBus.DataSource = DivisionTmp;
                BindingSource bsDivisionTmpPer = new BindingSource();
                bsDivisionTmpPer.DataSource = DivisionTmp;
                BindingSource bsDivisionTmpPre = new BindingSource();
                bsDivisionTmpPre.DataSource = DivisionTmp;


                //businessAddress
                if (_customerInformation.businessAddress != null)
                {
                    UtilityServices.fillComboBox(cmbDivitionBus, bsDivisionTmpBus, "name", "id");
                    if (_customerInformation.businessAddress.division != null)
                    {
                        cmbDivitionBus.SelectedValue = _customerInformation.businessAddress.division.id;
                    }

                    List<District> DistrictTmpBus = LocalCache.GetDistrictsByDivisionID(_customerInformation.businessAddress.division.id);
                    BindingSource bsDistrictBus = new BindingSource();
                    bsDistrictBus.DataSource = DistrictTmpBus;
                    UtilityServices.fillComboBox(cmbDistrictBus, bsDistrictBus, "title", "id");
                    if (_customerInformation.businessAddress.district != null)
                    {
                        cmbDistrictBus.SelectedValue = _customerInformation.businessAddress.district.id;
                    }

                    if (_customerInformation.businessAddress.district != null)
                    {
                        long tmpIdBus = _customerInformation.businessAddress.district.id;
                        List<Thana> ThanaTmp = LocalCache.GetThanasByDistrictID(tmpIdBus);
                        BindingSource bsThana = new BindingSource();
                        bsThana.DataSource = ThanaTmp;
                        UtilityServices.fillComboBox(cmbThanaBus, bsThana, "title", "id");
                        if (_customerInformation.businessAddress.thana != null)
                        {
                            cmbThanaBus.SelectedValue = _customerInformation.businessAddress.thana.id;
                        }

                        List<PostalCode> PostalCodeTmpBus = LocalCache.GetPostalCodesByDistrictID(tmpIdBus);
                        BindingSource bsPostalCodeTmpBus = new BindingSource();
                        bsPostalCodeTmpBus.DataSource = PostalCodeTmpBus;
                        UtilityServices.fillComboBox(cmbPostCodeBus, bsPostalCodeTmpBus, "postalCode", "id");
                        if (_customerInformation.businessAddress.postalCode != null)
                        {
                            cmbPostCodeBus.SelectedValue = _customerInformation.businessAddress.postalCode.id;
                        }
                    }

                    txtBusinessAddress1.Text = _customerInformation.businessAddress.addressLineOne;
                    txtBusinessAddress2.Text = _customerInformation.businessAddress.addressLineTwo;
                }


                //permanentAddress
                if (_customerInformation.permanentAddress != null)
                {
                    UtilityServices.fillComboBox(cmbDivitionPer, bsDivisionTmpPer, "name", "id");
                    if (_customerInformation.permanentAddress.division != null)
                    {
                        cmbDivitionPer.SelectedValue = _customerInformation.permanentAddress.division.id;
                    }

                    List<District> DistrictTmpPer = LocalCache.GetDistrictsByDivisionID(_customerInformation.permanentAddress.division.id);
                    BindingSource bsDistrictPer = new BindingSource();
                    bsDistrictPer.DataSource = DistrictTmpPer;
                    UtilityServices.fillComboBox(cmbDistrictPer, bsDistrictPer, "title", "id");
                    if (_customerInformation.permanentAddress.district != null)
                    {
                        cmbDistrictPer.SelectedValue = _customerInformation.permanentAddress.district.id;
                    }

                    if (_customerInformation.permanentAddress.district != null)
                    {
                        long tmpIdPer = _customerInformation.permanentAddress.district.id;
                        List<Thana> ThanaTmpPer = LocalCache.GetThanasByDistrictID(tmpIdPer);
                        BindingSource bsThanaPer = new BindingSource();
                        bsThanaPer.DataSource = ThanaTmpPer;
                        UtilityServices.fillComboBox(cmbThanaPer, bsThanaPer, "title", "id");
                        if (_customerInformation.permanentAddress.thana != null)
                        {
                            cmbThanaPer.SelectedValue = _customerInformation.permanentAddress.thana.id;
                        }

                        List<PostalCode> PostalCodeTmpPer = LocalCache.GetPostalCodesByDistrictID(tmpIdPer);
                        BindingSource bsPostalCodeTmpPer = new BindingSource();
                        bsPostalCodeTmpPer.DataSource = PostalCodeTmpPer;
                        UtilityServices.fillComboBox(cmbPostCodePer, bsPostalCodeTmpPer, "postalCode", "id");
                        if (_customerInformation.permanentAddress.postalCode != null)
                        {
                            cmbPostCodePer.SelectedValue = _customerInformation.permanentAddress.postalCode.id;
                        }
                    }
                    txtPermanentBusinessAddress1.Text = _customerInformation.permanentAddress.addressLineOne;
                    txtPermanentBusinessAddress2.Text = _customerInformation.permanentAddress.addressLineTwo;
                }


                //presentAddress 
                if (_customerInformation.presentAddress != null)
                {
                    UtilityServices.fillComboBox(cmbDivitionPre, bsDivisionTmpPre, "name", "id");
                    if (_customerInformation.presentAddress.division != null)
                    {
                        cmbDivitionPre.SelectedValue = _customerInformation.presentAddress.division.id;
                    }

                    List<District> DistrictTmpPre = LocalCache.GetDistrictsByDivisionID(_customerInformation.presentAddress.division.id);
                    BindingSource bsDistrictPre = new BindingSource();
                    bsDistrictPre.DataSource = DistrictTmpPre;
                    UtilityServices.fillComboBox(cmbDistrictPre, bsDistrictPre, "title", "id");
                    if (_customerInformation.presentAddress.district != null)
                    {
                        cmbDistrictPre.SelectedValue = _customerInformation.presentAddress.district.id;
                    }

                    if (_customerInformation.presentAddress.district != null)
                    {
                        long tmpIdPre = _customerInformation.presentAddress.district.id;
                        List<Thana> ThanaTmpPre = LocalCache.GetThanasByDistrictID(tmpIdPre);
                        BindingSource bsThanaPre = new BindingSource();
                        bsThanaPre.DataSource = ThanaTmpPre;
                        UtilityServices.fillComboBox(cmbThanaPre, bsThanaPre, "title", "id");
                        if (_customerInformation.presentAddress.thana != null)
                        {
                            cmbThanaPre.SelectedValue = _customerInformation.presentAddress.thana.id;
                        }

                        List<PostalCode> PostalCodeTmpPre = LocalCache.GetPostalCodesByDistrictID(tmpIdPre);
                        BindingSource bsPostalCodeTmpPre = new BindingSource();
                        bsPostalCodeTmpPre.DataSource = PostalCodeTmpPre;
                        UtilityServices.fillComboBox(cmbPostCodePre, bsPostalCodeTmpPre, "postalCode", "id");
                        if (_customerInformation.presentAddress.postalCode != null)
                        {
                            cmbPostCodePre.SelectedValue = _customerInformation.presentAddress.postalCode.id;
                        }
                    }

                    txtPresentBusinessAddress1.Text = _customerInformation.presentAddress.addressLineOne;
                    txtPresentBusinessAddress2.Text = _customerInformation.presentAddress.addressLineTwo;
                }

                //--------------------...will be fixed later---------------------------------
                // cmbPresentAddressCopy.SelectedValue = _customerInformation.presentAddress;
                //


                loadOwnerInfo();
            }

            if (_receivePacket.actionType == FormActionType.View)
            {
                gvOwnerInfo.Columns[0].Visible = false;
                gvOwnerInfo.Columns[1].Visible = true;
            }
            else
            {
                gvOwnerInfo.Columns[0].Visible = true;
                gvOwnerInfo.Columns[1].Visible = false;
            }
        }

        private void loadOwnerInfo()
        {
            //ownerGrid
            gvOwnerInfo.DataSource = null;
            gvOwnerInfo.Columns.Clear();

            //DataGrid Edit Button
            DataGridViewButtonColumn buttonColumnEdit = new DataGridViewButtonColumn();
            buttonColumnEdit.Text = "Edit";
            buttonColumnEdit.UseColumnTextForButtonValue = true;
            gvOwnerInfo.Columns.Add(buttonColumnEdit);

            //DataGrid View Button
            DataGridViewButtonColumn buttonColumnView = new DataGridViewButtonColumn();
            buttonColumnView.Text = "View";
            buttonColumnView.UseColumnTextForButtonValue = true;
            gvOwnerInfo.Columns.Add(buttonColumnView);

            if (_receivePacket.actionType == FormActionType.Edit || _receivePacket.actionType == FormActionType.New)
            {
                buttonColumnEdit.Visible = true;
                buttonColumnView.Visible = false;
            }
            else
            {
                buttonColumnEdit.Visible = false;
                buttonColumnView.Visible = true;
            }


            List<OwnerInformation> ownerInformations = _customerInformation.owners;
            gvOwnerInfo.DataSource = ownerInformations.Select(o => new OwnerGrid(o)
            {
                Name = o.individualInformation.firstName + " " + o.individualInformation.lastName,
                Fathers_Name = o.individualInformation.fatherFirstName,
                OwnerType = o.ownerType.description
            }).ToList();
        }

        private void FillObjectWithComponentValue()
        {
            if (_customerInformation.cisType == null)
            {
                _customerInformation.cisType = new CisType();

            }

            _customerInformation.cisType = UtilityServices.genCisType(Convert.ToInt32(cmbCustomerType.SelectedValue), null, null);

            if ((long)cmbCustomerType.SelectedValue != 1)
            {
                _customerInformation.cisInstituteType = (cmbInstitutionType.SelectedIndex == -1) ? null : UtilityServices.genCisInstituteType(Convert.ToInt32(cmbInstitutionType.SelectedValue), null);
            }
            else
            {
                _customerInformation.cisInstituteType = null;
            }
            //_customerInformation.owners = objOwnerInfoList;

            _customerInformation.title = txtCustomerTitle.Text;
            _customerInformation.email = txtEmail.Text;
            _customerInformation.mobileNumber = txtMolile.Text;
            _customerInformation.fax = txtFax.Text;
            _customerInformation.location = (CisLocation)cmbLocation.SelectedValue;
            _customerInformation.sectorType = long.Parse(((ComboboxItem)cmbSectorType.SelectedItem).Value.ToString());

            if (cmbSectorCode.SelectedValue != null)
                _customerInformation.sectorCode = cmbSectorCode.SelectedValue.ToString();
            else
                _customerInformation.sectorCode = null;
            _customerInformation.borrowerCode = txtBorrowerCode.Text;

            //bus
            {
                if (_customerInformation.businessAddress == null)
                {
                    _customerInformation.businessAddress = new Address();
                }
                _customerInformation.businessAddress.addressLineOne = txtBusinessAddress1.Text;
                _customerInformation.businessAddress.addressLineTwo = txtBusinessAddress2.Text;
                if (_customerInformation.businessAddress.division == null)
                    _customerInformation.businessAddress.division = new Division();
                _customerInformation.businessAddress.division.id = ((Division)cmbDivitionBus.SelectedItem).id;

                if (_customerInformation.businessAddress.district == null)
                    _customerInformation.businessAddress.district = new District();
                _customerInformation.businessAddress.district.id = ((District)cmbDistrictBus.SelectedItem).id;

                if (_customerInformation.businessAddress.thana == null)
                    _customerInformation.businessAddress.thana = new Thana();
                _customerInformation.businessAddress.thana.id = ((Thana)cmbThanaBus.SelectedItem).id;

                if (_customerInformation.businessAddress.postalCode == null)
                    _customerInformation.businessAddress.postalCode = new PostalCode();
                _customerInformation.businessAddress.postalCode.id = ((PostalCode)cmbPostCodeBus.SelectedItem).id;

                if (_customerInformation.businessAddress.country == null)
                    _customerInformation.businessAddress.country = new Country();
                _customerInformation.businessAddress.country.id = ((Country)cmbCountryBus.SelectedItem).id;
            }

            //per
            {
                if (_customerInformation.permanentAddress == null)
                    _customerInformation.permanentAddress = new Address();
                _customerInformation.permanentAddress.addressLineOne = txtPermanentBusinessAddress1.Text;
                _customerInformation.permanentAddress.addressLineTwo = txtPermanentBusinessAddress2.Text;

                if (_customerInformation.permanentAddress.division == null)
                    _customerInformation.permanentAddress.division = new Division();
                _customerInformation.permanentAddress.division.id = ((Division)cmbDivitionPer.SelectedItem).id;

                if (_customerInformation.permanentAddress.district == null)
                    _customerInformation.permanentAddress.district = new District();
                _customerInformation.permanentAddress.district.id = ((District)cmbDistrictPer.SelectedItem).id;

                if (_customerInformation.permanentAddress.thana == null)
                    _customerInformation.permanentAddress.thana = new Thana();
                _customerInformation.permanentAddress.thana.id = ((Thana)cmbThanaPer.SelectedItem).id;

                if (_customerInformation.permanentAddress.postalCode == null)
                    _customerInformation.permanentAddress.postalCode = new PostalCode();
                _customerInformation.permanentAddress.postalCode.id = ((PostalCode)cmbPostCodePer.SelectedItem).id;

                if (_customerInformation.permanentAddress.country == null)
                    _customerInformation.permanentAddress.country = new Country();
                _customerInformation.permanentAddress.country.id = ((Country)cmbCountryPer.SelectedItem).id;
            }

            //pre
            {
                if (_customerInformation.presentAddress == null)
                    _customerInformation.presentAddress = new Address();
                _customerInformation.presentAddress.addressLineOne = txtPresentBusinessAddress1.Text;
                _customerInformation.presentAddress.addressLineTwo = txtPresentBusinessAddress2.Text;

                if (_customerInformation.presentAddress.division == null)
                    _customerInformation.presentAddress.division = new Division();
                _customerInformation.presentAddress.division.id = ((Division)cmbDivitionPre.SelectedItem).id;

                if (_customerInformation.presentAddress.district == null)
                    _customerInformation.presentAddress.district = new District();
                _customerInformation.presentAddress.district.id = ((District)cmbDistrictPre.SelectedItem).id;

                if (_customerInformation.presentAddress.thana == null)
                    _customerInformation.presentAddress.thana = new Thana();
                _customerInformation.presentAddress.thana.id = ((Thana)cmbThanaPre.SelectedItem).id;

                if (_customerInformation.presentAddress.postalCode == null)
                    _customerInformation.presentAddress.postalCode = new PostalCode();
                _customerInformation.presentAddress.postalCode.id = ((PostalCode)cmbPostCodePre.SelectedItem).id;

                if (_customerInformation.presentAddress.country == null)
                    _customerInformation.presentAddress.country = new Country();
                _customerInformation.presentAddress.country.id = ((Country)cmbCountryPre.SelectedItem).id;
            }

            //if (_docId != null)
            {
                _customerInformation.documentInfoId = _docId;
            }
        }

        private bool validationCheck()
        {
            if (_customerInformation == null)
            {
                Message.showWarning("Please provide customer information!!");
                return false;
            }
            if (_customerInformation.cisType == null)
            {
                Message.showWarning("Please provide CIS Type information!!");
                return false;
            }
            //if (_customerInformation.cisInstituteType == null)
            //{
            //    Message.showWarning("Please provide inistitute information!!");
            //    return false;
            //}
            if (_customerInformation.cisType.id != 1)
            {
                if (_customerInformation.cisInstituteType == null)
                {
                    Message.showWarning("Institution Type cannot be left blank!!");
                    return false;
                }
            }
            if (string.IsNullOrEmpty(_customerInformation.title))
            {
                Message.showWarning("Customer title not found!!");
                return false;
            }
            if (string.IsNullOrEmpty(_customerInformation.mobileNumber))
            {
                Message.showWarning("Mobile number not found!!");
                return false;
            }
            ////if (_customerInformation.owners.Count <= 0)
            ////{
            ////    Message.showWarning("Owner information not found!!");
            ////    return false;
            ////}
            ////////if (_customerInformation.sectorType == null)
            ////////{
            ////////    Message.showWarning("Sector type not found!!");
            ////////    return false;
            ////////}
            ////////if (string.IsNullOrEmpty(_customerInformation.sectorCode))
            ////////{
            ////////    Message.showWarning("Sector type not found!!");
            ////////    return false;
            ////////}
            if (string.IsNullOrEmpty(_customerInformation.permanentAddress.addressLineOne))
            {
                Message.showWarning("Please provide permanent address!!");
                return false;
            }
            //if (string.IsNullOrEmpty(_customerInformation.permanentAddress.addressLineTwo))
            //{
            //    Message.showWarning("Please provide permanent address!!");
            //    return false;
            //}
            if (_customerInformation.permanentAddress.division == null)
            {
                Message.showWarning("Please provide division information!!");
                return false;
            }
            if (_customerInformation.permanentAddress.district == null)
            {
                Message.showWarning("Please provide District!!");
                return false;
            }
            if (_customerInformation.permanentAddress.thana == null)
            {
                Message.showWarning("Please provide Thana information!!");
                return false;
            }
            if (_customerInformation.permanentAddress.thana == null)
            {
                Message.showWarning("Please provide Thana information !!");
                return false;
            }
            if (string.IsNullOrEmpty(_customerInformation.presentAddress.addressLineOne))
            {
                Message.showWarning("Please provide present address!!");
                return false;
            }
            //if (string.IsNullOrEmpty(_customerInformation.presentAddress.addressLineTwo))
            //{
            //    Message.showWarning("Please provide permanent address!!");
            //    return false;
            //}
            if (_customerInformation.presentAddress.division == null)
            {
                Message.showWarning("Please provide division information!!");
                return false;
            }
            if (_customerInformation.presentAddress.district == null)
            {
                Message.showWarning("Please provide District!!");
                return false;
            }
            if (_customerInformation.presentAddress.thana == null)
            {
                Message.showWarning("Please provide Thana information!!");
                return false;
            }
            if (_customerInformation.presentAddress.thana == null)
            {
                Message.showWarning("Please provide Thana information !!");
                return false;
            }
            //if (_customerInformation.documentInfoId == null)
            //{
            //    Message.showWarning("Please provide document information !!!");
            //    return false;
            //}
            return true;
        }

        public CustomerInformation GetFilledObject()
        {
            return _customerInformation;
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

        //--------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------

        private void btnSave_Click(object sender, EventArgs e)
        {
            FillObjectWithComponentValue();

            if (validationCheck())
            {
                if (_receivePacket.intentType == IntentType.Request)
                {
                    this.Close();
                }
            }

            /*
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
                    //CustomerInformation objCis = new CustomerInformation();
                    //objCis = fillCustomerInformation();
                    try
                    {
                        //if (customerValidation(objCis))           //not necessary when validationCheck() is used.
                        //{
                        ProgressUIManager.ShowProgress(this);
                        //string retrnMsg = objCustomerServices.saveCustomer(objCis);
                        string retrnMsg = objCustomerServices.saveCustomer(_customerInformation);
                        ProgressUIManager.CloseProgress();

                        Message.showConfirmation(retrnMsg);
                        clearData();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
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

            btnSave.Enabled = true;*/
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbCountryBus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnDocument_Click(object sender, EventArgs e)
        {
            ActionType actionType = new ActionType();

            switch (_receivePacket.actionType)
            {
                case FormActionType.New:
                case FormActionType.Edit:
                    actionType = ActionType.update;
                    break;
                case FormActionType.View:
                case FormActionType.Verify:
                    actionType = ActionType.view;
                    break;
            }

            frmDocument doc = new frmDocument(Convert.ToInt32(_docId), actionType);
            if (doc.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _docId = Convert.ToInt32(doc.getDocIdAfterSave());
                }
                catch (Exception ex)
                {
                    // MessageBox.Show(doc.getDocIdAfterSave());
                }
            }
        }

        private void cmbDivitionBus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (!cb.Focused)
            {
                return;
            }

            List<District> DistrictTmpBus = LocalCache.GetDistrictsByDivisionID(((Division)cmbDivitionBus.SelectedItem).id);
            BindingSource bsDivisionBus = new BindingSource();
            bsDivisionBus.DataSource = DistrictTmpBus;
            UtilityServices.fillComboBox(cmbDistrictBus, bsDivisionBus, "title", "id");

            cmbDistrictBus.SelectedIndex = -1;
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

            long districtId = Convert.ToInt32(cmbDistrictBus.SelectedValue);
            BindingSource bsDistrictBus = new BindingSource();
            bsDistrictBus.DataSource = LocalCache.GetThanasByDistrictID(districtId);
            UtilityServices.fillComboBox(cmbThanaBus, bsDistrictBus, "title", "id");
            cmbThanaBus.SelectedIndex = -1;

            BindingSource bsPostCodeBus = new BindingSource();
            bsPostCodeBus.DataSource = LocalCache.GetPostalCodesByDistrictID(districtId);
            UtilityServices.fillComboBox(cmbPostCodeBus, bsPostCodeBus, "postalCode", "id");
            cmbPostCodeBus.SelectedIndex = -1;
        }

        private void cmbDivitionPer_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (!cb.Focused)
            {
                return;
            }

            List<District> DistrictTmpPer = LocalCache.GetDistrictsByDivisionID(((Division)cmbDivitionPer.SelectedItem).id);
            BindingSource bsDivisionPer = new BindingSource();
            bsDivisionPer.DataSource = DistrictTmpPer;
            UtilityServices.fillComboBox(cmbDistrictPer, bsDivisionPer, "title", "id");

            cmbDistrictPer.SelectedIndex = -1;
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

            long districtId = Convert.ToInt32(cmbDistrictPer.SelectedValue);
            BindingSource bsDistrictPer = new BindingSource();
            bsDistrictPer.DataSource = LocalCache.GetThanasByDistrictID(districtId);
            UtilityServices.fillComboBox(cmbThanaPer, bsDistrictPer, "title", "id");
            cmbThanaPer.SelectedIndex = -1;

            BindingSource bsPostCodePer = new BindingSource();
            bsPostCodePer.DataSource = LocalCache.GetPostalCodesByDistrictID(districtId);
            UtilityServices.fillComboBox(cmbPostCodePer, bsPostCodePer, "postalCode", "id");
            cmbPostCodePer.SelectedIndex = -1;
        }

        private void cmbDivitionPre_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (!cb.Focused)
            {
                return;
            }

            try
            {
                List<District> DistrictTmpPre = LocalCache.GetDistrictsByDivisionID(((Division)cmbDivitionPre.SelectedItem).id);
                BindingSource bsDistrictPre = new BindingSource();
                bsDistrictPre.DataSource = DistrictTmpPre;
                UtilityServices.fillComboBox(cmbDistrictPre, bsDistrictPre, "title", "id");

                cmbDistrictPre.SelectedIndex = -1;
                cmbThanaPre.DataSource = null;
                cmbPostCodePre.DataSource = null;
            }
            catch { }
        }

        private void cmbDistrictPre_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (!cb.Focused)
            {
                return;
            }

            long districtId = Convert.ToInt32(cmbDistrictPre.SelectedValue);
            BindingSource bsDistrictPre = new BindingSource();
            bsDistrictPre.DataSource = LocalCache.GetThanasByDistrictID(districtId);
            UtilityServices.fillComboBox(cmbThanaPre, bsDistrictPre, "title", "id");
            cmbThanaPre.SelectedIndex = -1;

            BindingSource bsPostCodePre = new BindingSource();
            bsPostCodePre.DataSource = LocalCache.GetPostalCodesByDistrictID(districtId);
            UtilityServices.fillComboBox(cmbPostCodePre, bsPostCodePre, "postalCode", "id");
            cmbPostCodePre.SelectedIndex = -1;
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
            if (_docId != 0) objCis.documentInfoId = _docId;
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
            //objCis.owners = objOwnerInfoList;
            objCis.businessAddress.country.id = Convert.ToInt32(cmbCountryBus.SelectedValue);
            objCis.permanentAddress.country.id = Convert.ToInt32(cmbCountryPer.SelectedValue);
            objCis.presentAddress.country.id = Convert.ToInt32(cmbCountryPre.SelectedValue);
            return objCis;
        }

        private void clearData()
        {
            _gui.EmptyControls(new Control[]
            {
                txtBusinessAddress1,
                txtBusinessAddress2,
                txtCustomerTitle,
                txtEmail,
                txtFax,
                txtIndividualId,
                txtMolile,
                txtPermanentBusinessAddress1,
                txtPermanentBusinessAddress2,
                txtPresentBusinessAddress1,
                txtPresentBusinessAddress2,
                txtTelephone
            });

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

        private void cmbSectorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSectorType.SelectedIndex != 0)
            {
                BindingSource sc = new BindingSource();
                if (cmbSectorType.SelectedIndex == 1)
                    sc.DataSource = publicSectorCodes.OrderBy(x => x.name).ToList();
                if (cmbSectorType.SelectedIndex == 2)
                    sc.DataSource = privateSectorCodes.OrderBy(x => x.name).ToList();
                UtilityServices.fillComboBox(cmbSectorCode, sc, "NameWithCode", "code");
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
            cmbOwnerType.SelectedIndex = -1;
            if ((long)cmbCustomerType.SelectedValue == 1)
            {
                cmbInstitutionType.Visible = false;
                lblInisType.Enabled = false;
            }
            else
            {
                cmbInstitutionType.Visible = true;
                lblInisType.Enabled = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnAddSelectedIndividualAsOwner_Click(object sender, EventArgs e)
        {
            ////////////////////////////////////////////////////////////////////////
            //                                                                    //  
            //        CHANGE objOwnerInfoList TO _customerInformation.owners      //
            //                                                                    //
            ////////////////////////////////////////////////////////////////////////

            /*
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
            */
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

        private void cmbBusinessAddressCopy_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (!cb.Focused)
            {
                return;
            }
            try
            {
                //Address addr = UtilityServices.commonAddresses.Single(o => o.commonAddressIndex == (int)(cmbBusinessAddressCopy.SelectedValue));
                Address addr = _addresses[((ComboboxItem)cb.SelectedItem).Value];
                UtilityServices.setAddress(addr, ref txtBusinessAddress1, ref txtBusinessAddress2, ref cmbPostCodeBus, ref cmbThanaBus, ref cmbDistrictBus, ref cmbDivitionBus, ref cmbCountryBus);
            }
            catch
            {

            }
        }

        private void cmbPermanentAddressCopy_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (!cb.Focused)
            {
                return;
            }
            chkUseBusinessAddress.Checked = false;
            //Address addr = UtilityServices.commonAddresses.Single(o => o.commonAddressIndex == (int)(cmbPermanentAddressCopy.SelectedValue));
            Address addr = _addresses[((ComboboxItem)cb.SelectedItem).Value];
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
            //Address addr = UtilityServices.commonAddresses.Single(o => o.commonAddressIndex == (int)(cmbPresentAddressCopy.SelectedValue));
            Address addr = _addresses[((ComboboxItem)cb.SelectedItem).Value];
            UtilityServices.setAddress(addr, ref txtPresentBusinessAddress1, ref txtPresentBusinessAddress2, ref cmbPostCodePre, ref cmbThanaPre, ref cmbDistrictPre, ref cmbDivitionPre, ref cmbCountryPre);
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
                UtilityServices.copyAddress(txtPermanentBusinessAddress1, txtPermanentBusinessAddress2, cmbPostCodePer, cmbThanaPer, cmbDistrictPer, cmbDivitionPer, cmbCountryPer, ref txtPresentBusinessAddress1, ref txtPresentBusinessAddress2, ref cmbPostCodePre, ref cmbThanaPre, ref cmbDistrictPre, ref cmbDivitionPre, ref cmbCountryPre);
            }
            catch (Exception ex)
            {
                Message.showError(ex.Message);
            }
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

        private void gvOwnerInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gvOwnerInfo.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (gvOwnerInfo.Rows.Count > 0)
                {
                    try
                    {
                        IndividualInformation individualInformation = _customerInformation.owners[e.RowIndex].individualInformation;
                        Packet packet = new Packet();
                        frmIndividualInformation frm = null;

                        packet.intentType = IntentType.Request;

                        //Edit Button Clicked
                        if (gvOwnerInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "Edit")
                        {
                            packet.actionType = FormActionType.Edit;
                            frm = new frmIndividualInformation(packet, individualInformation);
                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                individualInformation = frm.getFilledObject();
                                _customerInformation.owners[e.RowIndex].individualInformation = individualInformation;
                                loadOwnerInfo();
                            }
                        }

                        //View Button Clicked
                        if (gvOwnerInfo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "View")
                        {
                            packet.actionType = FormActionType.View;
                            frm = new frmIndividualInformation(packet, individualInformation);
                            if (frm.ShowDialog() == DialogResult.OK)
                            {

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Message.showError(ex.Message);
                    }
                }
            }
        }
    }

    public class OwnerGrid
    {
        public string Name { get; set; }
        public string Fathers_Name { get; set; }
        public string OwnerType { get; set; }

        private OwnerInformation _obj;

        public OwnerGrid(OwnerInformation obj)
        {
            _obj = obj;
        }

        public OwnerInformation GetModel()
        {
            return _obj;
        }
    }
}