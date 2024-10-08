using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_Ej4
{
    public class Dueno
    {
        public int ID { get; set; }
        public static int LastID { get; set; }
        public string Nombre { get; set; }
        public string 

        public Dueno() 
        {
            ID = LastID;
            LastID++;
        }
    }
}
