using Microsoft.AspNetCore.Mvc;
using WebStoreGB.Interfaces.TestAPI;

namespace WebStoreGB.Controllers
{
    public class WebAPIController : Controller
    {
        public WebAPIController(IValuesService ValueService)
        {
            _ValueService = ValueService;
        }

        private readonly IValuesService _ValueService;

        public IActionResult Index()
        {
            var values = _ValueService.GetAll();
            return View(values);
        }
    }
}
