using EFDataAccess.Models;
using Rent_Car_Api.DTOs.Order;

namespace Rent_Car_Api.Managers.OrderM
{
    public interface IOrderManager
    {
        Task<ManagerResult<OrderReservation>> GetAsync();
        Task<ManagerResult<List<int>>> GetAsyncChart();
        Task<ManagerResult<OrderReservation>> GetByClientAsync(string userId);
        Task<ManagerResult<int>> GetOrdersByDay();
        Task<ManagerResult<OrderReservation>> AddAsync(CreateOrderDTO createOrderDTO, string userId);
        Task<ManagerResult<OrderReservation>> AddOrderAdminAsync(CreateOrderAdminDTO createOrderAdminDTO);
        Task<ManagerResult<OrderReservation>> UpdateAsync(int id,UpdateOrderDTO updateOrderDTO,string userId);
    }
}
