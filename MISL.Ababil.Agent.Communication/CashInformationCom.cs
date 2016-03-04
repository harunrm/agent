using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.ssp;
using MISL.Ababil.Agent.Infrastructure.Models.models.transaction;
using MISL.Ababil.Agent.Infrastructure.Models.dto;
using Newtonsoft.Json;
using MISL.Ababil.Agent.Communication;

namespace MISL.Ababil.Agent.Communication
{
    public class CashInformationCom
    {
        public CashInformationDto GetCashInformationList()
        {
            CashInformationDto listData = new CashInformationDto();
            WebClient client = new WebClient();
            string path = SessionInfo.rootServiceUrl + "resources/transaction/cashinfo";
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
                        listData = ser.ReadObject(ms) as CashInformationDto;
                    }
                    return listData;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public OutletCashSummaryDto GetOutletCashSummary(OutletCashSumReqDto outletCashSumReqDto)
        {
            var jsonString = JsonConvert.SerializeObject(outletCashSumReqDto);
            OutletCashSummaryDto outletCashSummaryDto = new OutletCashSummaryDto();
            WebClient client = new WebClient();
            try
            {
                String path = SessionInfo.rootServiceUrl + "resources/cash/cashsummary";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.UploadString(path, "POST", jsonString);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                    return null;
                else
                {
                    outletCashSummaryDto = JsonConvert.DeserializeObject<OutletCashSummaryDto>(responseString);
                    return outletCashSummaryDto;
                }
            }
            catch (WebException webEx)
            {
                // throw new Exception(UtilityCom.parseErrorData(webEx));
            }
            return null;
        }


        public List<CashTxnDetails> GetOutletCashInfoDetails(CashTxnDetailsReq cashTxnDetailsReq)
        {
            var jsonString = JsonConvert.SerializeObject(cashTxnDetailsReq);
            List<CashTxnDetails> listData = new List<CashTxnDetails>();
            WebClient client = new WebClient();
            string path = SessionInfo.rootServiceUrl + "resources/cash/itemwisecashdetails";
            try
            {
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.UploadString(path, "POST", jsonString);
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
                        listData = ser.ReadObject(ms) as List<CashTxnDetails>;
                    }
                    return listData;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public List<CashTxnDetails> GetOutletCashInfoAllDetails(CashTxnDetailsReq cashTxnDetailsReq)
        {
            var jsonString = JsonConvert.SerializeObject(cashTxnDetailsReq);
            List<CashTxnDetails> listData = new List<CashTxnDetails>();
            WebClient client = new WebClient();
            string path = SessionInfo.rootServiceUrl + "resources/cash/cashflowwisecashdetails";
            try
            {
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.UploadString(path, "POST", jsonString);
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
                        listData = ser.ReadObject(ms) as List<CashTxnDetails>;
                    }
                    return listData;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public List<CashTxnDetails> GetOutletCashInfoWithAllViewDetails(CashTxnDetailsReq cashTxnDetailsReq)
        {
            var jsonString = JsonConvert.SerializeObject(cashTxnDetailsReq);
            List<CashTxnDetails> listData = new List<CashTxnDetails>();
            WebClient client = new WebClient();
            string path = SessionInfo.rootServiceUrl + "resources/cash/allcashdetails";
            try
            {
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.UploadString(path, "POST", jsonString);
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
                        listData = ser.ReadObject(ms) as List<CashTxnDetails>;
                    }
                    return listData;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public List<CashTxnDetails> GetOutletCashInfoDetails(long outletId, string cashItem, string informationDate)
        {
            List<CashTxnDetails> listData = new List<CashTxnDetails>();
            WebClient client = new WebClient();
            string path = SessionInfo.rootServiceUrl + "resources/cash/itemwisecashdetails/" + outletId.ToString() + "/" + cashItem + "/" + informationDate;
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
                        listData = ser.ReadObject(ms) as List<CashTxnDetails>;
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