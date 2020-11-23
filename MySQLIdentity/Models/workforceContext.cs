using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MySQLIdentity.Models
{
    public partial class workforceContext : DbContext
    {
        public workforceContext()
        {
        }

        public workforceContext(DbContextOptions<workforceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=admin;database=workforce");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PRIMARY");

                entity.ToTable("employee");

                entity.Property(e => e.EmpId).HasColumnName("empId");

                entity.Property(e => e.EmpName)
                    .HasColumnName("empName")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.JobTitle)
                    .HasColumnName("jobTitle")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Salary)
                    .HasColumnName("salary")
                    .HasColumnType("decimal(9,2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
