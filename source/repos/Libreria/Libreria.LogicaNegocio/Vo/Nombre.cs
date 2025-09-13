using Libreria.LogicaNegocio.Excepciones;
using Libreria.LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.Vo
{
    public class Nombre : IValidar
    {
        public string Value { get; private set; }

        public Nombre(string value)
        {
            Value = value;

            Validar();
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Value))
            {
                throw new NombreException();
            }

        }
    }
}
