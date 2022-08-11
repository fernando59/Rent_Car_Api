using EFDataAccess;
using EFDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_Car_Api_Test.Mocks
{
    public static class MockDbContext
    {
        public  static ApplicationDbContext GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                            .Options;


            var databaseContext = new ApplicationDbContext(options);
            databaseContext.Database.EnsureCreated();

            //seed
            if (databaseContext.BrandVehicle.Count() <= 0)
            {
                for (int i = 1; i < 5; i++)
                {
                    databaseContext.BrandVehicle.Add(new BrandVehicle { Id = i, name = $"Brand{i}" });
                    //databaseContext.Vehicle.Add(new Vehicle() { BrandVehicleId});

                    databaseContext.SaveChanges();
                }
            }



            return databaseContext;

        }


    }
}
