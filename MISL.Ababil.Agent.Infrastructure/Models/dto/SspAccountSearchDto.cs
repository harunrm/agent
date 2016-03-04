using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.ssp;

namespace MISL.Ababil.Agent.Infrastructure.Models.dto
{
    public class SspAccountSearchDto
    {
        public AgentInformation agent { get; set; }
        public SubAgentInformation subAgent { get; set; }
        public SspProductType product { get; set; }
        public long fromDate { get; set; }
        public long toDate { get; set; }
    }
}
