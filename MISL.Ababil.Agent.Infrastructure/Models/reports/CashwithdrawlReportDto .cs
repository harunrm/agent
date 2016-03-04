using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.reports
{
    public class CashwithdrawlReportDto
    {

        private String _agentName;
        private String _outletName;
        private String _outletAdress;

        private String _accountName;
        private String _accountNumber;
        private DateTime _transactionDate;
        private String _voucherNumber;
        private String _userId;
        private Decimal _amount;
        private String _amountInWords;



        public CashwithdrawlReportDto()
        {

        }


        public CashwithdrawlReportDto(String agentName, String outletName,
                String outletAdress, String accountName, String accountNumber,
                DateTime transactionDate, String voucherNumber, String userId,
                Decimal amount, string amountInWords)
        {

            this._agentName = agentName;
            this._outletName = outletName;
            this._outletAdress = outletAdress;
            this._accountName = accountName;
            this._accountNumber = accountNumber;
            this._transactionDate = transactionDate;
            this._voucherNumber = voucherNumber;
            this._userId = userId;
            this._amount = amount;
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
        public virtual string outletName
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
        public virtual string outletAdress
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
        public virtual string userId
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
        public virtual string accountName
        {
            get
            {
                return _accountName;
            }
            set
            {
                this._accountName = value;
            }
        }
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
        public virtual DateTime transactionDate
        {
            get
            {
                return _transactionDate;
            }
            set
            {
                this._transactionDate = value;
            }
        }
        public virtual string voucherNumber
        {
            get
            {
                return _voucherNumber;
            }
            set
            {
                this._voucherNumber = value;
            }
        }
        public virtual Decimal amount
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

        public virtual string amountInWords
        {
            get
            {
                return _amountInWords;
            }
            set
            {
                this._amountInWords = value;
            }

        }

    }


}
