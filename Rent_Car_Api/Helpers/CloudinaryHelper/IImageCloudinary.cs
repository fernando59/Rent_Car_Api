using EFDataAccess.Models;
using Rent_Car_Api.Managers;

namespace Rent_Car_Api.Helpers.CloudinaryHelper
{
    public interface IImageCloudinary
    {
        Task<string>  uploadImage(IFormFile image,string folder);
    }
}
