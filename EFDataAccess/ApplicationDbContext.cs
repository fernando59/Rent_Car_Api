using EFDataAccess.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EFDataAccess
{
    public class ApplicationDbContext: IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
         //Tables
         public virtual  DbSet<TypeVehicle> TypeVehicle { get; set; }
         public virtual  DbSet<BrandVehicle> BrandVehicle { get; set; }
         public virtual  DbSet<ModelVehicle> ModelVehicle { get; set; }


        //Seed Data
        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TypeVehicle>().HasData(new List<TypeVehicle>()
            {
                new TypeVehicle()
                {
                    Id=1,
                    name="Motos",
                },
                new TypeVehicle()
                {
                    Id=2,
                    name="Autos",
                },
            });
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

     

    }
}