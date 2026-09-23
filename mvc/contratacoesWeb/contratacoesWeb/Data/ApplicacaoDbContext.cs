using contratacoesWeb.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
namespace contratacoesWeb.Data
{
    public class AplicacaoDbContext : DbContext
    {
        public DbSet<Recrutadores> Recrutadores { get; init; }

        public DbSet<Candidatos> Candidatos { get; init; }

        public DbSet<Vagas> Vagas { get; init; }

        public AplicacaoDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Recrutadores>().ToCollection("Recrutadores");
            modelBuilder.Entity<Candidatos>().ToCollection("Candidatos");
            modelBuilder.Entity<Vagas>().ToCollection("Vagas");

        }
    }
}
