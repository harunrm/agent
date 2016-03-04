using MISL.Ababil.Agent.Infrastructure.Models.models.transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.reports
{
   public class BillPaymentSearchResultDto
    {
       public string agentName { get; set; }
       public string outletName { get; set; }
       public string serviceProvider { get; set; }
       public string billNo { get; set; }
       public Decimal billAmount { get; set; }
       public Decimal charge { get; set; }
       public string customerName { get; set; }
       public PaymentType paymentType { get; set; }
       public string accountNo { get; set; }
       public string mobileNo { get; set; }
       public string txnDate { get; set; }
    }
}
