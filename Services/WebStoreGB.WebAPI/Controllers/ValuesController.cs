using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebStoreGB.Interfaces;

namespace WebStoreGB.WebAPI.Controllers
{
    //если происходит запрос по этому аддресу, то вызывается метод Get()
    [Route(WebAPIAddresses.Values)]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly Dictionary<int, string> _Values = Enumerable.Range(1, 10)
            .Select(i => (Id: i, Value: $"Value-{i}"))
            .ToDictionary(v => v.Id, v => v.Value);

        public ValuesController()
        {
            // Через конструктор мы должны получить данные Dictionary _values, которым должен управлять какой-то сервис
        }

        //[HttpGet]
        //public IEnumerable<string> Get() => _Values.Values;

        //[HttpGet]
        //public ActionResult<string[]> Get() => _Values.Values.ToArray(); // <тип данных который хотите вернуть>

        //[HttpGet]
        //public ActionResult<string[]> Get() => Ok(_Values.Values.ToArray()); // <тип данных который хотите вернуть>

        // api/Values - ресурс, конечная точка

        [HttpGet]
        public IActionResult Get() => Ok(_Values.Values); //возвращаем 200 и объект который надо сериализовать

        [HttpGet("{Id}")] // ("{указываем какой параметр должен содержать метод, т.е те параметры которые мы будем указывать в аддресной строке}")
        public IActionResult GetById(int Id)
        {
            if(!_Values.ContainsKey(Id))
                return NotFound();

            return Ok(_Values[Id]);
        }

        [HttpGet("count")] // ("указываем маршрут")
        public IActionResult Count() => Ok(_Values.Count);

        [HttpPost]
        [HttpPost("add")] // можно указать несколько конечных точек, просто указав параметры
        public IActionResult Add([FromBody] string value)
        {
            var id = _Values.Count == 0 ? 1 : _Values.Keys.Max() + 1;
            _Values[id] = value;

            return CreatedAtAction(nameof(GetById), new {Id = id});
        }

        [HttpPut("{Id}")]
        public IActionResult Replace(int id, [FromBody] string value)
        {
            if(!_Values.ContainsKey(id))
              return NotFound();

            _Values[id] = value;
            return Ok();
        }

        [HttpDelete("Id")]
        public IActionResult Delete(int id) 
        {
            if (!_Values.ContainsKey(id))
                return NotFound();

            _Values[id].Remove(id);
            return Ok();
        }


    }
}
