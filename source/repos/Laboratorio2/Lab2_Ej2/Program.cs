namespace Lab2_Ej2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Televisor t1 = new Televisor("Panavox", "SC99", 32, true, 10, false);
            Televisor t2 = new Televisor("Samsung", "SamsungX3", 50, true, 15, false);

            Console.WriteLine(t1.Volume);
            t1.AlterarVolumen(-10);

            Console.WriteLine(t1.Volume);

            Console.WriteLine(t2.ObtenerStatus());
            t2.CambiarStatus();

            Console.WriteLine(t2.ObtenerStatus());

            Console.ReadKey();
        }
    }
}
