using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment2OOP2
{
    public class DataManager
    {
        private List<Flight> _flights;

        public DataManager()
        {
            _flights = new List<Flight>();
            Functionality.LoadFlights(_flights); 
        }

        public List<Flight> FindFlights(string from, string to, string day)
        {
            return _flights.Where(f =>
                (string.IsNullOrEmpty(from) || f.Origin.Contains(from, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(to) || f.Destination.Contains(to, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(day) || f.DayOfWeek.Contains(day, StringComparison.OrdinalIgnoreCase))
            ).ToList();
        }
    }
}
