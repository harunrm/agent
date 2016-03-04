using MISL.Ababil.Agent.Communication;
using MISL.Ababil.Agent.Infrastructure.Models.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Services
{
    public class ExchangeHouseSetupService
    {
        public string saveExchangeHouseSetup(ExchangeHouseSetupDto exchangeHouseSetupdto)
        {
            ExchangeHouseSetupCom objExchangeHouseSetupCom = new ExchangeHouseSetupCom();
            string responseString = objExchangeHouseSetupCom.saveExchangeHouse(exchangeHouseSetupdto);
            return responseString;
        }
    }
}
