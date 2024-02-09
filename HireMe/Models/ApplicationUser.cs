    using Microsoft.AspNetCore.Identity;
namespace HireMe.Models
{

    public class ApplicationUser : IdentityUser
    {      
        
        public string AccountType { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string? ProfessionalTitle { get; set; }
        public string? Skills { get; set; }
        public string? EducationalBackground { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyDescription { get; set; }
        public string? Industry { get; set; }

    }

}
