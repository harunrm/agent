using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.dto
{
    public class AgentBalanceDto
    {
        public long id { get; set; }
        public string agentCode { get; set; }
        public string businessName { get; set; }
        public string contactNo { get; set; }
        public string accountNo { get; set; }
        public decimal accountBalance { get; set; }
        public List<OutletBalanceDto> outletBalanceList { get; set; }
    }
}
