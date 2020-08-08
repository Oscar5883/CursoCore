using System;
using System.Collections.Generic;

namespace DAL.CursoEscuela.Models
{
    public partial class Grupos
    {
        public int IdGrupos { get; set; }
        public string Descripcion { get; set; }
        public int IdAlumnos { get; set; }
        public int IdMateria { get; set; }

        public virtual Alumnos IdAlumnosNavigation { get; set; }
        public virtual Materias IdMateriaNavigation { get; set; }
    }
}
