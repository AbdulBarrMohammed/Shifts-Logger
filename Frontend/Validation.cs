using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontend
{
    public class Validation
    {
        public bool checkYear(int year)
        {
            if (Math.Floor(Math.Log10(year) + 1) != 4)
            {
                return false;
            }
            return true;
        }
    }
}
