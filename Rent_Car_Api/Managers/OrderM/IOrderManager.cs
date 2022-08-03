﻿using EFDataAccess.Models;
using Rent_Car_Api.DTOs.Order;

namespace Rent_Car_Api.Managers.OrderM
{
    public interface IOrderManager
    {
        Task<ManagerResult<OrderReservation>> GetAsync();
        Task<ManagerResult<OrderReservation>> AddAsync(CreateOrderDTO createOrderDTO,string userId);
    }
}