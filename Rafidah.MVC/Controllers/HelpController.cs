using Microsoft.AspNetCore.Mvc;

namespace Rafidah.MVC.Controllers
{
	public class HelpController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
