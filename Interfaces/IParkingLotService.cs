using ParkingLotConsoleApp.Models;
using ParkingLotConsoleApp.Interfaces;


namespace ParkingLotConsoleApp.Interfaces;


public interface IParkingLotService
{
    void Initialize(int twoWheelers, int fourWheelers, int heavy);
    ParkingTicket? ParkVehicle(IVehicle vehicle);
    void UnPark(string vehicleNumber);
    void ShowOccupancy();
    IReadOnlyCollection<ParkingTicket> GetActiveTickets();
}