using backendpreguntas.Domain.Iservices;
using backendpreguntas.Domain.Models;
using backendpreguntas.DTO;
using backendpreguntas.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace backendpreguntas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Usuario usuario)
        {
            try
            {
                var validate = await _usuarioService.ValidateExistence(usuario);

                if (Convert.ToBoolean(validate)==true)
                {
                    return BadRequest(new { message = "El nombre de usuario ya esta en uso" });
                }
                else
                {
                    usuario.password = Encriptar.EncriptarPassword(usuario.password);
                    await _usuarioService.SaveUser(usuario);
                    return Ok(new { message = "Usuario registrado con exito!" });
                }
           
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Route("cambiarpassword")]
        [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        public async Task<IActionResult> CambiarPassword([FromBody]CambiarPasswordDTO cambiar)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                int id = JwtConfigurator.GetTokenIdUsuario(identity);
               

                string password = Encriptar.EncriptarPassword(cambiar.Password);
                var usuario = await _usuarioService.ValidatePassword(id, password);
                if (usuario==null)
                {
                    return BadRequest(new { message = "Password incorrecto!" });
                }else
                {
                    usuario.password = Encriptar.EncriptarPassword(cambiar.NewPassword);
                   await _usuarioService.UpdatePassword(usuario);

                    return Ok(new { message = "Password cambiado con exito!" });
                }
               
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
