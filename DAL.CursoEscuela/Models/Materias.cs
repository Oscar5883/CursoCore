using System;
using System.Collections.Generic;

namespace DAL.CursoEscuela.Models
{
    public partial class Materias
    {
        public Materias()
        {
            Calificaciones = new HashSet<Calificaciones>();
            Grupos = new HashSet<Grupos>();
            Maestro = new HashSet<Maestro>();
        }

        public int IdMateria { get; set; }
        public string Nombre { get; set; }
        public string ClaveMateria { get; set; }

        public virtual ICollection<Calificaciones> Calificaciones { get; set; }
        public virtual ICollection<Grupos> Grupos { get; set; }
        public virtual ICollection<Maestro> Maestro { get; set; }
    }
}
