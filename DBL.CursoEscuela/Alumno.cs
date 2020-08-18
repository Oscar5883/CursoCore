using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using DAL.CursoEscuela;
using DAL.CursoEscuela.Models;

namespace DBL.CursoEscuela
{
    
   public class Alumno
    {


        public string CrearAlumno(Alumnos alumno)
        {
            DAL.CursoEscuela.Alumno _Alumno = new DAL.CursoEscuela.Alumno();
            string mensaje = string.Empty;
            int matricula = Convert.ToInt32(_Alumno.ObtenerMatriculaActual());
            string nuevaMatricula = matricula == 0 ? string.Format("{0:D5}", 1) : string.Format("{0:D5}", matricula + 1);
            alumno.Matricula = nuevaMatricula;

            if (_Alumno.CrearAlumno(alumno))
            {
                mensaje = "Alumno Registrado Correctamente";
            }
            else
            {
                mensaje = "Error al Generar Alumno";
            }
            return mensaje;

        }

        public List<ObtenerAlumnos> ObtenerAlumnos()
        {
            DAL.CursoEscuela.Alumno _Alumno = new DAL.CursoEscuela.Alumno();
            return _Alumno.ObtenerAlumnos();


        }
        public string EliminarAlumnos(List<Alumnos> alumnos)
        {
            DAL.CursoEscuela.Alumno _alumnos = new DAL.CursoEscuela.Alumno();
            string mensaje = string.Empty;
            if (_alumnos.EliminarAlumnos(alumnos))
            {
                mensaje = "Alumno(s) eliminados Corectamente";
            }
            else
            {
                mensaje = "Error al Eliminar Alumno(s)";
            }
            return mensaje;

        }
        public List<Turnos> OntenerTurnos()
        {
            DAL.CursoEscuela.Alumno _Alumno = new DAL.CursoEscuela.Alumno();
            return _Alumno.ObtenerTurnos();

        }
        public Alumnos ObtenerAlumno(int Id)
        {
            DAL.CursoEscuela.Alumno _alumno = new DAL.CursoEscuela.Alumno();
            return _alumno.ObtenerAlumno(Id);
        }
        public string EditarAlumno(Alumnos alumno)
        {
            DAL.CursoEscuela.Alumno _alumno = new DAL.CursoEscuela.Alumno();
            string mensaje = string.Empty;
            if (_alumno.Editar(alumno))
            {
                mensaje = "Alumno Actualizado Correctamente";
            }
            else
            {
                mensaje = "Error al Actualizar Alumno";
            }
            return mensaje;
        }

    }
}
