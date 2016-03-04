using MISL.Ababil.Agent.Communication;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.nominee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Services
{
    public class NomineeServices
    {
        NomineeCom objNomineeCom = new NomineeCom();
        public string deleteNomineeById(long nomineeId)
        {
            return objNomineeCom.deleteNomineeById(nomineeId);
        }
        //public List<NomineeInformation> getNomineesByConsumerApp(long ConsumerAppId)
        //{
        //    return objNomineeCom.getNomineesByConsumerApp(ConsumerAppId);
        //}

        public List<NomineeInformationTemp> getNomineesByConsumerApp(long ConsumerAppId)
        {
            return objNomineeCom.getNomineesByConsumerApp(ConsumerAppId);
        }
    }
}
