using System;
using System.ComponentModel.DataAnnotations;

public class FutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is DateTime dateTimeValue)
        {
            if (dateTimeValue < DateTime.Today)
            {
                return new ValidationResult("The application deadline must be a future date.");
            }
        }
        else
        {
            return new ValidationResult("Invalid date.");
        }

        return ValidationResult.Success;
    }
}
