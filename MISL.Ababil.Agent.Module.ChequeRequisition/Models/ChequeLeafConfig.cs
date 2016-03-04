using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Module.ChequeRequisition.Models
{
    public class ChequeLeafConfig
    {
        public long id { get; set; }
        public int numberOfLeaf { get; set; }
        public decimal charge { get; set; }
    }
}