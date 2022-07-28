using EFDataAccess.Models;
using Rent_Car_Api.DTOs.Vehicle;

namespace Rent_Car_Api.Managers.VehicleM;

public interface IVehicleManager
{

    Task<ManagerResult<Vehicle>> AddAsync(CreateVehicleDTO createVehicleDTO);
    Task<ManagerResult<Vehicle>> GetAsync();
    Task<ManagerResult<Vehicle>> GetAsyncById(int id);
    Task<ManagerResult<Vehicle>> GetAsyncFilter(int page,int brandId, int typeVehicleId, int modelId, int quantity);
    Task<ManagerResult<Vehicle>> UpdateAsync(int id,UpdateVehicleDTO updateVehicleDTO);
    Task<ManagerResult<Vehicle>> DeleteAsync(int id);
}
