using MISL.Ababil.Agent.Infrastructure.Models.domain.models.cis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.domain.models.consumer
{
   public class CustomerApplyDto
    {
        public String customerName { get; set; }
        public String nationalId { get; set; }
        public String mobileNo { get; set; }
        public long productType { get; set; }
        public decimal? openingDeposit { get; set; }
        public int noOfOperator { get; set; }
        public CisType cisType { get; set; }
        public List<OwnerInformation> ownerInformations { get; set; }
        public byte[] photo { get; set; }
    }
}
