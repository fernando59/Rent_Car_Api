using EFDataAccess.Models;
using Rent_Car_Api.DTOs.Image;
using Rent_Car_Api.DTOs.Vehicle;

namespace Rent_Car_Api.Managers.PhotoM
{
    public interface IPhotoManager
    {
        Task<ManagerResult<PhotosVehicle>> GetAsync(int id);
        Task<ManagerResult<PhotosVehicle>> AddAsync(CreateImageDTO createImageDTO);
    }
}
