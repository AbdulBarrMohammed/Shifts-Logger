using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Frontend
{
    static class Validation
    {
        static public bool CheckYear(string year)
        {
            // Check if year is a number
            int number;
            if(!Int32.TryParse(year, out number))
            {
                return false;
            }

            // Check if length of number is 4
            if (Math.Floor(Math.Log10(number) + 1) != 4) return false;

            return true;
        }

        static bool CheckHour(int hour)
        {
            if (hour > 23 || hour < 1) return false;
            return true;
        }

        static bool CheckMin(int min)
        {
            if (min > 59 || min < 0) return false;
            return true;
        }

        static bool CheckDay(int day)
        {
            if (day > 31 || day <= 0) return false;
            return true;
        }
        static public bool CheckMonth(string month)
        {
            int number;
            if(!Int32.TryParse(month, out number))
            {
                return false;
            }

            if (number > 12 || number < 0) return false;
            return true;
        }
    }
}
