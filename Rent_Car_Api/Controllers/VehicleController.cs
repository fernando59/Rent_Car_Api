using EFDataAccess;
using EFDataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rent_Car_Api.DTOs.Vehicle;
using Rent_Car_Api.Managers;
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

        [HttpPost]
        // [Authorize(Roles = UserRols.Admin)]

        public async Task<IActionResult> CreateVehicle(CreateVehicleDTO createVehicleDTO)
        {
            ManagerResult<Vehicle> managerResult = await _vehicleManager.AddAsync(createVehicleDTO);

            if (!managerResult.Success)
            {
                return BadRequest(managerResult);
            }

            return Ok(managerResult);
        }
        [HttpPut("{id}")]
        // [Authorize(Roles = UserRols.Admin)]

        public async Task<IActionResult> UpdateVehicle(int id,UpdateVehicleDTO updateVehicleDTO)
        {
            ManagerResult<Vehicle> managerResult = await _vehicleManager.UpdateAsync(id,updateVehicleDTO);

            if (!managerResult.Success)
            {
                return BadRequest(managerResult);
            }

            return Ok(managerResult);
        }


        [HttpDelete("{id}")]
        // [Authorize(Roles = UserRols.Admin)]

        public async Task<IActionResult> DeleteVehicle(int id)
        {
            ManagerResult<Vehicle> managerResult = await _vehicleManager.DeleteAsync(id);

            if (!managerResult.Success)
            {
                return BadRequest(managerResult);
            }

            return Ok(managerResult);
        }

    }
}
