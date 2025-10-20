using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.vo;

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
            LoadEquipo();
            LoadUsuario();
            LoadTipoGasto();
            LoadPago();
        }

        private void LoadEquipo()
        {
            if (!_context.Equipos.Any())
            {
                var equipos = new[]
                {
                    new Equipo(new NombreEquipo("Soporte Técnico")),
                    new Equipo(new NombreEquipo("Desarrollo de Software")),
                    new Equipo(new NombreEquipo("Administración")),
                };

                _context.Equipos.AddRange(equipos);

                _context.SaveChanges();
            }
        }

        private void LoadUsuario()
        {
            if (!_context.Usuarios.Any())
            {
                var soporte = _context.Equipos.FirstOrDefault(e => e.Nombre.Value == "Soporte Técnico");
                var desarrollo = _context.Equipos.FirstOrDefault(e => e.Nombre.Value == "Desarrollo de Software");
                var admin = _context.Equipos.FirstOrDefault(e => e.Nombre.Value == "Administración");

                var usuarios = new object[]
                {
                    new Administrador(
                        new Nombre("Ana"),
                        new Apellido("Sá"),
                        new Contrasena("hFn9ZGofWL"),
                        new Email("anasa@empresa.com"),
                        admin.ID,
                        admin),

                    new Gerente(
                        new Nombre("Valentina"),
                        new Apellido("Ribeiro"),
                        new Contrasena("NUkTC472ol"),
                        new Email("valrib@empresa.com"),
                        desarrollo.ID,
                        desarrollo),

                    new Empleado(
                        new Nombre("Facundo"),
                        new Apellido("Martínez"),
                        new Contrasena("DzlJ0Cry3E"),
                        new Email("facmar@empresa.com"),
                        soporte.ID,
                        soporte),

                    new Empleado(
                        new Nombre("Lucas"),
                        new Apellido("Pérez"),
                        new Contrasena("0iCNFnNLet"),
                        new Email("lucper@empresa.com"),
                        soporte.ID,
                        soporte),

                    new Gerente(
                        new Nombre("Santiago"),
                        new Apellido("Méndez"),
                        new Contrasena("qz7jCxRYum"),
                        new Email("sanmen@empresa.com"),
                        admin.ID,
                        admin)
                };

                _context.Usuarios.AddRange(usuarios.Cast<Usuario>());

                _context.SaveChanges();
            }
        }

        private void LoadTipoGasto()
        {
            if (!_context.TiposGasto.Any())
            {
                var tipos = new[]
                {
                    new TipoGasto(
                        new NombreGasto("Suministros de Oficina"),
                        new Descripcion("Compra de materiales de oficina como papel, tinta, carpetas, etc.")
                    ),
                    new TipoGasto(
                        new NombreGasto("Servicios Externos"),
                        new Descripcion("Contratación de servicios de terceros o freelancers.")
                    ),
                    new TipoGasto(
                        new NombreGasto("Infraestructura"),
                        new Descripcion("Gastos relacionados a servidores, hosting y hardware.")
                    ),
                    new TipoGasto(
                        new NombreGasto("Capacitación"),
                        new Descripcion("Cursos, talleres o certificaciones para empleados.")
                    ),
                    new TipoGasto(
                        new NombreGasto("Transporte"),
                        new Descripcion("Gastos de traslado, combustible o viajes de trabajo.")
                    )
                };

                _context.TiposGasto.AddRange(tipos);
                _context.SaveChanges();
            }
        }

        private void LoadPago()
        {
            if (!_context.Pagos.Any())
            {
                var gerente = _context.Usuarios.FirstOrDefault(u => u.Email.Value == "valrib@empresa.com");
                var empleado = _context.Usuarios.FirstOrDefault(u => u.Email.Value == "facmar@empresa.com");
                var tipoInfra = _context.TiposGasto.FirstOrDefault(t => t.NombreGasto.Value == "Infraestructura");
                var tipoServicios = _context.TiposGasto.FirstOrDefault(t => t.NombreGasto.Value == "Servicios Externos");
                var tipoTransporte = _context.TiposGasto.FirstOrDefault(t => t.NombreGasto.Value == "Transporte");

                if (gerente != null && empleado != null && tipoInfra != null && tipoServicios != null && tipoTransporte != null)
                {
                    // Pagos Recurrentes
                    var pagosRecurrentes = new[]
                    {
                        new PagoRecurrente(
                            new Credito(),
                            tipoInfra.ID,
                            tipoInfra,
                            gerente.ID,
                            gerente,
                            new DescripcionPago("Pago mensual de servidores cloud"),
                            new MontoPago(2000),
                            DateTime.Now.AddMonths(-3),
                            DateTime.Now.AddMonths(9)
                        ),
                        new PagoRecurrente(
                            new Credito(),
                            tipoServicios.ID,
                            tipoServicios,
                            empleado.ID,
                            empleado,
                            new DescripcionPago("Mantenimiento de sistemas externos"),
                            new MontoPago(1500),
                            DateTime.Now.AddMonths(-1),
                            DateTime.Now.AddMonths(11)
                        )
                    };

                    // Pagos Únicos
                    var pagosUnicos = new[]
                    {
                        new PagoUnico(
                            new Efectivo(),
                            tipoInfra.ID,
                            tipoInfra,
                            gerente.ID,
                            gerente,
                            new DescripcionPago("Compra de licencias de software"),
                            new MontoPago(3500),
                            DateTime.Now.AddDays(-15),
                            new NumeroRecibo(10045)
                        ),
                        new PagoUnico(
                            new Credito(),
                            tipoTransporte.ID,
                            tipoTransporte,
                            empleado.ID,
                            empleado,
                            new DescripcionPago("Viaje por conferencia de tecnología"),
                            new MontoPago(1200),
                            DateTime.Now.AddDays(-40),
                            new NumeroRecibo(10046)
                        )
                    };

                    _context.Pagos.AddRange(pagosRecurrentes);
                    _context.Pagos.AddRange(pagosUnicos);
                    _context.SaveChanges();
                }
            }
        }
    }
}
