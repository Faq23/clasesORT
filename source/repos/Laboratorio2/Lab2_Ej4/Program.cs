namespace Lab2_Ej4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int espectadores = r.Next(20000, 70000);

            Estadio e1 = new Estadio("Campeon Del Siglo", 40700);

            Console.WriteLine(e1.ToString());

            if (e1.CumpleCapacidad(espectadores))
            {
                Console.WriteLine($"El estadio cumple la capacidad para { espectadores } espectadores");
            } else
            {
                Console.WriteLine($"El estadio no cumple la capacidad para {espectadores} espectadores");
            }

            Console.ReadKey();
        }
    }
}
