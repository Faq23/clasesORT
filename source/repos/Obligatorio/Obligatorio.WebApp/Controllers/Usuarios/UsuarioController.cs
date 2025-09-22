using Microsoft.AspNetCore.Mvc;
using Obligatorio.LogicaAplicacion.CasosUso.Usuarios;
using Obligatorio.LogicaAplicacion.dtos.Equipos;
using Obligatorio.LogicaAplicacion.dtos.Usuarios;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.vo;

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

        private ICUAdd<EquipoDTOAlta> _r;

        public UsuarioController(
            ICUAdd<UsuarioDTOAlta> add,
            ICUGetAll<UsuarioDTOListado> getAll,
            ICUGetByID<UsuarioDTOListado> getByID,
            ICUDelete<UsuarioDTOListado> delete,
            ICUEmailGenerator generateEmail,
            LoginUsuario loginUsuario,
            ICUAdd<EquipoDTOAlta> r

            )
        {
            _add = add;
            _getAll = getAll;
            _getByID = getByID;
            _delete = delete;
            _generateEmail = generateEmail;
            _loginUsuario = loginUsuario;
            _r = r;
        }

        public void Index()
        {
            foreach (UsuarioDTOListado udto in _getAll.Execute())
            {
                Console.WriteLine($"{udto.ID} {udto.Nombre} {udto.Apellido} {udto.Email} {udto.Contrasena}");
            }
        }

        public void Create()
        {
            Equipo equipo = new Equipo(new NombreEquipo("Equipo2"));
            _r.Execute(new EquipoDTOAlta(equipo.Nombre.Value));

            string email = _generateEmail.Execute("Ana", "Sá");
            _add.Execute(new UsuarioDTOAlta("Ana", "Sá", "password", email, 2, equipo, "Administrador"));

            string email2 = _generateEmail.Execute("Fácundo", "Nuñez");
            _add.Execute(new UsuarioDTOAlta("Fácundo", "Nuñez", "password", email2, 2, equipo, "Empleado"));
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string emailUsuario, string contrasenaUsuario)
        {
            UsuarioDTOListado usuarioLogueado = _loginUsuario.Login(emailUsuario, contrasenaUsuario);
            HttpContext.Session.SetString("TipoUsuario", usuarioLogueado.Tipo);

            return RedirectToAction("Index", usuarioLogueado.Tipo);
        }
    }
}
