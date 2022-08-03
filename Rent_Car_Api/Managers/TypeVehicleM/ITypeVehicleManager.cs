using EFDataAccess.Models;
using Rent_Car_Api.DTOs.TypeVehicle;

namespace Rent_Car_Api.Managers.TypeVehicleM
{
    public interface ITypeVehicleManager
    {

        Task<ManagerResult<TypeVehicle>> GetAsync();
        Task<ManagerResult<TypeVehicle>> AddAsync(CreateTypeVehicleDTO createTypeVehicleDTO);
        Task<ManagerResult<TypeVehicle>> UpdateAsync(int id, CreateTypeVehicleDTO createTypeVehicleDTO);
        Task<ManagerResult<TypeVehicle>> DeleteAsync(int id);
    }
}
