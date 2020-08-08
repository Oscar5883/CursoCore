using System;
using System.Collections.Generic;

namespace DAL.CursoEscuela.Models
{
    public partial class Turnos
    {
        public Turnos()
        {
            Alumnos = new HashSet<Alumnos>();
        }

        public int IdTurno { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Alumnos> Alumnos { get; set; }
    }
}
