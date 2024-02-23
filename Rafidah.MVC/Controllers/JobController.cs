using Microsoft.AspNetCore.Mvc;
using Rafidah.DAL.Context;

namespace Rafidah.MVC.Controllers
{
    public class JobController : Controller
    {
        AppDbContext _context;

		public JobController(AppDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
        {
            var job = _context.Jobs.ToList();
            return View(job);
        }
    }
}
