using Rent_Car_Api.DTOs.Brand;

namespace Rent_Car_Api.Managers.Brand
{
    public interface IBrandManager
    {

        Task<ManagerResult> AddAsync(CreateBrandDTO createBrandDTO);
        Task<ManagerResult> Updatesync(int id,CreateBrandDTO createBrandDTO);
    }
}
