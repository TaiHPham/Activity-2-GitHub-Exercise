using System;
public class PoliceOfficer
{
    // Attributes
    private string name;
    private string badgeNumber;

    // Constructor
    public PoliceOfficer(string name, string badgeNumber)
    {
        this.name = name;
        this.badgeNumber = badgeNumber;
    }

    public override string ToString()
    {
        return $"{name} - Badge #: {badgeNumber}";
    }

    public bool CheckForViolation(ParkedCar parkedCar, ParkingMeter parkingMeter)
    {
        int parkedMinutes = parkedCar.GetParkedMinutes();
        int purchasedMinutes = parkingMeter.GetMinutesPurchased();

        return parkedMinutes > purchasedMinutes;
    }

    public ParkingTicket IssueParkingTicket(ParkedCar parkedCar, ParkingMeter parkingMeter)
    {
        int parkedMinutes = parkedCar.GetParkedMinutes();
        int purchasedMinutes = parkingMeter.GetMinutesPurchased();

        int minutesOverParked = parkedMinutes - purchasedMinutes;
        decimal fineAmount = 25m + minutesOverParked * 0.16m;

        ParkingTicket ticket = new ParkingTicket(parkedCar, this, minutesOverParked, fineAmount);
        
        return ticket;
    }
}

