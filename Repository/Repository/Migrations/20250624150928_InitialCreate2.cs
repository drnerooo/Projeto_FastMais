using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoEntrega_Produto_ProdutoId",
                table: "ProdutoEntrega");

            migrationBuilder.RenameColumn(
                name: "ProdutoId",
                table: "ProdutoEntrega",
                newName: "ProdutoID");

            migrationBuilder.RenameIndex(
                name: "IX_ProdutoEntrega_ProdutoId",
                table: "ProdutoEntrega",
                newName: "IX_ProdutoEntrega_ProdutoID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoEntrega_Produto_ProdutoID",
                table: "ProdutoEntrega",
                column: "ProdutoID",
                principalTable: "Produto",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoEntrega_Produto_ProdutoID",
                table: "ProdutoEntrega");

            migrationBuilder.RenameColumn(
                name: "ProdutoID",
                table: "ProdutoEntrega",
                newName: "ProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_ProdutoEntrega_ProdutoID",
                table: "ProdutoEntrega",
                newName: "IX_ProdutoEntrega_ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoEntrega_Produto_ProdutoId",
                table: "ProdutoEntrega",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "id");
        }
    }
}
