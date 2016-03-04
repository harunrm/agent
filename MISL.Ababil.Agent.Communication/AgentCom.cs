using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using MISL.Ababil.Agent.Infrastructure.Models.dto;
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
using System.Windows.Forms;
using MISL.Ababil.Agent.Infrastructure.Models.reports;

namespace MISL.Ababil.Agent.Communication
{
    public class AgentCom
    {
        //------------------------------------------------------------------------------------------------------------------------
        public List<OutletUserInfoReportResultDto> getOutletUserInfoList(OutletUserInfoReportSearchDto outletInfoSearchDto)
        {
            List<OutletUserInfoReportResultDto> Data = new List<OutletUserInfoReportResultDto>();
            var jsonString = JsonConvert.SerializeObject(outletInfoSearchDto);
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/subagentinfo/outletreport";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.UploadString(path, "POST", jsonString);
                string serviceResponse = UtilityCom.getServerResponse(client);
                if (!serviceResponse.Equals("OK")) return null;
                else
                {
                    Data = JsonConvert.DeserializeObject<List<OutletUserInfoReportResultDto>>(responseString);
                    return Data;
                }
            }
            catch (WebException webEx)
            { throw new Exception(UtilityCom.parseErrorData(webEx)); }
        }
//----------------------------------------------------------------------------------------------------------------------------

