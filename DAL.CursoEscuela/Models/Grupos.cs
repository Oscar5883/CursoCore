using System;
using System.Collections.Generic;

namespace DAL.CursoEscuela.Models
{
    public partial class Grupos
    {
        public Grupos()
        {
            Alumnos = new HashSet<Alumnos>();
        }

        public int IdGrupos { get; set; }
        public string Descripcion { get; set; }
        public int IdMateria { get; set; }

        public virtual Materias IdMateriaNavigation { get; set; }
        public virtual ICollection<Alumnos> Alumnos { get; set; }
    }
}
