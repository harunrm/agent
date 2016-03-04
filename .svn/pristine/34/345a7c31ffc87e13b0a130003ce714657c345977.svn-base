using System;
using System.Collections.Specialized;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account;
using MISL.Ababil.Agent.Infrastructure.Models.models.transaction;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;
using System.Runtime.Serialization;
using System.Net;
using MISL.Ababil.Agent.Infrastructure.Models.reports;
using System.Collections.Generic;
using MISL.Ababil.Agent.Infrastructure.Models.dto;
using Newtonsoft.Json;


namespace MISL.Ababil.Agent.Communication
{
    public class TransactionCom
    {

        public List<TransactionRecord> getRecordListOfTransaction(TransactionRecordSerchDto dto)
        {
            List<TransactionRecord> consumerApplications = new List<TransactionRecord>();

            String path = SessionInfo.rootServiceUrl + "resources/transaction/search";

            //JavaScriptSerializer js = new JavaScriptSerializer();
            string jsonstring = JsonConvert.SerializeObject(dto);
            WebClient client = new WebClient();
            client = UtilityCom.setClientHeaders(client);
            string responseString = client.UploadString(path, "POST", jsonstring);
            string serviceResponse = UtilityCom.getServerResponse(client);
            if (serviceResponse == "OK")
                return consumerApplications = JsonConvert.DeserializeObject<List<TransactionRecord>>(responseString);
            else
                return null;
        }

        public string fundTransfer(string jsonString)
        {
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/transaction/fundtransfer";
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
                        var ser = new DataContractJsonSerializer(typeof(String));
                        responseString = ser.ReadObject(ms) as String;
                    }

                    return responseString;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public string cashIn(string jsonString)
        {
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/transaction/cashin";
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
                        var ser = new DataContractJsonSerializer(typeof(String));
                        responseString = ser.ReadObject(ms) as String;
                    }

                    return responseString;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public string cashOut(string jsonString)
        {
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/transaction/cashout";
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
                        var ser = new DataContractJsonSerializer(typeof(String));
                        responseString = ser.ReadObject(ms) as String;
                    }

                    return responseString;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public string balanceInquiry(string accNo)
        {
           
            AccountInformationDto accDto=new AccountInformationDto();
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/accountinfo/details/" + accNo;
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.DownloadString(path);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                    return "Inavlid Account Number";
                else
                {
                    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    {
                        var ser = new DataContractJsonSerializer(accDto.GetType());
                        accDto = ser.ReadObject(ms) as AccountInformationDto;
                    }

                    return accDto.balance.ToString();
                }
            }
            catch (WebException webEx) {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        
        }


        public List<TransactionDetail> ministatement(string accNo)
        {
           
            List<TransactionDetail> txnDetails = new List<TransactionDetail>();
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/accountinfo/statement/" + accNo;
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
                        var ser = new DataContractJsonSerializer(txnDetails.GetType());
                        txnDetails = ser.ReadObject(ms) as List<TransactionDetail>;
                    }

                    return txnDetails;
                }
            }
            catch (WebException webEx) {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }

        }


       
        public decimal getChargeAmount(string jsonString)
        {
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/charge/calculate";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.UploadString(path, "POST", jsonString);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                    return 0;
                else
                {
                    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    {
                        var ser = new DataContractJsonSerializer(typeof(String));
                        responseString = ser.ReadObject(ms) as String;
                    }

                    return decimal.Parse(responseString);
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }

        }



        public TransactionReportDto GetTransactionReportDto(string voucherNumber)
        {

            //TransactionReportDto dto = new TransactionReportDto();

            ////consumerapplication/nationalid/
            //String path = SessionInfo.rootServiceUrl + "resources/report/transaction/" + voucherNumber;
            //string responseString;
            //try
            //{
            //    NameValueCollection reqparm = new NameValueCollection();
            //    //reqparm.Add("username", username);
            //    //reqparm.Add("password", password);
            //    //reqparm.Add("terminal", terminal);
            //    responseString = JsonCom.getJson(reqparm, path);
            //    dto = new JavaScriptSerializer().Deserialize<TransactionReportDto>(responseString);

            //    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
            //    {
            //        var ser = new DataContractJsonSerializer(dto.GetType());
            //        dto = ser.ReadObject(ms) as TransactionReportDto;
            //    }


            //    return dto;
            //}
            //catch (Exception ex)
            //{

            //    return dto;
            //}

            TransactionReportDto Data = new TransactionReportDto();
            WebClient client = new WebClient();
            try
            {
                String path = SessionInfo.rootServiceUrl + "resources/report/transaction/" + voucherNumber;
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.DownloadString(path);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                    return null;
                else
                {
                    Data = JsonConvert.DeserializeObject<TransactionReportDto>(responseString);
                    return Data;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }

        }

        public List<TransactionRecord> getTransactionReocrdByDateRange(DailyTrnRecordSearchDto TrnDateDto)
        {
            List<TransactionRecord> trnRecord = new List<TransactionRecord>();

            String path = SessionInfo.rootServiceUrl + "resources/subagentinfo/trsearch";

            JavaScriptSerializer js = new JavaScriptSerializer();
     

            string jsonstring = JsonConvert.SerializeObject(TrnDateDto);
            WebClient client = new WebClient();
            client = UtilityCom.setClientHeaders(client);
            string responseString = client.UploadString(path, "POST", jsonstring);
            string serviceResponse = UtilityCom.getServerResponse(client);
            if (serviceResponse == "OK")
                return trnRecord = JsonConvert.DeserializeObject<List<TransactionRecord>>(responseString);
            else
                return null;
        }

        public List<TransactionReportResultDto> getTransactionReport(TransactionReportSearchDto TrnSearchDto)
        {
            List<TransactionReportResultDto> Data = new List<TransactionReportResultDto>();
            var jsonString = JsonConvert.SerializeObject(TrnSearchDto);
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/report/transactions";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.UploadString(path, "POST", jsonString);
                string serviceResponse = UtilityCom.getServerResponse(client);
                if (!serviceResponse.Equals("OK")) return null;
                else
                {
                    Data = JsonConvert.DeserializeObject<List<TransactionReportResultDto>>(responseString);
                    return Data;
                }
            }
            catch (WebException webEx)
            { throw new Exception(UtilityCom.parseErrorData(webEx)); }
        }

    }

}