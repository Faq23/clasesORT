using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Obligatorio.LogicaAplicacion.dtos.Auditorias;
using Obligatorio.LogicaAplicacion.dtos.Pagos;
using Obligatorio.LogicaAplicacion.dtos.TiposGasto;
using Obligatorio.LogicaAplicacion.dtos.Usuarios;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion.Pago;

namespace Obligatorio.WebApp.Controllers.Pagos
{
    public class PagoController : Controller
    {
        // Recurrente

        private ICUAdd<PagoRecurrenteDTOAlta> _addRecurrente;
        private ICUGetAll<PagoRecurrenteDTOListado> _recurrenteListado;
        private ICUPagoMensualList<PagoRecurrenteDTOListadoConSaldo> _recurrenteConSaldo;

        // Unico

        private ICUAdd<PagoUnicoDTOAlta> _addUnico;
        private ICUGetAll<PagoUnicoDTOListado> _unicoListado;
        private ICUPagoMensualList<PagoUnicoDTOListadoConSaldo> _unicoConSaldo;

        // Extras

        private ICUGetByID<UsuarioDTOListado> _getUsuario;
        private ICUGetByID<TipoGastoDTOListado> _getTipoGasto;
        private ICUGetAll<TipoGastoDTOListado> _getTiposGasto;
        private ICUAdd<AuditoriaDTOAlta> _addAuditoria;

        private UsuarioDTOListado usuarioActivo;


        public PagoController(
            ICUAdd<PagoRecurrenteDTOAlta> addRecurrente,
            ICUGetAll<PagoRecurrenteDTOListado> recurrenteListado,
            ICUAdd<PagoUnicoDTOAlta> addUnico,
            ICUGetAll<PagoUnicoDTOListado> unicoListado,
            ICUGetByID<UsuarioDTOListado> getUsuario,
            ICUGetByID<TipoGastoDTOListado> getTipoGasto,
            ICUGetAll<TipoGastoDTOListado> getTiposGasto,
            ICUPagoMensualList<PagoRecurrenteDTOListadoConSaldo> recurrenteConSaldo,
            ICUPagoMensualList<PagoUnicoDTOListadoConSaldo> unicoConSaldo,
            ICUAdd<AuditoriaDTOAlta> addAuditoria
            )
        {
            _addRecurrente = addRecurrente;
            _addUnico = addUnico;
            _recurrenteListado = recurrenteListado;
            _unicoListado = unicoListado;
            _recurrenteConSaldo = recurrenteConSaldo;
            _unicoConSaldo = unicoConSaldo;

            _getUsuario = getUsuario;
            _getTipoGasto = getTipoGasto;
            _getTiposGasto = getTiposGasto;
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

                if (usuarioActivo.Tipo != "Gerente" && context.ActionDescriptor.RouteValues["action"] == "ObtenerConSaldo")
                {
                    context.Result = Redirect($"/{HttpContext.Session.GetString("TipoUsuario")}/Index");
                }
                else if (usuarioActivo.Tipo != "Gerente"
                    && usuarioActivo.Tipo != "Administrador"
                    && context.ActionDescriptor.RouteValues["action"].Contains("Create"))
                {
                    context.Result = Redirect($"/{HttpContext.Session.GetString("TipoUsuario")}/Index");

                }
            }
        }

        public IActionResult Index()
        {
            ViewData["PagosRecurrentes"] = _recurrenteListado.Execute();
            ViewData["PagosUnicos"] = _unicoListado.Execute();
            ViewData["TiposGasto"] = _getTiposGasto.Execute();

            return View();
        }

        [HttpPost]
        public IActionResult CreateRecurrente(string descripcion, int monto, string metodoPago, int idTipoGasto, DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                if (HttpContext.Session.GetInt32("IDUsuario") != null)
                {
                    int idUsuario = HttpContext.Session.GetInt32("IDUsuario").Value;

                    _addRecurrente.Execute(new PagoRecurrenteDTOAlta(
                    descripcion,
                    monto,
                    idUsuario,
                    _getUsuario.Execute(idUsuario),
                    metodoPago,
                    idTipoGasto,
                    _getTipoGasto.Execute(idTipoGasto),
                    fechaInicio,
                    fechaFin
                    ));

                    _addAuditoria.Execute(new AuditoriaDTOAlta(
                        $"Se creo Pago Recurrente para [Descripcion: {descripcion}, " +
                        $"Monto: {monto}, Metodo de Pago: {metodoPago}, " +
                        $"Fecha Inicio: {fechaInicio}, Fecha Fin: {fechaFin}]",
                        usuarioActivo.Email,
                        DateTime.Now
                    ));

                    TempData["msgType"] = "Sucess";
                    TempData["msg"] = "Pago agregado correctamente";
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CreateUnico(string descripcion, int monto, string metodoPago, int idTipoGasto, DateTime fechaPago, int numeroRecibo)
        {
            try
            {
                if (HttpContext.Session.GetInt32("IDUsuario") != null)
                {
                    int idUsuario = HttpContext.Session.GetInt32("IDUsuario").Value;

                    _addUnico.Execute(new PagoUnicoDTOAlta(
                    descripcion,
                    monto,
                    idUsuario,
                    _getUsuario.Execute(idUsuario),
                    metodoPago,
                    idTipoGasto,
                    _getTipoGasto.Execute(idTipoGasto),
                    fechaPago,
                    numeroRecibo
                    ));

                    _addAuditoria.Execute(new AuditoriaDTOAlta(
                        $"Se creo Pago Unico para [Descripcion: {descripcion}, " +
                        $"Monto: {monto}, Metodo de Pago: {metodoPago}, " +
                        $"Fecha Pago: {fechaPago}, Numero de Recibo: {numeroRecibo}]",
                        usuarioActivo.Email,
                        DateTime.Now
                    ));

                    TempData["msgType"] = "Sucess";
                    TempData["msg"] = "Pago agregado correctamente";
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }

            return RedirectToAction("Index");
        }

        public IActionResult ObtenerConSaldo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ObtenerConSaldo(string fecha)
        {
            string[] parteFecha = fecha.Split("-");
            int month = int.Parse(parteFecha[1]);
            int year = int.Parse(parteFecha[0]);

            IEnumerable<PagoRecurrenteDTOListadoConSaldo> listaRecurrente = _recurrenteConSaldo.Execute(month, year);
            IEnumerable<PagoUnicoDTOListadoConSaldo> listaUnico = _unicoConSaldo.Execute(month, year);

            if (!listaRecurrente.Any() && !listaUnico.Any())
            {
                _addAuditoria.Execute(new AuditoriaDTOAlta(
                    $"No se obtuvieron datos para la Fecha: {month} / {year}",
                    usuarioActivo.Email,
                    DateTime.Now
                ));

                TempData["msg"] = "No se encontraron Pagos para la fecha seleccionada";
            }
            else
            {
                ViewData["PagosRecurrentes"] = listaRecurrente;
                ViewData["PagosUnicos"] = listaUnico;

                _addAuditoria.Execute(new AuditoriaDTOAlta(
                    $"Se obtuvieron datos para la Fecha: {month} / {year}",
                    usuarioActivo.Email,
                    DateTime.Now
                ));
            }

            return View();
        }
    }
}
