using Obligatorio.LogicaAplicacion.dtos.Usuarios;
using Obligatorio.LogicaAplicacion.Mapper;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion.Usuario;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaAplicacion.CasosUso.Usuarios
{
    public class GetListaPorMonto : ICUListaMayorMonto<UsuarioDTOListadoConMonto>
    {
        private IRepositorioPagoUnico _repo; // Utilizo el repositorio de Pagos Unicos para armar la lista de Usuarios

        public GetListaPorMonto(IRepositorioPagoUnico repo)
        {
            _repo = repo;
        }
        public IEnumerable<UsuarioDTOListadoConMonto> Execute(int monto)
        {
            return UsuarioMapper.ToListDTOFromAnother(
                _repo.GetAll()
                .Where(p => p.MontoPago.Value >= monto)
                );
        }
    }
}
