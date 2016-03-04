using System;
using System.Collections.Generic;

namespace MISL.Ababil.Agent.Infrastructure.Models.domain.models.account.tp
{

	public class CbsTransactionProfile
	{
		private long _id;


		private string _code;

		private string _description;


		private string _createUser;


		private long _createDate;

		private long _createTime;

		private IList<CbsTransactionLimit> _limit;

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


		public virtual string code
		{
			get
			{
				return _code;
			}
			set
			{
				this._code = value;
			}
		}


		public virtual string description
		{
			get
			{
				return _description;
			}
			set
			{
				this._description = value;
			}
		}


		public virtual string createUser
		{
			get
			{
				return _createUser;
			}
			set
			{
				this._createUser = value;
			}
		}


		public virtual long createDate
		{
			get
			{
				return _createDate;
			}
			set
			{
			    if (value == null) this.createDate = 0;
				else this._createDate = value;
			}
		}


		public virtual long createTime
		{
			get
			{
				return _createTime;
			}
			set
			{
                if (value == null) this.createTime = 0;
                this._createTime = value;
			}
		}


		public virtual IList<CbsTransactionLimit> limit
		{
			get
			{
				return _limit;
			}
			set
			{
				this._limit = value;
			}
        }

        public TpType tpType;
        public TpMode tpMode;

	}

}