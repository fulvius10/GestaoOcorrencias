using GestaoOcorrencias.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestaoOcorrencias.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Ocorrencia> Ocorrencias { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Ocorrencia>()
                .HasOne(o => o.ResponsavelAbertura)
                .WithMany()
                .HasForeignKey(o => o.ResponsavelAberturaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ocorrencia>()
                .HasOne(o => o.ResponsavelOcorrencia)
                .WithMany()
                .HasForeignKey(o => o.ResponsavelOcorrenciaId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Cliente>().HasKey(c => c.Id);
            modelBuilder.Entity<Ocorrencia>().HasKey(o => o.Id);
            base.OnModelCreating(modelBuilder);

        }
    }
}
