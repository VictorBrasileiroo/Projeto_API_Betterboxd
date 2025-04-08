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
        DbSet<FilmeModel> Filmes { get; set; }
    }
}
