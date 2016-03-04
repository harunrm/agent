namespace MISL.Ababil.Agent.Infrastructure.Models.domain.models.account.kyc
{
    public class KycCashMonthlyTxnAmount
	{
		private long _id;
		private decimal _minAmount;
		private decimal _maxAmount;
		private string _txnType;

		private string _riskLevel;
		private int _riskRating;

	    public virtual long id
		{
			get
			{
				return _id;
			}
			set
			{
				this._id = value;
			}
		}
		public virtual decimal minAmount
		{
			get
			{
				return _minAmount;
			}
			set
			{
				this._minAmount = value;
			}
		}
		public virtual decimal maxAmount
		{
			get
			{
				return _maxAmount;
			}
			set
			{
				this._maxAmount = value;
			}
		}
		public virtual string txnType
		{
			get
			{
				return _txnType;
			}
			set
			{
				this._txnType = value;
			}
		}
		public virtual string riskLevel
		{
			get
			{
				return _riskLevel;
			}
			set
			{
				this._riskLevel = value;
			}
		}
		public virtual int riskRating
		{
			get
			{
				return _riskRating;
			}
			set
			{
				this._riskRating = value;
			}
		}


	}

}