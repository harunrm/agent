using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;
using System.Collections.Specialized;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.cis;
using MISL.Ababil.Agent.Infrastructure.Models.dto;
using Newtonsoft.Json;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.termaccount;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.ssp;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.nominee;

namespace MISL.Ababil.Agent.Communication
{
    public class UtilityCom
    {
        public static string getServerResponse(WebClient client)
        {
            string responseString = null;
            string responseStatusCode = null;
            string responseStatusDescription = null;
            int responseCode = JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
            if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                return null;
            else if (responseStatusCode != HttpStatusCode.OK.ToString())
            {
                WebHeaderCollection responseHd = client.ResponseHeaders;
                foreach (string key in responseHd.AllKeys)
                {
                    if (key == "reason")
                        responseString = responseHd[key];
                    else
                        responseString = "Communication error";
                }
                return responseString;
            }
            else
                return "OK";
        }
        public static WebClient setClientHeaders(WebClient client)
        {
            client.Headers["username"] = SessionInfo.username;
            client.Headers["terminal"] = SessionInfo.terminal;
            client.Headers["token"] = SessionInfo.token;
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            return client;
        }
        public static BranchDto getBranchDto(int branchId)
        {
            BranchDto Data = new BranchDto();
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/setup/branch/" + branchId;
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.DownloadString(path);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                {
                    return null;
                }
                else
                {
                    Data = JsonConvert.DeserializeObject<BranchDto>(responseString);
                    return Data;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }
        public List<CisOwnerType> getOwnerTypesByCisType(int cisTypeId)
        {
            List<CisOwnerType> listData = new List<CisOwnerType>();
            //String path = SessionInfo.rootServiceUrl + "resources/setup/cisownertype/" + cisTypeId;
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/setup/cisownertype/" + cisTypeId;
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.DownloadString(path);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                {
                    return null;
                }
                else
                {
                    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    {
                        var ser = new DataContractJsonSerializer(listData.GetType());
                        listData = ser.ReadObject(ms) as List<CisOwnerType>;
                    }
                    return listData;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
            //using (WebClient client = new WebClient())
            //{
            //    try
            //    {
            //        System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
            //        string responseString = JsonCom.getJson(reqparm, path);

            //        using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
            //        {
            //            var ser = new DataContractJsonSerializer(listData.GetType());
            //            listData = ser.ReadObject(ms) as List<CisOwnerType>;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        throw new Exception(ex.Message);
            //    }
            //}
            //return listData;
        }

        public List<NomineeRelationship> GetAllRelationships()
        {
            List<NomineeRelationship> Data = new List<NomineeRelationship>();
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/setup/relationship";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.DownloadString(path);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                {
                    return null;
                }
                else
                {
                    Data = JsonConvert.DeserializeObject<List<NomineeRelationship>>(responseString);
                    return Data;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public List<CisOwnerType> getOwnerTypes()
        {
            List<CisOwnerType> listData = new List<CisOwnerType>();
            //String path = SessionInfo.rootServiceUrl + "resources/setup/cisownertype";
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/setup/cisownertype";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.DownloadString(path);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                {
                    return null;
                }
                else
                {
                    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    {
                        var ser = new DataContractJsonSerializer(listData.GetType());
                        listData = ser.ReadObject(ms) as List<CisOwnerType>;
                    }
                    return listData;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
            //using (WebClient client = new WebClient())
            //{
            //    try
            //    {
            //        System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
            //        string responseString = JsonCom.getJson(reqparm, path);

            //        using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
            //        {
            //            var ser = new DataContractJsonSerializer(listData.GetType());
            //            listData = ser.ReadObject(ms) as List<CisOwnerType>;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        throw new Exception(ex.Message);
            //    }
            //}
            //return listData;
        }
        public List<CisType> getcmbCustomerTypes()
        {
            List<CisType> listData = new List<CisType>();
            //String path = SessionInfo.rootServiceUrl + "resources/setup/cistypes";
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/setup/cistypes";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.DownloadString(path);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                {
                    return null;
                }
                else
                {
                    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    {
                        var ser = new DataContractJsonSerializer(listData.GetType());
                        listData = ser.ReadObject(ms) as List<CisType>;
                    }
                    return listData;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
            //using (WebClient client = new WebClient())
            //{
            //    try
            //    {
            //        System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
            //        string responseString = JsonCom.getJson(reqparm, path);

            //        using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
            //        {
            //            var ser = new DataContractJsonSerializer(listData.GetType());
            //            listData = ser.ReadObject(ms) as List<CisType>;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        throw new Exception(ex.Message);
            //    }
            //}
            //return listData;
        }
        public List<CisInstituteType> getcmbInstitutionTypes()
        {
            List<CisInstituteType> listData = new List<CisInstituteType>();
            //String path = SessionInfo.rootServiceUrl + "resources/setup/institutetypes";
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/setup/institutetypes";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.DownloadString(path);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                {
                    return null;
                }
                else
                {
                    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    {
                        var ser = new DataContractJsonSerializer(listData.GetType());
                        listData = ser.ReadObject(ms) as List<CisInstituteType>;
                    }
                    return listData;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
            //using (WebClient client = new WebClient())
            //{
            //    try
            //    {
            //        System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
            //        string responseString = JsonCom.getJson(reqparm, path);

            //        using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
            //        {
            //            var ser = new DataContractJsonSerializer(listData.GetType());
            //            listData = ser.ReadObject(ms) as List<CisInstituteType>;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        throw new Exception(ex.Message);
            //    }
            //}
            //return listData;
        }
        public List<Branch> getBranches()
        {
            List<Branch> listData = new List<Branch>();
            //string path = SessionInfo.rootServiceUrl + "resources/setup/districts";
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/setup/branches";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.DownloadString(path);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                {
                    return null;
                }
                else
                {
                    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    {
                        var ser = new DataContractJsonSerializer(listData.GetType());
                        listData = ser.ReadObject(ms) as List<Branch>;
                    }
                    return listData;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }
        public List<District> getAllDistricts()
        {
            List<District> listData = new List<District>();
            //string path = SessionInfo.rootServiceUrl + "resources/setup/districts";
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/setup/districts";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.DownloadString(path);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                {
                    return null;
                }
                else
                {
                    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    {
                        var ser = new DataContractJsonSerializer(listData.GetType());
                        listData = ser.ReadObject(ms) as List<District>;
                    }
                    return listData;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
            //try
            //{
            //    NameValueCollection reqparm = new NameValueCollection();
            //    //reqparm.Add("username", username);
            //    //reqparm.Add("password", password);
            //    //reqparm.Add("terminal", terminal);
            //    string responseString = JsonCom.getJson(reqparm, path);

            //    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
            //    {
            //        var ser = new DataContractJsonSerializer(listData.GetType());
            //        listData = ser.ReadObject(ms) as List<District>;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}
            //return listData;
        }
        public List<Occupation> getOccupations()
        {
            List<Occupation> listData = new List<Occupation>();
            //string path = SessionInfo.rootServiceUrl + "resources/setup/occupations";
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/setup/occupations";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.DownloadString(path);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                {
                    return null;
                }
                else
                {
                    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    {
                        var ser = new DataContractJsonSerializer(listData.GetType());
                        listData = ser.ReadObject(ms) as List<Occupation>;
                    }
                    return listData;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
            //try
            //{
            //    NameValueCollection reqparm = new NameValueCollection();
            //    //reqparm.Add("username", username);
            //    //reqparm.Add("password", password);
            //    //reqparm.Add("terminal", terminal);
            //    string responseString = JsonCom.getJson(reqparm, path);

            //    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
            //    {
            //        var ser = new DataContractJsonSerializer(listData.GetType());
            //        listData = ser.ReadObject(ms) as List<Occupation>;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}
            //return listData;
        }
        public List<PostalCode> getPostalCodes(long districtId)
        {
            List<PostalCode> listData = new List<PostalCode>();
            //string path = SessionInfo.rootServiceUrl + "resources/setup/postalCodes/" + districtId;
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/setup/postalCodes/" + districtId;
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.DownloadString(path);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                {
                    return null;
                }
                else
                {
                    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    {
                        var ser = new DataContractJsonSerializer(listData.GetType());
                        listData = ser.ReadObject(ms) as List<PostalCode>;
                    }
                    return listData;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
            //try
            //{
            //    NameValueCollection reqparm = new NameValueCollection();
            //    //reqparm.Add("username", username);
            //    //reqparm.Add("password", password);
            //    //reqparm.Add("terminal", terminal);
            //    string responseString = JsonCom.getJson(reqparm, path);

            //    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
            //    {
            //        var ser = new DataContractJsonSerializer(listData.GetType());
            //        listData = ser.ReadObject(ms) as List<PostalCode>;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}
            //return listData;
        }
        public List<Thana> getThanas(int districtId)
        {
            List<Thana> listData = new List<Thana>();
            //string path = SessionInfo.rootServiceUrl + "resources/setup/thanas/" + districtId;
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/setup/thanas/" + districtId;
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.DownloadString(path);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                {
                    return null;
                }
                else
                {
                    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    {
                        var ser = new DataContractJsonSerializer(listData.GetType());
                        listData = ser.ReadObject(ms) as List<Thana>;
                    }
                    return listData;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
            //    try
            //    {
            //        NameValueCollection reqparm = new NameValueCollection();
            //        //reqparm.Add("username", username);
            //        //reqparm.Add("password", password);
            //        //reqparm.Add("terminal", terminal);
            //        string responseString = JsonCom.getJson(reqparm, path);

            //        using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
            //        {
            //            var ser = new DataContractJsonSerializer(listData.GetType());
            //            listData = ser.ReadObject(ms) as List<Thana>;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        throw new Exception(ex.Message);
            //    }
            //return listData;
        }
        public List<District> getDistricts(int divisionId)
        {
            //string responseString = "";
            List<District> listData = new List<District>();
            //String path = SessionInfo.rootServiceUrl + "resources/setup/districts/" + divisionId;
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/setup/districts/" + divisionId;
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.DownloadString(path);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                {
                    return null;
                }
                else
                {
                    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    {
                        var ser = new DataContractJsonSerializer(listData.GetType());
                        listData = ser.ReadObject(ms) as List<District>;
                    }
                    return listData;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
            //using (WebClient client = new WebClient())
            //{
            //    try
            //    {
            //        System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
            //        //reqparm.Add("username", username);
            //        //reqparm.Add("password", password);
            //        //reqparm.Add("terminal", terminal);
            //        responseString = JsonCom.getJson(reqparm, path);

            //        using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
            //        {
            //            var ser = new DataContractJsonSerializer(listData.GetType());
            //            listData = ser.ReadObject(ms) as List<District>;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        string unknownError = responseString;
            //        throw new Exception(ex.Message);
            //    }
            //}
            //return listData;
        }
        public List<Division> getDivisions()
        {
            //string responseString = "";
            List<Division> listData = new List<Division>();
            //String path = SessionInfo.rootServiceUrl + "resources/setup/divisions";
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/setup/divisions";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.DownloadString(path);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                {
                    return null;
                }
                else
                {
                    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    {
                        var ser = new DataContractJsonSerializer(listData.GetType());
                        listData = ser.ReadObject(ms) as List<Division>;
                    }
                    return listData;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
            //try
            //{
            //    System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
            //    //reqparm.Add("username", username);
            //    //reqparm.Add("password", password);
            //    //reqparm.Add("terminal", terminal);
            //    responseString = JsonCom.getJson(reqparm, path);

            //    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
            //    {
            //        var ser = new DataContractJsonSerializer(listData.GetType());
            //        listData = ser.ReadObject(ms) as List<Division>;
            //    }
            //}
            //catch (WebException webEx)
            //{
            //    responseString = webEx.Response.Headers.Get("reason");
            //    if (responseString == null)
            //    {
            //        responseString = "Communication error";
            //    }

            //    throw new Exception(responseString);
            //}
            //catch (Exception ex)
            //{
            //    string unKnownError = responseString + ex.Message;
            //    throw new Exception(ex.Message);
            //}
            //return listData;
        }

        public static string parseErrorData(WebException webEx)
        {

            string responseString;
            if (webEx.Response != null)
            {
                responseString = webEx.Response.Headers.Get("reason");
                if (responseString == null)
                {
                    responseString = "Communication error";
                }
            }
            else
                responseString = webEx.Message;
            return responseString;

        }

        public List<Country> getCountries()
        {
            List<Country> listData = new List<Country>();
            //String path = SessionInfo.rootServiceUrl + "resources/setup/countries";
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/setup/countries";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.DownloadString(path);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                {
                    return null;
                }
                else
                {
                    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    {
                        var ser = new DataContractJsonSerializer(listData.GetType());
                        listData = ser.ReadObject(ms) as List<Country>;
                    }
                    return listData;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public List<TermProductType> GetITDProducts()
        {
            List<TermProductType> listData = new List<TermProductType>();
            //String path = SessionInfo.rootServiceUrl + "resources/setup/countries";
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/setup/product/itd";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.DownloadString(path);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                {
                    return null;
                }
                else
                {
                    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    {
                        var ser = new DataContractJsonSerializer(listData.GetType());
                        listData = ser.ReadObject(ms) as List<TermProductType>;
                    }
                    return listData;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public List<TermProductType> GetMTDProducts()
        {
            List<TermProductType> listData = new List<TermProductType>();            
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/setup/product/mtd";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.DownloadString(path);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                {
                    return null;
                }
                else
                {
                    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    {
                        var ser = new DataContractJsonSerializer(listData.GetType());
                        listData = ser.ReadObject(ms) as List<TermProductType>;
                    }
                    return listData;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public List<AgentProduct> GetAgentProducts()
        {
            List<AgentProduct> listData = new List<AgentProduct>();
            //String path = SessionInfo.rootServiceUrl + "resources/setup/countries";
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/agentinfo/depositproducttype";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.DownloadString(path);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                {
                    return null;
                }
                else
                {
                    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    {
                        var ser = new DataContractJsonSerializer(listData.GetType());
                        listData = ser.ReadObject(ms) as List<AgentProduct>;
                    }
                    return listData;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public List<SspInstallment> GetITDInstallment()
        {
            List<SspInstallment> listData = new List<SspInstallment>();
            //String path = SessionInfo.rootServiceUrl + "resources/setup/countries";
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/setup/product/itd";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.DownloadString(path);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                {
                    return null;
                }
                else
                {
                    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    {
                        var ser = new DataContractJsonSerializer(listData.GetType());
                        listData = ser.ReadObject(ms) as List<SspInstallment>;
                    }
                    return listData;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public List<SectorCodeInfo> getcmbSectorCodeList()
        {
            List<SectorCodeInfo> listData = new List<SectorCodeInfo>();

            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/setup/sectorcode";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.DownloadString(path);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                {
                    return null;
                }
                else
                {
                    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    {
                        var ser = new DataContractJsonSerializer(listData.GetType());
                        listData = ser.ReadObject(ms) as List<SectorCodeInfo>;
                    }
                    return listData;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }

        }

    }
}
