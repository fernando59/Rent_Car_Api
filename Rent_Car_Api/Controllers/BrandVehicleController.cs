﻿using EFDataAccess;
using EFDataAccess.ClassesAux;
using EFDataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rent_Car_Api.DTOs.Brand;
using Rent_Car_Api.Managers;
using Rent_Car_Api.Managers.BrandM;

namespace Rent_Car_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandVehicleController : ControllerBase
    {
        private readonly IBrandManager _brandManager;

        public BrandVehicleController(IBrandManager brandManager)
        {
            _brandManager = brandManager;
        }


        [HttpGet]
        public async Task<ActionResult> GetModelVehicles()
        {
            var brands = await _brandManager.GetAsync();
            return Ok(brands);
        }



        [HttpPost]
        [Authorize(Roles = UserRols.Admin)]
        
        public async Task<IActionResult> CreateBrand(CreateBrandDTO createBrandDTO)
        {
            ManagerResult<BrandVehicle> managerResult = await _brandManager.AddAsync(createBrandDTO);

            if(!managerResult.Success)
            {
                return BadRequest(managerResult);
            }

            return Ok(managerResult);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = UserRols.Admin)]
        public async Task<IActionResult> UpdateBRand(int id, CreateBrandDTO createBrandDTO)
        {
            ManagerResult<BrandVehicle> managerResult = await _brandManager.Updatesync(id,createBrandDTO);
           
            if (!managerResult.Success)
            {
                return BadRequest(managerResult);
            }

            return Ok(managerResult);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {

            ManagerResult<BrandVehicle> managerResult = await _brandManager.DeleteAsync(id);
            if (!managerResult.Success)
            {
                return BadRequest(managerResult);
            }
            return Ok(managerResult);
        }

    }
}
