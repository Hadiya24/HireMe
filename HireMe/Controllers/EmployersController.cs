using HireMe.Data;
using HireMe.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HireMe.Controllers
{
    [Authorize(Roles = "Employer")]
    public class EmployersController : Controller
    {
        private readonly ApplicationDbContext _context;


        public EmployersController(ApplicationDbContext context) {
            _context = context;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); 
            var totalJobsByEmployer = await _context.Jobs.CountAsync(job => job.EmployerId == userId);  

            ViewBag.TotalJobsByEmployer = totalJobsByEmployer;

            return View();
        }
        
        public IActionResult PostJob()
        {
            return View();
        }
         
        [HttpPost]
        public async Task<IActionResult> PostJob(JobPostModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)??null;
                var job = new Job
                {
                    JobTitle = model.JobTitle,
                    JobDescription = model.JobDescription,
                    Location = model.Location,
                    EmploymentType = model.EmploymentType,
                    MinSalary = model.MinSalary,
                    MaxSalary = model.MaxSalary,
                    Deadline = model.Deadline,
                    PostedOn = DateTime.UtcNow,
                    Requirements = model.Requirements,
                    Tags = model.Tags,
                    Status =  JobStatus.Open,
                    EmployerId = userId

                };

                 _context.Jobs.Add(job);
                await _context.SaveChangesAsync();

                
                return RedirectToAction("JobPosted");
            }

             return View(model);
        }


        public IActionResult JobPosted()
        {
            return View();
        }


    }
}
