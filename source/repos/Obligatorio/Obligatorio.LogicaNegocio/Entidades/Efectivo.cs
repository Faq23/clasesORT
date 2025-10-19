namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Efectivo : MetodoPago
    {
        public Efectivo() : base() { }

        public override string ToString()
        {
            return "Efectivo";
        }
    }
}
