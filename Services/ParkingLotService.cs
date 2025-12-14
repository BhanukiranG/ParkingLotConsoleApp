using ParkingLotConsoleApp.Interfaces;
using ParkingLotConsoleApp.Models;
using ParkingLotConsoleApp.Utils;


namespace ParkingLotConsoleApp.Services;


public class ParkingLotService : IParkingLotService
{
    private readonly List<ParkingSlot> _slots = new();
    private readonly Dictionary<string, ParkingTicket> _activeTickets = new();


    public void Initialize(int twoWheelers, int fourWheelers, int heavy)
    {
        int slotNumber = 1;


        AddSlots(twoWheelers, VehicleType.TwoWheeler, ref slotNumber);
        AddSlots(fourWheelers, VehicleType.FourWheeler, ref slotNumber);
        AddSlots(heavy, VehicleType.Heavy, ref slotNumber);
    }


    private void AddSlots(int count, VehicleType type, ref int slotNumber)
    {
        for (int i = 0; i < count; i++)
            _slots.Add(new ParkingSlot(slotNumber++, type));
    }


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


    public void UnPark(string vehicleNumber)
    {
        if (!_activeTickets.TryGetValue(vehicleNumber, out var ticket))
            throw new KeyNotFoundException("Ticket not found");


        var slot = _slots.First(s => s.SlotNumber == ticket.SlotNumber);
        slot.Vacate();
        ticket.CloseTicket(DateTimeProvider.Now);
        _activeTickets.Remove(vehicleNumber);
    }


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

    public IReadOnlyCollection<ParkingTicket> GetActiveTickets()
    {
        return _activeTickets.Values.ToList().AsReadOnly();
    }
}