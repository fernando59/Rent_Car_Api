using EFDataAccess;
using EFDataAccess.Models;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rent_Car_Api.Controllers;
using Rent_Car_Api.Managers;
using Rent_Car_Api.Managers.BrandM;
using Rent_Car_Api_Test.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_Car_Api_Test.Controllers.Brand
{
    public class BrandControllerTest
    {
        private readonly BrandManager _brandManager;
        private readonly  ApplicationDbContext _dbContext ;
        

        public BrandControllerTest()
        {
             _dbContext= MockDbContext.GetDatabaseContext();
             _brandManager =new(_dbContext); 

        }
          [Fact]
        public async void GetBrandsControllerTest()
        {
            //arrange
            var controller = new BrandVehicleController(_brandManager);
            //act
            var result = await controller.GetModelVehicles();
            var resultOk = (result as OkObjectResult);
            var resultManager = resultOk?.Value  as ManagerResult<BrandVehicle>;

            //assert
             result.Should().NotBeNull();
             result.Should().BeOfType(typeof(OkObjectResult));
             resultOk?.StatusCode.Should().Be(200);
             resultManager?.Data.Count.Should().Be(4);
        }

    }
}