        //================================================================================================================
        public List<AgentIncomeStatementDto> getAgentIncomeStatementReportDtoList(AccountSearchDto accountSearchDto)
        {
            List<AgentIncomeStatementDto> Data = new List<AgentIncomeStatementDto>();
            string jsonObj = JsonConvert.SerializeObject(accountSearchDto);
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/report/agincstatement";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.UploadString(path, "POST", jsonObj);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                {
                    return null;
                }
                else
                {
                    Data = JsonConvert.DeserializeObject<List<AgentIncomeStatementDto>>(responseString);
                    return Data;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }
        //===========================================================================================================
        public AgentInformation getCurrentAgentInfo()
        {
            AgentInformation Data = new AgentInformation();
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/agentinfo/agentforreport";
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
                        var ser = new DataContractJsonSerializer(Data.GetType());
                        Data = ser.ReadObject(ms) as AgentInformation;
                    }
                    return Data;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }
        public List<AgentProduct> getAgentProductByProductType(string productType)
        {
            List<AgentProduct> Data = new List<AgentProduct>();
            string jsonObj = JsonConvert.SerializeObject(productType);
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/agentinfo/agentproducttype";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.UploadString(path, "POST", jsonObj);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
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
        public string saveAgent(AgentInformation agentInfo)
        {

            var jsonString = JsonConvert.SerializeObject(agentInfo);
            WebClient client = new WebClient();
            try
            {

                string path = SessionInfo.rootServiceUrl + "resources/agentinfo/save";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.UploadString(path, "POST", jsonString);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                    return null;
                else
                {
                    return "Agent saved successfully";
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public List<AccountInformation> getAgentAccountList(long agentId)
        {
            List<AccountInformation> Data = new List<AccountInformation>();
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/agentinfo/search/" + agentId;
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
                        var ser = new DataContractJsonSerializer(Data.GetType());
                        Data = ser.ReadObject(ms) as List<AccountInformation>;
                    }
                    return Data;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }
        public List<AgentInformation> getAgentInfoBranchWise()
        {
            List<AgentInformation> Data = new List<AgentInformation>();
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/agentinfo/search";
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
                        var ser = new DataContractJsonSerializer(Data.GetType());
                        Data = ser.ReadObject(ms) as List<AgentInformation>;
                    }
                    return Data;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }
        public AgentInformation getAgentInfoById(string agentId)
        {
            AgentInformation Data = new AgentInformation();
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/agentinfo/agent/" + agentId;
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
                        var ser = new DataContractJsonSerializer(Data.GetType());
                        Data = ser.ReadObject(ms) as AgentInformation;
                    }
                    return Data;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public AccountInformationDto GetAgentAccountInfoByAgentId(string agentId)
        {
            AccountInformationDto Data = new AccountInformationDto();
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/agentinfo/account/" + agentId;
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
                        var ser = new DataContractJsonSerializer(Data.GetType());
                        Data = ser.ReadObject(ms) as AccountInformationDto;
                    }
                    return Data;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public List<AgentInformation> SearchAgents(AgentDto searcDto)
        {
            List<AgentInformation> Data = new List<AgentInformation>();
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/agentinfo/search";
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
                        var ser = new DataContractJsonSerializer(Data.GetType());
                        Data = ser.ReadObject(ms) as List<AgentInformation>;
                    }
                    return Data;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public List<SubAgentInformation> GetSubagentsByAgentId(long agentId)
        {
            List<SubAgentInformation> Data = new List<SubAgentInformation>();
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/subagentinfo/outletlimit/agent/" + agentId;
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
                    //using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    //{
                    //    var ser = new DataContractJsonSerializer(Data.GetType());
                    //    Data = ser.ReadObject(ms) as List<SubAgentInformation>;
                    //}

                    Data = JsonConvert.DeserializeObject<List<SubAgentInformation>>(responseString);

                    return Data;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public List<AgentIncomeStatementDto> getAgentIncomeStatementDtoList(AccountSearchDto accountSearchDto)
        {
            List<AgentIncomeStatementDto> Data = new List<AgentIncomeStatementDto>();
            string jsonObj = JsonConvert.SerializeObject(accountSearchDto);
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/report/agincstatement";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.UploadString(path, "POST", jsonObj);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                {
                    return null;
                }
                else
                {
                    Data = JsonConvert.DeserializeObject<List<AgentIncomeStatementDto>>(responseString);
                    return Data;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }
        public List<AgentDayEndSummeryDto> getAgentDayEndSummaryDtoList(AccountSearchDto accountSearchDto)
        {
            List<AgentDayEndSummeryDto> Data = new List<AgentDayEndSummeryDto>();
            string jsonObj = JsonConvert.SerializeObject(accountSearchDto);
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/report/agentdayendsummery";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.UploadString(path, "POST", jsonObj);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                {
                    return null;
                }
                else
                {
                    Data = JsonConvert.DeserializeObject<List<AgentDayEndSummeryDto>>(responseString);
                    return Data;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        #region WALI :: 21-Jul-2015
        public static List<AgentCommissionInfoDto> GetAgentCommissionInformation(AccountSearchDto searchDto)
        {
            List<AgentCommissionInfoDto> Data = new List<AgentCommissionInfoDto>();

            string jsonObj = JsonConvert.SerializeObject(searchDto);
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/report/agentcommission";
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
                        Data = ser.ReadObject(ms) as List<AgentCommissionInfoDto>;
                    }
                    return Data;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }

        }
        public static List<AgentTransactionMonitoringDto> GetAgentTrMonitorInformaiton(AccountSearchDto searchDto)
        {
            List<AgentTransactionMonitoringDto> Data = new List<AgentTransactionMonitoringDto>();

            string jsonObj = JsonConvert.SerializeObject(searchDto);
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/report/agenttrmonitoring";
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
                        Data = ser.ReadObject(ms) as List<AgentTransactionMonitoringDto>;
                    }
                    return Data;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }

        }
        public static List<AccountMonitoringDto> GetAccountMonitorInformaiton(AccountSearchDto searchDto)
        {
            List<AccountMonitoringDto> Data = new List<AccountMonitoringDto>();

            string jsonObj = JsonConvert.SerializeObject(searchDto);
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/report/accountmonitoring";
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
                        Data = ser.ReadObject(ms) as List<AccountMonitoringDto>;
                    }
                    return Data;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }

        }
        #endregion

        public List<OutletReportDto> getOutletInformationReportList(OutletReportSearchDto outletInfoSearchDto)
        {
            List<OutletReportDto> Data = new List<OutletReportDto>();
            var jsonString = JsonConvert.SerializeObject(outletInfoSearchDto);
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/subagentinfo/outletreport";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.UploadString(path, "POST", jsonString);
                string serviceResponse = UtilityCom.getServerResponse(client);
                if (!serviceResponse.Equals("OK")) return null;
                else
                {
                    Data = JsonConvert.DeserializeObject<List<OutletReportDto>>(responseString);
                    return Data;
                }
            }
            catch (WebException webEx)
            { throw new Exception(UtilityCom.parseErrorData(webEx)); }
        }
        public List<AgentReportDto> getAgentInformationReportList()
        {
            List<AgentReportDto> Data = new List<AgentReportDto>();
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/agentinfo/agents";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.DownloadString(path);
                string serviceResponse = UtilityCom.getServerResponse(client);
                if (!serviceResponse.Equals("OK")) return null;
                else
                {
                    Data = JsonConvert.DeserializeObject<List<AgentReportDto>>(responseString);
                    return Data;
                }
            }
            catch (WebException webEx)
            { throw new Exception(UtilityCom.parseErrorData(webEx)); }
        }
        public AgentBalanceDto getAgentBalanceDetails(AgentBalanceReqDto reqDto)
        {
            AgentBalanceDto Data = new AgentBalanceDto();
            var jsonString = JsonConvert.SerializeObject(reqDto);
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/agentinfo/outletcash/";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.UploadString(path, "POST", jsonString);
                string serviceResponse = UtilityCom.getServerResponse(client);
                if (!serviceResponse.Equals("OK")) return null;
                else
                {
                    Data = JsonConvert.DeserializeObject<AgentBalanceDto>(responseString);
                    return Data;
                }
            }
            catch (WebException webEx)
            { throw new Exception(UtilityCom.parseErrorData(webEx)); }
        }

    }
}
