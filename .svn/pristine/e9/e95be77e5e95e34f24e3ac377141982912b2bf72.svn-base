using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.common
{
    public enum Rights
    {
        DRAFT_CONSUMER_APPLICATION = 0, SUBMIT_CONSUMER = 1, VERIFY_CONSUMER = 2, APPROVE_CONSUMER = 3, CANCEL_CONSUMER_APPLICATION = 4, CREATE_BANK_USER = 5, 
        REPORT_VIEW_CENTRALLY=6, REPORT_VIEW_AGENTWISE=7, ADMINISTRATIVE=8

    }
    
    public class UserWiseRights
    {
        public static List<string> subAgentRights = new List<string>(new string[] { Rights.DRAFT_CONSUMER_APPLICATION.ToString(), Rights.SUBMIT_CONSUMER.ToString() });
        public static List<string> fieldOfficerRights = new List<string>(new string[] { Rights.VERIFY_CONSUMER.ToString(), Rights.CANCEL_CONSUMER_APPLICATION.ToString() });
        public static List<string> BranchRights = new List<string>(new string[] { Rights.APPROVE_CONSUMER.ToString(), Rights.CANCEL_CONSUMER_APPLICATION.ToString() });
    }
}
