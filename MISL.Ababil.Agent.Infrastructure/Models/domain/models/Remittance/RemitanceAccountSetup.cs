using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.domain.models.Remittance
{
    public class RemitanceAccountSetup
    {
        public long id { get; set; }
        public ExchangeHouse exchangeHouse { get; set; }
        public DateTime effectDate { get; set; }
        public AccountNature accountNature { get; set; }
        public String accountNumber { get; set; }
    }
}