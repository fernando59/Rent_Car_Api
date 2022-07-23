using EFDataAccess.Models;
using Rent_Car_Api.DTOs.Vehicle;

namespace Rent_Car_Api.Managers.VehicleM;

public interface IVehicleManager
{

    Task<ManagerResult<Vehicle>> AddAsync(CreateVehicleDTO createVehicleDTO);
    Task<ManagerResult<Vehicle>> GetAsync();
}
