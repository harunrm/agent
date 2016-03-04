using MISL.Ababil.Agent.Infrastructure.Models.domain.models.Remittance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.dto
{
    public class ExchangeHouseSetupDto
    {
        public ExchangeHouse exchangeHouse { get; set; }
        public RemitanceAccountSetup remitanceAccountSetup { get; set; }
    }
}