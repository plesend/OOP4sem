using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Lab02
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class PostalCodeAttribute : ValidationAttribute
    {
        public PostalCodeAttribute() : base("Почтовый индекс должен содержать 6 цифр")
        {
        }

        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            string postalCode = value.ToString().Replace(" ", "");
            return postalCode.Length == 6 && postalCode.All(char.IsDigit);
        }
    }
} 