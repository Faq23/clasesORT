namespace Lab1_Ej10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese su E-Mail");
            string email = Console.ReadLine();

            int emailLength = email.Length;

            bool firstCondition = email.Contains("@") && email[emailLength - 1].ToString() != "@";
            bool secondCondition = email.Contains(".") && email[emailLength - 1].ToString() != "." && email[0].ToString() != ".";


            if (emailLength > 1 && firstCondition && secondCondition)
            {
                Console.WriteLine("El correo ingresado es valido");
            } else
            {
                Console.WriteLine("El correo ingresado no es valido");
            }

            Console.ReadKey();
        }
    }
}
