using EFDataAccess;
using EFDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Rent_Car_Api.DTOs.TypeVehicle;

namespace Rent_Car_Api.Managers.TypeVehicleM
{
    public class TypeVehicleManager:ITypeVehicleManager
    {
        private readonly ApplicationDbContext _context;

        public TypeVehicleManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ManagerResult<TypeVehicle>> AddAsync(CreateTypeVehicleDTO createTypeVehicleDTO)
        {
            var managerResult = new ManagerResult<TypeVehicle>();

            // Deberia de estar en repositorio
            var typeVehicleFound = await _context.TypeVehicle.Where(item => item.name == createTypeVehicleDTO.name).FirstOrDefaultAsync();

            if (typeVehicleFound != null)
            {
                managerResult.Success = false;
                managerResult.Message = "There are exist typeVehicle";
                return managerResult;
            }

            TypeVehicle typeVehicle = new TypeVehicle { name = createTypeVehicleDTO.name.ToLower() };

            // Deberia de estar en repositorio
            await _context.TypeVehicle.AddAsync(typeVehicle);
            await _context.SaveChangesAsync();

            managerResult.Success = true;
            managerResult.Message = "Successfully Add";

            return managerResult;
        }


        public async Task<ManagerResult<TypeVehicle>> DeleteAsync(int id)
        {
            var managerResult = new ManagerResult<TypeVehicle>();
            try
            {
                var typeVehicle = await _context.TypeVehicle.Where(t => t.Id == id).FirstOrDefaultAsync();

                if (typeVehicle == null)
                {
                    managerResult.Success = false;
                    managerResult.Message = "Type Vehicle not found";
                    return managerResult;
                }

                _context.TypeVehicle.Remove(typeVehicle);
                await _context.SaveChangesAsync();
                managerResult.Message = "Delete successfully";
                return managerResult;

            }
            catch (Exception e)
            {

                managerResult.Success = false;
                managerResult.Message = "The Type Vehicle already has a vehicle assigned";
                
                return managerResult;
            }
        }

        public async Task<ManagerResult<TypeVehicle>> GetAsync()
        {
            var managerResult = new ManagerResult<TypeVehicle>();
            var typeVehicles = await _context.TypeVehicle.ToListAsync();
            managerResult.Data = typeVehicles;
            return managerResult;
        }

        public async  Task<ManagerResult<TypeVehicle>> UpdateAsync(int id, CreateTypeVehicleDTO createTypeVehicleDTO)
        {
            var managerResult = new ManagerResult<TypeVehicle>();
            try
            {
                var typeVehicle = await _context.TypeVehicle.FindAsync(id);

                if (typeVehicle == null)
                {
                    managerResult.Success = false;
                    managerResult.Message = "There are not  exist typeVehicle";
                    return managerResult;

                }

                typeVehicle.name = createTypeVehicleDTO.name.ToLower();
                _context.Entry(typeVehicle).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                managerResult.Message = "Successfully Update";

                return managerResult;

            }
            catch (Exception e)
            {
                managerResult.Success = false;
                managerResult.Message = e.Message;
                return managerResult;

            }
        }
    }
}
