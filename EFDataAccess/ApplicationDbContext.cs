using EFDataAccess.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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
         public virtual  DbSet<Vehicle> Vehicle { get; set; }
         public virtual  DbSet<PhotosVehicle> PhotosVehicles{ get; set; }


        //Seed Data
        private void SeedData(ModelBuilder modelBuilder)
        {

            #region SEED ROLS
            string idRolAdmin = "832820ac-1b08-444f-a181-cb53552ec970";
            string idRolClient= "ade430d8-7c00-4fb4-96e7-b4531617964e";
            modelBuilder.Entity<IdentityRole>()
               .HasData(new List<IdentityRole>() {
                    new IdentityRole()
                    {
                        Id = idRolAdmin,
                        Name = "Admin",
                        NormalizedName = "ADMIN"
                    },
                    new IdentityRole()
                    {
                        Id = idRolClient,
                        Name = "Client",
                        NormalizedName = "CLIENT"
                    },
               });

            #endregion


            #region SEED DATA
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
            #endregion


            #region SEED ADMIN USER
            string userId = "bfd48176-a1c3-4b29-9c74-72b2d8bb688d";
            var passwordHasher = new PasswordHasher<IdentityUser>();

            var usuarioAdmin = new IdentityUser()
            {
                Id = userId,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                PasswordHash = passwordHasher.HashPassword(null, "Passw0rd$")
            };

            modelBuilder.Entity<IdentityUser>()
               .HasData(usuarioAdmin);


            modelBuilder.Entity<IdentityUserRole<string>>()
                       .HasData(new IdentityUserRole<string>()
                       {
                           UserId = userId,
                           RoleId = idRolAdmin
                       });
            modelBuilder.Entity<IdentityUserClaim<string>>()
             .HasData(new IdentityUserClaim<string>()
             {
                 Id = 1,
                 ClaimType = ClaimTypes.Role,
                 UserId = userId,
                 ClaimValue = "Admin"
             });
             #endregion
        }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

     

    }
}