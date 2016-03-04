using MISL.Ababil.Agent.Communication;
using MISL.Ababil.Agent.Infrastructure.Models.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Services
{
    public class TransactionProfileEditServices
    {
        public List<TransactionProfileDto> GetTransactionProfileByAccountNo(string accNo)
        {
            TransactionProfileEditCom transactionProfileEditCom = new TransactionProfileEditCom();
            return transactionProfileEditCom.GetTransactionProfileByAccountNo(accNo);
        }

        public string saveTransactionProfileDtoList(List<TransactionProfileDto> transactionProfileDtoList)
        {
            TransactionProfileEditCom transactionProfileEditCom = new TransactionProfileEditCom();
            return transactionProfileEditCom.saveTransactionProfileDtoList(transactionProfileDtoList);
        }
    }
}