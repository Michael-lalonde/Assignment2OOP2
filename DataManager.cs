using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment2OOP2.Components.Pages;

namespace Assignment2OOP2
{
    public class DataManager
    {
        private List<Flight> flights = new List<Flight>();
        private List<Airport> airports = new List<Airport>();

        public DataManager()
        {
            Functionality.LoadFlights(flights);
            Functionality.LoadAirports(airports);
            Console.WriteLine($"Loaded {flights.Count} flights.");
        }

        public List<Flight> FindFlights(string from, string to, string day)
        {
            List<Flight> foundFlights = new List<Flight>();
            Console.WriteLine($"Looking for flights from {from} to {to} on {day}...");
            foreach (Flight flight in flights)
            {
                if (flight.Origin == from && flight.Destination == to && flight.DayOfWeek == day)
                {
                    foundFlights.Add(flight);
                }
            }
            Console.WriteLine($"Found {foundFlights.Count} flights.");
            return foundFlights;
        }
    }
}
