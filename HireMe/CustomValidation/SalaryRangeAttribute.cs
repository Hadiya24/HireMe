using HireMe.Models;
using System.ComponentModel.DataAnnotations;

public class SalaryRangeAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var jobPostModel = (JobPostModel)validationContext.ObjectInstance;

        if (jobPostModel.MinSalary <= 0)
        {
            return new ValidationResult("Minimum salary must be greater than 0");
        }

        if (jobPostModel.MaxSalary < jobPostModel.MinSalary)
        {
            return new ValidationResult("Maximum salary should not be less than minimum salary");
        }

        return ValidationResult.Success;
    }
}
