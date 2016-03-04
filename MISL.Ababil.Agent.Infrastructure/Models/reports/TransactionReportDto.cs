using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Infrastructure.Models.reports
{
   public class TransactionReportDto
    {
        private String _agentName;
        private String _outletName;
        private String _outletAdress;

        private String _creditorAccountName;
        private String _creditorAccountNumber;

        private String _debitoAccountName;
        private String _debitorAccountNumber;


        private DateTime _transactionDate;
        private String _voucherNumber;
        private String _userId;
        private Decimal _transactionAmount;
        private String _amountInWords;

        public TransactionReportDto()
        {

        }

        public TransactionReportDto(String agentName, String outletName,
                String outletAdress, String creditorAccountName,
                String creditorAccountNumber, String debitoAccountName,
                String debitorAccountNumber, DateTime transactionDate,
                String voucherNumber, String userId, Decimal transactionAmount,string amountInWords)
        {

            this._agentName = agentName;
            this._outletName = outletName;
            this._outletAdress = outletAdress;
            this._creditorAccountName = creditorAccountName;
            this._creditorAccountNumber = creditorAccountNumber;
            this._debitoAccountName = debitoAccountName;
            this._debitorAccountNumber = debitorAccountNumber;
            this._transactionDate = transactionDate;
            this._voucherNumber = voucherNumber;
            this._userId = userId;
            this._transactionAmount = transactionAmount;
            this._amountInWords = amountInWords;
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
        public virtual string creditorAccountName
        {
            get
            {
                return _creditorAccountName;
            }
            set
            {
                this._creditorAccountName = value;
            }
        }
        public virtual string creditorAccountNumber
        {
            get
            {
                return _creditorAccountNumber;
            }
            set
            {
                this._creditorAccountNumber = value;
            }
        }
        public virtual string debitoAccountName
        {
            get
            {
                return _debitoAccountName;
            }
            set
            {
                this._debitoAccountName = value;
            }
        }
        public virtual string debitorAccountNumber
        {
            get
            {
                return _debitorAccountNumber;
            }
            set
            {
                this._debitorAccountNumber = value;
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
        public virtual Decimal transactionAmount
        {
            get
            {
                return _transactionAmount;
            }
            set
            {
                this._transactionAmount = value;
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