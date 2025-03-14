using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesApi.Domain.Entities;
using SalesApi.Infrastructure.Entities;

namespace SalesApi.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<SaleEntity> Sales { get; set; }
        public DbSet<SaleItemEntity> SaleItems { get; set; }
        public DbSet<ProductEntity> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>();

            modelBuilder.Entity<SaleEntity>()
                .HasMany(s => s.Items)
                .WithOne(si => si.Sale)
                .HasForeignKey(si => si.SaleId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SaleItemEntity>()
                .Property(si => si.Id)
                .ValueGeneratedOnAdd();

            base.OnModelCreating(modelBuilder);
        }
    }
}
