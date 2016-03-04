using System;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using MISL.Ababil.Agent.Communication;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account;
using System.Collections.Generic;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.fingerprint;
using MISL.Ababil.Agent.Infrastructure;
using MISL.Ababil.Agent.Infrastructure.Models.dto;
using MISL.Ababil.Agent.Infrastructure.Models.reports;

namespace MISL.Ababil.Agent.Services
{
    public class AccountInformationService
    {
        readonly AccountInformationCom _accountInformationCom = new AccountInformationCom();

        public string getAccountBalance(string accountNumber)
        {
            try
            {
                return FetchAccountInformation(accountNumber).accountNumber; // will be replaced with balance when service comes
            }
            catch (Exception exception)
            {
                return "Error: " + exception.Message;
            }
        }
        public AccountInformationDto getAccountInfoDTO(string accountNumber)
        {
            AccountInformationDto accountInformation = _accountInformationCom.GetAccountDto(accountNumber);
            return accountInformation;
        }
        private AccountInformation FetchAccountInformation(string accountNumber)
        {
            AccountInformation accountInformation = _accountInformationCom.GetAccountInformation(accountNumber);
            return accountInformation;
        }

        public string GetAccountTitle(string accountNumber)
        {
            try
            {
                return FetchAccountInformation(accountNumber).accountTitle;
            }
            catch (Exception exception)
            {
                return "Error: " + exception.Message;
            }
        }

        public List<BiometricTemplate> GetFingerData(string accountNumber)
        {
            try
            {
                return FetchAccountInformation(accountNumber).consumerInformation.fingerDatas;
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public static ServiceResult GetCashRegisterReport(DailyTrnRecordSearchDto sspRequestDto)
        {
            var serviceResult = ServiceResult.CreateServiceResult();
            serviceResult.ReturnedObject = "";

            try
            {
                serviceResult.ReturnedObject = AccountInformationCom.GetCashRegister(sspRequestDto);
                if (string.IsNullOrEmpty(serviceResult.ReturnedObject.ToString()))
                {
                    serviceResult.ReturnedObject = "";
                    serviceResult.Message = "Cash Register report could not be generated successfully, please check connectivity and inform Bank Administration";
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