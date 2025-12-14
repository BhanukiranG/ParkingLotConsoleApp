using ParkingLotConsoleApp.Interfaces;
using ParkingLotConsoleApp.Models;
using ParkingLotConsoleApp.Services;
using ParkingLotConsoleApp.Utils;

IParkingLotService parkingLot = new ParkingLotService();

ConsoleHelper.PrintHeader("Parking Lot Simulation");

Console.Write("Enter 2-Wheeler slots: ");
int m = int.Parse(Console.ReadLine()!);

Console.Write("Enter 4-Wheeler slots: ");
int n = int.Parse(Console.ReadLine()!);

Console.Write("Enter Heavy Vehicle slots: ");
int o = int.Parse(Console.ReadLine()!);

parkingLot.Initialize(m, n, o);

while (true)
{
    Console.WriteLine("\n1. Park Vehicle");
    Console.WriteLine("2. Un-Park Vehicle");
    Console.WriteLine("3. Show Occupancy");
    Console.WriteLine("0. Exit");
    Console.Write("Choice: ");

    var choice = Console.ReadLine();

    switch (choice)
    {
        case "0":
            Environment.Exit(0);
            break;

        case "1":
            Console.Write("Vehicle Number: ");
            var number = Console.ReadLine()!;

            Console.Write("Type (0=TwoWheeler, 1=FourWheeler, 2=Heavy): ");
            var type = (VehicleType)int.Parse(Console.ReadLine()!);

            var ticket = parkingLot.ParkVehicle(new Vehicle(number, type));

            if (ticket == null)
                Console.WriteLine("No slot available");
            else
                Console.WriteLine($"Parked at Slot {ticket.SlotNumber} at {ticket.InTime}");
            break;

        case "2":
            Console.Write("Vehicle Number: ");
            parkingLot.UnPark(Console.ReadLine()!);
            Console.WriteLine("Vehicle Un-Parked Successfully");
            break;

        case "3":
            parkingLot.ShowOccupancy();
            break;

        default:
            Console.WriteLine("Invalid choice");
            break;
    }
}