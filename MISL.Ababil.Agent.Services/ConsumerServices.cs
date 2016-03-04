using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using com.mislbd.agentbanking.report.dto;
using MISL.Ababil.Agent.Communication;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.consumer;
using MISL.Ababil.Agent.Infrastructure.Models.dto;
using MISL.Ababil.Agent.Infrastructure.Models.reports;
using Newtonsoft.Json;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.cis;

namespace MISL.Ababil.Agent.Services
{
    public class ConsumerServices //getConumerPhoto
    {
        ConsumerCom objConsumerCom = new ConsumerCom();
        //new add from IDTA

        public byte[] getConumerPhotoByAppId(long consumerAppId)
        {
            return objConsumerCom.GetConsumerPhotoByAppId(consumerAppId);
        }

        public string getConumerPhotoByAppIdA(long consumerAppId)
        {
            return objConsumerCom.GetConsumerPhotoByAppIdA(consumerAppId);
        }

        public ConsumerApplicationReportDto GetConsumerApplicationData(string refrencenumber)
        {
            return objConsumerCom.GetConsumerApplicationReportDto(refrencenumber);
        }

        public ApprovedConsumerAppReportDto GetApprovedConsumerReportDto(string refrencenumber)
        {
            return objConsumerCom.GetApprovedConsumerAppReportDto(refrencenumber);
        }

        public CashwithdrawlReportDto GetCashWithDrawlReportDto(string voucherNumber)
        {
            return objConsumerCom.GetCashWithDrawlReportDto(voucherNumber);
        }

        public DepositReportDto GetDepositReportDto(string voucherNumber)
        {
            return objConsumerCom.GetCashDepositReportDto(voucherNumber);
        }


        public BillPaymentReportDto GetBillReportDto(string voucherNumber)
        {
            return objConsumerCom.GetBillPaymentReportDto(voucherNumber);
        }
        //public TransactionReportDto GetTransactionReportDto(string voucherNumber)
        //{
        //    ConnectionHeaders connectionHeaders = UtilityServices.getConnectionHeaders();
        //    connectionHeaders.rootServiceUrl = "http://192.168.1.71:8080/agent-service/";
        //    connectionHeaders.Username = "shafayat";
        //    return objConsumerCom.GetTransactionReportDto(connectionHeaders, voucherNumber);
        //}
        public string draftAtBranch(ConsumerApplication consumerApp)
        {
            //var json = new JavaScriptSerializer().Serialize(consumerApp);
            var json = JsonConvert.SerializeObject(consumerApp);
            return objConsumerCom.saveConsumer(json, ApplicationStatus.draft_at_branch);
        }
        public string draftConsumer(ConsumerApplication consumerApp)
        {
            //var json = new JavaScriptSerializer().Serialize(consumerApp);
            var json = JsonConvert.SerializeObject(consumerApp);
            return objConsumerCom.saveConsumer(json, ApplicationStatus.draft);
        }
        public string submitConsumer(ConsumerApplication consumerApp)
        {
            var json = JsonConvert.SerializeObject(consumerApp);//new JavaScriptSerializer().Serialize(consumerApp);
            return objConsumerCom.saveConsumer(json, ApplicationStatus.submitted);
        }
        public string verifyConsumer(ConsumerApplication consumerApp)
        {
            var json = JsonConvert.SerializeObject(consumerApp); //new JavaScriptSerializer().Serialize(consumerApp);
            return objConsumerCom.saveConsumer(json, ApplicationStatus.verified);
        }
        public string approveConsumer(ConsumerApplication consumerApp)
        {
            var json = JsonConvert.SerializeObject(consumerApp); //new JavaScriptSerializer().Serialize(consumerApp);
            return objConsumerCom.saveConsumer(json, ApplicationStatus.approved);
        }
        public string cancelConsumer(ConsumerApplication consumerApp)
        {
            var json = JsonConvert.SerializeObject(consumerApp); //new JavaScriptSerializer().Serialize(consumerApp);
            return objConsumerCom.saveConsumer(json, ApplicationStatus.canceled);
        }
        public string correctionConsumer(ConsumerApplication consumerApp)
        {
            var json = JsonConvert.SerializeObject(consumerApp); //new JavaScriptSerializer().Serialize(consumerApp);
            return objConsumerCom.saveConsumer(json, ApplicationStatus.correction);
        }
        public static List<ConsumerAppResultDto> getConsumerApplications(ConsumerApplicationDto dto)
        {
            List<ConsumerAppResultDto> consumerAppResultDto = new List<ConsumerAppResultDto>();
            ConsumerCom consumerCom = new ConsumerCom();
            consumerAppResultDto = consumerCom.getListOfConsumerApplications(dto);
            return consumerAppResultDto;
        }

        public List<ConsumerApplication> getListOfConsumerApplicationsA(ConsumerApplicationDto dto)
        {
            List<ConsumerApplication> consumerApplication = new List<ConsumerApplication>();
            ConsumerCom consumerCom = new ConsumerCom();
            consumerApplication = consumerCom.getListOfConsumerApplicationsA(dto);
            return consumerApplication;
        }

        public ConsumerApplication getConsumerApplicationById(string referenceNumber)
        {
            ConsumerApplication consumerApplication = new ConsumerApplication();
            ConsumerCom consumerCom = new ConsumerCom();
            consumerApplication = consumerCom.getListOfConsumerApplication(referenceNumber);
            return consumerApplication;
        }

        public static List<ConsumerApplication> getAllConsumerApplications(AllApplicationSearchDto dto)
        {
            List<ConsumerApplication> consumerApplications = new List<ConsumerApplication>();
            ConsumerCom consumerCom = new ConsumerCom();
            consumerApplications = consumerCom.getAllListOfConsumerApplications(dto);
            return consumerApplications;
        }

        public ConsumerInformationDto getConsumerInformationDtoByAcc(string accountNo)
        {
            ConsumerInformationDto consumerInformationDto = new ConsumerInformationDto();
            ConsumerCom consumerCom = new ConsumerCom();
            consumerInformationDto = consumerCom.getConsumerInformationDtoByAcc(accountNo);
            return consumerInformationDto;
        }


        public RemittanceReportDto GetRemittanceReportDto(string voucherNumber)
        {
            return objConsumerCom.GetRemittanceReportDto(voucherNumber);
        }

        public string applyConsumer(CustomerApplyDto customerApplyDto)
        {
            return objConsumerCom.applyConsumer(customerApplyDto);
        }

        public CustomerInformation getCustomerByAppId(long id)
        {
            return objConsumerCom.getCustomerByAppId(id);
        }

        public void changeApplicationStatus(ApplicationStatusChangeDto applicationStatusChangeDto, ApplicationStatus applicationStatus)
        {


            objConsumerCom.changeApplicationStatus(applicationStatusChangeDto, applicationStatus);

        }
    }
}
