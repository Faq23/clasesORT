using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Oferta
    {
        // Properties

        public int ID { get; set; }
        public static int LastID { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public int Monto { get; set; }

        // Constructores
        public Oferta() 
        {
            ID = LastID;
            LastID++;
        }

        public Oferta(Cliente cliente, int monto)
        {
            ID = LastID;
            LastID++;
            Cliente = cliente;
            FechaPublicacion = DateTime.Now;
            Monto = monto;
            ValidarMonto(Cliente.Saldo);
        }

        // Metodos

        private void ValidarMonto(int saldoCliente)
        {
            if (Monto < 1)
            {
                throw new Exception("El Monto a ofertar debe ser mayor a 0");
            }
            else if (Monto > saldoCliente) 
            {
                throw new Exception("No puedes ofertar un Monto mayor a tu Saldo disponible");
            }
        }
    }
}
