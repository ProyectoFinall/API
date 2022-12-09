using Microsoft.AspNetCore.Mvc;
using multiconstrucciones_api.Models;
using Microsoft.EntityFrameworkCore;

namespace multiconstrucciones_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DefectosController : Controller
    {
        private readonly IConfiguration _config;
        private readonly MulticonstruccionesContext _context;

        public DefectosController(IConfiguration config, MulticonstruccionesContext context)
        {
            _config = config;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _context.Defectos
                                    .ToListAsync();
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Defectos defectos)
        {
            try
            {
                _context.Defectos.Add(defectos);
                int cfa = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
            return Ok(new
            {
                error = "success",
                summary = "Grabar defectos.",
                message = "Defecto agregado correctamente.",
                data = defectos
            });
        }
    }
}
