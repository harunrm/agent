using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.reports
{
    public class DailyTrnRecordSearchDto
    {
        public long fromDate { get; set; }
        public long toDate { get; set; }
        public string subAgentUserName { get; set;}

        private AgentInformation _agent;
        private SubAgentInformation _subAgent;
        public virtual AgentInformation agent
        {
            get
            { return _agent; }
            set
            { this._agent = value; }
        }
        public virtual SubAgentInformation subAgent
        {
            get
            { return _subAgent; }
            set
            { this._subAgent = value; }
        }
    }
}
