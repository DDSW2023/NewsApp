using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyecto.Migrations
{
    /// <inheritdoc />
    public partial class migracionborrartemas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Noticias_Temas_TemaId",
                table: "Noticias");

            migrationBuilder.DropTable(
                name: "Imagen");

            migrationBuilder.DropTable(
                name: "Seccion");

            migrationBuilder.DropTable(
                name: "Temas");

            migrationBuilder.DropIndex(
                name: "IX_Noticias_TemaId",
                table: "Noticias");

            migrationBuilder.DropColumn(
                name: "TemaId",
                table: "Noticias");

            migrationBuilder.AddColumn<string>(
                name: "tema",
                table: "Noticias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tema",
                table: "Noticias");

            migrationBuilder.AddColumn<int>(
                name: "TemaId",
                table: "Noticias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Imagen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    formato = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cuerpo = table.Column<int>(type: "int", maxLength: 128, nullable: false),
                    titulo = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seccion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Temas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temas", x => x.Id);
                });

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
    }
}
