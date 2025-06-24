using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fast_Teste.Migrations
{
    /// <inheritdoc />
    public partial class Migration01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entrega_ProdutoEntrega_produtoentregaid",
                table: "Entrega");

            migrationBuilder.DropForeignKey(
                name: "FK_Produto_ProdutoEntrega_produtoentregaid",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Produto_produtoentregaid",
                table: "Produto");

            migrationBuilder.DropIndex(
                name: "IX_Entrega_produtoentregaid",
                table: "Entrega");

            migrationBuilder.DropColumn(
                name: "produtoentregaid",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "teste",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "produtoentregaid",
                table: "Entrega");

            migrationBuilder.RenameColumn(
                name: "quantidade",
                table: "ProdutoEntrega",
                newName: "Quantidade");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ProdutoEntrega",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "EntregaId",
                table: "ProdutoEntrega",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProdutoId",
                table: "ProdutoEntrega",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Produtoid",
                table: "ProdutoEntrega",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Entrega",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<bool>(
                name: "Entregue",
                table: "Entrega",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoEntrega_EntregaId",
                table: "ProdutoEntrega",
                column: "EntregaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoEntrega_Produtoid",
                table: "ProdutoEntrega",
                column: "Produtoid",
                unique: true,
                filter: "[Produtoid] IS NOT NULL");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoEntrega_Entrega_EntregaId",
                table: "ProdutoEntrega",
                column: "EntregaId",
                principalTable: "Entrega",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoEntrega_Produto_ProdutoId",
                table: "ProdutoEntrega",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoEntrega_Produto_Produtoid",
                table: "ProdutoEntrega",
                column: "Produtoid",
                principalTable: "Produto",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entrega_ProdutoEntrega_id",
                table: "Entrega");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoEntrega_Entrega_EntregaId",
                table: "ProdutoEntrega");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoEntrega_Produto_ProdutoId",
                table: "ProdutoEntrega");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoEntrega_Produto_Produtoid",
                table: "ProdutoEntrega");

            migrationBuilder.DropIndex(
                name: "IX_ProdutoEntrega_EntregaId",
                table: "ProdutoEntrega");

            migrationBuilder.DropIndex(
                name: "IX_ProdutoEntrega_Produtoid",
                table: "ProdutoEntrega");

            migrationBuilder.DropIndex(
                name: "IX_ProdutoEntrega_ProdutoId",
                table: "ProdutoEntrega");

            migrationBuilder.DropColumn(
                name: "EntregaId",
                table: "ProdutoEntrega");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "ProdutoEntrega");

            migrationBuilder.DropColumn(
                name: "Produtoid",
                table: "ProdutoEntrega");

            migrationBuilder.DropColumn(
                name: "Entregue",
                table: "Entrega");

            migrationBuilder.RenameColumn(
                name: "Quantidade",
                table: "ProdutoEntrega",
                newName: "quantidade");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProdutoEntrega",
                newName: "id");

            migrationBuilder.AddColumn<int>(
                name: "produtoentregaid",
                table: "Produto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "teste",
                table: "Produto",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Entrega",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "produtoentregaid",
                table: "Entrega",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Produto_produtoentregaid",
                table: "Produto",
                column: "produtoentregaid");

            migrationBuilder.CreateIndex(
                name: "IX_Entrega_produtoentregaid",
                table: "Entrega",
                column: "produtoentregaid");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrega_ProdutoEntrega_produtoentregaid",
                table: "Entrega",
                column: "produtoentregaid",
                principalTable: "ProdutoEntrega",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_ProdutoEntrega_produtoentregaid",
                table: "Produto",
                column: "produtoentregaid",
                principalTable: "ProdutoEntrega",
                principalColumn: "id");
        }
    }
}
