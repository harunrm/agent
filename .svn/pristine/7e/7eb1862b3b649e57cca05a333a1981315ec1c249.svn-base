using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.dto;
using Newtonsoft.Json;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account;

namespace MISL.Ababil.Agent.Communication
{
    public class AccountBalanceReportCom
    {
        public static List<AccountBlanceDto> GetAccountBalanceList(AccountSearchDto searcDto)
        {
            List<AccountBlanceDto> Data = new List<AccountBlanceDto>();

            string jsonObj = JsonConvert.SerializeObject(searcDto);
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/report/accountsblance";
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
                        Data = ser.ReadObject(ms) as List<AccountBlanceDto>;
                    }
                    return Data;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }

        }

        public static List<AccountBlanceDto> GetAccountBalanceList(SspAccountSearchDto searcDto)
        {
            List<AccountBlanceDto> Data = new List<AccountBlanceDto>();

            string jsonObj = JsonConvert.SerializeObject(searcDto);
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/report/sspaccountsbalance";
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
                        Data = ser.ReadObject(ms) as List<AccountBlanceDto>;
                    }
                    return Data;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }

        }
        public static List<AccountBlanceDto> GetAccountBalanceList(SspAccountSearchDto searcDto, ProductType productType)
        {
            List<AccountBlanceDto> Data = new List<AccountBlanceDto>();

            string jsonObj = JsonConvert.SerializeObject(searcDto);
            WebClient client = new WebClient();
            try
            {
                string path = "";
                if (productType == ProductType.SSP)
                {
                    path = SessionInfo.rootServiceUrl + "resources/report/sspaccountsbalance";
                }
                else
                {
                    path = SessionInfo.rootServiceUrl + "resources/report/mtdraccountsbalance";
                }

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
                        Data = ser.ReadObject(ms) as List<AccountBlanceDto>;
                    }
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