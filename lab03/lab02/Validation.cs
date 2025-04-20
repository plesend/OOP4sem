using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab02
{
    public class DomikiValidation
    {
        public static List<ValidationResult> GetValidationResults(object илиАдресИлиДом)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(илиАдресИлиДом);

            bool isvalid = Validator.TryValidateObject(илиАдресИлиДом, validationContext, validationResults, true);

            return validationResults;
        }
    }
    public class NotZeroAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            if (int.TryParse(value.ToString(), out int number))
            {
                return number != 0;
            }

            return false;
        }
    }
}
