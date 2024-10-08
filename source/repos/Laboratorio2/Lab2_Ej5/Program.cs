namespace Lab2_Ej5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pais p1 = new Pais("Uruguay", 598, "Pesos Uruguayos", 3426260, 176215);

            Console.WriteLine(p1.ToString());

            Console.ReadKey();

        }
    }
}
