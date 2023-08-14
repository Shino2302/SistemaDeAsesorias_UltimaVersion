using Microsoft.AspNetCore.Mvc;
using SistemaDeAsesorias.Datos.Contrato;
using SistemaDeAsesorias.Models;

namespace SistemaDeAsesorias.Controllers
{
    public class TipoAsesoriaController : Controller
    {
        private readonly IGenericDatos<TipoAsesoria> _ta;
        public TipoAsesoriaController(IGenericDatos<TipoAsesoria> ta)
        {
            _ta = ta;
        }
    
        public IActionResult Listar()
        {
            List<TipoAsesoria> lista = _ta.GetList();
            return View(lista);
        }
        public IActionResult Guardar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Guardar(TipoAsesoria model)
        {
            bool tipoAsesoriaGuardado = _ta.Guardar(model);
            if (tipoAsesoriaGuardado)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult Eliminar(int idTA)
        {
            bool TAEliminada = _ta.Eliminar(idTA);
            if (TAEliminada)
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
