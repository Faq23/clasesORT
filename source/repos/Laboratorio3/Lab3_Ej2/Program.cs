namespace Lab3_Ej2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Pais uruguay = new Pais("Uruguay", "UYU");
                Marca Samsung = new Marca("Samsung", uruguay);
                Televisor t1 = new Televisor(Samsung, "SM0304", Tamano.SM, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
