namespace ParkingLotConsoleApp.Models;

/// <summary>
/// Represents a single parking slot in the parking lot.
/// </summary>
/// <param name="slotNumber">
/// The unique identifier assigned to the parking slot.
/// </param>
/// <param name="type">
/// The vehicle type that is allowed to occupy this parking slot.
/// </param>
public class ParkingSlot(int slotNumber, VehicleType type)
{
    /// <summary>
    /// Gets the unique number of the parking slot.
    /// </summary>
    public int SlotNumber { get; } = slotNumber;

    /// <summary>
    /// Gets the vehicle type that is allowed to occupy this slot.
    /// </summary>
    public VehicleType AllowedType { get; } = type;

    /// <summary>
    /// Indicates whether the parking slot is currently occupied.
    /// </summary>
    public bool IsOccupied { get; private set; }

    /// <summary>
    /// Marks the parking slot as occupied.
    /// </summary>
    public void Occupy() => IsOccupied = true;

    /// <summary>
    /// Marks the parking slot as available.
    /// </summary>
    public void Vacate() => IsOccupied = false;
}