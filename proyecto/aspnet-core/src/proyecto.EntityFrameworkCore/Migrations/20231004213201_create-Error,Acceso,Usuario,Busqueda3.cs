using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyecto.Migrations
{
    /// <inheritdoc />
    public partial class createErrorAccesoUsuarioBusqueda3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AlertaId",
                table: "Notificaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Notificaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ListaNoticiaId",
                table: "Alertas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    mail = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accesos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    horaInicio = table.Column<TimeSpan>(type: "time", nullable: false),
                    horaFin = table.Column<TimeSpan>(type: "time", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accesos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accesos_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Busquedas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    parametro = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Busquedas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Busquedas_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Errores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    AccesoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Errores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Errores_Accesos_AccesoId",
                        column: x => x.AccesoId,
                        principalTable: "Accesos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notificaciones_AlertaId",
                table: "Notificaciones",
                column: "AlertaId");

            migrationBuilder.CreateIndex(
                name: "IX_Notificaciones_UsuarioId",
                table: "Notificaciones",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Alertas_ListaNoticiaId",
                table: "Alertas",
                column: "ListaNoticiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Accesos_UsuarioId",
                table: "Accesos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Busquedas_UsuarioId",
                table: "Busquedas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Errores_AccesoId",
                table: "Errores",
                column: "AccesoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alertas_ListaNoticias_ListaNoticiaId",
                table: "Alertas",
                column: "ListaNoticiaId",
                principalTable: "ListaNoticias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notificaciones_Alertas_AlertaId",
                table: "Notificaciones",
                column: "AlertaId",
                principalTable: "Alertas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notificaciones_Usuario_UsuarioId",
                table: "Notificaciones",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alertas_ListaNoticias_ListaNoticiaId",
                table: "Alertas");

            migrationBuilder.DropForeignKey(
                name: "FK_Notificaciones_Alertas_AlertaId",
                table: "Notificaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Notificaciones_Usuario_UsuarioId",
                table: "Notificaciones");

            migrationBuilder.DropTable(
                name: "Busquedas");

            migrationBuilder.DropTable(
                name: "Errores");

            migrationBuilder.DropTable(
                name: "Accesos");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Notificaciones_AlertaId",
                table: "Notificaciones");

            migrationBuilder.DropIndex(
                name: "IX_Notificaciones_UsuarioId",
                table: "Notificaciones");

            migrationBuilder.DropIndex(
                name: "IX_Alertas_ListaNoticiaId",
                table: "Alertas");

            migrationBuilder.DropColumn(
                name: "AlertaId",
                table: "Notificaciones");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Notificaciones");

            migrationBuilder.DropColumn(
                name: "ListaNoticiaId",
                table: "Alertas");
        }
    }
}
