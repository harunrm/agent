using MISL.Ababil.Agent.Infrastructure.Models.domain.models.consumer;
using System.Collections.Generic;
namespace MISL.Ababil.Agent.Infrastructure.Models.models.transaction
{
    public class CashOutRequest : TransactionRequest
    {

        private string _customerAccount;
        private string _agentFingerData;
        private List<AccountOperator> _accountOperators;
        public virtual string customerAccount
        {
            get
            {
                return _customerAccount;
            }
            set
            {
                this._customerAccount = value;
            }
        }
        public virtual string agentFingerData
        {
            get
            {
                return _agentFingerData;
            }
            set
            {
                this._agentFingerData = value;
            }
        }
        public virtual List<AccountOperator> accountOperators
        {
            get
            {
                return _accountOperators;
            }
            set
            {
                this._accountOperators = value;
            }
        }


    }
}