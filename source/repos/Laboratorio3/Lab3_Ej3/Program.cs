namespace Lab3_Ej3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Pais uruguay = new Pais("Uruguay", "UYU");
                Director directora = new Director("Romina", "Lois", uruguay);
                Pelicula pelicula = new Pelicula("Pelicula nueva", Genero.thriller, directora, new DateTime(2023,01,09), 120);

                Console.WriteLine(pelicula.FechaBaja());

                if (pelicula.EsApta())
                {
                    Console.WriteLine("La pelicula es apta para menores");
                }
                else
                {
                    Console.WriteLine("La pelicula no es apta para menores");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
