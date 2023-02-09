using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStoreGB.Domain.ViewModels
{
    public class EmployeeViewModel : IValidatableObject
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Имя не указано")]
        [Display(Name = "Имя")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Длина от 5 до 30 символов")]
        [RegularExpression(@"([А-ЯЁ][а-яё]+)|([A-Z][a-z]+)", ErrorMessage = "Неверный формат")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Фамилия не указана")]
        [Display(Name = "Фамилия")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Длина от 5 до 30 символов")]
        [RegularExpression(@"([А-ЯЁ][а-яё]+)|([A-Z][a-z]+)", ErrorMessage = "Неверный формат")]
        public string LastName { get; set; }

        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }

        [Display(Name = "Возраст")]
        [Range(18, 80, ErrorMessage = "Возраст должен быть от 18 до 80")]
        public int Age { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            switch (validationContext.MemberName)
            {
                //default: return Enumerable.Empty<ValidationResult>();
                default: return new[] { ValidationResult.Success };

                case nameof(Age):
                    if (Age < 18 || Age > 80)
                        return new[] { new ValidationResult("Возраст должен быть от 18 до 80", new[] { nameof(Age) }) };
                    return new[] { ValidationResult.Success };
            }
        }
    }
}
