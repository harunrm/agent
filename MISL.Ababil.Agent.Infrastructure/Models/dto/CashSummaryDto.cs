using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.dto
{
    public class CashSummaryDto
    {
        public string itemName { get; set; }
        public decimal balance { get; set; }
        public long noOfTxn { get; set; }
    }
}