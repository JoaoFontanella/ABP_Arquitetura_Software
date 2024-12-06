using Microsoft.AspNetCore.Mvc;
using CursoOnlineAPI.Models;
using Microsoft.EntityFrameworkCore;

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

        // Método GET para listar todas as matrículas
        [HttpGet]
        public async Task<ActionResult<List<Matrículas>>> GetMatriculas()
        {
            return Ok(await _context.Matrículas
                .Include(m => m.Alunos)
                .Include(m => m.Cursos)
                .ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> CreateMatricula(Matrículas matriculaRequest)
        {
            // Busca o aluno pelo ID
            var aluno = await _context.Alunos.FindAsync(matriculaRequest.AlunoId);
            if (aluno == null)
            {
                return NotFound("Aluno não encontrado.");
            }

            // Busca o curso pelo ID
            var curso = await _context.Cursos.FindAsync(matriculaRequest.CursoId);
            if (curso == null)
            {
                return NotFound("Curso não encontrado.");
            }

            // Cria a matrícula
            var matricula = new Matrículas
            {
                AlunoId = matriculaRequest.AlunoId,
                CursoId = matriculaRequest.CursoId,
                Alunos = aluno,
                Cursos = curso
            };

            _context.Matrículas.Add(matricula);
            await _context.SaveChangesAsync();

            return Ok(matricula);
        }

    }
}
