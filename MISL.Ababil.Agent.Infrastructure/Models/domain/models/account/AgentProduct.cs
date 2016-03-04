using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MISL.Ababil.Agent.Infrastructure.Models.domain.models.account
{
    public class AgentProduct
    {
        public long id { get; set; }
        public String productPrefix { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ProductType productType { get; set; }
        public string productTitle { get; set; }
        public decimal? openingDeposit { get; set; }
        public long openingDepositGl { get; set; }
        public DepositAccountCategory accountCategory { get; set; }
    }
}
