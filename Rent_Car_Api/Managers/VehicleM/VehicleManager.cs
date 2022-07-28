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
                    ModelVehicleId = createVehicleDTO.modelVehicle,
                    TypeVehicleId = createVehicleDTO.typeVehicle,
                    BrandVehicleId = createVehicleDTO.brandVehicle
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

        public async Task<ManagerResult<Vehicle>> DeleteAsync(int id)
        {
            var managerResult = new ManagerResult<Vehicle>();
            var vehicle = await _context.Vehicle.Where(i=>i.Id ==id).FirstOrDefaultAsync();

            if (vehicle == null)
            {
                managerResult.Success=false;
                managerResult.Message = "Vehicle not exist";
                return managerResult;

            }

             _context.Vehicle.Remove(vehicle);
            await _context.SaveChangesAsync();
            managerResult.Message = "Delete Successfully";

            return managerResult;
        }


        public async Task<ManagerResult<Vehicle>> UpdateAsync(int id, UpdateVehicleDTO updateVehicleDTO)
        {
            var managerResult = new ManagerResult<Vehicle>();
            try
            {
                var vehicle = await _context.Vehicle.FindAsync(id);

                if (vehicle == null)
                {
                    managerResult.Success = false;
                    managerResult.Message = "There are not  exist vehicle";
                    return managerResult;

                }

                vehicle.price = updateVehicleDTO.price;
                vehicle.plate = updateVehicleDTO.plate.ToUpper();
                vehicle.year = updateVehicleDTO.year;
                vehicle.capacity = updateVehicleDTO.capacity;
                vehicle.hasAir = updateVehicleDTO.hasAir;
                vehicle.BrandVehicleId = updateVehicleDTO.brandVehicleId;
                vehicle.ModelVehicleId = updateVehicleDTO.modelVehicleId;
                vehicle.TypeVehicleId = updateVehicleDTO.typeVehicleId;

                _context.Entry(vehicle).State = EntityState.Modified;
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
        public async Task<ManagerResult<Vehicle>> GetAsync()
        {
            var managerResult = new ManagerResult<Vehicle>();
            var vehicles = await _context.Vehicle
              .Include(i => i.ModelVehicle)
              .Include(h => h.BrandVehicle)
              .Include(t => t.TypeVehicle)
              .Include(i=>i.PhotosVehicles)
              .ToListAsync();

            managerResult.Data = vehicles;

            return managerResult;
        }

        public async Task<ManagerResult<Vehicle>> GetAsyncFilter(int page,int brandId,int typeVehicleId,int modelId,int quantity=10)
        {
            var managerResult = new ManagerResult<Vehicle>();
            IQueryable<Vehicle> listVehicles = from vehicle in _context.Vehicle
                                        select vehicle;

            if(brandId != 0) {
                listVehicles = listVehicles.Where(i => i.BrandVehicleId == brandId);
            }

            if (typeVehicleId!= 0)
            {
                listVehicles = listVehicles.Where(i => i.TypeVehicleId == typeVehicleId);
            }
            
            if (modelId != 0)
            {
                listVehicles = listVehicles.Where(i => i.ModelVehicleId == modelId);
            }

            var vehicles = await listVehicles
                .Skip(page)
                .Take(quantity)
                .Include(s => s.ModelVehicle)
                .Include(s => s.TypeVehicle)
                .Include(s => s.BrandVehicle)
                .ToListAsync();

            managerResult.Data = vehicles;

            return managerResult;


        }

        public async Task<ManagerResult<Vehicle>> GetAsyncById(int id)
        {
            var managerResult = new ManagerResult<Vehicle>();
            var vehicles = await _context.Vehicle.Where(i=>i.Id ==id)
              .Include(i => i.ModelVehicle)
              .Include(h => h.BrandVehicle)
              .Include(t => t.TypeVehicle)
              .Include(i=>i.PhotosVehicles)
              .ToListAsync();
            if(vehicles.Count == 0)
            {

                managerResult.Success = false;
                var vehiclesList= new List<Vehicle>();
                managerResult.Message = "Vehicle not found";
                managerResult.Data = vehiclesList;
                return managerResult;
            }

            managerResult.Data = vehicles;

            return managerResult;

        }
    }
}
