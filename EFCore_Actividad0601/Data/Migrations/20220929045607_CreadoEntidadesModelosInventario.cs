using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore_Actividad0601.Data.Migrations
{
    public partial class CreadoEntidadesModelosInventario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreadoPorUsuarioId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPorUsuarioId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false),
                    EstaEliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreadoPorUsuarioId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPorUsuarioId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false),
                    EstaEliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Participante",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreadoPorUsuarioId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPorUsuarioId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false),
                    EstaEliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participante", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Articulos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Notas = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    EstaEnVenta = table.Column<bool>(type: "bit", nullable: false),
                    FechaCompra = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaVenta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PrecioCompra = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PrecioFinalOActual = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CategoriaId = table.Column<int>(type: "int", nullable: true),
                    CreadoPorUsuarioId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoPorUsuarioId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false),
                    EstaEliminado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articulos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CategoriasDetalles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ColorValor = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    ColorNombre = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasDetalles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoriasDetalles_Categorias_Id",
                        column: x => x.Id,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticuloParticipante",
                columns: table => new
                {
                    ArticulosId = table.Column<int>(type: "int", nullable: false),
                    ParticipantesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticuloParticipante", x => new { x.ArticulosId, x.ParticipantesId });
                    table.ForeignKey(
                        name: "FK_ArticuloParticipante_Articulos_ArticulosId",
                        column: x => x.ArticulosId,
                        principalTable: "Articulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticuloParticipante_Participante_ParticipantesId",
                        column: x => x.ParticipantesId,
                        principalTable: "Participante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticulosGeneros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticuloId = table.Column<int>(type: "int", nullable: false),
                    GeneroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticulosGeneros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticulosGeneros_Articulos_ArticuloId",
                        column: x => x.ArticuloId,
                        principalTable: "Articulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticulosGeneros_Generos_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticuloParticipante_ParticipantesId",
                table: "ArticuloParticipante",
                column: "ParticipantesId");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_CategoriaId",
                table: "Articulos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticulosGeneros_ArticuloId_GeneroId",
                table: "ArticulosGeneros",
                columns: new[] { "ArticuloId", "GeneroId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArticulosGeneros_GeneroId",
                table: "ArticulosGeneros",
                column: "GeneroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticuloParticipante");

            migrationBuilder.DropTable(
                name: "ArticulosGeneros");

            migrationBuilder.DropTable(
                name: "CategoriasDetalles");

            migrationBuilder.DropTable(
                name: "Participante");

            migrationBuilder.DropTable(
                name: "Articulos");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
