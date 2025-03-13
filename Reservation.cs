using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2OOP2
{
    public class Reservation
    {
        private string ReservationCode { get; set; }
        private string FlightCode { get; set; }
        private string AirlineName { get; set; }
        private double Cost { get; set; }
        private string Name { get; set; }
        private string Citizenship { get; set; }
        private string Status { get; set; }

        public Reservation(string ReservationCode, string FlightCode, string AirlineName, double Cost, string Name, string Citizenship, string Status)
        {
            this.ReservationCode = ReservationCode;
            this.FlightCode = FlightCode;
            this.AirlineName = AirlineName;
            this.Cost = Cost;
            this.Name = Name;
            this.Citizenship = Citizenship;
            this.Status = Status;
        }
        public override string ToString()
        {
            return $"1. Reservation Code: {ReservationCode}\n" +
                   $"2. Flight Code: {FlightCode}\n" +
                   $"3. Airline Name: {AirlineName}\n" +
                   $"4. Cost: {Cost}\n" +
                   $"5. Client Name: {Name}\n" +
                   $"6. Citizenship: {Citizenship}\n" +
                   $"7. Status: {Status}";
        }
    }
}