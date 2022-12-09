using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using multiconstrucciones_api.Models.DTO;
using System.Text;
using multiconstrucciones_api.Models;
using Microsoft.EntityFrameworkCore;

namespace multiconstrucciones_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpleadosController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly MulticonstruccionesContext _context;

        public EmpleadosController(IConfiguration config, MulticonstruccionesContext context)
        {
            _config = config;
            _context = context;
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Empleado empleado)
        {
            try
            {

                var empleados = await _context.Empleados
                    .Where(c => c.NomEmpleado == empleado.NomEmpleado && c.Apaterno == empleado.Apaterno && c.Amaterno == empleado.Amaterno)
                    .FirstOrDefaultAsync();

                if (empleados != null)
                {
                    return Ok(new
                    {
                        error = "error",
                        summary = "Error al grabar.",
                        message = "Ya existe el empleado con estos datos.",
                    });
                }
                _context.Empleados.Add(empleado);
                int cfa = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
            return Ok(new
            {
                error = "success",
                summary = "Grabar empleado.",
                message = "Empleado agregado correctamente con el id: " + empleado.NumEmpleado + ".",
                data = empleado
            });
        }

    }
}
