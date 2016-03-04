using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.reports
{
    public class MTDPaySlipDto
    {

  
        public string outLetName { get; set; }
        public string customerName { get; set; }
        public string accountNumber { get; set; }
        public DateTime accOpeningDate { get; set; }
        public string durationMonths { get; set; }
        public DateTime expairyDate { get; set; }
        public Decimal amount { get; set; }
     

    }
}
