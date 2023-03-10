using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStoreGB.Domain.Models;
using WebStoreGB.Interfaces.Services;
using WebStoreGB.Services.Data;

namespace WebStoreGB.Services.Services.InMemory
{
    public class InMemoryEmployeesData : IEmployeesData
    {
        private readonly ILogger<InMemoryEmployeesData> _Logger;
        private int _CurrentMaxId;
        public InMemoryEmployeesData(ILogger<InMemoryEmployeesData> logger)
        {
            _Logger = logger;
            _CurrentMaxId = TestData.Employees.Max(x => x.Id);
        }
        public int Add(Employee employee)
        {
            if (employee is null) throw new ArgumentNullException(nameof(employee));
            if (TestData.Employees.Contains(employee)) return employee.Id;

            employee.Id = ++_CurrentMaxId;
            TestData.Employees.Add(employee);

            _Logger.LogInformation("Сотрудник {0} успешно добавлен",employee);

            return employee.Id;
        }

        public bool Delete(int id)
        {
            var db_employee = GetById(id);
            if (db_employee is null)
            {
                _Logger.LogInformation("Сотрудник с id {0} не найден", id);
                return false;
            }
            TestData.Employees.Remove(db_employee);

            _Logger.LogInformation("Сотрудник {0} успешно удалён", db_employee);

            return true;
        }

        public IEnumerable<Employee> GetAll()
        {
            return TestData.Employees;
        }

        public Employee GetById(int id)
        {
            return TestData.Employees.SingleOrDefault(x => x.Id == id);
        }

        public void Update(Employee employee)
        {
            if (employee is null) throw new ArgumentNullException(nameof(employee));
            if (TestData.Employees.Contains(employee)) return; //удалить когда появится БД

            var db_employee = GetById(employee.Id);
            if (db_employee is null) return;

            db_employee.LastName = employee.LastName;
            db_employee.FirstName = employee.FirstName;
            db_employee.Patronymic = employee.Patronymic;
            db_employee.Age = employee.Age;

            _Logger.LogInformation("Сотрудник {0} успешно обновлён", employee);
        }
    }
}
