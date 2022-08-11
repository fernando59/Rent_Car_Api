using EFDataAccess;
using EFDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Rent_Car_Api.DTOs.Brand;

namespace Rent_Car_Api.Managers.BrandM
{
    public class BrandManager : IBrandManager
    {
        private readonly ApplicationDbContext _context;

        public BrandManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ManagerResult<BrandVehicle>> AddAsync(CreateBrandDTO createBrandDTO)
        {
            var managerResult = new ManagerResult<BrandVehicle>();

            // Deberia de estar en repositorio
            var brandFound = await _context.BrandVehicle.Where(item => item.name == createBrandDTO.name).FirstOrDefaultAsync();

            if (brandFound != null)
            {
                managerResult.Success = false;
                managerResult.Message = "There are exist brand";
                return managerResult;
            }
            
            BrandVehicle brandVehicle = new BrandVehicle { name = createBrandDTO.name.ToLower() };

            // Deberia de estar en repositorio
            await _context.BrandVehicle.AddAsync(brandVehicle);
            await _context.SaveChangesAsync();

            managerResult.Success = true;
            managerResult.Message = "Successfully Add";

            return managerResult;
        }

        public async  Task<ManagerResult<BrandVehicle>> DeleteAsync(int id)
        {
            var managerResult = new ManagerResult<BrandVehicle>();
            try { 
                 var brand = await _context.BrandVehicle.Where(t => t.Id == id).FirstOrDefaultAsync();

                if (brand == null)
                {
                    managerResult.Message = "Brand not found";
                    managerResult.Success = false;
                    return managerResult;
                }
                _context.BrandVehicle.Remove(brand);
                await _context.SaveChangesAsync();
                return managerResult;
            }catch(Exception e)
            {
                managerResult.Success = false;
                managerResult.Message = "The brand already has a vehicle assigned";
                return managerResult;

            }
        }

        public async Task<ManagerResult<BrandVehicle>> GetAsync()
        {
            var managerResult = new ManagerResult<BrandVehicle>();
            var brands = await _context.BrandVehicle.ToListAsync();
            managerResult.Data = brands;
            return managerResult;
        }

        public async Task<ManagerResult<BrandVehicle>> Updatesync(int id,CreateBrandDTO createBrandDTO)
        {
            var managerResult = new ManagerResult<BrandVehicle>();
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
