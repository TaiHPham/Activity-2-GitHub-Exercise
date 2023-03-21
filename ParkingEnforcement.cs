/*
 * Parking Violations Simulator
 * 
 * This program simulates a police officer checking for parking violations in a parking lot.
 * The program creates 10 parked cars, each with their own parking meter. The officer checks
 * each parking spot and issues citations to cars that have expired meters.
 * 
 * Author: [Your Name]
 * Date: [Current Date]
 */

using System;
using System.Threading;
using System.Collections.Generic;

namespace ParkingViolations
{
    class Simulation
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

        private PoliceOfficer cop;

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

            // Initialize parked cars and their meters
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

            cop = new PoliceOfficer("John Friendly", 42050);
        }
        
          /*
         * Advances the simulation to the next round, which is 10 minutes later.
         * If the current time is 50 minutes past the hour, it rolls over to the
         * next hour. The officer also moves to the next parking spot.
         */
        
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

            //Assuming 10 parking spots
            if (officerLocation == 9)
                officerLocation = 0;
            else
                officerLocation++;
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
            List<ParkedCar> Cars = new List<ParkedCar>() { car1, car2, car3, car4, car5, car6, car7, car8, car9, car10 };
            List<ParkingMeter> Meters = new List<ParkingMeter>() { meter1, meter2, meter3, meter4, meter5, meter6, meter7, meter8, meter9, meter10 };

            while (Rounds > 0)
            {
                --Rounds;
                Thread.Sleep(1500);
                Console.WriteLine("Time: " + getTime());
                Console.WriteLine("Inspecting Spot #" + (officerLocation +1).ToString());
                if(cop.CheckForViolation(Cars[officerLocation], Meters[officerLocation]) == true)
                {
                    Console.WriteLine("Issuing Citation\n----------------");
                    cop.IssueParkingTicket(Cars[officerLocation], Meters[officerLocation]);
                    Console.WriteLine("\n\n");
                }
                else
                {
                    Console.WriteLine("No violation detected.\n\n");
                }

                advanceRound();
                foreach (ParkedCar car in Cars)
                    car.AddParkedMinutes(10);
                

            }
        }
    }

    class ParkedCar
    {
        private string make;
        private string model;
        private string color;
        private string licenseNumber;
        private int timeParked;
        private bool ticketed;
        public ParkedCar(string Make, string Model, string Color, string License)
        {
            make = Make;
            model = Model;
            color = Color;
            licenseNumber = License;
            timeParked = 0;
            ticketed = false;
        }
        public int GetParkedMinutes()
        {
            return timeParked;
        }
        public void AddParkedMinutes(int Minutes)
        {
            timeParked += Minutes;
        }
        public bool GetTicketed()
        {
            return ticketed;
        }
        public string GetCarInfo()
        {
            ticketed = true;
            return "Make: " + make + " | Model: " + model + " | Color: " + color + " | Plate: " + licenseNumber;

        }

    }

    class ParkingMeter
    {
        private int minutesPurchased;
        public ParkingMeter(int Minutes)
        {
            minutesPurchased = Minutes;
        }
        public int readMeter()
        {
            return minutesPurchased;
        }
    }

    class ParkingTicket
    {
        public ParkingTicket(ParkedCar Car, int MinutesOver, string copName, int copBadge)
        {
            decimal fine = 25m + .16m * MinutesOver;
            string Output = Car.GetCarInfo() + "\nMinutes Over: " + MinutesOver + "\nFine: $" + fine.ToString() + "\nOfficer: " + copName + ", Badge# " + copBadge;
            Console.WriteLine(Output);
        }

    }

    class PoliceOfficer
    {
        private string name;
        private int badgeNumber;
        public PoliceOfficer(string Name, int BadgeNumber)
        {
            name = Name;
            badgeNumber = BadgeNumber;
        }
        public string GetCopInfo()
        {
            return "Officer: " + name + " | Badge# " + badgeNumber;
        }
        public bool CheckForViolation(ParkedCar Car, ParkingMeter Meter)
        {
            if (Meter.readMeter() < Car.GetParkedMinutes() && !Car.GetTicketed())
                return true;
            else
                return false;
        }
        public void IssueParkingTicket(ParkedCar Car, ParkingMeter Meter)
        {
            int MinutesOver = Car.GetParkedMinutes() - Meter.readMeter();
            ParkingTicket ticket = new ParkingTicket(Car, MinutesOver, name, badgeNumber);
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            Simulation parkingLot = new Simulation();
            parkingLot.Simulate(10);
        }
    }
}
