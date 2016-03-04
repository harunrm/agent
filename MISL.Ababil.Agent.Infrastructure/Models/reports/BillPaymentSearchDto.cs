using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.reports
{
   public class BillPaymentSearchDto
    {
       public long? agentId { get; set; }
       public long? subagentId { get; set; }
       public long? serviceProviderId { get; set; }
       public String billNo { get; set; }
       public DateTime fromDate { get; set; }
       public DateTime toDate { get; set; }
    }
}
