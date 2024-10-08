namespace Lab2_Ej8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Apartamento a1 = new Apartamento(1, 2, 3, Apartamento.Vistas.interior);
            Apartamento a2 = new Apartamento(2, 1, 6, Apartamento.Vistas.calle);
            Apartamento a3 = new Apartamento(3, 4, 10, Apartamento.Vistas.interior);

            Console.WriteLine(a1.ToString() + "\n");
            Console.WriteLine(a2.ToString() + "\n");
            Console.WriteLine(a3.ToString() + "\n");

            Apartamento.ValorBase = 1500;

            Console.WriteLine(a1.ToString() + "\n");
            Console.WriteLine(a2.ToString() + "\n");
            Console.WriteLine(a3.ToString() + "\n");

            Console.ReadKey();
        }
    }
}
