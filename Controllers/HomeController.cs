using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using System.Diagnostics;
using Portafolio.Servicios;

namespace Portafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepositorioProyectos repositorioProyectos;
        private readonly IEmailSendGrid servicioEmail;

        public HomeController(IRepositorioProyectos repositorioProyectos, IEmailSendGrid servicioEmail)
        {
            this.repositorioProyectos = repositorioProyectos;
            this.servicioEmail = servicioEmail;
        }

        public IActionResult Index()
        {
            List<ProyectoViewModel> proyectos = repositorioProyectos.ObtenerProyectos().Take(3).ToList();
            HomeIndexViewModel modelo = new HomeIndexViewModel() { 
                Proyectos = proyectos,
            };
            return View(modelo);
        }
        public IActionResult Proyectos()
        {
            List<ProyectoViewModel> proyectos = repositorioProyectos.ObtenerProyectos().ToList();
            return View(proyectos);
        }

        //Metodo que lleva atributo HttpGet que es el atributo que viene por defecto si no se asigna nada, como en los demas metodos.
        [HttpGet]
        public IActionResult Contacto()
        {
            return View();
        }

        //Metodo que lleva un atributo HttpPost para saber que es lo que se ejecuta cuando se recibe un POST.
        [HttpPost] 
        public async Task<IActionResult> Contacto(ContactoViewModel contactoViewModel)
        {
            await this.servicioEmail.Enviar(contactoViewModel);
            return Redirect("Gracias");
        }

        public IActionResult Gracias()
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