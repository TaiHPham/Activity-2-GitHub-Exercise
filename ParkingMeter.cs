using System;
public class ParkingMeter
{
    public int minutesPurchased;

    public ParkingMeter(int minutesPurchased)
    {
        this.minutesPurchased = minutesPurchased;
    }

    public int GetMinutesPurchased()
    {
        return minutesPurchased;
    }
}

