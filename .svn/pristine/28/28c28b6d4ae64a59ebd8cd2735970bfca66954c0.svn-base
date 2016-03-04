using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.documentMgt;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.Remittance;
using MISL.Ababil.Agent.Infrastructure.Models.models.transaction;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Script.Serialization;
using MISL.Ababil.Agent.Infrastructure.Models.dto;

namespace MISL.Ababil.Agent.Communication
{
    public class RemittanceCom
    {
        public List<ExchangeHouse> getListofExchangeHouse()
        {
            List<ExchangeHouse> exchangeHouse = new List<ExchangeHouse>();
            WebClient client = new WebClient();
            try
            {
                String path = SessionInfo.rootServiceUrl + "resources/setup/exhouse";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.DownloadString(path);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                    return null;
                else
                {
                    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    {
                        var ser = new DataContractJsonSerializer(exchangeHouse.GetType());
                        exchangeHouse = ser.ReadObject(ms) as List<ExchangeHouse>;
                    }
                    return exchangeHouse;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }       
        }

        public List<Remittance> getListOfRemittance(Remittance rmts)
        {
            var jsonString = JsonConvert.SerializeObject(rmts); //new JavaScriptSerializer().Serialize(rmts);
            List<Remittance> remittances = new List<Remittance>();
            WebClient client = new WebClient();
            try
            {
                String path = SessionInfo.rootServiceUrl + "resources/remittance/search";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.UploadString(path, "POST", jsonString);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                    return null;
                else
                {
                    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    {
                        var ser = new DataContractJsonSerializer(remittances.GetType());
                        remittances = ser.ReadObject(ms) as List<Remittance>;
                    }

                    return remittances;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public static List<RemittanceDto> GetReportListOfRemittance(RemittanceSearchDto rmts)
        {
            var jsonString = JsonConvert.SerializeObject(rmts); //new JavaScriptSerializer().Serialize(rmts);
            List<RemittanceDto> remittances = new List<RemittanceDto>();
            WebClient client = new WebClient();
            try
            {
                //String path = SessionInfo.rootServiceUrl + "resources/remittance/report";
                String path = SessionInfo.rootServiceUrl + "resources/report/remittance";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.UploadString(path, "POST", jsonString);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                    return null;
                else
                {
                    remittances = JsonConvert.DeserializeObject<List<RemittanceDto>>(responseString);
                    //using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    //{
                    //    var ser = new DataContractJsonSerializer(remittances.GetType());
                    //    remittances = ser.ReadObject(ms) as List<RemittanceDto>;
                    //}

                    return remittances;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }


        public string saveRemittance(Remittance remittance)
        {
            var jsonString = JsonConvert.SerializeObject(remittance); //new JavaScriptSerializer().Serialize(remittance);
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/remittance/save";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.UploadString(path, "POST", jsonString);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                    return null;
                else
                {

                    if (responseString == "")
                    {
                        return null;
                    }
                    else
                    {
                        using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                        {
                            var ser = new DataContractJsonSerializer(typeof(String));
                            responseString = ser.ReadObject(ms) as String;
                        }

                        return responseString;
                    }
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public string getAccountNumber(string exchangeHouseId)
        {
            string responseString = "";
            WebClient client = new WebClient();
            string path = SessionInfo.rootServiceUrl + "" + exchangeHouseId;
            try
            {
                NameValueCollection reqparm = new NameValueCollection();
                responseString = JsonCom.getJson(reqparm, path);
            }
            catch (Exception ex)
            {
                responseString = ex.Message;
            }
            return responseString;
        }

        public string getOutletName()
        {
            string responseString = "";
            WebClient client = new WebClient();
            string path = SessionInfo.rootServiceUrl + "" + SessionInfo.username;
            try
            {
                NameValueCollection reqparm = new NameValueCollection();
                responseString = JsonCom.getJson(reqparm, path);
            }
            catch (Exception ex)
            {
                responseString = ex.Message;
            }

            return responseString;
        }

        public string disburseRemittance(RemittanceDisburseRequest remittanceDisburseRequest)
        {

            var jsonString = JsonConvert.SerializeObject(remittanceDisburseRequest); //new JavaScriptSerializer().Serialize(remittanceDisburseRequest);
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/remittance/disburse";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.UploadString(path, "POST", jsonString);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                    return null;
                else
                {

                    if (responseString == "")
                    {
                        return null;
                    }
                    else
                    {
                        using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                        {
                            var ser = new DataContractJsonSerializer(typeof(String));
                            responseString = ser.ReadObject(ms) as String;
                        }

                        return responseString;
                    }
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public List<DocumentType> getRemittanceDocumentTypeList()
        {
            List<DocumentType> Data = new List<DocumentType>();
            string path = SessionInfo.rootServiceUrl + "resources/document/type/remittance"; ///////////////////////
            try
            {
                NameValueCollection reqparm = new NameValueCollection();
                string responseString = JsonCom.getJson(reqparm, path);
                if (responseString == "NotFound")
                {
                    return null;
                }
                else if (responseString == "Unable to connect to the remote server")
                {
                    return null;
                }
                else
                {
                    //using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    //{
                    //    var ser = new DataContractJsonSerializer(Data.GetType());
                    //    Data = ser.ReadObject(ms) as List<Document>;
                    //}
                    Data = JsonConvert.DeserializeObject<List<DocumentType>>(responseString);
                    return Data;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }
    }
}
