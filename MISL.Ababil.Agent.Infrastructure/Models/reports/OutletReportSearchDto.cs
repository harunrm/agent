using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models;

namespace MISL.Ababil.Agent.Infrastructure.Models.reports
{
    public class OutletReportSearchDto
    {
        public long agentId { get; set; }
        public OutletStatus? status { get; set; }
        public long divisionId { get; set; }
        public long districtId { get; set; }
        public long thanaId { get; set; }

        public OutletReportSearchDto()
        {
            agentId = 0;
            divisionId = 0;
            districtId = 0;
            thanaId = 0;
        }
    }
}
