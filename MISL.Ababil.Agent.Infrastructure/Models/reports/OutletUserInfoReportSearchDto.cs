using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;

namespace MISL.Ababil.Agent.Infrastructure.Models.reports
{
    public class OutletUserInfoReportSearchDto
    {
        public AgentInformation _agent {get;set; }
        public SubAgentInformation _subAgent { get; set; }
        public UserStatus userStatus { get; set; }
        
    }
}
