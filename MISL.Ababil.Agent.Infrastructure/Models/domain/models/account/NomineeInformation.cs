using MISL.Ababil.Agent.Infrastructure.Models.domain.models.cis;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.consumer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.domain.models.account
{
    public class NomineeInformation
    {
        private static long serialVersionUID = 1L;

        public long id { get; set; }
        public IndividualInformation individualInformation { get; set; }
        public AccountInformation accountInformation { get; set; }
        public ConsumerApplication consumerApplication { get; set; }
        public string relation { get; set; }
        public int ratio { get; set; }
        
        //[JsonConverter(typeof(ByteArrayConverter))]
        public byte[] photo { get; set; }
        public string instruction { get; set; }











        //public string instruction { get; set; }

        //public long getId()
        //{
        //    return id;
        //}
        //public void setId(long id)
        //{
        //    this.id = id;
        //}
        //public List<NomineeIndividualRelation> getNomineeIndividualRelations()
        //{
        //    return nomineeIndividualRelations;
        //}
        //public void setNomineeIndividualRelations(
        //        List<NomineeIndividualRelation> nomineeIndividualRelations)
        //{
        //    this.nomineeIndividualRelations = nomineeIndividualRelations;
        //}
    }
}
