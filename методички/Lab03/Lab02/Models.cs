using System;
using System.ComponentModel.DataAnnotations;

namespace Lab02
{
    public class Address
    {
        public string City { get; set; }
        
        [PostalCode]
        public string PostalCode { get; set; }
        
        public string Street { get; set; }
        public string House { get; set; }
        public string Apartment { get; set; }
    }

    public class WorkPlace
    {
        public string Company { get; set; }
        public string Position { get; set; }
        public int Experience { get; set; }
        public double Salary { get; set; }
    }

    public class Student
    {
        [Required(ErrorMessage = "ФИО студента обязательно для заполнения")]
        [RegularExpression(@"^[А-Яа-я\s]{2,50}$", ErrorMessage = "ФИО должно содержать только русские буквы и пробелы, длина от 2 до 50 символов")]
        public string FullName { get; set; }

        [Range(16, 100, ErrorMessage = "Возраст должен быть от 16 до 100 лет")]
        public int Age { get; set; }

        public string Specialization { get; set; }
        public DateTime BirthDate { get; set; }
        public int Course { get; set; }
        public string Group { get; set; }

        [Range(1.0, 10.0, ErrorMessage = "Средний балл должен быть от 1 до 10")]
        public double AverageGrade { get; set; }

        public string Gender { get; set; }
        public Address Address { get; set; }
        public WorkPlace WorkPlace { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Student other = (Student)obj;
            return FullName == other.FullName &&
                   BirthDate == other.BirthDate &&
                   Group == other.Group;
        }

    }
} 