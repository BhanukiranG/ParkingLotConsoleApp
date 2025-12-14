using ParkingLotConsoleApp.Models;

namespace ParkingLotConsoleApp.Interfaces;

public interface IVehicle
{
    string VehicleNumber { get; }
    VehicleType Type { get; }
}