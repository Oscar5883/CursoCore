using System;
using System.Collections.Generic;

namespace DAL.CursoEscuela.Models
{
    public partial class RolOperacion
    {
        public int IdRolOpercion { get; set; }
        public int IdRol { get; set; }
        public int IdOperacion { get; set; }

        public virtual Operaciones IdOperacionNavigation { get; set; }
        public virtual Rol IdRolNavigation { get; set; }
    }
}
