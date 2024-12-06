using CursoOnlineAPI.Models;

namespace CursoOnlineAPI.Models
{
    public class Matrículas
    {
        public int Id { get; set; }
        public int AlunoId { get; set; }
        public Alunos? Alunos { get; set; }
        public int CursoId { get; set; }
        public Cursos? Cursos { get; set; }
    }
}
