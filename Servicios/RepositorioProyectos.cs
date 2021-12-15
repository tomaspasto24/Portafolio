using Portafolio.Models;

namespace Portafolio.Servicios
{
    public interface IRepositorioProyectos
    {
        List<ProyectoViewModel> ObtenerProyectos();
    }

    public class RepositorioProyectos : IRepositorioProyectos
    {
        public List<ProyectoViewModel> ObtenerProyectos()
        {
            return new List<ProyectoViewModel>()
            {
                new ProyectoViewModel()
                {
                    Title = "Prueba1",
                    Description = "Descripción ejemplo1",
                    Link = "https://amazon.com",
                    ImagenURL = "/Images/amazon.png"
                },
                new ProyectoViewModel()
                {
                    Title = "Prueba2",
                    Description = "Descripción ejemplo2",
                    Link = "https://facebook.com",
                    ImagenURL = "/Images/nyt.png"
                },
                new ProyectoViewModel()
                {
                    Title = "Prueba3",
                    Description = "Descripción ejemplo3",
                    Link = "https://steam.com",
                    ImagenURL = "/Images/reddit.png"
                },
                new ProyectoViewModel()
                {
                    Title = "Prueba4",
                    Description = "Descripción ejemplo4",
                    Link = "https://udemy.com",
                    ImagenURL = "/Images/steam.png"
                },
            };
        }
    }
}
