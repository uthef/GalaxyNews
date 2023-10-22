using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace GalaxyNews.Database.Models;

public partial class GalaxyNewsContext : DbContext
{
    public GalaxyNewsContext()
    {
    }

    public GalaxyNewsContext(DbContextOptions<GalaxyNewsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Article> News { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("galaxynews_cs"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("news_pkey");

            entity.ToTable("news");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Announce)
                .HasColumnType("character varying")
                .HasColumnName("announce");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Image)
                .HasColumnType("character varying")
                .HasColumnName("image");
            entity.Property(e => e.Title)
                .HasColumnType("character varying")
                .HasColumnName("title");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
