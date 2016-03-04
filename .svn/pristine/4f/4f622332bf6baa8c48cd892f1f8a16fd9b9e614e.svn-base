using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MISL.Ababil.Agent.Communication;
using MISL.Ababil.Agent.Infrastructure.Models.models.transaction;

namespace MISL.Ababil.Agent.Services
{
    public class CashEntryService
    {
        public List<TransactionPurpose> GetTransactionPurposeList()
        {
            CashEntryCom cashEntryCom = new CashEntryCom();
            return cashEntryCom.GetTransactionPurposeList();
        }

        public string SaveOutletCashTransactionRegister(OutletCashTransactionRegister outletCashTransactionRegister)
        {
            CashEntryCom cashEntryCom = new CashEntryCom();
            return cashEntryCom.SaveOutletCashTransactionRegister(outletCashTransactionRegister);
        }
    }
}
