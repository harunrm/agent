using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.dto
{
    public class AgentBalanceReqDto
    {
        public long agentId { get; set; }
        public DateTime informationDate { get; set; }
    }
}
