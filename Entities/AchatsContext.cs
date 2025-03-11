using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API.Entities;

public partial class AchatsContext : DbContext
{
    public AchatsContext()
    {
    }

    public AchatsContext(DbContextOptions<AchatsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<Consomateur> Consomateurs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=;database=Achats");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Article", "Achats");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nom).HasMaxLength(50);
        });

        modelBuilder.Entity<Consomateur>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Consomateurs", "Achats");

            entity.Property(e => e.Adresse).HasMaxLength(100);
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nom).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
