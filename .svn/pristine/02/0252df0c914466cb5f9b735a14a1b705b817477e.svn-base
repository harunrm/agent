using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.user;
using Newtonsoft.Json;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.consumer;

namespace MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent
{
    public class SubAgentInformation
    {
        private static long serialVersionUID = 1L;

        public long id { get; set; }
        public string name { get; set; }
        public string subAgentCode { get; set; }
        public Address businessAddress { get; set; }
        public string mobleNumber { get; set; }
        public string phoneNumber { get; set; }

        public AccountInformation agentAccount { get; set; }

        public List<SubAgentUser> users { get; set; }
        public AgentInformation agent { get; set; }
        public string email { get; set; }

        //[JsonConverter(typeof(ByteArrayConverter))]
        //public string img { get; set; }
        public byte[] img { get; set; }
        public long? monitoringBranch { get; set; }

        public decimal? dailyCreditLimit { get; set; }
        public decimal? dailyDebitLimit { get; set; }
        public decimal? usedDailyCreditLimit { get; set; }
        public decimal? usedDailyDebitLimit { get; set; }

        public bool creditLimitApplicable { get; set; }
        public bool debitLimitApplicable { get; set; }
        //public string status { get; set; }

        public OutletStatus? status { get; set; }

        public DateTime? creationDate { get; set; }
        public DateTime? creationTime { get; set; }

        public string creationUser { get; set; }
        public DateTime? lastUpdateDate { get; set; }
        public DateTime? lastUpdateTime { get; set; }
        public string lastUpdateUser { get; set; }

    }
}