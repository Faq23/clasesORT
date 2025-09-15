using Microsoft.AspNetCore.Mvc;
using Obligatorio.LogicaAplicacion.dtos.Equipos;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;

namespace Obligatorio.WebApp.Controllers
{
    public class EquipoController : Controller
    {
        private ICUAdd<EquipoDTOAlta> _add;
        private ICUGetAll<EquipoDTOListado> _getAll;

        public EquipoController(
            ICUAdd<EquipoDTOAlta> add,
            ICUGetAll<EquipoDTOListado> getAll
            )
        {
            _add = add;
            _getAll = getAll;
        }

        public void Index()
        {
            foreach (EquipoDTOListado edto in _getAll.Execute())
            {
                Console.WriteLine($"{edto.ID} {edto.Nombre}");
            }
        }

        public void Create()
        {
            _add.Execute(new EquipoDTOAlta(1, "EquipoA"));
        }
    }
}
