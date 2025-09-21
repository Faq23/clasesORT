namespace Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion
{
    public interface ICUEmailGenerator
    {
        string Execute(string firstPart, string lastPart);
    }
}
