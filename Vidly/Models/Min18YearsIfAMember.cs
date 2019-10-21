using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsIfAMember:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Customer customer = (Customer) validationContext.ObjectInstance;

            if (customer.MemberShipTypeId == 0 || customer.MemberShipTypeId == 1)
            {
                return ValidationResult.Success;
            }

            if ( customer.Birthdate == null)
            {
                return new ValidationResult("Birthdate is required");
            }

            int age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer should be at least 18 to go on a membership");
        }
    }
}