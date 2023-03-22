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

class Program
{
    static void Main(string[] args)
    {
        Simulation parkingLot = new Simulation();
        parkingLot.Simulate(10);
        Console.ReadLine();
    }
}
