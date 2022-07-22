using EFDataAccess;
using EFDataAccess.ClassesAux;
using EFDataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rent_Car_Api.DTOs.Brand;

namespace Rent_Car_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandVehicleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;


        public BrandVehicleController(ApplicationDbContext context)
        {
            _context = context;

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BrandVehicle>>> GetModelVehicles()
        {
            var brandVehicles = await _context.BrandVehicle.ToListAsync();
            return brandVehicles;
        }

        [HttpPost]
        [Authorize(Roles = UserRols.Admin)]
        public async Task<IActionResult> CreateModel(CreateBrandDTO createBrandDTO)
        {
            var brandFound = await _context.BrandVehicle.Where(item => item.name == createBrandDTO.name).FirstOrDefaultAsync();
            if (brandFound != null) return BadRequest(new { Message = "There are exist brand" });

            BrandVehicle brandVehicle = new BrandVehicle { name = createBrandDTO.name.ToLower() };
            await _context.BrandVehicle.AddAsync(brandVehicle);

            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
