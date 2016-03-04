using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Script.Serialization;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.ssp;
using Newtonsoft.Json;
using com.mislbd.agentbanking.report.dto;
using MISL.Ababil.Agent.Infrastructure.Models.reports;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.termaccount;

namespace MISL.Ababil.Agent.Communication
{
    public class SSPAccountCom
    {
        public SspSlipDto GetSSPPaySlipRequestApplicationReportDto(string refrenceNumber)
        {
            SspSlipDto Data = new SspSlipDto();
            WebClient client = new WebClient();
            try
            {
                String path = SessionInfo.rootServiceUrl + "resources/report/sspconfirmslip/" + refrenceNumber;
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.DownloadString(path);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                    return null;
                else
                {
                    Data = JsonConvert.DeserializeObject<SspSlipDto>(responseString);
                    return Data;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }
        //new add IDTA 
        public ConsumerApplicationReportDto GetITDAApplicationReportDto(string refrenceNumber)
        {


            //ConsumerApplicationReportDto Data = new ConsumerApplicationReportDto();
            //WebClient client = new WebClient();
            //try
            //{
            //    String path = SessionInfo.rootServiceUrl + "resources/report/sspconfirmslip/" + refrenceNumber;
            //    client = UtilityCom.setClientHeaders(client);
            //    string responseString = client.DownloadString(path);
            //    string responseStatusCode;
            //    string responseStatusDescription;
            //    JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
            //    if (responseStatusCode == HttpStatusCode.NotFound.ToString())
            //        return null;
            //    else
            //    {
            //        Data = JsonConvert.DeserializeObject<ConsumerApplicationReportDto>(responseString);
            //        return Data;
            //    }
            //}
            //catch (WebException webEx)
            //{
            //    throw new Exception(UtilityCom.parseErrorData(webEx));
            //}
            return null;
        }
        public List<SspProductType> getProductTypes()
        {
            List<SspProductType> listData = new List<SspProductType>();
            WebClient client = new WebClient();
            string path = SessionInfo.rootServiceUrl + "resources/sspaccount/ssptype";
            try
            {
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
                        listData = ser.ReadObject(ms) as List<SspProductType>;
                    }
                    return listData;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public List<SspInstallment> GetInstallmentSizeByProductTypeId(string id)
        {
            List<SspInstallment> listData = new List<SspInstallment>();
            WebClient client = new WebClient();
            string path = SessionInfo.rootServiceUrl + "resources/sspaccount/sspinstallment/" + id;
            try
            {
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

        public string sendSspRequest(string jsonString, sspaccountstatus appStatus)
        {
            //string responseString = "";
            string path = "";
            if (appStatus == sspaccountstatus.submitted)
                path = SessionInfo.rootServiceUrl + "resources/sspaccount/save";
            if (appStatus == sspaccountstatus.approved)
                path = SessionInfo.rootServiceUrl + "resources/sspaccount/approve";
            else if (appStatus == sspaccountstatus.canceled)
                path = SessionInfo.rootServiceUrl + "resources/sspaccount/cancel";
            else if (appStatus == sspaccountstatus.correction)
                path = SessionInfo.rootServiceUrl + "resources/sspaccount/correction";

            WebClient client = new WebClient();
            client = UtilityCom.setClientHeaders(client);
            try
            {
                string responseString = client.UploadString(path, "POST", jsonString);
                string serviceResponse = UtilityCom.getServerResponse(client);
                if (appStatus == sspaccountstatus.submitted)
                    return responseString;
                if (appStatus == sspaccountstatus.approved)
                    return "SSP Account Request was approved successfully";
                else if (appStatus == sspaccountstatus.canceled)
                    return "SSP Account Request was rejected successfully";
                else if (appStatus == sspaccountstatus.correction)
                    return "SSP Account Request was sent for correction successfully";
                else
                    return "Successfull";
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public string SubmitSspRequest(string json)
        {
            string path = SessionInfo.rootServiceUrl + "resources/sspaccount/save";
            WebClient client = new WebClient();
            client = UtilityCom.setClientHeaders(client);
            try
            {
                string responseString = client.UploadString(path, "POST", json);
                string serviceResponse = UtilityCom.getServerResponse(client);
                string customerSavedSuccessfully;
                if (serviceResponse.Equals("OK"))
                {
                    customerSavedSuccessfully = "SSP Account Request was saved successfully with the ID: " + responseString;
                }
                else
                {
                    customerSavedSuccessfully = "SSP Account Request could not be saved successfully";
                }
                return customerSavedSuccessfully;

            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }

        }

        //public string ApproveSSPRequest(string json)
        //{
        //    string path = SessionInfo.rootServiceUrl + "resources/sspaccount/save"; //change if necessary
        //    WebClient client = new WebClient();
        //    client = UtilityCom.setClientHeaders(client);
        //    try
        //    {
        //        string responseString = client.UploadString(path, "POST", json);
        //        string serviceResponse = UtilityCom.getServerResponse(client);
        //        string customerSavedSuccessfully;
        //        if (serviceResponse.Equals("OK"))
        //        {
        //            customerSavedSuccessfully = "SSP Account Request was approved successfully with the ID: " + responseString;
        //        }
        //        else
        //        {
        //            customerSavedSuccessfully = "SSP Account Request could not be approved successfully";
        //        }
        //        return customerSavedSuccessfully;

        //    }
        //    catch (WebException webEx)
        //    {
        //        throw new Exception(UtilityCom.parseErrorData(webEx));
        //    }

        //}

        //public string RejectSSPRequest(string json)
        //{
        //    string path = SessionInfo.rootServiceUrl + "resources/sspaccount/cancel";
        //    WebClient client = new WebClient();
        //    client = UtilityCom.setClientHeaders(client);
        //    try
        //    {
        //        string responseString = client.UploadString(path, "POST", json);
        //        string serviceResponse = UtilityCom.getServerResponse(client);
        //        string customerSavedSuccessfully;
        //        if (serviceResponse.Equals("OK"))
        //        {
        //            customerSavedSuccessfully = "SSP Account Request was rejected successfully with the ID: " + responseString;
        //        }
        //        else
        //        {
        //            customerSavedSuccessfully = "SSP Account Request could not be rejected successfully";
        //        }
        //        return customerSavedSuccessfully;

        //    }
        //    catch (WebException webEx)
        //    {
        //        throw new Exception(UtilityCom.parseErrorData(webEx));
        //    }

        //}

        public List<TermAccountInformation> SearchAgents(SspAccountInformationSearchDto searcDto)
        {
            List<TermAccountInformation> Data = new List<TermAccountInformation>();

            //JavaScriptSerializer js = new JavaScriptSerializer();
            string jsonObj = JsonConvert.SerializeObject(searcDto);
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/sspaccount/search";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.UploadString(path, "POST", jsonObj);
                string serviceResponse = UtilityCom.getServerResponse(client);
                if (!serviceResponse.Equals("OK"))
                {
                    return null;
                }
                else
                {
                    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    {
                        var ser = new DataContractJsonSerializer(Data.GetType());
                        Data = ser.ReadObject(ms) as List<TermAccountInformation>;
                    }
                    return Data;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public List<TermAccountInformation> SearchAgents(long id)
        {
            List<TermAccountInformation> Data = new List<TermAccountInformation>();

            //string jsonObj = JsonConvert.SerializeObject(searcDto);
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/sspaccount/sspdetail/" + id;
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.DownloadString(path);
                string serviceResponse = UtilityCom.getServerResponse(client);
                if (!serviceResponse.Equals("OK"))
                {
                    return null;
                }
                else
                {
                    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    {
                        var ser = new DataContractJsonSerializer(Data.GetType());
                        Data = ser.ReadObject(ms) as List<TermAccountInformation>;
                    }
                    return Data;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public TermAccountInformation SearchAgent(long id)
        {
            TermAccountInformation Data = new TermAccountInformation();

            //string jsonObj = JsonConvert.SerializeObject(searcDto);
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/sspaccount/sspdetail/" + id;
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.DownloadString(path);
                string serviceResponse = UtilityCom.getServerResponse(client);
                if (!serviceResponse.Equals("OK"))
                {
                    return null;
                }
                else
                {
                    Data = JsonConvert.DeserializeObject<TermAccountInformation>(responseString);
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