using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account.tp;

namespace MISL.Ababil.Agent.Communication
{
    public class TransactionProfileCom
    {
        public List<CbsTransactionProfile> GetTransactionProfiles()
        {
            List<CbsTransactionProfile> listData = new List<CbsTransactionProfile>();

            string path = SessionInfo.rootServiceUrl + "resources/transaction/profiles";
            string responseString;

            using (WebClient client = new WebClient())
            {
                try
                {
                    NameValueCollection reqparm = new NameValueCollection();
                    responseString = JsonCom.getJson(reqparm, path);

                    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    {
                        var ser = new DataContractJsonSerializer(listData.GetType());
                        listData = ser.ReadObject(ms) as List<CbsTransactionProfile>;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return listData;
        }

        public CbsTxnProfileSet GetCbsTxnProfileSet(long profileSetId)
        {
            CbsTxnProfileSet Data = new CbsTxnProfileSet();
            string path = SessionInfo.rootServiceUrl + "resources/transaction/profiles/sets/" + profileSetId;
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
                    Data = ser.ReadObject(ms) as CbsTxnProfileSet;
                }
                return Data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string SaveTransactionProfile(string json)
        {
            //string responseString = "";
            string path = SessionInfo.rootServiceUrl + "resources/transaction/profiles/limits";
            WebClient client = new WebClient();
            client = UtilityCom.setClientHeaders(client);
            try
            {
                string responseString = client.UploadString(path, "POST", json);
                string serviceResponse = UtilityCom.getServerResponse(client);
                return responseString;
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
            
            //try
            //{
            //    NameValueCollection reqparm = new NameValueCollection();
            //    responseString = JsonCom.postJsonForBalance(reqparm, path, json);
            //    //return responseString = JsonServices.postJson(connHeaders, reqparm, path, jsonString);
            //}
            //catch (Exception ex)
            //{
            //    //throw new Exception(ex.Message);
            //    responseString = ex.Message;
            //}
            //if (responseString == "OK")
            //{
            //    return "Profile data saved successfully";
            //}
            //if (responseString == "NotFound")
            //{
            //    return "Profile data update failed";
            //}
            //return responseString;
        }

    }
}