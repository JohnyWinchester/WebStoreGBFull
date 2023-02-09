using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebStoreGB.Domain.Entities.Identity;
using WebStoreGB.Domain.Models;
using WebStoreGB.Domain.ViewModels;
using WebStoreGB.Interfaces.Services;

namespace WebStoreGB.Controllers
{
    //[Route("Employees/[action]/{id?}")]
    //[Route("Staff/[action]/{id?}")]
    [Authorize]
    public class EmployeesController : Controller
    {
        private readonly IEmployeesData _EmployeesData;
        private readonly ILogger<EmployeesController> _Logger;

        public EmployeesController(IEmployeesData employeesData, ILogger<EmployeesController> logger)
        {
            _EmployeesData = employeesData;
            _Logger = logger;
        }
        public IActionResult Index()
        {
            return View(_EmployeesData.GetAll());
        }
        public IActionResult Details(int id)
        {
            var employee = _EmployeesData.GetById(id);

            if (employee is null)
                return NotFound();

            return View(employee);
        }

        #region Edit
        [Authorize(Roles = Role.Administrators)]
        public IActionResult Edit(int? id)
        {
            if (id is null) return View(new EmployeeViewModel());

            var employee = _EmployeesData.GetById((int)id);

            if (employee is null)
                return NotFound();

            var model = new EmployeeViewModel
            {
                Id = employee.Id,
                Name = employee.FirstName,
                LastName = employee.LastName,
                Patronymic = employee.Patronymic,
                Age = employee.Age,
            };
            return View(model);
        }

        [Authorize(Roles = Role.Administrators)]
        [HttpPost]
        public IActionResult Edit(EmployeeViewModel model)
        {
            if (model.LastName == "Бубубуб")
                ModelState.AddModelError("", "Некоректная фамилия");

            if (!ModelState.IsValid) return View(model);

            var employee = new Employee
            {
                Id = model.Id,
                LastName = model.LastName,
                FirstName = model.Name,
                Patronymic = model.Patronymic,
                Age = model.Age,
            };

            if (employee.Id == 0) _EmployeesData.Add(employee);
            else _EmployeesData.Update(employee);

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Delete
        [Authorize(Roles = Role.Administrators)]
        public IActionResult Delete(int id)
        {
            if (id < 0) return BadRequest();

            var employee = _EmployeesData.GetById(id);

            if (employee is null)
                return NotFound();

            return View(new EmployeeViewModel
            {
                Id = employee.Id,
                Name = employee.FirstName,
                LastName = employee.LastName,
                Age = employee.Age,
                Patronymic = employee.Patronymic,
            });
        }

        [HttpPost]
        [Authorize(Roles = Role.Administrators)]
        public IActionResult DeleteConfirmed(int id)
        {
            _EmployeesData.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        #endregion

        [Authorize(Roles = Role.Administrators)]
        public IActionResult Create() => View("Edit", new EmployeeViewModel());
    }
}
