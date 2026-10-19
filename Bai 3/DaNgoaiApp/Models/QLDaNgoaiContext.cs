using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DaNgoaiApp.Models;

public partial class QLDaNgoaiContext : DbContext
{
    public QLDaNgoaiContext()
    {
    }

    public QLDaNgoaiContext(DbContextOptions<QLDaNgoaiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChuyenDi> ChuyenDis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(ConfigurationHelper.GetConnectionString());
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChuyenDi>(entity =>
        {
            entity.HasKey(e => e.MaChuyen).HasName("PK__ChuyenDi__0ED32A4790009B74");

            entity.ToTable("ChuyenDi");

            entity.Property(e => e.DiaDiem).HasMaxLength(100);
            entity.Property(e => e.GhiChu).HasMaxLength(200);
            entity.Property(e => e.NganSach).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.PhuongTien).HasMaxLength(30);
            entity.Property(e => e.TenChuyen).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
