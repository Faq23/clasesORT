namespace Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion.Usuario
{
    public interface ICUEmailGenerator
    {
        string Execute(string firstPart, string lastPart);
    }
}
