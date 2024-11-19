using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Subasta : Publicacion
    {
        // Properties
        private List<Oferta> _ofertas = new List<Oferta>();

        //Constructores
        public Subasta() { }
        public Subasta(string nombre, List<Articulo> articulos) : base(nombre, articulos) { }

        // Metodos

        public void AgregarOferta(Cliente cliente, double monto)
        {
            if (monto <= ObtenerPrecio())
            {
                throw new Exception("El monto debe ser mayor a la oferta más alta");
            } 
            else
            {
                _ofertas.Add(new Oferta(cliente, monto));
            }
        }

        public IEnumerable<Oferta> ObtenerOfertas() // Retorno un IEnumerable ya que la lista de ofertas no deberia poder modificarse por fuera de esta clase.
        {
            return _ofertas;
        }

        public Oferta ObtenerMejorOferta()
        {
            Oferta mejorOferta = new Oferta();
            double precioOferta = 0;

            foreach(Oferta o in _ofertas)
            {
                if (o.Monto > precioOferta)
                {
                    precioOferta += o.Monto;
                    mejorOferta = o;
                }
            }

            return mejorOferta;
        }

        #region Polimorfismo

        public override void FinalizarPublicacion(Usuario usuario)
        {
            Oferta mejorOferta = new Oferta();
            bool found = false;

            while (_ofertas.Count > 0 && !found)
            {

                foreach (Oferta o in _ofertas)
                {

                    if (o.Monto > mejorOferta.Monto)
                    {
                        mejorOferta = o;
                    }

                }

                if (mejorOferta.Cliente.Saldo >= mejorOferta.Monto)
                {
                    Cliente = mejorOferta.Cliente;
                    Usuario = usuario as Administrador;
                    FechaFin = DateTime.Now;
                    Estado = Estado.Cerrada;

                    found = true;
                }
                else
                {
                    _ofertas.Remove(mejorOferta);
                    mejorOferta = new Oferta();
                }

            }

            if (!found)
            {
                throw new Exception("Ninguna oferta pudo ser aceptada, la subasta continuará activa.");
            }
        }

        public override double ObtenerPrecio()
        {
            return ObtenerMejorOferta().Monto;
        }

        public override string TipoPublicacion()
        {
            return "Subasta";
        }

        #endregion
    }
}
