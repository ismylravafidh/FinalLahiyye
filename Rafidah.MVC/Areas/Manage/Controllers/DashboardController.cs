using Microsoft.AspNetCore.Mvc;

namespace Rafidah.MVC.Areas.Manage.Controllers
{
	[Area("Manage")]
	public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Tables()
        {
            return View();
        }
    }
}
