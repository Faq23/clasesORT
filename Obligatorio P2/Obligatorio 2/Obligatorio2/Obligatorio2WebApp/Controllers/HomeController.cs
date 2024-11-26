using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Modelo;
using Obligatorio2WebApp.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Obligatorio2WebApp.Controllers
{
    public class HomeController : Controller
    {
        Sistema system = Sistema.Instance;

        public IActionResult Index()
        {
            HttpContext.Session.Clear(); // Limpio el Session cuando se accede al Home
            return RedirectToAction("Login"); // Por defecto el Index lo envia al Login
        }

        [HttpGet]
        public IActionResult Login() // Permite a un usuario Loguearse
        {
            string? successRegister = HttpContext.Session.GetString("successRegister");
            string? userRegistered = HttpContext.Session.GetString("userRegistered");

            if (!string.IsNullOrEmpty(successRegister))
            {
                ViewBag.msgType = "Success";
                ViewBag.msg = successRegister;
                ViewBag.userRegistered = userRegistered;

                HttpContext.Session.Remove("successRegister");
            }

            return View();
        }

        public IActionResult Register() // Permite a un usuario Registrarse
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Cliente c)
        {
            if (c.Nombre is not null && c.Apellido is not null && c.Email is not null && c.Password is not null)
            {
                try
                {
                    system.RegistrarCliente(c);
                    HttpContext.Session.SetString("successRegister", "El usuario fue creado correctamente.");
                    HttpContext.Session.SetString("userRegistered", c.Email);
                    return RedirectToAction("Login", "Home");
                }
                catch(Exception ex)
                {
                    ViewBag.msg = ex.Message;
                    return View();
                }
            } else
            {
                ViewBag.msg = "Debe completar todos los campos";
                return View();
            }
        }

        [HttpPost]
        public IActionResult Login(string userEmail, string userPassword)
        {
            try
            {
                Usuario userLogin = system.LogInUser(userEmail, userPassword);

                // Agregamos los datos que vamos a utilizar mas adelante al Session.
                HttpContext.Session.SetInt32("userID", userLogin.ID);
                HttpContext.Session.SetString("userRol", userLogin.ObtenerRol());
                
                return RedirectToAction("Index", userLogin.ObtenerRol());
            }
            catch (Exception ex)
            {
                ViewBag.msg = ex.Message;
                return View();
            }
        }
    }
}
