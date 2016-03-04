using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using MISL.Ababil.Agent.Communication;
using MISL.Ababil.Agent.Infrastructure;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.ssp;
using Newtonsoft.Json;
using com.mislbd.agentbanking.report.dto;
using MISL.Ababil.Agent.Infrastructure.Models.reports;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.termaccount;

namespace MISL.Ababil.Agent.Services
{
    public class SspService
    {
        private static readonly SSPAccountCom SspAccountCom = new SSPAccountCom();
        SSPAccountCom objSSPAccountCom = new SSPAccountCom();
        public SspSlipDto GetSSPPaySlipRequestApplicationData(string refrencenumber)
        {
            return objSSPAccountCom.GetSSPPaySlipRequestApplicationReportDto(refrencenumber);
        }
        public ConsumerApplicationReportDto GetITDAApplicationData(string refrencenumber)
        {
            //return objSSPAccountCom.GetITDAApplicationReportDto(refrencenumber);
            return null;
        }
        public static ServiceResult GetProductTypes()
        {
            var serviceResult = ServiceResult.CreateServiceResult();
            serviceResult.ReturnedObject = new List<SspProductType>();

            try
            {
                serviceResult.ReturnedObject = SspAccountCom.getProductTypes();
                if (serviceResult.ReturnedObject == null)
                {
                    serviceResult.ReturnedObject = new List<SspProductType>();
                    serviceResult.Message = "Agent Banking Service Endpoint could not be reached, please check connectivity and inform Bank Administration";
                }
                else
                {
                    serviceResult.Success = true;
                }
            }
            catch (Exception exception)
            {
                serviceResult.Message = exception.Message;
            }

            return serviceResult;
        }

        public static ServiceResult GetInstallmentSizesByProductTypeId(string id)
        {
            var serviceResult = ServiceResult.CreateServiceResult();
            serviceResult.ReturnedObject = new List<SspProductType>();

            try
            {
                serviceResult.ReturnedObject = SspAccountCom.GetInstallmentSizeByProductTypeId(id);
                if (serviceResult.ReturnedObject == null)
                {
                    serviceResult.ReturnedObject = new List<SspInstallment>();
                    serviceResult.Message = "Agent Banking Service Endpoint could not be reached, please check connectivity and inform Bank Administration";
                }
                else
                {
                    serviceResult.Success = true;
                }
            }
            catch (Exception exception)
            {
                serviceResult.Message = exception.Message;
            }

            return serviceResult;
        }

        public static ServiceResult SubmitSspRequest(TermAccountInformation sspAccountInformation)
        {
            var serviceResult = ServiceResult.CreateServiceResult();
            serviceResult.ReturnedObject = "";

            string json = JsonConvert.SerializeObject(sspAccountInformation); //new JavaScriptSerializer().Serialize(sspAccountInformation);

            try
            {
                //serviceResult.ReturnedObject = SspAccountCom.SubmitSspRequest(json);
                serviceResult.ReturnedObject = SspAccountCom.sendSspRequest(json, sspaccountstatus.submitted);
                if (string.IsNullOrEmpty(serviceResult.ReturnedObject.ToString()))
                {
                    serviceResult.ReturnedObject = "";
                    serviceResult.Message = "SSP Account Request could not be saved successfully, please check connectivity and inform Bank Administration";
                }
                else
                {
                    serviceResult.Success = true;
                    serviceResult.Message = "SSP Account Request was saved successfully with the ID: " + serviceResult.ReturnedObject.ToString();
                }
            }
            catch (Exception exception)
            {
                serviceResult.Message = exception.Message;
            }

            return serviceResult;
        }


        public static ServiceResult ApproveSSPRequest(TermAccountInformation sspAccountInformation)
        {
            var serviceResult = ServiceResult.CreateServiceResult();
            serviceResult.ReturnedObject = "";

            string json = JsonConvert.SerializeObject(sspAccountInformation); //new JavaScriptSerializer().Serialize(sspAccountInformation);

            try
            {
                //serviceResult.ReturnedObject = SspAccountCom.ApproveSSPRequest(json);
                serviceResult.ReturnedObject = SspAccountCom.sendSspRequest(json, sspaccountstatus.approved);
                if (string.IsNullOrEmpty(serviceResult.ReturnedObject.ToString()))
                {
                    serviceResult.ReturnedObject = "";
                    serviceResult.Message = "SSP Account Request could not be approved successfully, please check connectivity and inform Bank Administration";
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


        public static ServiceResult RejectSSPRequest(TermAccountInformation sspAccountInformation)
        {
            var serviceResult = ServiceResult.CreateServiceResult();
            serviceResult.ReturnedObject = "";

            string json = JsonConvert.SerializeObject(sspAccountInformation); //new JavaScriptSerializer().Serialize(sspAccountInformation);

            try
            {
                //serviceResult.ReturnedObject = SspAccountCom.RejectSSPRequest(json);
                serviceResult.ReturnedObject = SspAccountCom.sendSspRequest(json, sspaccountstatus.canceled);
                if (string.IsNullOrEmpty(serviceResult.ReturnedObject.ToString()))
                {
                    serviceResult.ReturnedObject = "";
                    serviceResult.Message = "SSP Account Request could not be rejected successfully, please check connectivity and inform Bank Administration";
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
        public static ServiceResult CorrectionSSPRequest(TermAccountInformation sspAccountInformation)
        {
            var serviceResult = ServiceResult.CreateServiceResult();
            serviceResult.ReturnedObject = "";

            string json = JsonConvert.SerializeObject(sspAccountInformation); //new JavaScriptSerializer().Serialize(sspAccountInformation);

            try
            {
                //serviceResult.ReturnedObject = SspAccountCom.RejectSSPRequest(json);
                serviceResult.ReturnedObject = SspAccountCom.sendSspRequest(json, sspaccountstatus.correction);
                if (string.IsNullOrEmpty(serviceResult.ReturnedObject.ToString()))
                {
                    serviceResult.ReturnedObject = "";
                    serviceResult.Message = "SSP Account Request could not be sent for correction successfully, please check connectivity and inform Bank Administration";
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

        public static ServiceResult GetSSPAccountInfoByID(long id)
        {
            var serviceResult = ServiceResult.CreateServiceResult();
            serviceResult.ReturnedObject = "";

            try
            {
                serviceResult.ReturnedObject = SspAccountCom.SearchAgent(id);
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

        public static ServiceResult SearchSspAccounts(SspAccountInformationSearchDto sspRequestDto)
        {
            var serviceResult = ServiceResult.CreateServiceResult();
            serviceResult.ReturnedObject = "";

            try
            {
                serviceResult.ReturnedObject = SspAccountCom.SearchAgents(sspRequestDto);
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
