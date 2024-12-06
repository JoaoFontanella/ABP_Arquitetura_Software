using Microsoft.AspNetCore.Mvc;
using CursoOnlineAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CursoOnlineAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CursoController : ControllerBase
	{
		private readonly DataContext _context;

        public CursoController(DataContext context)
		{
			_context = context;

        }

        [HttpGet]
		public async Task<ActionResult<List<Cursos>>> GetCursos()
		{
			return Ok(await _context.Cursos.ToListAsync());
		}

		[HttpPost]
		public async Task<ActionResult> CreateCurso(Cursos curso)
		{
			_context.Cursos.Add(curso);
			await _context.SaveChangesAsync();
			return Ok(curso);
		}

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteCurso(int id)
        {
            var possuiMatriculas = await _context.Set<Matrículas>()
                .AnyAsync(m => m.CursoId == id);

            if (possuiMatriculas)
            {
                return BadRequest(new { Message = "Não é possível excluir o curso, pois ele está associado a uma ou mais matrículas." });
            }

            var curso = await _context.Set<Cursos>().FindAsync(id);
            if (curso == null)
            {
                return NotFound(new { Message = "Curso não encontrado." });
            }
            _context.Set<Cursos>().Remove(curso);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
