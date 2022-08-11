using EFDataAccess;
using EFDataAccess.Models;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Rent_Car_Api.Managers;
using Rent_Car_Api.Managers.BrandM;
using Rent_Car_Api_Test.Mocks;

namespace Rent_Car_Api_Test.Managers.Brand
{
    public class BrandManagerTest
    {
        //mockear
         [Fact]
        public async void GetBrandsTest()
        {
            //arrange
            var dbContext= MockDbContext.GetDatabaseContext();
            BrandManager brandManager = new(dbContext);
            //act
            var result = await  brandManager.GetAsync();
            //assert
            result.Should().NotBeNull();
            result.Should().BeOfType<ManagerResult<BrandVehicle>>();
            result.Data.Count.Should().Be(4);   

        }
    }
}
