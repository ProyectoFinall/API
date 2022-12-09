using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using multiconstrucciones_api.Models;

namespace multiconstrucciones_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ObraController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly MulticonstruccionesContext _context;

        public ObraController(IConfiguration config, MulticonstruccionesContext context)
        {
            _config = config;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _context.Obras
                                    .ToListAsync();
            return Ok(result);
        }
        [HttpGet("detalles")]
        public async Task<IActionResult> Detalles()
        {
            //var result = await _context.Obras
                //.Include(d => d.VigasLst)
                //.ToListAsync();

            var result = (from ep in _context.Obras
                              join e in _context.Vigas on ep.ClvObra equals e.ClvObra
                              join p in _context.Proceso on e.ClvProceso equals p.ClvProceso into px
                              from p in px.DefaultIfEmpty()
                              select new
                              {
                                  ClvObra = ep.ClvObra,
                                  NomObra = ep.NomObra,
                                  ClvViga = e.ClvViga,
                                  Largo = e.LargoViga,
                                  Peso = e.PesoViga,
                                  Material = e.Material,
                                  p.ProcesoNombre
                              });

            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Obra obra)
        {
            try
            {
                obra.FechaObra = DateTime.Now;
                _context.Obras.Add(obra);
                int cfa = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

            return Ok(new
            {
                error = "success",
                summary = "Grabar obra.",
                message = "Obra agregada correctamente.",
                data = obra
            });
        }
    }
}
