using Microsoft.AspNetCore.Mvc;
using HireMe.Data;
using HireMe.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HireMe.Controllers
{
    public class JobSeekersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobSeekersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var jobs = await _context.Jobs.Where(j => j.Status == JobStatus.Open).ToListAsync();
            return View(jobs);
        }

        public async Task<IActionResult> Details(int id)
        {
            var job = await _context.Jobs.FirstOrDefaultAsync(j => j.Id == id);
            if (job == null)
            {
                return NotFound();
            }
            return View(job);
        }

     
    }
}
