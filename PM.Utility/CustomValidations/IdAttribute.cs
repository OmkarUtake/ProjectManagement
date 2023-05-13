using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.Utility.CustomValidations
{
    public class IdAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //var obj = Activator.CreateInstance(value.GetType());
            var propertName = validationContext.DisplayName;
            var propertyValue = (int)value;

            if (propertyValue <= 0)
            {
                return new ValidationResult($"{propertName} cannot be 0");
            }
            return ValidationResult.Success;
        }
    }
}
