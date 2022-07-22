using EFDataAccess;
using EFDataAccess.ClassesAux;
using EFDataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rent_Car_Api.DTOs.Model;

namespace Rent_Car_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelVehicleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;


        public ModelVehicleController(ApplicationDbContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModelVehicle>>> GetModelVehicles()
        {
            var modelVehicles = await _context.ModelVehicle.ToListAsync();
            return modelVehicles;
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<ModelVehicle>> GetModel(int id)
        {
            var vehicle = await _context.ModelVehicle.FindAsync(id);
            if (vehicle != null) return vehicle;
            return NotFound();

        }



        [HttpPost]
        [Authorize(Roles = UserRols.Admin)]
        public async Task<IActionResult> CreateModel(CreateModelDTO createModelDTO)
        {
            var vehicleFound = await _context.ModelVehicle.Where(item=>item.name ==createModelDTO.name).FirstOrDefaultAsync();
            if (vehicleFound != null) return BadRequest(new {Message="There are exist model"});
            
            ModelVehicle vehicle = new ModelVehicle { name = createModelDTO.name.ToLower() };
            await _context.ModelVehicle.AddAsync(vehicle);
        
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = UserRols.Admin)]
        public async Task<IActionResult> UpdateModel(int id,CreateModelDTO createModelDTO)
        {
            var vehicle = await _context.ModelVehicle.FindAsync(id);

            if (vehicle == null) return NotFound();

            vehicle.name = createModelDTO.name.ToLower();
            _context.Entry(vehicle).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }



    }
}
