using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.domain.models.account
{
    public class DefaultAccountTypeDefinition
    {
        private static long serialVersionUID = 1L;
        public long id { get; set; }
        public string defaultAgentAccountType { get; set; }
        public string defaultConsumerAccountType { get; set; }
    }
}
