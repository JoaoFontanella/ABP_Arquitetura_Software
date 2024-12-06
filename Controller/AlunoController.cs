using Microsoft.AspNetCore.Mvc;
using CursoOnlineAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CursoOnlineAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly DataContext _context;

        public AlunoController(DataContext context)
        {
            _context = context;
        }

        // Método GET para listar todos os alunos
        [HttpGet]
        public async Task<ActionResult<List<Alunos>>> GetAlunos()
        {
            return Ok(await _context.Alunos.ToListAsync());
        }

        // Método POST para criar um novo aluno
        [HttpPost]
        public async Task<ActionResult> CreateAluno(Alunos aluno)
        {
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();
            return Ok(aluno);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAluno(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null)
            {
                return NotFound(new { Message = "Aluno não encontrado." });
            }
            var possuiMatriculas = await _context.Matrículas.AnyAsync(m => m.AlunoId == id);
            if (possuiMatriculas)
            {
                return BadRequest(new { Message = "Não é possível excluir o aluno, pois ele está vinculado a um ou mais cursos." });
            }
            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
