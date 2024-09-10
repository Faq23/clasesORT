using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_Ej3
{
    public class Pais
    {
        public int ID { get; set; }
        public static int LastID { get; set; } = 0;
        public string Nombre { get; set; }
        public string Codigo { get; set; }

        public Pais()
        {
            ID = LastID;
            LastID++;
        }

    }
}
