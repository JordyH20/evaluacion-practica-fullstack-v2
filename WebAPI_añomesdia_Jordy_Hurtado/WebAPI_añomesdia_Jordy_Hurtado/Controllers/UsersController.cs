using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_añomesdia_Jordy_Hurtado.DTOs.Requuest;
using WebAPI_añomesdia_Jordy_Hurtado.DTOs.Response;
using WebAPI_añomesdia_Jordy_Hurtado.Service;

namespace WebAPI_añomesdia_Jordy_Hurtado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AuthService _authService;

        public UsersController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("registro")]
        [ProducesResponseType(typeof(UsuarioResponseDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UsuarioResponseDto>> Registrar(
            [FromBody] RegistroUsuarioRequestDto request)
        {
            var usuario = await _authService.RegistrarAsync(request);

            if (usuario == null)
            {
                return BadRequest(new
                {
                    mensaje = "Ya existe un usuario con ese correo."
                });
            }

            return StatusCode(StatusCodes.Status201Created, usuario);
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioResponseDto>>> ObtenerUsuarios()
        {
            var usuarios = await _authService.ObtenerUsuariosAsync();
            return Ok(usuarios);
        }
    }
}

