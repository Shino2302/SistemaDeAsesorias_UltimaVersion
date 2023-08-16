using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaDeAsesorias.Datos.Contrato;
using SistemaDeAsesorias.Models;

namespace SistemaDeAsesorias.Controllers
{
    public class GrupoController : Controller
    {
        private InterMultiDatos<ConsultaGrupoModel> _grupo;
        private IGenericDatos<CuatriCarrera> _cuatriCarrera;
        public GrupoController(InterMultiDatos<ConsultaGrupoModel> grupo){
            _grupo = grupo;
        }
        public IActionResult Listar(){
            List<ConsultaGrupoModel> lista = _grupo.GetList();
            return View(lista);
        }
        public IActionResult Guardar(){
            List<CuatriCarrera>lista = _cuatriCarrera.GetList();
            List<SelectListItem> listC = lista.ConvertAll(
                item => new SelectListItem()
                {
                    Text = item.IdCarrera1.ToString(),
                    Value = item.IdCC.ToString(),
                    Selected = false
                });
            ViewBag.Lista = listC;
            return View();
        }
        /*
        [HttpPost]
        public IActionResult Guardar(Grupo model){
            bool grupoGuardado = _grupo.Guardar(model);
            if(grupoGuardado)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }
       [HttpPost]
        public IActionResult Eliminar(int idGrupo)
        {
            bool grupoEliminado = _grupo.Eliminar(idGrupo);
            if (grupoEliminado)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                // Manejar el caso en que la eliminación no fue exitosa
                return RedirectToAction("Listar");
            }
        }
        */
    }
}