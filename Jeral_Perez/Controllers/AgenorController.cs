using Microsoft.AspNetCore.Mvc;

namespace Jeral_Perez.Controllers
{
    public class AgenorController : Controller
    {
        public IActionResult Index()
        {
            return View("Agenor");
        }
    }
}
