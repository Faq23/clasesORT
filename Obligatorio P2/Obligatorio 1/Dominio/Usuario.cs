using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        // Properties

        public int ID { get; set; }
        public static int LastID { get; set; } = 0;
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        // Constructores
        public Usuario() 
        {
            ID = LastID;
            LastID++;
        }
        public Usuario(string nombre, string apellido, string email, string password)
        {
            ID = LastID;
            LastID++;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Password = password;
            Validacion();
        }

        // Metodos

        private void Validacion()
        {
            ValidarNombre();
            ValidarApellido();
            ValidarEmail();
            ValidarPassword();
        }
        private void ValidarNombre()
        {
            string pattern = @"^[\p{L}\s']+$";

            if (string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("No ha ingresado un Nombre");
            } 
            else if (!Regex.IsMatch(Nombre, pattern))
            {
                throw new Exception("No ha ingresado un Nombre válido");
            }
        }
        private void ValidarApellido()
        {
            string pattern = @"^[\p{L}\s']+$";

            if (string.IsNullOrEmpty(Apellido))
            {
                throw new Exception("No ha ingresado un Apellido");
            }
            else if (!Regex.IsMatch(Apellido, pattern))
            {
                throw new Exception("No ha ingresado un Apellido válido");
            }
        }
        private void ValidarEmail() 
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"; // Esta expresión regular chequea que el formato de los correos sean correctos.

            if (string.IsNullOrEmpty(Email))
            {
                throw new Exception("No ha ingresado un Email");
            }
            else if (!Regex.IsMatch(Email, pattern))
            {
                throw new Exception("No ha ingresado un Email válido");
            }
        }
        private void ValidarPassword()
        {
            string pattern = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*[+=!$])(?=.*\d).{8,}$"; // Esta expresión regular valida que las contraseñas tengan al menos: Una Mayuscula, una Minuscula, un Numero y un Simbolo dentro de los permitidos (+,=,!,$)

            if (string.IsNullOrEmpty(Password))
            {
                throw new Exception("No ha ingresado una Contraseña");
            }
            else if (!Regex.IsMatch(Password, pattern))
            {
                throw new Exception("No ha ingresado un Contraseña válida, debe respetar el siguiente formato: \n Al menos una mayuscula \n Al menos una minuscula \n Al menos un número \n Al menos un caracter especial (+, =, !, $)");
            }
        }
    }
}
