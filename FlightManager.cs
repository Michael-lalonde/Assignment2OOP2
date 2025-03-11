using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Globalization;

namespace Assignment2OOP2
{
    public class FlightManager
    {
        public List<Flight> Flights { get; private set; } = new();
        public Dictionary<string, string> Airports { get; private set; } = new();

        public FlightManager()
        {
            LoadFlights();
            LoadAirports();
        }

        // Load flights from CSV
        private void LoadFlights()
        {
            var assembly = typeof(FlightManager).Assembly;
            using var stream = assembly.GetManifestResourceStream("MauiApp2.Resources.Raw.flights.csv");
            
            using var reader = new StreamReader(stream!);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var parts = line!.Split(',');
                Flights.Add(new Flight
                {
                    FlightCode = parts[0],
                    Airline = parts[1],
                    Origin = parts[2],
                    Destination = parts[3],
                    DayOfWeek = parts[4],
                    DepartureTime = parts[5],
                    SeatsAvailable = int.Parse(parts[6]),
                    Cost = decimal.Parse(parts[7], CultureInfo.InvariantCulture)
                });
            }
        }

        // Load airports from CSV
        private void LoadAirports()
        {
            var assembly = typeof(FlightManager).Assembly;
            using var stream = assembly.GetManifestResourceStream("MauiApp2.Resources.Raw.airports.csv");
            
            using var reader = new StreamReader(stream!);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var parts = line!.Split(',');
                Airports[parts[0]] = parts[1]; // Code -> Name
            }
        }

        // Find flights with filters
        public List<Flight> FindFlights(string origin, string destination, string dayOfWeek)
        {
            return Flights
                .Where(f =>
                    (origin == "Any" || f.Origin == origin) &&
                    (destination == "Any" || f.Destination == destination) &&
                    (dayOfWeek == "Any" || f.DayOfWeek == dayOfWeek))
                .ToList();
        }

        // Get airport name from code
        public string GetAirportName(string code) => Airports.GetValueOrDefault(code, code);
    }
}