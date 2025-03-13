using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2OOP2
{
    public class Reservation
    {
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