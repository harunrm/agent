﻿namespace MISL.Ababil.Agent.Infrastructure.Models.domain.models.account.kyc
{
    public class KycCustomerTurnover
	{
		private long _id;
		private string _turnOverAmount;
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
		public virtual string turnOverAmount
		{
			get
			{
				return _turnOverAmount;
			}
			set
			{
				this._turnOverAmount = value;
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