using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Authentication.ExtendedProtection;
using System.Threading.Tasks;
using Frontend.obj.Model;
using Spectre.Console;

namespace Frontend
{
    public class UserInteface
    {
        public string GetName()
        {
            Console.WriteLine("Enter your name: \n");
            var name = Console.ReadKey().ToString();
            return name;
        }

        public int GetMin()
        {
            Console.WriteLine("Enter the minutes: \n");
            var minutes = Console.ReadKey().ToString();
            while (!Validation.CheckMin(minutes))
            {
                Console.WriteLine("Day is not in correct format");
                Console.WriteLine("Enter the month: ");
                minutes = Console.ReadKey().ToString();
            }

            return Int32.Parse(minutes);

        }

        public int GetHour()
        {
            Console.WriteLine("Enter the hour: ");
            var hour = Console.ReadKey().ToString();
            while (!Validation.CheckHour(hour))
            {
                Console.WriteLine("Day is not in correct format");
                Console.WriteLine("Enter the month: ");
                hour = Console.ReadKey().ToString();
            }

            return Int32.Parse(hour);
        }

        public int GetDay()
        {
            Console.WriteLine("Enter the day : ");
            var day = Console.ReadKey().ToString();
            while (!Validation.CheckDay(day))
            {
                Console.WriteLine("Day is not in correct format");
                Console.WriteLine("Enter the month: ");
                day = Console.ReadKey().ToString();
            }
            return Int32.Parse(day);

        }

        public int GetMonth()
        {
            Console.WriteLine("Enter the month: ");
            string month = Console.ReadKey().ToString();
            while (!Validation.CheckMonth(month))
            {
                Console.WriteLine("Month is not in correct format");
                Console.WriteLine("Enter the month: ");
                month = Console.ReadKey().ToString();
            }
            return Int32.Parse(month);

        }

        public int GetYear()
        {
            Console.WriteLine("Enter the year: ");
            string year = Console.ReadKey().ToString();
            while (!Validation.CheckYear(year))
            {
                Console.WriteLine("Year is not in correct format");
                Console.WriteLine("Enter the year: ");
                year = Console.ReadKey().ToString();
            }

            return Int32.Parse(year);
        }
        public int CalculateDuration(DateTime start, DateTime end)
        {
            TimeSpan span = end.Subtract ( start );
            return (int)span.TotalHours;
        }

        public Shift CreateNewShift()
        {
            Console.WriteLine("Start Time:");
            var startYear = GetYear();
            var startDay = GetDay();
            var startMonth = GetMonth();
            var startHour = GetHour();
            var startMin = GetMin();
            //new DateTime(year, month, day, hour, minute, second)
            DateTime startDate = new DateTime(startYear, startMonth, startDay, startHour, startMin, 0);


            Console.WriteLine("End Time");
            var endYear = GetYear();
            var endDay = GetDay();
            var endMonth = GetMonth();
            var endHour = GetHour();
            var endMin = GetMin();
            //new DateTime(year, month, day, hour, minute, second)
            DateTime endDate = new DateTime(endYear, endMonth, endDay, endHour, endMin, 0);

            int duration = CalculateDuration(startDate, endDate);

            string name = GetName();
            return new Shift(duration, startDate, endDate, name);

        }
    }
}
