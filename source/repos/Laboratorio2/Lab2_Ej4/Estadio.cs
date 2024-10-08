using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Ej4
{
    public class Estadio
    {
        public int ID { get; set; }
        public static int LastID { get; set; }
        public string Nombre { get; set; }
        public int Capacidad { get; set; }

        public Estadio()
        { 
        }

        public Estadio(string nombre, int capacidad)
        {
            ID = LastID;
            LastID++;
            Nombre = nombre;
            Capacidad = capacidad;
        }

        public bool CumpleCapacidad(int espectadores)
        {
            bool cumple = false;

            if (espectadores <= Capacidad)
            {
                cumple = true;
            }

            return cumple;
        }

        public override string ToString()
        {
            return $"El estadio { Nombre } tiene una capacidad para { Capacidad } espectadores";
        }
    }
}
