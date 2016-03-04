using MISL.Ababil.Agent.Infrastructure.Models.common;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;

namespace MISL.Ababil.Agent.Services.Communication
{
    public class JsonCom
    {
        public static int GetStatusCode(WebClient client, out string statusDescription, out string statusCode)
        {
            FieldInfo responseField = client.GetType().GetField("m_WebResponse", BindingFlags.Instance | BindingFlags.NonPublic);

            if (responseField != null)
            {
                HttpWebResponse response = responseField.GetValue(client) as HttpWebResponse;

                if (response != null)
                {
                    statusDescription = response.StatusDescription;
                    statusCode = response.StatusCode.ToString();
                    return (int)response.StatusCode;
                }
            }

            statusDescription = null;
            statusCode = null;
            return 0;
        }
        public static string getJson(NameValueCollection reqparm, string path)
        {
            string responseString = "";
            using (WebClient client = new WebClient())
            {
                try
                {
                    client.Headers["username"] = SessionInfo.username;
                    client.Headers["terminal"] = SessionInfo.terminal;
                    client.Headers["token"] = SessionInfo.token;

                    responseString = client.DownloadString(path);

                    string responseStatusCode = null;
                    string responseStatusDescription = null;
                    int responseCode = GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                    if (responseStatusCode == HttpStatusCode.OK.ToString())
                    {
                        //nothing to do
                    }
                    else if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                        responseString = "NotFound";
                    else
                    {
                        WebHeaderCollection responseHd = client.ResponseHeaders;
                        foreach (string key in responseHd.AllKeys)
                        {
                            if (key == "reason")
                                responseString = responseHd[key];
                        }
                    }
                }
                catch (Exception ex)
                {
                    //throw new Exception(ex.Message);
                    responseString = ex.Message;
                }
            }
            return responseString;
        }

        public static string getLoginData(NameValueCollection reqparm, string path)
        {



            string responseString = "";
            using (WebClient client = new WebClient())
            {
                try
                {
                    byte[] responsebytes = client.UploadValues(path, "POST", reqparm);
                    responseString = Encoding.UTF8.GetString(responsebytes);

                    string responseStatusCode = null;
                    string responseStatusDescription = null;
                    int responseCode = GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                    if (responseStatusCode == HttpStatusCode.OK.ToString())
                    {
                        //nothing to do
                    }
                    else if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                        responseString = "NotFound";
                    else
                    {
                        WebHeaderCollection responseHd = client.ResponseHeaders;
                        foreach (string key in responseHd.AllKeys)
                        {
                            if (key == "reason")
                                responseString = responseHd[key];
                        }
                    }
                }
                catch (Exception ex)
                {
                    //throw new Exception(ex.Message);
                    responseString = ex.Message;
                }
            }
            return responseString;
        }
    }
}