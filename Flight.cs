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
        public double SeatsAvailable { get; set; }
        public double Cost { get; set; }

        public Flight(string? flightCode, string? airline, string? origin, string? destination, string? dayOfWeek, string? departureTime, double seatsAvailable, double cost)
        {
            FlightCode = flightCode;
            Airline = airline;
            Origin = origin;
            Destination = destination;
            DayOfWeek = dayOfWeek;
            DepartureTime = departureTime;
            SeatsAvailable = seatsAvailable;
            Cost = cost;
        }
    }
}