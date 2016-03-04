using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using MISL.Ababil.Agent.Communication;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account.tp;
using Newtonsoft.Json;

namespace MISL.Ababil.Agent.Services
{
    public class ProfileService
    {
        public static List<CbsTransactionProfile> TransactionProfiles;

        public static List<CbsTransactionProfile> GetProfiles()
        {
            TransactionProfileCom profileCom = new TransactionProfileCom();
            if (TransactionProfiles == null) TransactionProfiles = profileCom.GetTransactionProfiles();
            return TransactionProfiles;
        }

        public static CbsTxnProfileSet GetProfileSet(long profileSetId)
        {
            TransactionProfileCom profileCom = new TransactionProfileCom();
            return profileCom.GetCbsTxnProfileSet(profileSetId);
        }

        public static string SaveProfileData(CbsTxnProfileSet kycProfile)
        {
            var json = JsonConvert.SerializeObject(kycProfile); //new JavaScriptSerializer().Serialize(kycProfile);
            //MessageBox.Show(json);
            TransactionProfileCom profileComCom = new TransactionProfileCom();
            return profileComCom.SaveTransactionProfile(json);
        }

    }
}