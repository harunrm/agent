using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account.kyc;

namespace MISL.Ababil.Agent.Infrastructure.Mediators
{
    public class MediatorKycCustomerTurnover : KycCustomerTurnover
    {
        public string TurnOverDescription
        {
            get { return Utility.MergeLookup(turnOverAmount, riskLevel, riskRating); }
        }
    }
}