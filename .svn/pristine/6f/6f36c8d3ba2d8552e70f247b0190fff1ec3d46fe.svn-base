using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using MISL.Ababil.Agent.Infrastructure.Models.common;

namespace MISL.Ababil.Agent.Infrastructure.Models.common
{
    public class Utility
    {
        const string Format = "##,##,###.00";
        const string MergeDelimiter = " - ";

        //public static Decimal getBigDecimalFromString(String val)
        //{
            //locale in_ID = new Locale("en", "US");

            //DecimalFormat nf = (DecimalFormat)NumberFormat.getInstance(in_ID);
            //nf.setParseBigDecimal(true);

            //BigDecimal bd = (BigDecimal)nf.parse(val, new ParsePosition(0));
            //return bd;
        //}
        
        
        public static string FetchAccountNameFromNumber(string accountNumber)
        {
            if (accountNumber == "0" || accountNumber.Trim().Length < 1) return "";



            return "Mock Customer";
        }

        public static void DisplayAccountName(string accountName, TextBox accountNumberTextBox, Label accountNameLabel)
        {
            if (accountName.Length > 0)
            {
                accountNameLabel.Text = accountName;
                accountNumberTextBox.ForeColor = Color.Black;
            }
            else
            {
                accountNameLabel.Text = "";
                accountNumberTextBox.ForeColor = Color.Red;
            }
        }

        public static void HandleAccountNumberTextLeave(string accountTitle, TextBox accountNumberTextBox, Label accountNameLabel)
        {
            Utility.DisplayAccountName(accountTitle, accountNumberTextBox, accountNameLabel);
        }
        public static bool EnterPressed(KeyPressEventArgs e)
        {
            return e.KeyChar == (char)13;
        }

        public static string GetCurrencyFormatted(decimal toFormat)
        {
            return toFormat.ToString(Format, CultureInfo.CurrentCulture);
        }

        public static string MergeLookup(string descriptive, decimal minAmount, decimal maxAmount, string riskLevel, int riskRating)
        {
            return descriptive + MergeDelimiter + Utility.GetCurrencyFormatted(minAmount) + MergeDelimiter +
                   Utility.GetCurrencyFormatted(maxAmount) + MergeDelimiter + riskLevel + MergeDelimiter + riskRating;
        }


        public static string MergeLookup(string descriptive, int minNumber, int maxNumber, string riskLevel, int riskRating)
        {
            return descriptive + MergeDelimiter + minNumber + MergeDelimiter + maxNumber + MergeDelimiter + riskLevel + MergeDelimiter + riskRating;
        }

        public static string MergeLookup(string descriptive, string riskLevel, int riskRating)
        {
            return descriptive + MergeDelimiter + riskLevel + MergeDelimiter + riskRating;
        }

        public static DateTime FromUnixTime(long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddMilliseconds((double) unixTime);
        }
    }
}
