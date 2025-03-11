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

        private void LoadFlights()
        {
            var assembly = typeof(FlightManager).Assembly;
            var stream = assembly.GetManifestResourceStream("Assignment2OOP2.Resources.flights.csv");
            if (stream == null) return; 

            using var reader = new StreamReader(stream);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line)) continue;

                var parts = line.Split(',');
                if (parts.Length == 8)
                {
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
        }

        private void LoadAirports()
        {
            var assembly = typeof(FlightManager).Assembly;
            var stream = assembly.GetManifestResourceStream("Assignment2OOP2.Resources.airports.csv");
            if (stream == null) return; 

            using var reader = new StreamReader(stream);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line)) continue;

                var parts = line.Split(',');
                if (parts.Length == 2)
                {
                    Airports[parts[0]] = parts[1];
                }
            }
        }

        public List<Flight> FindFlights(string origin, string destination, string dayOfWeek)
        {
            return Flights
                .Where(f =>
                    (origin == "Any" || f.Origin == origin) &&
                    (destination == "Any" || f.Destination == destination) &&
                    (dayOfWeek == "Any" || f.DayOfWeek == dayOfWeek))
                .ToList();
        }

        public string GetAirportName(string code) => Airports.GetValueOrDefault(code, code);
    }
}

