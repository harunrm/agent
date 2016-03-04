using System;
using MISL.Ababil.Agent.Communication;
using MISL.Ababil.Agent.Infrastructure;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.Remittance;
using MISL.Ababil.Agent.Infrastructure.Models.dto;
using MISL.Ababil.Agent.Infrastructure.Models.models.transaction;

namespace MISL.Ababil.Agent.Services
{
    public class RemittanceServices
    {
   

        public string saveRemittance(Remittance remittance)
        {
            RemittanceCom objRemittanceCom = new RemittanceCom();

            string responseString = objRemittanceCom.saveRemittance(remittance);

            return responseString;
        }

        public string disburseRemittance(RemittanceDisburseRequest remittanceDisburseRequest)
        {

            RemittanceCom objRemittanceCom = new RemittanceCom();

            string responseString = objRemittanceCom.disburseRemittance(remittanceDisburseRequest);

            return responseString;
           
        }

        public static ServiceResult GetRemittanceList(RemittanceSearchDto sspRequestDto)
        {
            var serviceResult = ServiceResult.CreateServiceResult();
            serviceResult.ReturnedObject = "";

            try
            {
                serviceResult.ReturnedObject = RemittanceCom.GetReportListOfRemittance(sspRequestDto);
                if (string.IsNullOrEmpty(serviceResult.ReturnedObject.ToString()))
                {
                    serviceResult.ReturnedObject = "";
                    serviceResult.Message = "SSP Account search could not be done successfully, please check connectivity and inform Bank Administration";
                }
                else
                {
                    serviceResult.Success = true;
                    serviceResult.Message = serviceResult.ReturnedObject.ToString();
                }
            }
            catch (Exception exception)
            {
                serviceResult.Message = exception.Message;
            }

            return serviceResult;
        }


    }
}