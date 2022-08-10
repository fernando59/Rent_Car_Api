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
            var orders = await _context.OrderReservation.Where(i => i.status != 4)
                .Include(i=>i.Vehicle)
                .Include("Vehicle.BrandVehicle")
                .Include("Vehicle.ModelVehicle")
                .Include("Vehicle.TypeVehicle")
                .Include(i=>i.User)
                .OrderByDescending(i=>i.Id)
                .ToListAsync();
            managerResult.Data = orders;
            return managerResult;
        }
        public async Task<ManagerResult<List<OrderChart>>> GetAsyncChart()
        {

            var managerResult = new ManagerResult<List<OrderChart>>();
                var orders = await _context.OrderReservation
                  .Include(i => i.Vehicle)
                  .Include("Vehicle.BrandVehicle")
                  .GroupBy(x => x.Vehicle.BrandVehicle.name)
                  .Select(x => new OrderChart{ Vehicle = x.Key, count = x.Count() }).ToListAsync();
            managerResult.Data = (IList<List<OrderChart>>)orders;

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


                var days = (createOrderDTO.endDate.Date - createOrderDTO.startDate.Date).Days;
                OrderReservation orderReservation = new OrderReservation
                {
                    startDate = createOrderDTO.startDate,
                    endDate = createOrderDTO.endDate,
                    price = vehicle.price,
                    VehicleId = createOrderDTO.VehicleId,
                    UserId = userId,
                    days=days,
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
                managerResult.Message = e.Message;
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

        public async Task<ManagerResult<OrderReservation>> GetByClientAsync(string userId)
        {
            var managerResult = new ManagerResult<OrderReservation>();
            var orders = await _context.OrderReservation
                .Where(i => i.status != 4)
                .Where(i=>i.UserId ==userId)
                .Include(i => i.Vehicle)
                .Include("Vehicle.BrandVehicle")
                .Include("Vehicle.ModelVehicle")
                .Include("Vehicle.TypeVehicle")
                .Include(i => i.User)
                .OrderByDescending(i=>i.Id)
                .ToListAsync();
            managerResult.Data = orders;
            return managerResult;
        }

        public async Task<ManagerResult<OrderReservation>> UpdateAsync(int id,UpdateOrderDTO updateOrderDTO, string userId)
        {

            var transaction = _context.Database.BeginTransaction();
            var managerResult = new ManagerResult<OrderReservation>();
            try
            {
                var order = await _context.OrderReservation.FindAsync(id);
                if(order == null)
                {
                    managerResult.Success = false;
                    managerResult.Message = "Order not found";
                    return managerResult;
                }

                order.status = updateOrderDTO.status;
                if(order.status == OrderStates.Canceled || order.status ==OrderStates.Finished)
                {
                    var resVehicleUpdate = await updateVehicleAysnc(order.VehicleId, VehicleStates.Open);
                    if (!resVehicleUpdate)
                    {
                        await transaction.RollbackAsync();
                        managerResult.Success = false;
                        managerResult.Message = "An error has occurred";
                        return managerResult;

                    }
                }

                _context.Entry(order).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                managerResult.Success = true;
                await transaction.CommitAsync();    
                return managerResult;

            }catch(Exception e)
            {

                managerResult.Success = false;
                managerResult.Message = e.Message;
                await transaction.RollbackAsync(); 
                return managerResult;
            }

        }


        private async Task<bool> updateVehicleAysnc(int idVehicle,int status)
        {
            try
            {

                var vehicle= await _context.Vehicle.FindAsync(idVehicle);   
                if(vehicle == null)
                {
                    return false;
                }
                vehicle.state = status;
                _context.Entry(vehicle).State = EntityState.Modified;
                await _context.SaveChangesAsync();


                return true;

            }catch(Exception e)
            {
                return false;

            }
        }

        public async Task<ManagerResult<OrderReservation>> AddOrderAdminAsync(CreateOrderAdminDTO createOrderAdminDTO)
        {

            var transaction = _context.Database.BeginTransaction();
            var managerResult = new ManagerResult<OrderReservation>();
            try
            {
                var vehicle = await _context.Vehicle.Where(v => v.Id == createOrderAdminDTO.VehicleId && v.state == VehicleStates.Open).FirstOrDefaultAsync();
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


                var days = (createOrderAdminDTO.endDate.Date - createOrderAdminDTO.startDate.Date).Days;
                OrderReservation orderReservation = new OrderReservation
                {
                    startDate = createOrderAdminDTO.startDate,
                    endDate = createOrderAdminDTO.endDate,
                    price = vehicle.price,
                    VehicleId = createOrderAdminDTO.VehicleId,
                    UserId = createOrderAdminDTO.userId,
                    days = days,
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
                managerResult.Message = e.Message;
                return managerResult;

            }

        }

        public async Task<ManagerResult<int>> GetOrdersByDay()
        {
            var managerResult = new ManagerResult<int>();
            var orders = await _context.OrderReservation.Where(i => i.status != 4).Where(i => i.createAt.Date == DateTime.Now.Date).ToListAsync();
            managerResult.DataOnly = orders.Count;
            return managerResult;
        }

    }
}
