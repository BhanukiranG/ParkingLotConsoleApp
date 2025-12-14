namespace ParkingLotConsoleApp.Models;

/// <summary>
/// Represents the supported categories of vehicles
/// that can be parked in the parking lot.
/// </summary>
public enum VehicleType
{
    /// <summary>
    /// A two-wheeled vehicle such as a bike or scooter.
    /// </summary>
    TwoWheeler,

    /// <summary>
    /// A four-wheeled vehicle such as a car or SUV.
    /// </summary>
    FourWheeler,

    /// <summary>
    /// A heavy vehicle such as a truck or bus.
    /// </summary>
    Heavy
}