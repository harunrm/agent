using System;
using System.Collections.Specialized;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using System.Net;
using Newtonsoft.Json;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account;
using MISL.Ababil.Agent.Infrastructure.Models.dto;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using MISL.Ababil.Agent.Infrastructure.Models.reports;

namespace MISL.Ababil.Agent.Communication
{
    public class AccountInformationCom
    {
        public AccountInformation GetAccountInformation(string accountNumber)
        {
            //string path = SessionInfo.rootServiceUrl + "resources/accountinfo/details/" + accountNumber;
            //try
            //{
            //    NameValueCollection reqparm = new NameValueCollection();
            //    //reqparm.Add("username", username);
            //    //reqparm.Add("password", password);
            //    //reqparm.Add("terminal", terminal);
                
            //    string responseString = JsonCom.getJson(reqparm, path);
            //    return responseString;
            //}
            //catch (Exception ex)
            //{
            //    //throw new Exception(ex.Message);
            //    return ex.Message;
            //}
            AccountInformation data = new AccountInformation();
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/accountinfo/details/" + accountNumber;
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.DownloadString(path);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                    return null;
                else
                {
                    data = JsonConvert.DeserializeObject<AccountInformation>(responseString);
                    return data;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }
        public AccountInformationDto GetAccountDto(string accountNumber)
        {
            AccountInformationDto accInfoDto = new AccountInformationDto();
            //string path = SessionInfo.rootServiceUrl + "resources/accountinfo/details/" + accountNumber;
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/accountinfo/details/" + accountNumber;
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
                    return accInfoDto = JsonConvert.DeserializeObject<AccountInformationDto>(responseString);
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public static List<CashRegisterDto> GetCashRegister(DailyTrnRecordSearchDto searcDto)
        {
            List<CashRegisterDto> Data = new List<CashRegisterDto>();

            string jsonObj = JsonConvert.SerializeObject(searcDto);
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/report/cashregister";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.UploadString(path, "POST", jsonObj);
                string serviceResponse = UtilityCom.getServerResponse(client);
                if (!serviceResponse.Equals("OK"))
                {
                    return null;
                }
                else
                {
                    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    {
                        var ser = new DataContractJsonSerializer(Data.GetType());
                        Data = ser.ReadObject(ms) as List<CashRegisterDto>;
                    }
                    return Data;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

    }
}