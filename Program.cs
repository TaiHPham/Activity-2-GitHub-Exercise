using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        Simulation parkingLot = new Simulation();
        parkingLot.Simulate(10);
    }
}
