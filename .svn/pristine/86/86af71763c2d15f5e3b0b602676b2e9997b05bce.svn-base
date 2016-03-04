using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Module.Common.UI.MessageUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Module.Common.Service
{
    public static class TransactionSafetyCommonService
    {
        public static bool isTxnSafe(string txnType, string pfrmAccount, string ptoAccount, decimal pamount)
        {
            if (!SessionInfo.lastTransaction.isTxnSafe(txnType, pfrmAccount, ptoAccount, pamount))
            {
                if (MsgBox.showConfirmation("You have already executed this type of transaction within 2 minutes.\n\nAre you sure to execute it again?") == "yes")
                {
                    return true;
                }
                else
                    return false;
            }
            return true;
        }

        public static void cacheCurrentTxn(string txnType, string pfrmAccount, string ptoAccount, decimal pamount)
        {
            SessionInfo.lastTransaction.cacheCurrentTxn(txnType, pfrmAccount, ptoAccount, pamount);
        }
    }
}