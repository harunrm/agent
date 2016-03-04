using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.domain.models.consumer
{
    public class ConsumerInformationDto
    {
        private static long serialVersionUID = 1L;

        public long id { get; set; }

        public string consumerTitle { get; set; }
               
        public string photo { get; set; }
               
        public string mobileNumber { get; set; }

        public int numberOfOperator { get; set; }

        public List<AccountOperator> accountOperators { get; set; }

        public decimal? balance { get; set; }
    }
}