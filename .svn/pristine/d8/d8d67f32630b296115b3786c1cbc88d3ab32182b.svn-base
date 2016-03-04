using MISL.Ababil.Agent.Communication;
using MISL.Ababil.Agent.Infrastructure;
using MISL.Ababil.Agent.Infrastructure.Models.models.transaction;
using MISL.Ababil.Agent.Infrastructure.Models.reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Services
{
    public class BillPaymentServices
    {
        public static ServiceResult GetBillPayemntList(BillPaymentSearchDto billPayemtSearchDto)
        {
            var serviceResult = ServiceResult.CreateServiceResult();
            serviceResult.ReturnedObject = "";

            try
            {
                serviceResult.ReturnedObject = BillPaymentCom.GetReportListOfBillPayment(billPayemtSearchDto);
                if (string.IsNullOrEmpty(serviceResult.ReturnedObject.ToString()))
                {
                    serviceResult.ReturnedObject = "";
                    serviceResult.Message = "Bill Payment  search could not be done successfully, please check connectivity and inform Bank Administration";
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
        public List<BillServiceProvider> GetListBillServiceProviders()
        {
            BillPaymentCom billPaymentCom = new BillPaymentCom();
            return billPaymentCom.GetListBillServiceProviders();
        }

        public decimal? GetChargeByBillAmount(long providerId, decimal amount)
        {
            BillPaymentCom billPaymentCom = new BillPaymentCom();
            return billPaymentCom.GetChargeByBillAmount(providerId, amount);
        }

        public string SaveBillPaymentRequest(BillPaymentRequestDto billPaymentRequestDto)
        {
            BillPaymentCom billPaymentCom = new BillPaymentCom();
            return billPaymentCom.SaveBillPaymentRequest(billPaymentRequestDto);
        }
    }
}