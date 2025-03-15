using System;
using System.Collections.Generic;
using System.IO;

namespace Assignment2OOP2
{
    public static class Functionality
    {
        public static void LoadFlights(List<Flight> flights)
        {
            // Get the current directory (this assumes the .csv is in the root folder)
            string exeDir = AppDomain.CurrentDomain.BaseDirectory;

            // The file is in the same directory as the project, so we don't need extra folder traversal
            string filePath = Path.Combine(exeDir, "flights.csv");

            // Check if the file exists at the given path
            if (File.Exists(filePath))
            {
                // Read the file line by line
                foreach (string line in File.ReadLines(filePath))
                {
                    // Split the line by commas and parse the flight data
                    string[] items = line.Split(',');
                    Flight f = new Flight(
                        items[0], items[1], items[2], items[3],
                        items[4], items[5], double.Parse(items[6]), double.Parse(items[7])
                    );

                    // Add the flight object to the flights list
                    flights.Add(f);
                }
            }
            else
            {
                // Log if the file doesn't exist
                Console.WriteLine("The flights.csv file was not found.");
            }
        }


        public static void LoadAirports(List<Airport> airports)
        {
            string exeDir = AppDomain.CurrentDomain.BaseDirectory;
            string projectDir = Path.GetFullPath(Path.Combine(exeDir, "..", "..", ".."));
            string filePath = Path.Combine(projectDir, "Resources", "Raw", "airports.csv");

            Console.WriteLine($"Loading airports from: {filePath}");

            if (File.Exists(filePath))
            {
                foreach (string line in File.ReadLines(filePath))
                {
                    string[] items = line.Split(",");
                    airports.Add(new Airport(items[0], items[1]));
                    Console.WriteLine($"Loaded airport: {items[0]}");  // Debugging line
                }
            }
            else
            {
                Console.WriteLine("Airports file not found.");
            }
        }
    }
}
