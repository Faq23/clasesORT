using Libreria.LogicaNegocio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.LogicaNegocio.Vo
{
    public class CantidadHabitantes
    {
        public int Value { get; private set; }

        public CantidadHabitantes(int value)
        {
            Value = value;

            Validar();
        }

        public void Validar()
        {
            if (Value <= 0)
            {
                throw new CantidadHabitantesException();
            }
        }
    }
}
