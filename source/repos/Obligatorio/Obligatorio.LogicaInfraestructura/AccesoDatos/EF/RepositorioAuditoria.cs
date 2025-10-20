using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaInfraestructura.AccesoDatos.EF
{
    public class RepositorioAuditoria : IRepositorioAuditoria
    {
        ObligatorioContext _context;

        public RepositorioAuditoria(ObligatorioContext context)
        {
            _context = context;
        }

        public void Add(Auditoria obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
