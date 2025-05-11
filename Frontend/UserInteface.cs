using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spectre.Console;

namespace Frontend
{
    public class UserInteface
    {
        public void GetStartTime()
        {

        }

        public void GetEndTime()
        {

            Console.WriteLine("Enter the year: ");
            string year = Console.ReadKey().ToString();
            while (!Validation.CheckYear(year))
            {
                Console.WriteLine("Year is not in correct format");
                Console.WriteLine("Enter the year: ");
                year = Console.ReadKey().ToString();
            }

            Console.WriteLine("Enter the month: ");
            string month = Console.ReadKey().ToString();
            while (!Validation.CheckMonth(month))
            {
                Console.WriteLine("Month is not in correct format");
                Console.WriteLine("Enter the month: ");
                month = Console.ReadKey().ToString();
            }

            Console.WriteLine("Enter the day : ");
            var day = Console.ReadKey().ToString();
            while (!Validation.CheckDay(day))
            {
                Console.WriteLine("Day is not in correct format");
                Console.WriteLine("Enter the month: ");
                day = Console.ReadKey().ToString();
            }

            Console.WriteLine("Enter the hour: ");
            var hour = Console.ReadKey().ToString();
            while (!Validation.CheckHour(hour))
            {
                Console.WriteLine("Day is not in correct format");
                Console.WriteLine("Enter the month: ");
                hour = Console.ReadKey().ToString();
            }


            Console.WriteLine("Enter the minutes: ");
            var minutes = Console.ReadKey().ToString();
            while (!Validation.CheckMin(minutes))
            {
                Console.WriteLine("Day is not in correct format");
                Console.WriteLine("Enter the month: ");
                minutes = Console.ReadKey().ToString();
            }


        }
        public int calculateDuration(DateTime start, DateTime end)
        {
            TimeSpan span = end.Subtract ( start );
            return (int)span.TotalHours;
        }
    }
}
