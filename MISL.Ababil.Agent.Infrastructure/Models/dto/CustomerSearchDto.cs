using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account;

namespace MISL.Ababil.Agent.Infrastructure.Models.dto
{
    public class CustomerSearchDto
    {

        public long? customerCbsId { get; set; }
        public string customerName { get; set; }
        public string acccountNo { get; set; }
        public ProductType? accountType { get; set; }
        public string nationalId { get; set; }
        public DateTime? birthDate { get; set; }
        public string mobileNo { get; set; }
    }
}
