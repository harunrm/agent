using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.termaccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.dto
{
    public class TermAccountSearchDto
    {
        public long? agentId;
        public long? outletId;
        public string refNo;
        public AccountType? accountType;
        public TermProductType productType;
        public string depositAccno;
        public string depositAccTitle;
        public TermAccountStatus? applicationStatus;
        public long? fromDate;
        public long? toDate;
        public AgentUserType agentUserType;
    }
}