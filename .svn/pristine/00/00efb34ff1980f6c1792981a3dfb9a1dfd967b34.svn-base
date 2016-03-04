using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.dto;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Text;
using System.Runtime.Serialization.Json;
using System.Net;

namespace MISL.Ababil.Agent.Communication
{
    public class TransactionProfileEditCom
    {
        public List<TransactionProfileDto> GetTransactionProfileByAccountNo(string accNo)
        {
            List<TransactionProfileDto> Data = new List<TransactionProfileDto>();
            string path = SessionInfo.rootServiceUrl + "resources/accountinfo/transactionprofile/" + accNo;
            try
            {
                NameValueCollection reqparm = new NameValueCollection();
                string responseString = JsonCom.getJson(reqparm, path);
                if (responseString == "NotFound")
                {
                    return null;
                }
                if (responseString == "Unable to connect to the remote server")
                {
                    return null;
                }
                using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                {
                    var ser = new DataContractJsonSerializer(Data.GetType());
                    Data = ser.ReadObject(ms) as List<TransactionProfileDto>;
                }
                return Data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //transactionprofile/save
        public string saveTransactionProfileDtoList(List<TransactionProfileDto> transactionProfileDtoList)
        {
            var jsonString = JsonConvert.SerializeObject(transactionProfileDtoList);
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/accountinfo/transactionprofile/save";
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
                        using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                        {
                            var ser = new DataContractJsonSerializer(typeof(String));
                            responseString = ser.ReadObject(ms) as String;
                        }
                        return responseString;
                    }
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }
    }
}