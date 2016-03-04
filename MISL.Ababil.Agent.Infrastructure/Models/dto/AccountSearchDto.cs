using MISL.Ababil.Agent.Infrastructure.Models.domain.models.account;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;

namespace MISL.Ababil.Agent.Infrastructure.Models.dto
{

	public class AccountSearchDto
	{

		private AgentInformation _agent;
		private SubAgentInformation _subAgent;
		private AgentProduct _product;
	    public long fromDate { get; set; }
	    public long? toDate { get; set; }

	    public virtual AgentInformation agent
		{
			get
			{
				return _agent;
			}
			set
			{
				this._agent = value;
			}
		}
		public virtual SubAgentInformation subAgent
		{
			get
			{
				return _subAgent;
			}
			set
			{
				this._subAgent = value;
			}
		}
		public virtual AgentProduct product
		{
			get
			{
				return _product;
			}
			set
			{
				this._product = value;
			}
		}



	}

}