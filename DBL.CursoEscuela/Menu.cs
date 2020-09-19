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

        public string GuardarMenu(DAL.CursoEscuela.Models.Menu menu)
        {
            string Mensaje = string.Empty;
            DAL.CursoEscuela.Menu men = new DAL.CursoEscuela.Menu();
            if (men.GuardarMenu(menu) == true)
            {
                Mensaje = "Menú Creado Correctamente";
            }
            else
            {
                Mensaje = "Error al Crear el Menú";
            }
            return Mensaje;
        }

    }

}
