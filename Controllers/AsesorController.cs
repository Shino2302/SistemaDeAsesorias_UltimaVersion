using Microsoft.AspNetCore.Mvc;
using SistemaDeAsesorias.Datos.Contrato;
using SistemaDeAsesorias.Models;

namespace SistemaDeAsesorias.Controllers
{
    public class AsesorController : Controller
    {
        private readonly IGenericDatos<Asesor> _asesor;

        public AsesorController(IGenericDatos<Asesor> asesor)
        {
            _asesor = asesor;
        }

        public IActionResult Listar()
        {
            List<Asesor> lista = _asesor.GetList();
            return View(lista);
        }
        public IActionResult Guardar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Guardar(Asesor model)
        {
            bool asesorGuardado = _asesor.Guardar(model);
            if (asesorGuardado)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult Eliminar(int nroEmpleado)
        {
            bool asesorEliminado = _asesor.Eliminar(nroEmpleado);
            if (asesorEliminado)
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
