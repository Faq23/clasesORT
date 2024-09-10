namespace Lab3_Ej1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Material madera = new Material("Madera", "Brasil");
                Mesa mesaMadera = new Mesa(120, 100, 150, madera, 1200);

                Console.WriteLine(mesaMadera.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }        

            Console.ReadKey();
        }
    }
}
