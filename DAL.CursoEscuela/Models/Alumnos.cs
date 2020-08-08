using System;
using System.Collections.Generic;

namespace DAL.CursoEscuela.Models
{
    public partial class Alumnos
    {
        public Alumnos()
        {
            Calificaciones = new HashSet<Calificaciones>();
            Grupos = new HashSet<Grupos>();
        }

        public int IdAlumno { get; set; }
        public string Nombre { get; set; }
        public string Matricula { get; set; }
        public int IdTurno { get; set; }

        public virtual Turnos IdTurnoNavigation { get; set; }
        public virtual ICollection<Calificaciones> Calificaciones { get; set; }
        public virtual ICollection<Grupos> Grupos { get; set; }
    }
}
