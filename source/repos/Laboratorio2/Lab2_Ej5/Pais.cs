using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Ej5
{
    public class Pais
    {
        public int ID { get; set; }
        public static int LastID { get; set; }
        public string Nombre { get; set; }
        public int Codigo { get; set; }
        public string Moneda { get; set; }
        public int Poblacion { get; set; }
        public int Area { get; set; }

        public Pais() 
        {
        }
        public Pais(string nombre, int codigo, string moneda, int poblacion, int area)
        {
            ID = LastID;
            LastID++;
            Nombre = nombre;
            Codigo = codigo;
            Moneda = moneda;
            Poblacion = poblacion;
            Area = area;
        }

        public double ObtenerDensidad()
        {
            return Poblacion / Area;
        }

        public override string ToString()
        {
            return $"El pais {Nombre} de {Poblacion} habitantes tiene una densidad de {ObtenerDensidad()} hab/km2";
        }
    }
}
