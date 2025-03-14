using System;
using System.Collections.Generic;

namespace Assignment2OOP2
{
    public class DaysOfWeek
    {
        public List<string> Days { get; private set; }

        public DaysOfWeek()
        {
            Days = new List<string>
            {
                "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"
            };
        }

        public void PrintDays()
        {
            foreach (var day in Days)
            {
                Console.WriteLine(day);
            }
        }
    }
}