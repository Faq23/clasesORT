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
                    .ToList();
        }

        public PagoRecurrente GetByID(int ID)
        {
            return _context.Pagos
            .OfType<PagoRecurrente>()
            .SingleOrDefault(pago => pago.ID == ID);
        }
    }
}

