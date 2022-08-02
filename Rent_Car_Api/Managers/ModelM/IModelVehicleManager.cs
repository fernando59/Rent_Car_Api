using EFDataAccess.Models;
using Rent_Car_Api.DTOs.Model;

namespace Rent_Car_Api.Managers.ModelM
{
    public interface IModelVehicleManager
    {
        Task<ManagerResult<ModelVehicle>> GetAsync();
        Task<ManagerResult<ModelVehicle>> AddAsync(CreateModelDTO createModelDTO);
        Task<ManagerResult<ModelVehicle>> UpdateAsync(int id, CreateModelDTO createModelDTO);
        Task<ManagerResult<ModelVehicle>> DeleteAsync(int id);

    }
}
