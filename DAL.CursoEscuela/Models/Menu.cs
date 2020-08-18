using System;
using System.Collections.Generic;

namespace DAL.CursoEscuela.Models
{
    public partial class Menu
    {
        public Menu()
        {
            SubMenus = new HashSet<SubMenus>();
        }

        public int IdMenu { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        public string Ruta { get; set; }
        public string Icono { get; set; }

        public virtual ICollection<SubMenus> SubMenus { get; set; }
    }
}
