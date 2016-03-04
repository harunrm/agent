using MISL.Ababil.Agent.Communication;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using MISL.Ababil.Agent.Infrastructure.Models.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using MISL.Ababil.Agent.Infrastructure.Models.reports;
using MISL.Ababil.Agent.Infrastructure;
namespace MISL.Ababil.Agent.Services
{
    public class AgentServices
    {
        //---------------------------------------------------------------------------------------------------------
        public ServiceResult getOutletUserInfoResultList(OutletUserInfoReportSearchDto outletInfoSearchDto)
        {
            objAgentCom = new AgentCom();
            var serviceResult = ServiceResult.CreateServiceResult();
            serviceResult.ReturnedObject = "";

            try
            {
                serviceResult.ReturnedObject = objAgentCom.getOutletUserInfoList(outletInfoSearchDto);
                if (string.IsNullOrEmpty(serviceResult.ReturnedObject.ToString()))
                {
                    serviceResult.ReturnedObject = "";
                    serviceResult.Message = "Outlet information report could not be generated successfully, please check connectivity and inform Bank Administration";
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

//----------------------------------------------------------------------------------------------------------------------------------------

        AgentCom objAgentCom = new AgentCom();
        //====================================================================================================================
        public List<AgentIncomeStatementDto> getAgentIncomeStatementReportDtoList(AccountSearchDto accountSearchDto)
        {
            //return objAgentCom.getAgentIncomeStatementDtoList(accountSearchDto);
            return objAgentCom.getAgentIncomeStatementReportDtoList(accountSearchDto);
        }

        //================================================================================================
        public List<AgentProduct> getAgentProductByProductType(string productType)
        {
            return objAgentCom.getAgentProductByProductType(productType);
        }
        public string saveAgent(AgentInformation agentInfo)
        {
            return objAgentCom.saveAgent(agentInfo);
        }

        public List<AccountInformation> getAgentAccountList(long agentId)
        {
            return objAgentCom.getAgentAccountList(agentId);
        }

        public List<AgentInformation> getAgentInfoBranchWise()
        {
            return objAgentCom.getAgentInfoBranchWise();
        }

        public AgentInformation getAgentInfoById(string agentId)
        {
            return objAgentCom.getAgentInfoById(agentId);
        }

        public AccountInformationDto GetAgentAccountInfoByAgentId(string agentId)
        {
            return objAgentCom.GetAgentAccountInfoByAgentId(agentId);
        }

        public List<AgentInformation> SearchAgents(AgentDto searchDto)
        {
            return objAgentCom.SearchAgents(searchDto);
        }

        public List<SubAgentInformation> GetSubagentsByAgentId(long agentId)
        {
            return objAgentCom.GetSubagentsByAgentId(agentId);
        }

        public List<AgentIncomeStatementDto> getAgentIncomeStatementDtoList(AccountSearchDto accountSearchDto)
        {
            return objAgentCom.getAgentIncomeStatementDtoList(accountSearchDto);
        }
        public List<AgentDayEndSummeryDto> getAgentDayEndSummaryDtoList(AccountSearchDto accountSearchDto)
        {
            return objAgentCom.getAgentDayEndSummaryDtoList(accountSearchDto);
        }

        #region WALI :: 21-Jul-2015
        public static MISL.Ababil.Agent.Infrastructure.ServiceResult GetAgentCommissionInformaiton(AccountSearchDto requestDto)
        {
            var serviceResult = MISL.Ababil.Agent.Infrastructure.ServiceResult.CreateServiceResult();
            serviceResult.ReturnedObject = "";

            try
            {
                serviceResult.ReturnedObject = AgentCom.GetAgentCommissionInformation(requestDto);
                if (string.IsNullOrEmpty(serviceResult.ReturnedObject.ToString()))
                {
                    serviceResult.ReturnedObject = "";
                    serviceResult.Message = "Agent Commission Info could not be fetched successfully, please check connectivity and inform Bank Administration";
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
        public static MISL.Ababil.Agent.Infrastructure.ServiceResult GetAgentTrMonitorInformaiton(AccountSearchDto requestDto)
        {
            var serviceResult = MISL.Ababil.Agent.Infrastructure.ServiceResult.CreateServiceResult();
            serviceResult.ReturnedObject = "";

            try
            {
                serviceResult.ReturnedObject = AgentCom.GetAgentTrMonitorInformaiton(requestDto);
                if (string.IsNullOrEmpty(serviceResult.ReturnedObject.ToString()))
                {
                    serviceResult.ReturnedObject = "";
                    serviceResult.Message = "Agent Commission Info could not be fetched successfully, please check connectivity and inform Bank Administration";
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
        public static MISL.Ababil.Agent.Infrastructure.ServiceResult GetAccountMonitorInformaiton(AccountSearchDto requestDto)
        {
            var serviceResult = MISL.Ababil.Agent.Infrastructure.ServiceResult.CreateServiceResult();
            serviceResult.ReturnedObject = "";

            try
            {
                serviceResult.ReturnedObject = AgentCom.GetAccountMonitorInformaiton(requestDto);
                if (string.IsNullOrEmpty(serviceResult.ReturnedObject.ToString()))
                {
                    serviceResult.ReturnedObject = "";
                    serviceResult.Message = "Account Monitor Info could not be fetched successfully, please check connectivity and inform Bank Administration";
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
        #endregion
        public ServiceResult getOutletInformationReportList(OutletReportSearchDto outletInfoSearchDto)
        {
            objAgentCom = new AgentCom();
            var serviceResult = ServiceResult.CreateServiceResult();
            serviceResult.ReturnedObject = "";

            try
            {
                serviceResult.ReturnedObject = objAgentCom.getOutletInformationReportList(outletInfoSearchDto);
                if (string.IsNullOrEmpty(serviceResult.ReturnedObject.ToString()))
                {
                    serviceResult.ReturnedObject = "";
                    serviceResult.Message = "Outlet information report could not be generated successfully, please check connectivity and inform Bank Administration";
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
        public ServiceResult getAgentInformationReportList()
        {
            objAgentCom = new AgentCom();
            var serviceResult = ServiceResult.CreateServiceResult();
            serviceResult.ReturnedObject = "";

            try
            {
                serviceResult.ReturnedObject = objAgentCom.getAgentInformationReportList();
                if (string.IsNullOrEmpty(serviceResult.ReturnedObject.ToString()))
                {
                    serviceResult.ReturnedObject = "";
                    serviceResult.Message = "Agent information report could not be generated successfully, please check connectivity and inform Bank Administration";
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

        public ServiceResult getAgentBalanceDetails(AgentBalanceReqDto reqDto)
        {
            objAgentCom = new AgentCom();
            var serviceResult = ServiceResult.CreateServiceResult();
            serviceResult.ReturnedObject = "";

            try
            {
                serviceResult.ReturnedObject = objAgentCom.getAgentBalanceDetails(reqDto);
                if (string.IsNullOrEmpty(serviceResult.ReturnedObject.ToString()))
                {
                    serviceResult.ReturnedObject = "";
                    serviceResult.Message = "Agent balance information could not be fetched successfully, please check connectivity and inform Bank Administration";
                }
                else
                {
                    serviceResult.Success = true;
                    serviceResult.Message = serviceResult.ReturnedObject.ToString();
                }
            }
            catch (Exception exception)
            { serviceResult.Message = exception.Message; }

            return serviceResult;
        }

    }
}