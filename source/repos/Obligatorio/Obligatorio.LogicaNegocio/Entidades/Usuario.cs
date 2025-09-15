using Obligatorio.LogicaNegocio.InterfacesDominio;
using Obligatorio.LogicaNegocio.vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Usuario : IEntity, IValidable
    {
        public int ID { get; set; }
        public Nombre Nombre { get; set; }
        public string Apellido { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public Usuario(Nombre nombre, string apellido, string password, string email)
        {
            Nombre = nombre;
            Apellido = apellido;
            Password = password;
            Email = email;

            Validar();
        }

        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
