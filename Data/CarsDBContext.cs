using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Autopedia.Models;

#nullable disable

namespace Autopedia.Data
{
    public partial class CarsDBContext : DbContext
    {
        public CarsDBContext()
        {
        }

        public CarsDBContext(DbContextOptions<CarsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<FamousCar> FamousCars { get; set; }
        public virtual DbSet<FormulaTeam> FormulaTeams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
