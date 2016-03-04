using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.dto
{
    public class AgentDayEndSummeryDto
    {
        public long id { get; set; }
        public long agentId { get; set; }
        public string agentName { get; set; }
        public long subAgentId { get; set; }
        public string subAgentName { get; set; }
        public string serviceName { get; set; }
        public decimal? cashReceive { get; set; }
        public decimal? cashPayment { get; set; }
        public decimal? closingBalance { get; set; }
    }
}
