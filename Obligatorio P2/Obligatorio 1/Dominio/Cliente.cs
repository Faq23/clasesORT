using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Cliente : Usuario
    {

        // Properties
        public int Saldo { get; set; }

        // Constructores
        public Cliente() { }
        public Cliente(int saldo, string nombre, string apellido, string email, string password) : base(nombre, apellido, email, password)
        {
            Saldo = saldo;
            ValidarSaldo();
        }

        // Métodos

        private void ValidarSaldo()
        {
            if (Saldo < 0)  
            {
                throw new Exception("El Cliente no puede tener Saldo negativo");
            }
        }

        public void RealizarCompra(Venta venta)
        {
                Sistema.Instance.AsociarCompra(venta, this);
        }

        public void CrearOferta(Subasta subasta, int monto)
        {
            Sistema.Instance.CrearOferta(subasta, monto, this);
        }
    }
}
