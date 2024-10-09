using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Subasta : Publicacion
    {

        // Properties
        public List<Oferta> Ofertas { get; set; } = new List<Oferta>();

        //Constructores
        public Subasta() { }
        public Subasta(string nombre, List<Articulo> articulos) : base(nombre, articulos) { }

        // Metodos

        public void AgregarOferta(Cliente cliente, int monto)
        {
            Ofertas.Add(new Oferta(cliente, monto));
        }

        public override void FinalizarPublicacion(Usuario administrador)
        {
            Oferta mejorOferta = new Oferta();
            bool found = false;

            while (Ofertas.Count > 0 && !found)
            {

                foreach (Oferta o in Ofertas)
                {

                    if (o.Monto > mejorOferta.Monto)
                    {
                        mejorOferta = o;
                    }

                }

                if (mejorOferta.Cliente.Saldo >= mejorOferta.Monto)
                {
                    Cliente = mejorOferta.Cliente;
                    Usuario = administrador as Administrador;
                    FechaFin = DateTime.Now;
                    Estado = Estado.Cerrada;

                    found = true;
                }
                else
                {
                    Ofertas.Remove(mejorOferta);
                    mejorOferta = new Oferta();
                }

            }

            if (!found)
            {
                throw new Exception("Ninguna oferta pudo ser aceptada, la subasta continuará activa.");
            }
        }
    }
}
