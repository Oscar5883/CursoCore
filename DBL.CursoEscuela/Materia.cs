using DAL.CursoEscuela.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBL.CursoEscuela
{
    public class Materia
    {
        public string GuardarMateria(Materias materias)
        {
            DAL.CursoEscuela.Materia _Materia = new DAL.CursoEscuela.Materia();
            int matricula = Convert.ToInt32(_Materia.ObtenerClaveMateria());
            string nuevaClaveMateria = matricula == 0 ? string.Format("{0:D5}", 1) : string.Format("{0:D5}", matricula + 1);
            materias.ClaveMateria = nuevaClaveMateria;
            string mensaje = string.Empty;
            if (_Materia.CrearMateria(materias))
            {
                mensaje = "Materia Creada Correctamente";

            }
            else
            {
                mensaje = "Ocurrio un Erro al Crear la Materia";
            }
            return mensaje;
        }
        public List<Materias> ObtenerMaterias()
        {

            DAL.CursoEscuela.Materia materia = new DAL.CursoEscuela.Materia();
            return materia.ObtenerMaterias();
        }
        public string EliminarMateriaBL(List<Materias> materias)
        {
            DAL.CursoEscuela.Materia _materia = new DAL.CursoEscuela.Materia();
            string mensaje = string.Empty;
            if (_materia.EliminarMateriaDL(materias))
            {

                mensaje = "Materia(s) eliminadas correctamente";
            }
            else
            {
                mensaje = "Error al eliminar la(s) Materia(s)";
            }
            return mensaje;
        }
    }
}
