using Microsoft.AspNetCore.Mvc;

namespace GogoDriver.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Ajouter()
        {
            return View();
        }
        public IActionResult Modifier()
        {
            return View();
        }
        public IActionResult Supprimer()
        {
            return View();
        }
    }
}
