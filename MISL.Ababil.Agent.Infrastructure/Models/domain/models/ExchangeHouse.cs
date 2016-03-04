using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.domain.models
{
    public class ExchangeHouse
    {
        public long id { get; set; }

        public String name { get; set; }

        public Address address { get; set; }
    }
}