using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fast_Teste.Migrations
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
                name: "ProdutoEntrega",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoEntrega", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Entrega",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    endereco = table.Column<string>(type: "varchar(128)", nullable: false),
                    valor = table.Column<double>(type: "float", nullable: false),
                    descricao = table.Column<string>(type: "varchar(128)", nullable: true),
                    inicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    fim = table.Column<DateTime>(type: "datetime", nullable: true),
                    conferenteID = table.Column<int>(type: "int", nullable: false),
                    entregadorID = table.Column<int>(type: "int", nullable: false),
                    produtoentregaid = table.Column<int>(type: "int", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_Entrega_ProdutoEntrega_produtoentregaid",
                        column: x => x.produtoentregaid,
                        principalTable: "ProdutoEntrega",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "varchar(128)", nullable: false),
                    valor = table.Column<double>(type: "float", nullable: false),
                    teste = table.Column<double>(type: "float", nullable: false),
                    produtoentregaid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.id);
                    table.ForeignKey(
                        name: "FK_Produto_ProdutoEntrega_produtoentregaid",
                        column: x => x.produtoentregaid,
                        principalTable: "ProdutoEntrega",
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
                name: "IX_Entrega_produtoentregaid",
                table: "Entrega",
                column: "produtoentregaid");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_produtoentregaid",
                table: "Produto",
                column: "produtoentregaid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entrega");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Conferente");

            migrationBuilder.DropTable(
                name: "Entregador");

            migrationBuilder.DropTable(
                name: "ProdutoEntrega");
        }
    }
}
