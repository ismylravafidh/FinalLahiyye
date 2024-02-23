using Microsoft.AspNetCore.Mvc;

namespace Rafidah.MVC.Controllers
{
	public class ContactController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
