using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyecto.Migrations
{
    /// <inheritdoc />
    public partial class temaNoticias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TemaNoticia");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Secciones",
                table: "Secciones");

            migrationBuilder.RenameTable(
                name: "Secciones",
                newName: "Seccion");

            migrationBuilder.AddColumn<int>(
                name: "TemaId",
                table: "Noticias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "titulo",
                table: "Seccion",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seccion",
                table: "Seccion",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Noticias_TemaId",
                table: "Noticias",
                column: "TemaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Noticias_Temas_TemaId",
                table: "Noticias",
                column: "TemaId",
                principalTable: "Temas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Noticias_Temas_TemaId",
                table: "Noticias");

            migrationBuilder.DropIndex(
                name: "IX_Noticias_TemaId",
                table: "Noticias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seccion",
                table: "Seccion");

            migrationBuilder.DropColumn(
                name: "TemaId",
                table: "Noticias");

            migrationBuilder.RenameTable(
                name: "Seccion",
                newName: "Secciones");

            migrationBuilder.AlterColumn<string>(
                name: "titulo",
                table: "Secciones",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Secciones",
                table: "Secciones",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TemaNoticia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoticiaId = table.Column<int>(type: "int", nullable: false),
                    TemaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemaNoticia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemaNoticia_Noticias_NoticiaId",
                        column: x => x.NoticiaId,
                        principalTable: "Noticias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TemaNoticia_Temas_TemaId",
                        column: x => x.TemaId,
                        principalTable: "Temas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TemaNoticia_NoticiaId",
                table: "TemaNoticia",
                column: "NoticiaId");

            migrationBuilder.CreateIndex(
                name: "IX_TemaNoticia_TemaId",
                table: "TemaNoticia",
                column: "TemaId");
        }
    }
}
