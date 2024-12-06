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
            var possuiMatriculas = await _context.Set<Matr�culas>()
                .AnyAsync(m => m.CursoId == id);

            if (possuiMatriculas)
            {
                return BadRequest(new { Message = "N�o � poss�vel excluir o curso, pois ele est� associado a uma ou mais matr�culas." });
            }

            var curso = await _context.Set<Cursos>().FindAsync(id);
            if (curso == null)
            {
                return NotFound(new { Message = "Curso n�o encontrado." });
            }
            _context.Set<Cursos>().Remove(curso);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
