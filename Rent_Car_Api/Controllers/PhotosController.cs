using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Rent_Car_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {

        [HttpPost]
        // [Authorize(Roles = UserRols.Admin)]

        public async Task<IActionResult> UploadImage()
        {
            Cloudinary cloudinary = new Cloudinary(Environment.GetEnvironmentVariable("CLOUDINARY_URL"));
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(@"https://cloudinary-devs.github.io/cld-docs-assets/assets/images/cld-sample.jpg"),
                UseFilename = true,
                UniqueFilename = false,
                Overwrite = true
            };
            var uploadResult = cloudinary.Upload(uploadParams);

            return Ok();
        }

    }
}
