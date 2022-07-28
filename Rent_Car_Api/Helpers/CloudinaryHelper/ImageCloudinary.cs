using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace Rent_Car_Api.Helpers.CloudinaryHelper
{
    public class ImageCloudinary : IImageCloudinary
    {
        private readonly IConfiguration _configuration;

        public ImageCloudinary(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<bool> uploadImage(IFormFile image)
        {
            try
            {

                Account account = new Account(_configuration["CLOUDINARY_NAME"], _configuration["CLOUDINARY_KEY"], _configuration["CLOUDINARY_SECRET"]);
                Cloudinary cloudinary = new Cloudinary(account);

                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(image.FileName, image.OpenReadStream()),
                    UseFilename = true,
                    UniqueFilename = false,
                    Overwrite = true,

                };
                var uploadsult = cloudinary.Upload(uploadParams);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
