using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStoreGB.Domain.Entities.Identity;
using WebStoreGB.Interfaces.Services;

namespace WebStoreGB.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Role.Administrators)]
    public class ProductsController : Controller
    {
        private readonly IProductData _ProductData;
        public ProductsController(IProductData ProductData)
        {
            _ProductData = ProductData;
        }
        public IActionResult Index()
        {
            var products = _ProductData.GetProducts();
            return View(products.Products);
        }

        public IActionResult Edit(int id)
        {
            return RedirectToAction(nameof(View));
        }

        public IActionResult Delete(int id)
        {
            return RedirectToAction(nameof(View));
        }
    }
}
