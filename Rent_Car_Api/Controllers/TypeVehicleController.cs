using EFDataAccess;
using EFDataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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


    }
}
