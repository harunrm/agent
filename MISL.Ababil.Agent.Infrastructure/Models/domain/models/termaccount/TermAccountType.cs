using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.domain.models.termaccount
{
    public class TermProductType
    {
        //public static long serialVersionUID = 1L;
        public long? id { get; set; }
        public string productPrefix { get; set; }
        public string productDescription { get; set; }
        public AccountType accountType { get; set; }
    }
}
