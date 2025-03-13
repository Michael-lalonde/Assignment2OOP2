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
    }

}
        public string reservationCode { get; set; }
        public object ReservationCode { get; internal set; }
        public double flightCode { get; set; }
        public string airlineName { get; set; }
        public double Cost { get; set; }
        public string Name { get; set; }
        public string Citizenship { get; set; }
        public string Status { get; set; }


        public string ToString()
        {
            return $"1. Reservation Code: {reservationCode}" +
                   $"2. Flight Code: {flightCode}" +
                   $"3. Airline Name: {airlineName}" +
                   $"4. Cost: {Cost}" +
                   $"5. Client Name: {Name}" +
                   $"6. Citizenship {Citizenship}" +
                   $"7. Status: {Status}";
        }
    }   
}