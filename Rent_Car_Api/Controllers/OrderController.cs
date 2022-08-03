using EFDataAccess.Models;
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

        [HttpPost]
        //[Authorize(Roles = UserRols.Admin)]
        public async Task<IActionResult> CreateOrder(CreateOrderDTO createrOrderDTO)
        {
            string userId = getUser();
            ManagerResult<OrderReservation> managerResult = await _orderManager.AddAsync(createrOrderDTO,userId);

            if (!managerResult.Success)
            {
                return BadRequest(managerResult);
            }
            return Ok(managerResult);
        }

        private string getUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;
            string uid = identity.FindFirst("uid").Value;
            return uid;
        }

    }
}
