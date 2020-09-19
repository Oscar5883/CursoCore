using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.CursoEscuela.Models;
using Microsoft.AspNetCore.Mvc;
using DBL.CursoEscuela;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace CursoCore.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public string Acceso([FromBody] Usuario usuario)
        {
            Login _login = new Login();
            string mensaje = "";
            var res = _login.Acceso(usuario);
            if (res.Nombre == null)
            {
                mensaje = "El usuario ó constraseña no es valido";
            }
            else
            {
                HttpContext.Session.SetString("Nombre", res.Nombre);
                HttpContext.Session.SetString("Email", res.Email);
                HttpContext.Session.SetString("Contraseña", res.Contraseña);
                HttpContext.Session.SetInt32("IdRol", res.IdRol);
            }
            return (mensaje);
        }
        public IActionResult Index()
        {
            return View();
        }
       
    }
}
