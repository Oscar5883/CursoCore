using DAL.CursoEscuela.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DAL.CursoEscuela
{
  public   class Login
    {
        public Usuario Accesso(Usuario usuario)
        {
            using (var context = new EscuelaContext())
            {
                var OUsuario= context.Usuario.Where(x => x.Email == usuario.Email && x.Contraseña == usuario.Contraseña).FirstOrDefault();

                if (OUsuario == null)
                {
                    return new Usuario();
                }


                return OUsuario;
            
            }
        }

    }
}
