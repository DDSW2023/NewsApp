using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyecto.Migrations
{
    /// <inheritdoc />
    public partial class migracionAlertas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alertas_ListaNoticias_ListaNoticiaId",
                table: "Alertas");

            migrationBuilder.AlterColumn<int>(
                name: "ListaNoticiaId",
                table: "Alertas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Alertas_ListaNoticias_ListaNoticiaId",
                table: "Alertas",
                column: "ListaNoticiaId",
                principalTable: "ListaNoticias",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alertas_ListaNoticias_ListaNoticiaId",
                table: "Alertas");

            migrationBuilder.AlterColumn<int>(
                name: "ListaNoticiaId",
                table: "Alertas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Alertas_ListaNoticias_ListaNoticiaId",
                table: "Alertas",
                column: "ListaNoticiaId",
                principalTable: "ListaNoticias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
