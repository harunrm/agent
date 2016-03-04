using MISL.Ababil.Agent.Communication;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Module.ChequeRequisition.Models;
using Newtonsoft.Json;
using System.Runtime.Serialization.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using MISL.Ababil.Agent.Infrastructure;
using MISL.Ababil.Agent.Module.ChequeRequisition.Models.Report;

namespace MISL.Ababil.Agent.Module.ChequeRequisition.Service
{
    public class ChequeRequisitionService
    {
        public Array GetUrgencyTypeList()
        {
            return Enum.GetValues(typeof(UrgencyType));
        }

        public Array GetDeliveryFromList()
        {
            return Enum.GetValues(typeof(ChequeDeliveryMedium));
        }

        public List<ChequeLeafConfig> GetChequeLeafConfigList()
        {
            List<ChequeLeafConfig> Data = new List<ChequeLeafConfig>();
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/setup/chequeleafconfig";
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
                    return Data = JsonConvert.DeserializeObject<List<ChequeLeafConfig>>(responseString);
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public List<T> xyz<T>(T p, string urlPart)
        {
            List<T> Data = new List<T>();
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + urlPart;
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
                    return Data = JsonConvert.DeserializeObject<List<T>>(responseString);
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public T2 GetDto<T, T2>(T dto, string url)
        {
            var jsonString = JsonConvert.SerializeObject(dto);
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + url;
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.UploadString(path, "POST", jsonString);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                {
                    return default(T2);
                }
                else
                {
                    return (T2)JsonConvert.DeserializeObject<T2>(responseString);
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public string ChangeChequeRequisitionStatus(ChequeRequestStatusChangeDto chequeRequestStatusChangeDto, string status)
        {
            var jsonString = JsonConvert.SerializeObject(chequeRequestStatusChangeDto);
            WebClient client = new WebClient();
            string successMessage = "";

            if (status == "processing") successMessage = "Cheque requisition is now processing.";
            else if (status == "prepared") successMessage = "Cheque is prepared.";
            else if (status == "correction") successMessage = "Cheque requisition is successfully sent for correction.";
            else if (status == "cancel") successMessage = "Cheque requisition is cancelled successfully.";
            else if (status == ChequeRequisitionStatus.Delivered.ToString()) successMessage = "Cheque requisition is successfully delivered.";
            else if (status == ChequeRequisitionStatus.Ready.ToString()) successMessage = "Cheque is ready.";
            else if (status == ChequeRequisitionStatus.Submitted.ToString()) successMessage = "Cheque requisition is submitted successfull.";

            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/chequerequisition/" + status;
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.UploadString(path, "POST", jsonString);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.OK.ToString()) responseString = successMessage;
                else responseString = "Server error !";

                return responseString;
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public List<ChequeRequisitionSearchResultDto> GetChequeRequisitionList(ChequeRequestSearchDto chequeRequestSearchDto)
        {
            return GetDto<ChequeRequestSearchDto, List<ChequeRequisitionSearchResultDto>>(chequeRequestSearchDto, "resources/chequerequisition/search");

            //List<ChequeRequestSearchDto> Data = new List<ChequeRequestSearchDto>();
            //WebClient client = new WebClient();
            //try
            //{
            //    string path = SessionInfo.rootServiceUrl + "resources/";
            //    client = UtilityCom.setClientHeaders(client);
            //    string responseString = client.DownloadString(path);
            //    string responseStatusCode;
            //    string responseStatusDescription;
            //    JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
            //    if (responseStatusCode == HttpStatusCode.NotFound.ToString())
            //    {
            //        return null;
            //    }
            //    else
            //    {
            //        return Data = JsonConvert.DeserializeObject<List<ChequeRequestSearchDto>>(responseString);
            //    }
            //}
            //catch (WebException webEx)
            //{
            //    throw new Exception(UtilityCom.parseErrorData(webEx));
            //}
        }

        public string SaveChequeRequest(ChequeRequestDto chequeRequestDto)
        {
            var jsonString = JsonConvert.SerializeObject(chequeRequestDto);
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/chequerequisition/apply";
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
                            string refNumber = ser.ReadObject(ms) as String;
                            responseString = "Request submitted successfully with reference no. " + refNumber;
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


        public string SaveChequeRequestDelivery(ChequeRequestDto chequeRequestDto)
        {
            var jsonString = JsonConvert.SerializeObject(chequeRequestDto);
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/chequerequisition/delivered";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.UploadString(path, "POST", jsonString);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                //if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                //{
                //    return "Not Found!";
                //}
                //else
                if (responseStatusCode == HttpStatusCode.OK.ToString())
                {
                    return "Successfully Delivered";
                }
                //else
                //{

                //    //if (responseString == "")
                //    //{
                //    //    return null;
                //    //}
                //    //else
                //    //{
                //    //    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                //    //    {
                //    //        var ser = new DataContractJsonSerializer(typeof(string));
                //    //        responseString = ser.ReadObject(ms) as string;
                //    //    }
                //    //    return responseString;
                //    //}
                //}
                return "";
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }


        public string BulkAccept(List<ChequeRequestStatusChangeDto> ChequeRequestStatusChangeDtoList)
        {
            var jsonString = JsonConvert.SerializeObject(ChequeRequestStatusChangeDtoList);
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/chequerequisition/bulkprocessing";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.UploadString(path, "POST", jsonString);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.OK.ToString())
                {
                    return "Bulk processing is done successfully.";
                }
                else return "";
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public string BulkReceive(List<ChequeRequestStatusChangeDto> ChequeRequestStatusChangeDtoList)
        {
            var jsonString = JsonConvert.SerializeObject(ChequeRequestStatusChangeDtoList);
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/chequerequisition/bulkready";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.UploadString(path, "POST", jsonString);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.OK.ToString())
                {
                    return "Selected cheques are received successfully.";
                }
                else return "";
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public List<ChequeRequisitionReportResultDto> getChequeRequisitionReport(ChequeRequisitionReportSearchDto searchDto)
        {
            var jsonString = JsonConvert.SerializeObject(searchDto);
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/chequerequisition/detilreport";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.UploadString(path, "POST", jsonString);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                    return null;
                else
                {
                    if (responseString == "") return null;
                    else
                    {
                        using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                        {
                            var ser = new DataContractJsonSerializer(typeof(List<ChequeRequisitionReportResultDto>));
                            return ser.ReadObject(ms) as List<ChequeRequisitionReportResultDto>;
                        }

                    }
                }
            }
            catch (WebException webEx)
            { throw new Exception(UtilityCom.parseErrorData(webEx)); }
        }
        public List<ChequeRequisitionReportResultDto> getChequeDeliveryReport(ChequeRequisitionReportSearchDto searchDto)
        {
            var jsonString = JsonConvert.SerializeObject(searchDto);
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/chequerequisition/delivereyreport";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.UploadString(path, "POST", jsonString);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                    return null;
                else
                {
                    if (responseString == "") return null;
                    else
                    {
                        using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                        {
                            var ser = new DataContractJsonSerializer(typeof(List<ChequeRequisitionReportResultDto>));
                            return ser.ReadObject(ms) as List<ChequeRequisitionReportResultDto>;
                        }

                    }
                }
            }
            catch (WebException webEx)
            { throw new Exception(UtilityCom.parseErrorData(webEx)); }
        }

        public List<ChequeRequestStatusChangeDto> ConvertChequeRequisitionSearchResultDtoListToChequeRequestStatusChangeDtoList(List<ChequeRequisitionSearchResultDto> chequeRequisitionSearchResultDtoList)
        {
            List<ChequeRequestStatusChangeDto> chequeRequestStatusChangeDtoList = new List<ChequeRequestStatusChangeDto>();
            ChequeRequestStatusChangeDto ChequeRequestStatusChangeDtoTemp;

            for (int i = 0; i < chequeRequisitionSearchResultDtoList.Count; i++)
            {
                ChequeRequestStatusChangeDtoTemp = new ChequeRequestStatusChangeDto();
                ChequeRequestStatusChangeDtoTemp.chequeRequestInfoId = chequeRequisitionSearchResultDtoList[i].chequeRequisitionInfoId;
                chequeRequestStatusChangeDtoList.Add(ChequeRequestStatusChangeDtoTemp);
            }
            return chequeRequestStatusChangeDtoList;
        }

        public string SingleReceive(List<ChequeRequestStatusChangeDto> ChequeRequestStatusChangeDtoList)
        {
            var jsonString = JsonConvert.SerializeObject(ChequeRequestStatusChangeDtoList);
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/chequerequisition/bulkready";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.UploadString(path, "POST", jsonString);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                
                if (responseStatusCode == HttpStatusCode.OK.ToString()) return "Cheque is ready to deliver.";
                else return "Server Error !";
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }
        public long GetLastChequeSerial(string accountNo)
        {
            //var jsonString = JsonConvert.SerializeObject(accountNo);
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/chequerequisition/lastchequeno/" + accountNo;
                client = UtilityCom.setClientHeaders(client);
                //string responseString = client.UploadString(path, "POST", jsonString);
                string responseString = client.DownloadString(path);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                    return 0;
                else
                {
                    if (responseString == "") return 0;
                    else
                    {
                        using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                        {
                            var ser = new DataContractJsonSerializer(typeof(long));
                            return (long)ser.ReadObject(ms);
                        }
                    }
                }
            }
            catch (WebException webEx)
            { throw new Exception(UtilityCom.parseErrorData(webEx)); }
        }

    }
}