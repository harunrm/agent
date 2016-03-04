using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MISL.Ababil.Agent.Services
{
    public class AmountInWords
    {
        public string ToWords(string number)
        {
            string tmpStr = "";
            try
            {
                number = number.Replace(",", "");
                string str = number;
                string b4Dec = "";
                string afDec = "";

                int retVal = str.IndexOf(".", 0);
                if (retVal > 0)
                {
                    string[] strDecSplit = str.Split('.');

                    b4Dec = NumberToWords(long.Parse(strDecSplit[0]));
                    //_______________________By Digits________________________//
                    //                                                        //
                    //   afDec = inWords.NumberToWordsDec(strDecSplit[1]);    //
                    //________________________________________________________//
                    long afDecNum = long.Parse(strDecSplit[1]);
                    if (afDecNum.ToString().Length == 1)
                    {
                        //afDecNum *= 10;
                    }
                    afDec = NumberToWords(afDecNum);
                    if (afDec != null)
                    {
                        str = b4Dec + " Taka And " + afDec + " Paisa";
                    }
                    else
                    {
                        str = b4Dec;
                    }
                    tmpStr = str;
                }
                else
                {
                    tmpStr = NumberToWords(long.Parse(number));
                }
            }
            catch (Exception)
            {
                tmpStr = "";
            }

            return tmpStr;
        }

        public string NumberToWords(long number)
        {
            if (number == 0)
                return "Zero";

            if (number < 0)
                return ("Minus " + NumberToWords(Math.Abs(number))).ToUpper();

            string words = "";

            if ((number / 10000000) > 0)
            {
                words += NumberToWords(number / 10000000) + " Core ";
                number %= 10000000;
            }

            if ((number / 100000) > 0)
            {
                words += NumberToWords(number / 100000) + " Lakh ";
                number %= 100000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " Thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " Hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += " ";

                var unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                var tensMap = new[] { "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }

        public string NumberToWordsDec(string number)
        {
            string words = "";

            number = Reverse(number);
            long tmp = long.Parse(number);
            number = Reverse(tmp.ToString());
            if (number == "0")
            {
                return null;
            }

            var unitsMap = new[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };

            for (int i = 0; i < number.Length; i++)
            {
                words += unitsMap[int.Parse(number[i].ToString())] + " ";
            }

            return words.Trim();
        }

        public string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}