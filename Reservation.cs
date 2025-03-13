using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2OOP2
{
    public class Reservation
    {
        public string ReservationCode { get; set; }
        public string FlightCode { get; set; }
        public string AirlineName { get; set; }
        public double Cost { get; set; }
        public string PassengerName { get; set; }
        public string Citizenship { get; set; }
        public string Status { get; set; }

        public Reservation(string ReservationCode, string FlightCode, string AirlineName, double Cost, string PassengerName, string Citizenship, string Status)
        {
            this.ReservationCode = ReservationCode;
            this.FlightCode = FlightCode;
            this.AirlineName = AirlineName;
            this.Cost = Cost;
            this.PassengerName = PassengerName;
            this.Citizenship = Citizenship;
            this.Status = Status;
        }
        public override string ToString()
        {
            return $"1. Reservation Code: {ReservationCode}\n" +
                   $"2. Flight Code: {FlightCode}\n" +
                   $"3. Airline Name: {AirlineName}\n" +
                   $"4. Cost: {Cost}\n" +
                   $"5. Client Name: {PassengerName}\n" +
                   $"6. Citizenship: {Citizenship}\n" +
                   $"7. Status: {Status}";
        }
    }
}