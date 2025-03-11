using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2OOP2
{
    public class Flight
    {
        public string? FlightCode { get; set; }
        public string? Airline { get; set; }
        public string? Origin { get; set; }
        public string? Destination { get; set; }
        public string? DayOfWeek { get; set; }
        public string? DepartureTime { get; set; }
        public int SeatsAvailable { get; set; }
        public decimal Cost { get; set; }
    }
}