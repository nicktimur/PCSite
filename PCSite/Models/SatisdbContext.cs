using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace PCSite.Models;

public partial class SatisdbContext : DbContext
{
    public SatisdbContext()
    {
    }

    public SatisdbContext(DbContextOptions<SatisdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Kullanici> Kullanicis { get; set; }

    public virtual DbSet<Sepet> Sepets { get; set; }

    public virtual DbSet<Sepeturun> Sepeturuns { get; set; }

    public virtual DbSet<Urun> Uruns { get; set; }

    public virtual DbSet<Ozellik> Urundetays { get; set; }

    public DbSet<UrunOzellik> UrunOzelliks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("Server=200.0.0.119;Port=3306;Database=satisdb;Uid=user;Pwd=1111;", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.38-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Kullanici>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("kullanici");

            entity.HasIndex(e => e.Email, "Email").IsUnique();

            entity.Property(e => e.Ad).HasMaxLength(100);
            entity.Property(e => e.Adres).HasMaxLength(255);
            entity.Property(e => e.KayitTarihi).HasColumnType("datetime");
            entity.Property(e => e.Sifre).HasMaxLength(255);
            entity.Property(e => e.Soyad).HasMaxLength(100);
            entity.Property(e => e.TelefonNumarasi).HasMaxLength(15);
        });


        modelBuilder.Entity<Sepet>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("sepet");

            entity.HasIndex(e => e.KullaniciId, "KullaniciId");

            entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");

            entity.HasOne(d => d.Kullanici)
                .WithMany(p => p.Sepets)
                .HasForeignKey(d => d.KullaniciId)
                .HasConstraintName("sepet_ibfk_1");
        });

        modelBuilder.Entity<Sepeturun>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("sepeturun");

            entity.HasIndex(e => e.SepetId, "SepetId");

            entity.HasIndex(e => e.UrunId, "UrunId");


            entity.HasOne(d => d.Sepet).WithMany(p => p.Sepeturuns)
                .HasForeignKey(d => d.SepetId)
                .HasConstraintName("sepeturun_ibfk_1");

            entity.HasOne(d => d.Urun).WithMany(p => p.Sepeturuns)
                .HasForeignKey(d => d.UrunId)
                .HasConstraintName("sepeturun_ibfk_2");
        });

        modelBuilder.Entity<Urun>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("urun");

            entity.Property(e => e.GuncellemeTarihi).HasColumnType("datetime");
            entity.Property(e => e.Kategori).HasMaxLength(50);
            entity.Property(e => e.Marka).HasMaxLength(100);
            entity.Property(e => e.OlusturmaTarihi).HasColumnType("datetime");
            entity.Property(e => e.UrunAdi).HasMaxLength(255);
        });

        modelBuilder.Entity<Ozellik>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ozellik");

            entity.Property(e => e.OzellikAdi).HasMaxLength(255);
            entity.Property(e => e.OzellikTuru).HasMaxLength(255);
        });

        modelBuilder.Entity<UrunOzellik>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("urunozellik");

            entity.Property(e => e.Deger).HasMaxLength(255);

            entity.HasOne(uo => uo.Urun)
                .WithMany(u => u.UrunOzelliks)
                .HasForeignKey(uo => uo.Id)
                .HasConstraintName("urunozellik_ibfk_1");

            entity.HasOne(uo => uo.Ozellik)
                .WithMany(o => o.UrunOzelliks)
                .HasForeignKey(uo => uo.Id)
                .HasConstraintName("urunozellik_ibfk_2");
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
