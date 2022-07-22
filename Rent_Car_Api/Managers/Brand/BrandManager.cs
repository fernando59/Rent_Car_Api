using EFDataAccess;
using EFDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Rent_Car_Api.DTOs.Brand;

namespace Rent_Car_Api.Managers.Brand
{
    public class BrandManager : IBrandManager
    {
        private readonly ApplicationDbContext _context;

        public BrandManager(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<ManagerResult> AddAsync(CreateBrandDTO createBrandDTO)
        {
            var managerResult = new ManagerResult();

            // Deberia de estar en repositorio
            var brandFound = await _context.BrandVehicle.Where(item => item.name == createBrandDTO.name).FirstOrDefaultAsync();

            if (brandFound != null)
            {
                managerResult.Message = "There are exist brand";
                return managerResult;
            }
            
            BrandVehicle brandVehicle = new BrandVehicle { name = createBrandDTO.name.ToLower() };

            // Deberia de estar en repositorio
            await _context.BrandVehicle.AddAsync(brandVehicle);
            await _context.SaveChangesAsync();

            managerResult.Success = true;

            return managerResult;
        }

        public async Task<ManagerResult> Updatesync(int id,CreateBrandDTO createBrandDTO)
        {
            var managerResult = new ManagerResult();
            var brand = await _context.BrandVehicle.FindAsync(id);

            if (brand == null)
            {
                managerResult.Success = false;
                managerResult.Message = "There are not  exist brand";
                return managerResult;

            }

            brand.name = createBrandDTO.name.ToLower();
            _context.Entry(brand).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            managerResult.Message = "Successfully Update";

            return managerResult;
        }
    }
}
