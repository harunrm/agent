using MISL.Ababil.Agent.Infrastructure.Models.domain.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.dto
{
    public class AllApplicationSearchDto
    {
        public String consumerName { get; set; }
        public String nationalId { get; set; }
        public String mobileNo { get; set; }
        public String referenceNumber { get; set; }
        public ApplicationStatus applicationStatus { get; set; }
        public long fromDate { get; set; }
        public long toDate { get; set; }

    }  
}
