namespace Lab2_Ej6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pelicula p1 = new Pelicula("Inception", "Christopher Nolan", 148);

            Console.WriteLine(p1.DefinirTipoPelicula());

            Pelicula.MinDuracionLargometraje = 160;

            Console.WriteLine(p1.DefinirTipoPelicula());

            Console.ReadKey();
        }
    }
}
