using System;
using System.Collections.Generic;

namespace DAL.CursoEscuela.Models
{
    public partial class Operaciones
    {
        public Operaciones()
        {
            RolOperacion = new HashSet<RolOperacion>();
        }

        public int IdOperacion { get; set; }
        public string Nombre { get; set; }
        public int IdModulo { get; set; }

        public virtual Modulo IdModuloNavigation { get; set; }
        public virtual ICollection<RolOperacion> RolOperacion { get; set; }
    }
}
