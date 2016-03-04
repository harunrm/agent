using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.domain.models.account
{
    public class AccountOperators
    {
        public long id { get; set; }
        public String identity { get; set; }
        public String identityName { get; set; }
        public String fingerData { get; set; }
        public AccountInformation accountInformation { get; set; }
    }
}
