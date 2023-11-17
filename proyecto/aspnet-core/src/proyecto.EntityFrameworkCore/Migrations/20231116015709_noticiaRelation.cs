using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyecto.Migrations
{
    /// <inheritdoc />
    public partial class noticiaRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.AddColumn<int>(
                name: "NoticiaId",
                table: "Noticias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Noticias_NoticiaId",
                table: "Noticias",
                column: "NoticiaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Noticias_Noticias_NoticiaId",
                table: "Noticias",
                column: "NoticiaId",
                principalTable: "Noticias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict); // Cambiado a ReferentialAction.Restrict
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Noticias_Noticias_NoticiaId",
                table: "Noticias");

            migrationBuilder.DropIndex(
                name: "IX_Noticias_NoticiaId",
                table: "Noticias");

            migrationBuilder.DropColumn(
                name: "NoticiaId",
                table: "Noticias");
        }
    }
}