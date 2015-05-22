using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMS.BLL
{
    class General_Utilities
    {
        #region Added By Vivek On 22-05-2015 Amount To Word Funtions

        public static String amount_to_word(int number)
        {
            String finalstr = String.Empty;
            int reminder, pass = 1;

            if (number != 0)
            {
                while (number != 0)
                {
                    if (pass == 2)
                    {
                        reminder = number % 10;
                        number = number / 10;
                    }
                    else
                    {
                        reminder = number % 100;
                        number = number / 100;
                    }
                    if (reminder != 0)
                        finalstr = String.Concat(String.Concat(number_to_word(reminder), word(pass), finalstr));
                    pass++;
                }
            }
            else
                finalstr = "Zero ";
            return finalstr;
        }

        private static String number_to_word(int num)
        {
            String str1;
            switch (num)
            {
                case 1:
                    return "One ";
                case 2:
                    return "Two ";
                case 3:
                    return "Three ";
                case 4:
                    return "Four ";
                case 5:
                    return "Five ";
                case 6:
                    return "Six ";
                case 7:
                    return "Seven ";
                case 8:
                    return "Eight ";
                case 9:
                    return "Nine ";
                case 10:
                    return "Ten ";
                case 11:
                    return "Eleven ";
                case 12:
                    return "Twelve ";
                case 13:
                    return "Thirteen ";
                case 14:
                    return "Fourteen ";
                case 15:
                    return "Fifteen ";
                case 16:
                    return "Sixteen ";
                case 17:
                    return "Seventeen ";
                case 18:
                    return "Eighteen ";
                case 19:
                    return "Nineteen ";
                case 20:
                    return "Twenty ";
                case 30:
                    return "Thirty ";
                case 40:
                    return "Fourty ";
                case 50:
                    return "Fifty ";
                case 60:
                    return "Sixty ";
                case 70:
                    return "Seventy ";
                case 80:
                    return "Eighty ";
                case 90:
                    return "Ninety ";
                default:
                    {
                        if (num >= 20)
                        {
                            str1 = number_to_word((num / 10) * 10);
                            return String.Concat(str1, number_to_word(num % 10));
                        }
                        else
                            return String.Empty;
                    }
            }
        }

        private static String word(int pass)
        {
            switch (pass)
            {
                case 2:
                    return "Hundred ";
                case 3:
                    return "Thousand ";
                case 4:
                    return "Lacs ";
                case 5:
                    return "Crore ";
                case 6:
                    return "Billion ";
                default:
                    return String.Empty;
            }
        }

        public static bool IsValidNumber(string number)
        {
            if (number.Trim() == string.Empty)
                return false;
            char[] cr = number.ToCharArray();

            for (int i = 0; i < cr.Length; i++)
            {
                string sr = cr[i].ToString();
                if (!CheckValidNumberornot(sr))
                    return false;
            }

            return true;

        }

        private static bool CheckValidNumberornot(string value)
        {
            string[] no = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            bool result = false;

            for (int i = 0; i < no.Length; i++)
            {
                if (no[i].ToString().Contains(value))
                    return true;
            }

            return result;
        }

        #endregion
    }
}
