using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_añomesdia_Jordy_Hurtado.Data;
using WebAPI_añomesdia_Jordy_Hurtado.Models;

namespace WebAPI_añomesdia_Jordy_Hurtado.Service
{
    public class CursoService
    {
        private readonly DbConexion _context;

        public CursoService(DbConexion context)
        {
            _context = context;
        }


        public List<Curso> GetCursosByInstructorId(int instructorId)
        {
            return _context.Cursos.Where(c => c.InstructorId == instructorId).ToList();
        }



        public async Task CrearAsync(Curso curso)
        {
            _context.Cursos.Add(curso);
            await _context.SaveChangesAsync();
            
        }



    }
}
