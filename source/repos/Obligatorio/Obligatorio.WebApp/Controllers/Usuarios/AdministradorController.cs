using Microsoft.AspNetCore.Mvc;

namespace Obligatorio.WebApp.Controllers.Usuarios
{
    public class AdministradorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
