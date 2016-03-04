using MISL.Ababil.Agent.Infrastructure.Models.common;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;

namespace MISL.Ababil.Agent.Communication
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
        //public static string postJson(NameValueCollection reqparm, string path, string json)
        //{
        //    string responseString = "";
        //    string errorString = "";
        //    using (var client = new WebClient())
        //    {
        //        client.Headers["username"] = SessionInfo.username;
        //        client.Headers["terminal"] = SessionInfo.terminal;
        //        client.Headers["token"] = SessionInfo.token;
        //        client.Headers[HttpRequestHeader.ContentType] = "application/json";
        //        responseString = client.UploadString(path, "POST", json);
        //        string responseStatusCode = null;
        //        string responseStatusDescription = null;
        //        int responseCode = GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
        //        if (responseStatusCode == HttpStatusCode.OK.ToString())
        //        {
        //            responseString = "Success";
        //        }
        //        else if (responseStatusCode == HttpStatusCode.NotFound.ToString())
        //            responseString = "NotFound";
        //        else
        //        {
        //            WebHeaderCollection responseHd = client.ResponseHeaders;
        //            foreach (string key in responseHd.AllKeys)
        //            {
        //                if (key == "reason")
        //                    responseString = responseHd[key];
        //            }
        //        }

        //        //WebHeaderCollection responseHd = client.ResponseHeaders;
        //        //foreach (string key in responseHd.AllKeys)
        //        //{
        //        //    if (key == "reason")
        //        //        responseString = responseHd[key];
        //        //}
        //    }
        //    return responseString;
        //}
        //public static string postJsonString(NameValueCollection reqparm, string path, string json)
        //{
        //    string responseString = "";
        //    var httpWebRequest = (HttpWebRequest)WebRequest.Create(path);
        //    httpWebRequest.ContentType = "application/json";
        //    httpWebRequest.Method = "POST";
        //    httpWebRequest.Headers["username"] = SessionInfo.username;
        //    httpWebRequest.Headers["terminal"] = SessionInfo.terminal;
        //    httpWebRequest.Headers["token"] = SessionInfo.token;
        //    httpWebRequest.ServicePoint.Expect100Continue = false;
        //    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        //    {
        //        streamWriter.Write(json);
        //        streamWriter.Flush();
        //        streamWriter.Close();
        //    }
        //    try
        //    {
        //        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        //        if (httpResponse.StatusCode == HttpStatusCode.OK)
        //            responseString = "OK";
        //        else if (httpResponse.StatusCode == HttpStatusCode.NotFound)
        //            responseString = "NotFound";
        //        else
        //        {
        //            WebHeaderCollection responseHd = httpResponse.Headers;
        //            foreach (string key in responseHd.AllKeys)
        //            {
        //                if (key == "reason")
        //                    responseString = responseHd[key];
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        responseString = ex.Message;
        //    }
        //    //using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        //    //{
        //    //    responseString = streamReader.ReadToEnd();

        //    //}
            
        //    return responseString;
        //}
        
        

        //public static string postJsonForBalance(NameValueCollection reqparm, string path, string json)
        //{
        //    string responseString = "";
        //    string errorString = "";
        //    using (var client = new WebClient())
        //    {
        //        client.Headers["username"] = SessionInfo.username;
        //        client.Headers["terminal"] = SessionInfo.terminal;
        //        client.Headers["token"] = SessionInfo.token;
        //        client.Headers[HttpRequestHeader.ContentType] = "application/json";
        //        responseString = client.UploadString(path, "POST", json);
        //        string responseStatusCode = null;
        //        string responseStatusDescription = null;
        //        int responseCode = GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
        //        if (responseStatusCode == HttpStatusCode.NotFound.ToString())
        //            responseString = null;
        //        if (responseStatusCode != HttpStatusCode.OK.ToString())
        //        {
        //            WebHeaderCollection responseHd = client.ResponseHeaders;
        //            foreach (string key in responseHd.AllKeys)
        //            {
        //                if (key == "reason")
        //                    responseString = responseHd[key];
        //            }
        //        }

        //        //convert to class





        //        if (responseStatusCode == HttpStatusCode.OK.ToString())
        //        {
        //            //responseString = "Success";
        //        }
        //        else if (responseStatusCode == HttpStatusCode.NotFound.ToString())
        //            responseString = "NotFound";
        //        else
        //        {
        //            WebHeaderCollection responseHd = client.ResponseHeaders;
        //            foreach (string key in responseHd.AllKeys)
        //            {
        //                if (key == "reason")
        //                    responseString = responseHd[key];
        //            }
        //        }

        //        //WebHeaderCollection responseHd = client.ResponseHeaders;
        //        //foreach (string key in responseHd.AllKeys)
        //        //{
        //        //    if (key == "reason")
        //        //        responseString = responseHd[key];
        //        //}
        //    }
        //    return responseString;
        //}
        //public static string postJsonForValue( NameValueCollection reqparm, string path, string json)
        //{
        //    string responseString = "";
        //    string errorString = "";
        //    using (var client = new WebClient())
        //    {
        //        client.Headers["username"] = SessionInfo.username;
        //        client.Headers["terminal"] = SessionInfo.terminal;
        //        client.Headers["token"] = SessionInfo.token;
        //        client.Headers[HttpRequestHeader.ContentType] = "application/json";
        //        responseString = client.UploadString(path, "POST", json);
        //        string responseStatusCode = null;
        //        string responseStatusDescription = null;
        //        int responseCode = GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
        //        if (responseStatusCode == HttpStatusCode.NotFound.ToString())
        //            responseString = null;
        //        if (responseStatusCode != HttpStatusCode.OK.ToString())
        //        {
        //            WebHeaderCollection responseHd = client.ResponseHeaders;
        //            foreach (string key in responseHd.AllKeys)
        //            {
        //                if (key == "reason")
        //                    responseString = responseHd[key];
        //            }
        //        }

        //        //convert to class





        //        if (responseStatusCode == HttpStatusCode.OK.ToString())
        //        {
        //            //responseString = "Success";
        //        }
        //        else if (responseStatusCode == HttpStatusCode.NotFound.ToString())
        //            responseString = "NotFound";
        //        else
        //        {
        //            WebHeaderCollection responseHd = client.ResponseHeaders;
        //            foreach (string key in responseHd.AllKeys)
        //            {
        //                if (key == "reason")
        //                    responseString = responseHd[key];
        //            }
        //        }

        //        //WebHeaderCollection responseHd = client.ResponseHeaders;
        //        //foreach (string key in responseHd.AllKeys)
        //        //{
        //        //    if (key == "reason")
        //        //        responseString = responseHd[key];
        //        //}
        //    }
        //    return responseString;
        //}

    }
}
