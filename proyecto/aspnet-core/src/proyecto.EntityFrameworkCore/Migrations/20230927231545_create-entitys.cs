using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyecto.Migrations
{
    /// <inheritdoc />
    public partial class createentitys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "nombreLista",
                table: "ListaNoticias",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ListaNoticiaId",
                table: "Noticias",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nombreLista",
                table: "ListaNoticias",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

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
    }
}
