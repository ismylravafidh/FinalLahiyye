using Microsoft.AspNetCore.Mvc;

namespace Rafidah.MVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class JobController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
