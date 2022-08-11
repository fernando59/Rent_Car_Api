using EFDataAccess;
using Rent_Car_Api.DTOs.Vehicle;
using EFDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using EFDataAccess.ClassesAux;
using Rent_Car_Api.Managers.PhotoM;
using Rent_Car_Api.DTOs.Image;

namespace Rent_Car_Api.Managers.VehicleM
{
    public class VehicleManager : IVehicleManager
    {
        private readonly ApplicationDbContext _context;
        private readonly IPhotoManager _photoManager;

        public VehicleManager(ApplicationDbContext context,IPhotoManager photoManager)
        {
            _context = context;
            _photoManager = photoManager;
        }
        public async Task<ManagerResult<Vehicle>> GetAsync()
        {
            var managerResult = new ManagerResult<Vehicle>();
            var vehicles = await _context.Vehicle.Where(i => i.state != VehicleStates.Deleted)
              .Include(i => i.ModelVehicle)
              .Include(h => h.BrandVehicle)
              .Include(t => t.TypeVehicle)
              .Include(i => i.PhotosVehicles)
              .ToListAsync();

            managerResult.Data = vehicles;

            return managerResult;
        }
        public async Task<ManagerResult<int>> GetVehiclesCount()
        {
            var managerResult = new ManagerResult<int>();
            var vehicles = await _context.Vehicle.Where(i => i.state != VehicleStates.Deleted).ToListAsync();
            managerResult.DataOnly = vehicles.Count;
            return managerResult;
        }
        public async Task<ManagerResult<Vehicle>> GetAsyncOnlyOpen()
        {
            var managerResult = new ManagerResult<Vehicle>();
            var vehicles = await _context.Vehicle.Where(i => i.state == VehicleStates.Open)
              .Include(i => i.ModelVehicle)
              .Include(h => h.BrandVehicle)
              .Include(t => t.TypeVehicle)
              .Include(i => i.PhotosVehicles)
              .ToListAsync();

            managerResult.Data = vehicles;

            return managerResult;
        }
        public async Task<ManagerResult<Vehicle>> AddAsync(CreateVehicleDTO createVehicleDTO)
        {
            var transaction = _context.Database.BeginTransaction();
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
                    description= createVehicleDTO.description,
                    ModelVehicleId = createVehicleDTO.modelVehicleId,
                    TypeVehicleId = createVehicleDTO.typeVehicleId,
                    BrandVehicleId = createVehicleDTO.brandVehicleId
                };

                // Deberia de estar en repositorio
                await _context.Vehicle.AddAsync(vehicle);
                await _context.SaveChangesAsync();

                CreateImageDTO createImageDTO = new CreateImageDTO { fileImage = createVehicleDTO.imagePath, vehicleId = vehicle.Id.ToString() };
                await _photoManager.AddAsync(createImageDTO);
                await transaction.CommitAsync();



                managerResult.Success = true;
                managerResult.Message = "Successfully Add";

                return managerResult;
            }
            catch (Exception e)
            {
                await transaction.RollbackAsync();
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
            var transaction = _context.Database.BeginTransaction();
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
                vehicle.description= updateVehicleDTO.description;
                vehicle.hasAir = updateVehicleDTO.hasAir;
                vehicle.BrandVehicleId = updateVehicleDTO.brandVehicleId;
                vehicle.ModelVehicleId = updateVehicleDTO.modelVehicleId;
                vehicle.TypeVehicleId = updateVehicleDTO.typeVehicleId;

                _context.Entry(vehicle).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                var image = await _context.PhotosVehicles.Where(i => i.VehicleId == vehicle.Id).FirstOrDefaultAsync();


                if (image != null && updateVehicleDTO.imagePath !=null)
                {
                    _context.PhotosVehicles.Remove(image);
                    await _context.SaveChangesAsync();
                }




                if(updateVehicleDTO.imagePath != null)
                {
                    CreateImageDTO createImageDTO = new CreateImageDTO { fileImage = updateVehicleDTO.imagePath, vehicleId = vehicle.Id.ToString() };
                    await _photoManager.AddAsync(createImageDTO);
                }
                await transaction.CommitAsync();

                managerResult.Message = "Successfully Update";

                return managerResult;
            }
            catch (Exception e)
            {
                await transaction.RollbackAsync();
                managerResult.Success = false;
                managerResult.Message = e.Message;
                return managerResult;
            }
        }


        public async Task<ManagerResult<Vehicle>> GetAsyncFilter(int page,int brandId=0,int typeVehicleId=0,int modelId = 0,int quantity=10)
        {
            var managerResult = new ManagerResult<Vehicle>();
            IQueryable<Vehicle> listVehicles = from vehicle in _context.Vehicle where vehicle.state == VehicleStates.Open
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
                .Include(i => i.PhotosVehicles)
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

        public async Task<ManagerResult<decimal>> GetPrices()
        {
            var managerResult = new ManagerResult<decimal>();
            var max = await _context.Vehicle.MaxAsync(x => x.price);
            var min = await _context.Vehicle.MinAsync(x => x.price);

            decimal[] prices = { min, max };

            managerResult.Data = prices;

            return managerResult;
        }
    }
}
