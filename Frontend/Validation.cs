using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Frontend
{
    static class Validation
    {
        static bool checkYear(int year)
        {
            if (Math.Floor(Math.Log10(year) + 1) != 4) return false;
            return true;
        }

        static bool checkHour(int hour)
        {
            if (hour > 23 || hour < 1) return false;
            return true;
        }

        static bool checkMin(int min)
        {
            if (min > 59 || min < 0) return false;
            return true;
        }

        static bool checkDay(int day)
        {
            if (day > 31 || day <= 0) return false;
            return true;
        }
        static bool checkMonth(int mouth)
        {
            if (mouth > 12 || mouth < 0) return false;
            return true;
        }
    }
}
