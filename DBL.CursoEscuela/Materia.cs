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
    }
}
