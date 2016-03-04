using MISL.Ababil.Agent.Infrastructure.Models.common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace MISL.Ababil.Agent.Services.Communication
{
    public class WebClientCommunicator<RequestType, ResponseType>
    {
        public ResponseType GetPostResult(RequestType request, string url)
        {
            return ProcessRequest(request, url, MethodType.POST);
        }

        public ResponseType GetResult(string url, params string[] requestParams)
        {
            string urlPart = (requestParams.Length == 0) ? string.Empty : string.Join("/", requestParams);
            return ProcessRequest(default(RequestType), url + urlPart, MethodType.GET);
        }

        private ResponseType ProcessRequest(RequestType request, string url, MethodType method)
        {
            var jsonString = (method == MethodType.POST) ? JsonConvert.SerializeObject(request) : null;
            WebClient client = new WebClient();
            
            try
            {
                string path = SessionInfo.rootServiceUrl + url;
                client = SetClientHeaders(client);

                string responseString = "";
                if (method == MethodType.POST)
                {
                    responseString = client.UploadString(path, method.ToString(), jsonString);
                }
                else if (method == MethodType.GET)
                {
                    responseString = client.DownloadString(path);
                }

                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode != HttpStatusCode.OK.ToString())
                {
                    return default(ResponseType);
                }
                else
                {
                    return (ResponseType)JsonConvert.DeserializeObject<ResponseType>(responseString);
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(ParseErrorData(webEx));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private enum MethodType
        {
            GET,
            POST
        }

        public static WebClient SetClientHeaders(WebClient client)
        {
            client.Headers["username"] = SessionInfo.username;
            client.Headers["terminal"] = SessionInfo.terminal;
            client.Headers["token"] = SessionInfo.token;
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            return client;
        }

        public static string ParseErrorData(WebException webEx)
        {

            string responseString;
            if (webEx.Response != null)
            {
                responseString = webEx.Response.Headers.Get("reason");
                if (responseString == null)
                {
                    responseString = "Communication error";
                }
            }
            else
                responseString = webEx.Message;
            return responseString;

        }
    }
}