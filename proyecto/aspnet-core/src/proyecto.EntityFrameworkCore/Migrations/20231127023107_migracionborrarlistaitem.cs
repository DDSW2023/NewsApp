using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyecto.Migrations
{
    /// <inheritdoc />
    public partial class migracionborrarlistaitem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListaNoticiaItems");

            migrationBuilder.AddColumn<int>(
                name: "ListaNoticiasId",
                table: "Noticias",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Noticias_ListaNoticias_ListaNoticiasId",
                table: "Noticias");

            migrationBuilder.DropIndex(
                name: "IX_Noticias_ListaNoticiasId",
                table: "Noticias");

            migrationBuilder.DropColumn(
                name: "ListaNoticiasId",
                table: "Noticias");

            migrationBuilder.CreateTable(
                name: "ListaNoticiaItems",
                columns: table => new
                {
                    ListaNoticiaId = table.Column<int>(type: "int", nullable: false),
                    NoticiaId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaNoticiaItems", x => new { x.ListaNoticiaId, x.NoticiaId });
                    table.ForeignKey(
                        name: "FK_ListaNoticiaItems_ListaNoticias_ListaNoticiaId",
                        column: x => x.ListaNoticiaId,
                        principalTable: "ListaNoticias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListaNoticiaItems_Noticias_NoticiaId",
                        column: x => x.NoticiaId,
                        principalTable: "Noticias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListaNoticiaItems_NoticiaId",
                table: "ListaNoticiaItems",
                column: "NoticiaId");
        }
    }
}
