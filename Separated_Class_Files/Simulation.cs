using System;
using System.Collections.Generic;
using System.Threading;

public class Simulation
{
    private ParkedCar car1;
    private ParkedCar car2;
    private ParkedCar car3;
    private ParkedCar car4;
    private ParkedCar car5;
    private ParkedCar car6;
    private ParkedCar car7;
    private ParkedCar car8;
    private ParkedCar car9;
    private ParkedCar car10;

    private ParkingMeter meter1;
    private ParkingMeter meter2;
    private ParkingMeter meter3;
    private ParkingMeter meter4;
    private ParkingMeter meter5;
    private ParkingMeter meter6;
    private ParkingMeter meter7;
    private ParkingMeter meter8;
    private ParkingMeter meter9;
    private ParkingMeter meter10;

    private PoliceOfficer officer;

    private int hour;
    private int minute;
    private int minutesElapsed;
    private int officerLocation;

    public Simulation()
    {
        minute = 0;
        hour = 10; //cop starts his day at 10am
        minutesElapsed = 0;
        officerLocation = 0;

        // Create a police officer
        officer = new PoliceOfficer("John Smith", 123456);

        car1 = new ParkedCar("Chevrolet", "Sonic", "Silver", "WB8RDN");
        car2 = new ParkedCar("Toyota", "Corolla", "White", "NATY769");
        car3 = new ParkedCar("Honda", "Civic", "Black", "HGJEK87");
        car4 = new ParkedCar("Mini", "Cooper", "Blue", "MYMINI1");
        car5 = new ParkedCar("Ford", "F350", "Orange", "PWNLIBS");
        car6 = new ParkedCar("Subaru", "Forester", "White", "PIEJ888");
        car7 = new ParkedCar("Jeep", "Wrangler", "Gray", "WXYZ72S");
        car8 = new ParkedCar("Nissan", "Rogue", "Green", "HS667ZV");
        car9 = new ParkedCar("Tesla", "Model S", "Red", "LUV_ELON");
        car10 = new ParkedCar("GMC", "Sierra", "Silver", "KD4SRW");

        meter1 = new ParkingMeter(30);
        meter2 = new ParkingMeter(0);
        meter3 = new ParkingMeter(45);
        meter4 = new ParkingMeter(60);
        meter5 = new ParkingMeter(0);
        meter6 = new ParkingMeter(180);
        meter7 = new ParkingMeter(120);
        meter8 = new ParkingMeter(60);
        meter9 = new ParkingMeter(0);
        meter10 = new ParkingMeter(90);
    }

/*
* Advances the simulation to the next round, which is 10 minutes later.
* If the current time is 50 minutes past the hour, it rolls over to the
* next hour. The officer also moves to the next parking spot.
*/
    public void advanceRound()
    {
        // Increment minutes elapsed
        minutesElapsed += 10;

        // Check if the minute is 50. If so, reset the minute and increment the hour
        if (minute == 50)
        {
            minute = 0;
            if (hour == 24)
                hour = 0;
            else
                hour += 1;
        }
        else
            minute += 10;

        // Assuming there are 10 parking spots, move the officer to the next spot
        if (officerLocation == 9)
            officerLocation = 0;
        else
            officerLocation++;
    }

    // This method returns the current time in a formatted string.
    public string getTime()
    {
        string returnString;
        string minuteString;

        // Format the minute as a string with leading 0 if necessary
        if (minute == 0)
            minuteString = "00";
        else
            minuteString = minute.ToString();

        // Format the hour as a string with AM/PM designation
        if (hour == 0)
            returnString = "12:" + minuteString + " AM";
        else if (hour > 0 && hour < 12)
            returnString = hour.ToString() + ":" + minuteString + " AM";
        else if (hour == 12)
            returnString = hour.ToString() + ":" + minuteString + " PM";
        else
            returnString = (hour - 12).ToString() + ":" + minuteString + " PM";

        // Return the formatted time string.
        return returnString;
    }

    // This method simulates the specified number of rounds of the parking lot scenario
    public void Simulate(int Rounds)
    {
        List<ParkedCar> Cars = new List<ParkedCar>() { car1, car2, car3, car4, car5, car6, car7, car8, car9, car10 };
        List<ParkingMeter> Meters = new List<ParkingMeter>() { meter1, meter2, meter3, meter4, meter5, meter6, meter7, meter8, meter9, meter10 };

        while (Rounds > 0)
        {
            // Decrement rounds, pause for 1.5 seconds, and output the current time
            --Rounds;
            Thread.Sleep(1000);
            Console.WriteLine("Time: " + getTime());

            // Check the current parking spot for violations.
            Console.WriteLine("Inspecting Spot #" + (officerLocation + 1).ToString());
            if (officer.CheckForViolation(Cars[officerLocation], Meters[officerLocation]) == true)
            {
                // If a violation is detected, issue a parking ticket
                Console.WriteLine("Issuing Citation\n----------------");
                officer.IssueParkingTicket(Cars[officerLocation], Meters[officerLocation]);
                Console.WriteLine("\n\n");
            }
            else
            {
                // If no violation is detected, output a message
                Console.WriteLine("No violation detected.\n\n");
            }

            // Advance the simulation by one round and add 10 minutes to each parked car's time
            advanceRound();
            foreach (ParkedCar car in Cars)
                car.AddParkedMinutes(10);

        }
    }
}
