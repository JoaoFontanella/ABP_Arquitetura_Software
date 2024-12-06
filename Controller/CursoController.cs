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
	}
}
