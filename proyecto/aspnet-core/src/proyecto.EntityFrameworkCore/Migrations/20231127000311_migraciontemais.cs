using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyecto.Migrations
{
    /// <inheritdoc />
    public partial class migraciontemais : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListaNoticias_ListaNoticias_ListaNoticiaId",
                table: "ListaNoticias");

            migrationBuilder.DropIndex(
                name: "IX_ListaNoticias_ListaNoticiaId",
                table: "ListaNoticias");

            migrationBuilder.DropColumn(
                name: "ListaNoticiaId",
                table: "ListaNoticias");

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "ListaNoticias",
                type: "int",
                maxLength: 128,
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "ListaNoticias");

            migrationBuilder.AddColumn<int>(
                name: "ListaNoticiaId",
                table: "ListaNoticias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ListaNoticias_ListaNoticiaId",
                table: "ListaNoticias",
                column: "ListaNoticiaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListaNoticias_ListaNoticias_ListaNoticiaId",
                table: "ListaNoticias",
                column: "ListaNoticiaId",
                principalTable: "ListaNoticias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
