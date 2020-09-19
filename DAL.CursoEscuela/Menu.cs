using DAL.CursoEscuela.Models;
using DAL.CursoEscuela.Models.StoredProcedure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.CursoEscuela
{
   public class Menu
    {

        public List<ObtenerMenusSubMenus> ObtenerMenu()
        {
            using (var context = new EscuelaContext())
            {

                var res = context.ObtenerMenusSubMenus.FromSqlRaw("EXECUTE  sp_ObtenerMenuSubMenus").ToList();
                return res;
            }
        }


        public bool GuardarMenu(DAL.CursoEscuela.Models.Menu menu)
        {
            bool Estatus = true;
            try
            {
                using (var context = new EscuelaContext())
                {
                    context.Menu.Add(menu);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Estatus = false;
                throw ex;
            }
            return Estatus;
        }

    }
}
