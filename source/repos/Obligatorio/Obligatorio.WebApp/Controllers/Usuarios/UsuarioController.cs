using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Obligatorio.LogicaAplicacion.CasosUso.Usuarios;
using Obligatorio.LogicaAplicacion.dtos.Auditorias;
using Obligatorio.LogicaAplicacion.dtos.Equipos;
using Obligatorio.LogicaAplicacion.dtos.Usuarios;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion.Usuario;

namespace Obligatorio.WebApp.Controllers.Usuarios
{
    public class UsuarioController : Controller
    {
        private ICUAdd<UsuarioDTOAlta> _add;
        private ICUGetAll<UsuarioDTOListado> _getAll;
        private ICUGetByID<UsuarioDTOListado> _getByID;
        private ICUDelete<UsuarioDTOListado> _delete;
        private ICUEmailGenerator _generateEmail;
        private LoginUsuario _loginUsuario;
        private ICUListaMayorMonto<UsuarioDTOListadoConMonto> _getPorMonto;

        private ICUGetByID<EquipoDTOListado> _getEquipo;
        private ICUGetAll<EquipoDTOListado> _getEquipos;

        private ICUAdd<AuditoriaDTOAlta> _addAuditoria;

        private UsuarioDTOListado usuarioActivo;

        public UsuarioController(
            ICUAdd<UsuarioDTOAlta> add,
            ICUGetAll<UsuarioDTOListado> getAll,
            ICUGetByID<UsuarioDTOListado> getByID,
            ICUDelete<UsuarioDTOListado> delete,
            ICUEmailGenerator generateEmail,
            LoginUsuario loginUsuario,
            ICUListaMayorMonto<UsuarioDTOListadoConMonto> getPorMonto,
            ICUGetByID<EquipoDTOListado> getEquipo,
            ICUGetAll<EquipoDTOListado> getEquipos,
            ICUAdd<AuditoriaDTOAlta> addAuditoria
            )
        {
            _add = add;
            _getAll = getAll;
            _getByID = getByID;
            _delete = delete;
            _generateEmail = generateEmail;
            _loginUsuario = loginUsuario;
            _getPorMonto = getPorMonto;
            _getEquipo = getEquipo;
            _getEquipos = getEquipos;
            _addAuditoria = addAuditoria;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            int idUsuario = HttpContext.Session.GetInt32("IDUsuario") ?? -1;

            if (idUsuario != -1)
            {
                usuarioActivo = _getByID.Execute(idUsuario);

                if (usuarioActivo.Tipo != "Gerente" && context.ActionDescriptor.RouteValues["action"] == "MostrarPorMonto")
                {
                    context.Result = Redirect($"/{HttpContext.Session.GetString("TipoUsuario")}/Index");
                }
                else if (usuarioActivo.Tipo != "Gerente"
                    && usuarioActivo.Tipo != "Administrador"
                    && context.ActionDescriptor.RouteValues["action"] == "Create")
                {
                    context.Result = Redirect($"/{HttpContext.Session.GetString("TipoUsuario")}/Index");
                }
            }
            else if (idUsuario == -1 && context.ActionDescriptor.RouteValues["action"] != "Login")
            {
                context.Result = RedirectToAction("Login", "Usuario");
            }
        }

        public IActionResult Index()
        {
            ViewData["listaEquipos"] = _getEquipos.Execute();

            return View(_getAll.Execute());
        }

        [HttpPost]
        public IActionResult Create(string nombre, string apellido, string contrasena, int idEquipo, string tipo)
        {
            try
            {
                if (!string.IsNullOrEmpty(nombre) &&
                    !string.IsNullOrEmpty(apellido) &&
                    !string.IsNullOrEmpty(contrasena) &&
                    idEquipo >= 0 &&
                    !string.IsNullOrEmpty(tipo))
                {
                    _add.Execute(new UsuarioDTOAlta(
                            nombre,
                            apellido,
                            contrasena,
                            _generateEmail.Execute(nombre, apellido),
                            idEquipo,
                            _getEquipo.Execute(idEquipo),
                            tipo));

                    _addAuditoria.Execute(new AuditoriaDTOAlta(
                        $"Se creo el usuario para [Nombre: {nombre}, Apellido: {apellido}]",
                        usuarioActivo.Email,
                        DateTime.Now
                    ));
                }
                else
                {
                    TempData["msg"] = "Se deben completar todos los campos.";
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }

            return RedirectToAction("Index");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string emailUsuario, string contrasenaUsuario)
        {
            try
            {
                UsuarioDTOListado usuarioLogueado = _loginUsuario.Login(emailUsuario, contrasenaUsuario);

                if (usuarioLogueado != null)
                {
                    HttpContext.Session.SetString("TipoUsuario", usuarioLogueado.Tipo);
                    HttpContext.Session.SetInt32("IDUsuario", usuarioLogueado.ID);

                    _addAuditoria.Execute(new AuditoriaDTOAlta(
                        $"Login Usuario {usuarioLogueado.ID}",
                        usuarioLogueado.Email,
                        DateTime.Now
                    ));

                    return Redirect($"/{usuarioLogueado.Tipo}/Index");
                }
                else
                {
                    TempData["msg"] = "No se encontró ningún usuario.";
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }

            return RedirectToAction("Login", "Usuario");
        }

        public IActionResult MostrarPorMonto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MostrarPorMonto(int monto)
        {
            try
            {
                IEnumerable<UsuarioDTOListadoConMonto> usuariosObtenidos = _getPorMonto.Execute(monto);

                if (usuariosObtenidos.Any())
                {
                    _addAuditoria.Execute(new AuditoriaDTOAlta(
                        $"Usuario {usuarioActivo.ID} cargó lista Usuarios por Monto >= {monto}",
                        usuarioActivo.Email,
                        DateTime.Now
                    ));

                    return View(_getPorMonto.Execute(monto));
                }

                _addAuditoria.Execute(new AuditoriaDTOAlta(
                    $"Usuario {usuarioActivo.ID} no trajo datos en lista Usuarios por Monto >= {monto}",
                    usuarioActivo.Email,
                    DateTime.Now
                ));

                TempData["msg"] = "No se encontraron usuarios";

            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }

            return View();
        }
    }
}
