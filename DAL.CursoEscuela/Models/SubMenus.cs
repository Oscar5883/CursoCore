using System;
using System.Collections.Generic;

namespace DAL.CursoEscuela.Models
{
    public partial class SubMenus
    {
        public int IdSubMenu { get; set; }
        public int Nombre { get; set; }
        public bool Activo { get; set; }
        public int IdMenu { get; set; }
        public string Ruta { get; set; }

        public virtual Menu IdMenuNavigation { get; set; }
    }
}
