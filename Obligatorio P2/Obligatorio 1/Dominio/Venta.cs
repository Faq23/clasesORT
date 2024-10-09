using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Venta : Publicacion
    {
        // Properties
        public bool OfertaRelampago { get; set; }
        public int Valor { get; set; }

        // Constructores
        public Venta() { }

        public Venta(string nombre, List<Articulo> listaArticulos, int valor) : base(nombre, listaArticulos)
        {
            OfertaRelampago = false;
            Valor = valor;
        }
        public override void FinalizarPublicacion(Usuario cliente)
        {
            Cliente comprador = cliente as Cliente;

            if (comprador.Saldo >= Valor)
            {
                Cliente = comprador;
                Usuario = comprador;
                FechaFin = DateTime.Now;
                Estado = Estado.Cerrada;
            }
            else
            {
                throw new Exception("No tiene Saldo suficiente para realizar la Compra");
            }

        }

        public void ModificarOferta()
        {
            if (!OfertaRelampago)
            {
                OfertaRelampago = true;
            }
            else
            {
                OfertaRelampago = false;
            }
        }
    }
}
