using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using System.Web.Script.Serialization;
using MISL.Ababil.Agent.Communication;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account;
using System.Windows.Forms;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.user;
using MISL.Ababil.Agent.Infrastructure;

namespace MISL.Ababil.Agent.Services
{
    public class SubAgentServices
    {
        SubAgentService objSubAgentCom = new SubAgentService();

        public string saveSubAgentInfo(SubAgentInformation subAgentInfo)
        {
            SubAgentService objSubAgentInfo = new SubAgentService();
            return objSubAgentInfo.saveSubAgent(subAgentInfo);
        }

        public SubAgentInformation getSubAgentInfoById(string subAgentId)
        {
            return objSubAgentCom.getSubAgentInfoById(subAgentId);
        }

        public List<SubAgentUser> getSubAgentUserList()
        {
            return objSubAgentCom.getSubAgentUserList();
        }

        public List<SubAgentInformation> GetAllSubAgents()
        {
            SubAgentService subAgentService = new SubAgentService();
            return subAgentService.GetAllSubAgents();
        }

        public void SaveSubagentCreditLimit(string outletId, decimal? limit)
        {
            objSubAgentCom.SaveSubagentCreditLimit(outletId, limit);
        }

        public void SaveSubagentDebitLimit(string outletId, decimal? limit)
        {
            objSubAgentCom.SaveSubagentDebitLimit(outletId, limit);
        }

        public void SetCreditLimit(string outletId, bool status)
        {
            objSubAgentCom.SetCreditLimit(outletId, status);
        }

        public void SetDebitLimit(string outletId, bool status)
        {
            objSubAgentCom.SetDebitLimit(outletId, status);
        }


        public List<SubAgentUser> GetSubAgentUserListBySubAgentId(long subAgentId)
        {
            SubAgentService subAgentService = new SubAgentService();
            return subAgentService.GetSubAgentUserListBySubAgentId(subAgentId);
        }
        public ServiceResult SetSubAgentUserCreditLimit(string outletUserId, bool status)
        {
            return objSubAgentCom.SetSubAgentUserCreditLimit(outletUserId, status);
        }
        public ServiceResult SaveSubAgentUserCreditLimit(string outletUserId, decimal? limit)
        {
            return objSubAgentCom.SaveSubAgentUserCreditLimit(outletUserId, limit);
        }
        public ServiceResult SetSubAgentUserDebitLimit(string outletUserId, bool status)
        {
            return objSubAgentCom.SetSubAgentUserDebitLimit(outletUserId, status);
        }
        public ServiceResult SaveSubAgentUserDebitLimit(string outletUserId, decimal? limit)
        {
            return objSubAgentCom.SaveSubAgentUserDebitLimit(outletUserId, limit);
        }

    }
}