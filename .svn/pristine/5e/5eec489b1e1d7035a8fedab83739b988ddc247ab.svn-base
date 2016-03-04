using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.cis;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.user;

namespace MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent
{
    public class AgentInformation
    {

        private static long serialVersionUID = 1L;
        public long id { get; set; }
        public string agentCode { get; set; }
        public string businessName { get; set; }
        public Address agentAddress { get; set; }
        public int customerId { get; set; }
        public List<AccountInformation> accounts { get; set; }
        public List<AgentUser> agentUsers { get; set; }
        public long creationDate { get; set; }
        public AgentTransactionStatus transactionStatus { get; set; }
        public ApprovalStatus approvalStatus { get; set; }
        public long approvalDate { get; set; }
        public List<SubAgentInformation> subAgents { get; set; }     

    }
}
