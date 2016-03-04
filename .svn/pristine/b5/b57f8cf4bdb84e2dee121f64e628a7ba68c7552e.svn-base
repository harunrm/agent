using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Script.Serialization;
using com.mislbd.agentbanking.report.dto;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.consumer;
using MISL.Ababil.Agent.Infrastructure.Models.dto;
using MISL.Ababil.Agent.Infrastructure.Models.reports;
using Newtonsoft.Json;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.cis;

namespace MISL.Ababil.Agent.Communication
{
    public class ConsumerCom
    {

        // ===================================================================Bill payment=======================================//
        public BillPaymentReportDto GetBillPaymentReportDto(string voucherNumber)
        {
            // return null;

            BillPaymentReportDto dto = new BillPaymentReportDto();

            WebClient client = new WebClient();

            try
            {
                // to change this line
                String path = SessionInfo.rootServiceUrl + "resources/report/billpayment/" + voucherNumber;
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
                    return dto = JsonConvert.DeserializeObject<BillPaymentReportDto>(responseString);
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        // ==========================================================================================================//


        public byte[] GetConsumerPhotoByAppId(long consumerAppId)
        {
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/consumerapp/photo/" + consumerAppId;
                client = UtilityCom.setClientHeaders(client);
                byte[] responseString = client.DownloadData(path);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                {
                    return null;
                }
                else
                {
                    return responseString;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public string GetConsumerPhotoByAppIdA(long consumerAppId)
        {
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/consumerapp/photo/" + consumerAppId;
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
                    return responseString;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public ConsumerApplicationReportDto GetConsumerApplicationReportDto(string refrenceNumber)
        {
            //ConsumerApplicationReportDto dto = new ConsumerApplicationReportDto();

            ////dto.
            ////consumerapplication/nationalid/
            //String path = SessionInfo.rootServiceUrl + "resources/report/consumerapplication/refrence/" + refrenceNumber;

            //string responseString;
            //try
            //{
            //    NameValueCollection reqparm = new NameValueCollection();
            //    //reqparm.Add("username", username);
            //    //reqparm.Add("password", password);
            //    //reqparm.Add("terminal", terminal);
            //    responseString = JsonCom.getJson(reqparm, path);
            //    //dto = new JavaScriptSerializer().Deserialize<ConsumerApplicationReportDto>(responseString);

            //    //using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
            //    //{
            //    //    var ser = new DataContractJsonSerializer(dto.GetType());
            //    //    dto = ser.ReadObject(ms) as ConsumerApplicationReportDto;
            //    //}

            //    dto = JsonConvert.DeserializeObject<ConsumerApplicationReportDto>(responseString);


            //    return dto;
            //}
            //catch (Exception ex)
            //{

            //    return dto;
            //}

            ConsumerApplicationReportDto Data = new ConsumerApplicationReportDto();
            WebClient client = new WebClient();
            try
            {
                String path = SessionInfo.rootServiceUrl + "resources/report/consumerapplication/refrence/" + refrenceNumber;
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.DownloadString(path);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                    return null;
                else
                {
                    Data = JsonConvert.DeserializeObject<ConsumerApplicationReportDto>(responseString);
                    return Data;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }
        public ApprovedConsumerAppReportDto GetApprovedConsumerAppReportDto(string refrenceNumber)
        {
            //ApprovedConsumerAppReportDto dto = new ApprovedConsumerAppReportDto();

            ////dto.
            ////consumerapplication/nationalid/
            //String path = SessionInfo.rootServiceUrl + "resources/report/approvedconsumerapp/" + refrenceNumber;
            //string responseString;
            //try
            //{
            //    NameValueCollection reqparm = new NameValueCollection();
            //    //reqparm.Add("username", username);
            //    //reqparm.Add("password", password);
            //    //reqparm.Add("terminal", terminal);
            //    responseString = JsonCom.getJson(reqparm, path);
            //    //dto = new JavaScriptSerializer().Deserialize<ApprovedConsumerAppReportDto>(responseString);

            //    //using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
            //    //{
            //    //    var ser = new DataContractJsonSerializer(dto.GetType());
            //    //    dto = ser.ReadObject(ms) as ApprovedConsumerAppReportDto;
            //    //}

            //    dto = JsonConvert.DeserializeObject<ApprovedConsumerAppReportDto>(responseString);


            //    return dto;
            //}
            //catch (Exception ex)
            //{

            //    return dto;
            //}

            ApprovedConsumerAppReportDto Data = new ApprovedConsumerAppReportDto();
            WebClient client = new WebClient();
            try
            {
                String path = SessionInfo.rootServiceUrl + "resources/report/approvedconsumerapp/" + refrenceNumber;
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.DownloadString(path);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                    return null;
                else
                {
                    Data = JsonConvert.DeserializeObject<ApprovedConsumerAppReportDto>(responseString);
                    return Data;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public String changeApplicationStatus(ApplicationStatusChangeDto applicationStatusChangeDto, ApplicationStatus applicationStatus)
        {

            var jsonString = JsonConvert.SerializeObject(applicationStatusChangeDto);
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/consumerapp/request/";

                switch (applicationStatus)
                {
                    case ApplicationStatus.submitted:

                        break;
                    case ApplicationStatus.verified:
                        path += "verify";
                        break;

                    case ApplicationStatus.canceled:
                        path += "reject";
                        break;
                    case ApplicationStatus.approved:
                        path += "approve";
                        break;
                    case ApplicationStatus.correction:
                        path += "correction";
                        break;
                    default:
                        break;
                }

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
                        //using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                        //{
                        //    var ser = new DataContractJsonSerializer(typeof(string));
                        //    responseString = ser.ReadObject(ms) as string;
                        //}
                        return responseString;
                    }
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }



        }

        public CustomerInformation getCustomerByAppId(long id)
        {

            CustomerInformation customerInformation = new CustomerInformation();
            WebClient client = new WebClient();
            try
            {
                String path = SessionInfo.rootServiceUrl + "resources/customerinfo/customerbyappid/" + id;
                client = UtilityCom.setClientHeaders(client);
                string responseString = client.DownloadString(path);
                string responseStatusCode;
                string responseStatusDescription;
                JsonCom.GetStatusCode(client, out responseStatusDescription, out responseStatusCode);
                if (responseStatusCode == HttpStatusCode.NotFound.ToString())
                    return null;
                else
                {
                    customerInformation = JsonConvert.DeserializeObject<CustomerInformation>(responseString);
                    return customerInformation;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }

        }

        public string applyConsumer(CustomerApplyDto customerApplyDto)
        {

            string jsonstring = JsonConvert.SerializeObject(customerApplyDto);
            WebClient client = new WebClient();
            client = UtilityCom.setClientHeaders(client);
            string path = SessionInfo.rootServiceUrl + "resources/consumerapp/apply";
            string responseString = "";
            try
            {
                responseString = client.UploadString(path, "POST", jsonstring);
                string serviceResponse = UtilityCom.getServerResponse(client);
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
            return responseString;
        }

        public ConsumerApplication getListOfConsumerApplication(string referenceNumber)
        {
            ConsumerApplication consumerApplications = new ConsumerApplication();
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/consumerapp/app/" + referenceNumber;
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
                    return consumerApplications = JsonConvert.DeserializeObject<ConsumerApplication>(responseString);
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public List<ConsumerAppResultDto> getListOfConsumerApplications(ConsumerApplicationDto dto)
        {
            //ConsumerAppResultDto


            List<ConsumerAppResultDto> consumerAppResultDto = new List<ConsumerAppResultDto>();
            //JavaScriptSerializer js = new JavaScriptSerializer();
            string jsonstring = JsonConvert.SerializeObject(dto);

            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/consumerapp/search";
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
                    return consumerAppResultDto = JsonConvert.DeserializeObject<List<ConsumerAppResultDto>>(responseString);
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }

        public List<ConsumerApplication> getListOfConsumerApplicationsA(ConsumerApplicationDto dto)
        {
            List<ConsumerApplication> consumerApplications = new List<ConsumerApplication>();
            //JavaScriptSerializer js = new JavaScriptSerializer();
            string jsonstring = JsonConvert.SerializeObject(dto);

            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/consumerapp/searchapp";
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
                    return consumerApplications = JsonConvert.DeserializeObject<List<ConsumerApplication>>(responseString);
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }

        }

        public List<ConsumerApplication> getAllListOfConsumerApplications(AllApplicationSearchDto dto)
        {
            List<ConsumerApplication> consumerApplications = new List<ConsumerApplication>();
            //JavaScriptSerializer js = new JavaScriptSerializer();
            string jsonstring = JsonConvert.SerializeObject(dto);

            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/consumerapp/allapplication/search";
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
                    return consumerApplications = JsonConvert.DeserializeObject<List<ConsumerApplication>>(responseString);
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }

        }

        public ConsumerInformationDto getConsumerInformationDtoByAcc(string accountNo)
        {

            ConsumerInformationDto consumerInformationDto = new ConsumerInformationDto();
            WebClient client = new WebClient();
            try
            {
                string path = SessionInfo.rootServiceUrl + "resources/accountinfo/" + accountNo;
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
                    using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                    {
                        var ser = new DataContractJsonSerializer(consumerInformationDto.GetType());
                        consumerInformationDto = ser.ReadObject(ms) as ConsumerInformationDto;
                    }

                    return consumerInformationDto;
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }


        public string saveConsumer(string jsonString, ApplicationStatus appStatus)
        {
            //string responseString = "";
            string path = "";
            if (appStatus == ApplicationStatus.draft_at_branch)
                path = SessionInfo.rootServiceUrl + "resources/consumerapp/draftatbranch";
            if (appStatus == ApplicationStatus.draft)
                path = SessionInfo.rootServiceUrl + "resources/consumerapp/draft";
            else if (appStatus == ApplicationStatus.submitted)
                path = SessionInfo.rootServiceUrl + "resources/consumerapp/submit";
            else if (appStatus == ApplicationStatus.verified)
                path = SessionInfo.rootServiceUrl + "resources/consumerapp/verify";
            else if (appStatus == ApplicationStatus.approved)
                path = SessionInfo.rootServiceUrl + "resources/consumerapp/approve";
            else if (appStatus == ApplicationStatus.canceled)
                path = SessionInfo.rootServiceUrl + "resources/consumerapp/cancel";
            else if (appStatus == ApplicationStatus.correction)
                path = SessionInfo.rootServiceUrl + "resources/consumerapp/correction";

            WebClient client = new WebClient();
            client = UtilityCom.setClientHeaders(client);
            try
            {
                string responseString = client.UploadString(path, "POST", jsonString);
                string serviceResponse = UtilityCom.getServerResponse(client);
                if (appStatus == ApplicationStatus.draft_at_branch)
                    return responseString;
                if (appStatus == ApplicationStatus.draft)
                    return responseString;
                else if (appStatus == ApplicationStatus.submitted)
                    return "Consumer application submitted successfully";
                else if (appStatus == ApplicationStatus.verified)
                    return "Consumer application sent for verification successfully";
                else if (appStatus == ApplicationStatus.approved)
                    return "Consumer application approved successfully";
                else if (appStatus == ApplicationStatus.canceled)
                    return "Consumer application rejected successfully";
                else if (appStatus == ApplicationStatus.correction)
                    return "Application sent back for correction.";
                else
                    return "Successfull";

            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }


        public CashwithdrawlReportDto GetCashWithDrawlReportDto(string voucherNumber)
        {
            /*
                        CashwithdrawlReportDto dto= new CashwithdrawlReportDto();

                         //consumerapplication/nationalid/

                        string responseString;
                        try
                        {
                            NameValueCollection reqparm = new NameValueCollection();
                            //reqparm.Add("username", username);
                            //reqparm.Add("password", password);
                            //reqparm.Add("terminal", terminal);
                            responseString = JsonCom.getJson(reqparm, path);
                            dto = new JavaScriptSerializer().Deserialize<CashwithdrawlReportDto>(responseString);

                            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                            {
                                var ser = new DataContractJsonSerializer(dto.GetType());
                                dto = ser.ReadObject(ms) as CashwithdrawlReportDto;
                            }


                            return dto;
                        }
                        catch (Exception ex)
                        {

                            return dto;
                        }


                        return null;

                        */

            // ConsumerInformationDto consumerInformationDto = new ConsumerInformationDto();

            CashwithdrawlReportDto dto = new CashwithdrawlReportDto();

            WebClient client = new WebClient();
            try
            {
                String path = SessionInfo.rootServiceUrl + "resources/report/withdrawl/" + voucherNumber;
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
                    return dto = JsonConvert.DeserializeObject<CashwithdrawlReportDto>(responseString);
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }


        public DepositReportDto GetCashDepositReportDto(string voucherNumber)
        {
            /*
            DepositReportDto dto = new DepositReportDto();

            //consumerapplication/nationalid/
            String path = SessionInfo.rootServiceUrl + "resources/report/depositinformation/" + voucherNumber;
            string responseString;
            try
            {
                NameValueCollection reqparm = new NameValueCollection();
                //reqparm.Add("username", username);
                //reqparm.Add("password", password);
                //reqparm.Add("terminal", terminal);
                responseString = JsonCom.getJson(reqparm, path);
                dto = new JavaScriptSerializer().Deserialize<DepositReportDto>(responseString);

                using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(responseString)))
                {
                    var ser = new DataContractJsonSerializer(dto.GetType());
                    dto = ser.ReadObject(ms) as DepositReportDto;
                }


                return dto;
            }
            catch (Exception ex)
            {

                return dto;
            }


            return null;
            */

            DepositReportDto dto = new DepositReportDto();

            WebClient client = new WebClient();
            try
            {
                String path = SessionInfo.rootServiceUrl + "resources/report/depositinformation/" + voucherNumber;
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
                    return dto = JsonConvert.DeserializeObject<DepositReportDto>(responseString);
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }
        }


        public RemittanceReportDto GetRemittanceReportDto(string voucherNumber)
        {
            RemittanceReportDto dto = new RemittanceReportDto();

            WebClient client = new WebClient();
            try
            {
                String path = SessionInfo.rootServiceUrl + "resources/report/remittance/" + voucherNumber;
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
                    return dto = JsonConvert.DeserializeObject<RemittanceReportDto>(responseString);
                }
            }
            catch (WebException webEx)
            {
                throw new Exception(UtilityCom.parseErrorData(webEx));
            }



        }

    }
}
