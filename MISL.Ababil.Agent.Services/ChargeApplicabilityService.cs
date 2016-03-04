using MISL.Ababil.Agent.Communication;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Services
{
    public class ChargeApplicabilityService
    {
        public bool? IsManualChargeApplicable(AgentServicesType agentServicesType)
        {
            ChargeApplicabilityCom chargeApplicabilityCom = new ChargeApplicabilityCom();
            return chargeApplicabilityCom.IsManualChargeApplicable(agentServicesType);
        }
    }
}