using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebStoreGB.Domain.ViewModels;
using WebStoreGB.Interfaces.Services;

namespace WebStoreGB.Controllers
{
    [Authorize]
    public class UserProfileController : Controller
    {
        public IActionResult Index() => View();

        public async Task<IActionResult> Orders([FromServices] IOrderService OrderService)
        {
            var orders = await OrderService.GetUserOrders(User.Identity!.Name);

            return View(orders.Select(o => new UserOrderViewModel
            {
                Id = o.Id,
                Address = o.Address,
                Phone = o.Phone,
                Description = o.Description,
                TotalPrice = o.TotalPrice,
                Date = o.Date,
            }));
        }
    }
}
