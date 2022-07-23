using Rent_Car_Api.DTOs.Vehicle;

namespace Rent_Car_Api.Managers.Vehicle
{
    public interface IVehicleManager
    {

        Task<ManagerResult> AddAsync(CreateVehicleDTO createVehicleDTO);
    }
}
