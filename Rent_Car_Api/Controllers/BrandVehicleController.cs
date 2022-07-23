using EFDataAccess;
using EFDataAccess.ClassesAux;
using EFDataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rent_Car_Api.DTOs.Brand;
using Rent_Car_Api.Managers;
using Rent_Car_Api.Managers.BrandM;

namespace Rent_Car_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandVehicleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IBrandManager brandManager;

        public BrandVehicleController(ApplicationDbContext context, IBrandManager brandManager)
        {
            _context = context;
            this.brandManager = brandManager;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BrandVehicle>>> GetModelVehicles()
        {
            var brandVehicles = await _context.BrandVehicle.ToListAsync();
            return brandVehicles;
        }

        [HttpPost]
       // [Authorize(Roles = UserRols.Admin)]
        
        public async Task<IActionResult> CreateModel(CreateBrandDTO createBrandDTO)
        {
            ManagerResult<BrandVehicle> managerResult = await brandManager.AddAsync(createBrandDTO);

            if(!managerResult.Success)
            {
                return BadRequest(managerResult);
            }

            return Ok();
        }

        [HttpPut("{id}")]
        //[Authorize(Roles = UserRols.Admin)]
        public async Task<IActionResult> UpdateModel(int id, CreateBrandDTO createBrandDTO)
        {
            ManagerResult<BrandVehicle> managerResult = await brandManager.Updatesync(id,createBrandDTO);
           
            if (!managerResult.Success)
            {
                return BadRequest(managerResult);
            }

            return Ok(managerResult);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            var brand = await _context.BrandVehicle.Where(t => t.Id == id).FirstOrDefaultAsync();

            if (brand == null)  return NotFound(new { Ok = false, Message = "Brand not found" }); 

            _context.BrandVehicle.Remove(brand);
            await _context.SaveChangesAsync();
            return Ok(new { Ok = true, Message = "Delete successfully" });

        }

    }
}
