using System;

namespace Assignment2OOP2
{
    public class Flight
    {

        private string? flightCode;
        private string? airline;
        private string? origin;
        private string? destination;
        private string? dayOfWeek;
        private string? departureTime;
        private double seatsAvailable;
        private double cost;


        public string? FlightCode { get { return flightCode; } set { flightCode = value; } }
        public string? Airline { get { return airline; } set { airline = value; } }
        public string? Origin { get { return origin; } set { origin = value; } }
        public string? Destination { get { return destination; } set { destination = value; } }
        public string? DayOfWeek { get { return dayOfWeek; } set { dayOfWeek = value; } }
        public string? DepartureTime { get { return departureTime; } set { departureTime = value; } }
        public double SeatsAvailable { get { return seatsAvailable; } set { seatsAvailable = value; } }
        public double Cost { get { return cost; } set { cost = value; } }

        public Flight(string flightCode, string airline, string origin, string destination, string dayOfWeek, string departureTime, double seatsAvailable, double cost)
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
