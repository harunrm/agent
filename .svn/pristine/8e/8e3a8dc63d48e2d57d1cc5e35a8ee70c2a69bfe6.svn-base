using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using MISL.Ababil.Agent.Infrastructure;
using MISL.Ababil.Agent.Communication;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models;
using System.Configuration;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.cis;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.consumer;
using System.IO;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.documentMgt;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account.kyc;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using MISL.Ababil.Agent.Infrastructure.Models.reports;
using MetroFramework.Controls;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.nominee;
using System.Globalization;

namespace MISL.Ababil.Agent.Services
{
    public class UtilityServices
    {
        public static List<SectorCodeInfo> CmbSectorCodeList;

        public static List<CisType> CmbCustomerTypes;
        public static List<CisInstituteType> InstitutionTypes;
        public static List<District> AllDistricts;
        public static List<Occupation> Occupations;
        public static List<Division> Divisions;
        public static List<Country> Countries;
        public static List<Address> commonAddresses = new List<Address>();
        //public static DocumentInfo genDocumentInformation(long id, long ownerId, DocumentOwnerType ownerType)
        //{
        //    DocumentInfo docInfo = new DocumentInfo();
        //    docInfo.id = id;
        //    docInfo.ownerId = ownerId;
        //    docInfo.ownerType = ownerType;
        //    return docInfo;
        //}

