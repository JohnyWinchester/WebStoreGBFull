using Microsoft.AspNetCore.Mvc;
using WebStoreGB.Interfaces.Services;

namespace WebStoreGB.Components
{
    public class CartViewComponent: ViewComponent
    {
        public CartViewComponent(ICartService CartService)
        {
            _CartService = CartService;
        }

        public ICartService _CartService { get; }

        public IViewComponentResult Invoke()
        {
            ViewBag.Count = _CartService.GetViewModel().ItemsCount;
            return View();
        }
    }
}
