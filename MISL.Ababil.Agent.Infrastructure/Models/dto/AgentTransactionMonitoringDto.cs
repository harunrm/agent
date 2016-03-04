using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.dto
{
    public class AgentTransactionMonitoringDto
    {
        private long _agentId;
        private long _subAgentId;
        public long? noOfAccount;

        public long? noOfDeposit;
        public decimal? depositAmount;

        public long? noOfWithdraw;
        public decimal? withdrawAmount;

        public long? noOfFundTransfer;
        public decimal? transferAmount;

        public long? noOfRemittance;
        public decimal? remittanceAmount;

        public long? noOfUtilityBill;
        public decimal? billCollectionAmount;

        public long? noOfLoanDisbursed;
        public decimal? disbursedAmount;

        public long? noOfInstallmentRecovered;
        public decimal? recoveredAmount;

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
