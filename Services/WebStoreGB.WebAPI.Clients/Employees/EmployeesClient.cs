
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading;
using WebStoreGB.Domain.Models;
using WebStoreGB.Interfaces;
using WebStoreGB.Interfaces.Services;
using WebStoreGB.WebAPI.Clients.Base;

namespace WebStoreGB.WebAPI.Clients.Employees
{
    public class EmployeesClient : BaseClient, IEmployeesData
    {
        public EmployeesClient(HttpClient Client) : base(Client, WebAPIAddresses.Employees)
        {

        }

        public int Add(Employee employee)
        {
            var response = Post(Address, employee); 
            var added_employee = response.Content.ReadFromJsonAsync<Employee>().Result; // добавленный объект находится внутри содержимого ответа
            if (added_employee is null)
                return -1;
            var id = added_employee.Id;
            return id;
        }

        public bool Delete(int id)
        {
            var response = Delete($"{Address}/{id}");
            var success = response.IsSuccessStatusCode;
            return success;
        }


        public IEnumerable<Employee> GetAll()
        {
            var employees = Get<IEnumerable<Employee>>(Address);
            return employees;
        }

        public Employee GetById(int id)
        {
            var result = Get<Employee>($"{Address}/{id}");
            return result;
        }

        public void Update(Employee employee)
        {
            Put(Address, employee);
        }
    }
}