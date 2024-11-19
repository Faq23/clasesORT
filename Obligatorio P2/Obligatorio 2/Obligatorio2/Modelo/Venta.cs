using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Venta : Publicacion
    {
        // Properties
        public bool OfertaRelampago { get; set; }
        public double Valor { get; set; }

        // Constructores
        public Venta() { }

        public Venta(string nombre, List<Articulo> listaArticulos, double valor) : base(nombre, listaArticulos)
        {
            OfertaRelampago = false;
            Valor = valor;
        }

        // Metodos

        public void ModificarOfertaRel()
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

        #region Polimorfismo
        public override void FinalizarPublicacion(Usuario usuario)
        {
            Cliente comprador = usuario as Cliente;

            if (comprador.Saldo >= Valor)
            {
                Cliente = comprador;
                Usuario = comprador;
                FechaFin = DateTime.Now;
                Estado = Estado.Cerrada;

                comprador.Saldo -= ObtenerPrecio();
            }
            else
            {
                throw new Exception("No tiene Saldo suficiente para realizar la Compra");
            }

        }

        public override double ObtenerPrecio()
        {
            return Valor;
        }
        public override string TipoPublicacion()
        {
            return "Venta";
        }

        #endregion
    }
}
