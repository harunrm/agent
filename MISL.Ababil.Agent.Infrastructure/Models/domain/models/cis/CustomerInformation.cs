using MISL.Ababil.Agent.Infrastructure.Models.domain.models.documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.domain.models.cis
{
   public class CustomerInformation
    {
        private static long serialVersionUID = 1L;
        public long id { get; set; }
        public string title { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string mobileNumber { get; set; }
        public string fax { get; set; }
        public CisLocation location { get; set; }
        public Address businessAddress { get; set; }
        public Address permanentAddress { get; set; }
        public Address presentAddress { get; set; }
        public long? branchId { get; set; }
        public CisType cisType { get; set; }
        public CisInstituteType cisInstituteType { get; set; }
        public List<OwnerInformation> owners { get; set; }
        public long? cbsCustomerId { get; set; } //new added
        public long? documentInfoId { get; set; }
        public long? sectorType { set; get; }//add selector 

        public string sectorCode { set; get; }

        public string borrowerCode { set; get; }

    }
}
