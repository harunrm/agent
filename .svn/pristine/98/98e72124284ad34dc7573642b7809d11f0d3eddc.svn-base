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
using MISL.Ababil.Agent.Infrastructure.Models.dto;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account;

namespace MISL.Ababil.Agent.Communication
{
    public class TermAccountCom
    {


        public SspSlipDto GetMTDPPaySlipRequestApplicationReportDto(string refrenceNumber, AccountType? accountType)
        {
            SspSlipDto Data = new SspSlipDto();
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/report/mtdrconfirmslip/" + refrenceNumber;
                //path = SessionInfo.rootServiceUrl + "resources/report/mtdrconfirmslip/" + refrenceNumber;

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


        public SspSlipDto GetSSPPaySlipRequestApplicationReportDto(string refrenceNumber, AccountType? accountType)
        {
            SspSlipDto Data = new SspSlipDto();
            WebClient client = new WebClient();
            try
            {
                string path = "";
                switch (accountType)
                {
                    case AccountType.SSP:
                        path = SessionInfo.rootServiceUrl + "resources/report/sspconfirmslip/" + refrenceNumber;
                        break;
                    case AccountType.MTDR:
                        path = SessionInfo.rootServiceUrl + "resources/report/mtdrconfirmslip/" + refrenceNumber;
                        break;
                    default:
                        break;
                }


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

        public List<CommentDto> GetCommentsByID(string commentId)
        {
            List<CommentDto> listData = new List<CommentDto>();
            WebClient client = new WebClient();
            string path = SessionInfo.rootServiceUrl + "resources/comment/allcomment/" + commentId;
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
                        listData = ser.ReadObject(ms) as List<CommentDto>;
                    }
                    return listData;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public string sendTermRequestDto(string jsonString, TermAccountStatus appStatus)
        {
            string path = "";

            if (appStatus == TermAccountStatus.submitted)
                path = SessionInfo.rootServiceUrl + "resources/termaccount/request/submit";
            if (appStatus == TermAccountStatus.approved)
                path = SessionInfo.rootServiceUrl + "resources/sspaccount/approve";
            else if (appStatus == TermAccountStatus.canceled)
                path = SessionInfo.rootServiceUrl + "resources/sspaccount/cancel";
            else if (appStatus == TermAccountStatus.correction)
                path = SessionInfo.rootServiceUrl + "resources/sspaccount/correction";

            WebClient client = new WebClient();
            client = UtilityCom.setClientHeaders(client);
            try
            {
                string responseString = client.UploadString(path, "POST", jsonString);
                string serviceResponse = UtilityCom.getServerResponse(client);
                if (appStatus == TermAccountStatus.submitted)
                    return responseString;
                if (appStatus == TermAccountStatus.approved)
                    return "SSP Account Request was approved successfully";
                else if (appStatus == TermAccountStatus.canceled)
                    return "SSP Account Request was rejected successfully";
                else if (appStatus == TermAccountStatus.correction)
                    return "SSP Account Request was sent for correction successfully";
                else
                    return "Successfull";
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public string sendTermRequest(string jsonString, TermAccountStatus appStatus)
        {
            //string responseString = "";
            string path = "";
            //if (appStatus == TermAccountStatus.submitted)
            //    path = SessionInfo.rootServiceUrl + "resources/sspaccount/save";
            //if (appStatus == TermAccountStatus.approved)
            //    path = SessionInfo.rootServiceUrl + "resources/sspaccount/approve";
            //else if (appStatus == TermAccountStatus.canceled)
            //    path = SessionInfo.rootServiceUrl + "resources/sspaccount/cancel";
            //else if (appStatus == TermAccountStatus.correction)
            //    path = SessionInfo.rootServiceUrl + "resources/sspaccount/correction";

            if (appStatus == TermAccountStatus.submitted)
                path = SessionInfo.rootServiceUrl + "resources/termaccount/request/submit";
            if (appStatus == TermAccountStatus.approved)
                path = SessionInfo.rootServiceUrl + "resources/sspaccount/approve";
            else if (appStatus == TermAccountStatus.canceled)
                path = SessionInfo.rootServiceUrl + "resources/sspaccount/cancel";
            else if (appStatus == TermAccountStatus.correction)
                path = SessionInfo.rootServiceUrl + "resources/sspaccount/correction";


            WebClient client = new WebClient();
            client = UtilityCom.setClientHeaders(client);
            try
            {
                string responseString = client.UploadString(path, "POST", jsonString);
                string serviceResponse = UtilityCom.getServerResponse(client);
                if (appStatus == TermAccountStatus.submitted)
                    return responseString;
                if (appStatus == TermAccountStatus.approved)
                    return "SSP Account Request was approved successfully";
                else if (appStatus == TermAccountStatus.canceled)
                    return "SSP Account Request was rejected successfully";
                else if (appStatus == TermAccountStatus.correction)
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

        public List<TermAccountSearchResultDto> SearchTermAccounts(TermAccountSearchDto termAccountSearchDto)
        {
            List<TermAccountSearchResultDto> Data = new List<TermAccountSearchResultDto>();
            string jsonObj = JsonConvert.SerializeObject(termAccountSearchDto);
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/termaccount/application/search";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.UploadString(path, "POST", jsonObj);
                string serviceResponse = UtilityCom.getServerResponse(client);
                if (!serviceResponse.Equals("OK"))
                {
                    return null;
                }
                else
                {
                    Data = JsonConvert.DeserializeObject<List<TermAccountSearchResultDto>>(responseString);

                    //using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    //{
                    //    var ser = new DataContractJsonSerializer(Data.GetType());
                    //    Data = ser.ReadObject(ms) as List<TermAccountSearchResultDto>;
                    //}
                    return Data;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public TermAccountRequestDto GetTermAccountRequestDtoByAccID(long accountID)
        {
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/termaccount/application/" + accountID;
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
                    return JsonConvert.DeserializeObject<TermAccountRequestDto>(responseString);
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

        // "/request/correction"

        public string ChangeTermApplicationStatus(ApplicationStatusChangeDto applicationStatusChangeDto, TermAccountStatus termAccountStatus)
        {
            var jsonString = JsonConvert.SerializeObject(applicationStatusChangeDto);
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/termaccount/request/";

                switch (termAccountStatus)
                {
                    case TermAccountStatus.submitted:

                        break;
                    case TermAccountStatus.canceled:
                        path += "reject";
                        break;
                    case TermAccountStatus.approved:
                        path += "approve";
                        break;
                    case TermAccountStatus.correction:
                        path += "correction";
                        break;
                    default:
                        break;
                }

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
                        //using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                        //{
                        //    var ser = new DataContractJsonSerializer(typeof(string));
                        //    responseString = ser.ReadObject(ms) as string;
                        //}
                        return responseString;
                    }
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

    }
}