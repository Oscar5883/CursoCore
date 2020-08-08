using DAL.CursoEscuela.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;


namespace DAL.CursoEscuela
{
   

    public class Alumno
    {
        private readonly EscuelaContext _escuela;

        public Alumno(EscuelaContext escuela)
        {
            _escuela = escuela;
        }

        public Alumno()
        { 
        
        }
        public bool CrearAlumno(Alumnos alumno)
        {
            bool status = true;
            try
            {
                using (var context = new EscuelaContext())
                {
                    context.Alumnos.Add(alumno);
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


        public List<ObtenerAlumnos> ObtenerAlumnos()
        {

            using (var context = new EscuelaContext())
            {

                var res= context.ObtenerAlumnos.FromSqlRaw("EXECUTE  sp_ObtieneAlumnos").ToList();
                return res;
            }
            
        }
        public bool EliminarAlumnos(List<Alumnos> alumnos)
        {
            bool estatus = true;
            try
            {
                using (var context=new EscuelaContext())
                {
                    foreach (var alumno in alumnos)
                    {
                       context.Alumnos.Where(a => a.IdAlumno == alumno.IdAlumno).ToList().ForEach(e => context.Alumnos.Remove(e));
                        context.SaveChanges();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                estatus = false;
                throw ex;
            }
            return estatus;
        }
        public List<Turnos> ObtenerTurnos()
        {
            using (var context = new EscuelaContext())
            {
                return context.Turnos.ToList();
            
            }
        
        }
        public string ObtenerMatriculaActual()
        {
            using (var context = new EscuelaContext())
            {
                var UltMatricula = context.Alumnos.OrderByDescending(x => x.Matricula).FirstOrDefault();
                return UltMatricula == null ? "0" : UltMatricula.Matricula;
            }
        }
    }
}
