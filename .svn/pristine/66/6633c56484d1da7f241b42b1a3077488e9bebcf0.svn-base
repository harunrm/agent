using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.common
{
    public class LastTransaction
    {

        public DateTime txnTime { get; set; }
        public string transactionType { get; set; }
        public string fromAccount { get; set; }
        public string toAccount { get; set; }
        public decimal amount { get; set; }
        private long interval = 120000;

        private DateTime GetCalcTime()
        {
            DateTime tmp = txnTime;
            return tmp.AddMilliseconds(interval);
        }

        public Boolean isTxnSafe(String txnType, String pfrmAccount, String ptoAccount, decimal pamount)
        {

            if (!String.IsNullOrEmpty(transactionType) && transactionType == txnType)
            {
                if (txnType == "FundTransfer")
                {

                    if (pfrmAccount == fromAccount && ptoAccount == toAccount && pamount == amount && DateTime.Now <= GetCalcTime())
                    {
                        return false;
                    }

                }
                else
                {

                    if (pfrmAccount == fromAccount && pamount == amount && DateTime.Now <= GetCalcTime())
                    {
                        return false;
                    }
                }

            }

            return true;
        }

        public void cacheCurrentTxn(String txnType, String pfrmAccount, String ptoAccount, decimal pamount)
        {
            txnTime = DateTime.Now;
            transactionType = txnType;
            fromAccount = pfrmAccount;
            if (!string.IsNullOrEmpty(ptoAccount))
                toAccount = ptoAccount;
            amount = pamount;

        }

    }
}
