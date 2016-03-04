namespace MISL.Ababil.Agent.Infrastructure.Models.domain.models.ssp
{

	public class SspInstallment
	{

		private const long SerialVersionUid = 1L;
		private long _id;

		private SspProductType _sspProductType;

		private long _installPeriod;

		private decimal _installAmount;

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


		public virtual SspProductType sspProductType
		{
			get
			{
				return _sspProductType;
			}
			set
			{
				this._sspProductType = value;
			}
		}



		public virtual long installPeriod
		{
			get
			{
				return _installPeriod;
			}
			set
			{
				this._installPeriod = value;
			}
		}


		public virtual decimal installAmount
		{
			get
			{
				return _installAmount;
			}
			set
			{
				this._installAmount = value;
			}
		}





	}

}