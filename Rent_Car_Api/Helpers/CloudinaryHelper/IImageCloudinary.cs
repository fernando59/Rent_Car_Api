namespace Rent_Car_Api.Helpers.CloudinaryHelper
{
    public interface IImageCloudinary
    {

       Task<bool>  uploadImage(IFormFile image);
    }
}
