using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Validations
{
    public class Shirt_EnsureCorrectSizingAttribute :  ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
            {

                var shirt=validationContext.ObjectInstance as Shirt;
                if (shirt != null && !string.IsNullOrWhiteSpace(shirt.Gender))
                {
                    if (shirt.Gender.Equals("men",StringComparison.OrdinalIgnoreCase) && shirt.Size <8)
                    {
                        return new ValidationResult("for men size should be greater than 8");
                    }
                    else if (shirt.Gender.Equals("women",StringComparison.OrdinalIgnoreCase) && shirt.Size <6)
                    {
                        return new ValidationResult("for women size should be greater than 6");
                    }
                    else
                    {
                        return ValidationResult.Success;
                    }
                }
                return ValidationResult.Success;

            }
        

        
    }
}