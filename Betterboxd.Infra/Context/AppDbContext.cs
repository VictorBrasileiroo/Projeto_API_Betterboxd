using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Betterboxd.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Betterboxd.Infra.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
        public DbSet<FilmeModel> Filmes { get; set; }
        public DbSet<AvaliacaoModel> Avaliações { get; set; }
        public DbSet<UserModel> Usuários { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AvaliacaoModel>()
                .HasOne(a => a.Usuario)
                .WithMany(u => u.Avaliacoes)
                .HasForeignKey(a => a.IdUser)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AvaliacaoModel>()
                .HasOne(a => a.Filme)
                .WithMany(f => f.Avaliacoes)
                .HasForeignKey(a => a.IdFilme)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
