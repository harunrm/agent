using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.cis;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.consumer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.dto
{
    public class CustomerAccountDto
    {
        public int numberOfOperator { get; set; }
        public String accNumber { get; set; }
        public CustomerInformation customerInformation { get; set; }
        
    }
}
