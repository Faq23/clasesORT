using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Administrador : Usuario
    {
        // Constructores
        public Administrador() { }
        public Administrador(string nombre, string apellido, string email, string password) : base(nombre, apellido, email, password) { }

        // Metodos

        public override string ObtenerRol() { return "Administrador"; }
    }
}
