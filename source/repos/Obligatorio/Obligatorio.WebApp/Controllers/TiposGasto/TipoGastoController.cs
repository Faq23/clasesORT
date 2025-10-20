using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Obligatorio.LogicaAplicacion.dtos.Auditorias;
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

        private ICUAdd<AuditoriaDTOAlta> _addAuditoria;

        private UsuarioDTOListado usuarioActivo;
        public TipoGastoController(
            ICUAdd<TipoGastoDTOAlta> add,
            ICUGetAll<TipoGastoDTOListado> getAll,
            ICUGetByID<TipoGastoDTOListado> getByID,
            ICUDelete<TipoGastoDTOListado> delete,
            ICUUpdate<TipoGastoDTOAlta> update,
            ICUGetByID<UsuarioDTOListado> getUsuario,
            ICUAdd<AuditoriaDTOAlta> addAuditoria
            )
        {
            _add = add;
            _getAll = getAll;
            _getByID = getByID;
            _delete = delete;
            _update = update;

            _getUsuario = getUsuario;

            _addAuditoria = addAuditoria;
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

                    _addAuditoria.Execute(new AuditoriaDTOAlta(
                        $"Se creo el Tipo Gasto para [Nombre: {nombreTipoGasto}, Descripcion: {descripcionTipoGasto}]",
                        usuarioActivo.Email,
                        DateTime.Now
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

                    _addAuditoria.Execute(new AuditoriaDTOAlta(
                        $"Se modificó el Tipo Gasto por [Nombre: {newNombre}, Descripcion: {newDescripcion}]",
                        usuarioActivo.Email,
                        DateTime.Now
                    ));

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

                _addAuditoria.Execute(new AuditoriaDTOAlta(
                    $"Se eliminó Tipo Gasto {ID}",
                    usuarioActivo.Email,
                    DateTime.Now
                ));

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
