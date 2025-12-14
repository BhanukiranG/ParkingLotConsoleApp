using ParkingLotConsoleApp.Models;

namespace ParkingLotConsoleApp.Interfaces;

/// <summary>
/// Defines operations for managing a parking lot, including
/// initialization, vehicle parking, un-parking, and occupancy tracking.
/// </summary>
public interface IParkingLotService
{
    /// <summary>
    /// Initializes the parking lot with a fixed number of slots
    /// for each supported vehicle type.
    /// </summary>
    /// <param name="twoWheelers">Number of two-wheeler parking slots.</param>
    /// <param name="fourWheelers">Number of four-wheeler parking slots.</param>
    /// <param name="heavy">Number of heavy vehicle parking slots.</param>
    void Initialize(int twoWheelers, int fourWheelers, int heavy);

    /// <summary>
    /// Parks a vehicle in an available slot that matches its type
    /// and issues a parking ticket.
    /// </summary>
    /// <param name="vehicle">The vehicle to be parked.</param>
    /// <returns>
    /// A <see cref="ParkingTicket"/> if a suitable slot is available;
    /// otherwise, <c>null</c>.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the vehicle is already parked.
    /// </exception>
    ParkingTicket? ParkVehicle(IVehicle vehicle);

    /// <summary>
    /// Un-parks a vehicle using its vehicle number, frees the
    /// associated parking slot, and closes the parking ticket.
    /// </summary>
    /// <param name="vehicleNumber">The unique vehicle number.</param>
    /// <exception cref="KeyNotFoundException">
    /// Thrown when no active ticket is found for the given vehicle number.
    /// </exception>
    void UnPark(string vehicleNumber);

    /// <summary>
    /// Displays the current occupancy status of the parking lot,
    /// grouped by vehicle type.
    /// </summary>
    void ShowOccupancy();

    /// <summary>
    /// Retrieves all currently active parking tickets.
    /// </summary>
    /// <returns>
    /// A read-only collection of active <see cref="ParkingTicket"/> instances.
    /// </returns>
    IReadOnlyCollection<ParkingTicket> GetActiveTickets();
}