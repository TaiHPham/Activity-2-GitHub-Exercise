using System;
public class ParkingMeter
{
    private int minutesPurchased;
    private DateTime startTime;
    private const int RATE_PER_MINUTE = 2;

    // Constructor
    public ParkingMeter(int minutes)
    {
        minutesPurchased = minutes;
        startTime = DateTime.Now;
    }

    // Getter for minutesPurchased
    public int GetMinutesPurchased()
    {
        return minutesPurchased;
    }

    // Add time to the parking meter
    public void AddPurchaseTime(int minutes)
    {
        minutesPurchased += minutes;
    }

    // Check if the parking meter has expired
    public bool TimeExpired()
    {
        DateTime expirationTime = startTime.AddMinutes(minutesPurchased);
        return DateTime.Now >= expirationTime;
    }

    // Calculate the parking fee
    public decimal CalculateFee()
    {
        TimeSpan timeParked = DateTime.Now - startTime;
        int minutesParked = (int)timeParked.TotalMinutes;
        int extraMinutes = minutesParked - minutesPurchased;
        if (extraMinutes > 0)
        {
            return RATE_PER_MINUTE * extraMinutes;
        }
        else
        {
            return 0;
        }
    }
}
