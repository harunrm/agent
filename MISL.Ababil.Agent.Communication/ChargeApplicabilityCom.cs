using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace MISL.Ababil.Agent.Communication
{
    public class ChargeApplicabilityCom
    {
        public bool? IsManualChargeApplicable(AgentServicesType agentServicesType)
        {
            WebClient client = new WebClient();
            try
            {
                // to change this line
                string path = SessionInfo.rootServiceUrl + "resources/charge/manual/" + agentServicesType;
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
                    //return dto = JsonConvert.DeserializeObject<BillPaymentReportDto>(responseString);
                    if (responseString.ToLower() == "y")
                    {
                        return true;
                    }
                    //else if (responseString == "n")
                    //{
                    //    return false;
                    //}
                    else
                    {
                        return null;
                    }
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }
    }
}