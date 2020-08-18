using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace DAL.CursoEscuela.Models.StoredProcedure
{
    public class ObtenerMenusSubMenus
    {
        [Key]
        public int IdMenu { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        public string Ruta { get; set; }
        public string? Icono { get; set; }

        public int? IdSubMenu { get; set; }
        public int? NombreSubMenu { get; set; }
        public bool? ActivoSubMenu { get; set; }
        public string? RutaSubMenu { get; set; }
       

    }
}
