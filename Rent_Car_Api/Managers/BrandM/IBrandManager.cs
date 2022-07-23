using Rent_Car_Api.DTOs.Brand;
using EFDataAccess.Models;
namespace Rent_Car_Api.Managers.BrandM
{
    public interface IBrandManager
    {

        Task<ManagerResult<BrandVehicle>> AddAsync(CreateBrandDTO createBrandDTO);
        Task<ManagerResult<BrandVehicle>> Updatesync(int id,CreateBrandDTO createBrandDTO);
    }
}
