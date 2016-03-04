using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account.kyc;

namespace MISL.Ababil.Agent.Infrastructure.Mediators
{
    public class MediatorKycAccountOpeningMode : KycAccountOpeningMode
    {
        public string OpeningModeDescription
        {
            get { return Utility.MergeLookup(openingMode, riskLevel, riskRating); }
        }
    }
}