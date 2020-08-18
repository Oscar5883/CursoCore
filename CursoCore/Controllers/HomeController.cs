using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CursoCore.Models;
using DAL.CursoEscuela.Models;
using DBL.CursoEscuela;
using System.Text.Json;

namespace CursoCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult  Index()
        {
            return View();
        }
        public string ObtenerMenu()
        {
            DBL.CursoEscuela.Menu menu = new DBL.CursoEscuela.Menu();
            var res = menu.ObtenerMenu();
            return JsonSerializer.Serialize(res);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
