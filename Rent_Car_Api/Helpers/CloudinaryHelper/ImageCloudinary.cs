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
        public async Task<string> uploadImage(IFormFile image,string folder)
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
                    Folder=folder,
                    Overwrite = true,

                };
                var uploadResult = cloudinary.Upload(uploadParams);
                return uploadResult.PublicId;
            }
            catch (Exception e)
            {
                return "";
            }
        }
    }
}
