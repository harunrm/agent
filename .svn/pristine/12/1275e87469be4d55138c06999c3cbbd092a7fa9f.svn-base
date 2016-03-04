using System.Collections.Generic;
using System.Web.Script.Serialization;
using MISL.Ababil.Agent.Communication;
using MISL.Ababil.Agent.Infrastructure.Mediators;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account.kyc;
using Newtonsoft.Json;

namespace MISL.Ababil.Agent.Services
{
    public class KycService
    {
        public static List<MediatorKycAccountOpeningMode> KycAccountOpeningModes;
        public static List<MediatorKycCustomerTurnover> KycCustomerTurnovers;
        public static List<MediatorKycMonthTxnAmount> KycMonthTxnAmounts;
        public static List<MediatorKycMonthTxnNumber> KycMonthTxnNumbers;
        public static List<MediatorKycCashMonthlyTxnAmount> KycCashMonthlyTxnAmounts;
        public static List<MediatorKycCashMonthlyTxnNumber> KycCashMonthlyTxnNumbers;

        public static List<MediatorKycAccountOpeningMode> GetAccountOpeningModes()
        {
            KycCom kycCom = new KycCom();
            if (KycAccountOpeningModes == null) KycAccountOpeningModes = kycCom.GetAccountOpeningModes();
            return KycAccountOpeningModes;
        }

        public static List<MediatorKycCustomerTurnover> getCustomerTurnovers()
        {
            KycCom kycCom = new KycCom();
            if (KycCustomerTurnovers == null) KycCustomerTurnovers = kycCom.GetCustomerTurnovers();
            return KycCustomerTurnovers;
        }

        public static List<MediatorKycMonthTxnAmount> getTransactionAmount()
        {
            KycCom kycCom = new KycCom();
            if (KycMonthTxnAmounts == null) KycMonthTxnAmounts = kycCom.GetTxnAmounts();
            return KycMonthTxnAmounts;
        }

        public static List<MediatorKycMonthTxnNumber> getTransactionNumbers()
        {
            KycCom kycCom = new KycCom();
            if (KycMonthTxnNumbers == null) KycMonthTxnNumbers = kycCom.GetTxnNumbers();
            return KycMonthTxnNumbers;
        }

        public static List<MediatorKycCashMonthlyTxnAmount> getCashTransactionAmount()
        {
            KycCom kycCom = new KycCom();
            if (KycCashMonthlyTxnAmounts == null) KycCashMonthlyTxnAmounts = kycCom.GetCashMonthlyTxnAmounts();
            return KycCashMonthlyTxnAmounts;
        }


        public static List<MediatorKycCashMonthlyTxnNumber> getCashTransactionNumbers()
        {
            KycCom kycCom = new KycCom();
            if (KycCashMonthlyTxnNumbers == null) KycCashMonthlyTxnNumbers = kycCom.GetCashMonthlyTxnNumbers();
            return KycCashMonthlyTxnNumbers;
        }

        public static string SaveProfileData(KycProfile kycProfile)
        {
            var json = JsonConvert.SerializeObject(kycProfile); //new JavaScriptSerializer().Serialize(kycProfile);
            KycCom kycCom = new KycCom();
            return kycCom.saveKyc(json);
        }

        public static KycProfile GetKycProfile(long profileId)
        {
            KycCom kycCom = new KycCom();
            return kycCom.GetKycProfile(profileId);
        } 
    }
}