using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.user;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Configuration;
using Newtonsoft.Json;

namespace MISL.Ababil.Agent.Communication
{
    public class LoginCom
    {

        public String GetAuthenticationType(string username)
        {
            NameValueCollection formData = HttpUtility.ParseQueryString(String.Empty);
            formData.Add("username", username);


            GatewayClient<String> client = new GatewayClient<String>();
            String type = client.PostForm(SessionInfo.rootServiceUrl + "resources/security/authtype", formData);
            return type;
        }


        public UserLoginData authenticate(string username, string password, string terminal, string bioTemplate)
        {
            UserLoginData Data = new UserLoginData();
            return Data;
        }

        public UserLoginData getUserRigtsWithFingerData(string username, string password, string terminal, string bioTemplate, string serviceLoginUrl)
        {

            UserLoginData Data = new UserLoginData();
            string path = serviceLoginUrl;

            NameValueCollection reqparm = new NameValueCollection();
            reqparm.Add("username", username);
            reqparm.Add("password", password);
            reqparm.Add("terminal", terminal);
            reqparm.Add("bio-template", bioTemplate);
            WebClient client = new WebClient();
            try
            {
                byte[] responsebytes = client.UploadValues(path, "POST", reqparm);
                string responseString = Encoding.UTF8.GetString(responsebytes);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                {
                    return null;
                }
                else
                {
                    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    {
                        var ser = new DataContractJsonSerializer(Data.GetType());
                        Data = ser.ReadObject(ms) as UserLoginData;
                    }
                    return Data;
                }
            }
            catch (WebException webEx)
            {
                if (webEx.Response != null)
                {
                    if (((HttpWebResponse)webEx.Response).StatusCode == HttpStatusCode.NotFound)
                        throw new Exception("Invalid user information");
                    else
                        throw new Exception(UtilityCom.parseErrorData(webEx));
                }
                else
                    throw new Exception(webEx.Message);
            }

        }
        public UserLoginData getUserRigtsWithoutFingerprint(string username, string password, string terminal, string serviceLoginUrl)
        {
            UserLoginData Data = new UserLoginData();
            string path = serviceLoginUrl;
            NameValueCollection reqparm = new NameValueCollection();
            reqparm.Add("username", username);
            reqparm.Add("password", password);
            reqparm.Add("terminal", terminal);
            WebClient client = new WebClient();
            try
            {
                byte[] responsebytes = client.UploadValues(path, "POST", reqparm);
                string responseString = Encoding.UTF8.GetString(responsebytes);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                {
                    return null;
                }
                else
                {
                    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    {
                        var ser = new DataContractJsonSerializer(Data.GetType());
                        Data = ser.ReadObject(ms) as UserLoginData;
                    }
                    return Data;
                }
            }
            catch (WebException webEx)
            {
                if (webEx.Response != null)
                {
                    if (((HttpWebResponse)webEx.Response).StatusCode == HttpStatusCode.NotFound)
                        throw new Exception("Invalid user information");
                    else
                        throw new Exception(UtilityCom.parseErrorData(webEx));
                }
                else
                    throw new Exception(webEx.Message);
            }
        }
        public UserLoginData getUserRigtsWithFingerDataAlt(string username, string password, string terminal, string bioTemplate, string serviceLoginUrl)
        {

            UserLoginData Data = new UserLoginData();
            string path = serviceLoginUrl;
            try
            {
                NameValueCollection reqparm = new NameValueCollection();
                reqparm.Add("username", username);
                reqparm.Add("password", password);
                reqparm.Add("terminal", terminal);
                reqparm.Add("bio-template", bioTemplate);
                string responseString = JsonCom.getLoginData(reqparm, path);
                if (responseString == "NotFound")
                {
                    return null;
                }
                else if (responseString == "Unable to connect to the remote server")
                {
                    return null;
                }
                else if (responseString == "The remote server returned an error: (404) Not Found.")
                {
                    return null;
                }
                else
                {
                    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    {
                        var ser = new DataContractJsonSerializer(Data.GetType());
                        Data = ser.ReadObject(ms) as UserLoginData;
                    }
                    return Data;
                }
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public UserLoginData getUserRigtsWithoutFingerprintAlt(string username, string password, string terminal, string serviceLoginUrl)
        {


            UserLoginData Data = new UserLoginData();
            string path = serviceLoginUrl;
            try
            {
                NameValueCollection reqparm = new NameValueCollection();
                reqparm.Add("username", username);
                reqparm.Add("password", password);
                reqparm.Add("terminal", terminal);
                string responseString = JsonCom.getLoginData(reqparm, path);
                if (responseString == "NotFound")
                {
                    return null;
                }
                else if (responseString == "Unable to connect to the remote server")
                {
                    return null;
                }
                else if (responseString == "The remote server returned an error: (404) Not Found.")
                {
                    return null;
                }
                else
                {
                    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    {
                        var ser = new DataContractJsonSerializer(Data.GetType());
                        Data = ser.ReadObject(ms) as UserLoginData;
                    }
                    return Data;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }




        }
        public string getTokenNumber(string username, string password, string terminal, string serviceLoginUrl)
        {
            string tokenNumber = "";
            String path = serviceLoginUrl;
            using (WebClient client = new WebClient())
            {
                try
                {
                    System.Collections.Specialized.NameValueCollection reqparm = new System.Collections.Specialized.NameValueCollection();
                    reqparm.Add("username", username);
                    reqparm.Add("password", password);
                    reqparm.Add("terminal", terminal);
                    byte[] responsebytes = client.UploadValues(path, "POST", reqparm);
                    tokenNumber = Encoding.UTF8.GetString(responsebytes);
                }
                //catch (Exception ex)
                //{
                //    int errorCode = ex.HResult; ;
                //    throw new Exception(ex.Message);
                //}
                catch (Exception e)
                {
                    var w32ex = e as Win32Exception;
                    if (w32ex == null)
                    {
                        w32ex = e.InnerException as Win32Exception;
                        //if (w32ex == null)
                        tokenNumber = "404";
                    }
                    if (w32ex != null)
                    {
                        int code = w32ex.ErrorCode;
                        tokenNumber = code.ToString();
                    }
                }
            }
            return tokenNumber;
        }

        public UserBasicInformationDto GetUserBasicInformation(string userName)
        {

            //--------------
            UserBasicInformationDto Data = new UserBasicInformationDto();
            WebClient client = new WebClient();
            try
            {
                String path = SessionInfo.rootServiceUrl + "resources/userinfo/basicinformation/" + userName;
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.DownloadString(path);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                    return null;
                else
                {
                    Data = JsonConvert.DeserializeObject<UserBasicInformationDto>(responseString);
                    return Data;
                }

                //-------
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }
    }
}
