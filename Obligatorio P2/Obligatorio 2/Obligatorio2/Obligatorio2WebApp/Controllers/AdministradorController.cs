using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Modelo;
using System.Runtime.ConstrainedExecution;

namespace Obligatorio2WebApp.Controllers
{
    public class AdministradorController : Controller
    {

        Sistema system = Sistema.Instance;
        Usuario usuarioActivo;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            int? adminID = HttpContext.Session.GetInt32("userID");
            usuarioActivo = system.ObtenerUsuarioPorID(adminID);

            if (usuarioActivo is null)
            {
                context.Result = RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.nombreUsuario = usuarioActivo.Nombre + " " + usuarioActivo.Apellido;

                ViewBag.msg = HttpContext.Session.GetString("msg");
                ViewBag.msgType = HttpContext.Session.GetString("msgType");
            }
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Publicacion()
        {
            return RedirectToAction("PublicacionAdmin", "Publicacion");
        }
        public IActionResult Subasta(int ID)
        {
            Publicacion? subastaSeleccionada = system.ObtenerPublicacionPorID(ID);

            return View(subastaSeleccionada);
        }

        [HttpPost]
        public IActionResult Subasta(string nombreSubasta, int ID)
        {
            Publicacion? subasta = system.ObtenerPublicacionPorID(ID);

            try
            {
                if(subasta.ObtenerPrecio() > 0)
                {
                    subasta.FinalizarPublicacion(usuarioActivo);
                    HttpContext.Session.SetString("msg", "La subasta fue cerrada.");
                } 
                else
                {
                    subasta.CancelarPublicacion(usuarioActivo);
                    HttpContext.Session.SetString("msg", "La subasta fue cancelada.");
                }

                HttpContext.Session.SetString("msgType", "Success");
                return RedirectToAction("PublicacionAdmin", "Publicacion");

            }
            catch (Exception ex)
            {
                HttpContext.Session.SetString("msg", ex.Message);
            }

            return View("Subasta", subasta.ID);
        }
    }
}
