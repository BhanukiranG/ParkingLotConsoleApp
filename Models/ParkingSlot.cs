namespace ParkingLotConsoleApp.Models;

public class ParkingSlot
{
    public int SlotNumber { get; }
    public VehicleType AllowedType { get; }
    public bool IsOccupied { get; private set; }


    public ParkingSlot(int slotNumber, VehicleType type)
    {
        SlotNumber = slotNumber;
        AllowedType = type;
    }


    public void Occupy() => IsOccupied = true;
    public void Vacate() => IsOccupied = false;
}