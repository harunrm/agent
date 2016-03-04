namespace MISL.Ababil.Agent.Infrastructure.Models.domain.models.account.kyc
{
    public class KycCashMonthlyTxnNumber
	{
		private long _id;
		private int _minNumber;
		private int _maxNumber;
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
		public virtual int minNumber
		{
			get
			{
				return _minNumber;
			}
			set
			{
				this._minNumber = value;
			}
		}
		public virtual int maxNumber
		{
			get
			{
				return _maxNumber;
			}
			set
			{
				this._maxNumber = value;
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