// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using HireMe.Data;
using HireMe.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HireMe.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;


        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext context

            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        public bool IsEmployer => User.IsInRole("Employer");
        public bool JobSeeker => User.IsInRole("JobSeeker");
      
        public string Username { get; set; }
 
        [TempData]
        public string StatusMessage { get; set; }
 
        [BindProperty]
        public InputModel Input { get; set; }

        public List<Industry> Industries { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Phone]
            [Display(Name = "Phone Number")]
            public string PhoneNumber { get; set; }

            [Display(Name = "Company Name")]
            public string CompanyName { get; set; }

            [Display(Name = "Company Description")]
            public string CompanyDescription { get; set; }

            [Display(Name = "Industry")]
            public string Industry { get; set; }

            public string ProfessionalTitle { get; set; }
            public string Skills { get; set; }
            public string EducationalBackground { get; set; }

        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                FirstName = user.FirstName,
                LastName = user.LastName,
                CompanyName = user.CompanyName,
                CompanyDescription = user.CompanyDescription,
                Industry = user.Industry,
                ProfessionalTitle = user.ProfessionalTitle,
                Skills = user.Skills,
                EducationalBackground = user.EducationalBackground
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Industries = await _context.Industries.ToListAsync();

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }


              user.FirstName = Input.FirstName;
              user.LastName = Input.LastName;
            user.ProfessionalTitle = Input.ProfessionalTitle;
            user.Skills = Input.Skills;
            user.EducationalBackground = Input.EducationalBackground;

            if (IsEmployer)
              {
                  user.CompanyName = Input.CompanyName;
                  user.CompanyDescription = Input.CompanyDescription;
                  user.Industry = Input.Industry;
              }


            var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }

          
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
