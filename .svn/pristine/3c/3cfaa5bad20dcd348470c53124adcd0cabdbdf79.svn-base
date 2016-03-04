using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.cis;
using MISL.Ababil.Agent.Infrastructure.Models.dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;

namespace MISL.Ababil.Agent.Communication
{
    public class CustomerCom
    {

        public List<CustomerInfoDto> getAllListOfCustomer(CustomerSearchDto dto)
        {
            List<CustomerInfoDto> customerInfo = new List<CustomerInfoDto>();
            string jsonstring = JsonConvert.SerializeObject(dto);
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/customerinfo/search";
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.UploadString(path, "POST", jsonstring);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                {
                    return null;
                }
                else
                {
                    return customerInfo = JsonConvert.DeserializeObject<List<CustomerInfoDto>>(responseString);
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }

        }



        //=====================================================================================================///
        public string saveCustomerAccDTO(string jsonString)
        {
            //string responseString = "";
            string path = SessionInfo.rootServiceUrl + "resources/customerinfo/savecustomeraccdto";
            WebClient client = new WebClient();
            client = UtilityCom.setClientHeaders(client);
            try
            {
                string responseString = client.UploadString(path, "POST", jsonString);
                string serviceResponse = UtilityCom.getServerResponse(client);
                return "Customer saved successfully";

            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }
        public string saveCustomer(string jsonString)
        {
            //string responseString = "";
            string path = SessionInfo.rootServiceUrl + "resources/customerinfo/save";
            WebClient client = new WebClient();
            client = UtilityCom.setClientHeaders(client);
            try
            {
                string responseString = client.UploadString(path, "POST", jsonString);
                string serviceResponse = UtilityCom.getServerResponse(client);
                return "Customer saved successfully";

            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }



            //try
            //{
            //    NameValueCollection reqparm = new NameValueCollection();
            //    responseString = JsonCom.postJsonString(reqparm, path, jsonString);
            //    //return responseString = JsonServices.postJson(connHeaders, reqparm, path, jsonString);
            //}
            //catch (Exception ex)
            //{
            //    //throw new Exception(ex.Message);
            //    responseString = ex.Message;
            //}
            //if (responseString == "OK")
            //{
            //    return "Consumer applied successfully";
            //}
            //else if (responseString == "NotFound")
            //{
            //    return "Consumer application failed";
            //}
            //else
            //    return responseString;
        }
        public CustomerAccountDto GetCustomerAccountDtoByAcc(string accNo)
        {
            CustomerAccountDto Data = new CustomerAccountDto();
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/customerinfo/customerbyacc/" + accNo;
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.DownloadString(path);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                    return null;
                else
                {
                    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    {
                        var ser = new DataContractJsonSerializer(Data.GetType());
                        Data = ser.ReadObject(ms) as CustomerAccountDto;
                    }

                    return Data;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }
        public CustomerInformation GetCustomerInfoByConsumerAppId(long ConsumerAppId)
        {
            CustomerInformation Data = new CustomerInformation();
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/consumerapp/customer/" + ConsumerAppId;
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.DownloadString(path);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                    return null;
                else
                {
                    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    {
                        var ser = new DataContractJsonSerializer(Data.GetType());
                        Data = ser.ReadObject(ms) as CustomerInformation;
                    }

                    return Data;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }


        public CustomerInformation GetCustomerInfoByCustomerId(long CustomerId)
        {
            CustomerInformation Data = new CustomerInformation();
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/consumerapp/customerinfo/" + CustomerId;
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.DownloadString(path);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                    return null;
                else
                {
                    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    {
                        var ser = new DataContractJsonSerializer(Data.GetType());
                        Data = ser.ReadObject(ms) as CustomerInformation;
                    }

                    return Data;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public CustomerDto getCustomerInfo(int customerId)
        {
            CustomerDto Data = new CustomerDto();
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/customerinfo/customer/" + customerId;
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.DownloadString(path);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                    return null;
                else
                {
                    Data = JsonConvert.DeserializeObject<CustomerDto>(responseString);
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
