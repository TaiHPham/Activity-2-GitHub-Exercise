
// This code defines a class called PoliceOfficer
public class PoliceOfficer
{
    private string name;
    private int badgeNumber;

    // This is a constructor method that takes two parameters
    public PoliceOfficer(string Name, int BadgeNumber)
    {
        name = Name;
        badgeNumber = BadgeNumber;
    }

    // This method overrides the ToString() method and returns a string representation of the PoliceOfficer object
    public override string ToString()
    {
        return $"{name} - Badge #: {badgeNumber}";
    }

    // This method checks for a violation given a ParkedCar and ParkingMeter object
    public bool CheckForViolation(ParkedCar parkedCar, ParkingMeter parkingMeter)
    {
        if (parkingMeter.GetMinutesPurchased() < parkedCar.GetParkedMinutes() && !parkedCar.GetTicketed())
            return true;
        else
            return false;
    }

    // This method issues a ParkingTicket given a ParkedCar and ParkingMeter object
    public ParkingTicket IssueParkingTicket(ParkedCar parkedCar, ParkingMeter parkingMeter)
    {
        int MinutesOver = parkedCar.GetParkedMinutes() - parkingMeter.GetMinutesPurchased();
        ParkingTicket ticket = new ParkingTicket(parkedCar, MinutesOver, name, badgeNumber);

        return ticket;
    }
}

