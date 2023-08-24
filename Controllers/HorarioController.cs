using Microsoft.AspNetCore.Mvc;
using SistemaDeAsesorias.Datos.Contrato;
using SistemaDeAsesorias.Datos.Implementacion;
using SistemaDeAsesorias.Models;
using System.Data.SqlClient;
using System.Data;

namespace SistemaDeAsesorias.Controllers
{
    public class HorarioController : Controller
    {
        private readonly InMultiHorario<HorarioPorAsesor> _multiHorario;
        private readonly IGenericDatos<Asesor> _asesor;
        public HorarioController(InMultiHorario<HorarioPorAsesor> multiHorario,
            IGenericDatos<Asesor> asesor)
        {
            _multiHorario = multiHorario;
            _asesor = asesor;
        }

        public IActionResult SeleccionAsesor()
        {
            List<Asesor> lista = _asesor.GetList();
            return View(lista);
        }

        [HttpPost]
        public IActionResult SeleccionAsesor(int NroEmpleado)
        {
            return RedirectToAction("Horario");
        }

        public IActionResult Horario(int NroEmpleado)
        {
            List<HorarioPorAsesor> lista = _multiHorario.GetList(NroEmpleado);
            return View(lista);
        }/*
        public IActionResult Guardar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Guardar(Horario model, int NroEmpleado)
        {

            bool horarioGuardado = _horario.Guardar(model, NroEmpleado);
            if (horarioGuardado)
            {
                return RedirectToAction("Horario");
            }
            else
            {
                return View();
            }
        }*/

    }
}


