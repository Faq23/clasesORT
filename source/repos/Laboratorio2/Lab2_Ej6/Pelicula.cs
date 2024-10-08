using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Ej6
{
    public class Pelicula
    {
        public int ID { get; set; }
        public static int LastID { get; set; } = 0;
        public string Nombre { get; set; }
        public string Director { get; set; }
        public int Duracion { get; set; } // En minutos
        public static int MinDuracionLargometraje { get; set; } = 60; // En minutos
        
        public Pelicula() 
        { 
        }
        public Pelicula(string nombre, string director, int duracion)
        {
            ID = LastID;
            LastID++;
            Nombre = nombre;
            Director = director;
            Duracion = duracion;
        }

        public string DefinirTipoPelicula()
        {
            string message = "Es un cortometraje";

            if (Duracion >= MinDuracionLargometraje)
            {
                message = "Es un largometraje";
            }

            return message;
        }
    }
}
