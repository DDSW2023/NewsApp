using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyecto.Migrations
{
    /// <inheritdoc />
    public partial class migracionstring12312323123123123123123123 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Noticias_ListaNoticias_ListaNoticiasId",
                table: "Noticias");

            migrationBuilder.DropIndex(
                name: "IX_Noticias_ListaNoticiasId",
                table: "Noticias");

            migrationBuilder.AlterColumn<int>(
                name: "ListaNoticiasId",
                table: "Noticias",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ListaNoticiaId",
                table: "Noticias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Noticias_ListaNoticiaId",
                table: "Noticias",
                column: "ListaNoticiaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Noticias_ListaNoticias_ListaNoticiaId",
                table: "Noticias",
                column: "ListaNoticiaId",
                principalTable: "ListaNoticias",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Noticias_ListaNoticias_ListaNoticiaId",
                table: "Noticias");

            migrationBuilder.DropIndex(
                name: "IX_Noticias_ListaNoticiaId",
                table: "Noticias");

            migrationBuilder.DropColumn(
                name: "ListaNoticiaId",
                table: "Noticias");

            migrationBuilder.AlterColumn<int>(
                name: "ListaNoticiasId",
                table: "Noticias",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Noticias_ListaNoticiasId",
                table: "Noticias",
                column: "ListaNoticiasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Noticias_ListaNoticias_ListaNoticiasId",
                table: "Noticias",
                column: "ListaNoticiasId",
                principalTable: "ListaNoticias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
