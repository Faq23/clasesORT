using Microsoft.EntityFrameworkCore;
using Obligatorio.LogicaAplicacion.CasosUso.Equipos;
using Obligatorio.LogicaAplicacion.CasosUso.Pagos;
using Obligatorio.LogicaAplicacion.CasosUso.TiposGasto;
using Obligatorio.LogicaAplicacion.CasosUso.Usuarios;
using Obligatorio.LogicaAplicacion.dtos.Equipos;
using Obligatorio.LogicaAplicacion.dtos.Pagos;
using Obligatorio.LogicaAplicacion.dtos.TiposGasto;
using Obligatorio.LogicaAplicacion.dtos.Usuarios;
using Obligatorio.LogicaInfraestructura.AccesoDatos.EF;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion.Pago;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion.Usuario;
using Obligatorio.LogicaNegocio.InterfacesRepositorio;

namespace Obligatorio.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Conexión BDD
            IConfiguration configuracion = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json").Build();

            string cadenaConexion = configuracion.GetConnectionString("Default");

            builder.Services.AddDbContext<ObligatorioContext>(options =>
                options.UseSqlServer(cadenaConexion));

            // Session
            builder.Services.AddSession();

            // Inyeccion de Repositorios
            builder.Services.AddScoped<IRepositorioEquipo, RepositorioEquipo>();
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            builder.Services.AddScoped<IRepositorioTipoGasto, RepositorioTipoGasto>();
            builder.Services.AddScoped<IRepositorioPagoRecurrente, RepositorioPagoRecurrente>();
            builder.Services.AddScoped<IRepositorioPagoUnico, RepositorioPagoUnico>();

            // Inyeccion de Caso de Uso
            // Equipo
            builder.Services.AddScoped<ICUAdd<EquipoDTOAlta>, AddEquipo>();
            builder.Services.AddScoped<ICUGetAll<EquipoDTOListado>, GetAllEquipos>();
            builder.Services.AddScoped<ICUGetByID<EquipoDTOListado>, GetByIDEquipo>();

            // Usuario
            builder.Services.AddScoped<ICUAdd<UsuarioDTOAlta>, AddUsuario>();
            builder.Services.AddScoped<ICUGetAll<UsuarioDTOListado>, GetAllUsuarios>();
            builder.Services.AddScoped<ICUGetByID<UsuarioDTOListado>, GetByIDUsuario>();
            builder.Services.AddScoped<ICUDelete<UsuarioDTOListado>, DeleteUsuario>();
            builder.Services.AddScoped<ICUEmailGenerator, GenerateEmailUsuario>();
            builder.Services.AddScoped<LoginUsuario, LoginUsuario>();
            builder.Services.AddScoped<ICUListaMayorMonto<UsuarioDTOListadoConMonto>, GetListaPorMonto>();

            // TipoGasto
            builder.Services.AddScoped<ICUAdd<TipoGastoDTOAlta>, AddTipoGasto>();
            builder.Services.AddScoped<ICUGetAll<TipoGastoDTOListado>, GetAllTipoGasto>();
            builder.Services.AddScoped<ICUGetByID<TipoGastoDTOListado>, GetByIDTipoGasto>();
            builder.Services.AddScoped<ICUDelete<TipoGastoDTOListado>, DeleteTipoGasto>();
            builder.Services.AddScoped<ICUUpdate<TipoGastoDTOAlta>, UpdateTipoGasto>();

            // Pago

            builder.Services.AddScoped<ICUAdd<PagoRecurrenteDTOAlta>, AddPagoRecurrente>();
            builder.Services.AddScoped<ICUGetAll<PagoRecurrenteDTOListado>, GetAllPagosRecurrentes>();
            builder.Services.AddScoped<ICUGetByID<PagoRecurrenteDTOListado>, GetByIDPagoRecurrente>();
            builder.Services.AddScoped<ICUPagoMensualList<PagoRecurrenteDTOListadoConSaldo>, ListarPagosRecurrentesMensual>();

            builder.Services.AddScoped<ICUAdd<PagoUnicoDTOAlta>, AddPagoUnico>();
            builder.Services.AddScoped<ICUGetAll<PagoUnicoDTOListado>, GetAllPagosUnicos>();
            builder.Services.AddScoped<ICUGetByID<PagoUnicoDTOListado>, GetByIDPagoUnico>();
            builder.Services.AddScoped<ICUPagoMensualList<PagoUnicoDTOListadoConSaldo>, ListarPagosUnicosMensual>();

            // Precarga de datos
            builder.Services.AddScoped<SeedData>();

            // API + Swagger

            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                using (var scope = app.Services.CreateScope())
                {
                    var seeder = scope.ServiceProvider.GetRequiredService<SeedData>();
                    seeder.Run();
                }

                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler(" / Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSession();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
