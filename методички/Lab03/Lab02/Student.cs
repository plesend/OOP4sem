using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Lab02
{
    public class Student
    {
        [Required(ErrorMessage = "ФИО обязательно для заполнения")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "ФИО должно содержать от 2 до 100 символов")]
        [RegularExpression(@"^[А-Яа-я\s]+$", ErrorMessage = "ФИО должно содержать только русские буквы и пробелы")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Возраст обязателен для заполнения")]
        [Range(16, 100, ErrorMessage = "Возраст должен быть от 16 до 100 лет")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Специальность обязательна для заполнения")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Специальность должна содержать от 2 до 100 символов")]
        public string Specialization { get; set; }

        [Required(ErrorMessage = "Курс обязателен для заполнения")]
        [Range(1, 6, ErrorMessage = "Курс должен быть от 1 до 6")]
        public int Course { get; set; }

        [Required(ErrorMessage = "Группа обязательна для заполнения")]
        [RegularExpression(@"^[А-Яа-я0-9-]+$", ErrorMessage = "Группа должна содержать только русские буквы, цифры и дефис")]
        public string Group { get; set; }

        [Required(ErrorMessage = "Средний балл обязателен для заполнения")]
        [Range(0, 5, ErrorMessage = "Средний балл должен быть от 0 до 5")]
        public double AverageGrade { get; set; }

        public string Gender { get; set; }

        public Address Address { get; set; }
        public WorkPlace WorkPlace { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(FullName))
            {
                yield return new ValidationResult("ФИО не может быть пустым", new[] { nameof(FullName) });
            }

            if (Age < 16 || Age > 100)
            {
                yield return new ValidationResult("Некорректный возраст", new[] { nameof(Age) });
            }

            if (string.IsNullOrEmpty(Specialization))
            {
                yield return new ValidationResult("Специальность не может быть пустой", new[] { nameof(Specialization) });
            }

            if (Course < 1 || Course > 6)
            {
                yield return new ValidationResult("Некорректный курс", new[] { nameof(Course) });
            }

            if (string.IsNullOrEmpty(Group))
            {
                yield return new ValidationResult("Группа не может быть пустой", new[] { nameof(Group) });
            }

            if (AverageGrade < 0 || AverageGrade > 5)
            {
                yield return new ValidationResult("Некорректный средний балл", new[] { nameof(AverageGrade) });
            }
        }
    }

    public class Address
    {
        [RegularExpression(@"^[А-Яа-я\s]+$", ErrorMessage = "Город должен содержать только русские буквы и пробелы")]
        public string City { get; set; }

        [Required(ErrorMessage = "Улица обязательна для заполнения")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Улица должна содержать от 2 до 100 символов")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Номер дома обязателен для заполнения")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Номер дома должен содержать от 1 до 10 символов")]
        public string House { get; set; }

        [Required(ErrorMessage = "Почтовый индекс обязателен для заполнения")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Почтовый индекс должен содержать 6 символов")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Номер квартиры обязателен для заполнения")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Номер квартиры должен содержать от 1 до 10 символов")]
        public string Apartment { get; set; }
    }

    public class WorkPlace
    {
        [Required(ErrorMessage = "Название компании обязательно для заполнения")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Название компании должно содержать от 2 до 100 символов")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Должность обязательна для заполнения")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Должность должна содержать от 2 до 100 символов")]
        public string Position { get; set; }
    }
} 