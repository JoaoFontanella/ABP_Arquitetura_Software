using Microsoft.EntityFrameworkCore;
using CursoOnlineAPI.Models;

namespace CursoOnlineAPI
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Cursos> Cursos { get; set; }
        public DbSet<Alunos> Alunos { get; set; }
        public DbSet<Matr�culas> Matr�culas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Matr�culas>()
                .HasOne(m => m.Alunos)
                .WithMany()
                .HasForeignKey(m => m.AlunoId);

            modelBuilder.Entity<Matr�culas>()
                .HasOne(m => m.Cursos)
                .WithMany()
                .HasForeignKey(m => m.CursoId);
        }

    }
}
