using Microsoft.AspNetCore.Mvc;

namespace SistemaDeAsesorias.Controllers
{
    public class SolicitudAsesoriaController : Controller
    {
        public IActionResult Solicitud()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Solicitud(int id)
        {
            return View();
        }
    }
}