        public static ReportHeaders getReportHeaders(string reportTitle)
        {
            ReportHeaders rptHeaders = new ReportHeaders();
            int branchId = CommonRules.agentBankDivisionId;
            try
            {
                rptHeaders.branchDto = UtilityCom.getBranchDto(branchId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            rptHeaders.printUser = SessionInfo.username;
            rptHeaders.printDate = DateTime.Now;
            rptHeaders.reportHeading = reportTitle;
            return rptHeaders;
        }
        public static SubAgentInformation getCurrentSubAgent() //works only when subagent logins
        {
            SubAgentService objSubagentCom = new SubAgentService();
            return objSubagentCom.getCurrentSubAgentInfo();
        }
      
        public static AgentInformation getCurrentAgent()  //works only when subagent and agent logins
        {
            AgentCom objAgentCom = new AgentCom();
            return objAgentCom.getCurrentAgentInfo();
        }
        public static string getAddressInString(Address address)
        {
            string fullAddress = "";
            if (address != null)
            {
                string LineOne = (address.addressLineOne != "") ? address.addressLineOne : "";
                string LineTwo = (address.addressLineTwo != "") ? address.addressLineTwo : "";
                string country = (address.country != null) ? address.country.name : "";
                string division = (address.division != null) ? address.division.name : "";
                string district = (address.district != null) ? address.district.title : "";
                string thana = (address.thana != null) ? address.thana.title : "";
                string postalCode = (address.postalCode != null) ? address.postalCode.postalCode : "";

                fullAddress += LineOne;
                fullAddress += (LineOne != "") ? ", " + LineTwo : LineTwo;
                fullAddress += (LineTwo != "") ? ", Division: " + division : "Division: " + division;
                fullAddress += ", District: " + district;
                fullAddress += ", Thana: " + thana;
                fullAddress += ", Postal Code: " + postalCode;
            }

            return fullAddress;
        }

        public static List<NomineeRelationship> GetAllRelationships()
        {
            UtilityCom objUtilityCom = new UtilityCom();
            return objUtilityCom.GetAllRelationships();
        }

        public static bool isRoleExist(string roleName)
        {
            bool roleExist = false;
            foreach (string thisrole in SessionInfo.roles)
            {
                if (thisrole == roleName)
                {
                    roleExist = true;
                    break;
                }
                else
                {
                    roleExist = false;
                }
            }
            return roleExist;
        }
        public static bool isRightExist(Rights singleRight)
        {
            bool rightExist = false;
            foreach (string thisright in SessionInfo.rights)
            {
                if (thisright == singleRight.ToString())
                {
                    rightExist = true;
                    break;
                }
                else
                {
                    rightExist = false;
                }
            }
            return rightExist;
        }
        public static DocumentType genDocumentType(long id, string name, string code)
        {
            DocumentType docTypeInfo = new DocumentType();
            docTypeInfo.id = id;
            docTypeInfo.name = name;
            docTypeInfo.code = code;
            return docTypeInfo;
        }

        public static CisOwnerType genCisOwnerType(int id, string ownerCode, string description)
        {
            CisOwnerType objCisOwnerType = new CisOwnerType();
            objCisOwnerType.id = id;
            objCisOwnerType.ownerCode = ownerCode;
            objCisOwnerType.description = description;
            return objCisOwnerType;
        }
        public static Address genBusinessAddress(long id, string addressLineOne, string addressLineTwo, Thana thana, PostalCode postalCode, District district, Division division, Country country)
        {
            Address address = new Address();
            address.id = id;
            address.addressLineOne = addressLineOne;
            address.addressLineTwo = addressLineTwo;
            address.thana = thana;
            address.postalCode = postalCode;
            address.district = district;
            address.division = division;
            address.country = country;
            return address;
        }
        public static Address genPermanentAddress(long id, string addressLineOne, string addressLineTwo, Thana thana, PostalCode postalCode, District district, Division division, Country country)
        {
            Address address = new Address();
            address.id = id;
            address.addressLineOne = addressLineOne;
            address.addressLineTwo = addressLineTwo;
            address.thana = thana;
            address.postalCode = postalCode;
            address.district = district;
            address.division = division;
            address.country = country;
            return address;
        }
        public static Address genPresentAddress(long id, string addressLineOne, string addressLineTwo, Thana thana, PostalCode postalCode, District district, Division division, Country country)
        {
            Address address = new Address();
            address.id = id;
            address.addressLineOne = addressLineOne;
            address.addressLineTwo = addressLineTwo;
            address.thana = thana;
            address.postalCode = postalCode;
            address.district = district;
            address.division = division;
            address.country = country;
            return address;
        }
        public static CisType genCisType(long id, string description, string code)
        {
            CisType cistype = new CisType();
            cistype.id = id;
            cistype.description = description;
            cistype.code = code;
            return cistype;
        }
        public static CisInstituteType genCisInstituteType(long id, string description)
        {
            CisInstituteType cisInstituteType = new CisInstituteType();
            cisInstituteType.id = id;
            cisInstituteType.description = description;
            return cisInstituteType;
        }
        public static List<CisOwnerType> getOwnerTypes(int cisTypeId)
        {
            UtilityCom objUtil = new UtilityCom();
            List<CisOwnerType> ownerTypes = objUtil.getOwnerTypesByCisType(cisTypeId);
            return ownerTypes;
        }
        public static void fillOwnerTypesByCisType(ref ComboBox cmbOwnerType, int cisTypeId)
        {
            UtilityCom objUtil = new UtilityCom();
            try
            {
                List<CisOwnerType> ownerTypes = objUtil.getOwnerTypesByCisType(cisTypeId);
                BindingSource bs = new BindingSource();
                bs.DataSource = ownerTypes;
                fillComboBox(cmbOwnerType, bs, "description", "id");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void fillOwnerTypesByCisType(ref MetroComboBox cmbOwnerType, int cisTypeId)
        {
            UtilityCom objUtil = new UtilityCom();
            try
            {
                List<CisOwnerType> ownerTypes = objUtil.getOwnerTypesByCisType(cisTypeId);
                BindingSource bs = new BindingSource();
                bs.DataSource = ownerTypes;
                fillComboBox(cmbOwnerType, bs, "description", "id");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //public static void fillSectorType(ref ComboBox cmbSectorType, string sectorCode)
        //{
        //    UtilityCom objUtil = new UtilityCom();
        //    try
        //    {
        //        List<CisOwnerType> ownerTypes = objUtil.getOwnerTypesByCisType(sectorCode);
        //        BindingSource bs = new BindingSource();
        //        bs.DataSource = ownerTypes;
        //        fillComboBox(cmbSectorType, bs, "name", "code");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            if (byteArrayIn != null)
            {
                MemoryStream ms = new MemoryStream(byteArrayIn);
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
            else
                return null;
        }
        public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            if (imageIn != null)
            {
                MemoryStream ms = new MemoryStream();
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();
            }
            else
                return null;
        }
        public static NomineeInformation genNomineeInformation(long id, IndividualInformation individualInformation, AccountInformation accountInformation, ConsumerApplication consumerApplication, string relation, int ratio, byte[] photo, string instruction)
        {
            NomineeInformation objNomineeInformation = new NomineeInformation();
            objNomineeInformation.id = id;
            objNomineeInformation.individualInformation = individualInformation;
            objNomineeInformation.accountInformation = accountInformation;
            objNomineeInformation.consumerApplication = consumerApplication;
            objNomineeInformation.relation = relation;
            objNomineeInformation.ratio = ratio;
            objNomineeInformation.photo = photo;
            objNomineeInformation.instruction = instruction;
            return objNomineeInformation;
        }

        public static NomineeInformationTemp genNomineeInformationTemp(long id, IndividualInformation individualInformation, string relation, int ratio, byte[] photo, string instruction)
        {
            NomineeInformationTemp objNomineeInformation = new NomineeInformationTemp();
            objNomineeInformation.id = id;
            objNomineeInformation.individualInformation = individualInformation;
            //objNomineeInformation.accountInformation = accountInformation;
            //objNomineeInformation.consumerApplication = consumerApplication;
            objNomineeInformation.relation = relation;
            objNomineeInformation.ratio = ratio;
            objNomineeInformation.photo = photo;
            objNomineeInformation.instruction = instruction;
            return objNomineeInformation;
        }

        public static ConsumerApplication genConsumerApplication(long id, string consumerName, string nationalId, string mobileNo, string referenceNumber, byte[] photo, ApplicationStatus applicationStatus, CustomerInformation customer, List<NomineeInformationTemp> nominees, string subAgentName, long? creationDate, AgentProduct agentProduct, long kycProfile, int accountOperated, long txnProfileSetNo, decimal? openingAmount, string intrducerAccNumber, string remarks)
        {
            ConsumerApplication objConsumerApplication = new ConsumerApplication();
            objConsumerApplication.id = id;
            objConsumerApplication.consumerName = consumerName;
            objConsumerApplication.nationalId = nationalId;
            objConsumerApplication.mobileNo = mobileNo;
            objConsumerApplication.referenceNumber = referenceNumber;
            objConsumerApplication.photo = photo;
            objConsumerApplication.applicationStatus = applicationStatus;
            objConsumerApplication.customer = customer;
            //----objConsumerApplication.nominees = nominees;
            objConsumerApplication.subAgentName = subAgentName;
            objConsumerApplication.creationDate = creationDate;
            objConsumerApplication.agentProduct = agentProduct;
            objConsumerApplication.kycProfileNo = kycProfile;
            objConsumerApplication.numberOfOperator = accountOperated;
            objConsumerApplication.txnProfileSetNo = txnProfileSetNo;
            //----objConsumerApplication.openingAmount = openingAmount;
            objConsumerApplication.intrducerAccNumber = intrducerAccNumber;
            //----objConsumerApplication.remarks = remarks;
            return objConsumerApplication;
        }
        public static AccountInformation genAccountInfo(long id, string accountNumber, string accountTitle, Boolean isActive, AgentInformation agent, ConsumerInformation consumerInformation, List<NomineeInformation> nominees)
        {
            AccountInformation objAgentAccountInfo = new AccountInformation();
            objAgentAccountInfo.id = id;
            objAgentAccountInfo.accountNumber = accountNumber;
            objAgentAccountInfo.accountTitle = accountTitle;
            //objAgentAccountInfo.isActive = isActive;
            objAgentAccountInfo.agent = agent;
            objAgentAccountInfo.consumerInformation = consumerInformation;
            //objAgentAccountInfo.nominees = nominees;
            return objAgentAccountInfo;
        }

        public static DateTime getDateFromLong(long? unixDate)
        {
            //long unixDate = 1297380023295;
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime date = start.AddMilliseconds((long)unixDate).ToLocalTime();
            return date;
        }

        public static string getBDFormattedDateFromLong(long? unixDate)
        {
            return getDateFromLong(unixDate).ToString("dd'/'MM'/'yyyy");
        }

        public static long GetLongDate(DateTime myDate)
        {
            DateTime dateTime = myDate;
            return dateTime.ToUnixTime();
        }


        public static void setSectorCode(ref List<SectorCodeInfo> publicSectorCodes, long sectorType)
        {


        }

        public static void GetSectorCodeList(ref ComboBox cmdSectorCode, ref List<SectorCodeInfo> publicSectorCodes, ref List<SectorCodeInfo> privateSectorCodes)
        {
            UtilityCom objUtil = new UtilityCom();
            try
            {
                List<SectorCodeInfo> SectorCodeList = objUtil.getcmbSectorCodeList();

                publicSectorCodes.Clear();
                privateSectorCodes.Clear();

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

                BindingSource bs = new BindingSource();

                SectorCodeInfo sectorCodeSelect = new SectorCodeInfo();
                sectorCodeSelect.name = "(Select)";

                SectorCodeList.Insert(0, sectorCodeSelect);

                bs.DataSource = SectorCodeList.OrderBy(x => x.name).ToList();
                fillComboBox(cmdSectorCode, bs, "NameWithCode", "code");



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public static List<CisType> getCustomerTypes()
        {
            UtilityCom objUtil = new UtilityCom();
            if (CmbCustomerTypes == null) CmbCustomerTypes = objUtil.getcmbCustomerTypes();
            List<CisType> cisTypes = CmbCustomerTypes;
            return cisTypes;
        }
        public static void fillCustomerTypes(ref ComboBox cmbCustomerType)
        {
            UtilityCom objUtil = new UtilityCom();
            try
            {
                List<CisType> cisTypes = objUtil.getcmbCustomerTypes();
                BindingSource bs = new BindingSource();
                bs.DataSource = cisTypes;
                fillComboBox(cmbCustomerType, bs, "description", "id");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void fillCustomerTypes(ref MetroComboBox cmbCustomerType)
        {
            UtilityCom objUtil = new UtilityCom();
            try
            {
                List<CisType> cisTypes = objUtil.getcmbCustomerTypes();
                BindingSource bs = new BindingSource();
                bs.DataSource = cisTypes;
                fillComboBox(cmbCustomerType, bs, "description", "id");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void fillInstitutionTypes(ref ComboBox cmbInstitutionType)
        {
            UtilityCom objUtil = new UtilityCom();
            try
            {
                if (InstitutionTypes == null) InstitutionTypes = objUtil.getcmbInstitutionTypes();
                List<CisInstituteType> divisions = InstitutionTypes;
                BindingSource bs = new BindingSource();
                bs.DataSource = divisions;
                fillComboBox(cmbInstitutionType, bs, "description", "id");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void fillInstitutionTypes(ref MetroComboBox cmbInstitutionType)
        {
            UtilityCom objUtil = new UtilityCom();
            try
            {
                if (InstitutionTypes == null) InstitutionTypes = objUtil.getcmbInstitutionTypes();
                List<CisInstituteType> divisions = InstitutionTypes;
                BindingSource bs = new BindingSource();
                bs.DataSource = divisions;
                fillComboBox(cmbInstitutionType, bs, "description", "id");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static Occupation genClientOccupation(ComboBox cmbOccupation)
        {
            Occupation newOccupation = new Occupation();
            newOccupation.id = Convert.ToInt32(cmbOccupation.SelectedValue);
            newOccupation.description = cmbOccupation.Text;
            return newOccupation;
        }
        public static List<Address> appendIndividualAddress(ref IndividualInformation individualInfo)
        {
            if (individualInfo != null)
            {
                int addrCount = (commonAddresses != null) ? commonAddresses.Count : 0;
                if (individualInfo.presentAddress != null)
                {
                    if (isAddressExist(individualInfo.presentAddress))
                    {
                        commonAddresses.RemoveAt((int)individualInfo.presentAddress.commonAddressIndex);
                        individualInfo.presentAddress.commonAddressIndex = individualInfo.presentAddress.commonAddressIndex;
                        individualInfo.presentAddress.commonAddressName = individualInfo.firstName + " " + individualInfo.lastName + "'s Present Address";
                        commonAddresses.Insert((int)individualInfo.presentAddress.commonAddressIndex, individualInfo.presentAddress);
                    }
                    else
                    {
                        individualInfo.presentAddress.commonAddressIndex = addrCount;
                        individualInfo.presentAddress.commonAddressName = individualInfo.firstName + " " + individualInfo.lastName + "'s Present Address";
                        commonAddresses.Add(individualInfo.presentAddress);
                    }
                    addrCount++;
                }
                if (individualInfo.permanentAddress != null)
                {
                    if (isAddressExist(individualInfo.permanentAddress))
                    {
                        commonAddresses.RemoveAt((int)individualInfo.permanentAddress.commonAddressIndex);
                        individualInfo.permanentAddress.commonAddressIndex = individualInfo.permanentAddress.commonAddressIndex;
                        individualInfo.permanentAddress.commonAddressName = individualInfo.firstName + " " + individualInfo.lastName + "'s Permanent Address";
                        commonAddresses.Insert((int)individualInfo.permanentAddress.commonAddressIndex, individualInfo.permanentAddress);
                    }
                    else
                    {
                        individualInfo.permanentAddress.commonAddressIndex = addrCount;
                        individualInfo.permanentAddress.commonAddressName = individualInfo.firstName + " " + individualInfo.lastName + "'s Permanent Address";
                        commonAddresses.Add(individualInfo.permanentAddress);
                    }
                    addrCount++;
                }
            }
            return commonAddresses;
        }
        private static bool isAddressExist(Address addr)
        {
            if (addr.id != 0 && addr.commonAddressIndex != null)
                return true;
            else
            {
                if (addr.commonAddressIndex != null)
                    return true;
                else
                    return false;
            }
        }
        public static List<Address> appendCustomerAddress(ref CustomerInformation customerInfo)
        {

            if (customerInfo != null)
            {
                int addrCount = (commonAddresses != null) ? commonAddresses.Count : 0;
                if (customerInfo.businessAddress != null)
                {
                    if (isAddressExist(customerInfo.businessAddress))
                    {
                        commonAddresses.RemoveAt((int)customerInfo.businessAddress.commonAddressIndex);
                        customerInfo.businessAddress.commonAddressIndex = customerInfo.businessAddress.commonAddressIndex;
                        customerInfo.businessAddress.commonAddressName = customerInfo.title + "'s Business Address";
                        commonAddresses.Insert((int)customerInfo.businessAddress.commonAddressIndex, customerInfo.businessAddress);
                    }
                    else
                    {
                        customerInfo.businessAddress.commonAddressIndex = addrCount;
                        customerInfo.businessAddress.commonAddressName = customerInfo.title + "'s Business Address";
                        commonAddresses.Add(customerInfo.businessAddress);
                    }
                    addrCount++;
                }
                if (customerInfo.presentAddress != null)
                {
                    if (isAddressExist(customerInfo.presentAddress))
                    {
                        commonAddresses.RemoveAt((int)customerInfo.presentAddress.commonAddressIndex);
                        customerInfo.presentAddress.commonAddressIndex = customerInfo.presentAddress.commonAddressIndex;
                        customerInfo.presentAddress.commonAddressName = customerInfo.title + "'s Present Address";
                        commonAddresses.Insert((int)customerInfo.presentAddress.commonAddressIndex, customerInfo.presentAddress);
                    }
                    else
                    {
                        customerInfo.presentAddress.commonAddressIndex = addrCount;
                        customerInfo.presentAddress.commonAddressName = customerInfo.title + "'s Present Address";
                        commonAddresses.Add(customerInfo.presentAddress);
                    }
                    addrCount++;
                }
                if (customerInfo.permanentAddress != null)
                {
                    if (isAddressExist(customerInfo.permanentAddress))
                    {
                        commonAddresses.RemoveAt((int)customerInfo.permanentAddress.commonAddressIndex);
                        customerInfo.permanentAddress.commonAddressIndex = customerInfo.permanentAddress.commonAddressIndex;
                        customerInfo.permanentAddress.commonAddressName = customerInfo.title + "'s Permanent Address";
                        commonAddresses.Insert((int)customerInfo.permanentAddress.commonAddressIndex, customerInfo.permanentAddress);
                    }
                    else
                    {
                        customerInfo.permanentAddress.commonAddressIndex = addrCount;
                        customerInfo.permanentAddress.commonAddressName = customerInfo.title + "'s Permanent Address";
                        commonAddresses.Add(customerInfo.permanentAddress);
                        addrCount++;
                    }
                }
            }
            return commonAddresses;
        }
        public static Address getSelectedAddress(CommonAddressList addrList)
        {
            if (addrList == CommonAddressList.Individual_Contact_Address)
                return CommonAddresses.IndividualContactAddress;
            if (addrList == CommonAddressList.Individual_Permanent_Address)
                return CommonAddresses.IndividualPermanentAddress;
            if (addrList == CommonAddressList.Customer_Business_Address)
                return CommonAddresses.CustomerBusinessAddress;
            if (addrList == CommonAddressList.Customer_Contact_Address)
                return CommonAddresses.CustomerContactAddress;
            if (addrList == CommonAddressList.Customer_Permanent_Address)
                return CommonAddresses.CustomerPermanentAddress;
            else
                return null;
        }

        public static void setAddress(Address addr, ref TextBox txtAddressOne, ref TextBox txtAddressTwo, ref ComboBox cmbPostalCode, ref ComboBox cmbThana, ref ComboBox cmbDistrict, ref ComboBox cmbDivision, ref ComboBox cmbCountry)
        {
            txtAddressOne.Text = string.Empty;
            txtAddressTwo.Text = string.Empty;
            cmbPostalCode.DataSource = null;
            cmbThana.DataSource = null;
            cmbDistrict.DataSource = null;
            cmbDivision.DataSource = null;
            cmbCountry.DataSource = null;
            if (addr != null)
            {
                txtAddressOne.Text = addr.addressLineOne;
                txtAddressTwo.Text = addr.addressLineTwo;
                if (addr.country != null)
                {
                    if (addr.country.id != 0)
                    {
                        UtilityServices.fillCountries(ref cmbCountry);
                        cmbCountry.SelectedValue = addr.country.id;
                    }
                }
                if (addr.division != null)
                {
                    if (addr.division.id != 0)
                    {
                        UtilityServices.fillDivisions(ref cmbDivision);
                        cmbDivision.SelectedValue = addr.division.id;

                        if (addr.district != null)
                        {
                            if (addr.district.id != 0)
                            {
                                UtilityServices.fillDistrictsByDivision(ref cmbDistrict, Convert.ToInt32(addr.division.id));
                                cmbDistrict.SelectedValue = addr.district.id;
                                if (addr.thana != null)
                                {
                                    if (addr.thana.id != 0)
                                    {
                                        UtilityServices.fillThanaByDistrict(ref cmbThana, Convert.ToInt32(addr.district.id));
                                        cmbThana.SelectedValue = addr.thana.id;
                                    }
                                }
                                if (addr.postalCode != null)
                                {
                                    if (addr.postalCode.id != 0)
                                    {
                                        UtilityServices.fillPostalCodeByDistrict(ref cmbPostalCode, Convert.ToInt32(addr.district.id));
                                        cmbPostalCode.SelectedValue = addr.postalCode.id;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void setAddress(Address addr, ref MetroTextBox txtAddressOne, ref MetroTextBox txtAddressTwo, ref MetroComboBox cmbPostalCode, ref MetroComboBox cmbThana, ref MetroComboBox cmbDistrict, ref MetroComboBox cmbDivision, ref MetroComboBox cmbCountry)
        {
            txtAddressOne.Text = string.Empty;
            txtAddressTwo.Text = string.Empty;
            cmbPostalCode.DataSource = null;
            cmbThana.DataSource = null;
            cmbDistrict.DataSource = null;
            cmbDivision.DataSource = null;
            cmbCountry.DataSource = null;
            if (addr != null)
            {
                txtAddressOne.Text = addr.addressLineOne;
                txtAddressTwo.Text = addr.addressLineTwo;
                if (addr.country != null)
                {
                    if (addr.country.id != 0)
                    {
                        UtilityServices.fillCountries(ref cmbCountry);
                        cmbCountry.SelectedValue = addr.country.id;
                    }
                }
                if (addr.division != null)
                {
                    if (addr.division.id != 0)
                    {
                        UtilityServices.fillDivisions(ref cmbDivision);
                        cmbDivision.SelectedValue = addr.division.id;

                        if (addr.district != null)
                        {
                            if (addr.district.id != 0)
                            {
                                UtilityServices.fillDistrictsByDivision(ref cmbDistrict, Convert.ToInt32(addr.division.id));
                                cmbDistrict.SelectedValue = addr.district.id;
                                if (addr.thana != null)
                                {
                                    if (addr.thana.id != 0)
                                    {
                                        UtilityServices.fillThanaByDistrict(ref cmbThana, Convert.ToInt32(addr.district.id));
                                        cmbThana.SelectedValue = addr.thana.id;
                                    }
                                }
                                if (addr.postalCode != null)
                                {
                                    if (addr.postalCode.id != 0)
                                    {
                                        UtilityServices.fillPostalCodeByDistrict(ref cmbPostalCode, Convert.ToInt32(addr.district.id));
                                        cmbPostalCode.SelectedValue = addr.postalCode.id;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void copyAddress(TextBox txtAddressOneFrom, TextBox txtAddressTwoFrom, ComboBox cmbPostalCodeFrom, ComboBox cmbThanaFrom, ComboBox cmbDistrictFrom, ComboBox cmbDivisionFrom, ComboBox cmbCountryFrom, ref TextBox txtAddressOne, ref TextBox txtAddressTwo, ref ComboBox cmbPostalCode, ref ComboBox cmbThana, ref ComboBox cmbDistrict, ref ComboBox cmbDivision, ref ComboBox cmbCountry)
        {
            txtAddressOne.Text = string.Empty;
            txtAddressTwo.Text = string.Empty;
            cmbPostalCode.DataSource = null;
            cmbThana.DataSource = null;
            cmbDistrict.DataSource = null;
            cmbDivision.DataSource = null;
            cmbCountry.DataSource = null;
            //if (addr != null)
            //{
            txtAddressOne.Text = txtAddressOneFrom.Text;
            txtAddressTwo.Text = txtAddressTwoFrom.Text;
            if (cmbCountryFrom.SelectedValue != null)
            {
                UtilityServices.fillCountries(ref cmbCountry);
                cmbCountry.SelectedValue = cmbCountryFrom.SelectedValue;
            }
            if (cmbDivisionFrom.SelectedValue != null)
            {
                UtilityServices.fillDivisions(ref cmbDivision);
                cmbDivision.SelectedValue = cmbDivisionFrom.SelectedValue;

                if (cmbDistrictFrom.SelectedValue != null)
                {
                    UtilityServices.fillDistrictsByDivision(ref cmbDistrict, Convert.ToInt32(cmbDivisionFrom.SelectedValue));
                    cmbDistrict.SelectedValue = cmbDistrictFrom.SelectedValue;
                    if (cmbThanaFrom.SelectedValue != null)
                    {
                        UtilityServices.fillThanaByDistrict(ref cmbThana, Convert.ToInt32(cmbDistrictFrom.SelectedValue));
                        cmbThana.SelectedValue = cmbThanaFrom.SelectedValue;
                    }
                    if (cmbPostalCodeFrom.SelectedValue != null)
                    {
                        UtilityServices.fillPostalCodeByDistrict(ref cmbPostalCode, Convert.ToInt32(cmbDistrictFrom.SelectedValue));
                        cmbPostalCode.SelectedValue = cmbPostalCodeFrom.SelectedValue;
                    }
                }
            }
            //}
        }

        public static void copyAddress(MetroTextBox txtAddressOneFrom, MetroTextBox txtAddressTwoFrom, MetroComboBox cmbPostalCodeFrom, MetroComboBox cmbThanaFrom, MetroComboBox cmbDistrictFrom, MetroComboBox cmbDivisionFrom, MetroComboBox cmbCountryFrom, ref MetroTextBox txtAddressOne, ref MetroTextBox txtAddressTwo, ref MetroComboBox cmbPostalCode, ref MetroComboBox cmbThana, ref MetroComboBox cmbDistrict, ref MetroComboBox cmbDivision, ref MetroComboBox cmbCountry)
        {
            txtAddressOne.Text = string.Empty;
            txtAddressTwo.Text = string.Empty;
            cmbPostalCode.DataSource = null;
            cmbThana.DataSource = null;
            cmbDistrict.DataSource = null;
            cmbDivision.DataSource = null;
            cmbCountry.DataSource = null;
            //if (addr != null)
            //{
            txtAddressOne.Text = txtAddressOneFrom.Text;
            txtAddressTwo.Text = txtAddressTwoFrom.Text;
            if (cmbCountryFrom.SelectedValue != null)
            {
                UtilityServices.fillCountries(ref cmbCountry);
                cmbCountry.SelectedValue = cmbCountryFrom.SelectedValue;
            }
            if (cmbDivisionFrom.SelectedValue != null)
            {
                UtilityServices.fillDivisions(ref cmbDivision);
                cmbDivision.SelectedValue = cmbDivisionFrom.SelectedValue;

                if (cmbDistrictFrom.SelectedValue != null)
                {
                    UtilityServices.fillDistrictsByDivision(ref cmbDistrict, Convert.ToInt32(cmbDivisionFrom.SelectedValue));
                    cmbDistrict.SelectedValue = cmbDistrictFrom.SelectedValue;
                    if (cmbThanaFrom.SelectedValue != null)
                    {
                        UtilityServices.fillThanaByDistrict(ref cmbThana, Convert.ToInt32(cmbDistrictFrom.SelectedValue));
                        cmbThana.SelectedValue = cmbThanaFrom.SelectedValue;
                    }
                    if (cmbPostalCodeFrom.SelectedValue != null)
                    {
                        UtilityServices.fillPostalCodeByDistrict(ref cmbPostalCode, Convert.ToInt32(cmbDistrictFrom.SelectedValue));
                        cmbPostalCode.SelectedValue = cmbPostalCodeFrom.SelectedValue;
                    }
                }
            }
            //}
        }

        public static Address genClientAddress(string clientAddress1, string clientAddress2, ComboBox cmbPostalCode, ComboBox cmbThana, ComboBox cmbDistrict, ComboBox cmbDivision, ComboBox cmbCountry, int? commonAddressIndex, string commonAddressName)
        {
            Address newAddress = new Address();
            //newAddress.id = 
            newAddress.addressLineOne = clientAddress1;
            newAddress.addressLineTwo = clientAddress2;
            newAddress.postalCode = (cmbPostalCode != null) ? ((cmbPostalCode.Items.Count > 0) ? genClientPostalCode(cmbPostalCode, cmbDistrict, cmbDivision) : null) : null;
            newAddress.thana = (cmbThana != null) ? ((cmbThana.Items.Count > 0) ? genClientThana(cmbThana, cmbDistrict, cmbDivision) : null) : null;
            newAddress.district = (cmbDistrict != null) ? ((cmbDistrict.Items.Count > 0) ? genClientDistrict(cmbDistrict, cmbDivision) : null) : null;
            newAddress.division = (cmbDivision != null) ? ((cmbDivision.Items.Count > 0) ? genclientDivision(cmbDivision) : null) : null;
            newAddress.country = (cmbCountry != null) ? ((cmbCountry.Items.Count > 0) ? genClientCountry(cmbCountry) : null) : null;
            newAddress.commonAddressIndex = commonAddressIndex;
            newAddress.commonAddressName = commonAddressName;
            return newAddress;
        }
        public static Thana genClientThana(ComboBox cmbThana, ComboBox cmbDistrict, ComboBox cmbDivision)
        {
            Thana objThana = new Thana();
            objThana.id = Convert.ToInt32(cmbThana.SelectedValue);
            objThana.title = cmbThana.Text;
            objThana.district = (cmbDistrict != null) ? ((cmbDistrict.Items.Count > 0) ? genClientDistrict(cmbDistrict, cmbDivision) : null) : null;
            return objThana;
        }
        public static PostalCode genClientPostalCode(ComboBox cmbPostalCode, ComboBox cmbDistrict, ComboBox cmbDivision)
        {
            PostalCode objPostalCode = new PostalCode();
            objPostalCode.id = Convert.ToInt32(cmbPostalCode.SelectedValue);
            objPostalCode.postalCode = cmbPostalCode.Text;
            //objPostalCode.area =
            objPostalCode.district = (cmbDistrict != null) ? ((cmbDistrict.Items.Count > 0) ? genClientDistrict(cmbDistrict, cmbDivision) : null) : null;
            return objPostalCode;
        }
        public static District genClientDistrict(ComboBox cmbDistrict, ComboBox cmbDivision)
        {
            District objDistrict = new District();
            objDistrict.id = Convert.ToInt32(cmbDistrict.SelectedValue);
            objDistrict.title = cmbDistrict.Text;
            objDistrict.division = (cmbDivision != null) ? ((cmbDivision.Items.Count > 0) ? genclientDivision(cmbDivision) : null) : null;
            return objDistrict;
        }
        public static Division genclientDivision(ComboBox cmbDivision)
        {
            Division objDivision = new Division();
            objDivision.id = Convert.ToInt32(cmbDivision.SelectedValue);
            objDivision.name = cmbDivision.Text;
            return objDivision;
        }
        public static Country genClientCountry(ComboBox cmbCountry)
        {
            Country objCountry = new Country();
            objCountry.id = Convert.ToInt32(cmbCountry.SelectedValue);
            objCountry.name = cmbCountry.Text;
            return objCountry;
        }
        public static void fillBranches(ref ComboBox cmbBranch)
        {
            UtilityCom objUtil = new UtilityCom();
            try
            {
                List<Branch> allBranch = objUtil.getBranches();
                BindingSource bs = new BindingSource();
                bs.DataSource = allBranch;
                fillComboBox(cmbBranch, bs, "name", "id");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void fillDistrictsAll(ref ComboBox cmbDistrict)
        {
            UtilityCom objUtil = new UtilityCom();
            try
            {
                if (AllDistricts == null) AllDistricts = objUtil.getAllDistricts();
                List<District> districts = AllDistricts;
                BindingSource bs = new BindingSource();
                bs.DataSource = districts;
                fillComboBox(cmbDistrict, bs, "title", "id");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void fillOccupation(ref ComboBox cmbOccupation)
        {
            UtilityCom objUtil = new UtilityCom();
            try
            {
                if (Occupations == null) Occupations = objUtil.getOccupations();
                List<Occupation> districts = Occupations;
                BindingSource bs = new BindingSource();
                bs.DataSource = districts;
                fillComboBox(cmbOccupation, bs, "description", "id");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void fillPostalCodeByDistrict(ref ComboBox cmbDistrict, int districtId)
        {
            List<PostalCode> postalCodes = new List<PostalCode>();
            try
            {
                if (districtId > 0)
                {
                    UtilityCom objUtil = new UtilityCom();
                    postalCodes = objUtil.getPostalCodes(districtId);
                }
                BindingSource bs = new BindingSource();
                bs.DataSource = postalCodes;
                fillComboBox(cmbDistrict, bs, "postalCode", "id");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void fillPostalCodeByDistrict(ref MetroComboBox cmbDistrict, int districtId)
        {
            List<PostalCode> postalCodes = new List<PostalCode>();
            try
            {
                if (districtId > 0)
                {
                    UtilityCom objUtil = new UtilityCom();
                    postalCodes = objUtil.getPostalCodes(districtId);
                }
                BindingSource bs = new BindingSource();
                bs.DataSource = postalCodes;
                fillComboBox(cmbDistrict, bs, "postalCode", "id");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void fillThanaByDistrict(ref ComboBox cmbDistrict, int districtId)
        {
            List<Thana> thanas = new List<Thana>();
            try
            {
                if (districtId > 0)
                {
                    UtilityCom objUtil = new UtilityCom();
                    thanas = objUtil.getThanas(districtId);
                }
                BindingSource bs = new BindingSource();
                bs.DataSource = thanas;
                fillComboBox(cmbDistrict, bs, "title", "id");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void fillThanaByDistrict(ref MetroComboBox cmbDistrict, int districtId)
        {
            List<Thana> thanas = new List<Thana>();
            try
            {
                if (districtId > 0)
                {
                    UtilityCom objUtil = new UtilityCom();
                    thanas = objUtil.getThanas(districtId);
                }
                BindingSource bs = new BindingSource();
                bs.DataSource = thanas;
                fillComboBox(cmbDistrict, bs, "title", "id");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void fillDistrictsByDivision(ref ComboBox cmbDistrict, int divisionId)
        {
            List<District> districts = new List<District>();
            try
            {
                if (divisionId > 0)
                {
                    UtilityCom objUtil = new UtilityCom();
                    districts = objUtil.getDistricts(divisionId);
                }
                BindingSource bs = new BindingSource();
                bs.DataSource = districts;
                fillComboBox(cmbDistrict, bs, "title", "id");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void fillDistrictsByDivision(ref MetroComboBox cmbDistrict, int divisionId)
        {
            List<District> districts = new List<District>();
            try
            {
                if (divisionId > 0)
                {
                    UtilityCom objUtil = new UtilityCom();
                    districts = objUtil.getDistricts(divisionId);
                }
                BindingSource bs = new BindingSource();
                bs.DataSource = districts;
                fillComboBox(cmbDistrict, bs, "title", "id");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void fillDivisions(ref ComboBox cmbDivision)
        {
            UtilityCom objUtil = new UtilityCom();
            try
            {
                if (Divisions == null) Divisions = objUtil.getDivisions();
                List<Division> divisions = Divisions;
                BindingSource bs = new BindingSource();
                bs.DataSource = divisions;
                fillComboBox(cmbDivision, bs, "name", "id");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void fillDivisions(ref MetroComboBox cmbDivision)
        {
            UtilityCom objUtil = new UtilityCom();
            try
            {
                if (Divisions == null) Divisions = objUtil.getDivisions();
                List<Division> divisions = Divisions;
                BindingSource bs = new BindingSource();
                bs.DataSource = divisions;
                fillComboBox(cmbDivision, bs, "name", "id");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void fillCountries(ref ComboBox cmbCountry)
        {
            UtilityCom objUtil = new UtilityCom();
            try
            {
                if (Countries == null) Countries = objUtil.getCountries();
                List<Country> countries = Countries;
                BindingSource bs = new BindingSource();
                bs.DataSource = countries;
                fillComboBox(cmbCountry, bs, "name", "id");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void fillCountries(ref MetroComboBox cmbCountry)
        {
            UtilityCom objUtil = new UtilityCom();
            try
            {
                if (Countries == null) Countries = objUtil.getCountries();
                List<Country> countries = Countries;
                BindingSource bs = new BindingSource();
                bs.DataSource = countries;
                fillComboBox(cmbCountry, bs, "name", "id");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void fillComboBox(ComboBox cmb, BindingSource bs, string displayMember, string valueMember)
        {
            cmb.DataSource = bs;
            cmb.DisplayMember = displayMember;
            cmb.ValueMember = valueMember;
            //cmb.Text = "Select";
            //System.Windows.Controls.ComboBoxItem itemSelect = new System.Windows.Controls.ComboBoxItem();
            //itemSelect.Uid = "0";
            //itemSelect.Name = "<Select Religion>";
            //Ilist.Insert(0, itemSelect);
        }
        private ImageCodecInfo GetEncoderInfo(ImageFormat format)
        {
            return ImageCodecInfo.GetImageDecoders().SingleOrDefault(c => c.FormatID == format.Guid);
        }
        private static long getImageLength(Image img)
        {
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.Length;
        }
        public static Image getResizedImage(Bitmap image, long maxImageSize, int quality, string filePath)
        {
            int maxWidth = image.Width;
            int maxHeight = image.Height;
            long imgLength = getImageLength(image);
            Bitmap newImage = new Bitmap(maxWidth, maxHeight, PixelFormat.Format24bppRgb);
            do
            {

                // Get the image's original width and height
                int originalWidth = image.Width;
                int originalHeight = image.Height;

                // To preserve the aspect ratio
                float ratioX = (float)maxWidth / (float)originalWidth;
                float ratioY = (float)maxHeight / (float)originalHeight;
                float ratio = Math.Min(ratioX, ratioY);

                // New width and height based on aspect ratio
                int newWidth = (int)(originalWidth * ratio);
                int newHeight = (int)(originalHeight * ratio);

                // Convert other formats (including CMYK) to RGB.
                newImage = new Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb);

                // Draws the image in the specified size with quality mode set to HighQuality
                using (Graphics graphics = Graphics.FromImage(newImage))
                {
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.DrawImage(image, 0, 0, newWidth, newHeight);
                }

                //// Get an ImageCodecInfo object that represents the JPEG codec.
                //ImageCodecInfo imageCodecInfo = this.GetEncoderInfo(ImageFormat.Jpeg);

                //// Create an Encoder object for the Quality parameter.
                //System.Drawing.Imaging.Encoder encoder = System.Drawing.Imaging.Encoder.Quality;

                //// Create an EncoderParameters object. 
                //EncoderParameters encoderParameters = new EncoderParameters(1);

                //// Save the image as a JPEG file with quality level.
                //EncoderParameter encoderParameter = new EncoderParameter(encoder, quality);
                //encoderParameters.Param[0] = encoderParameter;
                //newImage.Save(filePath, imageCodecInfo, encoderParameters);
                imgLength = getImageLength(newImage);
                maxWidth -= (int)(maxWidth * .1);
                maxHeight -= (int)(maxHeight * .1); ;

            } while (imgLength > maxImageSize);
            return newImage;
        }
        public static void uploadPhoto(ref OpenFileDialog open, ref PictureBox picbox)
        {
            try
            {
                // open file dialog
                open = new OpenFileDialog();
                // image filters
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";

                if (open.ShowDialog() == DialogResult.OK)
                {
                    Bitmap imgbitmap = new Bitmap(open.FileName);
                    Image img = new Bitmap(open.FileName);
                    img = getResizedImage(imgbitmap, CommonRules.imageSizeLimit, 100, "");
                    #region Image file length check
                    MemoryStream ms = new MemoryStream();
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    if (ms.Length > CommonRules.imageSizeLimit)
                    {
                        MessageBox.Show("Image file should be in " + CommonRules.imageSizeLimit / 1024 + " KB");
                        return;
                    }
                    #endregion

                    // display image in picture box
                    picbox.Image = img;
                    // image file path
                    //txtCustomerName.Text = open.FileName;
                }
            }
            catch (Exception)
            {
                throw new ApplicationException("Image loading error....");
            }
        }

        public static long GetMyDate(DateTime myDate)
        {
            DateTime dateTime = myDate;
            return dateTime.ToUnixTime();
        }
        public static long GetMyDateNow()
        {
            return GetMyDate(DateTime.Now);
        }

        public static DateTime ParseDateTime(string dateTimeString)
        {
            string format = "dd/MM/yyyy";
            CultureInfo provider = CultureInfo.InvariantCulture;
            return DateTime.ParseExact(dateTimeString, format, provider);
        }

        public static string getConfigData(string key)
        {
            string configValue = ConfigurationManager.AppSettings[key].ToString();
            return configValue;
        }

        /*  public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
            Image img = (Image)converter.ConvertFrom(byteArrayIn);
            return img;
        }
        */
    }



    public static class DateTimeExtensions
    {
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1);

        public static long ToUnixTime(this DateTime dateTime)
        {
            return (dateTime - UnixEpoch).Ticks / TimeSpan.TicksPerMillisecond;
        }
    }
}
