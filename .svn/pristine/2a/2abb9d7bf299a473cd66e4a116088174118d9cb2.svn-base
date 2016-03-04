using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.cis;
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
    public class IndividualCom
    {
        public string saveIndividual(string jsonString)
        {
            //string responseString = "";
            string path = SessionInfo.rootServiceUrl + "resources/individualinfo/save";
            WebClient client = new WebClient();
            client = UtilityCom.setClientHeaders(client);
            try
            {
                string responseString = client.UploadString(path, "POST", jsonString);
                string serviceResponse = UtilityCom.getServerResponse(client);
                return "Individual saved successfully";

            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }


            //try
            //{
            //    NameValueCollection reqparm = new NameValueCollection();
            //    //reqparm.Add("username", username);
            //    //reqparm.Add("password", password);
            //    //reqparm.Add("terminal", terminal);
            //    responseString = JsonCom.postJsonString(reqparm, path, jsonString);
            //    //return responseString = JsonServices.postJson(connHeaders, reqparm, path, jsonString);
            //}
            //catch (Exception ex)
            //{
            //    //throw new Exception(ex.Message);
            //    responseString = ex.Message;
            //}
            //if (responseString == "OK")
            //{
            //    return "Individual created successfully";
            //}
            //else if (responseString == "NotFound")
            //{
            //    return "Individual creation failed";
            //}
            //else
            //    return responseString;
        }
        public IndividualInformation getIndividualInfo(long IndividualId)
        {
            IndividualInformation objIndividualInfo = new IndividualInformation();

            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/individualinfo/ind/" + IndividualId;
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
                    return objIndividualInfo = JsonConvert.DeserializeObject<IndividualInformation>(responseString);
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }

            //try
            //{
            //    NameValueCollection reqparm = new NameValueCollection();
            //    string responseString = JsonCom.getJson(reqparm, path);
            //    //string responseString2 = "";
            //    if (responseString == "NotFound")
            //    {
            //        return null;
            //    }
            //    else if (responseString == "Unable to connect to the remote server")
            //    {
            //        return null;
            //    }
            //    else
            //    {
            //        using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
            //        {
            //            var ser = new DataContractJsonSerializer(objIndividualInfo.GetType());
            //            objIndividualInfo = ser.ReadObject(ms) as IndividualInformation;
            //        }
            //        return objIndividualInfo;
            //    }
            //}
            //catch (WebException webEx)
            //{
            //    throw new Exception(UtilityCom.parseErrorData(webEx));
            //}
        }
    }
}
