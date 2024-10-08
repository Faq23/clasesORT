using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Ej3
{
    public class Estudiante
    {
        public int ID { get; set; }
        public static int LastID { get; set; } = 0;
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public double Promedio { get; set; }

        public Estudiante()
        {

        }

        public Estudiante(string nombre, string apellido, DateTime fechaNacimiento, double promedio)
        {
            ID = LastID;
            LastID++;
            Nombre = nombre;
            Apellido = apellido;
            FechaNacimiento = fechaNacimiento;
            Promedio = promedio;
        }

        public bool ExcelenciaAcademica()
        {
            bool result = false;

            if (Promedio > 95)
            {
                result = true;
            }

            return result;
        }

        public override string ToString()
        {
            return $"El estudiante { Nombre } { Apellido } tiene un promedio de { Promedio }";
        }
    }
}
