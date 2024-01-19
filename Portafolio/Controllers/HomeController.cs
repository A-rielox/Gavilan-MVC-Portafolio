using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Portafolio.Models;
using Portafolio.Servicios;
using System.Diagnostics;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorioProyectos repositorioProyectos;
        private readonly IConfiguration configuration;

        private readonly ServicioDelimitado servicioDelimitado;
        private readonly ServicioUnico servicioUnico;
        private readonly ServicioTransitorio servicioTransitorio;

        private readonly ServicioDelimitado servicioDelimitado2;
        private readonly ServicioUnico servicioUnico2;
        private readonly ServicioTransitorio servicioTransitorio2;

        public HomeController(ILogger<HomeController> logger,
                          IRepositorioProyectos repositorioProyectos,
                          IConfiguration configuration,

                          ServicioDelimitado servicioDelimitado,
                          ServicioUnico servicioUnico,
                          ServicioTransitorio servicioTransitorio,

                          ServicioDelimitado servicioDelimitado2,
                          ServicioUnico servicioUnico2,
                          ServicioTransitorio servicioTransitorio2
            )
        {
            _logger = logger;
            this.repositorioProyectos = repositorioProyectos;
            this.configuration = configuration;
            this.servicioDelimitado = servicioDelimitado;
            this.servicioUnico = servicioUnico;
            this.servicioTransitorio = servicioTransitorio;

            this.servicioDelimitado2 = servicioDelimitado2;
            this.servicioUnico2 = servicioUnico2;
            this.servicioTransitorio2 = servicioTransitorio2;
        }

        public IActionResult Index()
        {
            var proyectos = repositorioProyectos.ObtenerProyectos().Take(3).ToList();
            //var guidViewModel = new EjemploGUIDViewModel()
            //{
            //    Delimitado = servicioDelimitado.ObtenerGuid,
            //    Transitorio = servicioTransitorio.ObtenerGuid,
            //    Unico = servicioUnico.ObtenerGuid
            //};
            //var guidViewModel2 = new EjemploGUIDViewModel()
            //{
            //    Delimitado = servicioDelimitado2.ObtenerGuid,
            //    Transitorio = servicioTransitorio2.ObtenerGuid,
            //    Unico = servicioUnico2.ObtenerGuid
            //};

            var modelo = new HomeIndexViewModel()
            {
                Proyectos = proyectos,
                //EjemploGUID_1 = guidViewModel,
                //EjemploGUID_2 = guidViewModel2,
            };

            return View(modelo);
            //return View("Index2"); --> me buscaria una view con nombre de
                                       // archivo Index2.cshtml en Views/Home/Index2.cshtml
        }

        public IActionResult Privacy()
        {
            // ViewBag.Nombre = "Arielox G"; // es din[amico as[i que le puedo colocar .LoQueSea
            // ViewBag.Edad = 27;

            var persona = new Persona
            {
                Nombre = "Arielox GG",
                Edad = 27
            };

            return View(persona);

            //return View("Privacy", "Pepillo"); ---> necesito especificar el "Index" xq estoy pasando un 
            //                                      string y se confundiria con el nombre de la view
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}