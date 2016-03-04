using MISL.Ababil.Agent.Communication;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.LocalStorageService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace MISL.Ababil.Agent.LocalStorageService.Communication
{
    public class SubagentUserCom
    {
        public SubagentCachingData GetSubagentCachingData(string subagentUser)
        {
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/cache/subagent/cachingdata/" + subagentUser;
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
                    return JsonConvert.DeserializeObject<SubagentCachingData>(responseString);
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }
    }
}