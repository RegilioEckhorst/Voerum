using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Voerum.Models
{
    public class Symbols : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var recipes = (Recipes) validationContext.ObjectInstance;

            if (recipes.Name!=null)
            {
                if (recipes.Name.Contains("!") || recipes.Name.Contains("@"))
                {
                    return new ValidationResult("Deze symbolen zijn niet toegestaan");
                }
            }
           

            return ValidationResult.Success;
        }
    }
}