using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conferente",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(128)", nullable: false),
                    login = table.Column<string>(type: "varchar(64)", nullable: false),
                    senha = table.Column<string>(type: "varchar(64)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conferente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Entregador",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(128)", nullable: false),
                    login = table.Column<string>(type: "varchar(64)", nullable: false),
                    senha = table.Column<string>(type: "varchar(64)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entregador", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(128)", nullable: false),
                    valor = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Entrega",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    endereco = table.Column<string>(type: "varchar(128)", nullable: false),
                    valor = table.Column<double>(type: "float", nullable: false),
                    descricao = table.Column<string>(type: "varchar(128)", nullable: true),
                    inicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    fim = table.Column<DateTime>(type: "datetime", nullable: true),
                    conferenteID = table.Column<int>(type: "int", nullable: false),
                    entregadorID = table.Column<int>(type: "int", nullable: false),
                    Entregue = table.Column<bool>(type: "bit", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrega", x => x.id);
                    table.ForeignKey(
                        name: "FK_Entrega_Conferente_conferenteID",
                        column: x => x.conferenteID,
                        principalTable: "Conferente",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Entrega_Entregador_entregadorID",
                        column: x => x.entregadorID,
                        principalTable: "Entregador",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ProdutoEntrega",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    EntregaId = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoEntrega", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdutoEntrega_Entrega_EntregaId",
                        column: x => x.EntregaId,
                        principalTable: "Entrega",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ProdutoEntrega_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entrega_conferenteID",
                table: "Entrega",
                column: "conferenteID");

            migrationBuilder.CreateIndex(
                name: "IX_Entrega_entregadorID",
                table: "Entrega",
                column: "entregadorID");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoEntrega_EntregaId",
                table: "ProdutoEntrega",
                column: "EntregaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoEntrega_ProdutoId",
                table: "ProdutoEntrega",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrega_ProdutoEntrega_id",
                table: "Entrega",
                column: "id",
                principalTable: "ProdutoEntrega",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entrega_Conferente_conferenteID",
                table: "Entrega");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrega_Entregador_entregadorID",
                table: "Entrega");

            migrationBuilder.DropForeignKey(
                name: "FK_Entrega_ProdutoEntrega_id",
                table: "Entrega");

            migrationBuilder.DropTable(
                name: "Conferente");

            migrationBuilder.DropTable(
                name: "Entregador");

            migrationBuilder.DropTable(
                name: "ProdutoEntrega");

            migrationBuilder.DropTable(
                name: "Entrega");

            migrationBuilder.DropTable(
                name: "Produto");
        }
    }
}
