using Microsoft.AspNetCore.Mvc;

namespace Obligatorio.WebApp.Controllers.Pagos
{
    public class PagoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
