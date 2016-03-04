using System.Collections.Generic;

namespace MISL.Ababil.Agent.Infrastructure.Models.domain.models.account.tp
{
    public class CbsTxnProfileSet
    {
        public long id { get; set; }
        public List<CbsTransactionLimit> transactionLimits { get; set; }
    }
}