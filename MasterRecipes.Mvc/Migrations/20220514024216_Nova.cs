using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MasterRecipes.Mvc.Migrations
{
    public partial class Nova : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Receitas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receitas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receitas_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReceitaIgredientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantidade = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnidadeMedida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceitaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceitaIgredientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceitaIgredientes_Receitas_ReceitaId",
                        column: x => x.ReceitaId,
                        principalTable: "Receitas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReceitaImagens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceitaId = table.Column<int>(type: "int", nullable: false),
                    Principal = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceitaImagens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceitaImagens_Receitas_ReceitaId",
                        column: x => x.ReceitaId,
                        principalTable: "Receitas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReceitaTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceitaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceitaTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceitaTags_Receitas_ReceitaId",
                        column: x => x.ReceitaId,
                        principalTable: "Receitas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReceitaIgredientes_ReceitaId",
                table: "ReceitaIgredientes",
                column: "ReceitaId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceitaImagens_ReceitaId",
                table: "ReceitaImagens",
                column: "ReceitaId");

            migrationBuilder.CreateIndex(
                name: "IX_Receitas_CategoriaId",
                table: "Receitas",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceitaTags_ReceitaId",
                table: "ReceitaTags",
                column: "ReceitaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReceitaIgredientes");

            migrationBuilder.DropTable(
                name: "ReceitaImagens");

            migrationBuilder.DropTable(
                name: "ReceitaTags");

            migrationBuilder.DropTable(
                name: "Receitas");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
