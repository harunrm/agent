using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.models.transaction
{
    public class OutletCashTransactionRegister
    {
        public long id { get; set; }

        public long subagentId { get; set; }

        public long transactionDate { get; set; }

        public long transactionPurposeId { get; set; }

        public decimal amount { get; set; }

        public string remark { get; set; }

        public string entyUser { get; set; }

        public string entyDate { get; set; }
    }
}