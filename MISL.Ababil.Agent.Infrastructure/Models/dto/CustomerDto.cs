using MISL.Ababil.Agent.Infrastructure.Models.domain.models;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.dto
{
    public class CustomerDto
    {
        public List<AccountInformation> accountInformations { get; set; }
        public String name { get; set; }
        public String email { get; set; }
        public String mobileNumber { get; set; }
        public String nId { get; set; }
        public Address businessAddress { get; set; }

        //private String name;
        //private String email;
        //private String mobileNumber;
        //private String nId;
        //private Address businessAddress;
        //private List<AccountInformation> accountInformations;
        
        //public String getName()
        //{
        //    return name;
        //}
        //public void setName(String name)
        //{
        //    this.name = name;
        //}
        //public String getEmail()
        //{
        //    return email;
        //}
        //public void setEmail(String email)
        //{
        //    this.email = email;
        //}
        //public String getMobileNumber()
        //{
        //    return mobileNumber;
        //}
        //public void setMobileNumber(String mobileNumber)
        //{
        //    this.mobileNumber = mobileNumber;
        //}
        //public String getnId()
        //{
        //    return nId;
        //}
        //public void setnId(String nId)
        //{
        //    this.nId = nId;
        //}
        //public Address getBusinessAddress()
        //{
        //    return businessAddress;
        //}
        //public void setBusinessAddress(Address businessAddress)
        //{
        //    this.businessAddress = businessAddress;
        //}
        //public List<AccountInformation> getAccountInformations()
        //{
        //    return accountInformations;
        //}
        //public void setAccountInformations(List<AccountInformation> accountInformations)
        //{
        //    this.accountInformations = accountInformations;
        //}
    }
}
