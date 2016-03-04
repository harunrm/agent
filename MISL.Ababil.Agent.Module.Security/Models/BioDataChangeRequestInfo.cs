using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Module.Security.Models
{
    public class BioDataChangeRequestInfo
    {
        public long id { get; set; }
        public string accountNo { get; set; }
        public string requestOutletUser { get; set; }
        public long requestOutletId { get; set; }
        public long? requestDate { get; set; }
        public long? requestTime { get; set; }
        public string approveUser { get; set; }
        public long? approveDate { get; set; }
        public long? approveTime { get; set; }
    }
}