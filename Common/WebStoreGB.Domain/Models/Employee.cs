using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStoreGB.Domain.Models
{
    /// <summary>
    /// Информация о сотруднике
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Имя сотрудника
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия сотрудника
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Отчество сотрудника
        /// </summary>
        public string Patronymic { get; set; }
        /// <summary>
        /// Возраст сотрудника
        /// </summary>
        public int Age { get; set; }

        public override string ToString() => $"[{Id}] {FirstName} {LastName} {Patronymic} ({Age})";
    }
    //public record Employee(int Id,string LastName,string FirstName,string Patronymic,int Age)
}
