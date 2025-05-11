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

        static public bool CheckHour(string hour)
        {
            int number;
            if(!Int32.TryParse(hour, out number))
            {
                return false;
            }
            if (number > 23 || number < 1) return false;
            return true;
        }

        static public bool CheckMin(string min)
        {
            int number;
            if(!Int32.TryParse(min, out number))
            {
                return false;
            }
            if (number > 59 || number < 0) return false;
            return true;
        }

        static public bool CheckDay(string day)
        {
            int number;
            if(!Int32.TryParse(day, out number))
            {
                return false;
            }
            if (number > 31 || number <= 0) return false;
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
