using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.models.transaction
{
    public class TransactionPurpose
    {
        private static long serialVersionUID = 1L;

        public long id { get; set; }

        public String purpose { get; set; }

        public String txnType { get; set; }

        public string cmbFillingDisplayMember
        {
            get
            {
                if (txnType == "(Select)")
                {
                    return "(Select)";
                }
                return purpose + " (" + txnType + ")";
            }
        }
    }
}