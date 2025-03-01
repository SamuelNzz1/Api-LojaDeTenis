using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiLoja.Migrations
{
    /// <inheritdoc />
    public partial class AlterarRelacaoCarrinhoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Carrinho_CarrinhoId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CarrinhoId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CarrinhoId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Carrinho",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Carrinho_UserId",
                table: "Carrinho",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Carrinho_Users_UserId",
                table: "Carrinho",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carrinho_Users_UserId",
                table: "Carrinho");

            migrationBuilder.DropIndex(
                name: "IX_Carrinho_UserId",
                table: "Carrinho");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Carrinho");

            migrationBuilder.AddColumn<int>(
                name: "CarrinhoId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CarrinhoId",
                table: "Users",
                column: "CarrinhoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Carrinho_CarrinhoId",
                table: "Users",
                column: "CarrinhoId",
                principalTable: "Carrinho",
                principalColumn: "CarrinhoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
