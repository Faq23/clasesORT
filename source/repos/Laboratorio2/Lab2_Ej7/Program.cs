namespace Lab2_Ej7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Producto[] products = new Producto[3];
            products[0] = new Producto("Ibuprofeno", Producto.Activos.ibuprofeno, 200, new DateTime(2023,09,15)); // Anio - Mes - Dia
            products[1] = new Producto("Paracetamol", Producto.Activos.paracetamol, 500, new DateTime(2023,04,15));
            products[2] = new Producto("Nurofen Plus", Producto.Activos.ibuprofeno, 200, new DateTime(2021,11,3));

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(products[i].ToString());
                Console.WriteLine($"Fecha de vencimiento: { products[i].FechaVencimiento() }"); // Lo muestra como Mes / Dia / Anio

                if (products[i].FechaVencimiento() < DateTime.Now)
                {
                    Console.WriteLine("El producto se encuentra vencido");
                }
            }

            Console.ReadKey();
        }
    }
}
