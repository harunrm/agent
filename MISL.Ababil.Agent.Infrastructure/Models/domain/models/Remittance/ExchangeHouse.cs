using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.domain.models.Remittance
{
    public class ExchangeHouse
    {
        
        public long id { get; set; }
        public String companyName { get; set; }
        public String shortName { get; set; }
        public Address address { get; set; }
        public String mobile { get; set; }
        public String telephone { get; set; }
        public String fax { get; set; }
        public String email { get; set; }
        public String website { get; set; }
    }
}
