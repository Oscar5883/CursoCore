using DAL.CursoEscuela.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBL.CursoEscuela
{
    public class Login
    {
        public Usuario Acceso(Usuario usuario)
        {
            DAL.CursoEscuela.Login _login = new DAL.CursoEscuela.Login();
            var OUsuario = _login.Accesso(usuario);
            return OUsuario;
        }

    }
}
