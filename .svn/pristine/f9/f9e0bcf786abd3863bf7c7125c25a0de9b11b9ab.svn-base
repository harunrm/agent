using MISL.Ababil.Agent.Infrastructure.Models.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace MISL.Ababil.Agent.Communication
{
    public class SpecialCom
    {
        public string MoveDocToFlat()
        {
            //List<BillServiceProvider> Data = new List<BillServiceProvider>();
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/setup/moveDocToFlat";
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
                    //return Data = JsonConvert.DeserializeObject<List<BillServiceProvider>>(responseString);
                    return "RSP: " +responseString;
                }
            }
            catch (WebException webEx)
            {
                //throw new Exception(UtilityCom.parseErrorData(webEx));
                return "ERR: " + webEx.Message;
            }
        }
    }
}