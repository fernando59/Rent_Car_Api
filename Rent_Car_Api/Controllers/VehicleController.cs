using EFDataAccess;
using EFDataAccess.ClassesAux;
using EFDataAccess.Models;
using Microsoft.AspNetCore.Authorization;
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
        [HttpGet("getOnlyOpen")]
        public async Task<ActionResult> GetVehiclesOnlyOpen()
        {
            var vehicles = await _vehicleManager.GetAsyncOnlyOpen();
            return Ok(vehicles);
        }
        [HttpGet("getVehiclesCount")]
        public async Task<ActionResult> GetVehiclesCount()
        {
            var vehicles = await _vehicleManager.GetVehiclesCount();
            return Ok(vehicles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetVehicleById(int id)
        {
            ManagerResult<Vehicle> managerResult = await _vehicleManager.GetAsyncById(id);

            if (!managerResult.Success)
            {
                return NotFound(managerResult);
            }

            return Ok(managerResult);
        }
        [HttpGet("getPricesRange")]
        public async Task<ActionResult> GetPricesRange()
        {
            ManagerResult<decimal> managerResult = await _vehicleManager.GetPrices();

            if (!managerResult.Success)
            {
                return NotFound(managerResult);
            }

            return Ok(managerResult);
        }

        [HttpGet("GetVehiclesFilter")]
        public async Task<ActionResult> GetVehiclesFilter([FromQuery]int page,int brandId, int typeVehicleId, int modelId, int quantity)
        {
            ManagerResult<Vehicle> managerResult =await _vehicleManager.GetAsyncFilter(page,brandId,typeVehicleId,modelId,quantity);
            if (!managerResult.Success)
            {
                return BadRequest(managerResult);
            }

            return Ok(managerResult);
        }

        [HttpPost]
        [Authorize(Roles = UserRols.Admin)]

        public async Task<IActionResult> CreateVehicle([FromForm]  CreateVehicleDTO createVehicleDTO)
        {
            ManagerResult<Vehicle> managerResult = await _vehicleManager.AddAsync(createVehicleDTO);

            if (!managerResult.Success)
            {
                return BadRequest(managerResult);
            }

            return Ok(managerResult);
        }
        [HttpPut("{id}")]
        [Authorize(Roles = UserRols.Admin)]

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
        [Authorize(Roles = UserRols.Admin)]

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
