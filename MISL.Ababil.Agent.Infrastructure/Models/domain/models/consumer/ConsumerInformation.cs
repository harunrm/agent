using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.consumer;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.cis;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.fingerprint;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.user;

namespace MISL.Ababil.Agent.Infrastructure.Models.domain.models.consumer
{
    public class ConsumerInformation
    {
        private static long serialVersionUID = 1L;
        public long id { get; set; }
        public long cbsCustomerNumber { get; set; }
        public String customerTitle { get; set; }
        public byte[] photo { get; set; }
        public String mobileNumber { get; set; }
        public String nationalId { get; set; }
        public String referenceNumber { get; set; }
        public List<BiometricTemplate> fingerDatas { get; set; }
        public ApprovalStatus approvalStatus { get; set; }
        public SubAgentUser subAgentUser { get; set; }
        public long creationDate { get; set; }
        public int numberOfOperator { get; set; }
        public decimal? openingAmount { get; set; }
        public String intrducerAccNumber { get; set; }
        //public CustomerInformation customer { get; set; }

        //public AccountInformation account { get; set; }








        //public long getId()
        //{
        //    return id;
        //}
        //public void setId(long id)
        //{
        //    this.id = id;
        //}
        //public CustomerInformation getCustomer()
        //{
        //    return customer;
        //}
        //public void setCustomer(CustomerInformation customer)
        //{
        //    this.customer = customer;
        //}
        //public AccountInformation getAccount()
        //{
        //    return account;
        //}
        //public void setAccount(AccountInformation account)
        //{
        //    this.account = account;
        //}
        //public List<FingerData> getFingerDatas()
        //{
        //    return fingerDatas;
        //}
        //public void setFingerDatas(List<FingerData> fingerDatas)
        //{
        //    this.fingerDatas = fingerDatas;
        //}
        //public ApprovalStatus getApprovalStatus()
        //{
        //    return approvalStatus;
        //}
        //public void setApprovalStatus(ApprovalStatus approvalStatus)
        //{
        //    this.approvalStatus = approvalStatus;
        //}
        //public UserInformation getSubAgentUser()
        //{
        //    return subAgentUser;
        //}
        //public void setSubAgentUser(UserInformation subAgentUser)
        //{
        //    this.subAgentUser = subAgentUser;
        //}

    }
}
