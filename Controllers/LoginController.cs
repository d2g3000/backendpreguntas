using backendpreguntas.Domain.Iservices;
using backendpreguntas.Domain.Models;
using backendpreguntas.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backendpreguntas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {   
        private readonly ILoginService _iLoginserService;
        private readonly IConfiguration _config;
        public LoginController(ILoginService iloginservice,IConfiguration config)
        {
            _iLoginserService= iloginservice;
            _config= config;
        }

        [HttpPost]
        public async Task<IActionResult>Post([FromBody]Usuario usuario)
        {
            try
            {
                usuario.password = Encriptar.EncriptarPassword(usuario.password);
                var data = await _iLoginserService.ValidateUser(usuario);
                if (data==null)
                {
                   return BadRequest(new { message = "Datos incorrectos" });
                }
                string tokenString = JwtConfigurator.GetToken(data,_config);
                return Ok(new { token = tokenString } );
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
