using System;
public class ParkedCar
{
    private string make;
    private string model;
    private string color;
    private string licenseNumber;
    public int minutesParked;

    public ParkedCar(string make, string model, string color, string licenseNumber, int minutesParked)
    {
        this.make = make;
        this.model = model;
        this.color = color;
        this.licenseNumber = licenseNumber;
        this.minutesParked = minutesParked;
    }
    public override string ToString()
    {
        return $"{make} {model} ({color}) - {licenseNumber} - {minutesParked} minutes parked";
    }

    public int GetParkedMinutes()
    {
        return minutesParked;
    }
}
