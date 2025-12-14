using ParkingLotConsoleApp.Models;

namespace ParkingLotConsoleApp.Interfaces;

/// <summary>
/// Represents a vehicle that can be parked in the parking lot.
/// </summary>
public interface IVehicle
{
    /// <summary>
    /// Gets the unique registration number of the vehicle.
    /// </summary>
    string VehicleNumber { get; }

    /// <summary>
    /// Gets the type of the vehicle, which determines
    /// the category of parking slot it can occupy.
    /// </summary>
    VehicleType Type { get; }
}