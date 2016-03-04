using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Services
{
    public class CommonRules
    {
        public static int mobileNoLength = 11;
        public static int nomineeMaxRatio = 100;
        public static long countryId = 19;  //index in country combobox
        public static int cisType_institute = 3;
        public static string homeCountryCode = "BD";
        public static int accountNumberDigitCount = 13;
        public static long imageSizeLimit = Convert.ToInt32(ConfigurationManager.AppSettings["imageSize"]) * 1000; //in bytes
        public static long pdfSizeLimit = Convert.ToInt32(ConfigurationManager.AppSettings["pdfSize"]) * 1000; //in bytes
        public static int agentBankDivisionId = Convert.ToInt32(ConfigurationManager.AppSettings["branchId"]); //990
    }
}
