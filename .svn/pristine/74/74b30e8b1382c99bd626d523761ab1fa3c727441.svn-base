using MISL.Ababil.Agent.Communication;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.cis;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.Remittance;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.ssp;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.termaccount;
using MISL.Ababil.Agent.Infrastructure.Models.models.transaction;
using MISL.Ababil.Agent.LocalStorageService.Models;
using MISL.Ababil.Agent.LocalStorageService.Services;
using MISL.Ababil.Agent.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MISL.Ababil.Agent.LocalStorageService
{
    public class LocalStorage
    {
        private LocalStorageIO localStorageIO = new LocalStorageIO();

        public bool ResetLocalCache()
        {
            return localStorageIO.Reset();
        }

        public void Sync()
        {
            Task taskCheckForUpdate = new Task(() =>
            {
                LoadSubagentInfo();
                CheckForUpdate();
            });
            taskCheckForUpdate.Start();
        }


        public void LoadSubagentInfo()
        {
            try
            {
                if (SessionInfo.roles.Contains("Sub Agent"))
                {
                    SubagentUserService subagentUserService = new SubagentUserService();
                    LocalCache.OwnSubagentCachingData = subagentUserService.GetSubagentCachingData(SessionInfo.username);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool LoadLocalCacheInformation(ref List<CacheInformation> localCacheInformationList)
        {
            string jsonString = "";
            if (localStorageIO.LoadJsonToLocalStorage(LOCALSTORAGE_FIXED_KEYS.KEY_UPDATE, out jsonString))
            {
                localCacheInformationList = JsonConvert.DeserializeObject<List<CacheInformation>>(jsonString);
                return true;
            }
            return false;
        }

        public bool LoadRemoteCacheInformation(ref List<CacheInformation> remoteCacheInformationList)
        {
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/cache/cacheupdatestatus";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.DownloadString(path);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                {
                    return false;
                }
                else
                {
                    remoteCacheInformationList = JsonConvert.DeserializeObject<List<CacheInformation>>(responseString);
                    return true;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public void SaveRemoteCacheInformation(ref List<CacheInformation> remoteCacheInformationList)
        {
            var jsonString = JsonConvert.SerializeObject(remoteCacheInformationList);
            WebClient client = new WebClient();
            try
            {
                localStorageIO.SaveJsonToLocalStorage("cacheupdatestatus", ref jsonString);
                string path = SessionInfo.rootServiceUrl + "resources/cache/cacheinformation/update";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.UploadString(path, "POST", jsonString);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                    return;
                else
                {
                    if (responseString == "")
                    {
                        return;
                    }
                    else
                    {
                        //using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                        //{
                        //    var ser = new DataContractJsonSerializer(typeof(string));
                        //    responseString = ser.ReadObject(ms) as string;
                        //}
                        //return responseString;
                    }
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public string GetRemoteJSONString(string url)
        {
            WebClient client = new WebClient();
            try
            {
                //string path = SessionInfo.rootServiceUrl + "resources/cache/cacheupdatestatus";
                string path = SessionInfo.rootServiceUrl + "resources/" + url;
                path = path.Replace("resources//", "resources/");
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.DownloadString(path);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                {
                    //return null;
                }
                else
                {
                    return responseString;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
            return null;
        }

        public bool CheckForUpdate()
        {
            bool flagUpdateAvailable = false;
            List<CacheInformation> remoteCacheInformationList = new List<CacheInformation>();
            List<CacheInformation> localCacheInformationList = new List<CacheInformation>();
            List<CacheInformation> localCacheInformationListTmp = new List<CacheInformation>();

            LoadLocalCacheInformation(ref localCacheInformationList);
            LoadRemoteCacheInformation(ref remoteCacheInformationList);



            if (localCacheInformationList != null && localCacheInformationList.Count != 0)
            {
                for (int i = 0; i < remoteCacheInformationList.Count; i++)
                {
                    localCacheInformationListTmp = localCacheInformationList.Where(o => o.objectName.Equals(remoteCacheInformationList[i].objectName)).ToList();
                    if (localCacheInformationListTmp.Count > 0)
                    {
                        if (remoteCacheInformationList[i].lastUpdateTime > localCacheInformationListTmp[0].lastUpdateTime)
                        {
                            string jsonString = GetRemoteJSONString(remoteCacheInformationList[i].servicePath);
                            localStorageIO.SaveJsonToLocalStorage(remoteCacheInformationList[i].objectName, ref jsonString);
                            flagUpdateAvailable = true;
                        }
                    }
                    else
                    {
                        string jsonString = GetRemoteJSONString(remoteCacheInformationList[i].servicePath);
                        localStorageIO.SaveJsonToLocalStorage(remoteCacheInformationList[i].objectName, ref jsonString);
                        flagUpdateAvailable = true;
                    }
                }
            }
            else
            {
                string tmpString = GetRemoteJSONString(LOCALSTORAGE_FIXED_URLS.URL_UPDATE);
                localStorageIO.SaveJsonToLocalStorage(LOCALSTORAGE_FIXED_KEYS.KEY_UPDATE, ref tmpString);

                if (remoteCacheInformationList.Count != 0)
                {
                    UpdateAllLocalStorageItems(ref remoteCacheInformationList);
                    flagUpdateAvailable = true;
                }
                else
                {
                    //err handle
                }
            }
            SaveRemoteCacheInformation(ref remoteCacheInformationList);
            return flagUpdateAvailable;
        }

        public void UpdateAllLocalStorageItems(ref List<CacheInformation> remoteCacheInformationList)
        {
            for (int i = 0; i < remoteCacheInformationList.Count; i++)
            {
                string tmpString = GetRemoteJSONString(remoteCacheInformationList[i].servicePath);
                localStorageIO.SaveJsonToLocalStorage(remoteCacheInformationList[i].objectName, ref tmpString);
            }
        }

        public List<TransactionPurpose> GetTransactionPurposeList()
        {
            string key = "TransactionPurpose";
            LocalStorageIO localStorageIO = new LocalStorageIO();
            string responseString = "";
            localStorageIO.LoadJsonToLocalStorage(key, out responseString);
            if (!string.IsNullOrEmpty(responseString))
            {
                List<TransactionPurpose> Data = JsonConvert.DeserializeObject<List<TransactionPurpose>>(responseString);
                return Data;
            }
            CashEntryCom cashEntryCom = new CashEntryCom();
            List<TransactionPurpose> tempTransactionPurposeList = new List<TransactionPurpose>();
            tempTransactionPurposeList = cashEntryCom.GetTransactionPurposeList();
            localStorageIO.SaveObjectToLocalStorage(tempTransactionPurposeList, key);
            return tempTransactionPurposeList;
        }

        public List<Occupation> GetOccupations()
        {
            string key = "Occupation";
            LocalStorageIO localStorageIO = new LocalStorageIO();
            string responseString = "";
            localStorageIO.LoadJsonToLocalStorage(key, out responseString);
            if (!string.IsNullOrEmpty(responseString))
            {
                List<Occupation> Data = JsonConvert.DeserializeObject<List<Occupation>>(responseString);
                return Data;
            }
            UtilityCom utilityCom = new UtilityCom();
            List<Occupation> tempOccupationList = new List<Occupation>();
            tempOccupationList = utilityCom.getOccupations();
            localStorageIO.SaveObjectToLocalStorage(tempOccupationList, key);
            return tempOccupationList;
        }

        public List<Country> GetCountries()
        {
            string key = "Country";
            LocalStorageIO localStorageIO = new LocalStorageIO();
            string responseString = "";
            localStorageIO.LoadJsonToLocalStorage(key, out responseString);
            if (!string.IsNullOrEmpty(responseString))
            {
                List<Country> Data = JsonConvert.DeserializeObject<List<Country>>(responseString);
                return Data;
            }
            UtilityCom utilityCom = new UtilityCom();
            List<Country> tempCountryList = new List<Country>();
            tempCountryList = utilityCom.getCountries();
            localStorageIO.SaveObjectToLocalStorage(tempCountryList, key);
            return tempCountryList;
        }

        public List<Division> GetDivisions()
        {
            string key = "Division";
            LocalStorageIO localStorageIO = new LocalStorageIO();
            string responseString = "";
            localStorageIO.LoadJsonToLocalStorage(key, out responseString);
            if (!string.IsNullOrEmpty(responseString))
            {
                List<Division> Data = JsonConvert.DeserializeObject<List<Division>>(responseString);
                return Data;
            }
            UtilityCom utilityCom = new UtilityCom();
            List<Division> tempDivisionList = new List<Division>();
            tempDivisionList = utilityCom.getDivisions();
            localStorageIO.SaveObjectToLocalStorage(tempDivisionList, key);
            return tempDivisionList;
        }

        public List<District> GetDistrictsByDivisionID(int divisionId)
        {
            string key = "Districts" + divisionId.ToString();
            LocalStorageIO localStorageIO = new LocalStorageIO();
            string responseString = "";
            localStorageIO.LoadJsonToLocalStorage(key, out responseString);
            if (!string.IsNullOrEmpty(responseString))
            {
                List<District> Data = JsonConvert.DeserializeObject<List<District>>(responseString);
                return Data;
            }
            UtilityCom utilityCom = new UtilityCom();
            List<District> tempDistrictList = new List<District>();
            tempDistrictList = utilityCom.getDistricts(divisionId);
            localStorageIO.SaveObjectToLocalStorage(tempDistrictList, key);
            return tempDistrictList;
        }

        public List<District> GetDistricts()
        {
            string key = "Districts";
            LocalStorageIO localStorageIO = new LocalStorageIO();
            string responseString = "";
            localStorageIO.LoadJsonToLocalStorage(key, out responseString);
            if (!string.IsNullOrEmpty(responseString))
            {
                List<District> Data = JsonConvert.DeserializeObject<List<District>>(responseString);
                return Data;
            }
            UtilityCom utilityCom = new UtilityCom();
            List<District> tempDistrictList = new List<District>();
            tempDistrictList = utilityCom.getAllDistricts();
            localStorageIO.SaveObjectToLocalStorage(tempDistrictList, key);
            return tempDistrictList;
        }

        public List<Thana> GetThanasByDistrictID(long districtId)
        {
            string key = "Thanas" + districtId.ToString();
            LocalStorageIO localStorageIO = new LocalStorageIO();
            string responseString = "";
            localStorageIO.LoadJsonToLocalStorage(key, out responseString);
            if (!string.IsNullOrEmpty(responseString))
            {
                List<Thana> Data = JsonConvert.DeserializeObject<List<Thana>>(responseString);
                return Data;
            }
            UtilityCom utilityCom = new UtilityCom();
            List<Thana> tempThanaList = new List<Thana>();
            tempThanaList = utilityCom.getThanas((int)districtId);
            localStorageIO.SaveObjectToLocalStorage(tempThanaList, key);
            return tempThanaList;
        }

        public List<PostalCode> GetPostalCodesByDistrictID(long districtId)
        {
            string key = "PostalCodes" + districtId.ToString();
            LocalStorageIO localStorageIO = new LocalStorageIO();
            string responseString = "";
            localStorageIO.LoadJsonToLocalStorage(key, out responseString);
            if (!string.IsNullOrEmpty(responseString))
            {
                List<PostalCode> Data = JsonConvert.DeserializeObject<List<PostalCode>>(responseString);
                return Data;
            }
            UtilityCom utilityCom = new UtilityCom();
            List<PostalCode> tempPostalCodeList = new List<PostalCode>();
            tempPostalCodeList = utilityCom.getPostalCodes(districtId);
            localStorageIO.SaveObjectToLocalStorage(tempPostalCodeList, key);
            return tempPostalCodeList;
        }

        public List<TermProductType> GetITDProducts()
        {
            string key = "TermProductTypeITD";
            LocalStorageIO localStorageIO = new LocalStorageIO();
            string responseString = "";
            localStorageIO.LoadJsonToLocalStorage(key, out responseString);
            if (!string.IsNullOrEmpty(responseString))
            {
                List<TermProductType> Data = JsonConvert.DeserializeObject<List<TermProductType>>(responseString);
                return Data;
            }
            UtilityCom utilityCom = new UtilityCom();
            List<TermProductType> tempITDProductList = new List<TermProductType>();
            tempITDProductList = utilityCom.GetITDProducts();
            localStorageIO.SaveObjectToLocalStorage(tempITDProductList, key);
            return tempITDProductList;
        }

        public List<TermProductType> GetMTDProducts()
        {
            string key = "TermProductTypeMTD";
            LocalStorageIO localStorageIO = new LocalStorageIO();
            string responseString = "";
            localStorageIO.LoadJsonToLocalStorage(key, out responseString);
            if (!string.IsNullOrEmpty(responseString))
            {
                List<TermProductType> Data = JsonConvert.DeserializeObject<List<TermProductType>>(responseString);
                return Data;
            }
            UtilityCom utilityCom = new UtilityCom();
            List<TermProductType> tempMTDProductList = new List<TermProductType>();
            tempMTDProductList = utilityCom.GetMTDProducts();
            localStorageIO.SaveObjectToLocalStorage(tempMTDProductList, key);
            return tempMTDProductList;
        }

        public List<AgentProduct> GetDepositProducts()
        {
            string key = "DepositProductType";
            LocalStorageIO localStorageIO = new LocalStorageIO();
            string responseString = "";
            localStorageIO.LoadJsonToLocalStorage(key, out responseString);
            if (!string.IsNullOrEmpty(responseString))
            {
                List<AgentProduct> Data = JsonConvert.DeserializeObject<List<AgentProduct>>(responseString);
                return Data;
            }
            UtilityCom utilityCom = new UtilityCom();
            List<AgentProduct> tempAgentProductList = new List<AgentProduct>();
            tempAgentProductList = utilityCom.GetAgentProducts();
            localStorageIO.SaveObjectToLocalStorage(tempAgentProductList, key);
            return tempAgentProductList;
        }


        public List<SspInstallment> GetITDInstallment()
        {
            string key = "SspInstallment";
            LocalStorageIO localStorageIO = new LocalStorageIO();
            string responseString = "";
            localStorageIO.LoadJsonToLocalStorage(key, out responseString);
            if (!string.IsNullOrEmpty(responseString))
            {
                List<SspInstallment> Data = JsonConvert.DeserializeObject<List<SspInstallment>>(responseString);
                return Data;
            }
            UtilityCom utilityCom = new UtilityCom();
            List<SspInstallment> tempTransactionPurposeList = new List<SspInstallment>();
            tempTransactionPurposeList = utilityCom.GetITDInstallment();
            localStorageIO.SaveObjectToLocalStorage(tempTransactionPurposeList, key);
            return tempTransactionPurposeList;
        }

        public List<ExchangeHouse> GetExchangeHouses()
        {
            string key = "ExchangeHouse";
            LocalStorageIO localStorageIO = new LocalStorageIO();
            string responseString = "";
            localStorageIO.LoadJsonToLocalStorage(key, out responseString);
            if (!string.IsNullOrEmpty(responseString))
            {
                List<ExchangeHouse> Data = JsonConvert.DeserializeObject<List<ExchangeHouse>>(responseString);
                return Data;
            }
            RemittanceCom remittanceCom = new RemittanceCom();
            List<ExchangeHouse> tempExchangeHouseList = new List<ExchangeHouse>();
            tempExchangeHouseList = remittanceCom.getListofExchangeHouse();
            localStorageIO.SaveObjectToLocalStorage(tempExchangeHouseList, key);
            return tempExchangeHouseList;
        }

        public List<SectorCodeInfo> GetSectorCodes()
        {
            string key = "SectorCode";
            LocalStorageIO localStorageIO = new LocalStorageIO();
            string responseString = "";
            localStorageIO.LoadJsonToLocalStorage(key, out responseString);
            if (!string.IsNullOrEmpty(responseString))
            {
                List<SectorCodeInfo> Data = JsonConvert.DeserializeObject<List<SectorCodeInfo>>(responseString);
                return Data;
            }
            UtilityCom utilityCom = new UtilityCom();
            List<SectorCodeInfo> tempSectorCodeInfoList = new List<SectorCodeInfo>();
            tempSectorCodeInfoList = utilityCom.getcmbSectorCodeList();
            localStorageIO.SaveObjectToLocalStorage(tempSectorCodeInfoList, key);
            return tempSectorCodeInfoList;
        }

        public List<SectorCodeInfo> GetCisLocations()
        {
            string key = "CisLocation";
            LocalStorageIO localStorageIO = new LocalStorageIO();
            string responseString = "";
            localStorageIO.LoadJsonToLocalStorage(key, out responseString);
            if (!string.IsNullOrEmpty(responseString))
            {
                List<SectorCodeInfo> Data = JsonConvert.DeserializeObject<List<SectorCodeInfo>>(responseString);
                return Data;
            }
            UtilityCom utilityCom = new UtilityCom();
            List<SectorCodeInfo> tempSectorCodeInfoList = new List<SectorCodeInfo>();
            tempSectorCodeInfoList = utilityCom.getcmbSectorCodeList();
            localStorageIO.SaveObjectToLocalStorage(tempSectorCodeInfoList, key);
            return tempSectorCodeInfoList;
        }

        public List<CisInstituteType> GetCisInstituteTypes()
        {
            string key = "CisInstituteType";
            LocalStorageIO localStorageIO = new LocalStorageIO();
            string responseString = "";
            localStorageIO.LoadJsonToLocalStorage(key, out responseString);
            if (!string.IsNullOrEmpty(responseString))
            {
                List<CisInstituteType> Data = JsonConvert.DeserializeObject<List<CisInstituteType>>(responseString);
                return Data;
            }
            UtilityCom utilityCom = new UtilityCom();
            List<CisInstituteType> tempCisInstituteTypeList = new List<CisInstituteType>();
            tempCisInstituteTypeList = utilityCom.getcmbInstitutionTypes();
            localStorageIO.SaveObjectToLocalStorage(tempCisInstituteTypeList, key);
            return tempCisInstituteTypeList;
        }

        public List<CisType> GetCisTypes()
        {
            string key = "CisType";
            LocalStorageIO localStorageIO = new LocalStorageIO();
            string responseString = "";
            localStorageIO.LoadJsonToLocalStorage(key, out responseString);
            if (!string.IsNullOrEmpty(responseString))
            {
                List<CisType> Data = JsonConvert.DeserializeObject<List<CisType>>(responseString);
                return Data;
            }
            UtilityCom utilityCom = new UtilityCom();
            List<CisType> tempCisTypeList = new List<CisType>();
            tempCisTypeList = utilityCom.getcmbCustomerTypes();
            localStorageIO.SaveObjectToLocalStorage(tempCisTypeList, key);
            return tempCisTypeList;
        }
    }
}