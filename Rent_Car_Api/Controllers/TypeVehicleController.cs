using EFDataAccess;
using EFDataAccess.ClassesAux;
using EFDataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rent_Car_Api.DTOs.TypeVehicle;
using Rent_Car_Api.Managers;
using Rent_Car_Api.Managers.TypeVehicleM;

namespace Rent_Car_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeVehicleController : ControllerBase
    {
        private readonly ITypeVehicleManager _typeVehicleManager;

        public TypeVehicleController(ITypeVehicleManager typeVehicleManager)
        {
            _typeVehicleManager = typeVehicleManager;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeVehicle>>> GetTypeVehicles()
        {
            var typeVehicles = await _typeVehicleManager.GetAsync();
            return Ok(typeVehicles);
        }
        [HttpPost]

        [Authorize(Roles = UserRols.Admin)]
        public async Task<IActionResult> CreateTypeVehicle(CreateTypeVehicleDTO createTypeVehicleDTO)
        {
            ManagerResult<TypeVehicle> managerResult = await _typeVehicleManager.AddAsync(createTypeVehicleDTO);

            if (!managerResult.Success)
            {
                return BadRequest(managerResult);
            }

            return Ok(managerResult);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = UserRols.Admin)]
        public async Task<IActionResult> UpdateTypeVehicle(int id, CreateTypeVehicleDTO createTypeVehicleDTO)
        {
            ManagerResult<TypeVehicle> managerResult = await _typeVehicleManager.UpdateAsync(id, createTypeVehicleDTO);

            if (!managerResult.Success)
            {
                return BadRequest(managerResult);
            }

            return Ok(managerResult);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = UserRols.Admin)]
        public async Task<IActionResult> DeleteTypeVehicle(int id)
        {
            ManagerResult<TypeVehicle> managerResult = await _typeVehicleManager.DeleteAsync(id);

            if (!managerResult.Success)
            {
                return BadRequest(managerResult);
            }
            return Ok(managerResult);

        }


    }
}
