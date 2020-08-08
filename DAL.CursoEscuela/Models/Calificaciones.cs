using System;
using System.Collections.Generic;

namespace DAL.CursoEscuela.Models
{
    public partial class Calificaciones
    {
        public int IdCalificaciones { get; set; }
        public int Calificacion { get; set; }
        public int IdMateria { get; set; }
        public int IdAlumno { get; set; }

        public virtual Alumnos IdAlumnoNavigation { get; set; }
        public virtual Materias IdMateriaNavigation { get; set; }
    }
}
