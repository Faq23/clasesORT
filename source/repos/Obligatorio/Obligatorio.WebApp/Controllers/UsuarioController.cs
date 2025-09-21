using Microsoft.AspNetCore.Mvc;
using Obligatorio.LogicaAplicacion.dtos.Usuarios;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;

namespace Obligatorio.WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        private ICUAdd<UsuarioDTOAlta> _add;
        private ICUGetAll<UsuarioDTOListado> _getAll;
        private ICUGetByID<UsuarioDTOListado> _getByID;
        private ICUDelete<UsuarioDTOListado> _delete;

        public UsuarioController(
            ICUAdd<UsuarioDTOAlta> add,
            ICUGetAll<UsuarioDTOListado> getAll,
            ICUGetByID<UsuarioDTOListado> getByID,
            ICUDelete<UsuarioDTOListado> delete
            )
        {
            _add = add;
            _getAll = getAll;
            _getByID = getByID;
            _delete = delete;
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
            _add.Execute(new UsuarioDTOAlta(1, "Facundo", "Martinez", "password", "aaaa@aaaa.aaa"));
        }
    }
}
