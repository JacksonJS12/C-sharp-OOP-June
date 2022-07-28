using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ValidationAttributes.Utilities
{
    public static class Validator 
    {
        public static bool IsValid(object obj)
        {
           // var validationContext = new ValidationContext(obj);
           // ICollection<ValidationResult> errors = new List<ValidationResult>();

           //return System.ComponentModel.DataAnnotations.Validator.TryValidateObject(obj, validationContext, errors);
        }
    }
}
