using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CursoCore.Models;
using DAL.CursoEscuela.Models;
using DBL.CursoEscuela;
using Microsoft.AspNetCore.Mvc;


namespace CursoCore.Controllers
{
    public class AlumnoController : Controller
    {
        public ActionResult Index()
        {


            return View();
        }
        [HttpGet]
        public string ObtenerAlumnos()

        {
            Alumno al = new Alumno();
            var res = al.ObtenerAlumnos();

            return JsonSerializer.Serialize(res);
        }

        [HttpPost]
        public JsonResult Index([FromBody] Alumnos alumnos)
        {

            Alumno al = new Alumno();
            var res = al.CrearAlumno(alumnos);

            return Json(res);
        }
        [HttpPost]
        public JsonResult EliminarAlumnos([FromBody] List<Alumnos> alumnos)
        {
            Alumno al = new Alumno();
            var res = al.EliminarAlumnos(alumnos);
            return Json(res);
        }
        [HttpGet]
        public string ObtenerTurno()
        {
            Alumno al = new Alumno();
            var res = al.OntenerTurnos();

            return JsonSerializer.Serialize(res);

        }
        [HttpGet]
        public string ObtenerAlumno(int id)
        {
            Alumno al = new Alumno();
            var res = al.ObtenerAlumno(id);
            return JsonSerializer.Serialize(res);
        }
        [HttpPost]
        public JsonResult Editar([FromBody] Alumnos alumnos)
        {
            Alumno al = new Alumno();
            var res = al.EditarAlumno(alumnos);
            return Json(res);
        }
    }   
}
