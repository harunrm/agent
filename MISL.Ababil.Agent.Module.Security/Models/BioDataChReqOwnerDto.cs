using MISL.Ababil.Agent.Infrastructure.Models.domain.models.fingerprint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Module.Security.Models
{
    public class BioDataChReqOwnerDto
    {
        public string identity { get; set; }
        public long bioDataChReqOwnerId { get; set; }
        public string individualName { get; set; }
        public long individualId { get; set; }
        public string reason { get; set; }
        public List<BiometricTemplate> fingerDatas { get; set; }
        public bool? capture { get; set; }

        public string token { get; set; }
    }
}