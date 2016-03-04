using MISL.Ababil.Agent.Infrastructure.Models.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.UI
{
    public static class TransactionUIService
    {

        public static Boolean isTxnSafe(String txnType, String pfrmAccount, String ptoAccount, decimal pamount)
        {
            if (!SessionInfo.lastTransaction.isTxnSafe(txnType, pfrmAccount, ptoAccount, pamount))
            {
                if (Message.showConfirmation("You have already executed this type of transaction within 2 minutes.\n\nAre you sure to execute it again?") == "yes")
                {
                    return true;
                }
                else
                    return false;
            }
            return true;
        }

        public static void cacheCurrentTxn(String txnType, String pfrmAccount, String ptoAccount, decimal pamount)
        {
            SessionInfo.lastTransaction.cacheCurrentTxn(txnType, pfrmAccount, ptoAccount, pamount);
        }
    }
}
