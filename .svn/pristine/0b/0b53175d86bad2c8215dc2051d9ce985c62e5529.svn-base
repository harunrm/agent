using MISL.Ababil.Agent.Infrastructure.Models.domain.models.consumer;
using System.Collections.Generic;
namespace MISL.Ababil.Agent.Infrastructure.Models.models.transaction
{

    public class FundTransferRequest : TransactionRequest
    {
        private string _fromAccount;
        private string _toAccount;
        private string _agentFingerData;
        private List<AccountOperator> _accountOperators;



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
        public virtual string fromAccount
        {
            get
            {
                return _fromAccount;
            }
            set
            {
                this._fromAccount = value;
            }
        }
        public virtual string toAccount
        {
            get
            {
                return _toAccount;
            }
            set
            {
                this._toAccount = value;
            }
        }


    }

}