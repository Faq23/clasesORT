using Microsoft.AspNetCore.Mvc;
using Obligatorio.LogicaAplicacion.dtos.Auditorias;
using Obligatorio.LogicaAplicacion.dtos.Usuarios;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.WebApp.Models;
using System.Diagnostics;

namespace Obligatorio.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICUAdd<AuditoriaDTOAlta> _addAuditoria;
        private ICUGetByID<UsuarioDTOListado> _getUsuario;

        public HomeController(
            ILogger<HomeController> logger,
            ICUAdd<AuditoriaDTOAlta> addAuditoria,
            ICUGetByID<UsuarioDTOListado> getUsuario
            )
        {
            _logger = logger;
            _addAuditoria = addAuditoria;
            _getUsuario = getUsuario;
        }

        public IActionResult Index()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Usuario");
        }

        public IActionResult Logout()
        {
            int idUsuario = HttpContext.Session.GetInt32("IDUsuario") ?? -1;

            if (idUsuario != -1)
            {
                UsuarioDTOListado usuarioActivo = _getUsuario.Execute(idUsuario);

                _addAuditoria.Execute(new AuditoriaDTOAlta(
                        $"Logout usuario {usuarioActivo.ID}",
                        usuarioActivo.Email,
                        DateTime.Now
                    ));

                HttpContext.Session.Clear();
                Response.Cookies.Delete(".AspNetCore.Session");
            }

            return RedirectToAction("Login", "Usuario");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
