using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using System.IO;
using Newtonsoft.Json;

/**
 * Author: Syed Hasan Rahmatullah
 * Start Date: 2015-06-11
 */

namespace MISL.Ababil.Agent.Communication
{
    class GatewayClient<T>
    {
        public T Get(string path)
        {

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(path);
                request.Method = "GET";
                SetDefaults(request);

                return GetResponseData(request);

            }
            catch (Exception we)
            {
                HandleException(we);
            }

            return default(T);
        }

        public T PostForm(string path, System.Collections.Specialized.NameValueCollection formData)
        {

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(path);
                request.ContentType = "application/x-www-form-urlencoded";
                request.Method = "POST";
                request.Accept = "application/json";
                SetDefaults(request);
                PostData(request, formData.ToString());
                return GetResponseData(request);
            }
            catch (Exception we)
            {
                return HandleException(we);
            }

            return default(T);
        }

        public T PostJson(string path, Object obj)
        {

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(path);
                request.ContentType = "application/json";
                request.Method = "POST";

                SetDefaults(request);

                string jsonData = JsonConvert.SerializeObject(obj);

                PostData(request, jsonData.ToString());

                return GetResponseData(request);
            }
            catch (Exception we)
            {
                HandleException(we);
            }

            return default(T);
        }

        public void Delete(string path)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(path);
                request.Method = "DELETE";
                SetDefaults(request);

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.NoContent)
                {
                    return;
                }

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    HandleException(response);
                }
            }
            catch (Exception we)
            {
                HandleException(we);
            }
        }


        private void PostData(HttpWebRequest request, string data)
        {
            byte[] dateBytes = Encoding.UTF8.GetBytes(data);
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(dateBytes, 0, dateBytes.Length);
            requestStream.Flush();
            requestStream.Close();
        }

        private T GetResponseData(HttpWebRequest request)
        {
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.NoContent)
            {
                return default(T);
            }

            if (response.StatusCode != HttpStatusCode.OK)
            {
                HandleException(response);
            }

            //if (response.ContentLength > 0)
            {
                string data = ReadFromStream(response.GetResponseStream());

                data = data.Trim();
                data = ((data.StartsWith("{") && data.EndsWith("}")) ||
                        (data.StartsWith("[") && data.EndsWith("]"))) ?
                         data : (data.StartsWith("\"") && data.EndsWith("\"")) ?
                         data : "\"" + data + "\"";

                return JsonConvert.DeserializeObject<T>(data);
            }

            //return default(T);
        }


        private void SetDefaults(HttpWebRequest request)
        {
            if (SessionInfo.username != null && SessionInfo.username != "")
            {                
                request.Headers["username"] = SessionInfo.username;
                request.Headers["terminal"] = SessionInfo.terminal;
                request.Headers["token"] = SessionInfo.token;
            }
            request.Headers["Accept-Charset"] = "UTF-8";
        }

        private T HandleException(Exception ex)
        {
            if (ex is WebException)
            {

                HttpWebResponse response = (HttpWebResponse)((WebException)ex).Response;
                if (response == null)
                {

                    throw new CommunicationException("Communication Error.", ex);

                }

                if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.NoContent)
                {
                    return default(T);
                }

                return HandleException(response, ex);
            }
            else
            {
                throw new CommunicationException(ex.Message, ex);
            }
        }

        private T HandleException(WebResponse response, Exception ex)
        {
            String reason = response.Headers["reason"];
            if (reason != null)
            {
                if (ex != null)
                    throw new CommunicationException(reason, ex);
                else
                    throw new CommunicationException(reason);
            }
            else
            {
                throw new CommunicationException("An unhandled exception has occurred. Please contact your system administrator", ex);
            }
        }

        private T HandleException(HttpWebResponse response)
        {
            return this.HandleException(response, null);
        }

        private string ReadFromStream(Stream stream)
        {
            StreamReader reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

    }
}
