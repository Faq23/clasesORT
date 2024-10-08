using System.Numerics;

namespace Lab2_Ej3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Estudiante e1 = new Estudiante("Facundo", "Martinez", new DateTime(2002,11,23), 97);

            bool tieneExcelencia = e1.ExcelenciaAcademica();

            Console.WriteLine(e1.ToString());

            if (tieneExcelencia)
            {
                Console.WriteLine("Tiene Excelencia Academica");
            } else
            {
                Console.WriteLine("No tiene Excelencia Academica");
            }

            Console.ReadKey();
            
        }
    }
}
