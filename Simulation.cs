using System;
using System.Collections.Generic;
using System.Threading;

public class Simulation
{
    private int minute = 0;
    private int hour = 10;
    private int minutesElapsed = 0;

    public void advanceRound()
    {
        minutesElapsed += 10;
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
    }

    public string getTime()
    {
        string returnString;
        string minuteString;

        if (minute == 0)
            minuteString = "00";
        else
            minuteString = minute.ToString();

        if (hour == 0)
            returnString = "12:" + minuteString + " AM";
        else if (hour > 0 && hour < 12)
            returnString = hour.ToString() + ":" + minuteString + " AM";
        else if (hour == 12)
            returnString = hour.ToString() + ":" + minuteString + " PM";
        else
            returnString = (hour - 12).ToString() + ":" + minuteString + " PM";
        return returnString;
    }

    public void Simulate(int Rounds)
    {
        // Create a police officer
        PoliceOfficer officer = new PoliceOfficer("John Smith", "123456");

        int[] randParkedTime = new int[10];
        int[] randMeterTime = new int[10];
        Random rand = new Random();
        int randNum;

        // Simulate a random number of minutes parked
        for (int i = 0; i < randParkedTime.Length; i++)
        {
            randNum = rand.Next(1, 240);
            randParkedTime[i] = randNum;
        }

        ParkedCar car1 = new ParkedCar("Toyota", "Supra", "Black", "ABC123", randParkedTime[0]);
        ParkedCar car2 = new ParkedCar("Porsche", "911", "Silver", "DEF456", randParkedTime[1]);
        ParkedCar car3 = new ParkedCar("Honda", "Civic Type R", "White", "GHI789", randParkedTime[2]);
        ParkedCar car4 = new ParkedCar("Ford", "Mustang", "Black", "FGD793", randParkedTime[3]);
        ParkedCar car5 = new ParkedCar("Tesla", "Model S", "Gray", "DZF456", randParkedTime[4]);
        ParkedCar car6 = new ParkedCar("Nissian", "GTR", "Blue", "VBD583", randParkedTime[5]);
        ParkedCar car7 = new ParkedCar("Toyota", "86", "Black", "AHE345", randParkedTime[6]);
        ParkedCar car8 = new ParkedCar("Ford", "Mustang", "Silver", "RJK984", randParkedTime[7]);
        ParkedCar car9 = new ParkedCar("Dodge", "Challenger", "Yellow", "PRL483", randParkedTime[8]);
        ParkedCar car10 = new ParkedCar("Ferrari", "F8", "Red", "UIN659", randParkedTime[9]);

        // Simulate a random number of minutes purchased
        for (int i = 0; i < randMeterTime.Length; i++)
        {
            randNum = rand.Next(1, 240);
            randMeterTime[i] = randNum;
        }

        ParkingMeter meter1 = new ParkingMeter(randMeterTime[0]);
        ParkingMeter meter2 = new ParkingMeter(randMeterTime[1]);
        ParkingMeter meter3 = new ParkingMeter(randMeterTime[2]);
        ParkingMeter meter4 = new ParkingMeter(randMeterTime[3]);
        ParkingMeter meter5 = new ParkingMeter(randMeterTime[4]);
        ParkingMeter meter6 = new ParkingMeter(randMeterTime[5]);
        ParkingMeter meter7 = new ParkingMeter(randMeterTime[6]);
        ParkingMeter meter8 = new ParkingMeter(randMeterTime[7]);
        ParkingMeter meter9 = new ParkingMeter(randMeterTime[8]);
        ParkingMeter meter10 = new ParkingMeter(randMeterTime[9]);

        List<(ParkedCar, ParkingMeter)> parkingLot = new List<(ParkedCar, ParkingMeter)>
        {
            (car1, meter1),
            (car2, meter2),
            (car3, meter3),
            (car4, meter4),
            (car5, meter5),
            (car6, meter6),
            (car7, meter7),
            (car8, meter8),
            (car9, meter9),            
            (car10, meter10)
        };


        for (int i = 1; i <= Rounds; i++)
        {
            // Check one parking spot per round
            int spotToCheck = (i - 1) % parkingLot.Count;
            (ParkedCar car, ParkingMeter meter) = parkingLot[spotToCheck];

            Thread.Sleep(1000);
            Console.WriteLine("Time: " + getTime());
            Console.WriteLine($"Checking parking spot #{spotToCheck + 1}");

            // Check if the car has expired
            if (officer.CheckForViolation(car, meter))
            {
                // Issue a ticket
                ParkingTicket ticket = officer.IssueParkingTicket(car, meter);
                Console.WriteLine(ticket.ToString());
            }
            else
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("No violation detected");
                Console.WriteLine("--------------------------------------------");
            }
            advanceRound();
            Console.WriteLine();
        }
        Console.ReadLine();
    }
}