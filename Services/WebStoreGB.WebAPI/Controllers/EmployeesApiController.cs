using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStoreGB.Domain.Models;
using WebStoreGB.Interfaces;
using WebStoreGB.Interfaces.Services;

namespace WebStoreGB.WebAPI.Controllers
{
    [Route(WebAPIAddresses.Employees)]
    [ApiController]
    public class EmployeesApiController : ControllerBase
    {
        private readonly IEmployeesData _EmployeesData;

        public EmployeesApiController(IEmployeesData EmployeesData)
        {
            _EmployeesData = EmployeesData;
        }

        /// <summary>Получение всех сотрудников</summary>
        /// <returns>Список сотрудников</returns>
        [HttpGet]
        public IActionResult Get()
        {
            var employees = _EmployeesData.GetAll();
            return Ok(employees);
        }

        /// <summary>
        /// Получение сотрудника по его идентификатору
        /// </summary>
        /// <param name="id">Идентификатор сотрудника</param>
        /// <returns>Сотрудник с указанным идентификатором</returns>
        [HttpGet("{Id}")]
        //С помощью атрибутов документируем статусные коды 
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Employee))] // указываем статусный код который будет возвращаться и возвращаемое значение
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id) 
        {
            var employee = _EmployeesData.GetById(id);
            if(employee is null)
                return NotFound();

            return Ok(employee);
        }

        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            var id = _EmployeesData.Add(employee);
            return CreatedAtAction(nameof(GetById), new { id }, employee); // говорит что объект был создан на стороне сервиса и указывает по какому аддресу объект был создан
            //return Ok(id);
        }

        [HttpPut]
        public IActionResult Update(Employee employee)
        {
            _EmployeesData.Update(employee);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int id) 
        {
            var result = _EmployeesData.Delete(id);
            return result ? Ok(true) : NotFound(false);
        }
    }
}
