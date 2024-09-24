using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ASPCoreWebAPI.Models
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

        public virtual DbSet<MyTable> MyTables { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MyTable>(entity =>
            {
                entity.HasKey(e => e.SId)
                    .HasName("PK__MyTable__A3DFF08D19EF3161");

                entity.ToTable("MyTable");

                entity.Property(e => e.SId)
                    .ValueGeneratedNever()
                    .HasColumnName("S_Id");

                entity.Property(e => e.SAddress)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("S_Address");

                entity.Property(e => e.SAge).HasColumnName("S_Age");

                entity.Property(e => e.SClass)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("S_Class");

                entity.Property(e => e.SName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("S_Name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
