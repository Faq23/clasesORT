using Libreria.LogicaNegocio.Excepciones;
using Libreria.LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.Entidades
{
    public class Pais : IEntity
    {
        public int ID { get; set; }
        public Nombre Nombre { get; set; }
        public CantidadHabitantes CantidadHabitantes { get; set; }
    }
}
