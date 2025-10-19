namespace Obligatorio.LogicaInfraestructura.AccesoDatos.EF
{
    public class SeedData
    {
        private ObligatorioContext _context;

        public SeedData(ObligatorioContext context)
        {
            _context = context;
        }

        public void Run()
        {
            Console.WriteLine("Precarga de datos");
        }

    }
}
