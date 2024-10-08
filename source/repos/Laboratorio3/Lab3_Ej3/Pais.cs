﻿using System;
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

        public Pais(string nombre, string codigo)
        {
            ID = LastID;
            LastID++;
            Nombre = nombre;
            Codigo = codigo;
            Validacion();
        }

        private void Validacion()
        {
            ValidarNombre();
            ValidarCodigo();
        }

        private void ValidarNombre()
        {
            if (Nombre == "") 
            {
                throw new Exception("No ha ingresado un Nombre");
            }
        }
        private void ValidarCodigo()
        {
            if (Codigo == "")
            {
                throw new Exception("No ha ingresado un Codigo");
            }
        }
    }
}
