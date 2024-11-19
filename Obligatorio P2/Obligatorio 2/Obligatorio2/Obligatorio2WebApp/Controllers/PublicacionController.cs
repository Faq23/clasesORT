using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Modelo;

namespace Obligatorio2WebApp.Controllers
{
    public class PublicacionController : Controller
    {
        Sistema system = Sistema.Instance;
        Usuario? usuarioActivo;
        int? clientID;
        string? msg;
        string? msgType;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            clientID = HttpContext.Session.GetInt32("userID");
            usuarioActivo = system.ObtenerUsuarioPorID(clientID);

            msg = HttpContext.Session.GetString("msg");
            msgType = HttpContext.Session.GetString("msgType");

            if (usuarioActivo is null)
            {
                context.Result = RedirectToAction("Index", "Home");
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            HttpContext.Session.Remove("msg");
            HttpContext.Session.Remove("msgType");
        }

        public IActionResult Index()
        {
            return RedirectToAction("Publicacion");
        }

        public IActionResult Publicacion()
        {
            IEnumerable<Publicacion> listaPublicaciones = system.ObtenerPublicaciones();

            ViewBag.msg = msg;
            ViewBag.msgType = msgType;

            return View(listaPublicaciones);
        }

        public IActionResult PublicacionAdmin()
        {
            IEnumerable<Publicacion> listaPublicaciones = system.ObtenerPublicacionesPorFechaPubli();

            ViewBag.msg = msg;
            ViewBag.msgType = msgType;

            return View(listaPublicaciones);
        }
    }
}
