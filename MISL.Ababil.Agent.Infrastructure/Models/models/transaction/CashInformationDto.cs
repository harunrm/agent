using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.models.transaction
{
    public class CashInformationDto
    {
        public string outletName { get; set; }
        public decimal? previousDayBalance { get; set; }
        public List<cashInfoDetailsDtos> cashInfoDetailsDtos { get; set; }
    }
}