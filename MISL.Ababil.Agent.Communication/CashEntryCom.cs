using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.models.transaction;
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
    public class CashEntryCom
    {
        public List<TransactionPurpose> GetTransactionPurposeList()
        {
            List<TransactionPurpose> Data = new List<TransactionPurpose>();
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/setup/transactionpurpose";
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
                    return Data = JsonConvert.DeserializeObject<List<TransactionPurpose>>(responseString);
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public string SaveOutletCashTransactionRegister(OutletCashTransactionRegister outletCashTransactionRegister)
        {
            var jsonString = JsonConvert.SerializeObject(outletCashTransactionRegister);
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/cash/saveoutletCashTransactionRegister";
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

        public List<OutletCashTransactionRegister> GetOutletCashTransactionRegisterList()
        {
            List<OutletCashTransactionRegister> Data = new List<OutletCashTransactionRegister>();
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/setup/transactionpurpose"; //change URL//
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
                    return Data = JsonConvert.DeserializeObject<List<OutletCashTransactionRegister>>(responseString);
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }
    }
}