namespace ParkingLotConsoleApp.Models;


public class ParkingTicket
{
    public string VehicleNumber { get; }
    public int SlotNumber { get; }
    public DateTime InTime { get; }
    public DateTime? OutTime { get; private set; }


    public ParkingTicket(string vehicleNumber, int slotNumber, DateTime inTime)
    {
        VehicleNumber = vehicleNumber;
        SlotNumber = slotNumber;
        InTime = inTime;
    }


    public void CloseTicket(DateTime outTime)
    {
        OutTime = outTime;
    }
}