using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account.kyc;

namespace MISL.Ababil.Agent.Infrastructure.Mediators
{
    public class MediatorKycCashMonthlyTxnNumber : KycCashMonthlyTxnNumber
    {
        public string TransactionNumberDescription
        {
            get
            {
                return Utility.MergeLookup(txnType, minNumber, maxNumber, riskLevel, riskRating);
            }
        }
    }
}