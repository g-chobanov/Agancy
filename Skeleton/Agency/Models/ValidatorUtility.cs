using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Agency.Models
{

    static class ValidatorUtility
    {
        public static void ValidateAnnotations(Object o)
        {
            var context = new ValidationContext(o, null, null);

            var result = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(o, context, result, true);
            if (!isValid)
            {
                throw new ArgumentException(result[0].ErrorMessage);
            }
        }
    }
}
