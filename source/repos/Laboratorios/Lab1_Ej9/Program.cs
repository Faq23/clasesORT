namespace Lab1_Ej9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese una palabra: \n");

            string word = Console.ReadLine();
            string drow = "";

            Console.WriteLine($"{word.ToUpper()}\n{word.ToLower()}\n");



            for (int i = word.Length - 1; i >= 0; i--)
            {
                drow += word[i];
            }

            Console.WriteLine(drow);

            Console.ReadKey();
        }
    }
}
