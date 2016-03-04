using System;
using System.Collections.Generic;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.user;

namespace MISL.Ababil.Agent.Infrastructure.Mediators
{
    public class AgentInformationMediator
    {

        public long Id { get; set; }
        public string AgentCode { get; set; }
        public string BusinessName { get; set; }
        public Address AgentAddress { get; set; }
        //public int CustomerId { get; set; }
        public DateTime CreationDate { get; set; }
        public string TransactionStatus { get; set; }
        public string ApprovalStatus { get; set; }
        public DateTime ApprovalDate { get; set; }



        public AgentInformationMediator(AgentInformation agentInformation)
        {
            Id = agentInformation.id;
            AgentCode = agentInformation.agentCode;
            BusinessName = agentInformation.businessName;
            AgentAddress = agentInformation.agentAddress;
            CreationDate = Utility.FromUnixTime(agentInformation.creationDate);
            ApprovalDate = Utility.FromUnixTime(agentInformation.approvalDate);
            ApprovalStatus = agentInformation.approvalStatus.ToString();
            TransactionStatus = agentInformation.transactionStatus.ToString();
            //CustomerId = agentInformation.customerId;
        }


        public static List<AgentInformationMediator> GetAgentInformationMediatedList(
            List<AgentInformation> agentInformations)
        {
            List<AgentInformationMediator> agents = new List<AgentInformationMediator>();
            foreach (AgentInformation information in agentInformations)
            {
                AgentInformationMediator mediator = new AgentInformationMediator(information);
                agents.Add(mediator);
            }
            return agents;
        } 
    }
}