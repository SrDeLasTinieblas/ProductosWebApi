//using Biblioteca.Domain.Entities;
using Biblioteca.Domain.DTOs;
using Biblioteca.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Idcategories).HasName("PK__Categori__0A58588C15306274");

                entity.Property(e => e.Idcategories).HasColumnName("IDCategories");
                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Idproducts).HasName("PK__Products__ABDAF2A89391E230");

                entity.Property(e => e.Idproducts).HasColumnName("IDProducts");
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Category).WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Products__Catego__5165187F");
            });

            base.OnModelCreating(modelBuilder);
        }


    }
}
