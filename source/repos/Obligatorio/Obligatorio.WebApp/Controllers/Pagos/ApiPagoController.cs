using Microsoft.AspNetCore.Mvc;
using Obligatorio.LogicaAplicacion.dtos.Pagos;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;

namespace Obligatorio.WebApp.Controllers.Pagos
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiPagoController : ControllerBase
    {
        private ICUGetByID<PagoRecurrenteDTOListado> _getByIDRecurrente;
        private ICUGetByID<PagoUnicoDTOListado> _getByIDUnico;

        public ApiPagoController(
                ICUGetByID<PagoRecurrenteDTOListado> getByIDRecurrente,
                ICUGetByID<PagoUnicoDTOListado> getByIDUnico
            )
        {
            _getByIDRecurrente = getByIDRecurrente;
            _getByIDUnico = getByIDUnico;
        }

        [HttpGet("{idPago}")]
        public IActionResult GetByID(int idPago)
        {
            try
            {
                PagoRecurrenteDTOListado recurrente = _getByIDRecurrente.Execute(idPago);
                PagoUnicoDTOListado unico = _getByIDUnico.Execute(idPago);

                if (idPago < 0)
                {
                    return BadRequest();
                }

                if (recurrente == null && unico == null)
                {
                    return NotFound();
                }
                else if (recurrente == null)
                {
                    return Ok(unico);
                }
                else if (unico == null)
                {
                    return Ok(recurrente);
                }


            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return NotFound();
        }
    }
}
