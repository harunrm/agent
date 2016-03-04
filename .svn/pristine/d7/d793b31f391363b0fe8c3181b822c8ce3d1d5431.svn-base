using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.models.transaction;
using MISL.Ababil.Agent.Infrastructure.Models.reports;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;

namespace MISL.Ababil.Agent.Communication
{
    public class BillPaymentCom
    {
        //=================================billpayment report==================//
        public static List<BillPaymentSearchResultDto> GetReportListOfBillPayment(BillPaymentSearchDto billPmentSearch)
        {
            var jsonString = JsonConvert.SerializeObject(billPmentSearch); //new JavaScriptSerializer().Serialize(rmts);
            List<BillPaymentSearchResultDto> billPayment = new List<BillPaymentSearchResultDto>();
            WebClient client = new WebClient();
            try
            {
                String path = SessionInfo.rootServiceUrl + "resources/bill/search";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.UploadString(path, "POST", jsonString);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                    return null;
                else
                {
                    billPayment = JsonConvert.DeserializeObject<List<BillPaymentSearchResultDto>>(responseString);
                    return billPayment;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }
        //===================================================//
        public List<BillServiceProvider> GetListBillServiceProviders()
        {
            List<BillServiceProvider> Data = new List<BillServiceProvider>();
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/bill/providers";
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
                    return Data = JsonConvert.DeserializeObject<List<BillServiceProvider>>(responseString);
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public decimal? GetChargeByBillAmount(long providerId, decimal amount)
        {
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/bill/charge/" + providerId + "/" + amount;
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.DownloadString(path);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                    return null;
                else
                {
                    if (responseString == "" || responseString == null)
                    {
                        return null;
                    }
                    else
                    {
                        return decimal.Parse(responseString);
                    }
                }
            }
            catch (WebException webEx)
            {
                return null;
                // throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public string SaveBillPaymentRequest(BillPaymentRequestDto billPaymentRequestDto)
        {
            string jsonString = JsonConvert.SerializeObject(billPaymentRequestDto);
            string path = SessionInfo.rootServiceUrl + "resources/bill/payment";
            WebClient client = new WebClient();
            client = UtilityCom.setClientHeaders(client);
            try
            {
                string responseString = client.UploadString(path, "POST", jsonString);
                string serviceResponse = UtilityCom.getServerResponse(client);
                return responseString;

            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }
    }
}