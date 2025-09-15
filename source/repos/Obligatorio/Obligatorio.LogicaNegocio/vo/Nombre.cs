using Obligatorio.LogicaNegocio.Excepciones;
using Obligatorio.LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.LogicaNegocio.vo
{
    public record Nombre : IValidable
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
