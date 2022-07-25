using EFDataAccess;
using EFDataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Rent_Car_Api.Managers.TypeVehicleM
{
    public class TypeVehicleManager:ITypeVehicleManager
    {
        private readonly ApplicationDbContext _context;

        public TypeVehicleManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ManagerResult<TypeVehicle>> GetAsync()
        {
            var managerResult = new ManagerResult<TypeVehicle>();
            var typeVehicles = await _context.TypeVehicle.ToListAsync();
            managerResult.Data = typeVehicles;
            return managerResult;
        }
    }
}
