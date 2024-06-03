using Microsoft.AspNetCore.Mvc;
using MvcConciertos.Models;
using MvcConciertos.Services;

namespace MvcConciertos.Controllers
{
    public class ConciertosController : Controller
    {
        private ServiceApiConciertos service;
        public ConciertosController(ServiceApiConciertos service)
        {
            this.service = service;
        }
        public async Task<IActionResult> Index()
        {
            List<Evento> eventos = await this.service.GetEventosAsync();
            List<CategoriaEvento> categorias = await this.service.GetCategoriasAsync();
            ViewBag.Categorias = categorias;
            return View(eventos);
        }
        [HttpPost]
        public async Task<IActionResult> Index(int idcategoria)
        {
            List<Evento> eventos = await this.service.GetEventosPorCategoriaAsync(idcategoria);
            List<CategoriaEvento> categorias = await this.service.GetCategoriasAsync();
            ViewBag.Categorias = categorias;
            return View(eventos);
        }

        
    }
}
