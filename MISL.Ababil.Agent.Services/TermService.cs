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
using MISL.Ababil.Agent.Infrastructure.Models.dto;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account;

namespace MISL.Ababil.Agent.Services
{
    public class TermService
    {
        private static readonly TermAccountCom _termAccountCom = new TermAccountCom();
        TermAccountCom _objSSPAccountCom = new TermAccountCom();

        public SspSlipDto GetSSPPaySlipRequestApplicationData(string refrencenumber, AccountType? accountType)
        {
            return _objSSPAccountCom.GetSSPPaySlipRequestApplicationReportDto(refrencenumber, accountType);
        }

        //GetMTDPPaySlipRequestApplicationReportDto
        public SspSlipDto GetMTDPPaySlipRequestApplicationDto(string refrencenumber, AccountType? accountType)
        {
            return _objSSPAccountCom.GetMTDPPaySlipRequestApplicationReportDto(refrencenumber, accountType);
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
                serviceResult.ReturnedObject = _termAccountCom.getProductTypes();
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
                serviceResult.ReturnedObject = _termAccountCom.GetInstallmentSizeByProductTypeId(id);
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

        public static ServiceResult GetCommentsID(string CommentId)
        {
            var serviceResult = ServiceResult.CreateServiceResult();
            serviceResult.ReturnedObject = new List<CommentDto>();

            try
            {
                serviceResult.ReturnedObject = _termAccountCom.GetCommentsByID(CommentId);
                if (serviceResult.ReturnedObject == null)
                {
                    serviceResult.ReturnedObject = new List<CommentDto>();
                    serviceResult.Message = "msg";
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

        public static ServiceResult SubmitTermDtoRequest(TermAccountRequestDto termAccountRequestDto)
        {
            var serviceResult = ServiceResult.CreateServiceResult();
            serviceResult.ReturnedObject = "";
            string json = JsonConvert.SerializeObject(termAccountRequestDto);

            try
            {
                serviceResult.ReturnedObject = _termAccountCom.sendTermRequestDto(json, TermAccountStatus.submitted);
                if (string.IsNullOrEmpty(serviceResult.ReturnedObject.ToString()))
                {
                    //serviceResult.ReturnedObject = "";
                    serviceResult.Success = false;
                    //serviceResult.Message = "Term Account Request could not be saved successfully, please check connectivity and inform Bank Administration";
                    serviceResult.Message = "Couldn't submit!";
                }
                else
                {
                    serviceResult.Success = true;
                    //serviceResult.Message = "Term Account Request was saved successfully with the ID: " + serviceResult.ReturnedObject.ToString();
                }
            }
            catch (Exception exception)
            {
                serviceResult.Message = exception.Message;
            }
            return serviceResult;
        }


        public static ServiceResult SubmitTermRequest(TermAccountInformation termAccountInformation)
        {
            var serviceResult = ServiceResult.CreateServiceResult();
            serviceResult.ReturnedObject = "";
            string json = JsonConvert.SerializeObject(termAccountInformation); //new JavaScriptSerializer().Serialize(sspAccountInformation);

            try
            {
                serviceResult.ReturnedObject = _termAccountCom.sendTermRequest(json, TermAccountStatus.submitted);
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
                serviceResult.ReturnedObject = _termAccountCom.sendTermRequest(json, TermAccountStatus.approved);
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
                serviceResult.ReturnedObject = _termAccountCom.sendTermRequest(json, TermAccountStatus.canceled);
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
                serviceResult.ReturnedObject = _termAccountCom.sendTermRequest(json, TermAccountStatus.correction);
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
                serviceResult.ReturnedObject = _termAccountCom.SearchAgent(id);
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
                serviceResult.ReturnedObject = _termAccountCom.SearchAgents(sspRequestDto);
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

        public static ServiceResult SearchTermAccounts(TermAccountSearchDto termAccountSearchDto)
        {
            var serviceResult = ServiceResult.CreateServiceResult();
            serviceResult.ReturnedObject = "";

            try
            {
                serviceResult.ReturnedObject = _termAccountCom.SearchTermAccounts(termAccountSearchDto);
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

        public static TermAccountRequestDto GetTermAccountRequestDtoByAccID(long accountID)
        {
            return _termAccountCom.GetTermAccountRequestDtoByAccID(accountID);
        }

        public static string ChangeTermApplicationStatus(ApplicationStatusChangeDto applicationStatusChangeDto, TermAccountStatus termAccountStatus)
        {
            var serviceResult = _termAccountCom.ChangeTermApplicationStatus(applicationStatusChangeDto, termAccountStatus);
            return serviceResult;
        }
    }
}