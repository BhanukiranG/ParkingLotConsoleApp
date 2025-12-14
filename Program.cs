using ParkingLotConsoleApp.Interfaces;
using ParkingLotConsoleApp.Models;
using ParkingLotConsoleApp.Services;
using ParkingLotConsoleApp.Utils;

ParkingLotService parkingLot = new();

Console.Clear();
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
    Console.Clear();
    ConsoleHelper.PrintHeader("Parking Lot Simulation");

    Console.WriteLine("1. Park Vehicle");
    Console.WriteLine("2. Un-Park Vehicle");
    Console.WriteLine("3. Show Occupancy");
    Console.WriteLine("0. Exit");
    Console.Write("\nChoice: ");

    var choice = Console.ReadLine();

    Console.Clear();
    ConsoleHelper.PrintHeader("Parking Lot Simulation");

    switch (choice)
    {
        case "1":
            Console.Write("Vehicle Number: ");
            var number = Console.ReadLine()!;

            Console.Write("Type (0=TwoWheeler, 1=FourWheeler, 2=Heavy): ");
            var type = (VehicleType)int.Parse(Console.ReadLine()!);

            var ticket = parkingLot.ParkVehicle(new Vehicle(number, type));

            if (ticket == null)
                Console.WriteLine("\n❌ No slot available");
            else
                Console.WriteLine($"\n✅ Parked at Slot {ticket.SlotNumber}\n🕒 In Time: {ticket.InTime}");

            Pause();
            break;

        case "2":
            var tickets = parkingLot.GetActiveTickets();

            if (!tickets.Any())
            {
                Console.WriteLine("\nNo vehicles parked");
                Pause();
                break;
            }

            Console.WriteLine("Parked Vehicles:\n");
            foreach (var t in tickets)
                Console.WriteLine($"Vehicle: {t.VehicleNumber} | Slot: {t.SlotNumber}");

            Console.Write("\nEnter Vehicle Number to Un-Park: ");
            parkingLot.UnPark(Console.ReadLine()!);

            Console.WriteLine("\n✅ Vehicle Un-Parked Successfully");
            Pause();
            break;

        case "3":
            parkingLot.ShowOccupancy();
            Pause();
            break;

        case "0":
            Environment.Exit(0);
            break;

        default:
            Console.WriteLine("\n❌ Invalid choice");
            Pause();
            break;
    }
}

static void Pause()
{
    Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey();
}