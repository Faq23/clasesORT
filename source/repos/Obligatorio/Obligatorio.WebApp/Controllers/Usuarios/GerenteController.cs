using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Obligatorio.LogicaAplicacion.dtos.Usuarios;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;

namespace Obligatorio.WebApp.Controllers.Usuarios
{
    public class GerenteController : Controller
    {
        private ICUGetByID<UsuarioDTOListado> _getUsuario;
        private UsuarioDTOListado usuarioActivo;

        public GerenteController(
                ICUGetByID<UsuarioDTOListado> getUsuario
            )
        {
            _getUsuario = getUsuario;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);

            int idUsuario = HttpContext.Session.GetInt32("IDUsuario") ?? -1;

            if (idUsuario == -1)
            {
                context.Result = RedirectToAction("Index", "Home");
            }
            else
            {
                usuarioActivo = _getUsuario.Execute(idUsuario);

                if (usuarioActivo.Tipo != "Gerente")
                {
                    context.Result = Redirect($"/{HttpContext.Session.GetString("TipoUsuario")}/Index");
                }
                else
                {
                    ViewBag.nombreUsuario = usuarioActivo.Nombre + " " + usuarioActivo.Apellido;
                }
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
