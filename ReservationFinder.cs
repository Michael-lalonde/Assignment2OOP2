using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using Assignment2OOP2;


public class ReservationFinder
{
    private List<Reservation> Reservations = new List<Reservation>();
    private readonly string filePath = "reservations.bin";

    public void SaveReservations()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(Reservations, options);
        File.WriteAllText(filePath, jsonString);
    }

    public void LoadReservations()
    {
        if (!File.Exists(filePath)) return;

        string jsonString = File.ReadAllText(filePath);
        Reservations = JsonSerializer.Deserialize<List<Reservation>>(jsonString) ?? new List<Reservation>();
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
