using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.reports
{
    public class SspSlipDto
    {
        public string agentName { get; set; }
        public string outLetName { get; set; }
        public string outLetAddress { get; set; }
        public string outLetUserName { get; set; }
        public string customerName { get; set; }
        public string customerVillage { get; set; }
        public string customerUnion { get; set; }
        public string customerUpozilla { get; set; }
        public string customerDistrict { get; set; }
        public string sspAccountName { get; set; }
        public string customerId { get; set; }
        public string sspAccountNumber { get; set; }
        public string curOrSavingAccountNumber { get; set; }
        public long? openingDate { get; set; }
        public Decimal installment { get; set; }
        public long installmentPerod { get; set; }
        public long? maturDate { get; set; }
        public Decimal? maturAmount { get; set; }
        public string mobileNumber { get; set; }
        public string referenceNo { get; set; }
    }
}
