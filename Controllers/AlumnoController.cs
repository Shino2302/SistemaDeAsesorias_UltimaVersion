using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaDeAsesorias.Datos.Contrato;
using SistemaDeAsesorias.Models;

namespace SistemaDeAsesorias.Controllers
{
    public class AlumnoController : Controller
    {
        private IGenericDatos<Alumno> _Alumno;
        private IGenericDatos<Grupo> _Grupo;
        public AlumnoController(IGenericDatos<Alumno> Alumno, IGenericDatos<Grupo> Grupo)
        {
            _Alumno = Alumno;
            _Grupo = Grupo;
        }

        public IActionResult Listar()
        {
            List<Alumno> lista = _Alumno.GetList();
            return View(lista);
        }
        public IActionResult Guardar()
        {
            List<Grupo> lista = _Grupo.GetList();
            List<SelectListItem> listaC = lista.ConvertAll(
                item => new SelectListItem()
                {
                    Text = item.Nombre.ToString(),
                    Value = item.IdGrupo.ToString(),
                    Selected = false
                });
                ViewBag.Lista = listaC;
                return View();
        }
        [HttpPost]
        public IActionResult Guardar(Alumno model)
        {
            bool AlumnoGuardado = _Alumno.Guardar(model);
            if(AlumnoGuardado)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult Eliminar(int matricula)
        {
            bool alumnoEliminado = _Alumno.Eliminar(matricula);
            if (alumnoEliminado)
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
        