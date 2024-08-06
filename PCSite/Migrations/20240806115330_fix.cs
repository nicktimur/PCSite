using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCSite.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "urunozellik",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.UpdateData(
                table: "kullanici",
                keyColumn: "TelefonNumarasi",
                keyValue: null,
                column: "TelefonNumarasi",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "TelefonNumarasi",
                table: "kullanici",
                type: "varchar(15)",
                maxLength: 15,
                nullable: false,
                collation: "utf8mb4_0900_ai_ci",
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 15,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_urunozellik_ozellik_Id",
                table: "urunozellik",
                column: "Id",
                principalTable: "ozellik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_urunozellik_urun_Id",
                table: "urunozellik",
                column: "Id",
                principalTable: "urun",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_urunozellik_ozellik_Id",
                table: "urunozellik");

            migrationBuilder.DropForeignKey(
                name: "FK_urunozellik_urun_Id",
                table: "urunozellik");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "urunozellik",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "TelefonNumarasi",
                table: "kullanici",
                type: "int",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldMaxLength: 15)
                .OldAnnotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "IX_urunozellik_OzellikId",
                table: "urunozellik",
                column: "OzellikId");

            migrationBuilder.CreateIndex(
                name: "IX_urunozellik_UrunId",
                table: "urunozellik",
                column: "UrunId");

            migrationBuilder.AddForeignKey(
                name: "urunozellik_ibfk_1",
                table: "urunozellik",
                column: "UrunId",
                principalTable: "urun",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "urunozellik_ibfk_2",
                table: "urunozellik",
                column: "OzellikId",
                principalTable: "ozellik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
