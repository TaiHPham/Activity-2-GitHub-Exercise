// This code defines a class called ParkingMeter
public class ParkingMeter
{
    public int minutesPurchased;

    // This is a constructor method that takes one parameter
    public ParkingMeter(int Minutes)
    {
        minutesPurchased = Minutes;
    }

    // This method returns the number of minutes purchased for parking
    public int GetMinutesPurchased()
    {
        return minutesPurchased;
    }
}

