using Microsoft.AspNetCore.Mvc;
using SistemaDeAsesorias.Datos.Contrato;
using SistemaDeAsesorias.Models;

namespace SistemaDeAsesorias.Controllers
{
    public class CuatriCarreraController : Controller
    {
        private readonly IGenericDatos<CuatriCarrera> _cuatriCarrera;

        public CuatriCarreraController(IGenericDatos<CuatriCarrera> cuatriCarrera)
        {
            _cuatriCarrera = cuatriCarrera;
        }
        public IActionResult Listar()
        {
            List<CuatriCarrera> lista = _cuatriCarrera.GetList();
            return View(lista);
        }
        [HttpPost]
        public IActionResult Eliminar(int idCC)
        {
            bool CCEliminada = _cuatriCarrera.Eliminar(idCC);
            if (CCEliminada)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                // Manejar el caso en que la eliminación no fue exitosa
                return RedirectToAction("Listar");
            }
        }
    }
}