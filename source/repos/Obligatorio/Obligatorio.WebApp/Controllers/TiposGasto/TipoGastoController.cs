using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Obligatorio.LogicaAplicacion.dtos.TiposGasto;
using Obligatorio.LogicaAplicacion.dtos.Usuarios;
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

        private ICUGetByID<UsuarioDTOListado> _getUsuario;

        private UsuarioDTOListado usuarioActivo;
        public TipoGastoController(
            ICUAdd<TipoGastoDTOAlta> add,
            ICUGetAll<TipoGastoDTOListado> getAll,
            ICUGetByID<TipoGastoDTOListado> getByID,
            ICUDelete<TipoGastoDTOListado> delete,
            ICUUpdate<TipoGastoDTOAlta> update,
            ICUGetByID<UsuarioDTOListado> getUsuario
            )
        {
            _add = add;
            _getAll = getAll;
            _getByID = getByID;
            _delete = delete;
            _update = update;

            _getUsuario = getUsuario;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            int idUsuario = HttpContext.Session.GetInt32("IDUsuario") ?? -1;

            if (idUsuario == -1)
            {
                context.Result = RedirectToAction("Index", "Home");
            }
            else
            {
                usuarioActivo = _getUsuario.Execute(idUsuario);

                if (usuarioActivo.Tipo != "Administrador")
                {
                    context.Result = Redirect($"/{HttpContext.Session.GetString("TipoUsuario")}/Index");
                }
            }
        }

        public IActionResult Index()
        {
            return View(_getAll.Execute());
        }

        [HttpPost]
        public IActionResult Create(string nombreTipoGasto, string descripcionTipoGasto)
        {
            try
            {
                if (!string.IsNullOrEmpty(nombreTipoGasto) || !string.IsNullOrEmpty(descripcionTipoGasto))
                {
                    _add.Execute(new TipoGastoDTOAlta(
                        nombreTipoGasto,
                        descripcionTipoGasto
                    ));

                    TempData["msgType"] = "Success";
                    TempData["msg"] = "Tipo de Gasto agregado correctamente";
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult LoadUpdate(int ID)
        {
            try
            {
                return View("Update", _getByID.Execute(ID));
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Update(int idTipoGasto, string newNombre, string newDescripcion)
        {
            try
            {
                if (!string.IsNullOrEmpty(newNombre) && !string.IsNullOrEmpty(newDescripcion))
                {
                    _update.Execute(idTipoGasto, new TipoGastoDTOAlta(newNombre, newDescripcion));

                    TempData["msgType"] = "Success";
                    TempData["msg"] = $"Tipo de Gasto: {idTipoGasto} fue modificado correctamente";
                }
                else
                {
                    ViewBag.msg = "No se deben dejar campos sin completar.";
                    return View("Update", _getByID.Execute(idTipoGasto));
                }
            }
            catch (Exception ex)
            {
                ViewBag.msg = ex.Message;
                return View("Update", _getByID.Execute(idTipoGasto));
            }


            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int ID)
        {
            try
            {
                _delete.Execute(ID);

                TempData["msgType"] = "Success";
                TempData["msg"] = $"Tipo de Gasto: {ID} fue eliminado correctamente";

            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }

            return RedirectToAction("Index");
        }
    }
}
