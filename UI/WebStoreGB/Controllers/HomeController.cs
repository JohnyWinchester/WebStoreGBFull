using Microsoft.AspNetCore.Mvc;
using System;

namespace WebStoreGB.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() // http://localhost:5000/Home/Index
        {
            return View("Index");//Название представления
            //return Content("Home Controller");
        }

        public IActionResult Exception(string Message) => throw new InvalidOperationException(Message ?? "Ошибка в контроллере");

        //Перенести всю разметку и настроить меню(Shared Mainmenu)
        public IActionResult Blog() => View();
        public IActionResult BlogSingle() => View();
        public IActionResult Catalog() => View();
        public IActionResult Cart() => View();
        public IActionResult Checkout() => View();
        public IActionResult ContactUs() => View();
        public IActionResult Login() => View();
        public IActionResult ProductDetails() => View();
        public IActionResult Shop() => View();
        public IActionResult NotFound() => View();
        public IActionResult Status(string id)
        {
            if(id is null)
                throw new ArgumentNullException(nameof(id));

            switch (id)
            {
                default: return Content($"Status code ---{id}");
                case "404": return View("NotFound");
            }
        }
    }
}
