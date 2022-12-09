using Microsoft.AspNetCore.Mvc;
using multiconstrucciones_api.Models;
using Microsoft.EntityFrameworkCore;

namespace multiconstrucciones_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProcesoController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly MulticonstruccionesContext _context;

        public ProcesoController(IConfiguration config, MulticonstruccionesContext context)
        {
            _config = config;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _context.Proceso
                                    .ToListAsync();
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Proceso proceso)
        {
            try
            {
                _context.Proceso.Add(proceso);
                int cfa = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
            return Ok(new
            {
                error = "success",
                summary = "Grabar proceso.",
                message = "Proceso agregado correctamente.",
                data = proceso
            });
        }
    }
}
