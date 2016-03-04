using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;

namespace MISL.Ababil.Agent.Communication
{
    public class PasswordChangeCom
    {
        public string savePasswordChange(passwordChangeInfo pcInfo)
        {
            var jsonString = JsonConvert.SerializeObject(pcInfo); //new JavaScriptSerializer().Serialize(remittance);
            WebClient client = new WebClient();
            ////try
            ////{
            string path = SessionInfo.rootServiceUrl + "resources/security/users/password";
            client = UtilityCom.setClientHeaders(client);
            string responseString = client.UploadString(path, "POST", jsonString);
            string responseStatusCode;
            string responseStatusDescription;
            JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
            if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                return null;           
            else
            {

                if (responseString == "")
                {
                    return null;
                }
                else
                {                    
                    return responseString;
                }
            }
            ////}
            ////catch (Exception ex)
            ////{
            ////    throw new Exception();
            ////    //throw new Exception(UtilityCom.parseErrorData(webEx));
            ////}
            //return null;
        }
    }
}
