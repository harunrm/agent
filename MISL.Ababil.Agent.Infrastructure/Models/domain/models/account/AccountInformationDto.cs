using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.domain.models.account
{
    public class AccountInformationDto
    {
        public string accountTitle { get; set; }
        public AccountStatus accountStatus { get; set; }
        public decimal balance { get; set; }
        public byte[] image { get; set; }
        public String mobileNumber { get; set; }
    }
}
