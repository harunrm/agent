using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.ssp;
using Newtonsoft.Json;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.termaccount;

namespace MISL.Ababil.Agent.Communication
{
    public class SSPRequestSearchCom
    {
        public List<TermAccountInformation> getListOfSSPAccountInformation(SspAccountInformationSearchDto sspAccountInformation)
        {
            var jsonString = JsonConvert.SerializeObject(sspAccountInformation);
            List<TermAccountInformation> sspAccountInformationList = new List<TermAccountInformation>();
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/sspaccount/search";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.UploadString(path, "POST", jsonString);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                    return null;
                else
                {
                    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    {
                        var ser = new DataContractJsonSerializer(sspAccountInformationList.GetType());
                        sspAccountInformationList = ser.ReadObject(ms) as List<TermAccountInformation>;
                    }

                    return sspAccountInformationList;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }
    }
}
