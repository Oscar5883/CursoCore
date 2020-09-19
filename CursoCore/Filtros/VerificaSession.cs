using CursoCore.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace CursoCore.Filtros
{
    public class VerificaSession:ActionFilterAttribute
    {
         string Nombre, Email, Contraseña;
         int? IdRol;
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                base.OnActionExecuting(context);
                Nombre = context.HttpContext.Session.GetString("Nombre");
                Email = context.HttpContext.Session.GetString("Email");
                Contraseña = context.HttpContext.Session.GetString("Contraseña");
                IdRol = context.HttpContext.Session.GetInt32("IdRol");
                if (Nombre == null && Email == null && Contraseña == null && IdRol==null)
                {
                    if (context.Controller is LoginController == false)
                    {
                        context.HttpContext.Response.Redirect("../Login/Login");
                        
                    }
                }

            }
            catch (Exception)
            {
                context.Result = new RedirectResult("~/Login/Login");
                
            }
        }
    }
}
