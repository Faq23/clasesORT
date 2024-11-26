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
            else
            {
                ViewBag.msg = msg;
                ViewBag.msgType = msgType;
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            HttpContext.Session.Remove("msg");
            HttpContext.Session.Remove("msgType");
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("userRol") == "Administrador")
            {
                return RedirectToAction("PublicacionAdmin");
            }
            else
            {
                return RedirectToAction("Publicacion");
            }
            
        }

        public IActionResult Publicacion()
        {
            if (HttpContext.Session.GetString("userRol") == "Administrador")
            {
                return RedirectToAction("Index", "Administrador");
            }

            IEnumerable<Publicacion> listaPublicaciones = system.ObtenerPublicaciones();

            if (listaPublicaciones.Count() == 0)
            {
                ViewBag.msg = "No existen publicaciones para mostrar.";
            }

            return View(listaPublicaciones);
        }

        public IActionResult PublicacionAdmin()
        {
            if (HttpContext.Session.GetString("userRol") == "Cliente")
            {
                return RedirectToAction("Index", "Cliente");
            }

            IEnumerable<Publicacion> listaPublicaciones = system.ObtenerPublicacionesPorFechaPubli(); // Ordeno todas las publicaciones y mediante las vistas filtro para que sean unicamente las subastas.

            if (listaPublicaciones.Count() == 0)
            {
                ViewBag.msg = "No existen publicaciones para mostrar.";
            }

            return View(listaPublicaciones);
        }
    }
}
