using System;
using System.Collections.Generic;

namespace DAL.CursoEscuela.Models
{
    public partial class Modulo
    {
        public Modulo()
        {
            Operaciones = new HashSet<Operaciones>();
        }

        public int IdModulo { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Operaciones> Operaciones { get; set; }
    }
}
