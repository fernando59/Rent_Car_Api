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
        public async Task<ManagerResult<Vehicle>> AddAsync(CreateVehicleDTO createVehicleDTO)
        {
            var managerResult = new ManagerResult<Vehicle>();
            try
            {
                Vehicle vehicle = new Vehicle
                {
                    capacity = createVehicleDTO.capacity,
                    hasAir = createVehicleDTO.hasAir,
                    plate = createVehicleDTO.plate.ToUpper(),
                    price = createVehicleDTO.price,
                    year = createVehicleDTO.year,
                    ModelVehicleId = createVehicleDTO.model,
                    TypeVehicleId = createVehicleDTO.typeVehicle,
                    BrandVehicleId = createVehicleDTO.brand
                };

                // Deberia de estar en repositorio
                await _context.Vehicle.AddAsync(vehicle);
                await _context.SaveChangesAsync();

                managerResult.Success = true;
                managerResult.Message = "Successfully Add";

                return managerResult;
            }
            catch (Exception e)
            {
                managerResult.Success = false;
                managerResult.Message = e.Message;
                return managerResult;
            }
        }

        public async Task<ManagerResult<Vehicle>> GetAsync()
        {
            var managerResult = new ManagerResult<Vehicle>();
            var vehicles = await _context.Vehicle
              .Include(i => i.ModelVehicle)
              .Include(h => h.BrandVehicle)
              .Include(t => t.TypeVehicle)
              //.Include(i=>i.)
              .ToListAsync();

            managerResult.Data = vehicles;

            return managerResult;
        }
    }
}
