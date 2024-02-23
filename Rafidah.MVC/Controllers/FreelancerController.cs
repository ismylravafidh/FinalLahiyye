using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rafidah.DAL.Context;

namespace Rafidah.MVC.Controllers
{
	public class FreelancerController : Controller
	{
		AppDbContext _context;
        public FreelancerController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
		{
			var r =_context.Users.Include(c=>c.Category).Include(c=>c.City).Include(c=>c.Country).Include(c=>c.HourlyRate).ToList();
			return View(r);
		}
		public IActionResult Detail(string id)
		{
			var r = _context.Users.Include(c => c.Category)
				.Include(g=>g.Gender)
				.Include(c => c.City)
				.Include(c => c.Country)
				.Include(c => c.HourlyRate)
				.Include(l=>l.Languages)
				.Include(l=>l.LanguagesLevel)
				.Include(e=>e.Educations)
				.Where(i=>i.Id == id).FirstOrDefault();
			return View(r);
		}
	}
}
