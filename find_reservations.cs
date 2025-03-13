

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class ReservationManager
{
    private List<Reservation> Reservations = new List<Reservation>();
    private readonly string filePath = "reservations.bin"; 


    public void SaveReservations()
    {
        using (FileStream fs = new FileStream(filePath, FileMode.Create))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, Reservations);
        }
    }


    public void LoadReservations()
    {
        if (!File.Exists(filePath)) return; 

        using (FileStream fs = new FileStream(filePath, FileMode.Open))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            Reservations = (List<Reservation>)formatter.Deserialize(fs);
        }
    }


    public List<Reservation> FindReservations(string code = "", string airline = "", string name = "")
    {
        return Reservations.FindAll(r =>
            (string.IsNullOrEmpty(code) || r.ReservationCode.Equals(code, StringComparison.OrdinalIgnoreCase)) &&
            (string.IsNullOrEmpty(airline) || r.Flight.Airline.Contains(airline, StringComparison.OrdinalIgnoreCase)) &&
            (string.IsNullOrEmpty(name) || r.PassengerName.Contains(name, StringComparison.OrdinalIgnoreCase))
        );
    }
}
