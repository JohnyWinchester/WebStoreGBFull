using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebStoreGB.Domain.DTO;
using WebStoreGB.Domain.ViewModels;
using WebStoreGB.Interfaces;
using WebStoreGB.Interfaces.Services;

namespace WebStoreGB.WebAPI.Controllers
{
    [Route(WebAPIAddresses.Orders)]
    [ApiController]
    public class OrdersApiController : ControllerBase
    {
        private readonly IOrderService _OrderService;
        public OrdersApiController(IOrderService OrderService)
        {
            _OrderService = OrderService;
        }

        [HttpGet("user/{UserName}")]
        public async Task<IActionResult> GetUserOrders(string UserName)
        {
            var orders = await _OrderService.GetUserOrders(UserName);
            return Ok(orders.ToDTO());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _OrderService.GetOrderById(id);
            if (order is null)
                return NotFound();
            return Ok(order.ToDTO());
        }

        [HttpPost("{UserName}")]
        public async Task<IActionResult> CreateOrder(string UserName,[FromBody] CreateOrderDTO OrderModel)
        {
            var order = await _OrderService.CreateOrder(UserName, OrderModel.Items.ToCartView(), OrderModel.Order);
            return Ok(order.ToDTO());
        }
    }
}
