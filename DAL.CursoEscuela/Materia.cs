using DAL.CursoEscuela.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.CursoEscuela
{
  public   class Materia
    {
        public bool CrearMateria(Materias materia)
        {
            bool status = true;
            try
            {
                using (var context = new EscuelaContext())
                {
                    context.Materias.Add(materia);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                status = false;
                throw ex;
            }
            return status;
        }

    }
}
