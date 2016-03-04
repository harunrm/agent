using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.dto
{
    public class AgentCommissionInfoDto
    {
        private long _agentId;
        private long _subAgentId;
        public decimal? transactionComm;
        public decimal? remittanceComm;
        public decimal? utilityBillComm;
        public decimal? loanDisbursmentComm;
        public decimal? repaymentCollectionComm;
        public virtual long agentId
        {
            get
            {
                return _agentId;
            }
            set
            {
                this._agentId = value;
            }
        }
        public virtual long subAgentId
        {
            get
            {
                return _subAgentId;
            }
            set
            {
                this._subAgentId = value;
            }
        }

        public string agentName { get; set; }
        public string subAgentName { get; set; }
        //public decimal transactionComm { get; set; }
        //public decimal remittanceComm { get; set; }
        //public decimal utilityBillComm { get; set; }
        //public decimal loanDisbursmentComm { get; set; }
        //public decimal repaymentCollectionComm { get; set; }

    }
}
