using MISL.Ababil.Agent.Communication;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.cis;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace MISL.Ababil.Agent.Services
{
    public class IndividualServices
    {
        IndividualCom objIndividualCom = new IndividualCom();
        public string saveIndividual(IndividualInformation individualInfo)
        {
            var json = JsonConvert.SerializeObject(individualInfo); //new JavaScriptSerializer().Serialize(individualInfo);
            return objIndividualCom.saveIndividual(json);
        }
        public IndividualInformation GetIndividualInfo(long IndividualId){
            return objIndividualCom.getIndividualInfo(IndividualId);
        }
    }
}
