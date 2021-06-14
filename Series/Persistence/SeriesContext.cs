using Microsoft.EntityFrameworkCore;
using Series.Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Series.Persistence
{
    public class SeriesContext : DbContext
    {
        public SeriesContext(DbContextOptions<SeriesContext> options) : base(options)
        {

        }

        public DbSet<Serie> Series { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Serie>(e =>
            {
                e.HasKey(s => s.Id);
            });
        }
    }
}
