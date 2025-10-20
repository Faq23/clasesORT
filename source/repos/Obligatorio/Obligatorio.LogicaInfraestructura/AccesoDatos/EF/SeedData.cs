using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.vo.Equipo;
using Obligatorio.LogicaNegocio.vo.Pago;
using Obligatorio.LogicaNegocio.vo.TipoGasto;
using Obligatorio.LogicaNegocio.vo.Usuario;

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
            new Equipo(new NombreEquipo("Infraestructura")),
            new Equipo(new NombreEquipo("Recursos Humanos")),
            new Equipo(new NombreEquipo("Ventas")),
            new Equipo(new NombreEquipo("Atención al Cliente")),
            new Equipo(new NombreEquipo("Marketing")),
            new Equipo(new NombreEquipo("Seguridad Informática")),
            new Equipo(new NombreEquipo("Investigación y Desarrollo")),
        };

                _context.Equipos.AddRange(equipos);
                _context.SaveChanges();
            }
        }

        private void LoadUsuario()
        {
            if (!_context.Usuarios.Any())
            {
                var equipos = _context.Equipos.ToList();

                var usuarios = new Usuario[]
                {
            new Administrador(new Nombre("Ana"), new Apellido("Sá"), new Contrasena("hFn9ZGofWL"),
                new Email("anasa@laempresa.com"), equipos[2].ID, equipos[2]),

            new Gerente(new Nombre("Valentina"), new Apellido("Ribeiro"), new Contrasena("NUkTC472ol"),
                new Email("valrib@laempresa.com"), equipos[1].ID, equipos[1]),

            new Empleado(new Nombre("Facundo"), new Apellido("Martínez"), new Contrasena("DzlJ0Cry3E"),
                new Email("facmar@laempresa.com"), equipos[0].ID, equipos[0]),

            new Empleado(new Nombre("Lucas"), new Apellido("Pérez"), new Contrasena("0iCNFnNLet"),
                new Email("lucper@laempresa.com"), equipos[0].ID, equipos[0]),

            new Gerente(new Nombre("Santiago"), new Apellido("Méndez"), new Contrasena("qz7jCxRYum"),
                new Email("sanmen@laempresa.com"), equipos[2].ID, equipos[2]),

            new Empleado(new Nombre("Paula"), new Apellido("Gómez"), new Contrasena("pT5rA9KfLq"),
                new Email("paugom@laempresa.com"), equipos[3].ID, equipos[3]),

            new Administrador(new Nombre("Mario"), new Apellido("López"), new Contrasena("Lo89JqZtR1"),
                new Email("marlo@laempresa.com"), equipos[4].ID, equipos[4]),

            new Gerente(new Nombre("Elena"), new Apellido("Costa"), new Contrasena("We7iO0AsDp"),
                new Email("elecos@laempresa.com"), equipos[5].ID, equipos[5]),

            new Empleado(new Nombre("Federico"), new Apellido("Alonso"), new Contrasena("Mi8tX3LpRq"),
                new Email("fedalo@laempresa.com"), equipos[6].ID, equipos[6]),

            new Empleado(new Nombre("Lucía"), new Apellido("Fernández"), new Contrasena("aR4bE9QwH7"),
                new Email("lucfer@laempresa.com"), equipos[7].ID, equipos[7]),
                };

                _context.Usuarios.AddRange(usuarios);
                _context.SaveChanges();
            }
        }

        private void LoadTipoGasto()
        {
            if (!_context.TiposGasto.Any())
            {
                var tipos = new[]
                {
                    new TipoGasto(new NombreGasto("Suministros de Oficina"), new Descripcion("Compra de materiales de oficina.")),
                    new TipoGasto(new NombreGasto("Servicios Externos"), new Descripcion("Contratación de servicios de terceros.")),
                    new TipoGasto(new NombreGasto("Infraestructura"), new Descripcion("Gastos relacionados a servidores y hardware.")),
                    new TipoGasto(new NombreGasto("Capacitación"), new Descripcion("Cursos o talleres para empleados.")),
                    new TipoGasto(new NombreGasto("Transporte"), new Descripcion("Traslados o viajes de trabajo.")),
                    new TipoGasto(new NombreGasto("Publicidad"), new Descripcion("Campañas de marketing y difusión.")),
                    new TipoGasto(new NombreGasto("Eventos Corporativos"), new Descripcion("Reuniones y eventos empresariales.")),
                    new TipoGasto(new NombreGasto("Software"), new Descripcion("Compra o suscripción de herramientas digitales.")),
                    new TipoGasto(new NombreGasto("Comunicaciones"), new Descripcion("Telefonía, internet y servicios de red.")),
                    new TipoGasto(new NombreGasto("Mantenimiento"), new Descripcion("Reparaciones y mantenimiento general.")),
                };

                _context.TiposGasto.AddRange(tipos);
                _context.SaveChanges();
            }
        }

        private void LoadPago()
        {
            if (!_context.Pagos.Any())
            {
                var usuarios = _context.Usuarios.Take(5).ToList();
                var tipos = _context.TiposGasto.Take(5).ToList();

                var pagosRecurrentes = new[]
                {
            new PagoRecurrente(new Credito(), tipos[0].ID, tipos[0], usuarios[0].ID, usuarios[0],
                new DescripcionPago("Pago mensual de servidores cloud"), new MontoPago(2000),
                DateTime.Now.AddMonths(-3), DateTime.Now.AddMonths(9)),

            new PagoRecurrente(new Credito(), tipos[1].ID, tipos[1], usuarios[1].ID, usuarios[1],
                new DescripcionPago("Mantenimiento de sistemas externos"), new MontoPago(1500),
                DateTime.Now.AddMonths(-1), DateTime.Now.AddMonths(11)),

            new PagoRecurrente(new Efectivo(), tipos[2].ID, tipos[2], usuarios[2].ID, usuarios[2],
                new DescripcionPago("Pago de internet empresarial"), new MontoPago(1200),
                DateTime.Now.AddMonths(-2), DateTime.Now.AddMonths(10)),

            new PagoRecurrente(new Credito(), tipos[3].ID, tipos[3], usuarios[3].ID, usuarios[3],
                new DescripcionPago("Suscripción de software contable"), new MontoPago(900),
                DateTime.Now.AddMonths(-4), DateTime.Now.AddMonths(8)),

            new PagoRecurrente(new Efectivo(), tipos[4].ID, tipos[4], usuarios[4].ID, usuarios[4],
                new DescripcionPago("Mantenimiento de equipos de red"), new MontoPago(700),
                DateTime.Now.AddMonths(-6), DateTime.Now.AddMonths(6)),

            new PagoRecurrente(new Credito(), tipos[0].ID, tipos[0], usuarios[2].ID, usuarios[2],
                new DescripcionPago("Suscripción VPN"), new MontoPago(500),
                DateTime.Now.AddMonths(-8), DateTime.Now.AddMonths(4)),

            new PagoRecurrente(new Credito(), tipos[1].ID, tipos[1], usuarios[3].ID, usuarios[3],
                new DescripcionPago("Seguridad cloud"), new MontoPago(2500),
                DateTime.Now.AddMonths(-10), DateTime.Now.AddMonths(2)),

            new PagoRecurrente(new Efectivo(), tipos[2].ID, tipos[2], usuarios[1].ID, usuarios[1],
                new DescripcionPago("Soporte técnico remoto"), new MontoPago(1800),
                DateTime.Now.AddMonths(-12), DateTime.Now.AddMonths(1)),

            new PagoRecurrente(new Credito(), tipos[3].ID, tipos[3], usuarios[0].ID, usuarios[0],
                new DescripcionPago("Pago servidores internos"), new MontoPago(1100),
                DateTime.Now.AddMonths(-2), DateTime.Now.AddMonths(5)),

            new PagoRecurrente(new Efectivo(), tipos[4].ID, tipos[4], usuarios[4].ID, usuarios[4],
                new DescripcionPago("Backup mensual en nube"), new MontoPago(950),
                DateTime.Now.AddMonths(-5), DateTime.Now.AddMonths(7))
            };

                var pagosUnicos = new[]
                {
            new PagoUnico(new Efectivo(), tipos[0].ID, tipos[0], usuarios[0].ID, usuarios[0],
                new DescripcionPago("Compra de licencias de software"), new MontoPago(3500),
                DateTime.Now.AddDays(-15), new NumeroRecibo(10001)),

            new PagoUnico(new Credito(), tipos[1].ID, tipos[1], usuarios[1].ID, usuarios[1],
                new DescripcionPago("Viaje por conferencia de tecnología"), new MontoPago(1200),
                DateTime.Now.AddDays(-40), new NumeroRecibo(10002)),

            new PagoUnico(new Efectivo(), tipos[2].ID, tipos[2], usuarios[2].ID, usuarios[2],
                new DescripcionPago("Compra de sillas ergonómicas"), new MontoPago(800),
                DateTime.Now.AddDays(-10), new NumeroRecibo(10003)),

            new PagoUnico(new Credito(), tipos[3].ID, tipos[3], usuarios[3].ID, usuarios[3],
                new DescripcionPago("Capacitación en ciberseguridad"), new MontoPago(1800),
                DateTime.Now.AddDays(-30), new NumeroRecibo(10004)),

            new PagoUnico(new Credito(), tipos[4].ID, tipos[4], usuarios[4].ID, usuarios[4],
                new DescripcionPago("Servicio de mudanza de oficina"), new MontoPago(5000),
                DateTime.Now.AddDays(-60), new NumeroRecibo(10005)),

            new PagoUnico(new Efectivo(), tipos[0].ID, tipos[0], usuarios[2].ID, usuarios[2],
                new DescripcionPago("Compra de routers"), new MontoPago(1400),
                DateTime.Now.AddDays(-45), new NumeroRecibo(10006)),

            new PagoUnico(new Credito(), tipos[1].ID, tipos[1], usuarios[3].ID, usuarios[3],
                new DescripcionPago("Certificación técnica"), new MontoPago(2000),
                DateTime.Now.AddDays(-25), new NumeroRecibo(10007)),

            new PagoUnico(new Efectivo(), tipos[2].ID, tipos[2], usuarios[0].ID, usuarios[0],
                new DescripcionPago("Compra de monitores"), new MontoPago(2200),
                DateTime.Now.AddDays(-12), new NumeroRecibo(10008)),

            new PagoUnico(new Credito(), tipos[3].ID, tipos[3], usuarios[4].ID, usuarios[4],
                new DescripcionPago("Pago único de mantenimiento"), new MontoPago(950),
                DateTime.Now.AddDays(-50), new NumeroRecibo(10009)),

            new PagoUnico(new Efectivo(), tipos[4].ID, tipos[4], usuarios[1].ID, usuarios[1],
                new DescripcionPago("Compra de combustible para flota"), new MontoPago(600),
                DateTime.Now.AddDays(-70), new NumeroRecibo(10010)),
            };

                _context.Pagos.AddRange(pagosRecurrentes);
                _context.Pagos.AddRange(pagosUnicos);
                _context.SaveChanges();
            }
        }

    }
}
