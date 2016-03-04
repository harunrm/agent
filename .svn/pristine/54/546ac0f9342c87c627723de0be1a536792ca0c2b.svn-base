using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using System.Collections.Specialized;
using System.Web.Script.Serialization;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization.Json;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.user;
using MISL.Ababil.Agent.Infrastructure;


namespace MISL.Ababil.Agent.Communication
{
    public class SubAgentService
    {
        public SubAgentInformation getCurrentSubAgentInfo()
        {
            SubAgentInformation Data = new SubAgentInformation();
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/subagentinfo/subagentforreport";
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
                    return Data = JsonConvert.DeserializeObject<SubAgentInformation>(responseString);
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public List<SubAgentInformation> GetAllSubAgents()
        {
            List<SubAgentInformation> Data = new List<SubAgentInformation>();
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/subagentinfo/allsubagentsimple";
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
                    return Data = JsonConvert.DeserializeObject<List<SubAgentInformation>>(responseString);
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public string saveSubAgent(SubAgentInformation subAgentInfo)
        {

            var jsonString = JsonConvert.SerializeObject(subAgentInfo);
            WebClient client = new WebClient();
            try
            {

                string path = SessionInfo.rootServiceUrl + "resources/subagentinfo/save";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.UploadString(path, "POST", jsonString);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                    return null;
                else
                {
                    //using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    //{
                    //    var ser = new DataContractJsonSerializer(typeof(String));
                    //    responseString = ser.ReadObject(ms) as String;
                    //}

                    return responseString;

                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }

        }

        public SubAgentInformation getSubAgentInfoById(string subAgentId)
        {
            SubAgentInformation Data = new SubAgentInformation();
            //string path = SessionInfo.rootServiceUrl + "resources/agentinfo/agent/" + agentId;
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/subagentinfo/subagent/" + subAgentId;
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
                    //    Data = ser.ReadObject(ms) as SubAgentInformation;
                    //}
                    //return Data;
                    return Data = JsonConvert.DeserializeObject<SubAgentInformation>(responseString);
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public List<SubAgentUser> getSubAgentUserList()
        {
            List<SubAgentUser> Data = new List<SubAgentUser>();
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/subagentinfo/subagentuser";
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
                    return Data = JsonConvert.DeserializeObject<List<SubAgentUser>>(responseString);
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public void SaveSubagentCreditLimit(string outletId, decimal? limit)
        {
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/limit/outlet/credit/" + outletId + "/" + limit.ToString();
                client = UtilityCom.setClientHeaders(client);
                byte[] responseString = client.DownloadData(path);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                //if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                //{
                //    return null;
                //}
                //else
                //{
                //    return responseString;
                //}
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }

        }

        public void SetCreditLimit(string outletId, bool status)
        {
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/limit/outlet/setcreditlimit/" + outletId + "/" + (status == false ? "0" : "1");
                client = UtilityCom.setClientHeaders(client);
                byte[] responseString = client.DownloadData(path);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public void SetDebitLimit(string outletId, bool status)
        {
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/limit/outlet/setdebitlimit/" + outletId + "/" + (status == false ? "0" : "1");
                client = UtilityCom.setClientHeaders(client);
                byte[] responseString = client.DownloadData(path);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public void SaveSubagentDebitLimit(string outletId, decimal? limit)
        {
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/limit/outlet/debit/" + outletId + "/" + limit.ToString();
                client = UtilityCom.setClientHeaders(client);
                byte[] responseString = client.DownloadData(path);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                //if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                //{
                //    return null;
                //}
                //else
                //{
                //    return responseString;
                //}
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }

        }


        public List<SubAgentUser> GetSubAgentUserListBySubAgentId(long subAgentId)
        {
            List<SubAgentUser> Data = new List<SubAgentUser>();
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/userinfo/outletuserslimit/" + subAgentId;
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
                    return Data = JsonConvert.DeserializeObject<List<SubAgentUser>>(responseString);
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }
        public ServiceResult SetSubAgentUserCreditLimit(string outletUserId, bool status)
        {
            ServiceResult result = ServiceResult.CreateServiceResult();
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/userinfo/setcreditlimit/" + outletUserId + "/" + (status == false ? 0 : 1);
                client = UtilityCom.setClientHeaders(client);
                byte[] responseString = client.DownloadData(path);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);

                if (responseStatusCode != HttpStatusCode.OK.ToString()) result.Message = responseStatusDescription;
                else
                {
                    result.Message = "User credit limit status changed successfully";
                    result.Success = true;
                }
                return result;
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }
        public ServiceResult SaveSubAgentUserCreditLimit(string outletUserId, decimal? limit)
        {
            ServiceResult result = ServiceResult.CreateServiceResult();
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/userinfo/credit/" + outletUserId + "/" + limit;
                client = UtilityCom.setClientHeaders(client);
                byte[] responseString = client.DownloadData(path);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);

                if (responseStatusCode != HttpStatusCode.OK.ToString()) result.Message = responseStatusDescription;
                else
                {
                    result.Message = "User credit limit saved successfully";
                    result.Success = true;
                }
                return result;
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }

        }
        public ServiceResult SetSubAgentUserDebitLimit(string outletUserId, bool status)
        {
            ServiceResult result = ServiceResult.CreateServiceResult();
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/userinfo/setdebitlimit/" + outletUserId + "/" + (status == false ? 0 : 1);
                client = UtilityCom.setClientHeaders(client);
                byte[] responseString = client.DownloadData(path);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);

                if (responseStatusCode != HttpStatusCode.OK.ToString()) result.Message = responseStatusDescription;
                else
                {
                    result.Message = "User debit limit status changed successfully";
                    result.Success = true;
                }
                return result;
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }
        public ServiceResult SaveSubAgentUserDebitLimit(string outletUserId, decimal? limit)
        {
            ServiceResult result = ServiceResult.CreateServiceResult();
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/userinfo/debit/" + outletUserId + "/" + limit;
                client = UtilityCom.setClientHeaders(client);
                byte[] responseString = client.DownloadData(path);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);

                if (responseStatusCode != HttpStatusCode.OK.ToString()) result.Message = responseStatusDescription;
                else
                {
                    result.Message = "User debit limit saved successfully";
                    result.Success = true;
                }
                return result;
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }

        }

    }
}
