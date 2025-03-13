using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2OOP2
{
    public class ReservationManager
    {
        public List<Reservation> Reservations = new List<Reservation>();

        public void ModifyReservation(List<Reservation> reservations)
        {
            reservations.ToString();
            Console.WriteLine("Please enter which you would like to edit (5 , 6, or 7)");
            string selection = Console.ReadLine();

            foreach (Reservation reservation in reservations)
            {
                if (selection == "5")
                {
                    Console.WriteLine("Please enter new client name: ");
                    string newClientName = Console.ReadLine();
                    reservation.PassengerName = newClientName;
                }
                else if (selection == "6")
                {
                    Console.WriteLine("Please enter new client citizenship: ");
                    string newClientCitizenship = Console.ReadLine();
                    reservation.Citizenship = newClientCitizenship;
                }
                else if (selection == "7")
                {
                    Console.WriteLine("Please enter new client status: ");
                    string newClientStatus = Console.ReadLine();
                    reservation.Status = newClientStatus;
                }
            }
        }
    }
}
