using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.fingerprint;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.user;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.consumer;

namespace MISL.Ababil.Agent.Infrastructure.Models.domain.models.fingerprint
{
   public class BiometricTemplate
    {
       private static long serialVersionUID = 1L;
       public string hand { get; set; }
       public string finger { get; set; }
       public string bioData { get; set; }
      

    }
}
