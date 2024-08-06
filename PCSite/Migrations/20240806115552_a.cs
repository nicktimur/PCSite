using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCSite.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_urunozellik_ozellik_Id",
                table: "urunozellik");

            migrationBuilder.DropForeignKey(
                name: "FK_urunozellik_urun_Id",
                table: "urunozellik");

            migrationBuilder.AddForeignKey(
                name: "urunozellik_ibfk_1",
                table: "urunozellik",
                column: "Id",
                principalTable: "urun",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "urunozellik_ibfk_2",
                table: "urunozellik",
                column: "Id",
                principalTable: "ozellik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "urunozellik_ibfk_1",
                table: "urunozellik");

            migrationBuilder.DropForeignKey(
                name: "urunozellik_ibfk_2",
                table: "urunozellik");

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
    }
}
