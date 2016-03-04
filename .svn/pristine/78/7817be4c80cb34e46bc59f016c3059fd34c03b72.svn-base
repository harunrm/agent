using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using MISL.Ababil.Agent.Infrastructure.Mediators;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account.kyc;

namespace MISL.Ababil.Agent.Communication
{
    public class KycCom
    {
        public List<MediatorKycAccountOpeningMode> GetAccountOpeningModes()
        {
            List<MediatorKycAccountOpeningMode> listData = new List<MediatorKycAccountOpeningMode>();

            string path = SessionInfo.rootServiceUrl + "resources/kyc/accountopeningmodes";
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
                        listData = ser.ReadObject(ms) as List<MediatorKycAccountOpeningMode>;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return listData;
        }

        public List<MediatorKycCustomerTurnover> GetCustomerTurnovers()
        {
            List<MediatorKycCustomerTurnover> listData = new List<MediatorKycCustomerTurnover>();
            string path = SessionInfo.rootServiceUrl + "resources/kyc/customerturnovers";
            using (WebClient client = new WebClient())
            {
                try
                {
                    NameValueCollection reqparm = new NameValueCollection();
                    string responseString = JsonCom.getJson(reqparm, path);

                    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    {
                        var ser = new DataContractJsonSerializer(listData.GetType());
                        listData = ser.ReadObject(ms) as List<MediatorKycCustomerTurnover>;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return listData;
        }

        public List<MediatorKycMonthTxnAmount> GetTxnAmounts()
        {
            List<MediatorKycMonthTxnAmount> listData = new List<MediatorKycMonthTxnAmount>();
            string path = SessionInfo.rootServiceUrl + "resources/kyc/monthtxnamounts";
            using (WebClient client = new WebClient())
            {
                try
                {
                    NameValueCollection reqparm = new NameValueCollection();
                    string responseString = JsonCom.getJson(reqparm, path);

                    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    {
                        var ser = new DataContractJsonSerializer(listData.GetType());
                        listData = ser.ReadObject(ms) as List<MediatorKycMonthTxnAmount>;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return listData;
        }

        public List<MediatorKycMonthTxnNumber> GetTxnNumbers()
        {
            List<MediatorKycMonthTxnNumber> listData = new List<MediatorKycMonthTxnNumber>();
            string path = SessionInfo.rootServiceUrl + "resources/kyc/monthtxnnumbers";
            using (WebClient client = new WebClient())
            {
                try
                {
                    NameValueCollection reqparm = new NameValueCollection();
                    string responseString = JsonCom.getJson(reqparm, path);

                    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    {
                        var ser = new DataContractJsonSerializer(listData.GetType());
                        listData = ser.ReadObject(ms) as List<MediatorKycMonthTxnNumber>;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return listData;
        }

        public List<MediatorKycCashMonthlyTxnAmount> GetCashMonthlyTxnAmounts()
        {
            List<MediatorKycCashMonthlyTxnAmount> listData = new List<MediatorKycCashMonthlyTxnAmount>();
            string path = SessionInfo.rootServiceUrl + "resources/kyc/cashmonthlytxnamounts";
            using (WebClient client = new WebClient())
            {
                try
                {
                    NameValueCollection reqparm = new NameValueCollection();
                    string responseString = JsonCom.getJson(reqparm, path);

                    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    {
                        var ser = new DataContractJsonSerializer(listData.GetType());
                        listData = ser.ReadObject(ms) as List<MediatorKycCashMonthlyTxnAmount>;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return listData;
        }

        public List<MediatorKycCashMonthlyTxnNumber> GetCashMonthlyTxnNumbers()
        {
            List<MediatorKycCashMonthlyTxnNumber> listData = new List<MediatorKycCashMonthlyTxnNumber>();
            string path = SessionInfo.rootServiceUrl + "resources/kyc/cashmonthlytxnnumber";
            using (WebClient client = new WebClient())
            {
                try
                {
                    NameValueCollection reqparm = new NameValueCollection();
                    string responseString = JsonCom.getJson(reqparm, path);

                    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    {
                        var ser = new DataContractJsonSerializer(listData.GetType());
                        listData = ser.ReadObject(ms) as List<MediatorKycCashMonthlyTxnNumber>;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return listData;
        }

        public KycProfile GetKycProfile(long profileId)
        {
            KycProfile Data = new KycProfile();
            string path = SessionInfo.rootServiceUrl + "resources/kyc/profile/" + profileId;
            try
            {
                NameValueCollection reqparm = new NameValueCollection();
                string responseString = JsonCom.getJson(reqparm, path);
                if (responseString == "NotFound")
                {
                    return null;
                }
                else if(responseString=="Unable to connect to the remote server")
                {
                    return null;
                }
                else 
                {
                    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    {
                        var ser = new DataContractJsonSerializer(Data.GetType());
                        Data = ser.ReadObject(ms) as KycProfile;
                    }
                    return Data;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string saveKyc(string json)
        {
            //string responseString = "";
            string path = SessionInfo.rootServiceUrl + "resources/kyc/save";
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
            //else if (responseString == "NotFound")
            //{
            //    return "Profile data update failed";
            //}
            //else
            //    return responseString;
        }
    }
}