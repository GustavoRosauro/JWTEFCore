using JWTEntityCore.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTEntityCore.Data
{
    public class EscolaDbContext:DbContext
    {
        public EscolaDbContext(DbContextOptions<EscolaDbContext> options) : base(options) { }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<AlunoProfessorCurso> AlunosCursosProfessores { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlunoProfessorCurso>()
               .HasOne(x => x.Aluno)
               .WithMany().HasForeignKey(x => x.IdAluno);
            modelBuilder.Entity<AlunoProfessorCurso>()
               .HasOne(x => x.Professor)
               .WithMany().HasForeignKey(x => x.IdProfessor);
            modelBuilder.Entity<AlunoProfessorCurso>()
               .HasOne(x => x.Curso)
               .WithMany().HasForeignKey(x => x.IdCurso);
        }
    }
}
