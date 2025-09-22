using Microsoft.AspNetCore.Mvc;
using Obligatorio.LogicaAplicacion.dtos.Equipos;
using Obligatorio.LogicaAplicacion.dtos.TiposGasto;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;

namespace Obligatorio.WebApp.Controllers.TiposGasto
{
    public class TipoGastoController : Controller
    {
        private ICUAdd<TipoGastoDTOAlta> _add;
        private ICUGetAll<TipoGastoDTOListado> _getAll;
        private ICUGetByID<TipoGastoDTOListado> _getByID;
        private ICUDelete<TipoGastoDTOListado> _delete;
        private ICUUpdate<TipoGastoDTOAlta> _update;

        private ICUAdd<EquipoDTOAlta> _r;

        public TipoGastoController(
            ICUAdd<TipoGastoDTOAlta> add,
            ICUGetAll<TipoGastoDTOListado> getAll,
            ICUGetByID<TipoGastoDTOListado> getByID,
            ICUDelete<TipoGastoDTOListado> delete,
            ICUUpdate<TipoGastoDTOAlta> update
            )
        {
            _add = add;
            _getAll = getAll;
            _getByID = getByID;
            _delete = delete;
            _update = update;
        }

        public IActionResult Index()
        {
            return View(_getAll.Execute());
        }

        [HttpPost]
        public IActionResult Create(string nombreTipoGasto, string descripcionTipoGasto)
        {
            if (!string.IsNullOrEmpty(nombreTipoGasto) || !string.IsNullOrEmpty(descripcionTipoGasto))
            {
                _add.Execute(new TipoGastoDTOAlta(
               nombreTipoGasto,
               descripcionTipoGasto
               ));
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult LoadUpdate(int ID)
        {
            return View("Update", _getByID.Execute(ID));
        }

        [HttpPost]
        public IActionResult Update(int idTipoGasto, string newNombre, string newDescripcion)
        {
            if (!string.IsNullOrEmpty(newNombre) || !string.IsNullOrEmpty(newDescripcion))
            {
                _update.Execute(idTipoGasto, new TipoGastoDTOAlta(newNombre, newDescripcion));
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int ID)
        {
            _delete.Execute(ID);

            return RedirectToAction("Index");
        }
    }
}
