using Microsoft.EntityFrameworkCore;
using CursoOnlineAPI.Models;

namespace CursoOnlineAPI
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Cursos> Cursos { get; set; }
        public DbSet<Alunos> Alunos { get; set; }
        public DbSet<Matrículas> Matrículas { get; set; }
    }
}
