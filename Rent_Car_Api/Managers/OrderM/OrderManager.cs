using EFDataAccess;
using EFDataAccess.ClassesAux;
using EFDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Rent_Car_Api.DTOs.Order;

namespace Rent_Car_Api.Managers.OrderM
{
    public class OrderManager : IOrderManager
    {

        private readonly ApplicationDbContext _context;
        public OrderManager(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ManagerResult<OrderReservation>> GetAsync()
        {

            var managerResult = new ManagerResult<OrderReservation>();
            var orders = await _context.OrderReservation.Where(i => i.status == 1)
                .Include(i=>i.Vehicle)
                .Include(i=>i.User)
                .ToListAsync();
            managerResult.Data = orders;
            return managerResult;
        }


        public async Task<ManagerResult<OrderReservation>> AddAsync(CreateOrderDTO createOrderDTO, string userId)
        {
            var transaction = _context.Database.BeginTransaction();
            var managerResult = new ManagerResult<OrderReservation>();
            try
            {
                var vehicle = await _context.Vehicle.Where(v => v.Id == createOrderDTO.VehicleId && v.state == VehicleStates.Open).FirstOrDefaultAsync();
                if (vehicle == null)
                {
                    managerResult.Success = false;
                    managerResult.Message = "Vehicle not exist or is busy";
                    return managerResult;
                }

                var responseUpdateVehicle = await UpdateVehicle(vehicle);
                if (!responseUpdateVehicle)
                {
                    await transaction.RollbackAsync();
                    managerResult.Success = false;
                    managerResult.Message = "Vehicle is busy";
                    return managerResult;
                }



                OrderReservation orderReservation = new OrderReservation
                {
                    days = createOrderDTO.days,
                    price = createOrderDTO.price,
                    VehicleId = createOrderDTO.VehicleId,
                    UserId = userId,
                };

                // Deberia de estar en repositorio
                await _context.OrderReservation.AddAsync(orderReservation);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                managerResult.Success = true;
                managerResult.Message = "Successfully Add";

                return managerResult;
            }
            catch (Exception e)
            {

                await transaction.RollbackAsync();
                managerResult.Success = false;
                return managerResult;

            }

        }


        private async Task<bool> UpdateVehicle(Vehicle vehicle)
        {
            try
            {

                vehicle.state = VehicleStates.Busy;
                _context.Entry(vehicle).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

    }
}
