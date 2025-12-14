using ParkingLotConsoleApp.Interfaces;


namespace ParkingLotConsoleApp.Models;


public class Vehicle : IVehicle
{
    public string VehicleNumber { get; }
    public VehicleType Type { get; }


    public Vehicle(string vehicleNumber, VehicleType type)
    {
        VehicleNumber = vehicleNumber;
        Type = type;
    }
}