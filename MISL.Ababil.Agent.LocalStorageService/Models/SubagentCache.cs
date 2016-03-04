using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.LocalStorageService.Models
{
    public class SubagentCache
    {
        //SubAgentInformation currentSubagentInfo = UtilityServices.getCurrentSubAgent();
        public SubAgentInformation OwnSubagentInfo = new SubAgentInformation();

        public string OwnOutletName
        {
            get
            {
                return OwnSubagentInfo.name;
            }
        }
        private void test()
        {
            //agentInformation.
        }
    }
}
