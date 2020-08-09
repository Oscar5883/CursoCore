using DAL.CursoEscuela.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

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
        public List<Materias> ObtenerMaterias()
        {

            using (var context = new EscuelaContext())
            {
                return context.Materias.ToList();

            }


        }

        public string ObtenerClaveMateria()
        {
            using (var context = new EscuelaContext())
            {
                var UltClaveMateria = context.Materias.OrderByDescending(x => x.ClaveMateria).FirstOrDefault();
                return UltClaveMateria == null ? "0" : UltClaveMateria.ClaveMateria;
            }
        }

    }
}
