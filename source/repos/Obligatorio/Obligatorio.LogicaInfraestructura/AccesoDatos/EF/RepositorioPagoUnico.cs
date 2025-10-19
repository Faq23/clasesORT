using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaInfraestructura.AccesoDatos.EF
{
    public class RepositorioPagoUnico : IRepositorioPagoUnico
    {
        private ObligatorioContext _context;

        public RepositorioPagoUnico(ObligatorioContext context)
        {
            _context = context;
        }

        public void Add(PagoUnico obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public IEnumerable<PagoUnico> GetAll()
        {
            return _context.Pagos
                    .OfType<PagoUnico>()
                    .ToList();
        }

        public PagoUnico GetByID(int ID)
        {
            return _context.Pagos
                .OfType<PagoUnico>()
                .SingleOrDefault(pago => pago.ID == ID);
        }
    }
}

