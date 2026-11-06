using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebAPI_añomesdia_Jordy_Hurtado.Models;
using WebAPI_añomesdia_Jordy_Hurtado.Service;

namespace WebAPI_añomesdia_Jordy_Hurtado.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly CursoService _cursoService;

        public CursoController(CursoService cursoService)
        {
            _cursoService = cursoService;
        }



        [HttpGet]
        public IActionResult ObtenerCursos()
        {
            var instructorId = ObtenerUsuarioId();

            if (instructorId is null)
            {
                return Unauthorized();
            }

            var cursos = _cursoService.GetCursosByInstructorId(instructorId.Value);

            return Ok(cursos);
        }

        [HttpPost]
        public async Task<IActionResult> CrearCurso([FromBody] Curso curso)
        {
            var instructorId = ObtenerUsuarioId();

            if (instructorId is null)
            {
                return Unauthorized();
            }

            curso.InstructorId = instructorId.Value;

            await _cursoService.CrearAsync(curso);

            return Ok(new
            {
                mensaje = "Curso creado correctamente.",
                curso
            });
        }

        private int? ObtenerUsuarioId()
        {
            var claim = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return int.TryParse(claim, out var usuarioId)
                ? usuarioId
                : null;
        }
    }
}
