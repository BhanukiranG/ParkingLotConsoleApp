namespace ParkingLotConsoleApp.Models;

/// <summary>
/// Represents a parking transaction record for a parked vehicle.
/// Contains information about which vehicle is parked, where, and when.
/// </summary>
/// <remarks>
/// Initializes a new instance of the ParkingTicket class.
/// </remarks>
/// <param name="vehicleNumber">The vehicle's unique identifier</param>
/// <param name="slotNumber">The parking slot assigned to this vehicle</param>
/// <param name="inTime">The entry timestamp</param>
public class ParkingTicket(string vehicleNumber, int slotNumber, DateTime inTime)
{
    /// <summary>
    /// Gets the vehicle identifier associated with this parking record.
    /// </summary>
    public string VehicleNumber { get; } = vehicleNumber;

    /// <summary>
    /// Gets the parking slot number assigned to this vehicle.
    /// </summary>
    public int SlotNumber { get; } = slotNumber;

    /// <summary>
    /// Gets the date and time when the vehicle was parked (entry time).
    /// </summary>
    public DateTime InTime { get; } = inTime;

    /// <summary>
    /// Gets the date and time when the vehicle was un-parked (exit time).
    /// Returns null if the vehicle is still parked.
    /// </summary>
    public DateTime? OutTime { get; private set; }

    /// <summary>
    /// Closes the parking ticket by recording the exit time.
    /// This method should be called when the vehicle is un-parked.
    /// </summary>
    /// <param name="outTime">The exit timestamp</param>
    public void CloseTicket(DateTime outTime)
    {
        OutTime = outTime;
    }
}