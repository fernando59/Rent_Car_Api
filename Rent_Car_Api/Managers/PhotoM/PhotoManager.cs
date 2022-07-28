using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using EFDataAccess;
using EFDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Rent_Car_Api.DTOs.Image;
using Rent_Car_Api.Helpers.CloudinaryHelper;

namespace Rent_Car_Api.Managers.PhotoM
{
    public class PhotoManager : IPhotoManager
    {
        private readonly IImageCloudinary _imageCloudinary;
        private readonly ApplicationDbContext _context;

        public PhotoManager(IImageCloudinary imageCloudinary, ApplicationDbContext context)
        {
            _imageCloudinary = imageCloudinary;
            _context = context;
        }
        public async Task<ManagerResult<PhotosVehicle>> AddAsync(CreateImageDTO createImageDTO)
        {

            var managerResult = new ManagerResult<PhotosVehicle>();
            try
            {
                var path = $"Vehicle_{createImageDTO.vehicleId}/{createImageDTO.fileImage.FileName}" ;
                var folder = $"Vehicle_{createImageDTO.vehicleId}/";
                var res = await _imageCloudinary.uploadImage(createImageDTO.fileImage,folder);
                if(res.Length == 0)
                {
                    managerResult.Success = false;
                    return managerResult;
                }
                PhotosVehicle photoVehicle = new PhotosVehicle();
                photoVehicle.path =res;
                photoVehicle.VehicleId =  Convert.ToInt32(createImageDTO.vehicleId)
                    ;
                await _context.PhotosVehicles.AddAsync(photoVehicle);
                await _context.SaveChangesAsync();

                managerResult.Success = true;
                managerResult.Message = "Successfully Add";
                return managerResult;

            }
            catch(Exception e)
            {
                managerResult.Success = false;
                managerResult.Message = e.Message;
                return managerResult;
            }
        }

        public async Task<ManagerResult<PhotosVehicle>> GetAsync(int id)
        {
            var managerResult = new ManagerResult<PhotosVehicle>();
            var photos = await _context.PhotosVehicles.Where(v => v.VehicleId == id).ToListAsync();
            managerResult.Data = photos;
            return managerResult;
        }
    }
}
