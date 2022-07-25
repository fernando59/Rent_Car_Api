using EFDataAccess.Models;

namespace Rent_Car_Api.Managers.ModelM
{
    public interface IModelVehicleManager
    {
        //Task<ManagerResult<ModelVehicle>> AddAsync(CreateVehicleDTO createVehicleDTO);
        Task<ManagerResult<ModelVehicle>> GetAsync();

    }
}
