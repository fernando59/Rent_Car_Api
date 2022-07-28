using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using EFDataAccess.Models;
using Rent_Car_Api.DTOs.Image;
using Rent_Car_Api.Helpers.CloudinaryHelper;

namespace Rent_Car_Api.Managers.PhotoM
{
    public class PhotoManager : IPhotoManager
    {
        private readonly IImageCloudinary _imageCloudinary;

        public PhotoManager(IImageCloudinary imageCloudinary)
        {
            _imageCloudinary = imageCloudinary;
        }
        public async Task<ManagerResult<PhotosVehicle>> AddAsync(CreateImageDTO createImageDTO)
        {

            var managerResult = new ManagerResult<PhotosVehicle>();
            try
            {
                await _imageCloudinary.uploadImage(createImageDTO.fileImage);
                
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
    }
}
