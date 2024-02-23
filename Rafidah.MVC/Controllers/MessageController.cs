using Microsoft.AspNetCore.Mvc;

namespace Rafidah.MVC.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
