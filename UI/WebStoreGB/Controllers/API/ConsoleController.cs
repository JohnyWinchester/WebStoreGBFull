using Microsoft.AspNetCore.Mvc;
using System;

namespace WebStoreGB.Controllers.API
{
    [ApiController,Route("api/[controller]")]
    public class ConsoleController : ControllerBase
    {
        [HttpGet("clear")]
        public void Clear(string id) => Console.Clear();

        [HttpGet("WriteLine")]
        public void WriteLine(string Message) => Console.WriteLine(Message);
    }
}
