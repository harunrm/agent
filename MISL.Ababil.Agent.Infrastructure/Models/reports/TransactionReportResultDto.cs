using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.reports
{
    public class TransactionReportResultDto
    {
        public long agentId { get; set; }
        public string agentName { get; set; }
        public long subAgentId { get; set; }
        public string subAgentName { get; set; }
        public string userName { get; set; }

        public long txnId { get; set; }
        //public long txnDate { get; set; }
        public string txnDate { get; set; }
        public string voucherNo { get; set; }
        public decimal transactionAmount { get; set; }
        public decimal comissionAmount { get; set; }
        public string agentService { get; set; }
        public string debitAccount { get; set; }
        public string debitAccountTitle { get; set; }
        public string creditAccount { get; set; }
        public string creditAccountTitle { get; set; }
        //public string amountInWords { get; set; }
    }
}
