using MISL.Ababil.Agent.Infrastructure.Models.domain.models;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.user;
using MISL.Ababil.Agent.Infrastructure.Models.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.common
{
    public class UserBasicInformation
    {
        public AgentUserType userType { get; set; }
        public SubAgentInformation outlet { get; set; }
        public AgentInformation agent { get; set; }
        public Division division { get; set; }
        public District district { get; set; }
        public Thana thana { get; set; }
        public PostalCode postalCode { get; set; }
        public DateTime currentDate { get; set; }        
    }
}
