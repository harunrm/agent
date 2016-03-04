using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.models.transaction
{
   public class BalanceInquiryRequest : TransactionRequest
    {

        private string _accountNumber;
        private string _fingerData;


        public virtual string accountNumber
        {
            get
            {
                return _accountNumber;
            }
            set
            {
                this._accountNumber = value;
            }
        }


        public virtual string fingerData
        {
            get
            {
                return _fingerData;
            }
            set
            {
                this._fingerData = value;
            }
        }



    }
}
