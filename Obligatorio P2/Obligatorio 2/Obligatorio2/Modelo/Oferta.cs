using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Oferta
    {
        // Properties
        public int ID { get; set; }
        public static int LastID { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public double Monto { get; set; }

        // Constructores
        public Oferta()
        {
            ID = LastID;
            LastID++;
        }

        public Oferta(Cliente cliente, double monto)
        {
            ID = LastID;
            LastID++;
            Cliente = cliente;
            FechaPublicacion = DateTime.Now;
            Monto = monto;
            ValidarMonto();
        }

        // Metodos

        #region Validaciones

        private void ValidarMonto()
        {
            if (Monto < 1)
            {
                throw new Exception("El Monto a ofertar debe ser mayor a 0");
            }
            else if (Monto > Cliente.Saldo)
            {
                throw new Exception("No puedes ofertar un Monto mayor a tu Saldo disponible");
            }
        }

        #endregion

        public override bool Equals(object? obj) // Reescribo esta funcion para poder definir cuando dos ofertas son iguales y asi poder utilizar la propiedad Remove de la lista _ofertas en Subasta.
        {
            if (obj is Oferta other)
            {
                return ID == other.ID;
            }

            return false;
        }
    }
}
