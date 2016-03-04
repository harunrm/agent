using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account;
using MISL.Ababil.Agent.Infrastructure.Models.dto;
using Newtonsoft.Json;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.ssp;

namespace MISL.Ababil.Agent.Communication
{
    public class AccountOpeningReportCom
    {
        public static List<AccountBlanceDto> GetAccountOpeningList(AccountSearchDto searcDto)
        {
            List<AccountBlanceDto> Data = new List<AccountBlanceDto>();

            string jsonObj = JsonConvert.SerializeObject(searcDto);
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/report/accountsopening";
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

        public static List<AccountBlanceDto> GetAccountOpeningList(SspAccountSearchDto searcDto, ProductType productType)
        {
            List<AccountBlanceDto> Data = new List<AccountBlanceDto>();

            string jsonObj = JsonConvert.SerializeObject(searcDto);
            WebClient client = new WebClient();
            try
            {
                string path = "";

                switch (productType)
                {
                    case ProductType.SSP:
                        path = SessionInfo.rootServiceUrl + "resources/report/sspaccountsopening";
                        break;
                    case ProductType.MTDR:
                        path = SessionInfo.rootServiceUrl + "resources/report/mtdraccountsopening";
                        break;
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


        public static List<AgentProduct> GetAllAgentProducts()
        {
            List<AgentProduct> Data = new List<AgentProduct>();

            string jsonObj = JsonConvert.SerializeObject(null);
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/agentinfo/allagentproducttype";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.DownloadString(path);
                string serviceResponse = UtilityCom.getServerResponse(client);
                if (!serviceResponse.Equals("OK"))
                {
                    return null;
                }
                else
                {
                    Data = JsonConvert.DeserializeObject<List<AgentProduct>>(responseString);
                    return Data;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public static List<AgentProduct> GetDepositProducts()
        {
            List<AgentProduct> Data = new List<AgentProduct>();

            string jsonObj = JsonConvert.SerializeObject(null);
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/agentinfo/depositproducttype";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.DownloadString(path);
                string serviceResponse = UtilityCom.getServerResponse(client);
                if (!serviceResponse.Equals("OK"))
                {
                    return null;
                }
                else
                {
                    Data = JsonConvert.DeserializeObject<List<AgentProduct>>(responseString);
                    return Data;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }
        public static List<SspProductType> GetSchemeProducts()
        {
            List<SspProductType> Data = new List<SspProductType>();

            string jsonObj = JsonConvert.SerializeObject(null);
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/agentinfo/schemeproducttype";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.DownloadString(path);
                string serviceResponse = UtilityCom.getServerResponse(client);
                if (!serviceResponse.Equals("OK"))
                {
                    return null;
                }
                else
                {
                    Data = JsonConvert.DeserializeObject<List<SspProductType>>(responseString);
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