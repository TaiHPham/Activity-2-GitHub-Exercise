// This code defines a class called ParkedCar
public class ParkedCar
{
    // Private fields for make, model, color, license number, and time parked
    private string make;
    private string model;
    private string color;
    private string licenseNumber;
    private int timeParked;
    private bool ticketed;

    // This is a constructor method that takes four parameters
    public ParkedCar(string Make, string Model, string Color, string License)
    {
        make = Make;
        model = Model;
        color = Color;
        licenseNumber = License;
        timeParked = 0;
        ticketed = false;
    }

    // This method returns the number of minutes that the car has been parked
    public int GetParkedMinutes()
    {
        return timeParked;
    }

    // This method adds the specified number of minutes to the time parked
    public void AddParkedMinutes(int Minutes)
    {
        timeParked += Minutes;
    }

    // This method returns the ticketed status of the parked car
    public bool GetTicketed()
    {
        return ticketed;
    }

    // This method returns a string containing the make, model, color, and license number of the parked car, and sets the ticketed status to true
    public string GetCarInfo()
    {
        ticketed = true;
        return $"{make} {model} ({color}) - {licenseNumber}";
    }
}
