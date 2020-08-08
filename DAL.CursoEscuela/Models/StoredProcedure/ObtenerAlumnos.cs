using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.CursoEscuela.Models
{
    public class ObtenerAlumnos
    {
        [Key]
        public int IdAlumno { get; set; }
        public string Nombre { get; set; }
        public string Matricula { get; set; }
        public string Descripcion { get; set; }
    }
}
