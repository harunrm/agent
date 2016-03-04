namespace MISL.Ababil.Agent.Infrastructure.Models.domain.models.account.kyc
{
    public class KycAccountOpeningMode
	{
		private long _id;
		private string _openingMode;
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
		public virtual string openingMode
		{
			get
			{
				return _openingMode;
			}
			set
			{
				this._openingMode = value;
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