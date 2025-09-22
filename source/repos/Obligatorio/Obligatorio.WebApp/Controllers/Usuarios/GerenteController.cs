using Microsoft.AspNetCore.Mvc;

namespace Obligatorio.WebApp.Controllers.Usuarios
{
    public class GerenteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
