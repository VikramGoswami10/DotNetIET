using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using _15DataBaseFirstEF.Models;

namespace _15DataBaseFirstEF.Data
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=DB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Eid)
                    .HasName("PK__Employee__C190176B9AAEB229");

                entity.ToTable("Employee");

                entity.Property(e => e.Eid)
                    .ValueGeneratedNever()
                    .HasColumnName("EId");

                entity.Property(e => e.Eaddress)
                    .HasMaxLength(10)
                    .HasColumnName("EAddress")
                    .IsFixedLength();

                entity.Property(e => e.Ename)
                    .HasMaxLength(10)
                    .HasColumnName("EName")
                    .IsFixedLength();

                entity.Property(e => e.Esalary)
                    .HasMaxLength(10)
                    .HasColumnName("ESalary")
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
