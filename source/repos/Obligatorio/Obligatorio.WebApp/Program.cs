using Obligatorio.LogicaAplicacion.CasosUso.Equipos;
using Obligatorio.LogicaAplicacion.CasosUso.Usuarios;
using Obligatorio.LogicaAplicacion.dtos.Equipos;
using Obligatorio.LogicaAplicacion.dtos.Usuarios;
using Obligatorio.LogicaInfraestructura.AccesoDatos.Memoria;
using Obligatorio.LogicaNegocio.InterfacesLogicaAplicacion;
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

            // Inyeccion de Repositorios
            builder.Services.AddScoped<IRepositorioEquipo, RepositorioEquipo>();
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();

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


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

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
