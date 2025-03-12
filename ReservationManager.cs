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
            //Display reservation info
            
            Console.WriteLine("Please enter which you would like to edit (1 , 2, 3)");
            string selection = Console.ReadLine();

            foreach (Reservation reservation in reservations)
            {

                if (selection == "1")
                {
                    Console.WriteLine("Please enter new client name: ");
                    string newclientName = Console.ReadLine();

                }
            }
            
        }
    }
}
