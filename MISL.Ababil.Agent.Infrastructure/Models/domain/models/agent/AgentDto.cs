using System;

namespace MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent
{

	public class AgentDto
	{

		private string _agentCode;
		private string _businessName;
		private long? _creationDateFrom;
		private long?_creationDateTo;
		private long? _approvalDateFrom;
		private long? _approvalDateTo;
        

	    public bool useCode { get; set; }
	    public bool useName { get;  set; }
	    public bool useCreationDate { get;  set; }
	    public bool useApprovalDate { get;  set; }

        public bool useTransactionStatus { get; set; }
        public bool useApprovalStatus { get; set; }


	    private AgentTransactionStatus _transactionStatus;
		private ApprovalStatus _approvalStatus;

	    public AgentDto()
	    {
	        useCode = false;
	        useName = false;
	        useCreationDate = false;
	        useApprovalDate = false;
	    }

		public virtual string agentCode
		{
			get
			{
				return _agentCode;
			}
			set
			{
				_agentCode = value;
			}
		}
		public virtual string businessName
		{
			get
			{
				return _businessName;
			}
			set
			{
				_businessName = value;
			}
		}

		public virtual long? creationDateFrom
		{
			get
			{
				return _creationDateFrom;
			}
			set
			{
				_creationDateFrom = value;
			}
		}
		public virtual long? creationDateTo
		{
			get
			{
				return _creationDateTo;
			}
			set
			{
				_creationDateTo = value;
			}
		}
		public virtual long? approvalDateFrom
		{
			get
			{
				return _approvalDateFrom;
			}
			set
			{
				_approvalDateFrom = value;
			}
		}
		public virtual long? approvalDateTo
		{
			get
			{
				return _approvalDateTo;
			}
			set
			{
				_approvalDateTo = value;
			}
		}
		public virtual AgentTransactionStatus transactionStatus
		{
			get
			{
				return _transactionStatus;
			}
			set
			{
				_transactionStatus = value;
			}
		}
		public virtual ApprovalStatus approvalStatus
		{
			get
			{
				return _approvalStatus;
			}
			set
			{
				_approvalStatus = value;
			}
		}

	}

}