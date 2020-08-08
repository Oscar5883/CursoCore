using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.CursoEscuela.Models;
using DBL.CursoEscuela;
using Microsoft.AspNetCore.Mvc;

namespace CursoCore.Controllers
{
    public class MateriaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GuardarMateria([FromBody] Materias materia)
        {
            Materia mat = new Materia();
            var res = mat.GuardarMateria(materia);
            return Json(res);
        }
    }
}
