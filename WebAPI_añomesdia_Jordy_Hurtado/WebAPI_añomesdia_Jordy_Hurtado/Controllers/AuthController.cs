using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_añomesdia_Jordy_Hurtado.DTOs.Requuest;
using WebAPI_añomesdia_Jordy_Hurtado.DTOs.Response;
using WebAPI_añomesdia_Jordy_Hurtado.Service;

namespace WebAPI_añomesdia_Jordy_Hurtado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(LoginResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<LoginResponseDto>> Login(
            [FromBody] LoginRequestDto request)
        {
            var respuesta = await _authService.LoginAsync(request);

            if (respuesta == null)
            {
                return Unauthorized(new
                {
                    mensaje = "Correo o contraseña incorrectos."
                });
            }

            return Ok(respuesta);
        }
    }
}

