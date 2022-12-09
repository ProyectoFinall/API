using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using multiconstrucciones_api.Models;
using multiconstrucciones_api.Models.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace multiconstrucciones_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly MulticonstruccionesContext _context;

        public UsuariosController(IConfiguration config, MulticonstruccionesContext context)
        {
            _config = config;
            _context = context;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] EmpleadoLoginDTO userLogin)
        {
            var userFromRepo = await _context.Usuarios
                .Where(b => b.NumEmpleado == userLogin.NumEmpleado && b.Contraseña == userLogin.password)
                .FirstOrDefaultAsync();

            if (userFromRepo == null)
            {
                return StatusCode((int)HttpStatusCode.Unauthorized, "");
                //return Ok(new { error = true, message = "No existe el usuario ingresado." });
            }
            var empleado = await _context.Empleados
                .Where(c => c.NumEmpleado == userFromRepo.NumEmpleado)
                .FirstOrDefaultAsync();
            //Crea las llaves   para el token JWT
            var Claims = new[]
            {
                    new Claim("NumEmpleado", empleado.NumEmpleado.ToString()),
                    new Claim("NomEmpleado", empleado.NomEmpleado.ToString()),
                    new Claim("Apaterno", empleado.Apaterno.ToString()),
                    new Claim("Amaterno", empleado.Amaterno.ToString()),
                    new Claim("Puesto", empleado.Puesto.ToString())
                };
            var key = new SymmetricSecurityKey(Encoding.UTF8
                    .GetBytes(_config.GetSection("AppSettings:Secret").Value));

            SigningCredentials Credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature); // Firma el token

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(Claims), //Agrega los claims
                Expires = DateTime.Now.AddDays(1), // El tiempo de expiracion del token
                SigningCredentials = Credentials, //Las credenciales
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescription);

            return Ok(new
            {
                error = false,
                message = "Usuario encontrado.",
                token = tokenHandler.WriteToken(token)
            });
        }

        [HttpPost("LoginWeb")]
        public async Task<IActionResult> LoginWeb([FromBody] EmpleadoLoginDTO userLogin)
        {
            var userFromRepo = await _context.Usuarios
                .Where(b => b.NumEmpleado == userLogin.NumEmpleado && b.Contraseña == userLogin.password)
                .FirstOrDefaultAsync();

            if (userFromRepo == null)
            {
                return Ok(new { error = true, message = "No existe el usuario ingresado." });
            }
            var empleado = await _context.Empleados
                .Where(c => c.NumEmpleado == userFromRepo.NumEmpleado)
                .FirstOrDefaultAsync();
            //Crea las llaves   para el token JWT
            var Claims = new[]
            {
                    new Claim("NumEmpleado", empleado.NumEmpleado.ToString()),
                    new Claim("NomEmpleado", empleado.NomEmpleado.ToString()),
                    new Claim("Apaterno", empleado.Apaterno.ToString()),
                    new Claim("Amaterno", empleado.Amaterno.ToString()),
                    new Claim("Puesto", empleado.Puesto.ToString())
                };
            var key = new SymmetricSecurityKey(Encoding.UTF8
                    .GetBytes(_config.GetSection("AppSettings:Secret").Value));

            SigningCredentials Credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature); // Firma el token

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(Claims), //Agrega los claims
                Expires = DateTime.Now.AddDays(1), // El tiempo de expiracion del token
                SigningCredentials = Credentials, //Las credenciales
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescription);

            return Ok(new
            {
                error = false,
                message = "Usuario encontrado.",
                token = tokenHandler.WriteToken(token)
            });
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Usuario usuario)
        {
            try
            {
                var obraViga = await _context.Usuarios
                    .Where(c => c.NumEmpleado == usuario.NumEmpleado)
                    .FirstOrDefaultAsync();

                if (obraViga != null)
                {
                    return Ok(new
                    {
                        error = "error",
                        summary = "Error al grabar.",
                        message = "Código de empleado ya tiene usuario asignado.",
                    });
                }

                _context.Usuarios.Add(usuario);
                int cfa = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
            return Ok(new
            {
                error = "success",
                summary = "Grabar usuario.",
                message = "Usuario agregado correctamente.",
                data = usuario
            });
        }
    }
}
