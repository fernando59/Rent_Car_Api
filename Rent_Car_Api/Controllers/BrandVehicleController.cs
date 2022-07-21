using EFDataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
