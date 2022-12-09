using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using multiconstrucciones_api.Models;
using multiconstrucciones_api.Models.DTO;

namespace multiconstrucciones_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConsultasController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly MulticonstruccionesContext _context;

        public ConsultasController(IConfiguration config, MulticonstruccionesContext context)
        {
            _config = config;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ReportesFiltros reportesFiltros)
        {
            var TotalVigas = _context.Vigas
            .Where(p => p.FechaViga>= reportesFiltros.Desde && p.FechaViga <= reportesFiltros.Hasta)
            .Count();

            var Peso = _context.Proceso_Detalle
                .Where(p => p.FechaProcesoInicia >= reportesFiltros.Desde && p.FechaProcesoInicia <= reportesFiltros.Hasta).Sum(p => p.PesoViga);

            var TotalArmado = _context.Proceso_Detalle
                .Where(p => p.ClvProceso == 1 && p.FechaProcesoInicia >= reportesFiltros.Desde && p.FechaProcesoInicia <= reportesFiltros.Hasta).Sum(p => p.PesoViga);

            var TotalSoldado = _context.Proceso_Detalle
                .Where(p => p.ClvProceso == 2 && p.FechaProcesoInicia >= reportesFiltros.Desde && p.FechaProcesoInicia <= reportesFiltros.Hasta).Sum(p => p.PesoViga);


            var TotalPulido = _context.Proceso_Detalle
                .Where(p => p.ClvProceso == 3 && p.FechaProcesoInicia >= reportesFiltros.Desde && p.FechaProcesoInicia <= reportesFiltros.Hasta).Sum(p => p.PesoViga);

            var TotalLimpieza = _context.Proceso_Detalle
                .Where(p => p.ClvProceso == 4 && p.FechaProcesoInicia >= reportesFiltros.Desde && p.FechaProcesoInicia <= reportesFiltros.Hasta).Sum(p => p.PesoViga);

            var TotalPintura = _context.Proceso_Detalle
                .Where(p => p.ClvProceso == 5 && p.FechaProcesoInicia >= reportesFiltros.Desde && p.FechaProcesoInicia <= reportesFiltros.Hasta).Sum(p => p.PesoViga);
            //.Where(o => o.FechaViga == reportesFiltros.Desde)
            //.Select(dGroup.GroupBy(g => g.ItemNumber).Count() == 8)).Single();

            //.Select(g => new { total = g.Sum(i => i.PesoViga) });

            return Ok(new
            {
                Peso = Peso,
                TotalArmado = TotalArmado,
                TotalSoldado = TotalSoldado,
                TotalPulido = TotalPulido,
                TotalLimpieza = TotalLimpieza,
                TotalPintura = TotalPintura,
                TotalVigas = TotalVigas
            });
        }


    }
}
