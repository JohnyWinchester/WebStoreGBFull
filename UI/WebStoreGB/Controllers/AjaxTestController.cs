using log4net.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WebStoreGB.ViewModels;

namespace WebStoreGB.Controllers
{
    public class AjaxTestController : Controller
    {
        private readonly ILogger<AjaxTestController> _Logger;

        public AjaxTestController(ILogger<AjaxTestController> Logger)
        {
            _Logger = Logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetJSON(int? id, string msg, int Delay = 2000) 
        {
            _Logger.LogInformation("Получен запрос к GetJSON - id:{id}, msg:{msg}, Delay:{Delay}",id,msg,Delay);

            await Task.Delay(Delay);

            _Logger.LogInformation("Ответ на запрос к GetJSON - id:{id}, msg:{msg}, Delay:{Delay}", id, msg, Delay);
            return Json(new
            {
                Message = $"Response (id:{id ?? 0}): {msg ?? "--null--"}",
                ServerTime = DateTime.Now,
            });
        }

        public async Task<IActionResult> GetHTML(int? id, string msg, int Delay = 2000)
        {
            _Logger.LogInformation("Получен запрос к GetHTML - id:{id}, msg:{msg}, Delay:{Delay}", id, msg, Delay);

            await Task.Delay(Delay);

            _Logger.LogInformation("Ответ на запрос к GetHTML - id:{id}, msg:{msg}, Delay:{Delay}", id, msg, Delay);
            return PartialView("Partial/_DataView",new AjaxTestDataViewModel
            {
                Id = id ?? 0,
                Message= msg,
                Servertime= DateTime.Now,
            });
        }

        public IActionResult Chat() => View();
    }
}
