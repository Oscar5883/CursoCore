using System;
using System.Collections.Generic;

namespace DAL.CursoEscuela.Models
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public string Email { get; set; }
        public DateTime Fecha { get; set; }
        public int IdRol { get; set; }

        public virtual Rol IdRolNavigation { get; set; }
    }
}
