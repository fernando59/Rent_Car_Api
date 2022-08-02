using EFDataAccess;
using EFDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Rent_Car_Api.DTOs.Model;

namespace Rent_Car_Api.Managers.ModelM
{
    public class ModelVehicleManager:IModelVehicleManager
    {

        private readonly ApplicationDbContext _context;

        public ModelVehicleManager(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ManagerResult<ModelVehicle>> AddAsync(CreateModelDTO createModelDTO)
        {
            var managerResult = new ManagerResult<ModelVehicle>();

            // Deberia de estar en repositorio
            var brandFound = await _context.ModelVehicle.Where(item => item.name == createModelDTO.name).FirstOrDefaultAsync();

            if (brandFound != null)
            {
                managerResult.Success = false;
                managerResult.Message = "There are exist model";
                return managerResult;
            }

            ModelVehicle modelVehicle = new ModelVehicle{ name = createModelDTO.name.ToLower() };

            // Deberia de estar en repositorio
            await _context.ModelVehicle.AddAsync(modelVehicle);
            await _context.SaveChangesAsync();

            managerResult.Success = true;
            managerResult.Message = "Successfully Add";

            return managerResult;
        }

        public async Task<ManagerResult<ModelVehicle>> DeleteAsync(int id )
        {
            var managerResult = new ManagerResult<ModelVehicle>();
            try
            {
                var model = await _context.ModelVehicle.Where(t => t.Id == id).FirstOrDefaultAsync();

                if (model == null)
                {
                    managerResult.Success =false;
                    managerResult.Message = "Model not found";
                    return managerResult;
                }

                _context.ModelVehicle.Remove(model);
                await _context.SaveChangesAsync();
                managerResult.Message = "Delete successfully";
                return managerResult;

            }catch(Exception e)
            {

                managerResult.Success = false;
                managerResult.Message = e.Message;
                return managerResult;
            }

        }

        public async Task<ManagerResult<ModelVehicle>> GetAsync()
        {
            var managerResult = new ManagerResult<ModelVehicle>();
            var vehicles = await _context.ModelVehicle.ToListAsync();
            managerResult.Data = vehicles;
            return managerResult;
        }

        public async Task<ManagerResult<ModelVehicle>> UpdateAsync(int id, CreateModelDTO createModelDTO)
        {
            var managerResult = new ManagerResult<ModelVehicle>();
            try
            {
                var model = await _context.ModelVehicle.FindAsync(id);

                if (model == null)
                {
                    managerResult.Success = false;
                    managerResult.Message = "There are not  exist model";
                    return managerResult;

                }

                model.name = createModelDTO.name.ToLower();
                _context.Entry(model).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                managerResult.Message = "Successfully Update";

                return managerResult;

            }catch(Exception e)
            {
                managerResult.Success=false;
                managerResult.Message = e.Message;
                return managerResult;

            }

        }
    }
}
