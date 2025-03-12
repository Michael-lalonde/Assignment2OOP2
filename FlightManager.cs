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
            var resourceName = "Assignment2OOP2.Resources.flights.csv"; // Match your namespace

            using var stream = assembly.GetManifestResourceStream(resourceName);
            if (stream == null)
            {
                throw new FileNotFoundException($"Resource '{resourceName}' not found.");
            }

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
            var resourceName = "Assignment2OOP2.Resources.airports.csv"; // Match your namespace

            using var stream = assembly.GetManifestResourceStream(resourceName);
            if (stream == null)
            {
                throw new FileNotFoundException($"Resource '{resourceName}' not found.");
            }

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

        
    }
}