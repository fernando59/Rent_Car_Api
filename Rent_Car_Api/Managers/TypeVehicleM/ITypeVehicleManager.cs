using EFDataAccess.Models;

namespace Rent_Car_Api.Managers.TypeVehicleM
{
    public interface ITypeVehicleManager
    {

        Task<ManagerResult<TypeVehicle>> GetAsync();
    }
}
