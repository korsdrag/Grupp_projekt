using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EmployeesProj.Models.Entities
{
    public partial class EmployeesContext : DbContext
    {
        public EmployeesContext()
        {
        }

        public EmployeesContext(DbContextOptions<EmployeesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Finnish_Swedish_CI_AI");

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.CompanyName).HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.CompanyId).HasColumnName("CompanyID");

                entity.Property(e => e.Email).HasMaxLength(64);

                entity.Property(e => e.Name).HasMaxLength(32);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__Employees__Compa__38996AB5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
