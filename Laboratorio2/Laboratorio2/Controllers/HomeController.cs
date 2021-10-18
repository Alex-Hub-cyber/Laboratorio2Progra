using Laboratorio2.Dominio;
using Laboratorio2.Models;
using Laboratorio2.Models.ViewModels;
using Laboratorio2.Servicio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Ipersona ipersonas;
        public HomeController(ILogger<HomeController> logger,Ipersona ipersonas)
        {
            this.ipersonas = ipersonas;
            _logger = logger;
        }

        public IActionResult Index()
        {
            persona almacen = new persona();
            //almacen.NombrePersona = "Oscar";
            //almacen.EdadPersona = 20;
            //almacen.DescripcionPersona = "Alumno";
            //ipersonas.Insertar(almacen);

            return View();
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


        public IActionResult MostrarInformacion()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            var FormatoJson = ipersonas.Listardatos();

            return Json(new { data = FormatoJson });
        }

        public IActionResult GuardarDatos()
        {
            return View();
        }
        public IActionResult GuardarInformacion( ClsEspejoPersona GuardarDatos)
        {
            persona GPersona = new persona();

            if (ModelState.IsValid)
            {
                if (GuardarDatos.EdadPersona >= 18)
                {

                    GPersona.NombrePersona = GuardarDatos.NombrePersona;
                    GPersona.EdadPersona = GuardarDatos.EdadPersona;
                    GPersona.DescripcionPersona = GuardarDatos.DescripcionPersona;

                    ipersonas.Insertar(GPersona);

                    return View("MostrarInformacion");

                }
                else
                {
                    return Redirect("/Home/GuardarDatos");


                }
            }
            else
            {
                return View("GuardarDatos");
            }


        }

       
    }
}
