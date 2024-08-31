namespace Lab2_Ej1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mesa mesa = new Mesa(1.5, 1, 1.25, "Madera", 5000);

            Console.WriteLine(mesa.ToString());

            Console.ReadKey();
        }
    }
}
