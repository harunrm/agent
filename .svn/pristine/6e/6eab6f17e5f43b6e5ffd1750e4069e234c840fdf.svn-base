using MISL.Ababil.Agent.Communication;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account;
using MISL.Ababil.Agent.Infrastructure.Models.models.transaction;
using System.Web.Script.Serialization;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.IO;
using System.Text;
using MISL.Ababil.Agent.Infrastructure.Models.reports;
using System.Collections.Generic;
using System;
using MISL.Ababil.Agent.Infrastructure.Models.dto;
using Newtonsoft.Json;
using MISL.Ababil.Agent.Infrastructure;

namespace MISL.Ababil.Agent.Services
{
    public class TransactionService
    {
        TransactionCom _transactionCom = new TransactionCom();
        public static List<TransactionRecord> getTransactionReocrd(TransactionRecordSerchDto dto)
        {
            List<TransactionRecord> transactionRecord = new List<TransactionRecord>();
            TransactionCom transactionCom = new TransactionCom();
            transactionRecord = transactionCom.getRecordListOfTransaction(dto);
            return transactionRecord;
        }

        public string FundTransfer(FundTransferRequest request)
        {
            var json = JsonConvert.SerializeObject(request); //new JavaScriptSerializer().Serialize(request);
            return _transactionCom.fundTransfer(json);
        }

        public string CashIn(CashInRequest request)
        {
            var json = JsonConvert.SerializeObject(request);  //new JavaScriptSerializer().Serialize(request);
            return _transactionCom.cashIn(json);
        }

        public string CashOut(CashOutRequest request)
        {
            var json = JsonConvert.SerializeObject(request); //new JavaScriptSerializer().Serialize(request);
            return _transactionCom.cashOut(json);
        }

        public string BalanceInquiry(BalanceInquiryRequest request, string accNo)
        {
            return _transactionCom.balanceInquiry(accNo);
        }

        public List<TransactionDetail> Ministatemnet(MinistatementRequest request, string accNo)
        {
            var json = JsonConvert.SerializeObject(request); //new JavaScriptSerializer().Serialize(request);
            return _transactionCom.ministatement(accNo);
        }

        public TransactionReportDto GetTransactionReportDto(string voucherNumber)
        {
            return _transactionCom.GetTransactionReportDto(voucherNumber);
        }

        public decimal getChargeAmount(ChargeCalculationRequest request)
        {
            ConsumerCom consumerCom = new ConsumerCom();
            var json = JsonConvert.SerializeObject(request); //new JavaScriptSerializer().Serialize(request);
            decimal chargeAmount = _transactionCom.getChargeAmount(json);
            return chargeAmount;
        }

        public List<TransactionRecord> getTransactionReocrdByDateRange(DailyTrnRecordSearchDto TrnDateDto)
        {
            List<TransactionRecord> transactionRecord = new List<TransactionRecord>();
            TransactionCom transactionCom = new TransactionCom();
            transactionRecord = transactionCom.getTransactionReocrdByDateRange(TrnDateDto);
            return transactionRecord;
        }

        public ServiceResult getTransactionReport(TransactionReportSearchDto TrnSearchDto)
        {
            TransactionCom transactionCom = new TransactionCom();
            var serviceResult = ServiceResult.CreateServiceResult();
            serviceResult.ReturnedObject = "";

            try
            {
                serviceResult.ReturnedObject = transactionCom.getTransactionReport(TrnSearchDto);
                if (string.IsNullOrEmpty(serviceResult.ReturnedObject.ToString()))
                {
                    serviceResult.ReturnedObject = "";
                    serviceResult.Message = "Transaction Register report could not be generated successfully, please check connectivity and inform Bank Administration";
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