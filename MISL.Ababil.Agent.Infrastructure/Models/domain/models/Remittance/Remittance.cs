using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.domain.models.Remittance
{
    public class Remittance
    {
        public long id { get; set; }

        public ExchangeHouse exchangeHouse { get; set; }
        public string outletName { get; set; }
        public String pinCode { get; set; }
        public Decimal expectedAmount { get; set; }
        public Decimal remittanceAmount { get; set; }
        public String senderName { get; set; }
        public Country senderCountry { get; set; }
        public String senderPurpose { get; set; }
        public RemittanceStatus remittanceStatus { get; set; }
        public String benificaryName { get; set; }
        public String benificaryFatherName { get; set; }
        public String benificaryMotherName { get; set; }
        public Address benificaryAddress { get; set; }
        public String benificaryMobileNumber { get; set; }

        public String comments { get; set; }
        public String benificarynid { get; set; }

        public String referanceNumber { get; set; }

        public long documentId { get; set; }

        public string entryUser { get; set; }
        public string entryUserDateTime { get; set; }
        public string firstApprover { get; set; }
        public string firstApprovalDateTime { get; set; }
        public string secondApprover { get; set; }
        public string secondApprovalDateTime { get; set; }

        public string voucherNumber { get; set; }

        public long bankdocumentId { get; set; }
    }
}