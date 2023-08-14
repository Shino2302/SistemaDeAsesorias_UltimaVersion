using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaDeAsesorias.Datos.Contrato;
using SistemaDeAsesorias.Models;
namespace SistemaDeAsesorias.Controllers
{
    public class CarreraController : Controller
    {
        private readonly IGenericDatos<Carrera> _carrera;

        public CarreraController(IGenericDatos<Carrera> carrera)
        {
            _carrera = carrera;
        }

        public IActionResult Listar()
        {
            List<Carrera> lista = _carrera.GetList();
            return View(lista);
        }
        [HttpPost]
        public IActionResult Eliminar(int idCarrerA)
        {
            bool carreraEliminada = _carrera.Eliminar(idCarrerA);
            if (carreraEliminada)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                // Manejar el caso en que la eliminación no fue exitosa
                return RedirectToAction("Listar");
            }
        }
        public IActionResult Guardar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Guardar(Carrera model)
        {
            bool carreraGuardado = _carrera.Guardar(model);
            if (carreraGuardado)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }

        }
    }
}