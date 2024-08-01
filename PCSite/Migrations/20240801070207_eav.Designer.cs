﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PCSite.Models;

#nullable disable

namespace PCSite.Migrations
{
    [DbContext(typeof(SatisdbContext))]
    [Migration("20240801070207_eav")]
    partial class eav
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");
            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("PCSite.Models.Kullanici", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Adres")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Bakiye")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("GuncellenmeTarihi")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("KayitTarihi")
                        .HasColumnType("datetime");

                    b.Property<int>("KullaniciTipi")
                        .HasColumnType("int");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Soyad")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("TelefonNumarasi")
                        .HasMaxLength(15)
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Email" }, "Email")
                        .IsUnique();

                    b.ToTable("kullanici", (string)null);
                });

            modelBuilder.Entity("PCSite.Models.Ozellik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("OzellikAdi")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("OzellikTuru")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("ozellik", (string)null);
                });

            modelBuilder.Entity("PCSite.Models.Sepet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("GuncellemeTarihi")
                        .HasColumnType("datetime");

                    b.Property<int?>("KullaniciId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "KullaniciId" }, "KullaniciId");

                    b.ToTable("sepet", (string)null);
                });

            modelBuilder.Entity("PCSite.Models.Sepeturun", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Fiyat")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("Miktar")
                        .HasColumnType("int");

                    b.Property<int?>("SepetId")
                        .HasColumnType("int");

                    b.Property<int?>("UrunId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "SepetId" }, "SepetId");

                    b.HasIndex(new[] { "UrunId" }, "UrunId");

                    b.ToTable("sepeturun", (string)null);
                });

            modelBuilder.Entity("PCSite.Models.Urun", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("Fiyat")
                        .HasColumnType("float");

                    b.Property<DateTime?>("GuncellemeTarihi")
                        .HasColumnType("datetime");

                    b.Property<string>("Kategori")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Marka")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("OlusturmaTarihi")
                        .HasColumnType("datetime");

                    b.Property<int>("SepetDurumu")
                        .HasColumnType("int");

                    b.Property<int>("StokMiktari")
                        .HasColumnType("int");

                    b.Property<string>("UrunAdi")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("urun", (string)null);
                });

            modelBuilder.Entity("PCSite.Models.UrunOzellik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Deger")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("OzellikId")
                        .HasColumnType("int");

                    b.Property<int>("UrunId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex("OzellikId");

                    b.HasIndex("UrunId");

                    b.ToTable("urunozellik", (string)null);
                });

            modelBuilder.Entity("PCSite.Models.Sepet", b =>
                {
                    b.HasOne("PCSite.Models.Kullanici", "Kullanici")
                        .WithMany("Sepets")
                        .HasForeignKey("KullaniciId")
                        .HasConstraintName("sepet_ibfk_1");

                    b.Navigation("Kullanici");
                });

            modelBuilder.Entity("PCSite.Models.Sepeturun", b =>
                {
                    b.HasOne("PCSite.Models.Sepet", "Sepet")
                        .WithMany("Sepeturuns")
                        .HasForeignKey("SepetId")
                        .HasConstraintName("sepeturun_ibfk_1");

                    b.HasOne("PCSite.Models.Urun", "Urun")
                        .WithMany("Sepeturuns")
                        .HasForeignKey("UrunId")
                        .HasConstraintName("sepeturun_ibfk_2");

                    b.Navigation("Sepet");

                    b.Navigation("Urun");
                });

            modelBuilder.Entity("PCSite.Models.UrunOzellik", b =>
                {
                    b.HasOne("PCSite.Models.Ozellik", "Ozellik")
                        .WithMany("UrunOzellikleri")
                        .HasForeignKey("OzellikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("urunozellik_ibfk_2");

                    b.HasOne("PCSite.Models.Urun", "Urun")
                        .WithMany("UrunOzellikleri")
                        .HasForeignKey("UrunId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("urunozellik_ibfk_1");

                    b.Navigation("Ozellik");

                    b.Navigation("Urun");
                });

            modelBuilder.Entity("PCSite.Models.Kullanici", b =>
                {
                    b.Navigation("Sepets");
                });

            modelBuilder.Entity("PCSite.Models.Ozellik", b =>
                {
                    b.Navigation("UrunOzellikleri");
                });

            modelBuilder.Entity("PCSite.Models.Sepet", b =>
                {
                    b.Navigation("Sepeturuns");
                });

            modelBuilder.Entity("PCSite.Models.Urun", b =>
                {
                    b.Navigation("Sepeturuns");

                    b.Navigation("UrunOzellikleri");
                });
#pragma warning restore 612, 618
        }
    }
}
