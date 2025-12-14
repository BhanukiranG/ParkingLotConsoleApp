using ParkingLotConsoleApp.Interfaces;

namespace ParkingLotConsoleApp.Models;

/// <summary>
/// Represents a vehicle that can be parked in the parking lot.
/// </summary>
/// <param name="vehicleNumber">
/// The unique registration number of the vehicle.
/// </param>
/// <param name="type">
/// The type of the vehicle, which determines the category of parking slot it can occupy.
/// </param>
public class Vehicle(string vehicleNumber, VehicleType type) : IVehicle
{
    /// <summary>
    /// Gets the unique registration number of the vehicle.
    /// </summary>
    public string VehicleNumber { get; } = vehicleNumber;

    /// <summary>
    /// Gets the type of the vehicle.
    /// </summary>
    public VehicleType Type { get; } = type;
}