namespace MISL.Ababil.Agent.Infrastructure.Models.domain.models.ssp
{

    public class SspAccountInformationSearchDto
    {

        private string _depositAccNum;
        private string _depositAcctitle;
        private string _sspAccNum;
        private SspProductType _sspProductType;
        private decimal _amount;
        private string _referanceNumber;
        public sspaccountstatus sspAccountStatus { get; set; }

        private bool _isdepositAccNum;
        private bool _isdepositAcctitle;
        private bool _issspAccNum;
        private bool _issspProductType;
        private bool _isamount;
        private bool _isreferanceNumber;
        public bool issspAccountStatus { get; set; }

        public virtual string depositAccNum
        {
            get
            {
                return _depositAccNum;
            }
            set
            {
                this._depositAccNum = value;
            }
        }
        public virtual string depositAcctitle
        {
            get
            {
                return _depositAcctitle;
            }
            set
            {
                this._depositAcctitle = value;
            }
        }
        public virtual string sspAccNum
        {
            get
            {
                return _sspAccNum;
            }
            set
            {
                this._sspAccNum = value;
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
        public virtual decimal amount
        {
            get
            {
                return _amount;
            }
            set
            {
                this._amount = value;
            }
        }
        public virtual string referanceNumber
        {
            get
            {
                return _referanceNumber;
            }
            set
            {
                this._referanceNumber = value;
            }
        }
        public virtual bool isdepositAccNum
        {
            get
            {
                return _isdepositAccNum;
            }
            set
            {
                this._isdepositAccNum = value;
            }
        }
        public virtual bool isdepositAcctitle
        {
            get
            {
                return _isdepositAcctitle;
            }
            set
            {
                this._isdepositAcctitle = value;
            }
        }
        public virtual bool issspAccNum
        {
            get
            {
                return _issspAccNum;
            }
            set
            {
                this._issspAccNum = value;
            }
        }
        public virtual bool issspProductType
        {
            get
            {
                return _issspProductType;
            }
            set
            {
                this._issspProductType = value;
            }
        }
        public virtual bool isamount
        {
            get
            {
                return _isamount;
            }
            set
            {
                this._isamount = value;
            }
        }
        public virtual bool isreferanceNumber
        {
            get
            {
                return _isreferanceNumber;
            }
            set
            {
                this._isreferanceNumber = value;
            }
        }

    }

}