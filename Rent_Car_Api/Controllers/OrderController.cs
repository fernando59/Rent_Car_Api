using EFDataAccess.ClassesAux;
using EFDataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rent_Car_Api.DTOs.Order;
using Rent_Car_Api.Managers;
using Rent_Car_Api.Managers.OrderM;
using System.Security.Claims;

namespace Rent_Car_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderManager _orderManager;

        public OrderController(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }

        [HttpGet]
        public async Task<ActionResult> GetOrders()
        {
            var orders = await _orderManager.GetAsync();
            return Ok(orders);
        }

        [HttpGet("getOrdersByUser")]
        [Authorize(Roles = UserRols.Client)]
        public async Task<ActionResult> GetOrdersByClient()
        {
            string userId = getUser();
            ManagerResult<OrderReservation> managerResult = new ManagerResult<OrderReservation>();
            if (userId == null)
            {
                managerResult.Success = false;
                managerResult.Message = "User not found";
                return BadRequest(managerResult);
            }
            managerResult = await _orderManager.GetByClientAsync(userId);
            return Ok(managerResult);
        }

        [HttpPost]
        [Authorize(Roles = UserRols.Client)]
        public async Task<IActionResult> CreateOrder(CreateOrderDTO createrOrderDTO)
        {
            string userId = getUser();
            ManagerResult<OrderReservation> managerResult = new ManagerResult<OrderReservation>();
            if (userId == null)
            {
                managerResult.Success = false;
                managerResult.Message = "User not found";
                return BadRequest(managerResult);
            }

             managerResult = await _orderManager.AddAsync(createrOrderDTO,userId);
            if (!managerResult.Success)
            {
                return BadRequest(managerResult);
            }
            return Ok(managerResult);
        }
        [HttpPost("CreateOrderAdmin")]
        [Authorize(Roles = UserRols.Admin)]
        public async Task<IActionResult> CreateOrderAdmin(CreateOrderAdminDTO createOrderAdminDTO)
        {
            ManagerResult<OrderReservation> managerResult = new ManagerResult<OrderReservation>();
            managerResult = await _orderManager.AddOrderAdminAsync(createOrderAdminDTO);

            if (!managerResult.Success)
            {
                return BadRequest(managerResult);
            }
            return Ok(managerResult);
        }


        [HttpPut("{id}")]
        [Authorize(Roles = $"{UserRols.Admin},${UserRols.Client}")]

        public async Task<IActionResult> UpdateOrder(int id,UpdateOrderDTO updateOrderDTO)
        {
            string userId = getUser();
            ManagerResult<OrderReservation> managerResult = new ManagerResult<OrderReservation>();
            if (userId == null)
            {
                managerResult.Success = false;
                managerResult.Message = "User not found";
                return BadRequest(managerResult);
            }

            managerResult = await _orderManager.UpdateAsync(id,updateOrderDTO, userId);
            if (!managerResult.Success)
            {
                return BadRequest(managerResult);
            }

            return Ok(managerResult);

        }

        private string getUser()
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                //IEnumerable<Claim> claims = identity.Claims;
                string uid = identity.FindFirst("uid").Value;
                return uid;

            }catch(Exception e)
            {
                return null;
            }
        }

    }
}
