using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.dto
{
    public class AccountMonitoringDto
    {
        private long _agentId;
        private long _subAgentId;
        public decimal? agentAccBalance;

        public long? noOfMSDAccount;
        public decimal? msdAccBalance;

        public long? noOfCDAccount;
        public decimal? cdAccBalance;

        public long? noOfITDAccount;
        public decimal? itdAccBalance;

        public long? noOfMTDAccount;
        public decimal? mtdAccBalance;

        public long? noOfInvestmentAccount;
        public decimal? investedAmount;

        public virtual long agentId
        {
            get
            { return _agentId; }
            set
            { this._agentId = value; }
        }
        public virtual long subAgentId
        {
            get
            { return _subAgentId; }
            set
            { this._subAgentId = value; }
        }

        public string agentName { get; set; }
        public string subAgentName { get; set; }

    }
}
