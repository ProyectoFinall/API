using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using multiconstrucciones_api.Models;
using multiconstrucciones_api.Models.DTO;

namespace multiconstrucciones_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VigaController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly MulticonstruccionesContext _context;

        public VigaController(IConfiguration config, MulticonstruccionesContext context)
        {
            _config = config;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _context.Vigas
                .ToListAsync();
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int ClvViga)
        {
            var result = await _context.Vigas
                .Where(p => p.ClvViga == ClvViga)
                .FirstOrDefaultAsync();
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Viga viga)
        {
            try
            {
                int totalVigas = 0;
                var obraViga = await _context.Obras
                    .Where(c => c.ClvObra == viga.ClvObra)
                    .FirstOrDefaultAsync();


                var CantVigasxObra = from p in _context.Vigas
                                     group p by p.ClvObra into g
                                     where g.Key == viga.ClvObra
                                     select new
                                     {
                                         name = g.Key,
                                         count = g.Count()
                                     };
                foreach (var groupedCycle in CantVigasxObra)
                {
                    totalVigas += groupedCycle.count;
                }

                if (obraViga!.CantidadVigas <= totalVigas)
                {
                    return Ok(new
                    {
                        error = "info",
                        summary = "Grabar viga.",
                        message = "No se puede agregar más vigas a esta obra.",
                        data = viga
                    });
                }
                //_context.Vigas
                //    .Where(p => p.ClvObra == viga.ClvObra).Count(p => p.ClvViga);


                viga.FechaViga = DateTime.Now;
                _context.Vigas.Add(viga);
                int cfa = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
            return Ok(new
            {
                error = "success",
                summary = "Grabar viga.",
                message = "Viga agregada correctamente.",
                data = viga
            });
            //return Ok(new { error = false, viga });
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] VigaDTO viga)
        {
            try
            {
                Viga? vigas = await _context.Vigas
                    .Where(p => p.ClvViga == viga.ClvViga)
                    .FirstOrDefaultAsync();

                if (vigas!.ClvProceso != viga.ClvProceso)
                {
                    Proceso_Detalle proceso_Detalle = new Proceso_Detalle();
                    proceso_Detalle.ClvObra = vigas.ClvObra;
                    proceso_Detalle.ClvViga = vigas.ClvViga;
                    proceso_Detalle.ClvProceso = (int)viga.ClvProceso!;
                    proceso_Detalle.PesoViga = (int)vigas.PesoViga!;
                    proceso_Detalle.NumEmpleado = viga.NumEmpleado;
                    proceso_Detalle.FechaProcesoInicia = DateTime.Now;
                    _context.Proceso_Detalle.Add(proceso_Detalle);
                }

                vigas!.ClvDefecto = viga.ClvDefecto;
                vigas!.ClvProceso = viga.ClvProceso;
                vigas!.NumEmpleado = viga.NumEmpleado;

                var result = await _context.SaveChangesAsync();

                return Ok(new
                {
                    error = "success",
                    summary = "Grabar viga.",
                    message = "Viga actualizada correctamente.",
                    data = viga
                });
                //_context.Vigas.Add(viga);
                //int cfa = await _context.Update();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
    }
}
