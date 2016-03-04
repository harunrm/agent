using System;

namespace com.mislbd.agentbanking.report.dto
{

	public class ConsumerApplicationReportDto
	{


		private String _agentName;
		private String _outletName;
		private String _outletAdress;
		private String _userId;

		private String _customerName;
		private String _mobileNo;
		private String _unionName;
		private String _upazillaName;
		private String _districtName;
		private long _dateOfApplication;
		private String _villageName;


		public ConsumerApplicationReportDto()
		{

		}

		public ConsumerApplicationReportDto(String agentName, String outletName, String outletAdress, String userId, String customerName, String mobileNo, String unionName, String upazillaName, String districtName, String villageName)
		{

			this._agentName = agentName;
			this._outletName = outletName;
			this._outletAdress = outletAdress;
			this._userId = userId;
			this._customerName = customerName;
			this._mobileNo = mobileNo;
			this._unionName = unionName;
			this._upazillaName = upazillaName;
			this._districtName = districtName;
			this._villageName = villageName;

		}

		public virtual String agentName
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
		public virtual String outletName
		{
			get
			{
				return _outletName;
			}
			set
			{
				this._outletName = value;
			}
		}
		public virtual String outletAdress
		{
			get
			{
				return _outletAdress;
			}
			set
			{
				this._outletAdress = value;
			}
		}
		public virtual String userId
		{
			get
			{
				return _userId;
			}
			set
			{
				this._userId = value;
			}
		}
		public virtual String customerName
		{
			get
			{
				return _customerName;
			}
			set
			{
				this._customerName = value;
			}
		}
		public virtual String mobileNo
		{
			get
			{
				return _mobileNo;
			}
			set
			{
				this._mobileNo = value;
			}
		}
		public virtual String unionName
		{
			get
			{
				return _unionName;
			}
			set
			{
				this._unionName = value;
			}
		}
		public virtual String upazillaName
		{
			get
			{
				return _upazillaName;
			}
			set
			{
				this._upazillaName = value;
			}
		}
		public virtual String districtName
		{
			get
			{
				return _districtName;
			}
			set
			{
				this._districtName = value;
			}
		}

		public virtual String villageName
		{
			get
			{
				return _villageName;
			}
			set
			{
				this._villageName = value;
			}
		}
        public virtual long dateOfApplication
		{
			get
			{
				return _dateOfApplication;
			}
			set
			{
				this._dateOfApplication = value;
			}
		}


	}
}