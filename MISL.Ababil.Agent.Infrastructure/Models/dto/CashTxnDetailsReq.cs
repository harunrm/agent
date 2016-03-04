using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.dto
{
    public class CashTxnDetailsReq
    {
        public long outletId { get; set; }
        public string cashItem { get; set; }
        public DateTime informationDate { get; set; }
        public string cashFlowType { get; set; }
    }
}