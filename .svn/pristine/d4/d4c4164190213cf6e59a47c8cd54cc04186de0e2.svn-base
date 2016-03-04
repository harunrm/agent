using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.fingerprint;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MISL.Ababil.Agent.Infrastructure.Models.common;

namespace MISL.Ababil.Agent.Infrastructure.Models.domain.models.user
{
    public class SubAgentUser
    {
        public long id { get; set; }
        public String username { get; set; }
        public string password { get; set; }
        public List<BiometricTemplate> fingerDatas { get; set; }
        public SubAgentInformation subAgentInformation { get; set; }
        [JsonIgnore]
        public bool? isNewUser { get; set; }
        public UserStatus? userStatus { get; set; }


        public decimal? dailyCreditLimit { get; set; }
        public decimal? dailyDebitLimit { get; set; }
        public decimal? usedDailyCreditLimit { get; set; }
        public decimal? usedDailyDebitLimit { get; set; }

        public bool creditLimitApplicable { get; set; }
        public bool debitLimitApplicable { get; set; }


        //private String username;

        //private SubAgentInformation subAgentInformation;


        //public String getUsername() {
        //    return username;
        //}

        //public void setUsername(String username) {
        //    this.username = username;
        //}

        //public SubAgentInformation getSubAgentInformation() {
        //    return subAgentInformation;
        //}

        //public void setSubAgentInformation(SubAgentInformation subAgentInformation) {
        //    this.subAgentInformation = subAgentInformation;
        //}

        //public void setId(long id) {
        //    this.id = id;
        //}
    }
}
