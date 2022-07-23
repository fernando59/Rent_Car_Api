using EFDataAccess;
using EFDataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rent_Car_Api.Managers.VehicleM;

namespace Rent_Car_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleManager _vehicleManager;

        public VehicleController(IVehicleManager vehicleManager)
        {
            _vehicleManager = vehicleManager;
        }

        [HttpGet]
        public async Task<ActionResult> GetVehicles()
        {
            var vehicles = await _vehicleManager.GetAsync();
            return Ok(vehicles);
        }


    }
}
