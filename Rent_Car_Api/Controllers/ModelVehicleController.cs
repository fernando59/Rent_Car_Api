using EFDataAccess;
using EFDataAccess.ClassesAux;
using EFDataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rent_Car_Api.DTOs.Model;
using Rent_Car_Api.Managers;
using Rent_Car_Api.Managers.ModelM;
using Rent_Car_Api.Managers.VehicleM;

namespace Rent_Car_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelVehicleController : ControllerBase
    {
        private readonly IModelVehicleManager _modelVehicleManager;

        public ModelVehicleController(IModelVehicleManager modelVehicleManager)
        {
            _modelVehicleManager = modelVehicleManager;
        }


        [HttpGet]
        public async Task<ActionResult> GetModelVehicles()
        {
            var res =await _modelVehicleManager.GetAsync();
            return Ok(res);
        }



        [HttpPost]

        //[Authorize(Roles = UserRols.Admin)]
        public async Task<IActionResult> CreateModel(CreateModelDTO createModelDTO)
        {
            ManagerResult<ModelVehicle> managerResult = await _modelVehicleManager.AddAsync(createModelDTO);

            if (!managerResult.Success)
            {
                return BadRequest(managerResult);
            }

            return Ok(managerResult);
        }


        [HttpPut("{id}")]
        //[Authorize(Roles = UserRols.Admin)]
        public async Task<IActionResult> UpdateModel(int id,CreateModelDTO createModelDTO)
        {
            ManagerResult<ModelVehicle> managerResult = await _modelVehicleManager.UpdateAsync(id, createModelDTO);

            if (!managerResult.Success)
            {
                return BadRequest(managerResult);
            }

            return Ok(managerResult);
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = UserRols.Admin)]
        public async Task<IActionResult> DeleteModel(int id)
        {
            ManagerResult<ModelVehicle> managerResult = await _modelVehicleManager.DeleteAsync(id);

            if (!managerResult.Success)
            {
                return BadRequest(managerResult);
            }
            return Ok(managerResult);

        }


    }
}
