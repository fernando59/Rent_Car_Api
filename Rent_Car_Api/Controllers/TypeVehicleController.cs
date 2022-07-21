using EFDataAccess;
using EFDataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Rent_Car_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeVehicleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;


        public TypeVehicleController(ApplicationDbContext context)
        {
            _context = context; 

        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeVehicle>>> GetTypeVehicles()
        {
            var typeVehicles = await _context.TypeVehicle.OrderBy(o => o.name).ToListAsync();
            return typeVehicles;

        }


    }
}
