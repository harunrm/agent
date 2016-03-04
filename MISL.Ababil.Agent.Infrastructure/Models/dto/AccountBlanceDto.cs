namespace MISL.Ababil.Agent.Infrastructure.Models.dto
{

	public class AccountBlanceDto
	{

		private string _accountNumber;
		private string _accTitle;
		public decimal? balance;
	    public long? openDate { get; set; }

	    public virtual string accountNumber
		{
			get
			{
				return _accountNumber;
			}
			set
			{
				this._accountNumber = value;
			}
		}
		public virtual string accTitle
		{
			get
			{
				return _accTitle;
			}
			set
			{
				this._accTitle = value;
			}
		}

        #region WALI :: 20-Jul-2015
        private string _productTitle;
        private string _mobileNumber;
        private string _agentName;
        private long _agentId;
        private string _subAgentName;
        private long _subAgentId;
        private string _productType;

        public virtual string productTitle
        {
            get
            {
                return _productTitle;
            }
            set
            {
                this._productTitle = value;
            }
        }
        public virtual string mobileNumber
        {
            get
            {
                return _mobileNumber;
            }
            set
            {
                this._mobileNumber = value;
            }
        }
        public virtual string agentName
        {
            get
            {
                return _agentName;
            }
            set
            {
                this._agentName = value;
            }
        }
        public virtual long agentId
        {
            get
            {
                return _agentId;
            }
            set
            {
                this._agentId = value;
            }
        }
        public virtual string subAgentName
        {
            get
            {
                return _subAgentName;
            }
            set
            {
                this._subAgentName = value;
            }
        }
        public virtual long subAgentId
        {
            get
            {
                return _subAgentId;
            }
            set
            {
                this._subAgentId = value;
            }
        }
        public virtual string productType
        {
            get
            {
                return _productType;
            }
            set
            {
                this._productType = value;
            }
        }
        #endregion

    }

}