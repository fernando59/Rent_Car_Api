using EFDataAccess;
using Rent_Car_Api.DTOs.Vehicle;
using EFDataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Rent_Car_Api.Managers.VehicleM
{
    public class VehicleManager : IVehicleManager
    {
        private readonly ApplicationDbContext _context;

        public VehicleManager(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<ManagerResult<Vehicle>> AddAsync(CreateVehicleDTO createVehicleDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<ManagerResult<Vehicle>> GetAsync()
        {
            var managerResult = new ManagerResult<Vehicle>();
            var vehicles = await _context.Vehicle
              .Include(i => i.ModelVehicle)
              .Include(h => h.BrandVehicle)
              .Include(t => t.TypeVehicle)
              .ToListAsync();

            managerResult.Data = vehicles;

            return managerResult;
        }
    }
}
