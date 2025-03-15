using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment2OOP2
{
    public class ReservationManager
    {
        private List<Reservation> reservations = new List<Reservation>();
        private static readonly Random random = new Random();
        private static readonly string FILE_NAME = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "reservations.csv");

        public ReservationManager()
        {
            LoadReservations();
        }

       
        public string GenerateReservationCode()
        {
            char letter = (char)random.Next('A', 'Z' + 1);
            int digits = random.Next(1000, 9999);
            return $"{letter}{digits:D4}";
        }

        
        public Reservation MakeReservation(string flightCode, string airlineName, double cost, string passengerName, string citizenship)
        {
            if (string.IsNullOrWhiteSpace(flightCode))
                throw new ArgumentException("Flight code cannot be empty.");
            if (string.IsNullOrWhiteSpace(airlineName))
                throw new ArgumentException("Airline name cannot be empty.");
            if (cost <= 0)
                throw new ArgumentException("Cost must be greater than zero.");
            if (string.IsNullOrWhiteSpace(passengerName))
                throw new ArgumentException("Passenger name cannot be empty.");
            if (string.IsNullOrWhiteSpace(citizenship))
                throw new ArgumentException("Citizenship cannot be empty.");

            string reservationCode = GenerateReservationCode();

            var reservation = new Reservation(
                reservationCode,
                flightCode,
                airlineName,
                cost,
                passengerName,
                citizenship,
                true 
            );

            reservations.Add(reservation);
            Persist(); 

            return reservation;
        }

        
        public List<Reservation> FindReservations(string code, string airline, string name)
        {
            return reservations
                .Where(r =>
                    (string.IsNullOrEmpty(code) || r.ReservationCode.Contains(code, StringComparison.OrdinalIgnoreCase)) &&
                    (string.IsNullOrEmpty(airline) || r.AirlineName.Contains(airline, StringComparison.OrdinalIgnoreCase)) &&
                    (string.IsNullOrEmpty(name) || r.PassengerName.Contains(name, StringComparison.OrdinalIgnoreCase)))
                .ToList();
        }

        // Update Reservation
        public void UpdateReservation(string reservationCode, string passengerName, string citizenship, bool status)
        {
            var reservation = reservations.FirstOrDefault(r => r.ReservationCode == reservationCode);

            if (reservation == null)
                throw new InvalidOperationException("Reservation not found.");

            if (string.IsNullOrWhiteSpace(passengerName))
                throw new ArgumentException("Passenger name cannot be empty.");
            if (string.IsNullOrWhiteSpace(citizenship))
                throw new ArgumentException("Citizenship cannot be empty.");

            reservation.PassengerName = passengerName;
            reservation.Citizenship = citizenship;
            reservation.Status = status;

            Persist(); // Save changes to file
        }

        // Delete Reservation (Soft Delete)
        public void DeleteReservation(string reservationCode)
        {
            var reservation = reservations.FirstOrDefault(r => r.ReservationCode == reservationCode);

            if (reservation == null)
                throw new InvalidOperationException("Reservation not found.");

            reservation.Status = false; 
            Persist();
        }

       
        private void Persist()
        {
            // Ensure Resources directory exists
            string directory = Path.GetDirectoryName(FILE_NAME);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            using (StreamWriter writer = new StreamWriter(FILE_NAME))
            {
                writer.WriteLine("ReservationCode,FlightCode,AirlineName,Cost,PassengerName,Citizenship,Status");

                foreach (var reservation in reservations)
                {
                    writer.WriteLine($"\"{reservation.ReservationCode}\"," +
                                     $"\"{reservation.FlightCode}\"," +
                                     $"\"{reservation.AirlineName}\"," +
                                     $"{reservation.Cost}," +
                                     $"\"{reservation.PassengerName}\"," +
                                     $"\"{reservation.Citizenship}\"," +
                                     $"{reservation.Status}");
                }
            }
        }

        // Load Reservations from CSV File
        private void LoadReservations()
        {
            if (!File.Exists(FILE_NAME))
                return;

            using (StreamReader reader = new StreamReader(FILE_NAME))
            {
                reader.ReadLine(); // Skip header row

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    string[] fields = line.Split(',');

                    string reservationCode = fields[0].Trim('"');
                    string flightCode = fields[1].Trim('"');
                    string airlineName = fields[2].Trim('"');
                    double cost = double.Parse(fields[3]);
                    string passengerName = fields[4].Trim('"');
                    string citizenship = fields[5].Trim('"');
                    bool status = bool.Parse(fields[6]);

                    var reservation = new Reservation(
                        reservationCode,
                        flightCode,
                        airlineName,
                        cost,
                        passengerName,
                        citizenship,
                        status
                    );

                    reservations.Add(reservation);
                }
            }
        }
    }
}
