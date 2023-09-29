using Microsoft.AspNetCore.Mvc;

namespace GogoDriver.Controllers
{
	public class FormulaireController : Controller
	{
		public IActionResult index()
		{
			return View();
		}

		public IActionResult Chauffeur()
		{
			return View();
		}
	}
}
