using System.ComponentModel.DataAnnotations;

namespace HireMe.Models
{
    public class JobPostModel
    {
        [Required(ErrorMessage = "Job title is required")]
        public string JobTitle { get; set; }

        [Required(ErrorMessage = "Job description is required")]
        public string JobDescription { get; set; }

        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Employment type is required")]
        public string EmploymentType { get; set; }

        [Required(ErrorMessage = "Minimum salary is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Minimum salary must be greater than 0")]
        public int MinSalary { get; set; }

        [Required(ErrorMessage = "Maximum salary is required")]
        [SalaryRange]  
        public int MaxSalary { get; set; }

        [Required(ErrorMessage = "Application deadline is required")]
        [FutureDate]
        public DateTime Deadline { get; set; }

        [Required(ErrorMessage = "At least one requirement must be added.")]

        public string Requirements { get; set; }


        [Required(ErrorMessage = "At least one tag must be added.")]

        public string Tags { get; set; }
        
    }

}
