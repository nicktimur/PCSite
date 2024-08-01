using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCSite.Migrations
{
    /// <inheritdoc />
    public partial class eav : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "satisdetay");

            migrationBuilder.DropTable(
                name: "urundetay");

            migrationBuilder.DropTable(
                name: "satis");

            migrationBuilder.DropColumn(
                name: "ToplamFiyat",
                table: "sepeturun");

            migrationBuilder.RenameIndex(
                name: "UrunId1",
                table: "sepeturun",
                newName: "UrunId");

            migrationBuilder.RenameIndex(
                name: "KullaniciId1",
                table: "sepet",
                newName: "KullaniciId");

            migrationBuilder.AddColumn<int>(
                name: "SepetDurumu",
                table: "urun",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Miktar",
                table: "sepeturun",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Fiyat",
                table: "sepeturun",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "ozellik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OzellikAdi = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OzellikTuru = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "urunozellik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UrunId = table.Column<int>(type: "int", nullable: false),
                    OzellikId = table.Column<int>(type: "int", nullable: false),
                    Deger = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "urunozellik_ibfk_1",
                        column: x => x.UrunId,
                        principalTable: "urun",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "urunozellik_ibfk_2",
                        column: x => x.OzellikId,
                        principalTable: "ozellik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "IX_urunozellik_OzellikId",
                table: "urunozellik",
                column: "OzellikId");

            migrationBuilder.CreateIndex(
                name: "IX_urunozellik_UrunId",
                table: "urunozellik",
                column: "UrunId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "urunozellik");

            migrationBuilder.DropTable(
                name: "ozellik");

            migrationBuilder.DropColumn(
                name: "SepetDurumu",
                table: "urun");

            migrationBuilder.DropColumn(
                name: "Fiyat",
                table: "sepeturun");

            migrationBuilder.RenameIndex(
                name: "UrunId",
                table: "sepeturun",
                newName: "UrunId1");

            migrationBuilder.RenameIndex(
                name: "KullaniciId",
                table: "sepet",
                newName: "KullaniciId1");

            migrationBuilder.AlterColumn<int>(
                name: "Miktar",
                table: "sepeturun",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<decimal>(
                name: "ToplamFiyat",
                table: "sepeturun",
                type: "decimal(65,30)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "satis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    KullaniciId = table.Column<int>(type: "int", nullable: true),
                    GuncellenmeTarihi = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    KargoDurumu = table.Column<sbyte>(type: "tinyint", nullable: true),
                    OdemeDurumu = table.Column<sbyte>(type: "tinyint", nullable: true),
                    SatisTarihi = table.Column<DateTime>(type: "datetime", nullable: true),
                    ToplamFiyat = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "satis_ibfk_1",
                        column: x => x.KullaniciId,
                        principalTable: "kullanici",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "urundetay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UrunId = table.Column<int>(type: "int", nullable: true),
                    Anakart = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Depolama = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EkranBoyutu = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EkranCozunurlugu = table.Column<string>(type: "longtext", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EkranKartı = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EkranYenilemeHizi = table.Column<int>(type: "int", nullable: true),
                    Islemci = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KlavyeBoyutu = table.Column<int>(type: "int", nullable: true),
                    KlavyeTuru = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RAM = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "urundetay_ibfk_1",
                        column: x => x.UrunId,
                        principalTable: "urun",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "satisdetay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SatisId = table.Column<int>(type: "int", nullable: true),
                    UrunId = table.Column<int>(type: "int", nullable: true),
                    BirimFiyat = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    Miktar = table.Column<int>(type: "int", nullable: true),
                    ToplamFiyat = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                    table.ForeignKey(
                        name: "satisdetay_ibfk_1",
                        column: x => x.SatisId,
                        principalTable: "satis",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "satisdetay_ibfk_2",
                        column: x => x.UrunId,
                        principalTable: "urun",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "KullaniciId",
                table: "satis",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "SatisId",
                table: "satisdetay",
                column: "SatisId");

            migrationBuilder.CreateIndex(
                name: "UrunId",
                table: "satisdetay",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "UrunId2",
                table: "urundetay",
                column: "UrunId");
        }
    }
}
