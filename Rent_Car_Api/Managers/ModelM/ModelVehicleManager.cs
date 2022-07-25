using EFDataAccess;
using EFDataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Rent_Car_Api.Managers.ModelM
{
    public class ModelVehicleManager:IModelVehicleManager
    {

        private readonly ApplicationDbContext _context;

        public ModelVehicleManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ManagerResult<ModelVehicle>> GetAsync()
        {
            var managerResult = new ManagerResult<ModelVehicle>();
            var vehicles = await _context.ModelVehicle.ToListAsync();
            managerResult.Data = vehicles;
            return managerResult;
        }
    }
}
