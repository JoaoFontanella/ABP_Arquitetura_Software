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

        [HttpGet]
        public async Task<ActionResult<List<Alunos>>> GetAlunos()
        {
            return Ok(await _context.Alunos.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> CreateAluno(Alunos aluno)
        {

            var existingAluno = await _context.Alunos.FindAsync(aluno.Id);
            if (existingAluno != null)
            {
                return BadRequest(new { Message = "Já existe um aluno com esse ID." });
            }

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
            return Ok(new { Message = "Aluno excluído com sucesso." });
        }
    }
}
