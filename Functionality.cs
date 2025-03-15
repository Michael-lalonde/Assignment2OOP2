using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment2OOP2
{
    public static class Functionality
    {
        public static void LoadFlights(List<Flight> flights)
        {
            string exeDir = AppDomain.CurrentDomain.BaseDirectory;
            string projectDir = Path.GetFullPath(Path.Combine(exeDir, "..", "..", ".."));
            // The file is in the same directory as the project, so we don't need extra folder traversal

            if (File.Exists(filePath))
            {
                foreach (string line in File.ReadLines(filePath))
                {
                    string[] items = line.Split(',');
                    Flight f = new Flight(
                        items[0], items[1], items[2], items[3],
                        items[4], items[5], double.Parse(items[6]), double.Parse(items[7])
                    );
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
                    airports.Add(new Airport(items[0], items[1]));
                }
            }
        }
    }
}
