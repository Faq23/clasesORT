using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Cliente : Usuario
    {
        // Properties
        public double Saldo { get; set; }

        // Constructores
        public Cliente() { }
        public Cliente(double saldo, string nombre, string apellido, string email, string password) : base(nombre, apellido, email, password)
        {
            Saldo = saldo;
            ValidarSaldo();
        }

        // Métodos

        #region Validaciones

        private void ValidarSaldo()
        {
            if (Saldo < 0)
            {
                throw new Exception("El Cliente no puede tener Saldo negativo");
            }
        }

        #endregion

        #region Funciones Cliente

        public void RealizarCompra(Venta venta)
        {
            Sistema.Instance.AsociarCompra(venta, this);
        }

        public void CrearOferta(Subasta subasta, double monto)
        {
            Sistema.Instance.CrearOferta(subasta, monto, this);
        }

        #endregion

        public override string ObtenerRol() { return "Cliente"; }
    }
}
