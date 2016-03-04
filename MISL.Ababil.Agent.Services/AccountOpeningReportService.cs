using System;
using System.Collections.Generic;
using MISL.Ababil.Agent.Communication;
using MISL.Ababil.Agent.Infrastructure;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account;
using MISL.Ababil.Agent.Infrastructure.Models.dto;

namespace MISL.Ababil.Agent.Services
{
    public class AccountOpeningReportService
    {
        public static ServiceResult GetAccountOpeningList(AccountSearchDto sspRequestDto)
        {
            var serviceResult = ServiceResult.CreateServiceResult();
            serviceResult.ReturnedObject = "";

            try
            {
                serviceResult.ReturnedObject = AccountOpeningReportCom.GetAccountOpeningList(sspRequestDto);
                if (string.IsNullOrEmpty(serviceResult.ReturnedObject.ToString()))
                {
                    serviceResult.ReturnedObject = "";
                    serviceResult.Message = "Deposit Account search could not be done successfully, please check connectivity and inform Bank Administration";
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

        public static ServiceResult GetAccountOpeningList(SspAccountSearchDto sspRequestDto, ProductType productType)
        {
            var serviceResult = ServiceResult.CreateServiceResult();
            serviceResult.ReturnedObject = "";

            try
            {
                serviceResult.ReturnedObject = AccountOpeningReportCom.GetAccountOpeningList(sspRequestDto, productType);
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

        public static ServiceResult GetAllAgentProducts()
        {
            var serviceResult = ServiceResult.CreateServiceResult();
            serviceResult.ReturnedObject = "";

            try
            {
                serviceResult.ReturnedObject = AccountOpeningReportCom.GetAllAgentProducts();
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

        public static ServiceResult GetDepositProducts()
        {
            var serviceResult = ServiceResult.CreateServiceResult();
            serviceResult.ReturnedObject = "";

            try
            {
                serviceResult.ReturnedObject = AccountOpeningReportCom.GetDepositProducts();
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
        
        public static ServiceResult GetSchemeProducts()
        {
            var serviceResult = ServiceResult.CreateServiceResult();
            serviceResult.ReturnedObject = "";

            try
            {
                serviceResult.ReturnedObject = AccountOpeningReportCom.GetSchemeProducts();
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