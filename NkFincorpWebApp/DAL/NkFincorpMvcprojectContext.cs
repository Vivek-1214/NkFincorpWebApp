using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NkFincorpWebApp.DAL;

public partial class NkFincorpMvcprojectContext : DbContext
{

    public NkFincorpMvcprojectContext()
    {
    }

    public NkFincorpMvcprojectContext(DbContextOptions<NkFincorpMvcprojectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("server=localhost\\SQLEXPRESS; database=NkFincorpMVCproject; trusted_connection=true; trustservercertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC074A70236A");

            entity.Property(e => e.AadharCard)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MaritalStatus)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Position).WithMany(p => p.Customers)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("FK__Customers__Posit__4BAC3F29");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Position__3214EC0741F621A7");

            entity.Property(e => e.Text)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
