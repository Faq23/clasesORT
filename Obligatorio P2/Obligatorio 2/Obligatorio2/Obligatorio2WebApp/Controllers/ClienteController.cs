using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Modelo;

namespace Obligatorio2WebApp.Controllers
{
    public class ClienteController : Controller
    {

        Sistema system = Sistema.Instance;
        Cliente? clienteActivo;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            int? clientID = HttpContext.Session.GetInt32("userID");
            Usuario? usuario = system.ObtenerUsuarioPorID(clientID); // Obtengo el Usuario de Sistema para poder manipularlo luego

            if (usuario is null) // Si no hay usuario lo redirijo hacia el login 
            {
                context.Result = RedirectToAction("Index", "Home");
            }
            else if (usuario is Administrador)
            {
                context.Result = RedirectToAction("Index", "Administrador"); // Si el Usuario Logueado es de tipo administrador lo retorno a su página principal
            }
            else
            {
                clienteActivo = usuario as Cliente;

                ViewBag.nombreCliente = clienteActivo.Nombre + " " + clienteActivo.Apellido;
                ViewBag.emailCliente = clienteActivo.Email;
                ViewBag.saldoCliente = clienteActivo.Saldo;

                ViewBag.msg = HttpContext.Session.GetString("msg");
                ViewBag.msgType = HttpContext.Session.GetString("msgType");
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Perfil()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Perfil(int saldoAumento)
        {
            if (saldoAumento <= 0)
            {
                ViewBag.msg = "Debe ingresar un valor mayor a 0 para poder sumarlo a su cuenta";
            }
            else
            {
                clienteActivo.Saldo += saldoAumento;
                ViewBag.saldoCliente = clienteActivo.Saldo;
                ViewBag.msg = "Su saldo fue agregado correctamente.";
                ViewBag.msgType = "Success";
            }

            return View();
        }

        public IActionResult Publicacion()
        {
            return RedirectToAction("Publicacion", "Publicacion"); // Creo la Action en Cliente pero lo redirijo al Controller que manipula las Publicaciones
        }

        public IActionResult Compra(int ID)
        {
            try
            {
                Publicacion? p = system.ObtenerPublicacionPorID(ID);

                if (p.ObtenerPrecio() <= clienteActivo.Saldo)
                {
                    p.FinalizarPublicacion(clienteActivo);

                    HttpContext.Session.SetString("msg", "La compra fue realizada correctamente.");
                    HttpContext.Session.SetString("msgType", "Success");
                } 
                else
                {
                    HttpContext.Session.SetString("msg", "Su saldo no es suficiente para realizar la compra.");
                }

                
            }
            catch (Exception ex)
            {
                HttpContext.Session.SetString("msg", ex.Message);
            }

            return RedirectToAction("Publicacion", "Publicacion");
        }

        public IActionResult Subasta(int ID)
        {
            Publicacion? p = system.ObtenerPublicacionPorID(ID);
            HttpContext.Session.SetInt32("idPublicacion", ID);

            return View(p);
        }

        [HttpPost]
        public IActionResult Subasta(Oferta oferta)
        {
            try
            {
                if (oferta.Monto <= clienteActivo.Saldo)
                {
                    int idPublicacion = HttpContext.Session.GetInt32("idPublicacion").Value;

                    clienteActivo.CrearOferta(system.ObtenerPublicacionPorID(idPublicacion) as Subasta, oferta.Monto);

                    HttpContext.Session.SetString("msg", "La oferta fue realizada correctamente.");
                    HttpContext.Session.SetString("msgType", "Success");

                    HttpContext.Session.Remove("idPublicacion");

                    return RedirectToAction("Publicacion", "Publicacion");
                }
                else
                {
                    HttpContext.Session.SetString("msg", "Su saldo no es suficiente para realizar la oferta.");
                    
                }
            }
            catch (Exception ex)
            {
                HttpContext.Session.SetString("msg", ex.Message);
            }

            return RedirectToAction("Subasta", HttpContext.Session.GetInt32("idPublicacion").Value);
        }
    }
}

