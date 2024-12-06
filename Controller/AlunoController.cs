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
    }
}
