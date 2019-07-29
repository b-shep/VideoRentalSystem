using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoRentalSystem.Models
{
    public class StockIfLessThan1: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;

            return 
                movie.NumberInStock > 1
                ? ValidationResult.Success
                : new ValidationResult("There must be least 1 in stock");

        }

    }
}