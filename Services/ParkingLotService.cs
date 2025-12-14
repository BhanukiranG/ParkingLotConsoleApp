using ParkingLotConsoleApp.Interfaces;
using ParkingLotConsoleApp.Models;
using ParkingLotConsoleApp.Utils;

namespace ParkingLotConsoleApp.Services;

/// <summary>
/// Provides core business logic for managing parking lot operations
/// such as slot initialization, vehicle parking, un-parking, and
/// occupancy tracking.
/// </summary>
public class ParkingLotService : IParkingLotService
{
    private readonly List<ParkingSlot> _slots = new();
    private readonly Dictionary<string, ParkingTicket> _activeTickets = new();

    /// <summary>
    /// Initializes the parking lot by creating parking slots
    /// for each supported vehicle type.
    /// </summary>
    /// <param name="twoWheelers">Number of two-wheeler parking slots.</param>
    /// <param name="fourWheelers">Number of four-wheeler parking slots.</param>
    /// <param name="heavy">Number of heavy vehicle parking slots.</param>
    public void Initialize(int twoWheelers, int fourWheelers, int heavy)
    {
        int slotNumber = 1;

        AddSlots(twoWheelers, VehicleType.TwoWheeler, ref slotNumber);
        AddSlots(fourWheelers, VehicleType.FourWheeler, ref slotNumber);
        AddSlots(heavy, VehicleType.Heavy, ref slotNumber);
    }

    /// <summary>
    /// Adds parking slots of a specific vehicle type to the parking lot.
    /// </summary>
    /// <param name="count">Number of slots to create.</param>
    /// <param name="type">Vehicle type allowed in the slots.</param>
    /// <param name="slotNumber">Reference to the running slot number.</param>
    private void AddSlots(int count, VehicleType type, ref int slotNumber)
    {
        for (int i = 0; i < count; i++)
        {
            _slots.Add(new ParkingSlot(slotNumber++, type));
        }
    }

    /// <summary>
    /// Parks a vehicle in an available slot matching its type
    /// and issues a parking ticket.
    /// </summary>
    /// <param name="vehicle">The vehicle to be parked.</param>
    /// <returns>
    /// A <see cref="ParkingTicket"/> if a slot is available;
    /// otherwise, <c>null</c>.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the vehicle is already parked.
    /// </exception>
    public ParkingTicket? ParkVehicle(IVehicle vehicle)
    {
        if (_activeTickets.ContainsKey(vehicle.VehicleNumber))
            throw new InvalidOperationException("Vehicle already parked");

        var slot = _slots.FirstOrDefault(s =>
            !s.IsOccupied && s.AllowedType == vehicle.Type);

        if (slot == null)
            return null;

        slot.Occupy();

        var ticket = new ParkingTicket(
            vehicle.VehicleNumber,
            slot.SlotNumber,
            DateTimeProvider.Now);

        _activeTickets[vehicle.VehicleNumber] = ticket;
        return ticket;
    }

    /// <summary>
    /// Un-parks a vehicle using its vehicle number, frees the
    /// associated parking slot, and closes the parking ticket.
    /// </summary>
    /// <param name="vehicleNumber">The unique vehicle registration number.</param>
    /// <exception cref="KeyNotFoundException">
    /// Thrown when no active ticket exists for the given vehicle.
    /// </exception>
    public void UnPark(string vehicleNumber)
    {
        if (!_activeTickets.TryGetValue(vehicleNumber, out var ticket))
            throw new KeyNotFoundException("Ticket not found");

        var slot = _slots.First(s => s.SlotNumber == ticket.SlotNumber);
        slot.Vacate();

        ticket.CloseTicket(DateTimeProvider.Now);
        _activeTickets.Remove(vehicleNumber);
    }

    /// <summary>
    /// Displays the current occupancy of the parking lot,
    /// grouped by vehicle type.
    /// </summary>
    public void ShowOccupancy()
    {
        Console.WriteLine("\nCurrent Occupancy:");

        foreach (VehicleType type in Enum.GetValues<VehicleType>())
        {
            var total = _slots.Count(s => s.AllowedType == type);
            var occupied = _slots.Count(s => s.AllowedType == type && s.IsOccupied);

            Console.WriteLine($"{type}: {occupied}/{total} occupied");
        }
    }

    /// <summary>
    /// Retrieves all active parking tickets for vehicles
    /// currently parked in the lot.
    /// </summary>
    /// <returns>
    /// A read-only collection of active <see cref="ParkingTicket"/> instances.
    /// </returns>
    public IReadOnlyCollection<ParkingTicket> GetActiveTickets()
    {
        return _activeTickets.Values.ToList().AsReadOnly();
    }
}