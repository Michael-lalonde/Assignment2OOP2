using System.Globalization;

namespace Assignment2OOP2
{
    public static class FlightManager
    {
        public static void LoadFlights(List<Flight> flights)
        {

            string exeDir = AppDomain.CurrentDomain.BaseDirectory;
            string projectDir = Path.GetFullPath(Path.Combine(exeDir, "..", "..", ".."));
            string filePath = Path.Combine(projectDir, "Resources", "Raw", "flights.csv");

            if (File.Exists(filePath))
            {
                foreach (string line in File.ReadLines(filePath))
                {
                    string[] items = line.Split(',');
                    string flightCode = items[0];
                    string airline = items[1];
                    string origin = items[2];
                    string destination = items[3];
                    string dayOfWeek = items[4];
                    string departureTime = items[5];
                    double seatsAvailable = double.Parse(items[6]);
                    double cost = double.Parse(items[7]);
                    Flight f = new Flight(flightCode, airline, origin, destination, dayOfWeek, departureTime, seatsAvailable, cost);
                    flights.Add(f);
                }
            }
        }
        public static void LoadAirports(List<Airport> airports)
        {
            string exeDir = AppDomain.CurrentDomain.BaseDirectory;
            string projectDir = Path.GetFullPath(Path.Combine(exeDir, "..", "..", ".."));
            string filePath = Path.Combine(projectDir, "Resources", "Raw", "airports.csv");

            if (File.Exists(filePath))
            {
                foreach (string line in File.ReadLines(filePath))
                {
                    string[] items = line.Split(",");
                    string code = items[0];
                    string name = items[1];
                    Airport a = new Airport(code, name);
                    airports.Add(a);
                }
            }
        }
    }
}