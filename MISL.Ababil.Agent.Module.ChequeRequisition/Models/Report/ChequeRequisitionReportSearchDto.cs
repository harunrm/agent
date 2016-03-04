using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Module.ChequeRequisition.Models.Report
{
    public class ChequeRequisitionReportSearchDto
    {
        public long agentId { get; set; }
        public long subAgentId { get; set; }
        public UrgencyType? urgencyType { get; set; }
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
        public ChequeRequisitionStatus? chequeRequisitionStatus { get; set; }

    }
}
