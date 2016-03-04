using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.consumer;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.fingerprint;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.cis;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account;
using Newtonsoft.Json;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account.kyc;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.nominee;

namespace MISL.Ababil.Agent.Infrastructure.Models.domain.models.consumer
{
    public class ConsumerApplication
    {
        public long id { get; set; }
        public string consumerName { get; set; }
        public string nationalId { get; set; }
        public string mobileNo { get; set; }
        public string referenceNumber { get; set; }
        public byte[] photo { get; set; }
        public ApplicationStatus applicationStatus { get; set; }
        public CustomerInformation customer { get; set; }
        public string subAgentName { get; set; }
        public long? creationDate { get; set; }
        public AgentProduct agentProduct { get; set; }
        public long kycProfileNo { get; set; }
        public long txnProfileSetNo { get; set; }
        public int numberOfOperator { get; set; }
        public decimal? openingAmount { get; set; }
        public string intrducerAccNumber { get; set; }
        public string introducerAccTitle { get; set; }
        public List<NomineeInformationTemp> nominees { get; set; }
        public long? commentId { get; set; }



        ////////private static long serialVersionUID = 1L;
        ////////public long id { get; set; }
        ////////public string consumerName { get; set; }
        ////////public string nationalId { get; set; }
        ////////public string mobileNo { get; set; }
        ////////public string referenceNumber { get; set; }
        ////////[JsonConverter(typeof(ByteArrayConverter))]
        ////////public byte[] photo { get; set; }
        //////////public string photo { get; set; }
        ////////public ApplicationStatus applicationStatus { get; set; }
        ////////public CustomerInformation customer { get; set; }
        ////////public List<NomineeInformation> nominees { get; set; }
        ////////public string subAgentName { get; set; }
        ////////public long? creationDate { get; set; }
        ////////public AgentProduct agentProduct { get; set; }
        ////////public long kycProfileNo { get; set; }
        ////////public int numberOfOperator { get; set; }
        ////////public long txnProfileSetNo { get; set; }
        ////////public decimal? openingAmount { get; set; }
        ////////public string intrducerAccNumber { get; set; }
        ////////public string remarks { get; set; }
    }
}
