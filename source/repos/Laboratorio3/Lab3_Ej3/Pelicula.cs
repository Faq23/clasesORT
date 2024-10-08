using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_Ej3
{
    public class Pelicula
    {
        public int ID { get; set; }
        public static int LastID { get; set; } = 0;
        public string Titulo { get; set; }
        public Genero Genero { get; set; }
        public Director Director { get; set; }
        public DateTime FechaLanzamiento { get; set; }
        public int Duracion { get; set; }

        public Pelicula() 
        {
            ID = LastID;
            LastID++;
        }
        public Pelicula(string titulo, Genero genero, Director director, DateTime fechaLanzamiento, int duracion)
        {
            ID = LastID;
            LastID++;
            Titulo = titulo;
            Genero = genero;
            Director = director;
            FechaLanzamiento = fechaLanzamiento;
            Duracion = duracion;
        }

        private void Validacion()
        {
           
        }
        private void ValidarTitulo()
        {
            if (Titulo == "")
            {
                throw new Exception("No ha ingresado un Titulo");
            }
        }
        private void ValidarDuracion()
        {
            if (Duracion <= 0)
            {
                throw new Exception("No ha ingresado una Duracion valida");
            }
        }

        public DateTime FechaBaja()
        {
            DateTime fechaBaja = FechaLanzamiento.AddMonths(3);

            return fechaBaja;
        }
        public bool EsApta() 
        {
            bool esApta = true;

            if (Genero == Genero.terror || Genero == Genero.suspenso || Genero == Genero.thriller) { esApta = false; }

            return esApta;
        }
    }
}
