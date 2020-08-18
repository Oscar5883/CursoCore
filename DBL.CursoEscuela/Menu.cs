using DAL.CursoEscuela.Models.StoredProcedure;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBL.CursoEscuela
{
   public class Menu
    {

        public List<ObtenerMenusSubMenus> ObtenerMenu()
        {
            DAL.CursoEscuela.Menu menu = new DAL.CursoEscuela.Menu();
            return menu.ObtenerMenu();

        }

    }
}
