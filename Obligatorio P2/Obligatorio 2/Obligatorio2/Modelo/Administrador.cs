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

        #region Funciones Administrador

        public void CrearArticulos(string nombre, string categoria, double precio)
        {
            Sistema.Instance.AgregarArticulo(nombre, categoria, precio);
        }

        public void CrearPublicaciones(string nombre, List<Articulo> articulos, string tipoPublicacion)
        {
            switch (tipoPublicacion.ToLower())
            {
                case "venta":
                    double valorTotal = 0;

                    foreach (var articulo in articulos)
                    {
                        valorTotal += articulo.Precio;
                    }

                    Sistema.Instance.CrearPublicacion(nombre, articulos, valorTotal);
                    break;
                case "subasta":
                    Sistema.Instance.CrearPublicacion(nombre, articulos);
                    break;
                default:
                    throw new Exception("El tipo de Publicacion ingresado no es valido");
            }
        }

        public void ValidarSubasta(Subasta subasta)
        {
            Sistema.Instance.ValidarSubasta(subasta, this);
        }

        public void CancelarPublicacion(Publicacion publicacion)
        {
            Sistema.Instance.CancelarPublicacion(publicacion, this);
        }

        public void ModificarOfertaRel(Venta venta)
        {
            Sistema.Instance.ModificarOfertaRel(venta);
        }

        #endregion

        public override string ObtenerRol() { return "Administrador"; }
    }
}
