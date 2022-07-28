using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using EFDataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rent_Car_Api.DTOs.Image;
using Rent_Car_Api.Managers;
using Rent_Car_Api.Managers.PhotoM;

namespace Rent_Car_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {

        // [Authorize(Roles = UserRols.Admin)]
        private readonly IPhotoManager _photoManager;
        public PhotosController(IPhotoManager photoManager)
        {
            _photoManager = photoManager;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetPhotosByVehicle(int id)
        {
            var res = await _photoManager.GetAsync(id);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage([FromForm] CreateImageDTO createImageDTO)
        {

            ManagerResult<PhotosVehicle> managerResult = await _photoManager.AddAsync(createImageDTO);

            if (!managerResult.Success)
            {
                return BadRequest(managerResult);
            }

            return Ok(managerResult);
        }

    }
}
