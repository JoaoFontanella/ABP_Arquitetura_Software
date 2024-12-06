using Microsoft.AspNetCore.Mvc;
using CursoOnlineAPI.Models;
using Microsoft.EntityFrameworkCore;
using CursoOnlineAPI.Dtos;

namespace CursoOnlineAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatriculaController : ControllerBase
    {
        private readonly DataContext _context;

        public MatriculaController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Matrículas>>> GetMatriculas()
        {
            return Ok(await _context.Matrículas
                .Include(m => m.Alunos)
                .Include(m => m.Cursos)
                .ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> CreateMatricula(MatriculaRequestDTO matriculaRequest)
        {

            var existingMatricula = await _context.Matrículas.FindAsync(matriculaRequest.Id);
            if (existingMatricula != null)
            {
                return BadRequest("Já existe uma matrícula com esse ID.");
            }

            var aluno = await _context.Alunos.FindAsync(matriculaRequest.AlunoId);
            if (aluno == null)
            {
                return NotFound("Aluno não encontrado.");
            }

            var curso = await _context.Cursos.FindAsync(matriculaRequest.CursoId);
            if (curso == null)
            {
                return NotFound("Curso não encontrado.");
            }

            var matricula = new Matrículas
            {
                Id = matriculaRequest.Id,
                AlunoId = matriculaRequest.AlunoId,
                CursoId = matriculaRequest.CursoId
            };

            _context.Matrículas.Add(matricula);
            await _context.SaveChangesAsync();

            return Ok(matricula);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteMatricula(int id)
        {
            var matricula = await _context.Set<Matrículas>().FindAsync(id);
            if (matricula == null)
            {
                return NotFound(new { Message = "Matrícula não encontrada." });
            }
            _context.Set<Matrículas>().Remove(matricula);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "Matrícula excluída com sucesso." });
        }

    }
}
