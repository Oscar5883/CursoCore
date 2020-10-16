using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CursoCore.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GuardarMenu([FromBody] DAL.CursoEscuela.Models.Menu menu)
        {
            DBL.CursoEscuela.Menu men = new DBL.CursoEscuela.Menu();
            var res = men.GuardarMenu(menu);
            return Json(res);
        }
        public string ObtenerMenu()
        {
            DBL.CursoEscuela.Menu menu = new DBL.CursoEscuela.Menu();
            var res = menu.ObtenerMenu();
            return JsonSerializer.Serialize(res);
        }
        [HttpPost]
        public JsonResult EliminarMenu([FromBody] List<DAL.CursoEscuela.Models.Menu> menus)
        {
            DBL.CursoEscuela.Menu men = new DBL.CursoEscuela.Menu();
            var res = men.DBLEliminarMenu(menus);
            return Json(res);
        }
    }
}
