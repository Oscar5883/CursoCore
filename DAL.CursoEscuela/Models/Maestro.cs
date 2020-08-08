using System;
using System.Collections.Generic;

namespace DAL.CursoEscuela.Models
{
    public partial class Maestro
    {
        public int IdMaestro { get; set; }
        public int Nombre { get; set; }
        public int IdMateria { get; set; }

        public virtual Materias IdMateriaNavigation { get; set; }
    }
}
