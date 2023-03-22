using System;

// This code defines a class called ParkingTicket
public class ParkingTicket
{
    // This is a constructor method that takes four parameters
    public ParkingTicket(ParkedCar parkedCar, int MinutesOver, string copName, int copBadge)
    {
        decimal fine = 25m + .16m * MinutesOver;
        string Output = parkedCar.GetCarInfo() + "\nMinutes Over: " + MinutesOver + "\nFine: $" + fine.ToString() + "\nOfficer: " + copName + ", Badge# " + copBadge;
        Console.WriteLine(Output);
    }
}
