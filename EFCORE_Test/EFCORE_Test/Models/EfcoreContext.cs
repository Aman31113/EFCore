using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFCORE_Test.Models;

public partial class EfcoreContext : DbContext
{
    public EfcoreContext()
    {
    }

    public EfcoreContext(DbContextOptions<EfcoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EfcoreEmployee> EfcoreEmployees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source =LTIN619237\\SQLEXPRESS;database=efcore;integrated security=true;trustservercertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EfcoreEmployee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__efcore_E__7AD04FF10ABD33CC");

            entity.ToTable("efcore_Employees");

            entity.Property(e => e.EmployeeId)
                .ValueGeneratedNever()
                .HasColumnName("EmployeeID");
            entity.Property(e => e.Department)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
