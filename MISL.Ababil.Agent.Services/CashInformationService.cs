using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MISL.Ababil.Agent.Communication;
using MISL.Ababil.Agent.Infrastructure.Models.models.transaction;
using MISL.Ababil.Agent.Infrastructure.Models.dto;

namespace MISL.Ababil.Agent.Services
{
    public class CashInformationService
    {
        public CashInformationDto GetCashInformationList()
        {
            CashInformationCom cashInformationCom = new CashInformationCom();
            return cashInformationCom.GetCashInformationList();
        }

        public OutletCashSummaryDto GetOutletCashSummary(OutletCashSumReqDto outletCashSumReqDto)
        {
            CashInformationCom cashInformationCom = new CashInformationCom();
            return cashInformationCom.GetOutletCashSummary(outletCashSumReqDto);
        }

        public List<CashTxnDetails> GetOutletCashInfoDetails(long outletId, string cashItem, DateTime informationDate)
        {
            CashInformationCom cashInformationCom = new CashInformationCom();
            //return cashInformationCom.GetOutletCashInfoDetails(outletId, cashItem, informationDate);
            CashTxnDetailsReq cashTxnDetailsReq = new CashTxnDetailsReq();
            cashTxnDetailsReq.outletId = outletId;
            cashTxnDetailsReq.cashItem = cashItem;
            cashTxnDetailsReq.informationDate = informationDate;
            return cashInformationCom.GetOutletCashInfoDetails(cashTxnDetailsReq);
        }

        public List<CashTxnDetails> GetOutletCashInfoWithAllDetails(long outletId, CashFlowType cashFlowType, DateTime informationDate)
        {            
            CashInformationCom cashInformationCom = new CashInformationCom();
            //return cashInformationCom.GetOutletCashInfoDetails(outletId, cashItem, informationDate);
            CashTxnDetailsReq cashTxnDetailsReq = new CashTxnDetailsReq();
            cashTxnDetailsReq.outletId = outletId;
            cashTxnDetailsReq.cashFlowType = cashFlowType.ToString();
            cashTxnDetailsReq.informationDate = informationDate;
            return cashInformationCom.GetOutletCashInfoAllDetails(cashTxnDetailsReq);
        }

        public List<CashTxnDetails> GetOutletCashInfoWithAllViewDetails(long outletId, DateTime informationDate)
        {
            CashInformationCom cashInformationCom = new CashInformationCom();
            //return cashInformationCom.GetOutletCashInfoDetails(outletId, cashItem, informationDate);
            CashTxnDetailsReq cashTxnDetailsReq = new CashTxnDetailsReq();
            cashTxnDetailsReq.outletId = outletId;            
            cashTxnDetailsReq.informationDate = informationDate;
            return cashInformationCom.GetOutletCashInfoWithAllViewDetails(cashTxnDetailsReq);
        }
    }
}