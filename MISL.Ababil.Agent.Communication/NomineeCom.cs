using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.cis;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.nominee;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;

namespace MISL.Ababil.Agent.Communication
{
    public class NomineeCom
    {
        public string deleteNomineeById(long nomineeId)
        {
            List<NomineeInformation> objNominees = new List<NomineeInformation>();
            //string path = SessionInfo.rootServiceUrl + "resources/consumerapp/nominee/" + ConsumerAppId;
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/consumerapp/nomineedelete/" + nomineeId;
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
                    return "Nominee deleted successfully";
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }
        public List<NomineeInformationTemp> getNomineesByConsumerApp(long ConsumerAppId)
        {
            List<NomineeInformationTemp> objNominees = new List<NomineeInformationTemp>();
            //string path = SessionInfo.rootServiceUrl + "resources/consumerapp/nominee/" + ConsumerAppId;
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/consumerapp/tempnominee/" + ConsumerAppId;
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
                    //    var ser = new DataContractJsonSerializer(objNominees.GetType());
                    //    objNominees = ser.ReadObject(ms) as List<NomineeInformation>;
                    //}
                    return objNominees = JsonConvert.DeserializeObject<List<NomineeInformationTemp>>(responseString);
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }
    }
}
