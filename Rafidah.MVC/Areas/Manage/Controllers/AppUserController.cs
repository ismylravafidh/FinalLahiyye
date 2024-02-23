using Microsoft.AspNetCore.Mvc;
using Rafidah.DAL.Context;

namespace Rafidah.MVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class AppUserController : Controller
    {
        AppDbContext _context;

        public AppUserController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var r = _context.Users.ToList();
            return View(r);
        }
    }
}
