using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoEntrega_Produto_ProdutoID",
                table: "ProdutoEntrega");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoEntrega_Produto_ProdutoID",
                table: "ProdutoEntrega",
                column: "ProdutoID",
                principalTable: "Produto",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoEntrega_Produto_ProdutoID",
                table: "ProdutoEntrega");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoEntrega_Produto_ProdutoID",
                table: "ProdutoEntrega",
                column: "ProdutoID",
                principalTable: "Produto",
                principalColumn: "id");
        }
    }
}
