using Microsoft.EntityFrameworkCore;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaInfraestructura.AccesoDatos.EF
{
    public class RepositorioPagoRecurrente : IRepositorioPagoRecurrente
    {
        private ObligatorioContext _context;

        public RepositorioPagoRecurrente(ObligatorioContext context)
        {
            _context = context;
        }

        public void Add(PagoRecurrente obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public IEnumerable<PagoRecurrente> GetAll()
        {
            return _context.Pagos
                    .OfType<PagoRecurrente>()
                    .Include(PagoRecurrente => PagoRecurrente.Usuario)
                    .Include(PagoRecurrente => PagoRecurrente.Usuario.Equipo)
                    .Include(PagoRecurrente => PagoRecurrente.TipoGastoAsociado)
                    .ToList();
        }

        public PagoRecurrente GetByID(int ID)
        {
            return _context.Pagos
            .OfType<PagoRecurrente>()
            .Include(PagoRecurrente => PagoRecurrente.Usuario)
            .Include(PagoRecurrente => PagoRecurrente.Usuario.Equipo)
            .Include(PagoRecurrente => PagoRecurrente.TipoGastoAsociado)
            .SingleOrDefault(pago => pago.ID == ID);
        }
    }
}

