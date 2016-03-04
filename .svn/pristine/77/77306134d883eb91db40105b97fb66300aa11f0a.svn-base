using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account.kyc;

namespace MISL.Ababil.Agent.Infrastructure.Mediators
{
    public class MediatorKycCashMonthlyTxnAmount : KycCashMonthlyTxnAmount
    {
        public string TransactionAmountDescription
        {
            get
            {
                return Utility.MergeLookup(txnType, minAmount, maxAmount, riskLevel, riskRating);
            }
        }
    }
}