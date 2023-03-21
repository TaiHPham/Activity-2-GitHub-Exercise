using System;
public class ParkingTicket
{
    private ParkedCar parkedCar;
    private PoliceOfficer officer;
    private int minutesOverParked;
    private decimal fineAmount;

    public ParkingTicket(ParkedCar parkedCar, PoliceOfficer officer, int minutesOverParked, decimal fineAmount)
    {
        this.parkedCar = parkedCar;
        this.officer = officer;
        this.minutesOverParked = minutesOverParked;
        this.fineAmount = fineAmount;
    }

    public override string ToString()
    {
        return $"--------------------------------------------\n" +
               $"Car: {parkedCar}\n" +
               $"Officer: {officer}\n" +
               $"Fine: ${fineAmount}\n" +
               $"Minutes over parked: {minutesOverParked}\n" +
               $"--------------------------------------------";
    }
}
