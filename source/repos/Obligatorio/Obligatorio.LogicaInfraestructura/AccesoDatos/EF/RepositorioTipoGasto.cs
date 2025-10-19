using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.LogicaInfraestructura.AccesoDatos.EF
{
    public class RepositorioTipoGasto : IRepositorioTipoGasto
    {
        private ObligatorioContext _context;

        public RepositorioTipoGasto(ObligatorioContext context)
        {
            _context = context;
        }
        public void Add(TipoGasto obj)
        {
            _context.TiposGasto.Add(obj);
            _context.SaveChanges();
        }

        public void Delete(int ID)
        {
            foreach (TipoGasto item in _context.TiposGasto)
            {
                if (item.ID == ID)
                {
                    _context.TiposGasto.Remove(item);
                    break;
                }
            }

            _context.SaveChanges();
        }

        public IEnumerable<TipoGasto> GetAll()
        {
            return _context.TiposGasto
                .ToList();
        }

        public TipoGasto GetByID(int ID)
        {
            return _context.TiposGasto.Single(tipoGasto => tipoGasto.ID == ID);
        }

        public void Update(int ID, TipoGasto obj)
        {
            foreach (TipoGasto item in _context.TiposGasto)
            {
                if (item.ID == ID)
                {
                    item.NombreGasto = obj.NombreGasto;
                    item.Descripcion = obj.Descripcion;
                    break;
                }
            }

            _context.SaveChanges();
        }
    }
}
